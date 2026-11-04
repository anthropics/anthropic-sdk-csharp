using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// `settings.environment_id` names no Environment within the organization's reach,
/// and the request had set the channel up by then. The channel stays set up with
/// every setting unset.
/// </summary>
public sealed class AnthropicBetaSlackChannelSetUpEnvironmentNotFoundException
    : AnthropicNotFoundException
{
    public AnthropicBetaSlackChannelSetUpEnvironmentNotFoundException(
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
    public new BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaSlackChannelSetUpEnvironmentNotFoundErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
