using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

/// <summary>
/// The External Key is held by a key management service that this endpoint does
/// not take. The message names the field and the service it takes.
/// </summary>
public sealed class AnthropicBetaExternalKeyProviderMismatchException : AnthropicBadRequestException
{
    public AnthropicBetaExternalKeyProviderMismatchException(
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
    public new BetaExternalKeyProviderMismatchErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaExternalKeyProviderMismatchErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
