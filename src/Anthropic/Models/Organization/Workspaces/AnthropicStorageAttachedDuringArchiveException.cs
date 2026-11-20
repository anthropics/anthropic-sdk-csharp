using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

/// <summary>
/// The Workspace was archived, but External Storage was attached to it during the
/// archive and is still attached. To detach it, archive the Workspace again as a
/// caller with the `org:external-storage:use` permission.
/// </summary>
public sealed class AnthropicStorageAttachedDuringArchiveException : AnthropicConflictException
{
    public AnthropicStorageAttachedDuringArchiveException(
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
    public new StorageAttachedDuringArchiveErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<StorageAttachedDuringArchiveErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
