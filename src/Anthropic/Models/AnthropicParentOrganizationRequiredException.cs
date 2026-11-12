using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The endpoint serves only organizations that belong to a parent organization, and
/// this organization belongs to none.
/// </summary>
public sealed class AnthropicParentOrganizationRequiredException : AnthropicBadRequestException
{
    public AnthropicParentOrganizationRequiredException(HttpRequestException? innerException = null)
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
    public new ParentOrganizationRequiredErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<ParentOrganizationRequiredErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
