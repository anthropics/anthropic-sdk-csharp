using Anthropic.Core;
using Anthropic.Exceptions;
using Google.Apis.Auth.OAuth2;

namespace Anthropic.GoogleCloud;

/// <summary>
/// An Anthropic client for Claude Platform on Google Cloud — the first-party Anthropic
/// API served through the Google Cloud gateway.
/// </summary>
/// <remarks>
/// <para>
/// Distinct from <c>Anthropic.Vertex.AnthropicVertexClient</c>, which targets the
/// <c>:rawPredict</c> publisher-model API. This client speaks the full first-party
/// Anthropic API: requests pass through the gateway unchanged — standard <c>/v1/*</c>
/// paths, standard model names, the complete API surface.
/// </para>
/// <para>
/// See <see cref="GoogleCloudClientOptions"/> for credential, project, location, base-URL,
/// and workspace-ID resolution.
/// </para>
/// </remarks>
public sealed class AnthropicGoogleCloudClient : AnthropicClient
{
    internal const string EnvAnthropicGoogleCloudProject = "ANTHROPIC_GOOGLE_CLOUD_PROJECT";
    internal const string EnvGoogleCloudProject = "GOOGLE_CLOUD_PROJECT";
    internal const string EnvLocation = "ANTHROPIC_GOOGLE_CLOUD_LOCATION";
    internal const string EnvWorkspaceId = "ANTHROPIC_GOOGLE_CLOUD_WORKSPACE_ID";
    internal const string EnvBaseUrl = "ANTHROPIC_GOOGLE_CLOUD_BASE_URL";

    internal const string CloudPlatformScope = "https://www.googleapis.com/auth/cloud-platform";

    internal const string DefaultLocation = "global";

    /// <inheritdoc/>
    protected override bool ShouldAutoResolveCredentials => false;

    private readonly GoogleCloudClientOptions _googleCloudConfig;

    /// <summary>
    /// Creates a new <see cref="AnthropicGoogleCloudClient"/>.
    /// </summary>
    /// <param name="options">
    /// Configuration options for credentials, project, location, base URL, and workspace ID.
    /// When <c>null</c>, all values are resolved from environment variables and Application
    /// Default Credentials.
    /// </param>
    public AnthropicGoogleCloudClient(GoogleCloudClientOptions? options = null)
        : base(options?.ClientOptions ?? new ClientOptions())
    {
        var opts = options ?? new GoogleCloudClientOptions();

        if (opts.SkipAuth && (opts.TokenProvider != null || opts.GoogleCredential != null))
        {
            throw new AnthropicException(
                "SkipAuth is mutually exclusive with TokenProvider and GoogleCredential; "
                    + "set one or the other."
            );
        }

        var resolvedProject =
            opts.Project
            ?? Environment.GetEnvironmentVariable(EnvAnthropicGoogleCloudProject)
            ?? Environment.GetEnvironmentVariable(EnvGoogleCloudProject);
        var resolvedLocation =
            opts.Location ?? Environment.GetEnvironmentVariable(EnvLocation) ?? DefaultLocation;
        var resolvedWorkspaceId =
            opts.WorkspaceId ?? Environment.GetEnvironmentVariable(EnvWorkspaceId);
        var resolvedBaseUrl = opts.BaseUrl ?? Environment.GetEnvironmentVariable(EnvBaseUrl);

        if (resolvedWorkspaceId == null && !opts.SkipAuth)
        {
            throw new AnthropicException(
                $"Workspace ID is required; set {nameof(opts.WorkspaceId)} or the "
                    + $"{EnvWorkspaceId} environment variable."
            );
        }

        // Resolve credentials before deriving the base URL: ADC may yield a project that
        // backfills both an unset Project and the derived URL.
        var googleCredential = opts.GoogleCredential;
        if (!opts.SkipAuth && opts.TokenProvider == null && googleCredential == null)
        {
            try
            {
                googleCredential = GoogleCredential
                    .GetApplicationDefault()
                    .CreateScoped(CloudPlatformScope);
            }
            catch (Exception ex)
            {
                throw new AnthropicException(
                    "Failed to load Google application default credentials. Set "
                        + $"{nameof(opts.TokenProvider)} or {nameof(opts.GoogleCredential)}, "
                        + $"or configure ADC: {ex.Message}",
                    ex
                );
            }
            // ADC project backfill — only some credential types carry one.
            if (
                resolvedProject == null
                && googleCredential.UnderlyingCredential is ServiceAccountCredential sac
            )
            {
                resolvedProject = sac.ProjectId;
            }
        }

        if (resolvedBaseUrl == null)
        {
            if (resolvedProject == null)
            {
                throw new AnthropicException(
                    $"No project found; set {nameof(opts.Project)}, set the "
                        + $"{EnvAnthropicGoogleCloudProject} environment variable, or configure "
                        + "application default credentials with a project."
                );
            }
            if (resolvedWorkspaceId == null)
            {
                throw new AnthropicException(
                    $"Workspace ID is required; set {nameof(opts.WorkspaceId)} or the "
                        + $"{EnvWorkspaceId} environment variable."
                );
            }
            resolvedBaseUrl = DeriveBaseUrl(resolvedLocation, resolvedProject, resolvedWorkspaceId);
        }

        // This client's auth comes solely from Google credentials. Suppress the base
        // client's ANTHROPIC_API_KEY / ANTHROPIC_AUTH_TOKEN env fallbacks so first-party
        // credentials are never sent to the gateway.
        base.ApiKey = null;
        AuthToken = null;
        // Always overwrite — this client never inherits ANTHROPIC_BASE_URL.
        BaseUrl = resolvedBaseUrl;

        // A local (rather than the field) so the factory closure below doesn't capture
        // and pin the whole client.
        var googleCloudConfig = new GoogleCloudClientOptions
        {
            Project = resolvedProject,
            Location = resolvedLocation,
            WorkspaceId = resolvedWorkspaceId,
            BaseUrl = resolvedBaseUrl,
            TokenProvider = opts.TokenProvider,
            GoogleCredential = googleCredential,
            SkipAuth = opts.SkipAuth,
        };
        _googleCloudConfig = googleCloudConfig;

        BackendAdaptationHandler = () => new GoogleCloudAdaptationHandler(googleCloudConfig);
    }

    private AnthropicGoogleCloudClient(
        GoogleCloudClientOptions googleCloudConfig,
        ClientOptions options
    )
        : base(options)
    {
        _googleCloudConfig = googleCloudConfig;
        // The options normally carry the backend adaptation handler from the original
        // construction; restore it if a WithOptions modifier returned fresh options.
        BackendAdaptationHandler ??= () => new GoogleCloudAdaptationHandler(googleCloudConfig);
    }

    /// <summary>
    /// Not supported — this client authenticates via Google credentials only.
    /// </summary>
    [Obsolete($"The {nameof(ApiKey)} property is not supported in this configuration.", true)]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
    public override string? ApiKey
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
    {
        get =>
            throw new NotSupportedException(
                $"The {nameof(ApiKey)} property is not supported in this configuration."
            );
        init =>
            throw new NotSupportedException(
                $"The {nameof(ApiKey)} property is not supported in this configuration."
            );
    }

    /// <inheritdoc />
    public override IAnthropicClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AnthropicGoogleCloudClient(_googleCloudConfig, modifier(_options));
    }

    private static string DeriveBaseUrl(string location, string project, string workspaceId) =>
        $"https://claude.googleapis.com/v1alpha/projects/{project}"
        + $"/locations/{location}/workspaces/{workspaceId}/invoke";
}
