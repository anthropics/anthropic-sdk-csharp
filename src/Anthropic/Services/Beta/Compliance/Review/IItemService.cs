using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Compliance.Review.Items;

namespace Anthropic.Services.Beta.Compliance.Review;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IItemService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IItemServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Read one message that Anthropic flagged for your organization to review, with
    /// its request and response.
    ///
    /// <para>A message that the API key can't read, or that isn't flagged, returns the
    /// same 404 as one that doesn't exist. For a message recorded with a user profile,
    /// send that profile's ID in the `anthropic-user-profile-id` header. A flagged
    /// message can also return 404 if it belongs to another organization than the key's
    /// own, or to your end customer's user profile or Workspace.</para>
    ///
    /// <para>If your encryption key or storage bucket refuses the read, the API returns
    /// a 400 with `cmek_key_disabled`, `storage_bucket_unreadable` or
    /// `customer_storage_refusal_unattributed` in `error.details.error_code`.</para>
    ///
    /// <para>The API key must have the `read:compliance_review_items`,
    /// `read:compliance_user_data` or `read:org_audit` scope. A key of an organization
    /// with no parent organization must have `read:compliance_review_items`.</para>
    /// </summary>
    Task<BetaComplianceReviewItem> Retrieve(
        ItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ItemRetrieveParams, CancellationToken)"/>
    Task<BetaComplianceReviewItem> Retrieve(
        string itemID,
        ItemRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IItemService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IItemServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IItemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/compliance/review/items/{item_id}</c>, but is otherwise the
    /// same as <see cref="IItemService.Retrieve(ItemRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaComplianceReviewItem>> Retrieve(
        ItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ItemRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaComplianceReviewItem>> Retrieve(
        string itemID,
        ItemRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
