using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The compaction request ends on an `assistant` turn that is not finished.
/// </summary>
public sealed class AnthropicCompactionIncompleteTurnException : AnthropicBadRequestException
{
    public AnthropicCompactionIncompleteTurnException(HttpRequestException? innerException = null)
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
    public new CompactionIncompleteTurnErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<CompactionIncompleteTurnErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
