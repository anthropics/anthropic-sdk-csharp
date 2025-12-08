using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Files;

namespace Anthropic.Services.Beta;

/// <inheritdoc/>
public sealed class FileService : IFileService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "files-api-2025-04-14");
    }

    /// <inheritdoc/>
    public IFileService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FileService(this._client.WithOptions(modifier));
    }

    readonly IAnthropicClient _client;

    public FileService(IAnthropicClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public async Task<DeletedFile> Delete(
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.FileID' cannot be null");
        }

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

    /// <inheritdoc/>
    public async Task<DeletedFile> Delete(
        string fileID,
        FileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Delete(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Download(
        FileDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.FileID' cannot be null");
        }

        HttpRequest<FileDownloadParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return response;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Download(
        string fileID,
        FileDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Download(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FileMetadata> RetrieveMetadata(
        FileRetrieveMetadataParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.FileID' cannot be null");
        }

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

    /// <inheritdoc/>
    public async Task<FileMetadata> RetrieveMetadata(
        string fileID,
        FileRetrieveMetadataParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.RetrieveMetadata(parameters with { FileID = fileID }, cancellationToken);
    }
}
