using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using Anthropic.Core.Telemetry;
using Anthropic.Exceptions;

namespace Anthropic.Core;

/// <summary>
/// OpenTelemetry tracing of the client's API calls, through <see cref="ActivitySource"/>, .NET's
/// tracing API, in which a span is an <see cref="Activity"/>.
///
/// <para>Two terms recur in this file, and wherever else the SDK documents its spans:</para>
/// <list type="bullet">
/// <item>An "API call" is one invocation of an SDK method that sends a request to the API. It
/// includes every retry, and reading the body or stream that the method returns. Its span, a
/// <see cref="ActivityKind.Client"/> span named after the method, is the "call span".</item>
/// <item>An "attempt" is one HTTP request within an API call, with its response when it receives
/// one. An API call that the SDK retries makes several attempts. This SDK emits no span per
/// attempt. The application's HTTP instrumentation, when it has one, emits each "attempt span" as
/// a child of the call span, because the call span is current while each request is sent.</item>
/// </list>
///
/// <para>An SDK method starts the call span and passes it to the client on its request
/// (<see cref="StartApiCallSpan"/>, <see cref="HttpRequest{P}.Span"/>), or names it
/// (<see cref="HttpRequest{P}.SpanName"/>) for the client to start it before the first attempt.
/// Either starts it with every attribute known by then, because a sampler decides on those that
/// a span starts with and sees none set later: the HTTP method and the route are among them
/// (<see cref="AddRequestAttributes"/>). The client sends the span's trace context with each
/// attempt (<see cref="InjectTraceHeaders"/>), and its innermost handler records each HTTP
/// request that it sends (<see cref="RecordRequest"/>): the URL of the first, and how many
/// followed it. The span ends with the call's result: at once
/// when the call fails, when the response body has been deserialized, or when the application
/// disposes of the response (<see cref="EndApiCallSpan(Activity)"/> and its overloads), or, for a
/// streamed body, when the application has read the stream or stopped reading it
/// (<see cref="EndApiCallSpanWhenStreamEnds"/>).</para>
/// </summary>
static class Tracing
{
    /// <summary>
    /// The source of the SDK's activities. A call emits one only while something listens to the
    /// source, such as a tracer provider of the OpenTelemetry .NET SDK that the application added
    /// the source to.
    /// </summary>
    internal static readonly ActivitySource Source = new(
        "com.anthropic.sdk.csharp",
        GetVersion(typeof(Tracing).Assembly)
    );

    /// <summary>
    /// The source of the activities of the clients for the cloud platform
    /// <paramref name="platform"/>, which the package of <paramref name="assembly"/> provides. Its
    /// name is that of <see cref="Source"/> and then the platform's short name, in lower case, as
    /// the package's name spells it. Its version is the package's own, because the package is
    /// versioned apart from the SDK. A package makes one source, and gives it to its clients
    /// (<see cref="ClientOptions.OpenTelemetrySource"/>).
    /// </summary>
    internal static ActivitySource PlatformSource(string platform, Assembly assembly) =>
        new(Source.Name + "." + platform, GetVersion(assembly));

    // The attributes of the OpenTelemetry semantic conventions that the span of any HTTP API call
    // has, named as the conventions' .NET constants name them.

    /// <summary>The <c>error.type</c> attribute: what kind of error an operation failed with.</summary>
    internal const string AttributeErrorType = "error.type";

    /// <summary>The <c>http.request.method</c> attribute: the HTTP method of the call's requests.</summary>
    internal const string AttributeHttpRequestMethod = "http.request.method";

    /// <summary>
    /// The <c>http.request.resend_count</c> attribute: how many times the SDK sent the call's
    /// request again, for any reason, such as a retry. A call that sent one request has none.
    /// </summary>
    internal const string AttributeHttpRequestResendCount = "http.request.resend_count";

    /// <summary>The <c>http.response.status_code</c> attribute: the status code of the final response.</summary>
    internal const string AttributeHttpResponseStatusCode = "http.response.status_code";

