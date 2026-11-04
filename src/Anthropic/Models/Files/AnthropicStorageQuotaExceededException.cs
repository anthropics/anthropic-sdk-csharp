using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Files;

/// <summary>
/// The organization's file storage quota is exhausted. Delete files to free up space,
/// then retry the upload.
/// </summary>
public sealed class AnthropicStorageQuotaExceededException : AnthropicBadRequestException
{
    public AnthropicStorageQuotaExceededException(HttpRequestException? innerException = null)
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
    public new StorageQuotaExceededErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<StorageQuotaExceededErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
