using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The Bundle has an attachment this API does not support editing, so its instructions
/// can be changed only in claude.ai.
/// </summary>
public sealed class AnthropicBetaBundleAttachmentNotSupportedException
    : AnthropicBadRequestException
{
    public AnthropicBetaBundleAttachmentNotSupportedException(
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
    public new BetaBundleAttachmentNotSupportedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaBundleAttachmentNotSupportedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
