using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// The External Storage can't be deleted while an Enterprise Frontier Safeguards
/// workspace policy lists it as allowed storage.
/// </summary>
public sealed class AnthropicBetaExternalStorageInWorkspacePolicyException
    : AnthropicBadRequestException
{
    public AnthropicBetaExternalStorageInWorkspacePolicyException(
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
    public new BetaExternalStorageInWorkspacePolicyErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaExternalStorageInWorkspacePolicyErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
