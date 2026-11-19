using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;

/// <summary>
/// The organization has reached its limit of settings documents, counting unused
/// ones. An owner can remove unused documents in claude.ai. Deleting a group's settings
/// or clearing the default settings also frees a document, if nothing else uses it.
/// None of these works once the organization has also reached its settings history limit.
/// </summary>
public sealed class AnthropicBetaSettingsDocumentLimitExceededException
    : AnthropicBadRequestException
{
    public AnthropicBetaSettingsDocumentLimitExceededException(
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
    public new BetaSettingsDocumentLimitExceededErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaSettingsDocumentLimitExceededErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
