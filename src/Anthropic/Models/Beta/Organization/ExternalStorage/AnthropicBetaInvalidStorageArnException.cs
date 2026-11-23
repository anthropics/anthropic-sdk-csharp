using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// On Claude Platform on AWS, the External Storage ID in the request is neither
/// a bucket ARN nor an `estrg_` ID, or is the `estrg_` ID of AWS storage. Name AWS
/// storage by its bucket ARN, `arn:&lt;partition&gt;:s3:::&lt;bucket_name&gt;`, which
/// responses return as its `id`.
/// </summary>
public sealed class AnthropicBetaInvalidStorageArnException : AnthropicBadRequestException
{
    public AnthropicBetaInvalidStorageArnException(HttpRequestException? innerException = null)
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
    public new BetaInvalidStorageArnErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaInvalidStorageArnErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