    /// <summary>
    /// The <c>http.route</c> attribute: the path of the call's endpoint as the API's description
    /// gives it, with the names of its parameters in place of their values.
    /// </summary>
    internal const string AttributeHttpRoute = "http.route";

    /// <summary>The <c>server.address</c> attribute: the host of the client's base URL.</summary>
    internal const string AttributeServerAddress = "server.address";

    /// <summary>The <c>server.port</c> attribute: the port of the client's base URL.</summary>
    internal const string AttributeServerPort = "server.port";

    // The `url.*` attributes describe the URL of the first HTTP request that the call sends.

    /// <summary>
    /// The <c>url.full</c> attribute: the URL, with <c>url.query</c> for its query string, so it
    /// can differ from the URL that was sent, and with its port only when it is not the scheme's
    /// default. A span that leaves out <c>url.query</c> because its value is content leaves this
    /// out too.
    /// </summary>
    internal const string AttributeUrlFull = "url.full";

    /// <summary>The <c>url.path</c> attribute: the URL's path, as sent.</summary>
    internal const string AttributeUrlPath = "url.path";

    /// <summary>
    /// The <c>url.query</c> attribute: the URL's query string, without the query parameters that
    /// the endpoint's description does not define (<see cref="DefinedQuery"/>). Its value is
    /// content when it has one of <see cref="ContentQueryParams"/>, or one of the endpoint's own
    /// <see cref="ParamsBase.ContentQueryParams"/>: then only a span that holds content has it.
    /// </summary>
    internal const string AttributeUrlQuery = "url.query";

    /// <summary>The <c>url.scheme</c> attribute: the URL's scheme.</summary>
    internal const string AttributeUrlScheme = "url.scheme";

    /// <summary>
    /// The name of the option of an HTTP request that holds the call span of the request's API
    /// call.
    /// </summary>
    const string CallSpanOption = "com.anthropic.sdk.csharp.call_span";

    /// <summary>
    /// The name of the custom property of a call span that holds the names of the query
    /// parameters that the call's endpoint defines.
    /// </summary>
    const string QueryParamsProperty = "com.anthropic.sdk.csharp.query_params";

    /// <summary>
    /// The name of the custom property of a call span that holds the names of the query
    /// parameters that are content on the call's endpoint only.
    /// </summary>
    const string ContentQueryParamsProperty = "com.anthropic.sdk.csharp.content_query_params";

    /// <summary>
    /// The name of the custom property of a call span that holds whether the span holds content.
    /// </summary>
    const string RecordsContentProperty = "com.anthropic.sdk.csharp.records_content";

    /// <summary>
    /// The name of the custom property of a call span that holds the number of HTTP requests that
    /// the call has sent.
    /// </summary>
    const string RequestCountProperty = "com.anthropic.sdk.csharp.request_count";

    /// <summary>
    /// Whether a client with <paramref name="options"/> emits spans. Without options, it does
    /// unless the <c>ANTHROPIC_OPEN_TELEMETRY</c> environment variable is <c>false</c>. Options
    /// that leave <c>Traces.Enabled</c> unset leave the spans on, whatever the variable says.
    /// </summary>
    internal static bool TracesEnabled(OpenTelemetryOptions? options) =>
        options == null ? ReadTraces() : options.Traces?.Enabled ?? true;

    /// <summary>
    /// Whether the <c>ANTHROPIC_OPEN_TELEMETRY</c> environment variable leaves the spans on: it does
    /// unless it is <c>false</c>.
    /// </summary>
    internal static bool ReadTraces() =>
        !string.Equals(
            Environment.GetEnvironmentVariable("ANTHROPIC_OPEN_TELEMETRY"),
            "false",
            StringComparison.OrdinalIgnoreCase
        );

