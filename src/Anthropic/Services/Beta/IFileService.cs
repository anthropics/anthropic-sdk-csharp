using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Files;

namespace Anthropic.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFileService
{
    IFileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List Files
    /// </summary>
    Task<FileListPageResponse> List(
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete File
    /// </summary>
    Task<DeletedFile> Delete(
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete File
    /// </summary>
    Task<DeletedFile> Delete(
        string fileID,
        FileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Download File
    /// </summary>
    Task<HttpResponse> Download(
        FileDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Download File
    /// </summary>
    Task<HttpResponse> Download(
        string fileID,
        FileDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get File Metadata
    /// </summary>
    Task<FileMetadata> RetrieveMetadata(
        FileRetrieveMetadataParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get File Metadata
    /// </summary>
    Task<FileMetadata> RetrieveMetadata(
        string fileID,
        FileRetrieveMetadataParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
