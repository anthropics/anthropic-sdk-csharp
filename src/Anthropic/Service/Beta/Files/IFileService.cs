using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Models.Beta.Files;

namespace Anthropic.Service.Beta.Files;

public interface IFileService
{
    /// <summary>
    /// List Files
    /// </summary>
    Task<FileListPageResponse> List(FileListParams @params);

    /// <summary>
    /// Delete File
    /// </summary>
    Task<DeletedFile> Delete(FileDeleteParams @params);

    /// <summary>
    /// Download File
    /// </summary>
    Task<JsonElement> Download(FileDownloadParams @params);

    /// <summary>
    /// Get File Metadata
    /// </summary>
    Task<FileMetadata> RetrieveMetadata(FileRetrieveMetadataParams @params);

    /// <summary>
    /// Upload File
    /// </summary>
    Task<FileMetadata> Upload(FileUploadParams @params);
}
