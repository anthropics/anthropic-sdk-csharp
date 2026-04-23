using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.MemoryStores;
using Anthropic.Services.Beta.MemoryStores;

namespace Anthropic.Services.Beta;

/// <inheritdoc/>
public sealed class MemoryStoreService : IMemoryStoreService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "managed-agents-2026-04-01");
    }

    readonly Lazy<IMemoryStoreServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMemoryStoreServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IMemoryStoreService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MemoryStoreService(this._client.WithOptions(modifier));
    }

    public MemoryStoreService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MemoryStoreServiceWithRawResponse(client.WithRawResponse));
        _memories = new(() => new MemoryService(client));
        _memoryVersions = new(() => new MemoryVersionService(client));
    }

    readonly Lazy<IMemoryService> _memories;
    public IMemoryService Memories
    {
        get { return _memories.Value; }
    }

    readonly Lazy<IMemoryVersionService> _memoryVersions;
    public IMemoryVersionService MemoryVersions
    {
        get { return _memoryVersions.Value; }
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsMemoryStore> Create(
        MemoryStoreCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsMemoryStore> Retrieve(
        MemoryStoreRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsMemoryStore> Retrieve(
        string memoryStoreID,
        MemoryStoreRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { MemoryStoreID = memoryStoreID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsMemoryStore> Update(
        MemoryStoreUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsMemoryStore> Update(
        string memoryStoreID,
        MemoryStoreUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { MemoryStoreID = memoryStoreID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MemoryStoreListPage> List(
        MemoryStoreListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsDeletedMemoryStore> Delete(
        MemoryStoreDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsDeletedMemoryStore> Delete(
        string memoryStoreID,
        MemoryStoreDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { MemoryStoreID = memoryStoreID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsMemoryStore> Archive(
        MemoryStoreArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsMemoryStore> Archive(
        string memoryStoreID,
        MemoryStoreArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { MemoryStoreID = memoryStoreID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MemoryStoreServiceWithRawResponse : IMemoryStoreServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMemoryStoreServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MemoryStoreServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MemoryStoreServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _memories = new(() => new MemoryServiceWithRawResponse(client));
        _memoryVersions = new(() => new MemoryVersionServiceWithRawResponse(client));
    }

    readonly Lazy<IMemoryServiceWithRawResponse> _memories;
    public IMemoryServiceWithRawResponse Memories
    {
        get { return _memories.Value; }
    }

    readonly Lazy<IMemoryVersionServiceWithRawResponse> _memoryVersions;
    public IMemoryVersionServiceWithRawResponse MemoryVersions
    {
        get { return _memoryVersions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsMemoryStore>> Create(
        MemoryStoreCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MemoryStoreCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsMemoryStore = await response
                    .Deserialize<BetaManagedAgentsMemoryStore>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsMemoryStore.Validate();
                }
                return betaManagedAgentsMemoryStore;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsMemoryStore>> Retrieve(
        MemoryStoreRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MemoryStoreID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MemoryStoreID' cannot be null");
        }

        HttpRequest<MemoryStoreRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsMemoryStore = await response
                    .Deserialize<BetaManagedAgentsMemoryStore>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsMemoryStore.Validate();
                }
                return betaManagedAgentsMemoryStore;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsMemoryStore>> Retrieve(
        string memoryStoreID,
        MemoryStoreRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { MemoryStoreID = memoryStoreID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsMemoryStore>> Update(
        MemoryStoreUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MemoryStoreID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MemoryStoreID' cannot be null");
        }

        HttpRequest<MemoryStoreUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsMemoryStore = await response
                    .Deserialize<BetaManagedAgentsMemoryStore>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsMemoryStore.Validate();
                }
                return betaManagedAgentsMemoryStore;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsMemoryStore>> Update(
        string memoryStoreID,
        MemoryStoreUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { MemoryStoreID = memoryStoreID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MemoryStoreListPage>> List(
        MemoryStoreListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MemoryStoreListParams> request = new()
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
                    .Deserialize<MemoryStoreListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new MemoryStoreListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsDeletedMemoryStore>> Delete(
        MemoryStoreDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MemoryStoreID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MemoryStoreID' cannot be null");
        }

        HttpRequest<MemoryStoreDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsDeletedMemoryStore = await response
                    .Deserialize<BetaManagedAgentsDeletedMemoryStore>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsDeletedMemoryStore.Validate();
                }
                return betaManagedAgentsDeletedMemoryStore;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsDeletedMemoryStore>> Delete(
        string memoryStoreID,
        MemoryStoreDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { MemoryStoreID = memoryStoreID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsMemoryStore>> Archive(
        MemoryStoreArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MemoryStoreID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MemoryStoreID' cannot be null");
        }

        HttpRequest<MemoryStoreArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsMemoryStore = await response
                    .Deserialize<BetaManagedAgentsMemoryStore>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsMemoryStore.Validate();
                }
                return betaManagedAgentsMemoryStore;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsMemoryStore>> Archive(
        string memoryStoreID,
        MemoryStoreArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { MemoryStoreID = memoryStoreID }, cancellationToken);
    }
}
