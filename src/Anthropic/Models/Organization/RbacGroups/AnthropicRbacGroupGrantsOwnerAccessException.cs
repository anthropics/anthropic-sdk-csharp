using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.RbacGroups;

/// <summary>
/// A role attached to an RBAC Group in the request grants owner access, so this API
/// does not add members to that group (directly or through an invite), remove its
/// members, or delete it. Make the change in the organization's admin settings in Claude.
/// </summary>
public sealed class AnthropicRbacGroupGrantsOwnerAccessException : AnthropicBadRequestException
{
    public AnthropicRbacGroupGrantsOwnerAccessException(HttpRequestException? innerException = null)
        : base(innerException) { }

    /// <summary>
    /// <c>error.details.error_code</c> of <see cref="AnthropicServiceException.Body"/>.
    /// </summary>
    public new string ErrorCode
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<string>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(
                    WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                        ?? default,
                    "details"
                ) ?? default,
                "error_code"
            );
        }
    }

    /// <summary>
    /// <c>error.details</c> of <see cref="AnthropicServiceException.Body"/>.
    /// </summary>
    public new RbacGroupGrantsOwnerAccessErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<RbacGroupGrantsOwnerAccessErrorDetails>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                    ?? default,
                "details"
            );
        }
    }
}
