using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Skills;

/// <summary>
/// A custom skill the request names is stored under an encryption key state the
/// workspace cannot currently decrypt.
/// </summary>
public sealed class AnthropicSkillReadBlockedUndecryptableException : AnthropicConflictException
{
    public AnthropicSkillReadBlockedUndecryptableException(
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
    public new SkillReadBlockedUndecryptableErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<SkillReadBlockedUndecryptableErrorDetails>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                    ?? default,
                "details"
            );
        }
    }
}
