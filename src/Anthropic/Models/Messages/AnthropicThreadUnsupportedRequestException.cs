using System.Net.Http;
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
                this.ErrorDetailsJson,
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
                this.ErrorJson,
                "details"
            );
        }
    }
}
