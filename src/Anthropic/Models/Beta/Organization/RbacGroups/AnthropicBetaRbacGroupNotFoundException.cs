using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.RbacGroups;

/// <summary>
/// The RBAC Group is not one of the organization's groups.
/// </summary>
public sealed class AnthropicBetaRbacGroupNotFoundException : AnthropicNotFoundException
{
    public AnthropicBetaRbacGroupNotFoundException(HttpRequestException? innerException = null)
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
    public new BetaRbacGroupNotFoundErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaRbacGroupNotFoundErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
