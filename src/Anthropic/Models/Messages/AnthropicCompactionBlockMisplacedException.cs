using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The `compaction` block is not the first block of the conversation, or is in a
/// `system` message.
/// </summary>
public sealed class AnthropicCompactionBlockMisplacedException : AnthropicBadRequestException
{
    public AnthropicCompactionBlockMisplacedException(HttpRequestException? innerException = null)
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
    public new CompactionBlockMisplacedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<CompactionBlockMisplacedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
