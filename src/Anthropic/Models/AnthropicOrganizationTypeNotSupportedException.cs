using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The endpoint does not support the organization's type. Each endpoint's description
/// says which organization types it supports.
/// </summary>
public sealed class AnthropicOrganizationTypeNotSupportedException : AnthropicBadRequestException
{
    public AnthropicOrganizationTypeNotSupportedException(
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
    public new OrganizationTypeNotSupportedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<OrganizationTypeNotSupportedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
