using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The response that `previous_message_id` names has already been continued, and
/// each response can be continued only once. Continue from the Thread's most recent
/// response `id`.
/// </summary>
public sealed class AnthropicThreadAlreadyContinuedException : AnthropicBadRequestException
{
    public AnthropicThreadAlreadyContinuedException(HttpRequestException? innerException = null)
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
    public new ThreadAlreadyContinuedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<ThreadAlreadyContinuedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
