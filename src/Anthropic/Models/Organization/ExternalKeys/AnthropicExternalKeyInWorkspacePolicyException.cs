using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ExternalKeys;

/// <summary>
/// The External Key can't be deleted or reconfigured while the organization's Workspace
/// Policy lists it as an allowed key.
/// </summary>
public sealed class AnthropicExternalKeyInWorkspacePolicyException : AnthropicBadRequestException
{
    public AnthropicExternalKeyInWorkspacePolicyException(
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
    public new ExternalKeyInWorkspacePolicyErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<ExternalKeyInWorkspacePolicyErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
