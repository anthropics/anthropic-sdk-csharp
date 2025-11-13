using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Beta.Files;

namespace Anthropic.Client.Services.Beta;

public sealed class FileService : IFileService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "files-api-2025-04-14");
    }

    public IFileService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FileService(this._client.WithOptions(modifier));
    }

    readonly IAnthropicClient _client;

    public FileService(IAnthropicClient client)
    {
        _client = client;
    }

    public async Task<FileListPageResponse> List(
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<FileListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<FileListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<DeletedFile> Delete(
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deletedFile = await response
            .Deserialize<DeletedFile>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deletedFile.Validate();
        }
        return deletedFile;
    }

    public async Task<FileMetadata> RetrieveMetadata(
        FileRetrieveMetadataParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FileRetrieveMetadataParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var fileMetadata = await response
            .Deserialize<FileMetadata>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            fileMetadata.Validate();
        }
        return fileMetadata;
    }
}
