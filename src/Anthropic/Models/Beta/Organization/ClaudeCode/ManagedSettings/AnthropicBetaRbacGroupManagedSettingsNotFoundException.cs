using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;

/// <summary>
/// This RBAC Group has no Claude Code managed settings.
/// </summary>
public sealed class AnthropicBetaRbacGroupManagedSettingsNotFoundException
    : AnthropicNotFoundException
{
    public AnthropicBetaRbacGroupManagedSettingsNotFoundException(
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
    public new BetaRbacGroupManagedSettingsNotFoundErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaRbacGroupManagedSettingsNotFoundErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
