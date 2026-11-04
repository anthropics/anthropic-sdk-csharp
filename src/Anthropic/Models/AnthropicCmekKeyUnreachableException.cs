using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The workspace's customer-managed encryption key could not be reached. Retry the
/// request; if this continues, check that the key is available in your key management
/// service, or contact Anthropic support.
/// </summary>
public sealed class AnthropicCmekKeyUnreachableException : AnthropicServiceUnavailableException
{
    public AnthropicCmekKeyUnreachableException(HttpRequestException? innerException = null)
        : base(innerException) { }

    /// <summary>
    /// <c>error.details.error_code</c> of <see cref="AnthropicServiceException.Body"/>.
    /// </summary>
    public new string ErrorCode
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<string>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(
                    WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                        ?? default,
                    "details"
                ) ?? default,
                "error_code"
            );
        }
    }

    /// <summary>
    /// <c>error.details</c> of <see cref="AnthropicServiceException.Body"/>.
    /// </summary>
    public new CmekKeyUnreachableErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<CmekKeyUnreachableErrorDetails>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                    ?? default,
                "details"
            );
        }
    }
}
