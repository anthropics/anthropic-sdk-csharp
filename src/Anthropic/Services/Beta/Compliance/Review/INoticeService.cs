using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Compliance.Review.Notices;

namespace Anthropic.Services.Beta.Compliance.Review;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface INoticeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INoticeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INoticeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List Anthropic's notices to the organizations that the API key can reach, newest
    /// first by default. A notice is returned only if the API key can read every case
    /// in its `case_ids`.
    ///
    /// <para>To poll, store the largest `created_at` you have read, and send it as the
    /// at-or-after filter on `created_at`. Read every page, match results by `id`, and
    /// store the new largest value after the last page.</para>
    ///
    /// <para>An Admin API key with the `read:compliance_review_cases` scope can call
    /// this endpoint.</para>
    /// </summary>
    Task<NoticeListPage> List(
        NoticeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="INoticeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INoticeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INoticeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/compliance/review/notices</c>, but is otherwise the
    /// same as <see cref="INoticeService.List(NoticeListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NoticeListPage>> List(
        NoticeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
