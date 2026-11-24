using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Credentials;
using Anthropic.Services;

namespace Anthropic;

/// <inheritdoc/>
public class AnthropicClient : IAnthropicClient
{
    protected readonly ClientOptions _options;
    private TokenCache? _ownedCredentials;
    private readonly Lazy<ClientOptions> _resolvedOptions;

    // Set on a client derived through WithOptions: the HTTP resources it shares with
    // the client it was derived from are that client's to dispose.
    private readonly ClientOptions? _parentOptions;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public IReadOnlyList<DelegatingHandler> Handlers
    {
        get { return this._options.Handlers; }
        init { this._options.Handlers = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._resolvedOptions.Value.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public OpenTelemetryOptions? OpenTelemetry
    {
        get { return this._options.OpenTelemetry; }
        init { this._options.OpenTelemetry = value; }
    }

    /// <inheritdoc/>
    public virtual string? ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public string? AuthToken
    {
        get { return this._options.AuthToken; }
        init { this._options.AuthToken = value; }
    }

    /// <inheritdoc/>
    public string? WebhookKey
    {
        get { return this._options.WebhookKey; }
        init { this._options.WebhookKey = value; }
    }

    /// <inheritdoc cref="ClientOptions.BackendAdaptationHandler"/>
    internal Func<DelegatingHandler>? BackendAdaptationHandler
    {
        get { return this._options.BackendAdaptationHandler; }
        init { this._options.BackendAdaptationHandler = value; }
    }

    /// <inheritdoc cref="ClientOptions.ExtraHeaders"/>
    internal IReadOnlyDictionary<string, string>? ExtraHeaders
    {
        get { return this._options.ExtraHeaders; }
        init { this._options.ExtraHeaders = value; }
    }

    /// <inheritdoc cref="ClientOptions.OpenTelemetryProviderName"/>
    internal string OpenTelemetryProviderName
    {
        get { return this._options.OpenTelemetryProviderName; }
        init { this._options.OpenTelemetryProviderName = value; }
    }

    internal ClientOptions Options
    {
        get { return this._options; }
    }

    /// <inheritdoc cref="ClientOptions.OpenTelemetrySource"/>
    internal ActivitySource? OpenTelemetrySource
    {
        get { return this._options.OpenTelemetrySource; }
        init { this._options.OpenTelemetrySource = value; }
    }

    readonly Lazy<IAnthropicClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public virtual IAnthropicClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public virtual IAnthropicClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        var parentOptions = this._resolvedOptions.Value;
        return new AnthropicClient(parentOptions.Apply(modifier), parentOptions);
    }

    readonly Lazy<IMessageService> _messages;
    public IMessageService Messages
    {
        get { return _messages.Value; }
    }

    readonly Lazy<IModelService> _models;
    public IModelService Models
    {
        get { return _models.Value; }
    }

    readonly Lazy<IFileService> _files;
    public IFileService Files
    {
        get { return _files.Value; }
    }

    readonly Lazy<ISkillService> _skills;
    public ISkillService Skills
    {
        get { return _skills.Value; }
    }

    readonly Lazy<IUserProfileService> _userProfiles;
    public IUserProfileService UserProfiles
    {
        get { return _userProfiles.Value; }
    }

    readonly Lazy<IOrganizationService> _organization;
    public IOrganizationService Organization
    {
        get { return _organization.Value; }
    }

    readonly Lazy<IBetaService> _beta;
    public IBetaService Beta
    {
        get { return _beta.Value; }
    }

    public void Dispose()
    {
        _ownedCredentials?.Dispose();
        this._options.DisposeHttpResources(_parentOptions);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Whether this client should attempt environment/profile credential auto-resolution
    /// when no explicit ApiKey/AuthToken/Credentials is provided. Cloud-backend clients
    /// (Bedrock, Vertex, Foundry, AWS) override this to false. User subclasses inherit true.
    /// </summary>
    protected virtual bool ShouldAutoResolveCredentials => true;

    public AnthropicClient()
        : this(new ClientOptions()) { }

    /// <summary>
    /// Returns the options with the credential found in the environment, if any. This runs on
    /// first use because the constructor can't see a credential passed in an object initializer.
    /// </summary>
    private ClientOptions ResolveCredentials()
    {
        var options = _options;

        // Auto-resolve credentials when nothing explicit was provided.
        // Cloud-backend subclasses opt out via ShouldAutoResolveCredentials.
        if (ShouldAutoResolveCredentials && options.CredentialIsUnset)
        {
            // Base URL precedence: explicit ctor > ANTHROPIC_BASE_URL > profile > Production.
            // Only let the profile's base_url through to Resolve (and adopt it for API
            // requests) when neither the ctor nor the env var supplied one.
            var envBaseUrl = Environment.GetEnvironmentVariable("ANTHROPIC_BASE_URL");
            var hasUserBaseUrl = options.BaseUrlExplicit || !string.IsNullOrEmpty(envBaseUrl);
            var resolved = AnthropicCredentials.Resolve(
                baseUrl: hasUserBaseUrl ? options.BaseUrl : null
            );
            if (resolved != null)
            {
                _ownedCredentials = new TokenCache(resolved.Credentials);
                options.Credentials = _ownedCredentials;
                if (!hasUserBaseUrl && resolved.BaseUrl != null)
                {
                    options.BaseUrl = resolved.BaseUrl;
                }
                // Merge: keep any user-supplied ExtraHeaders, overlay resolved
                // (resolved wins on key conflict).
                var merged = new Dictionary<string, string>();
                if (options.ExtraHeaders != null)
                {
                    foreach (var kv in options.ExtraHeaders)
                    {
                        merged[kv.Key] = kv.Value;
                    }
                }
                foreach (var kv in resolved.ExtraHeaders)
                {
                    merged[kv.Key] = kv.Value;
                }
                options.ExtraHeaders = merged;
            }
        }

        return options;
    }

    public AnthropicClient(ClientOptions options)
    {
        // Wrap any user-supplied provider in the shared token cache so the
        // raw-response client and 401-retry path see a single cached instance.
        // We own (and will dispose) the credentials only when this ctor created
        // or wrapped them; a TokenCache passed in (e.g. from a WithOptions clone)
        // is owned by whoever built it.
        if (options.Credentials is { } credentials and not TokenCache)
        {
            _ownedCredentials = new TokenCache(credentials);
            options.Credentials = _ownedCredentials;
        }

        if (!ShouldAutoResolveCredentials)
        {
            // A cloud-backend client sets its own credential next, which replaces a first-party
            // one in these options instead of counting as a second.
            options = options.InheritCredential();
        }

        // The tracing environment variables are read now: a later change of the environment does
        // not reach this client.
        _ = options.ResolvedOpenTelemetry;
        _options = options;
        _resolvedOptions = new(ResolveCredentials);

        _withRawResponse = new(() =>
        {
            var options = this._resolvedOptions.Value;
            return new AnthropicClientWithRawResponse(options, options);
        });
        _messages = new(() => new MessageService(this));
        _models = new(() => new ModelService(this));
        _files = new(() => new FileService(this));
        _skills = new(() => new SkillService(this));
        _userProfiles = new(() => new UserProfileService(this));
        _organization = new(() => new OrganizationService(this));
        _beta = new(() => new BetaService(this));
    }

    internal AnthropicClient(ClientOptions options, ClientOptions parentOptions)
        : this(options)
    {
        _parentOptions = parentOptions;
    }
}

/// <inheritdoc/>
public class AnthropicClientWithRawResponse : IAnthropicClientWithRawResponse
{
    protected readonly ClientOptions _options;
    private readonly TokenCache? _ownedCredentials;

    internal ClientOptions Options
    {
        get { return this._options; }
    }

    readonly RetryingExecutor _executor;

    // Set on a client derived through WithOptions or AnthropicClient.WithRawResponse: the
    // HTTP resources it shares with the client it was derived from are that client's to dispose.
    private readonly ClientOptions? _parentOptions;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public IReadOnlyList<DelegatingHandler> Handlers
    {
        get { return this._options.Handlers; }
        init { this._options.Handlers = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public OpenTelemetryOptions? OpenTelemetry
    {
        get { return this._options.OpenTelemetry; }
        init { this._options.OpenTelemetry = value; }
    }

    /// <inheritdoc/>
    public virtual string? ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public virtual string? AuthToken
    {
        get { return this._options.AuthToken; }
        init { this._options.AuthToken = value; }
    }

    /// <inheritdoc/>
    public virtual string? WebhookKey
    {
        get { return this._options.WebhookKey; }
        init { this._options.WebhookKey = value; }
    }

    /// <inheritdoc/>
    public virtual IAnthropicClientWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        var options = this._options.Apply(modifier);
        // Cloud-backend clients carry their adaptation handler in the options; restore
        // it if the modifier returned fresh options, so requests keep being adapted
        // (rewritten/signed) for the backend. Guarded instead of `??=` because even a
        // null-to-null assignment runs the setter, which rebuilds the handler chain and
        // re-attaches already-attached user Handlers on the next request.
        if (
            options.BackendAdaptationHandler == null
            && this._options.BackendAdaptationHandler != null
        )
        {
            options.BackendAdaptationHandler = this._options.BackendAdaptationHandler;
        }
        // The spans of such a client keep the scope of its package too.
        options.OpenTelemetrySource ??= this._options.OpenTelemetrySource;
        return new AnthropicClientWithRawResponse(options, this._options);
    }

    readonly Lazy<IMessageServiceWithRawResponse> _messages;
    public IMessageServiceWithRawResponse Messages
    {
        get { return _messages.Value; }
    }

    readonly Lazy<IModelServiceWithRawResponse> _models;
    public IModelServiceWithRawResponse Models
    {
        get { return _models.Value; }
    }

    readonly Lazy<IFileServiceWithRawResponse> _files;
    public IFileServiceWithRawResponse Files
    {
        get { return _files.Value; }
    }

    readonly Lazy<ISkillServiceWithRawResponse> _skills;
    public ISkillServiceWithRawResponse Skills
    {
        get { return _skills.Value; }
    }

    readonly Lazy<IUserProfileServiceWithRawResponse> _userProfiles;
    public IUserProfileServiceWithRawResponse UserProfiles
    {
        get { return _userProfiles.Value; }
    }

    readonly Lazy<IOrganizationServiceWithRawResponse> _organization;
    public IOrganizationServiceWithRawResponse Organization
    {
        get { return _organization.Value; }
    }

    readonly Lazy<IBetaServiceWithRawResponse> _beta;
    public IBetaServiceWithRawResponse Beta
    {
        get { return _beta.Value; }
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        return this._executor.Execute(request, cancellationToken);
    }

    internal TokenCache? ActiveTokenCache
    {
        get
        {
            // Token credentials are first-party-only auth; cloud-backend clients
            // (which install a backend adaptation handler) authenticate in that
            // handler instead, so neither token application nor the 401
            // token-refresh retry applies to them.
            if (_options.BackendAdaptationHandler != null)
            {
                return null;
            }

            return _options.Credentials as TokenCache;
        }
    }

    protected virtual async ValueTask BeforeSend<T>(
        HttpRequest<T> request,
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken
    )
        where T : ParamsBase
    {
        _options.WarnIfEnvironmentHoldsApiKeyAndAuthToken();

        if (ActiveTokenCache is { } tokenCache)
        {
            var token = await tokenCache
                .GetTokenAsync(forceRefresh: false, cancellationToken)
                .ConfigureAwait(false);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                token.Token
            );
            AppendBetaHeader(requestMessage, CredentialsConstants.ApiRequestBetaValue);
        }

        var extraHeaders = _options.ExtraHeaders;
        if (extraHeaders != null)
        {
            foreach (var header in extraHeaders)
            {
                // Per-request params may already carry these single-valued headers; appending
                // a second value would put "a, b" on the wire.
                if (
                    (
                        string.Equals(
                            header.Key,
                            "anthropic-workspace-id",
                            StringComparison.OrdinalIgnoreCase
                        )
                        || string.Equals(
                            header.Key,
                            "anthropic-user-profile-id",
                            StringComparison.OrdinalIgnoreCase
                        )
                    ) && requestMessage.Headers.Contains(header.Key)
                )
                {
                    continue;
                }
                requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }
    }

    private static void AppendBetaHeader(HttpRequestMessage requestMessage, string value)
    {
        // anthropic-beta is multi-valued; only append if not already present so service-level
        // betas (e.g., files-api-2025-04-14) and the OAuth beta coexist without duplicates.
        if (requestMessage.Headers.TryGetValues("anthropic-beta", out var existing))
        {
            var entries = existing.ToList();
            foreach (var entry in entries)
            {
                foreach (var part in entry.Split(','))
                {
                    if (string.Equals(part.Trim(), value, StringComparison.Ordinal))
                    {
                        return;
                    }
                }
            }
            entries.Add(value);
            requestMessage.Headers.Remove("anthropic-beta");
            value = string.Join(",", entries);
        }
        requestMessage.Headers.TryAddWithoutValidation("anthropic-beta", value);
    }

    protected virtual ValueTask AfterSend<T>(
        HttpRequest<T> request,
        HttpResponseMessage httpResponseMessage,
        CancellationToken cancellationToken
    )
        where T : ParamsBase
    {
        // 401 handling lives in RetryingExecutor so it can drive the retry loop.
        return default;
    }

    internal ValueTask SendingRequest<T>(
        HttpRequest<T> request,
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken
    )
        where T : ParamsBase => BeforeSend(request, requestMessage, cancellationToken);

    internal ValueTask ReceivedResponse<T>(
        HttpRequest<T> request,
        HttpResponseMessage httpResponseMessage,
        CancellationToken cancellationToken
    )
        where T : ParamsBase => AfterSend(request, httpResponseMessage, cancellationToken);

    public void Dispose()
    {
        _ownedCredentials?.Dispose();
        this._options.DisposeHttpResources(_parentOptions);
        GC.SuppressFinalize(this);
    }

    public AnthropicClientWithRawResponse()
    {
        _options = new();
        // The tracing environment variables are read now: a later change of the environment does
        // not reach this client.
        _ = _options.ResolvedOpenTelemetry;
        _executor = new(this);

        _messages = new(() => new MessageServiceWithRawResponse(this));
        _models = new(() => new ModelServiceWithRawResponse(this));
        _files = new(() => new FileServiceWithRawResponse(this));
        _skills = new(() => new SkillServiceWithRawResponse(this));
        _userProfiles = new(() => new UserProfileServiceWithRawResponse(this));
        _organization = new(() => new OrganizationServiceWithRawResponse(this));
        _beta = new(() => new BetaServiceWithRawResponse(this));
    }

    public AnthropicClientWithRawResponse(ClientOptions options)
        : this()
    {
        // Wrap any raw provider in the token cache. When constructed via
        // AnthropicClient.WithRawResponse this is already a TokenCache and is reused.
        // We own (and will dispose) the credentials only when this ctor created the
        // wrap; a TokenCache passed in is owned by whoever built it.
        if (options.Credentials is { } credentials and not TokenCache)
        {
            _ownedCredentials = new TokenCache(credentials);
            options.Credentials = _ownedCredentials;
        }
        _ = options.ResolvedOpenTelemetry;
        _options = options;
    }

    internal AnthropicClientWithRawResponse(ClientOptions options, ClientOptions parentOptions)
        : this(options)
    {
        _parentOptions = parentOptions;
    }
}
