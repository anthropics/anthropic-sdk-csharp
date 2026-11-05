using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ExternalKeys;

/// <summary>
/// The External Key failed Anthropic's validation, so the request was refused. The
/// message gives the reason, if there is one.
/// </summary>
public sealed class AnthropicExternalKeyValidationFailedException : AnthropicBadRequestException
{
    public AnthropicExternalKeyValidationFailedException(
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
    public new ExternalKeyValidationFailedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<ExternalKeyValidationFailedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
