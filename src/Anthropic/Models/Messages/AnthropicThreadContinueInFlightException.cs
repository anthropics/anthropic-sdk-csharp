using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// Another request is still continuing from the same `previous_message_id`. Wait
/// for it to complete and continue from its response `id`, or replay the full conversation
/// with `thread: {"type": "create"}`.
/// </summary>
public sealed class AnthropicThreadContinueInFlightException : AnthropicBadRequestException
{
    public AnthropicThreadContinueInFlightException(HttpRequestException? innerException = null)
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
    public new ThreadContinueInFlightErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<ThreadContinueInFlightErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
