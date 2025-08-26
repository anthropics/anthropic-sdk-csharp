using System.Threading.Tasks;
using Anthropic.Beta.Client.Models.Beta.Files;

namespace Anthropic.Beta.Client.Services.Beta.Files;

public interface IFileService
{
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
