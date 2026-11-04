using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// `settings.environment_id` names no Environment within the organization's reach.
/// </summary>
public sealed class AnthropicBetaEnvironmentNotFoundException : AnthropicNotFoundException
{
    public AnthropicBetaEnvironmentNotFoundException(HttpRequestException? innerException = null)
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
    public new BetaEnvironmentNotFoundErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaEnvironmentNotFoundErrorDetails>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                    ?? default,
                "details"
            );
        }
    }
}
