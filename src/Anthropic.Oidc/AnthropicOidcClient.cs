using System.Net;
using System.Net.Http;
using Anthropic.Core;

namespace Anthropic.Oidc;

/// <summary>
/// Anthropic API client that authenticates using OIDC workload identity federation
/// or other OAuth-based credentials.
/// </summary>
public class AnthropicOidcClient : AnthropicClient
{
    private readonly IAnthropicOidcCredentials _credentials;
    private readonly IReadOnlyDictionary<string, string> _extraHeaders;
    private readonly Lazy<IAnthropicClientWithRawResponse> _withRawResponse;

    /// <summary>
    /// Creates a new <see cref="AnthropicOidcClient"/> with the specified credentials.
    /// </summary>
    public AnthropicOidcClient(IAnthropicOidcCredentials credentials)
        : this(credentials, new Dictionary<string, string>(), new ClientOptions()) { }

    /// <summary>
    /// Creates a new <see cref="AnthropicOidcClient"/> with the specified credentials and options.
    /// </summary>
    public AnthropicOidcClient(IAnthropicOidcCredentials credentials, ClientOptions options)
        : this(credentials, new Dictionary<string, string>(), options) { }

    /// <summary>
    /// Creates a new <see cref="AnthropicOidcClient"/> from a <see cref="CredentialResult"/>.
    /// </summary>
    public AnthropicOidcClient(CredentialResult credentialResult)
        : this(credentialResult.Credentials, credentialResult.ExtraHeaders, new ClientOptions()) { }

    /// <summary>
    /// Creates a new <see cref="AnthropicOidcClient"/> from a <see cref="CredentialResult"/>
    /// with the specified options.
    /// </summary>
    public AnthropicOidcClient(CredentialResult credentialResult, ClientOptions options)
        : this(credentialResult.Credentials, credentialResult.ExtraHeaders, options) { }

    private AnthropicOidcClient(
        IAnthropicOidcCredentials credentials,
        IReadOnlyDictionary<string, string> extraHeaders,
        ClientOptions options
    )
        : base(SuppressKeyAuth(options))
    {
        _credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
        _extraHeaders = extraHeaders ?? new Dictionary<string, string>();

        _withRawResponse = new(() =>
            new AnthropicOidcClientWithRawResponse(_credentials, _extraHeaders, _options)
        );
    }

    /// <summary>
    /// Returns a copy of options with ApiKey and AuthToken set to null, so that
    /// ParamsBase.AddDefaultHeaders does not emit X-Api-Key or a duplicate Authorization header.
    /// </summary>
    private static ClientOptions SuppressKeyAuth(ClientOptions options)
    {
        options.ApiKey = null;
        options.AuthToken = null;
        return options;
    }

    [Obsolete("Use OIDC credentials instead of ApiKey.", true)]
#pragma warning disable CS0809
    public override string? ApiKey
#pragma warning restore CS0809
    {
        get =>
            throw new NotSupportedException("ApiKey is not supported when using OIDC credentials.");
        init =>
            throw new NotSupportedException("ApiKey is not supported when using OIDC credentials.");
    }

    /// <inheritdoc/>
    public override IAnthropicClientWithRawResponse WithRawResponse => _withRawResponse.Value;

    /// <inheritdoc/>
    public override IAnthropicClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AnthropicOidcClient(_credentials, _extraHeaders, modifier(_options));
    }

    /// <summary>
    /// Disposes the client and cascades disposal to the credentials.
    /// </summary>
    public new void Dispose()
    {
        _credentials.Dispose();
        base.Dispose();
    }

    private sealed class AnthropicOidcClientWithRawResponse : AnthropicClientWithRawResponse
    {
        private readonly IAnthropicOidcCredentials _credentials;
        private readonly IReadOnlyDictionary<string, string> _extraHeaders;

        public AnthropicOidcClientWithRawResponse(
            IAnthropicOidcCredentials credentials,
            IReadOnlyDictionary<string, string> extraHeaders,
            ClientOptions options
        )
            : base(options)
        {
            _credentials = credentials;
            _extraHeaders = extraHeaders;
        }

        public override IAnthropicClientWithRawResponse WithOptions(
            Func<ClientOptions, ClientOptions> modifier
        )
        {
            return new AnthropicOidcClientWithRawResponse(
                _credentials,
                _extraHeaders,
                modifier(_options)
            );
        }

        protected override async ValueTask BeforeSend<T>(
            HttpRequest<T> request,
            HttpRequestMessage requestMessage,
            CancellationToken cancellationToken
        )
        {
            await _credentials.ApplyAsync(requestMessage, cancellationToken).ConfigureAwait(false);

            // Apply any extra headers from credential resolution (e.g., workspace-id)
            foreach (var header in _extraHeaders)
            {
                requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        protected override ValueTask AfterSend<T>(
            HttpRequest<T> request,
            HttpResponseMessage httpResponseMessage,
            CancellationToken cancellationToken
        )
        {
            if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                // Invalidate cached token on 401 so the next request uses a fresh one.
                // We do NOT retry the current request (streaming safety).
                _credentials.InvalidateToken();
            }

            return default;
        }
    }
}
