using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Plugins;

/// <summary>
/// The marketplace already holds this name. `plugin_id` is the Plugin that holds
/// it, and can be absent.
/// </summary>
public sealed class AnthropicBetaPluginNameTakenException : AnthropicConflictException
{
    public AnthropicBetaPluginNameTakenException(HttpRequestException? innerException = null)
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
    public new BetaPluginNameTakenErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaPluginNameTakenErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
