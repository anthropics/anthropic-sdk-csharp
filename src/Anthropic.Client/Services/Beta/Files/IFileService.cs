using System;
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
    Task<Files::FileListPageResponse> List(Files::FileListParams? parameters = null);

    /// <summary>
    /// Delete File
    /// </summary>
    Task<Files::DeletedFile> Delete(Files::FileDeleteParams parameters);

    /// <summary>
    /// Get File Metadata
    /// </summary>
    Task<Files::FileMetadata> RetrieveMetadata(Files::FileRetrieveMetadataParams parameters);
}
