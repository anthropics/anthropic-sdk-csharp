using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

/// <summary>
/// The Workspace's storage and its user profile don't match: the Workspace and its
/// storage must have the same user profile, or both have none.
/// </summary>
public sealed class AnthropicStorageProfileMismatchException : AnthropicBadRequestException
{
    public AnthropicStorageProfileMismatchException(HttpRequestException? innerException = null)
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
    public new StorageProfileMismatchErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<StorageProfileMismatchErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
