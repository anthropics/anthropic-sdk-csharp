using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// External Storage isn't available for this Workspace, so only `internal` storage
/// is accepted. The error's `message` says why.
/// </summary>
public sealed class AnthropicBetaExternalStorageNotAvailableException : AnthropicBadRequestException
{
    public AnthropicBetaExternalStorageNotAvailableException(
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
    public new BetaExternalStorageNotAvailableErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaExternalStorageNotAvailableErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
