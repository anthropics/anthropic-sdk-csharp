using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// `messages` holds no `user` or `assistant` content to summarize or adopt.
/// </summary>
public sealed class AnthropicCompactionNothingToSummarizeException : AnthropicBadRequestException
{
    public AnthropicCompactionNothingToSummarizeException(
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
                this.ErrorDetailsJson,
                "error_code"
            );
        }
    }

    /// <summary>
    /// <c>error.details</c> of <see cref="AnthropicServiceException.Body"/>.
    /// </summary>
    public new CompactionNothingToSummarizeErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<CompactionNothingToSummarizeErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
