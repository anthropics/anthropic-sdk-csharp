using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization;

/// <summary>
/// Some of the request's changes may have been saved and others not. Send the same
/// request again to finish it; changes already saved aren't repeated.
/// </summary>
public sealed class AnthropicChangeOutcomeUnknownException : AnthropicServiceUnavailableException
{
    public AnthropicChangeOutcomeUnknownException(HttpRequestException? innerException = null)
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
    public new ChangeOutcomeUnknownErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<ChangeOutcomeUnknownErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
