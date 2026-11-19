using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;

/// <summary>
/// This stored settings document currently cannot be read or replaced. Contact support,
/// or, if you no longer need these settings, delete the group's settings or clear
/// the default.
/// </summary>
public sealed class AnthropicBetaCmekFeatureUnsupportedException : AnthropicBadRequestException
{
    public AnthropicBetaCmekFeatureUnsupportedException(HttpRequestException? innerException = null)
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
    public new BetaCmekFeatureUnsupportedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaCmekFeatureUnsupportedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