    /// <summary>
    /// Starts the call span named <paramref name="name"/> of an API call that an SDK method of a
    /// client with <paramref name="options"/> is about to make, as a child of the current activity,
    /// with <paramref name="tags"/>, the attributes that a sampler decides on, and makes it the
    /// current activity. It is an activity of <paramref name="source"/>, the source of the
    /// client's options, or of <see cref="Source"/> without one. The method passes it to the
    /// client on its request (<see cref="HttpRequest{P}.Span"/>). Call it from an async method, so
    /// that the caller's current activity is unchanged.
    ///
    /// <para>Returns null when the options disable spans, or when nothing listens for the span:
    /// then the call runs as if tracing were off.</para>
    /// </summary>
    internal static Activity? StartApiCallSpan(
        OpenTelemetryOptions? options,
        string name,
        IEnumerable<KeyValuePair<string, object?>> tags,
        ActivitySource? source = null
    ) => StartSpan(options, name, ActivityKind.Client, tags, source);

    /// <summary>
    /// Whether a span of <paramref name="source"/>, or of <see cref="Source"/> without one, would
    /// have a listener. A method asks before it builds anything for a span, and asks for the
    /// client's options only after: without a listener, that is all a call does for its span.
    /// </summary>
    internal static bool HasListeners(ActivitySource? source) => (source ?? Source).HasListeners();

    /// <summary>
    /// Whether a client with <paramref name="options"/> would emit a span now: something listens
    /// to its source, and the options leave spans on. A method asks before it builds the
    /// attributes that the span starts with.
    /// </summary>
    internal static bool IsEnabled(ClientOptions options) =>
        HasListeners(options.OpenTelemetrySource) && TracesEnabled(options.ResolvedOpenTelemetry);

    /// <summary>
    /// Starts a span of <paramref name="source"/>, or of <see cref="Source"/> without one, for a
    /// client with <paramref name="options"/>, or returns null when nothing listens for it or the
    /// options disable spans. Whether anything listens is asked first, since
    /// <see cref="TracesEnabled"/> can read the environment. A caller whose
    /// <paramref name="tags"/> take work to build asks <see cref="HasListeners"/> or
    /// <see cref="IsEnabled"/> before it builds them.
    ///
    /// <para>A listener or a sampler that throws as the span starts leaves the call without a
    /// span: it must not fail the call.</para>
    /// </summary>
    internal static Activity? StartSpan(
        OpenTelemetryOptions? options,
        string name,
        ActivityKind kind,
        IEnumerable<KeyValuePair<string, object?>>? tags = null,
        ActivitySource? source = null
    )
    {
        source ??= Source;
        if (!source.HasListeners() || !TracesEnabled(options))
        {
            return null;
        }
        var current = Activity.Current;
        try
        {
            return source.StartActivity(name, kind, default(ActivityContext), tags);
        }
        catch (Exception)
        {
            Activity.Current = current;
            return null;
        }
    }

    /// <summary>
    /// The attributes that the call span that <paramref name="request"/> names starts with, for a
    /// client with <paramref name="options"/>: those of the options, and what the method gave the
    /// request.
    /// </summary>
    internal static List<KeyValuePair<string, object?>> StartAttributes<P>(
        ClientOptions options,
        HttpRequest<P> request
    )
        where P : ParamsBase
    {
        var tags = ApiCallSpans.StartAttributes(options, request.SpanResourceIds);
        AddRequestAttributes(tags, request.Method, request.Params);
        return tags;
    }

    /// <summary>
    /// Adds to <paramref name="tags"/>, the attributes that a call span starts with, what is known
    /// of the call's HTTP requests before the first is built: <c>http.request.method</c> from
    /// <paramref name="method"/>, and <c>http.route</c> from the endpoint of
    /// <paramref name="parameters"/>. The route is the API's own on every client: a client for a
    /// cloud platform that sends the request to another path has that path as <c>url.path</c>.
    /// </summary>
    internal static void AddRequestAttributes(
        List<KeyValuePair<string, object?>> tags,
        HttpMethod method,
        ParamsBase parameters
    )
    {
        tags.Add(new(AttributeHttpRequestMethod, method.Method));
        if (parameters.Route is { } route)
        {
            tags.Add(new(AttributeHttpRoute, route));
        }
    }

