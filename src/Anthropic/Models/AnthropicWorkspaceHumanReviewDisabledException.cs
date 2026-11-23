using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The request's Workspace has Human Review turned off, and this operation is not
/// available there. Use a Workspace with Human Review on.
/// </summary>
public sealed class AnthropicWorkspaceHumanReviewDisabledException : AnthropicBadRequestException
{
    public AnthropicWorkspaceHumanReviewDisabledException(
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
    public new WorkspaceHumanReviewDisabledErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<WorkspaceHumanReviewDisabledErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
