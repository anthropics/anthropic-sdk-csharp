using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

/// <summary>
/// The request breaks the organization's Workspace Policy. The message says which
/// rule it broke; an organization admin can see and change the policy in the Console.
/// </summary>
public sealed class AnthropicWorkspacePolicyViolationException : AnthropicBadRequestException
{
    public AnthropicWorkspacePolicyViolationException(HttpRequestException? innerException = null)
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
    public new WorkspacePolicyViolationErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<WorkspacePolicyViolationErrorDetails>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                    ?? default,
                "details"
            );
        }
    }
}