    /// <summary>
    /// Gives <paramref name="headers"/>, the headers of an attempt's HTTP request, the trace context
    /// of <paramref name="span"/>, the call span, as the propagator that the application registered
    /// writes it, in place of any such headers already present. The client sends these with each
    /// attempt, so a retry carries the context afresh.
    ///
    /// <para>A propagator that throws leaves the request without the headers that it had not yet
    /// written: it must not keep the request from being sent.</para>
    /// </summary>
    internal static void InjectTraceHeaders(Activity span, HttpRequestHeaders headers)
    {
        try
        {
            DistributedContextPropagator.Current.Inject(
                span,
                headers,
                static (carrier, key, value) =>
                {
                    if (carrier is HttpRequestHeaders headers && value != null)
                    {
                        headers.Remove(key);
                        headers.TryAddWithoutValidation(key, value);
                    }
                }
            );
        }
        catch (Exception) { }
    }

    /// <summary>
    /// Makes <paramref name="requestMessage"/>, the HTTP request of an attempt of the API call
    /// with <paramref name="parameters"/>, carry <paramref name="span"/>, the call span, so that
    /// the client's innermost handler records the request on it when it sends it
    /// (<see cref="RecordRequest"/>). A handler that sends the request again in a copy that keeps
    /// its options has that copy recorded too. <paramref name="recordsContent"/> says whether the
    /// client's spans hold content. Does nothing for a span that is not recording.
    /// </summary>
    internal static void TrackRequest(
        HttpRequestMessage requestMessage,
        Activity span,
        ParamsBase parameters,
        bool recordsContent
    )
    {
        if (!span.IsAllDataRequested)
        {
            return;
        }
        span.SetCustomProperty(QueryParamsProperty, parameters.QueryParams);
        span.SetCustomProperty(ContentQueryParamsProperty, parameters.ContentQueryParams);
        span.SetCustomProperty(RecordsContentProperty, recordsContent);
#if NET
        requestMessage.Options.Set(new HttpRequestOptionsKey<Activity>(CallSpanOption), span);
#else
        requestMessage.Properties[CallSpanOption] = span;
#endif
    }

    /// <summary>
    /// Records <paramref name="requestMessage"/>, an HTTP request that is about to be sent, on the
    /// call span that it carries (<see cref="TrackRequest"/>), and does nothing for a request
    /// that carries none. The client's innermost handler calls it: there the request has the URL
    /// that a client for a cloud platform gave it, and not yet the one that a redirect would.
    ///
    /// <para>The span gets the <c>url.*</c> attributes from the call's first request, and no
    /// later request changes them. Each request is counted, for
    /// <c>http.request.resend_count</c>, which the span gets as it ends.</para>
    /// </summary>
    internal static void RecordRequest(HttpRequestMessage requestMessage)
    {
#if NET
        requestMessage.Options.TryGetValue(
            new HttpRequestOptionsKey<Activity>(CallSpanOption),
            out var span
        );
#else
        var span = requestMessage.Properties.TryGetValue(CallSpanOption, out var value)
            ? value as Activity
            : null;
#endif
        if (span == null || span.IsStopped)
        {
            return;
        }
        var requestCount = span.GetCustomProperty(RequestCountProperty) as int? ?? 0;
        span.SetCustomProperty(RequestCountProperty, requestCount + 1);
        if (requestCount == 0 && requestMessage.RequestUri is { IsAbsoluteUri: true } url)
        {
            try
            {
                SetUrlAttributes(
                    span,
                    url,
                    span.GetCustomProperty(QueryParamsProperty) as IReadOnlyList<string> ?? [],
                    span.GetCustomProperty(ContentQueryParamsProperty) as IReadOnlyList<string>
                        ?? [],
                    span.GetCustomProperty(RecordsContentProperty) is true
                );
            }
            catch (Exception)
            {
                // A URL that cannot be recorded must not keep the request from being sent.
            }
        }
    }

