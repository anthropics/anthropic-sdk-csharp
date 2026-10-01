using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.SpendLimits;
using Anthropic.Services.Beta.Organization.SpendLimits;

namespace Anthropic.Services.Beta.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISpendLimitService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISpendLimitServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpendLimitService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IEffectiveService Effective { get; }

    IIncreaseRequestService IncreaseRequests { get; }

    /// <summary>
    /// Retrieve a spend limit by ID.
    /// </summary>
    Task<BetaSpendLimit> Retrieve(
        SpendLimitRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SpendLimitRetrieveParams, CancellationToken)"/>
    Task<BetaSpendLimit> Retrieve(
        string spendLimitID,
        SpendLimitRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the organization's spend limits.
    ///
    /// <para>A Claude Console organization's limits come in an order that is stable
    /// across pages. A Claude Enterprise organization's are grouped by scope type, in
    /// the order `organization`, `seat_tier`, `rbac_group`, `organization_service`,
    /// `user`; within a type they come in a fixed order that is not creation order.</para>
    /// </summary>
    Task<SpendLimitListPage> List(
        SpendLimitListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a spend limit.
    ///
    /// <para>For a Claude Enterprise organization, this deletes a per-user override,
    /// and the member falls back to any inherited spend limit at that period. Its
    /// seat-tier, group, and organization-level rows cannot be deleted via this
    /// endpoint. A Claude Console organization deletes its organization and workspace
    /// limits. Deleting them through the API is in an early access preview.</para>
    /// </summary>
    Task<SpendLimitDeleteResponse> Delete(
        SpendLimitDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SpendLimitDeleteParams, CancellationToken)"/>
    Task<SpendLimitDeleteResponse> Delete(
        string spendLimitID,
        SpendLimitDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set a spend limit.
    ///
    /// <para>Upsert keyed on (scope, period): setting a limit that already exists
    /// overwrites it in place. A Claude Enterprise organization sets `user` limits. Its
    /// seat-tier, group, and organization-level defaults are configured in claude.ai. A
    /// Claude Console organization sets `organization` and `workspace` limits, which
    /// are monthly and always carry an amount. Setting those limits is in an early
    /// access preview. To request access, contact your Anthropic account team.</para>
    /// </summary>
    Task<BetaSpendLimit> Set(
        SpendLimitSetParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISpendLimitService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISpendLimitServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpendLimitServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IEffectiveServiceWithRawResponse Effective { get; }

    IIncreaseRequestServiceWithRawResponse IncreaseRequests { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/spend_limits/{spend_limit_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="ISpendLimitService.Retrieve(SpendLimitRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaSpendLimit>> Retrieve(
        SpendLimitRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SpendLimitRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaSpendLimit>> Retrieve(
        string spendLimitID,
        SpendLimitRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/spend_limits?beta=true</c>, but is otherwise the
    /// same as <see cref="ISpendLimitService.List(SpendLimitListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SpendLimitListPage>> List(
        SpendLimitListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/spend_limits/{spend_limit_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="ISpendLimitService.Delete(SpendLimitDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SpendLimitDeleteResponse>> Delete(
        SpendLimitDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SpendLimitDeleteParams, CancellationToken)"/>
    Task<HttpResponse<SpendLimitDeleteResponse>> Delete(
        string spendLimitID,
        SpendLimitDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/spend_limits?beta=true</c>, but is otherwise the
    /// same as <see cref="ISpendLimitService.Set(SpendLimitSetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaSpendLimit>> Set(
        SpendLimitSetParams parameters,
        CancellationToken cancellationToken = default
    );
}
