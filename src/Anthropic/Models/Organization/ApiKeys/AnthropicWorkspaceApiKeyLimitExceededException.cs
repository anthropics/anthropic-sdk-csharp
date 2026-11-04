using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ApiKeys;

/// <summary>
/// The workspace has reached its limit of active API keys.
/// </summary>
public sealed class AnthropicWorkspaceApiKeyLimitExceededException : AnthropicBadRequestException
{
    public AnthropicWorkspaceApiKeyLimitExceededException(
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
    public new WorkspaceApiKeyLimitExceededErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<WorkspaceApiKeyLimitExceededErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