    /// <summary>
    /// Sets the <c>url.*</c> attributes on <paramref name="span"/>, a call span, from
    /// <paramref name="url"/>, the URL of the call's first HTTP request, whose endpoint defines the
    /// query parameters <paramref name="queryParams"/>, of which
    /// <paramref name="contentQueryParams"/> are content on that endpoint only. A query string
    /// whose value is content is left out, and <c>url.full</c> with it, unless
    /// <paramref name="recordsContent"/>: the span holds content.
    /// </summary>
    static void SetUrlAttributes(
        Activity span,
        Uri url,
        IReadOnlyList<string> queryParams,
        IReadOnlyList<string> contentQueryParams,
        bool recordsContent
    )
    {
        // `Uri.Query` starts with the `?` of a URL that has a query string.
        var query = DefinedQuery(
            url.Query.Length > 0 ? url.Query.Substring(1) : "",
            queryParams,
            contentQueryParams,
            out var isContent
        );
        span.SetTag(AttributeUrlScheme, url.Scheme);
        span.SetTag(AttributeUrlPath, url.AbsolutePath);
        if (isContent && !recordsContent)
        {
            return;
        }
        if (query != null)
        {
            span.SetTag(AttributeUrlQuery, query);
        }
        StringBuilder full = new();
        // `Uri.Host` keeps the brackets of an IPv6 literal, which delimit it in a URL.
        full.Append(url.Scheme).Append("://").Append(url.Host);
        if (!url.IsDefaultPort)
        {
            full.Append(':').Append(url.Port.ToString(CultureInfo.InvariantCulture));
        }
        full.Append(url.AbsolutePath);
        if (query != null)
        {
            full.Append('?').Append(query);
        }
        span.SetTag(AttributeUrlFull, full.ToString());
    }

    /// <summary>
    /// What <c>url.query</c> has of <paramref name="query"/>, a URL's query string without its
    /// <c>?</c>, for an endpoint that defines the query parameters <paramref name="queryParams"/>:
    /// the pairs of <paramref name="query"/> that <see cref="RecordsQueryParam"/> keeps, as sent
    /// and in the order sent. Null when none is left. <paramref name="isContent"/> says whether
    /// one of them is a pair of one of <see cref="ContentQueryParams"/> or of one of
    /// <paramref name="contentQueryParams"/>, the parameters that are content on that endpoint
    /// only, which makes the value content.
    ///
    /// <para>A pair is kept when its percent-decoded name, in full, is one of the parameters, or
    /// when the name ends in <c>[]</c> and the name without that ending is one of them: an array
    /// parameter <c>ids</c> is sent as <c>ids[]</c>, while <c>created_at[gte]</c> is the name of
    /// a parameter of its own. Any other name with brackets, such as <c>limit[x]</c> on an
    /// endpoint that defines <c>limit</c>, is left out, and so is what the SDK or the
    /// application adds to a query string besides the endpoint's parameters, such as
    /// <c>beta=true</c>.</para>
    /// </summary>
    internal static string? DefinedQuery(
        string query,
        IReadOnlyList<string> queryParams,
        IReadOnlyList<string> contentQueryParams,
        out bool isContent
    )
    {
        isContent = false;
        StringBuilder? defined = null;
        foreach (var pair in query.Split('&'))
        {
            var equals = pair.IndexOf('=');
            var name = Uri.UnescapeDataString(
                (equals < 0 ? pair : pair.Substring(0, equals)).Replace('+', ' ')
            );
            if (!RecordsQueryParam(name, queryParams))
            {
                if (name.Length <= 2 || !name.EndsWith("[]", StringComparison.Ordinal))
                {
                    continue;
                }
                name = name.Substring(0, name.Length - 2);
                if (!RecordsQueryParam(name, queryParams))
                {
                    continue;
                }
            }
            defined = defined == null ? new() : defined.Append('&');
            defined.Append(pair);
            isContent |=
                Enumerable.Contains(ContentQueryParams, name, StringComparer.Ordinal)
                || Enumerable.Contains(contentQueryParams, name, StringComparer.Ordinal);
        }
        return defined?.ToString();
    }

