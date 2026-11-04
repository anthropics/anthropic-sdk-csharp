using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// Anthropic has disabled the organization for trust and safety reasons. An organization
/// disabled for any other reason, such as billing, does not get this code. `appeal_url`,
/// when present, is where the organization can appeal.
/// </summary>
public sealed class AnthropicOrganizationOnHoldException : AnthropicBadRequestException
{
    public AnthropicOrganizationOnHoldException(HttpRequestException? innerException = null)
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
    public new OrganizationOnHoldErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<OrganizationOnHoldErrorDetails>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                    ?? default,
                "details"
            );
        }
    }
}
