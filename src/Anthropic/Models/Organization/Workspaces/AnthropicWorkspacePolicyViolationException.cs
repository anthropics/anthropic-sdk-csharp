using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

/// <summary>
/// The request breaks the organization's Workspace Policy. The message says which
/// rule it broke; an organization admin can see and change the policy in the Console.
/// </summary>
public sealed class AnthropicWorkspacePolicyViolationException : AnthropicBadRequestException
{
    public AnthropicWorkspacePolicyViolationException(HttpRequestException? innerException = null)
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
    public new WorkspacePolicyViolationErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<WorkspacePolicyViolationErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