    /// <summary>
    /// Whether <c>url.query</c> records the query parameter <paramref name="name"/> of an endpoint
    /// that defines the query parameters <paramref name="queryParams"/>: when it is one of them.
    /// </summary>
    static bool RecordsQueryParam(string name, IReadOnlyList<string> queryParams) =>
        Enumerable.Contains(queryParams, name, StringComparer.Ordinal);

    /// <summary>
    /// The query parameters whose value is content, such as one that filters like a search, or
    /// one whose value comes from stored content. A query string that has one of them is content
    /// as a whole.
    ///
    /// <para>These are content on every endpoint that defines them. An endpoint names the others
    /// that are content on it only (<see cref="ParamsBase.ContentQueryParams"/>).</para>
    /// </summary>
    static readonly string[] ContentQueryParams =
    [
        "email",
        "expected_content_sha256",
        "path_prefix",
    ];

    /// <summary>
    /// Sets <c>http.response.status_code</c> on <paramref name="span"/>, the call span of an API
    /// call, from <paramref name="response"/>, the response of the call's final attempt. An attempt
    /// that the client retries is not final. The client sets it as soon as that response arrives,
    /// so that a call that fails on its status has it too.
    /// </summary>
    internal static void SetResponseStatusCode(Activity span, HttpResponseMessage response) =>
        span.SetTag(AttributeHttpResponseStatusCode, (int)response.StatusCode);

    /// <summary>
    /// Sets on <paramref name="span"/>, the call span of an API call that created
    /// <paramref name="created"/>, the attribute <paramref name="name"/>: the ID of the created
    /// object, which <paramref name="id"/> reads from it. The attribute is left out when the object
    /// has no such field.
    ///
    /// <para>Never throws into the API call, and does nothing without a span, or to one that is
    /// not recording.</para>
    /// </summary>
    internal static void SetCreatedId<T>(
        Activity? span,
        string name,
        T created,
        Func<T, string?> id
    ) =>
        // A model throws for a required field that the response does not have.
        ActivityTags.Record(
            span,
            recordingSpan => ActivityTags.SetTag(recordingSpan, name, id(created))
        );

    /// <summary>
    /// Ends <paramref name="span"/>, the call span of an API call that ran its course: the client
    /// deserialized the response body, or the application disposed of a response that is not a
    /// stream. Its status is <c>Ok</c>. The span of a streamed body that the application has
    /// started to read ends through <see cref="EndApiCallSpanWhenStreamEnds"/> instead.
    ///
    /// <para>Does nothing to a span that already ended.</para>
    /// </summary>
    internal static void EndApiCallSpan(Activity span)
    {
        if (span.IsStopped)
        {
            return;
        }
        span.SetStatus(ActivityStatusCode.Ok);
        End(span);
    }

    /// <summary>
    /// Ends <paramref name="span"/>, the call span of an API call that failed with
    /// <paramref name="error"/>: its status is <c>Error</c> with an <c>error.type</c>, unless
    /// <paramref name="cancellationToken"/>, the application's token for the code that failed,
    /// requested the cancellation, which leaves the status unset.
    ///
    /// <para>Does nothing to a span that already ended.</para>
    /// </summary>
    internal static void EndApiCallSpan(
        Activity span,
        Exception error,
        CancellationToken cancellationToken
    )
    {
        if (span.IsStopped)
        {
            return;
        }
        SetErrorStatus(span, error, cancellationToken);
        End(span);
    }

    /// <summary>
    /// Ends <paramref name="span"/>, the call span of an API call whose streamed body the
    /// application disposed of unread. That is the application's choice, so, like a cancellation,
    /// it leaves the status unset.
    ///
    /// <para>Does nothing to a span that already ended.</para>
    /// </summary>
    internal static void EndApiCallSpanOfUnreadStream(Activity span)
    {
        if (span.IsStopped)
        {
            return;
        }
        End(span);
    }

