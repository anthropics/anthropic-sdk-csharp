using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

/// <summary>
/// Another organization has data controls turned on for this Google Cloud project,
/// or turned them off recently. The message says how long to wait.
/// </summary>
public sealed class AnthropicBetaGcpProjectControlledByAnotherOrganizationException
    : AnthropicConflictException
{
    public AnthropicBetaGcpProjectControlledByAnotherOrganizationException(
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
    public new BetaGcpProjectControlledByAnotherOrganizationErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaGcpProjectControlledByAnotherOrganizationErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
