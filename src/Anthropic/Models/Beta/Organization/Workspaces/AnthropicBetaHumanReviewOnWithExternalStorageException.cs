using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces;

/// <summary>
/// The request would leave the Workspace with `inference_data_privacy.safeguards_storage`
/// set to External Storage and `inference_data_privacy.human_review` enabled. Anthropic
/// doesn't offer human review of data in a customer's own storage. Set `human_review`
/// to `disabled`, or `safeguards_storage` to `internal`.
/// </summary>
public sealed class AnthropicBetaHumanReviewOnWithExternalStorageException
    : AnthropicBadRequestException
{
    public AnthropicBetaHumanReviewOnWithExternalStorageException(
        HttpRequestException? innerException = null
    )
        : base(innerException) { }

    /// <summary>
    /// <c>error.details.error_code</c> of <see cref="AnthropicServiceException.Body"/>.
    /// </summary>
    public new string ErrorCode
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<string>(
                this.ErrorDetailsJson,
                "error_code"
            );
        }
    }

    /// <summary>
    /// <c>error.details</c> of <see cref="AnthropicServiceException.Body"/>.
    /// </summary>
    public new BetaHumanReviewOnWithExternalStorageErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaHumanReviewOnWithExternalStorageErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
