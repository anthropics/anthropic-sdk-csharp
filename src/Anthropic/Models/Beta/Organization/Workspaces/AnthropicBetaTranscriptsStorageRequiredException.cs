using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces;

/// <summary>
/// In an organization managed through AWS or Google Cloud, the request would leave
/// the Workspace with `inference_data_privacy.human_review` disabled and `inference_data_privacy.transcripts_storage`
/// not set to External Storage. With human review disabled, the organization reviews
/// its own flagged requests, and it receives them only in that storage.
/// </summary>
public sealed class AnthropicBetaTranscriptsStorageRequiredException : AnthropicBadRequestException
{
    public AnthropicBetaTranscriptsStorageRequiredException(
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
    public new BetaTranscriptsStorageRequiredErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaTranscriptsStorageRequiredErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
