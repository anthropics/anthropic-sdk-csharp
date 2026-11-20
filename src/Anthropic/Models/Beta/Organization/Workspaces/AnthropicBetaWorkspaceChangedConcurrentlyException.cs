using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces;

/// <summary>
/// Another request changed the Workspace, so this request left the setting named
/// in `field` as it is. The error's `message` says which of this request's other
/// changes are in place. Read the Workspace and send the request again if you still
/// want the change.
/// </summary>
public sealed class AnthropicBetaWorkspaceChangedConcurrentlyException : AnthropicConflictException
{
    public AnthropicBetaWorkspaceChangedConcurrentlyException(
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
    public new BetaWorkspaceChangedConcurrentlyErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaWorkspaceChangedConcurrentlyErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
