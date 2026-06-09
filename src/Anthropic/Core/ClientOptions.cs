using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
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
    /// <para>The created handler is attached as the innermost handler, inside all user
    /// <see cref="Handlers"/>, so user handlers observe Anthropic-shaped requests and
    /// normalized responses, and any request mutation they perform is covered by backend
    /// request signing. A factory (rather than an instance) because every attached handler
    /// chain needs its own unattached instance.</para>
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
    ///   <item>408 Request Timeout</item>
    ///   <item>409 Conflict</item>
    ///   <item>429 Rate Limit</item>
    ///   <item>5xx Internal</item>
    /// </list>
    /// </para>
    ///
    /// <para>The API may also explicitly instruct the SDK to retry or not retry a request.</para>
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
    /// <para>Defaults to <c>TimeSpan.FromMinutes(10)</c> when null.</para>
    /// </summary>
    public TimeSpan? Timeout { get; set; } = null;

    Lazy<string?> _apiKey = new(() => Environment.GetEnvironmentVariable("ANTHROPIC_API_KEY"));
    internal bool ApiKeyExplicit { get; private set; }
    public string? ApiKey
    {
        readonly get { return _apiKey.Value; }
        set
        {
            _apiKey = new(() => value);
            ApiKeyExplicit = true;
        }
    }

    Lazy<string?> _authToken = new(() =>
        Environment.GetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN")
    );
    internal bool AuthTokenExplicit { get; private set; }
    public string? AuthToken
    {
        readonly get { return _authToken.Value; }
        set
        {
            _authToken = new(() => value);
            AuthTokenExplicit = true;
        }
    }

    /// <summary>
    /// OIDC/OAuth credentials for authenticating with the Anthropic API.
    /// When set, these are used instead of env-var-based ApiKey/AuthToken.
    /// An explicitly provided ApiKey takes priority over Credentials.
    ///
    /// <para>The client wraps the provider in an internal token cache and sets the
    /// <c>Authorization</c> and <c>anthropic-beta</c> headers on every request.</para>
    ///
    /// <para>The client takes ownership of the provider and disposes it when the
    /// client is disposed. Advanced: if the value is already a <c>TokenCache</c>
    /// (e.g., propagated via <c>WithOptions</c>), the client does not dispose it.</para>
    /// </summary>
    public IAccessTokenProvider? Credentials { get; set; }

    /// <summary>
    /// Extra headers to include on every request (e.g. <c>anthropic-workspace-id</c>).
    /// These are additive metadata applied via <c>TryAddWithoutValidation</c> after
    /// authentication headers are set; they will not override <c>Authorization</c> or
    /// <c>X-Api-Key</c>. To change auth, use <see cref="ApiKey"/>, <see cref="AuthToken"/>,
    /// or <see cref="Credentials"/>.
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
                "claude-opus-4-1-20250805" => 8_192,
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
                    + "For more information, see https://github.com/anthropics/anthropic-sdk-csharp#streaming"
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
    /// placed inside all the given handlers, just outside the HTTP client itself.</para>
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
            var handler = backendAdaptationHandler();
            handler.InnerHandler = innerHandler;
            innerHandler = handler;
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
