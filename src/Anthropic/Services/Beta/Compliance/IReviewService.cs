using System;
using Anthropic.Core;
using Anthropic.Services.Beta.Compliance.Review;

namespace Anthropic.Services.Beta.Compliance;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IReviewService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IReviewServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReviewService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICaseService Cases { get; }

    INoticeService Notices { get; }

    IItemService Items { get; }
}

/// <summary>
/// A view of <see cref="IReviewService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IReviewServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReviewServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICaseServiceWithRawResponse Cases { get; }

    INoticeServiceWithRawResponse Notices { get; }

    IItemServiceWithRawResponse Items { get; }
}
