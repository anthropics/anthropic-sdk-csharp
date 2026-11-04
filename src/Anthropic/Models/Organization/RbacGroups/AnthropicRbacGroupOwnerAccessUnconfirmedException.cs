using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.RbacGroups;

/// <summary>
/// The API could not finish checking whether an RBAC Group in the request grants
/// owner access (the check reached a fixed limit), so it made no change. Retrying
/// the same request will not help. Make the change in the organization's admin settings
/// in Claude.
/// </summary>
public sealed class AnthropicRbacGroupOwnerAccessUnconfirmedException : AnthropicBadRequestException
{
    public AnthropicRbacGroupOwnerAccessUnconfirmedException(
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
    public new RbacGroupOwnerAccessUnconfirmedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<RbacGroupOwnerAccessUnconfirmedErrorDetails>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                    ?? default,
                "details"
            );
        }
    }
}
