using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Compliance.Review.Cases;

namespace Anthropic.Services.Beta.Compliance.Review;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICaseService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICaseServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICaseService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Read one review case.
    ///
    /// <para>A case that the API key can't reach, or that Anthropic hasn't sent,
    /// returns the same 404 as a case that doesn't exist.</para>
    ///
    /// <para>An Admin API key with the `read:compliance_review_cases` scope can call
    /// this endpoint.</para>
    /// </summary>
    Task<BetaComplianceReviewCase> Retrieve(
        CaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CaseRetrieveParams, CancellationToken)"/>
    Task<BetaComplianceReviewCase> Retrieve(
        string caseID,
        CaseRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the review cases of every organization that the API key can reach, newest
    /// first by default. Both open and closed cases are returned unless `status` is
    /// set.
    ///
    /// <para>To sync, store the largest `updated_at` you have read, and send it as the
    /// at-or-after filter on `updated_at`, sorted by `updated_at` ascending. That finds
    /// new cases, newly closed cases, and cases with a new notice. Read every page,
    /// match results by `id`, and store the new largest value after the last page.</para>
    ///
    /// <para>A request with the `anthropic-user-profile-id` header and no
    /// `user_profile_id` parameter returns a 400 error.</para>
    ///
    /// <para>An Admin API key with the `read:compliance_review_cases` scope can call
    /// this endpoint.</para>
    /// </summary>
    Task<CaseListPage> List(
        CaseListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send your conclusion on a review case. A response closes the case, and a closed
    /// case can't be reopened.
    ///
    /// <para>Only the first response counts. A request is safe to send again: if the
    /// closed case has a response with the same field values, in any list order, the
    /// API returns 200 and changes nothing. If the closed case has a different
    /// response, or none, the API returns a 400 with `case_closed` in
    /// `error.details.error_code`.</para>
    ///
    /// <para>If your end customer reviews this case instead of you, the API returns a
    /// 403 with `case_reviewed_by_end_customer` in `error.details.error_code`.</para>
    ///
    /// <para>An Admin API key with the `write:compliance_review_cases` scope can call
    /// this endpoint.</para>
    /// </summary>
    Task<BetaComplianceReviewCase> Respond(
        CaseRespondParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Respond(CaseRespondParams, CancellationToken)"/>
    Task<BetaComplianceReviewCase> Respond(
        string caseID,
        CaseRespondParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICaseService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICaseServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICaseServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/compliance/review/cases/{case_id}</c>, but is otherwise the
    /// same as <see cref="ICaseService.Retrieve(CaseRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaComplianceReviewCase>> Retrieve(
        CaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CaseRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaComplianceReviewCase>> Retrieve(
        string caseID,
        CaseRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/compliance/review/cases</c>, but is otherwise the
    /// same as <see cref="ICaseService.List(CaseListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CaseListPage>> List(
        CaseListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/compliance/review/cases/{case_id}/respond</c>, but is otherwise the
    /// same as <see cref="ICaseService.Respond(CaseRespondParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaComplianceReviewCase>> Respond(
        CaseRespondParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Respond(CaseRespondParams, CancellationToken)"/>
    Task<HttpResponse<BetaComplianceReviewCase>> Respond(
        string caseID,
        CaseRespondParams parameters,
        CancellationToken cancellationToken = default
    );
}
