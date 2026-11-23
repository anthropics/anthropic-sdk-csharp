using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// The External Storage is `active` or `draining`, so this delete didn't erase it.
/// The message says what to do next. On `draining` storage this delete may have started
/// a removal that can't be undone: get the storage and read `status.removal_started`.
/// </summary>
public sealed class AnthropicBetaExternalStorageInUseException : AnthropicBadRequestException
{
    public AnthropicBetaExternalStorageInUseException(HttpRequestException? innerException = null)
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
    public new BetaExternalStorageInUseErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaExternalStorageInUseErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
