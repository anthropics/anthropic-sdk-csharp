using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// `messages` holds more than one `compaction` block with content. Send only the
/// block the conversation returned last.
/// </summary>
public sealed class AnthropicCompactionBlockAmbiguousException : AnthropicBadRequestException
{
    public AnthropicCompactionBlockAmbiguousException(HttpRequestException? innerException = null)
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
    public new CompactionBlockAmbiguousErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<CompactionBlockAmbiguousErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
