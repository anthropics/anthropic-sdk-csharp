using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization;

/// <summary>
/// Human review can't be set as requested on this Workspace, so the request changed
/// nothing. The error's `message` says what to do instead.
/// </summary>
public sealed class AnthropicBetaHumanReviewNotAvailableException : AnthropicBadRequestException
{
    public AnthropicBetaHumanReviewNotAvailableException(
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
    public new BetaHumanReviewNotAvailableErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaHumanReviewNotAvailableErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
