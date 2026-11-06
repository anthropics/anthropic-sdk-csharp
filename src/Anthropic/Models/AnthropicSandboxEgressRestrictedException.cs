using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The request came from a Claude sandbox with restricted network access, which
/// is not allowed to make this change. Send it from outside the sandbox, or from
/// a sandbox with unrestricted network access.
/// </summary>
public sealed class AnthropicSandboxEgressRestrictedException : AnthropicForbiddenException
{
    public AnthropicSandboxEgressRestrictedException(HttpRequestException? innerException = null)
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
    public new SandboxEgressRestrictedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<SandboxEgressRestrictedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
