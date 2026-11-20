using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// Another request changed this storage setting while this one was running, so this
/// request left it as it is. Read the Workspace and send the request again if you
/// still want the change.
/// </summary>
public sealed class AnthropicBetaStorageChangedConcurrentlyException : AnthropicConflictException
{
    public AnthropicBetaStorageChangedConcurrentlyException(
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
    public new BetaStorageChangedConcurrentlyErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaStorageChangedConcurrentlyErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
