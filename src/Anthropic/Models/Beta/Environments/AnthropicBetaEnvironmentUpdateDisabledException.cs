using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// Anthropic has turned off updating environments for this organization. Existing
/// environments still work as they are.
/// </summary>
public sealed class AnthropicBetaEnvironmentUpdateDisabledException : AnthropicForbiddenException
{
    public AnthropicBetaEnvironmentUpdateDisabledException(
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
    public new BetaEnvironmentUpdateDisabledErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaEnvironmentUpdateDisabledErrorDetails>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                    ?? default,
                "details"
            );
        }
    }
}