    /// <summary>
    /// Makes <paramref name="span"/>, the call span of an API call whose streamed response body
    /// <paramref name="stream"/> the application is about to read, end when that read ends, and
    /// returns the stream to read in its place, which reads through <paramref name="stream"/>: the
    /// span ends with the status <c>Ok</c> once the application has read it to the end, with an
    /// error when reading fails, and with no status when the application stops reading early or
    /// cancels <paramref name="cancellationToken"/>. <paramref name="response"/> is the response
    /// that has the body. For a stream that has an end event, <paramref name="hasReadEndEvent"/> says
    /// whether the items read so far include that event: then a stream that the server ends before
    /// it is an <c>api_error</c>. The application stopping early leaves no status even after that
    /// event, because the server had not ended the stream yet, so the application canceled the
    /// call. A stream of server-sent events (a <c>text/event-stream</c> body) without
    /// <paramref name="hasReadEndEvent"/> has no end event, so it is never read to the end: when the
    /// server ends it, the span ends with no status.
    ///
    /// <para>Does nothing to a span that already ended, such as one whose stream was read before:
    /// then <paramref name="stream"/> comes back as it is, and fails as a second read does.</para>
    /// </summary>
    internal static IAsyncEnumerable<T> EndApiCallSpanWhenStreamEnds<T>(
        Activity span,
        IAsyncEnumerable<T> stream,
        HttpResponseMessage response,
        Func<bool>? hasReadEndEvent = null,
        CancellationToken cancellationToken = default
    )
    {
        if (span.IsStopped)
        {
            return stream;
        }
        // The span ends when the read ends, for every kind of body. The kind only decides the
        // status of a body that the server ended: server-sent events are complete when their end
        // event was read, since a stream that the server cut short ends the same way, and any
        // other body is complete at its end.
        var isServerSentEvents =
            response.Content?.Headers.ContentType?.MediaType == "text/event-stream";
        return IterateAndEndSpan(
            stream,
            span,
            hasReadEndEvent,
            isServerSentEvents,
            cancellationToken
        );
    }

    /// <summary>
    /// The stream that <see cref="EndApiCallSpanWhenStreamEnds"/> returns: it reads
    /// <paramref name="source"/> through to the application and gives <paramref name="span"/> the
    /// outcome of that read and ends it exactly once, however the read ends: exhausted, failed,
    /// stopped early by the application, or canceled through <paramref name="cancellationToken"/>.
    /// <paramref name="hasReadEndEvent"/> and <paramref name="isServerSentEvents"/> decide the status as that method
    /// describes.
    /// </summary>
    static async IAsyncEnumerable<T> IterateAndEndSpan<T>(
        IAsyncEnumerable<T> source,
        Activity span,
        Func<bool>? hasReadEndEvent,
        bool isServerSentEvents,
        [EnumeratorCancellationAttribute] CancellationToken cancellationToken = default
    )
    {
        var enumerator = source.GetAsyncEnumerator(cancellationToken);
        try
        {
            while (true)
            {
                bool moved;
                try
                {
                    moved = await enumerator.MoveNextAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    // Reading failed: an `error` event, or a lost connection.
                    SetErrorStatus(span, e, cancellationToken);
                    throw;
                }
                if (!moved)
                {
                    // Nothing looks for the end event of a span that is not recording.
                    if (hasReadEndEvent != null && span.IsAllDataRequested)
                    {
                        if (hasReadEndEvent())
                        {
                            span.SetStatus(ActivityStatusCode.Ok);
                        }
                        else
                        {
                            // The application sees such a stream end without an error, so only
                            // the span fails. The server cut the stream short, so the failure is
                            // the API's.
                            SetErrorStatus(span, "api_error");
                        }
                    }
                    else if (!isServerSentEvents)
                    {
                        span.SetStatus(ActivityStatusCode.Ok);
                    }
                    // Events without an end event are never read to the end: no status.
                    yield break;
                }
                // The application's early `break` or dispose resumes here and runs `finally`.
                yield return enumerator.Current;
            }
        }
        finally
        {
            // The source is disposed of first: a stream that records attributes as it is read
            // records the last of them then.
            await enumerator.DisposeAsync().ConfigureAwait(false);
            // Stopped early by the application, even after the end event, is a cancellation,
            // which has no status: the server had not ended the stream.
            End(span);
        }
    }

