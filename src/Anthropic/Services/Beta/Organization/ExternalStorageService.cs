using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ExternalStorage;

namespace Anthropic.Services.Beta.Organization;

/// <inheritdoc/>
public sealed class ExternalStorageService : IExternalStorageService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "efs-2026-10-01");
    }

    readonly Lazy<IExternalStorageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExternalStorageServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IExternalStorageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExternalStorageService(this._client.WithOptions(modifier));
    }

    public ExternalStorageService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ExternalStorageServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<BetaExternalStorage> Create(
        ExternalStorageCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaExternalStorage> Retrieve(
        ExternalStorageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaExternalStorage> Retrieve(
        string externalStorageID,
        ExternalStorageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                ExternalStorageID = externalStorageID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<BetaExternalStorage> Update(
        ExternalStorageUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaExternalStorage> Update(
        string externalStorageID,
        ExternalStorageUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(
            parameters with
            {
                ExternalStorageID = externalStorageID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<ExternalStorageListPage> List(
        ExternalStorageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaDeletedExternalStorage> Delete(
        ExternalStorageDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaDeletedExternalStorage> Delete(
        string externalStorageID,
        ExternalStorageDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(
            parameters with
            {
                ExternalStorageID = externalStorageID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<BetaExternalStorage> Activate(
        ExternalStorageActivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Activate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaExternalStorage> Activate(
        string externalStorageID,
        ExternalStorageActivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Activate(
            parameters with
            {
                ExternalStorageID = externalStorageID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class ExternalStorageServiceWithRawResponse : IExternalStorageServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExternalStorageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExternalStorageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExternalStorageServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaExternalStorage>> Create(
        ExternalStorageCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExternalStorageCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.external_storage.create",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaExternalStorage = await response
                    .Deserialize<BetaExternalStorage>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaExternalStorage.Validate();
                }
                Tracing.SetCreatedId(
                    response.Span,
                    "anthropic.organization.external_storage.id",
                    betaExternalStorage,
                    static created => created.ID
                );
                return betaExternalStorage;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaExternalStorage>> Retrieve(
        ExternalStorageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalStorageID == null)
        {
            throw new AnthropicInvalidDataException(
                "'parameters.ExternalStorageID' cannot be null"
            );
        }

        HttpRequest<ExternalStorageRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.external_storage.retrieve",
            SpanResourceIds =
            [
                new("anthropic.organization.external_storage.id", parameters.ExternalStorageID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaExternalStorage = await response
                    .Deserialize<BetaExternalStorage>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaExternalStorage.Validate();
                }
                return betaExternalStorage;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaExternalStorage>> Retrieve(
        string externalStorageID,
        ExternalStorageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                ExternalStorageID = externalStorageID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaExternalStorage>> Update(
        ExternalStorageUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalStorageID == null)
        {
            throw new AnthropicInvalidDataException(
                "'parameters.ExternalStorageID' cannot be null"
            );
        }

        HttpRequest<ExternalStorageUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.external_storage.update",
            SpanResourceIds =
            [
                new("anthropic.organization.external_storage.id", parameters.ExternalStorageID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaExternalStorage = await response
                    .Deserialize<BetaExternalStorage>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaExternalStorage.Validate();
                }
                return betaExternalStorage;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaExternalStorage>> Update(
        string externalStorageID,
        ExternalStorageUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(
            parameters with
            {
                ExternalStorageID = externalStorageID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalStorageListPage>> List(
        ExternalStorageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExternalStorageListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.external_storage.list",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<ExternalStorageListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ExternalStorageListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaDeletedExternalStorage>> Delete(
        ExternalStorageDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalStorageID == null)
        {
            throw new AnthropicInvalidDataException(
                "'parameters.ExternalStorageID' cannot be null"
            );
        }

        HttpRequest<ExternalStorageDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.external_storage.delete",
            SpanResourceIds =
            [
                new("anthropic.organization.external_storage.id", parameters.ExternalStorageID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaDeletedExternalStorage = await response
                    .Deserialize<BetaDeletedExternalStorage>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaDeletedExternalStorage.Validate();
                }
                return betaDeletedExternalStorage;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaDeletedExternalStorage>> Delete(
        string externalStorageID,
        ExternalStorageDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(
            parameters with
            {
                ExternalStorageID = externalStorageID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaExternalStorage>> Activate(
        ExternalStorageActivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalStorageID == null)
        {
            throw new AnthropicInvalidDataException(
                "'parameters.ExternalStorageID' cannot be null"
            );
        }

        HttpRequest<ExternalStorageActivateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.external_storage.activate",
            SpanResourceIds =
            [
                new("anthropic.organization.external_storage.id", parameters.ExternalStorageID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaExternalStorage = await response
                    .Deserialize<BetaExternalStorage>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaExternalStorage.Validate();
                }
                return betaExternalStorage;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaExternalStorage>> Activate(
        string externalStorageID,
        ExternalStorageActivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Activate(
            parameters with
            {
                ExternalStorageID = externalStorageID,
            },
            cancellationToken
        );
    }
}
