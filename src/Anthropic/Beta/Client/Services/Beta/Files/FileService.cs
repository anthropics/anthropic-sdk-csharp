using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Beta.Client.Models.Beta.Files;

namespace Anthropic.Beta.Client.Services.Beta.Files;

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

        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<FileListPageResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<DeletedFile> Delete(FileDeleteParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Delete, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<DeletedFile>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<FileMetadata> RetrieveMetadata(FileRetrieveMetadataParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<FileMetadata>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
