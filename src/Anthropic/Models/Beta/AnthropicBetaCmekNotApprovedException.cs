using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

/// <summary>
/// Anthropic has not approved customer-managed encryption keys for the organization,
/// project or user profile this request applies to, or has paused or withdrawn its
/// approval. If you did not expect this, contact Anthropic.
/// </summary>
public sealed class AnthropicBetaCmekNotApprovedException : AnthropicBadRequestException
{
    public AnthropicBetaCmekNotApprovedException(HttpRequestException? innerException = null)
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
    public new BetaCmekNotApprovedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaCmekNotApprovedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
