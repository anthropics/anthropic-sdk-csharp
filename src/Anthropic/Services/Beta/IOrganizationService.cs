using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization;
using Anthropic.Services.Beta.Organization;

namespace Anthropic.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IOrganizationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOrganizationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOrganizationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IApiKeyService ApiKeys { get; }

    IExternalKeyService ExternalKeys { get; }

    IFederationService Federation { get; }

    IInviteService Invites { get; }

    IServiceAccountService ServiceAccounts { get; }

    IUserService Users { get; }

    IWorkspaceService Workspaces { get; }

    IRateLimitService RateLimits { get; }

    /// <summary>
    /// Retrieve information about the organization associated with the authenticated
    /// API key.
    /// </summary>
    Task<BetaOrganization> Retrieve(
        OrganizationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IOrganizationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOrganizationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOrganizationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IApiKeyServiceWithRawResponse ApiKeys { get; }

    IExternalKeyServiceWithRawResponse ExternalKeys { get; }

    IFederationServiceWithRawResponse Federation { get; }

    IInviteServiceWithRawResponse Invites { get; }

    IServiceAccountServiceWithRawResponse ServiceAccounts { get; }

    IUserServiceWithRawResponse Users { get; }

    IWorkspaceServiceWithRawResponse Workspaces { get; }

    IRateLimitServiceWithRawResponse RateLimits { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/me?beta=true</c>, but is otherwise the
    /// same as <see cref="IOrganizationService.Retrieve(OrganizationRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaOrganization>> Retrieve(
        OrganizationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
