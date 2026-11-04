using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Plugins;

/// <summary>
/// The Plugin version was stored but is not yet usable in claude.ai. `plugin_id`
/// and `plugin_version_id` identify what was stored.
/// </summary>
public sealed class AnthropicBetaRegistrationPendingException : AnthropicServiceUnavailableException
{
    public AnthropicBetaRegistrationPendingException(HttpRequestException? innerException = null)
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
    public new BetaRegistrationPendingErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaRegistrationPendingErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
