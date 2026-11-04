using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments.Work;

/// <summary>
/// `expected_last_heartbeat` does not match the stored heartbeat, so another worker
/// may hold the lease.
/// </summary>
public sealed class AnthropicBetaHeartbeatPreconditionFailedException
    : AnthropicPreconditionFailedException
{
    public AnthropicBetaHeartbeatPreconditionFailedException(
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
    public new BetaHeartbeatPreconditionFailedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaHeartbeatPreconditionFailedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
