using System.Net.Http;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Beta.Files;

namespace Anthropic.Client.Services.Beta.Files;

public sealed class FileService : IFileService
{
    readonly IAnthropicClient _client;

    public FileService(IAnthropicClient client)
    {
        _client = client;
    }

    public async Task<FileListPageResponse> List(FileListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<FileListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response.Deserialize<FileListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<DeletedFile> Delete(FileDeleteParams parameters)
    {
        HttpRequest<FileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deletedFile = await response.Deserialize<DeletedFile>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deletedFile.Validate();
        }
        return deletedFile;
    }

    public async Task<FileMetadata> RetrieveMetadata(FileRetrieveMetadataParams parameters)
    {
        HttpRequest<FileRetrieveMetadataParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var fileMetadata = await response.Deserialize<FileMetadata>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            fileMetadata.Validate();
        }
        return fileMetadata;
    }
}
