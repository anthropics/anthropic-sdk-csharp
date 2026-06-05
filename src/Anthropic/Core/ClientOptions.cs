using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

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
            var handlers = _handlers;
            _messageInvoker = new(() => AttachHandlers(value, handlers));
        }
    }

    IReadOnlyList<DelegatingHandler> _handlers = [];

    /// <summary>
    /// The handlers to attach to <see cref="HttpClient"/> when the first request is sent.
    ///
    /// <para>Each handler wraps the next one, and the last handler wraps <see cref="HttpClient"/>
    /// itself, making the last handler the innermost one.</para>
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
            var httpClient = _httpClient;
            _messageInvoker = new(() => AttachHandlers(httpClient, handlers));
        }
    }

    Lazy<string> _baseUrl = new(() =>
        Environment.GetEnvironmentVariable("ANTHROPIC_BASE_URL") ?? EnvironmentUrl.Production
    );

    /// <summary>
    /// The base URL to use for every request.
    ///
    /// <para>Defaults to the production environment: <see cref="EnvironmentUrl.Production"/></para>
    /// </summary>
    public string BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set { _baseUrl = new(() => value); }
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
    public string? ApiKey
    {
        readonly get { return _apiKey.Value; }
        set { _apiKey = new(() => value); }
    }

    Lazy<string?> _authToken = new(() =>
        Environment.GetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN")
    );
    public string? AuthToken
    {
        readonly get { return _authToken.Value; }
        set { _authToken = new(() => value); }
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
    /// </summary>
    static HttpMessageInvoker AttachHandlers(
        HttpClient httpClient,
        IReadOnlyList<DelegatingHandler> handlers
    )
    {
        HttpMessageHandler innerHandler = new HttpClientPassthroughHandler(httpClient);
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
        var httpClient = _httpClient;
        var handlers = _handlers;
        _messageInvoker = new(() => AttachHandlers(httpClient, handlers));
    }
}
