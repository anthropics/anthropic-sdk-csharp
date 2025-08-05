using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Models.Beta.Files;

namespace Anthropic.Services.Beta.Files;

public interface IFileService
{
    /// <summary>
    /// List Files
    /// </summary>
    Task<FileListPageResponse> List(FileListParams parameters);

    /// <summary>
    /// Delete File
    /// </summary>
    Task<DeletedFile> Delete(FileDeleteParams parameters);

    /// <summary>
    /// Download File
    /// </summary>
    Task<JsonElement> Download(FileDownloadParams parameters);

    /// <summary>
    /// Get File Metadata
    /// </summary>
    Task<FileMetadata> RetrieveMetadata(FileRetrieveMetadataParams parameters);

    /// <summary>
    /// Upload File
    /// </summary>
    Task<FileMetadata> Upload(FileUploadParams parameters);
}
