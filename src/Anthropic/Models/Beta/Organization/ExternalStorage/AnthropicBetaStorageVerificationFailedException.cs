using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// The External Storage failed verification, so the request changed nothing. `failed_checks`
/// lists what to fix.
/// </summary>
public sealed class AnthropicBetaStorageVerificationFailedException : AnthropicBadRequestException
{
    public AnthropicBetaStorageVerificationFailedException(
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
    public new BetaStorageVerificationFailedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaStorageVerificationFailedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
