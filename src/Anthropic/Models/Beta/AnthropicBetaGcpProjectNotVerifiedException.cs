using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

/// <summary>
/// The organization has not proved that it owns the Google Cloud project that holds
/// the key or bucket. The message names the field.
/// </summary>
public sealed class AnthropicBetaGcpProjectNotVerifiedException : AnthropicBadRequestException
{
    public AnthropicBetaGcpProjectNotVerifiedException(HttpRequestException? innerException = null)
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
    public new BetaGcpProjectNotVerifiedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaGcpProjectNotVerifiedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
