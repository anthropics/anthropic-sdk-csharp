using System.Net.Http.Headers;
using Anthropic.Exceptions;

namespace Anthropic.GoogleCloud;

/// <summary>
/// Adapts requests for the Google Cloud gateway: sends organization-level routes to the
/// organization endpoint and attaches the Google OAuth2 bearer token.
///
/// <para>Attached as the innermost handler so user handlers observe the request before the
/// bearer token is applied. Unlike SigV4, a bearer token does not depend on the request
/// body, so the body is never read or buffered here — streaming and multipart uploads pass
/// through untouched.</para>
///
/// <para>This handler runs once, outside the underlying <see cref="HttpClient"/>;
/// redirect-following (and the default <c>Authorization</c> strip on cross-host redirect)
/// happens inside .NET's handler chain.</para>
/// </summary>
internal sealed class GoogleCloudAdaptationHandler : DelegatingHandler
{
    internal const string OrganizationPathPrefix = "/v1/organizations/";
    internal const string UserProfilesPath = "/v1/user_profiles";

    private readonly GoogleCloudClientOptions _googleCloudConfig;
    private readonly string? _workspaceBaseUrl;
    private readonly string? _organizationBaseUrl;

    public GoogleCloudAdaptationHandler(GoogleCloudClientOptions googleCloudConfig)
    {
        _googleCloudConfig = googleCloudConfig;

        if (
            googleCloudConfig.BaseUrl != null
            || googleCloudConfig.Project == null
            || googleCloudConfig.Location == null
        )
        {
            return;
        }
        // Normalized the way request URIs are, so the prefix comparison holds.
        _organizationBaseUrl = new Uri(
            AnthropicGoogleCloudClient.DeriveOrganizationBaseUrl(
                googleCloudConfig.Location,
                googleCloudConfig.Project
            )
        ).AbsoluteUri;
        if (googleCloudConfig.WorkspaceId != null)
        {
            _workspaceBaseUrl = new Uri(
                AnthropicGoogleCloudClient.DeriveWorkspaceBaseUrl(
                    googleCloudConfig.Location,
                    googleCloudConfig.Project,
                    googleCloudConfig.WorkspaceId
                )
            ).AbsoluteUri;
        }
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken
    )
    {
        RouteRequest(requestMessage);
        await AdaptRequestAsync(requestMessage, cancellationToken).ConfigureAwait(false);
        return await base.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
    }

    private void RouteRequest(HttpRequestMessage requestMessage)
    {
        if (_organizationBaseUrl == null || requestMessage.RequestUri == null)
        {
            return;
        }

        // A base URL assigned after construction takes every route, like an explicit
        // one: only requests still addressed to the derived URL are routed.
        var derivedBaseUrl = _workspaceBaseUrl ?? _organizationBaseUrl;
        var requestUrl = requestMessage.RequestUri.AbsoluteUri;
        if (!requestUrl.StartsWith(derivedBaseUrl + "/", StringComparison.Ordinal))
        {
            return;
        }

        var pathAndQuery = requestUrl.Substring(derivedBaseUrl.Length);
        if (IsOrganizationRoute(pathAndQuery.Split('?')[0]))
        {
            requestMessage.RequestUri = new Uri(_organizationBaseUrl + pathAndQuery);
            return;
        }

        if (_workspaceBaseUrl == null)
        {
            throw new AnthropicException(
                $"Workspace ID is required; set {nameof(GoogleCloudClientOptions.WorkspaceId)} "
                    + $"or the {AnthropicGoogleCloudClient.EnvWorkspaceId} environment variable."
            );
        }
    }

    private static bool IsOrganizationRoute(string path) =>
        path.StartsWith(OrganizationPathPrefix, StringComparison.Ordinal)
        || path.Equals(UserProfilesPath, StringComparison.Ordinal)
        || path.StartsWith(UserProfilesPath + "/", StringComparison.Ordinal);

    private async Task AdaptRequestAsync(
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken
    )
    {
        // Defense in depth: this client never sets ApiKey, but a user handler might
        // re-add the header; ensure first-party credentials never reach the gateway.
        requestMessage.Headers.Remove("X-Api-Key");

        if (_googleCloudConfig.SkipAuth)
        {
            return;
        }

        // Only set if not already present — lets a user handler supply a per-request
        // bearer when it needs to.
        if (requestMessage.Headers.Authorization != null)
        {
            return;
        }

        var token = await ResolveTokenAsync(cancellationToken).ConfigureAwait(false);
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    private async Task<string> ResolveTokenAsync(CancellationToken cancellationToken)
    {
        if (_googleCloudConfig.TokenProvider != null)
        {
            return await _googleCloudConfig.TokenProvider(cancellationToken).ConfigureAwait(false);
        }
        if (_googleCloudConfig.GoogleCredential != null)
        {
            // ITokenAccess.GetAccessTokenForRequestAsync caches and refreshes internally,
            // so this is cheap per request.
            return await _googleCloudConfig
                .GoogleCredential.UnderlyingCredential.GetAccessTokenForRequestAsync(
                    authUri: null,
                    cancellationToken: cancellationToken
                )
                .ConfigureAwait(false);
        }
        // Unreachable when constructed via AnthropicGoogleCloudClient: SkipAuth=false
        // always resolves a credential or throws at construction time.
        throw new AnthropicException(
            "No Google credentials available; set TokenProvider or GoogleCredential, or "
                + "configure application default credentials."
        );
    }
}
