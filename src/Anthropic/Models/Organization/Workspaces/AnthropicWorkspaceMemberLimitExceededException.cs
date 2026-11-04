using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

/// <summary>
/// The workspace has reached the member limit that Anthropic set for it.
/// </summary>
public sealed class AnthropicWorkspaceMemberLimitExceededException : AnthropicBadRequestException
{
    public AnthropicWorkspaceMemberLimitExceededException(
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
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(
                    WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                        ?? default,
                    "details"
                ) ?? default,
                "error_code"
            );
        }
    }

    /// <summary>
    /// <c>error.details</c> of <see cref="AnthropicServiceException.Body"/>.
    /// </summary>
    public new WorkspaceMemberLimitExceededErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<WorkspaceMemberLimitExceededErrorDetails>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                    ?? default,
                "details"
            );
        }
    }
}
