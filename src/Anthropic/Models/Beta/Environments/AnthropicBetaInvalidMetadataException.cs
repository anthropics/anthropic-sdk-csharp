using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// `metadata` has too many keys, a key or value that is too long, or a reserved
/// key. The message names each problem.
/// </summary>
public sealed class AnthropicBetaInvalidMetadataException : AnthropicBadRequestException
{
    public AnthropicBetaInvalidMetadataException(HttpRequestException? innerException = null)
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
    public new BetaInvalidMetadataErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaInvalidMetadataErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
