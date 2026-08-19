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

    readonly Lazy<IFileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFileServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    internal readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IFileService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FileService(this._client.WithOptions(modifier));
    }

    public FileService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FileServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<FileListPage> List(
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaDeletedFile> Delete(
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaDeletedFile> Delete(
        string fileID,
        FileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        FileDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Download(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        string fileID,
        FileDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Download(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaFileMetadata> RetrieveMetadata(
        FileRetrieveMetadataParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveMetadata(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaFileMetadata> RetrieveMetadata(
        string fileID,
        FileRetrieveMetadataParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMetadata(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaFileMetadata> Upload(
        FileUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Upload(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class FileServiceWithRawResponse : IFileServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FileServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<FileListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new FileListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaDeletedFile>> Delete(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaDeletedFile = await response
                    .Deserialize<BetaDeletedFile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaDeletedFile.Validate();
                }
                return betaDeletedFile;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaDeletedFile>> Delete(
        string fileID,
        FileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        string fileID,
        FileDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Download(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaFileMetadata>> RetrieveMetadata(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaFileMetadata = await response
                    .Deserialize<BetaFileMetadata>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaFileMetadata.Validate();
                }
                return betaFileMetadata;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaFileMetadata>> RetrieveMetadata(
        string fileID,
        FileRetrieveMetadataParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMetadata(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaFileMetadata>> Upload(
        FileUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FileUploadParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaFileMetadata = await response
                    .Deserialize<BetaFileMetadata>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaFileMetadata.Validate();
                }
                return betaFileMetadata;
            }
        );
    }
}
