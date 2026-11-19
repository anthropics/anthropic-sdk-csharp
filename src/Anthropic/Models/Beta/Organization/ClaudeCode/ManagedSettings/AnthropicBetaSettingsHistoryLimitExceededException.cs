using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;

/// <summary>
/// The organization has reached its settings history limit, a cap on stored versions
/// of its settings documents. Nothing in the API or claude.ai lowers the count,
/// so contact support. Creating or deleting group settings, creating or clearing
/// the default settings, and reordering are refused. Changing the mode still works,
/// unless it would copy the organization settings into a new default.
/// </summary>
public sealed class AnthropicBetaSettingsHistoryLimitExceededException
    : AnthropicBadRequestException
{
    public AnthropicBetaSettingsHistoryLimitExceededException(
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
    public new BetaSettingsHistoryLimitExceededErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaSettingsHistoryLimitExceededErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
