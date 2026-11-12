using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization;

/// <summary>
/// No RBAC Role with this ID was found.
/// </summary>
public sealed class AnthropicRbacRoleNotFoundException : AnthropicNotFoundException
{
    public AnthropicRbacRoleNotFoundException(HttpRequestException? innerException = null)
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
    public new RbacRoleNotFoundErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<RbacRoleNotFoundErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
