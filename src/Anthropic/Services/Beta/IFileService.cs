using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Files;

namespace Anthropic.Services.Beta;

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
    /// Download File
    /// </summary>
    Task<HttpResponse> Download(
        FileDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get File Metadata
    /// </summary>
    Task<FileMetadata> RetrieveMetadata(
        FileRetrieveMetadataParams parameters,
        CancellationToken cancellationToken = default
    );
}
