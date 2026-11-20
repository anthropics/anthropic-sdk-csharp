using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// This storage is bound to a different user profile from storage the Workspace has
/// attached, or from active or draining storage it once had for safeguards data.
/// Detaching storage the Workspace uses only for transcripts clears this. Detaching
/// safeguards storage doesn't, so use a new Workspace instead.
/// </summary>
public sealed class AnthropicBetaStorageProfileStillRequiredException : AnthropicBadRequestException
{
    public AnthropicBetaStorageProfileStillRequiredException(
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
    public new BetaStorageProfileStillRequiredErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaStorageProfileStillRequiredErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
