using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The request combines `thread` with a request field or an organization setting
/// that Threads do not support; `unsupported`, when present, names it. Send the
/// full conversation without `thread`, or change that field.
/// </summary>
public sealed class AnthropicThreadUnsupportedRequestException : AnthropicBadRequestException
{
    public AnthropicThreadUnsupportedRequestException(HttpRequestException? innerException = null)
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
    public new ThreadUnsupportedRequestErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<ThreadUnsupportedRequestErrorDetails>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                    ?? default,
                "details"
            );
        }
    }
}
