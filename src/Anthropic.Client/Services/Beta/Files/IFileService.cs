using System;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Beta.Files;

namespace Anthropic.Client.Services.Beta.Files;

public interface IFileService
{
    IFileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List Files
    /// </summary>
    Task<FileListPageResponse> List(FileListParams? parameters = null);

    /// <summary>
    /// Delete File
    /// </summary>
    Task<DeletedFile> Delete(FileDeleteParams parameters);

    /// <summary>
    /// Get File Metadata
    /// </summary>
    Task<FileMetadata> RetrieveMetadata(FileRetrieveMetadataParams parameters);
}
