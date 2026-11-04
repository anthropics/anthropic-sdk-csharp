using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The workspace's customer-managed encryption key is disabled or revoked. Re-enable
/// the key, then retry.
/// </summary>
public sealed class AnthropicCmekKeyDisabledException : AnthropicBadRequestException
{
    public AnthropicCmekKeyDisabledException(HttpRequestException? innerException = null)
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
    public new CmekKeyDisabledErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<CmekKeyDisabledErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
