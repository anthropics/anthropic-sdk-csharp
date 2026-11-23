using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// The Workspace has reached its limit of 100 different External Storage resources
/// attached over its lifetime. Detached storage counts toward the limit until it
/// is deleted.
/// </summary>
public sealed class AnthropicBetaStorageAttachLimitReachedException : AnthropicBadRequestException
{
    public AnthropicBetaStorageAttachLimitReachedException(
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
    public new BetaStorageAttachLimitReachedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaStorageAttachLimitReachedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
