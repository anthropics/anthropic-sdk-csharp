using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ExternalKeys;

/// <summary>
/// Anthropic's validation of the External Key did not finish in time, so the request
/// was refused. Wait a moment, then send the request again.
/// </summary>
public sealed class AnthropicExternalKeyValidationTimedOutException : AnthropicBadRequestException
{
    public AnthropicExternalKeyValidationTimedOutException(
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
    public new ExternalKeyValidationTimedOutErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<ExternalKeyValidationTimedOutErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
