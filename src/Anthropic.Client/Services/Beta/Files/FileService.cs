using System;
using System.Net.Http;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Files = Anthropic.Client.Models.Beta.Files;

namespace Anthropic.Client.Services.Beta.Files;

public sealed class FileService : IFileService
{
    public IFileService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FileService(this._client.WithOptions(modifier));
    }

    readonly IAnthropicClient _client;

    public FileService(IAnthropicClient client)
    {
        _client = client;
    }

    public async Task<Files::FileListPageResponse> List(Files::FileListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<Files::FileListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response.Deserialize<Files::FileListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<Files::DeletedFile> Delete(Files::FileDeleteParams parameters)
    {
        HttpRequest<Files::FileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deletedFile = await response.Deserialize<Files::DeletedFile>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deletedFile.Validate();
        }
        return deletedFile;
    }

    public async Task<Files::FileMetadata> RetrieveMetadata(
        Files::FileRetrieveMetadataParams parameters
    )
    {
        HttpRequest<Files::FileRetrieveMetadataParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var fileMetadata = await response.Deserialize<Files::FileMetadata>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            fileMetadata.Validate();
        }
        return fileMetadata;
    }
}
