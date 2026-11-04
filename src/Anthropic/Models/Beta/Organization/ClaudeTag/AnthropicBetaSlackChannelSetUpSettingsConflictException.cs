using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The request set the channel up, and something else then changed the channel or
/// removed it. Nothing of `settings` was stored.
/// </summary>
public sealed class AnthropicBetaSlackChannelSetUpSettingsConflictException
    : AnthropicConflictException
{
    public AnthropicBetaSlackChannelSetUpSettingsConflictException(
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
    public new BetaSlackChannelSetUpSettingsConflictErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaSlackChannelSetUpSettingsConflictErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
