using System.Net.Http;
using Anthropic.Core;

namespace Anthropic.Credentials;

/// <summary>
/// Configuration options for workload identity federation credentials.
/// </summary>
public sealed class WorkloadIdentityOptions
{
    /// <summary>
    /// The federation rule ID (e.g., <c>fdrl_01...</c>).
    /// </summary>
    public required string FederationRuleId { get; init; }

    /// <summary>
    /// The organization ID (UUID format).
    /// </summary>
    public string? OrganizationId { get; init; }

    /// <summary>
    /// The optional service account ID (e.g., <c>svac_01...</c>).
    /// </summary>
    public string? ServiceAccountId { get; init; }

    /// <summary>
    /// Optional <c>wrkspc_*</c> tagged ID, or the literal <c>"default"</c> to scope the
    /// token to the organization's default workspace. When omitted the server picks the
    /// rule's sole enabled workspace, else the org default if the rule covers it. Required
    /// when the rule enables more than one non-default workspace, or to target a specific
    /// workspace other than the one the server would pick. The minted token is
    /// workspace-scoped: per-request workspace selection (the
    /// <c>anthropic-workspace-id</c> header) is not supported for federation tokens —
    /// switching workspaces requires a new token exchange with a different
    /// <c>WorkspaceId</c>.
    /// </summary>
    public string? WorkspaceId { get; init; }

    /// <summary>
    /// The provider that supplies external OIDC JWTs for the token exchange.
    /// </summary>
    public required IIdentityTokenProvider IdentityTokenProvider { get; init; }

    /// <summary>
    /// The base URL for the Anthropic API. Defaults to <c>https://api.anthropic.com</c>.
    /// </summary>
    public string BaseUrl { get; init; } = EnvironmentUrl.Production;

    /// <summary>
    /// Optional <see cref="HttpClient"/> for token exchange requests.
    /// If not provided, a new one will be created internally.
    /// </summary>
    public HttpClient? HttpClient { get; init; }
}
