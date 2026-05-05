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
