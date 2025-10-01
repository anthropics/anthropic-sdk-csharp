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
        return await response.Deserialize<FileListPageResponse>().ConfigureAwait(false);
    }

    public async Task<DeletedFile> Delete(FileDeleteParams parameters)
    {
        HttpRequest<FileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<DeletedFile>().ConfigureAwait(false);
    }

    public async Task<FileMetadata> RetrieveMetadata(FileRetrieveMetadataParams parameters)
    {
        HttpRequest<FileRetrieveMetadataParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<FileMetadata>().ConfigureAwait(false);
    }
}