    /// <summary>
    /// Gives <paramref name="span"/> the status of an operation that failed with
    /// <paramref name="error"/>: <c>Error</c>, with the <c>error.type</c> derived from it. A
    /// cancellation that <paramref name="cancellationToken"/>, the application's token for the
    /// operation, requested is the application's choice, not a failure, and leaves the status
    /// unset.
    /// </summary>
    internal static void SetErrorStatus(
        Activity span,
        Exception error,
        CancellationToken cancellationToken
    )
    {
        if (error is OperationCanceledException && cancellationToken.IsCancellationRequested)
        {
            return;
        }
        SetErrorStatus(span, ErrorType(error));
    }

    /// <summary>
    /// Gives <paramref name="span"/> the status <c>Error</c> with the <c>error.type</c>
    /// <paramref name="type"/>.
    /// </summary>
    internal static void SetErrorStatus(Activity span, string type)
    {
        span.SetStatus(ActivityStatusCode.Error);
        span.SetTag(AttributeErrorType, type);
    }

    /// <summary>
    /// The <c>error.type</c> of an operation that failed with <paramref name="error"/>. An error
    /// from the API has the type of its error envelope when the API sent one, and its status code
    /// otherwise. A cancellation is a timeout, because one that the application requested never
    /// gets here.
    /// </summary>
    static string ErrorType(Exception error)
    {
        // The envelope is the body of an error response, or the data of a stream's `error` event.
        // It is read as text, so a type that this SDK version does not know is kept as sent.
        var envelopeJson = error switch
        {
            AnthropicApiException { ResponseBody: var body } => body,
            AnthropicSseException { EventData: var data } => data,
            _ => null,
        };
        if (
            envelopeJson != null
            && JsonNodes.ParseObject(envelopeJson)?["error"] is JsonObject envelope
            && JsonNodes.GetString(envelope["type"]) is { Length: > 0 } raw
        )
        {
            return raw;
        }
        if (
            error is AnthropicServiceException { ErrorType: { } errorType }
            && JsonSerializer.SerializeToElement(errorType, ModelBase.SerializerOptions)
                is { ValueKind: JsonValueKind.String } element
        )
        {
            return element.GetString() ?? "api_error";
        }
        return error switch
        {
            OperationCanceledException => "client_timeout_error",
            AnthropicIOException or IOException or HttpRequestException => "connection_error",
            AnthropicApiException apiException => ((int)apiException.StatusCode).ToString(),
            _ => "client_error",
        };
    }

    /// <summary>
    /// Stops <paramref name="span"/>. The span of an API call that sent more than one HTTP request
    /// (<see cref="RecordRequest"/>) first gets <c>http.request.resend_count</c>. Stopping an
    /// activity makes its parent the current activity, which is right only where the activity is
    /// the current one, so elsewhere the current activity is put back.
    ///
    /// <para>Never throws: a span ends where a call returns its result or throws its error, and
    /// a listener that throws as the span stops must not take the place of either.</para>
    /// </summary>
    internal static void End(Activity span)
    {
        // Every request that the call sent after its first is one that the SDK sent again.
        if (span.GetCustomProperty(RequestCountProperty) is int requestCount && requestCount > 1)
        {
            span.SetTag(AttributeHttpRequestResendCount, requestCount - 1);
        }
        var current = Activity.Current;
        try
        {
            span.Stop();
        }
        catch (Exception)
        {
            // The listener threw before `Stop` made the activity before the span current.
            Activity.Current = current == span ? span.Parent : current;
            return;
        }
        if (current != span)
        {
            Activity.Current = current;
        }
    }

    /// <summary>
    /// The version of the package of <paramref name="assembly"/>, for the instrumentation scope:
    /// the assembly's informational version without its build metadata.
    /// </summary>
    static string? GetVersion(Assembly assembly)
    {
        var version = assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            ?.InformationalVersion;
        // The informational version can end with build metadata, such as a commit hash.
        var metadata = version?.IndexOf('+') ?? -1;
        return metadata < 0 ? version : version!.Substring(0, metadata);
    }
}
