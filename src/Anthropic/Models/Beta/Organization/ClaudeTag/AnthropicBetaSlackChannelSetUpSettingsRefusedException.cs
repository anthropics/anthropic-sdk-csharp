using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The request set the channel up, and `settings` was then refused. The channel stays
/// set up with every setting unset.
/// </summary>
public sealed class AnthropicBetaSlackChannelSetUpSettingsRefusedException
    : AnthropicBadRequestException
{
    public AnthropicBetaSlackChannelSetUpSettingsRefusedException(
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
    public new BetaSlackChannelSetUpSettingsRefusedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaSlackChannelSetUpSettingsRefusedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
