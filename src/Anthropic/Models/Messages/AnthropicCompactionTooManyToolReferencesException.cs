using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The conversation references more distinct tools than a `compaction` block can record.
/// </summary>
public sealed class AnthropicCompactionTooManyToolReferencesException : AnthropicBadRequestException
{
    public AnthropicCompactionTooManyToolReferencesException(
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
    public new CompactionTooManyToolReferencesErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<CompactionTooManyToolReferencesErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
