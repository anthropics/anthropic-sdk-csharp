using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// Anthropic has not approved External Storage for the organization, for the Workspace
/// or, for storage bound to a user profile, for that user profile. Contact your
/// Anthropic account team.
/// </summary>
public sealed class AnthropicBetaGrantRequiredException : AnthropicBadRequestException
{
    public AnthropicBetaGrantRequiredException(HttpRequestException? innerException = null)
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
    public new BetaGrantRequiredErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaGrantRequiredErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
