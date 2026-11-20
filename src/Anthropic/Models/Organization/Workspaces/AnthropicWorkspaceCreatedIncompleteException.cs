using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

/// <summary>
/// The Workspace was created, but some of what the request asked for did not take
/// effect, or may not have. Don't send the create again. The error's `message` says
/// what to do with the Workspace at `workspace_id`.
/// </summary>
public sealed class AnthropicWorkspaceCreatedIncompleteException
    : AnthropicServiceUnavailableException
{
    public AnthropicWorkspaceCreatedIncompleteException(HttpRequestException? innerException = null)
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
    public new WorkspaceCreatedIncompleteErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<WorkspaceCreatedIncompleteErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
