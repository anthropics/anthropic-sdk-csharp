using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

namespace Anthropic.Services.Beta.Organization.SpendLimits;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IIncreaseRequestService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IIncreaseRequestServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIncreaseRequestService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve a spend limit increase request.
    ///
    /// <para>While `pending`, the response includes a live `spend_summary` for the
    /// requester at the request's period.</para>
    /// </summary>
    Task<BetaSpendLimitIncreaseRequest> Retrieve(
        IncreaseRequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(IncreaseRequestRetrieveParams, CancellationToken)"/>
    Task<BetaSpendLimitIncreaseRequest> Retrieve(
        string spendLimitIncreaseRequestID,
        IncreaseRequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List spend limit increase requests, most recent first.
    ///
    /// <para>Pending requests include a live `spend_summary` for the requester.
    /// Requests whose requester is no longer a member are excluded.</para>
    /// </summary>
    Task<IncreaseRequestListPage> List(
        IncreaseRequestListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Approve a pending spend limit increase request.
    ///
    /// <para>Writes a per-user spend limit at `amount` for the requester and
    /// transitions the request to `approved`. `period` defaults to the period the
    /// member was blocked on. Anthropic emails the requester unless
    /// `suppress_notification` is set.</para>
    /// </summary>
    Task<IncreaseRequestApproveResponse> Approve(
        IncreaseRequestApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(IncreaseRequestApproveParams, CancellationToken)"/>
    Task<IncreaseRequestApproveResponse> Approve(
        string spendLimitIncreaseRequestID,
        IncreaseRequestApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deny a pending spend limit increase request.
    ///
    /// <para>Idempotent on `denied`; denying an already-`approved` request returns 400.
    /// Anthropic emails the requester unless `suppress_notification` is set.</para>
    /// </summary>
    Task<BetaSpendLimitIncreaseRequest> Deny(
        IncreaseRequestDenyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deny(IncreaseRequestDenyParams, CancellationToken)"/>
    Task<BetaSpendLimitIncreaseRequest> Deny(
        string spendLimitIncreaseRequestID,
        IncreaseRequestDenyParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IIncreaseRequestService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IIncreaseRequestServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIncreaseRequestServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/spend_limit_increase_requests/{spend_limit_increase_request_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IIncreaseRequestService.Retrieve(IncreaseRequestRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaSpendLimitIncreaseRequest>> Retrieve(
        IncreaseRequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(IncreaseRequestRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaSpendLimitIncreaseRequest>> Retrieve(
        string spendLimitIncreaseRequestID,
        IncreaseRequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/spend_limit_increase_requests?beta=true</c>, but is otherwise the
    /// same as <see cref="IIncreaseRequestService.List(IncreaseRequestListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IncreaseRequestListPage>> List(
        IncreaseRequestListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/spend_limit_increase_requests/{spend_limit_increase_request_id}/approve?beta=true</c>, but is otherwise the
    /// same as <see cref="IIncreaseRequestService.Approve(IncreaseRequestApproveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IncreaseRequestApproveResponse>> Approve(
        IncreaseRequestApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(IncreaseRequestApproveParams, CancellationToken)"/>
    Task<HttpResponse<IncreaseRequestApproveResponse>> Approve(
        string spendLimitIncreaseRequestID,
        IncreaseRequestApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/spend_limit_increase_requests/{spend_limit_increase_request_id}/deny?beta=true</c>, but is otherwise the
    /// same as <see cref="IIncreaseRequestService.Deny(IncreaseRequestDenyParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaSpendLimitIncreaseRequest>> Deny(
        IncreaseRequestDenyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deny(IncreaseRequestDenyParams, CancellationToken)"/>
    Task<HttpResponse<BetaSpendLimitIncreaseRequest>> Deny(
        string spendLimitIncreaseRequestID,
        IncreaseRequestDenyParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
