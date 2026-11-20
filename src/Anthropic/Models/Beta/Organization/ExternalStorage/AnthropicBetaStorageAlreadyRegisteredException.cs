using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// The organization already has External Storage for this bucket that it has not
/// deleted. List the organization's External Storage to find it.
/// </summary>
public sealed class AnthropicBetaStorageAlreadyRegisteredException : AnthropicConflictException
{
    public AnthropicBetaStorageAlreadyRegisteredException(
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
    public new BetaStorageAlreadyRegisteredErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaStorageAlreadyRegisteredErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
