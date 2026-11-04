using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// A field that must stay the same across a Thread's turns differs from the value
/// stored with the Thread; the message names each such field. Send the stored values,
/// or replay the full conversation with `thread: {"type": "create"}` to change them.
/// </summary>
public sealed class AnthropicThreadFingerprintMismatchException : AnthropicBadRequestException
{
    public AnthropicThreadFingerprintMismatchException(HttpRequestException? innerException = null)
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
    public new ThreadFingerprintMismatchErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<ThreadFingerprintMismatchErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
