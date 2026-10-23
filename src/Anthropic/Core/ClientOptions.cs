using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core.Telemetry;
using Anthropic.Credentials;

namespace Anthropic.Core;

/// <summary>
/// A class representing the SDK client configuration.
/// </summary>
public record struct ClientOptions
{
    /// <summary>
    /// The default value used for <see cref="MaxRetries"/>.
    /// </summary>
    public static readonly int DefaultMaxRetries = 2;

    /// <summary>
    /// The default value used for <see cref="Timeout"/>.
    /// </summary>
    public static readonly TimeSpan DefaultTimeout = TimeSpan.FromMinutes(10);

    HttpClient _httpClient = new(
        new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.Available }
    )
    {
        Timeout = global::System.Threading.Timeout.InfiniteTimeSpan,
    };
    Lazy<HttpMessageInvoker> _messageInvoker;

    /// <summary>
    /// The HTTP client to use for making requests in the SDK.
    ///
    /// <para>When <see cref="Handlers"/> is non-empty, the handlers are attached to
    /// this client when the first request is sent.</para>
    ///
    /// <para>Note: The HttpClient has a built-in timeout, which defaults to 100 seconds. When passing a custom HttpClient,
    /// this timeout may conflict with the SDK's own timeout handler and cause premature cancellation.</para>
    /// </summary>
    public HttpClient HttpClient
    {
        readonly get { return _httpClient; }
        set
        {
            _httpClient = value;
            _messageInvoker = BuildMessageInvoker();
        }
    }

    IReadOnlyList<DelegatingHandler> _handlers = [];

    /// <summary>
    /// The handlers to attach to <see cref="HttpClient"/> when the first request is sent.
    ///
    /// <para>Each handler wraps the next one, and the last handler wraps <see cref="HttpClient"/>
    /// itself, making the last handler the innermost one.</para>
    ///
    /// <para>Cloud-backend clients (Bedrock, Vertex, Foundry, AWS) attach their own adaptation
    /// handler inside all of these handlers, so handlers always observe Anthropic-shaped requests
    /// and normalized responses; the backend's URL/body rewriting, request signing, and response
    /// translation happen after every handler has run. Handlers must therefore keep requests
    /// Anthropic-shaped (e.g. a <c>/v1/...</c> path with <c>model</c> in the body).</para>
    ///
    /// <para>Setting this property throws an <see cref="ArgumentException"/> if any handler is already
    /// attached to a client.</para>
    /// </summary>
    public IReadOnlyList<DelegatingHandler> Handlers
    {
        readonly get { return _handlers; }
        set
        {
            var handlers = new List<DelegatingHandler>(value);
            foreach (var handler in handlers)
            {
                if (handler.InnerHandler != null)
                {
                    throw new ArgumentException(
                        "Handler is already attached to a client",
                        nameof(value)
                    );
                }
            }

            _handlers = handlers;
            _messageInvoker = BuildMessageInvoker();
        }
    }

    Func<DelegatingHandler>? _backendAdaptationHandler;

    /// <summary>
    /// Factory for the handler that adapts requests and responses for a cloud backend
    /// (URL/body rewriting, request signing, response normalization).
    ///
    /// <para>The created handler is attached inside all user
    /// <see cref="Handlers"/>, so user handlers observe Anthropic-shaped requests and
    /// normalized responses, and any request mutation they perform is covered by backend
    /// request signing, except for the trace-context headers, which the handler does not see
    /// (<see cref="UnsignedTraceContextHandler"/>). A factory (rather than an instance) because
    /// every attached handler chain needs its own unattached instance.</para>
    /// </summary>
    internal Func<DelegatingHandler>? BackendAdaptationHandler
    {
        readonly get { return _backendAdaptationHandler; }
        set
        {
            _backendAdaptationHandler = value;
            _messageInvoker = BuildMessageInvoker();
        }
    }

    /// <summary>
    /// Builds a lazy invoker from a snapshot of the fields that make up the handler
    /// chain. Every setter that affects the chain must reassign
    /// <see cref="_messageInvoker"/> with this.
    /// </summary>
    readonly Lazy<HttpMessageInvoker> BuildMessageInvoker()
    {
        var httpClient = _httpClient;
        var handlers = _handlers;
        var backendAdaptationHandler = _backendAdaptationHandler;
        return new(() => AttachHandlers(httpClient, handlers, backendAdaptationHandler));
    }

    Lazy<string> _baseUrl = new(() =>
        Environment.GetEnvironmentVariable("ANTHROPIC_BASE_URL") ?? EnvironmentUrl.Production
    );
    internal bool BaseUrlExplicit { get; private set; }

    /// <summary>
    /// The base URL to use for every request.
    ///
    /// <para>Defaults to the production environment: <see cref="EnvironmentUrl.Production"/></para>
    /// </summary>
    public string BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set
        {
            _baseUrl = new(() => value);
            BaseUrlExplicit = true;
        }
    }

    /// <summary>
    /// Whether to validate response bodies before returning them.
    ///
    /// <para>Defaults to false, which means the shape of the response body will not be validated upfront.
    /// Instead, validation will only occur for the parts of the response body that are accessed.</para>
    ///
    /// <para>Note that when set to true, the response body is only validated if the response is
    /// deserialized. Methods that don't eagerly deserialize the response, such as those on
    /// <see cref="IAnthropicClient.WithRawResponse"/>, don't perform validation until deserialization
    /// is triggered.</para>
    /// </summary>
    public bool ResponseValidation { get; set; } = false;

    /// <summary>
    /// The maximum number of times to retry failed requests, with a short exponential backoff between requests.
    ///
    /// <para>
    /// Only the following error types are retried:
    /// <list type="bullet">
    ///   <item>Connection errors (for example, due to a network connectivity problem)</item>
    ///   <item>Request timeouts (see <see cref="Timeout"/>)</item>
    ///   <item>408 Request Timeout</item>
    ///   <item>409 Conflict</item>
    ///   <item>429 Rate Limit</item>
    ///   <item>5xx Internal</item>
    /// </list>
    /// </para>
    ///
    /// <para>The API may also explicitly instruct the SDK to retry or not retry a request.</para>
    ///
    /// <para>A request that uploads a file from a <c>Stream</c> is sent once and not retried, because the first
    /// attempt consumes the stream; an upload whose files were given as byte arrays is retried like any other
    /// request.</para>
    ///
    /// <para>Defaults to 2 when null. Set to 0 to
    /// disable retries, which also ignores API instructions to retry.</para>
    /// </summary>
    public int? MaxRetries { get; set; } = null;

    /// <summary>
    /// Sets the maximum time allowed for a complete HTTP call, not including retries.
    ///
    /// <para>This includes resolving DNS, connecting, writing the request body, server processing, as
    /// well as reading the response body.</para>
    ///
    /// <para>An attempt that exceeds this timeout is retried like a connection error (see
    /// <see cref="MaxRetries"/>); once retries are exhausted a
    /// <see cref="TaskCanceledException"/> wrapping a <see cref="TimeoutException"/> is thrown.</para>
    ///
    /// <para>Defaults to <c>TimeSpan.FromMinutes(10)</c> when null.</para>
    /// </summary>
    public TimeSpan? Timeout { get; set; } = null;

    /// <summary>
    /// The telemetry that the client emits through OpenTelemetry. <c>false</c> disables its spans.
    ///
    /// <para>Defaults to null. A client that is given none takes its settings from the
    /// <c>ANTHROPIC_OPEN_TELEMETRY</c>, <c>ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE</c> and
    /// <c>ANTHROPIC_OPEN_TELEMETRY_TRACES_MAX_CONTENT_BYTES</c> environment variables, which it
    /// reads once, when it is made; a variable that is not set leaves its setting at the default.
    /// A client that is given any value here takes none of them, and a setting that the value
    /// leaves unset has its default. See <see cref="OpenTelemetryTraces"/>.</para>
    ///
    /// <para>Setting this through <c>WithOptions</c> replaces the options of the client it was
    /// called on as a whole: the two are not merged. A client that <c>WithOptions</c> makes
    /// without setting this keeps what the client it was called on has, what that client read
    /// from the variables included. See <see cref="OpenTelemetryOptions"/>.</para>
    /// </summary>
    public OpenTelemetryOptions? OpenTelemetry { get; set; } = null;

    /// <summary>
    /// The OpenTelemetry options of the calls made with these options, such as the conversation
    /// that they belong to. Set it for one call through <c>WithOptions</c>:
    /// <c>client.WithOptions(options => options with { OpenTelemetryRequest = new() { ConversationId = id } })</c>.
    ///
    /// <para>Defaults to null.</para>
    /// </summary>
    public OpenTelemetryRequestOptions? OpenTelemetryRequest { get; set; } = null;

    readonly Lazy<OpenTelemetryDefaults> _openTelemetryDefaults = new(() => new());

    /// <summary>
    /// <see cref="OpenTelemetry"/> with nothing left unset. When it is null, every setting is what
    /// the <c>ANTHROPIC_OPEN_TELEMETRY</c>, <c>ANTHROPIC_OPEN_TELEMETRY_TRACES_CONTENT_MODE</c> and
    /// <c>ANTHROPIC_OPEN_TELEMETRY_TRACES_MAX_CONTENT_BYTES</c> environment variables said. They are
    /// read once, when a client is made with these options, and the copies that <c>WithOptions</c>
    /// makes of the options keep what was read. Options that the modifier of <c>WithOptions</c>
    /// makes anew read the environment again, as they do for the API key. When it is set, the
    /// variables do not count, and what it leaves unset has its built-in default.
    /// </summary>
    internal readonly OpenTelemetryOptions ResolvedOpenTelemetry
    {
        get { return _openTelemetryDefaults.Value.Resolve(OpenTelemetry); }
    }

    /// <summary>
    /// The <c>gen_ai.provider.name</c> of the spans: the platform that serves the requests. The
    /// clients for Amazon Bedrock and Vertex AI set it; every other client has <c>anthropic</c>.
    /// </summary>
    internal string OpenTelemetryProviderName { get; set; } = "anthropic";

    /// <summary>
    /// The source of the spans, which gives them their instrumentation scope. The clients for a
    /// cloud platform set it to the source of their package
    /// (<see cref="Tracing.PlatformSource"/>); without one, the spans are those of
    /// <see cref="Tracing.Source"/>.
    /// </summary>
    internal ActivitySource? OpenTelemetrySource { get; set; }

    ClientCredential _credential = ClientCredential.FromEnvironment();

    /// <inheritdoc cref="ClientCredential.IsUnset"/>
    internal readonly bool CredentialIsUnset
    {
        get { return _credential.IsUnset; }
    }

    /// <summary>
    /// The API key to authenticate with, sent as <c>Authorization: Bearer</c>.
    ///
    /// <para>Pass at most one of <see cref="ApiKey"/>, <see cref="AuthToken"/> and
    /// <see cref="Credentials"/>. The one you pass is used and no credential is read from the
    /// environment. Setting a second one throws an <see cref="ArgumentException"/>.</para>
    ///
    /// <para>Defaults to the <c>ANTHROPIC_API_KEY</c> environment variable. Setting this to
    /// <c>null</c> clears it: that variable isn't read, and neither are profiles or the workload
    /// identity federation variables.</para>
    /// </summary>
    public string? ApiKey
    {
        readonly get { return _credential.ApiKey; }
        set { _credential = _credential.WithApiKey(value); }
    }

    /// <summary>
    /// The auth token to authenticate with, sent as <c>Authorization: Bearer</c>.
    ///
    /// <para>Pass at most one of <see cref="ApiKey"/>, <see cref="AuthToken"/> and
    /// <see cref="Credentials"/>. The one you pass is used and no credential is read from the
    /// environment. Setting a second one throws an <see cref="ArgumentException"/>.</para>
    ///
    /// <para>Defaults to the <c>ANTHROPIC_AUTH_TOKEN</c> environment variable, which is ignored
    /// when <c>ANTHROPIC_API_KEY</c> is set. The first request sent with both set warns on stderr,
    /// once per process. Setting this to <c>null</c> clears it: that variable isn't read, and
    /// neither are profiles or the workload identity federation variables.</para>
    /// </summary>
    public string? AuthToken
    {
        readonly get { return _credential.AuthToken; }
        set { _credential = _credential.WithAuthToken(value); }
    }

    /// <summary>
    /// Applies a <c>WithOptions</c> modifier to a copy of these options.
    /// </summary>
    internal readonly ClientOptions Apply(Func<ClientOptions, ClientOptions> modifier)
    {
        var inherited = InheritCredential();
        var options = modifier(inherited);
        var isCloudBackend = _backendAdaptationHandler != null;
        var isFresh = options.CredentialIsUnset;
        if (isCloudBackend || isFresh)
        {
            // Cloud-backend clients settle their credentials at construction; one from the
            // modifier or the environment would conflict with the backend's own. Fresh options
            // that pass no credential inherit this client's too.
            options._credential = inherited._credential;
            if (!options.BaseUrlExplicit)
            {
                // Fresh options: the credentials above must not go to another host.
                options.BaseUrl = BaseUrl;
            }
        }
        if (isFresh)
        {
            // A profile's workspace header goes with its credential. Null means unset only in
            // fresh options; in a copy of these options the modifier cleared the headers.
            options.ExtraHeaders ??= ExtraHeaders;
        }
        return options;
    }

    /// <summary>
    /// Returns a copy whose credential counts as inherited: the copy reads none from the
    /// environment, and a credential option set on it replaces the inherited one instead of
    /// counting as a second.
    /// </summary>
    internal readonly ClientOptions InheritCredential()
    {
        var options = this;
        options._credential = _credential.Inherit();
        return options;
    }

    /// <summary>
    /// OIDC/OAuth credentials for authenticating with the Anthropic API.
    ///
    /// <para>Pass at most one of <see cref="ApiKey"/>, <see cref="AuthToken"/> and
    /// <see cref="Credentials"/>. The one you pass is used and no credential is read from the
    /// environment. Setting a second one throws an <see cref="ArgumentException"/>.</para>
    ///
    /// <para>The client wraps the provider in an internal token cache and sets the
    /// <c>Authorization</c> and <c>anthropic-beta</c> headers on every request.</para>
    ///
    /// <para>The client takes ownership of the provider and disposes it when the
    /// client is disposed. Advanced: if the value is already a <c>TokenCache</c>
    /// (e.g., propagated via <c>WithOptions</c>), the client does not dispose it.</para>
    /// </summary>
    public IAccessTokenProvider? Credentials
    {
        readonly get { return _credential.Credentials; }
        set { _credential = _credential.WithCredentials(value); }
    }

    static int s_environmentCredentialsWarningEmitted;

    internal static void ResetEnvironmentCredentialsWarningForTests() =>
        s_environmentCredentialsWarningEmitted = 0;

    /// <summary>
    /// Warns on stderr, once per process, when the API key hides an auth token.
    /// </summary>
    internal readonly void WarnIfEnvironmentHoldsApiKeyAndAuthToken()
    {
        if (
            _credential.ApiKeyHidesAuthToken
            && Interlocked.CompareExchange(ref s_environmentCredentialsWarningEmitted, 1, 0) == 0
        )
        {
            Console.Error.WriteLine(
                "Anthropic: ANTHROPIC_API_KEY and ANTHROPIC_AUTH_TOKEN are both set. "
                    + "Using ANTHROPIC_API_KEY."
            );
        }
    }

    /// <summary>
    /// Extra headers to include on every request (e.g. <c>anthropic-workspace-id</c>).
    /// These are additive metadata applied via <c>TryAddWithoutValidation</c> after
    /// authentication headers are set; they will not override <c>Authorization</c>.
    /// To change auth, use <see cref="ApiKey"/>, <see cref="AuthToken"/>, or
    /// <see cref="Credentials"/>.
    /// </summary>
    public IReadOnlyDictionary<string, string>? ExtraHeaders { get; set; }

    internal static TimeSpan TimeoutFromMaxTokens(
        long maxTokens,
        bool isStreaming,
        string? model = null
    )
    {
        // Check model-specific token limits for non-streaming requests
        long? maxNonStreamingTokens = null;

        if (model != null)
        {
            maxNonStreamingTokens = model switch
            {
                "claude-opus-4-20250514" => 8_192,
                "claude-4-opus-20250514" => 8_192,
                "claude-opus-4-0" => 8_192,
                "anthropic.claude-opus-4-20250514-v1:0" => 8_192,
                "claude-opus-4@20250514" => 8_192,
                "anthropic.claude-opus-4-1-20250805-v1:0" => 8_192,
                "claude-opus-4-1@20250805" => 8_192,
                _ => null,
            };
        }
        var exceedsModelLimit = maxNonStreamingTokens != null && maxTokens > maxNonStreamingTokens;

        long timeoutSeconds;
        if (isStreaming)
        {
            timeoutSeconds = Math.Min(
                60 * 60, // 1 hour maximum
                Math.Max(
                    10 * 60, // 10 minute minimum
                    60 * 60 * maxTokens / 128_000
                )
            );
        }
        else
        {
            timeoutSeconds = Math.Min(
                10 * 60, // 10 minute maximum
                Math.Max(
                    30, // 30 second minimum
                    30 * maxTokens / 1000
                )
            );
        }

        if (!isStreaming && (exceedsModelLimit || timeoutSeconds > 10 * 60)) // 10 minutes
        {
            throw new ArgumentOutOfRangeException(
                nameof(maxTokens),
                "Streaming is required for operations that may take longer than 10 minutes. "
                    + "For more information, see https://platform.claude.com/docs/en/cli-sdks-libraries/sdks/csharp#streaming"
            );
        }

        return TimeSpan.FromSeconds(timeoutSeconds);
    }

    Lazy<string?> _webhookKey = new(() =>
        Environment.GetEnvironmentVariable("ANTHROPIC_WEBHOOK_SIGNING_KEY")
    );
    public string? WebhookKey
    {
        readonly get { return _webhookKey.Value; }
        set { _webhookKey = new(() => value); }
    }

    /// <summary>
    /// Chains the given handlers together (last handler is the innermost one), attaches
    /// them to the given HTTP client, and returns an invoker that sends requests
    /// through the chain.
    ///
    /// <para>When a backend adaptation handler factory is given, the created handler is
    /// placed inside all the given handlers, in an <see cref="UnsignedTraceContextHandler"/>
    /// just outside the HTTP client itself.</para>
    /// </summary>
    static HttpMessageInvoker AttachHandlers(
        HttpClient httpClient,
        IReadOnlyList<DelegatingHandler> handlers,
        Func<DelegatingHandler>? backendAdaptationHandler
    )
    {
        HttpMessageHandler innerHandler = new HttpClientPassthroughHandler(httpClient);
        if (backendAdaptationHandler != null)
        {
            innerHandler = new UnsignedTraceContextHandler(
                backendAdaptationHandler(),
                innerHandler
            );
        }
        for (var index = handlers.Count - 1; index >= 0; index--)
        {
            var handler = handlers[index];
            if (handler.InnerHandler != null)
            {
                throw new InvalidOperationException("Handler is already attached to a client");
            }

            handler.InnerHandler = innerHandler;
            innerHandler = handler;
        }

        return new(innerHandler);
    }

    /// <summary>
    /// Sends the given request through <see cref="Handlers"/> and
    /// <see cref="HttpClient"/>.
    /// </summary>
    internal readonly Task<HttpResponseMessage> SendRequestAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        return _messageInvoker.Value.SendAsync(request, cancellationToken);
    }

    /// <summary>
    /// Disposes <see cref="HttpClient"/> along with any attached
    /// <see cref="Handlers"/>.
    /// </summary>
    internal readonly void DisposeHttpResources()
    {
        if (_messageInvoker.IsValueCreated)
        {
            // Disposes the attached handlers, which in turn dispose the HTTP client.
            _messageInvoker.Value.Dispose();
        }
        else
        {
            _httpClient.Dispose();
        }
    }

    public ClientOptions()
    {
        _messageInvoker = BuildMessageInvoker();
    }
}
