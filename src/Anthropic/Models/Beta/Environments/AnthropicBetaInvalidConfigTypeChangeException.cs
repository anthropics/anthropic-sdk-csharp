using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// `config.type` differs from the environment's stored type, which cannot change
/// after creation.
/// </summary>
public sealed class AnthropicBetaInvalidConfigTypeChangeException : AnthropicBadRequestException
{
    public AnthropicBetaInvalidConfigTypeChangeException(
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
    public new BetaInvalidConfigTypeChangeErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaInvalidConfigTypeChangeErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
