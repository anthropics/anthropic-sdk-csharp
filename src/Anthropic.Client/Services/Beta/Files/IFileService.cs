using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Files = Anthropic.Client.Models.Beta.Files;

namespace Anthropic.Client.Services.Beta.Files;

public interface IFileService
{
    IFileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List Files
    /// </summary>
    Task<Files::FileListPageResponse> List(
        Files::FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete File
    /// </summary>
    Task<Files::DeletedFile> Delete(
        Files::FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get File Metadata
    /// </summary>
    Task<Files::FileMetadata> RetrieveMetadata(
        Files::FileRetrieveMetadataParams parameters,
        CancellationToken cancellationToken = default
    );
}
