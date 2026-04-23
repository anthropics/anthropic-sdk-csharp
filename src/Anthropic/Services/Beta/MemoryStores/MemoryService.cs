using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.MemoryStores.Memories;

namespace Anthropic.Services.Beta.MemoryStores;

/// <inheritdoc/>
public sealed class MemoryService : IMemoryService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "managed-agents-2026-04-01");
    }

    readonly Lazy<IMemoryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMemoryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IMemoryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MemoryService(this._client.WithOptions(modifier));
    }

    public MemoryService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MemoryServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsMemory> Create(
        MemoryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsMemory> Create(
        string memoryStoreID,
        MemoryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { MemoryStoreID = memoryStoreID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsMemory> Retrieve(
        MemoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsMemory> Retrieve(
        string memoryID,
        MemoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { MemoryID = memoryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsMemory> Update(
        MemoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsMemory> Update(
        string memoryID,
        MemoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { MemoryID = memoryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MemoryListPage> List(
        MemoryListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MemoryListPage> List(
        string memoryStoreID,
        MemoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { MemoryStoreID = memoryStoreID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsDeletedMemory> Delete(
        MemoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsDeletedMemory> Delete(
        string memoryID,
        MemoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { MemoryID = memoryID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MemoryServiceWithRawResponse : IMemoryServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMemoryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MemoryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MemoryServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsMemory>> Create(
        MemoryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MemoryStoreID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MemoryStoreID' cannot be null");
        }

        HttpRequest<MemoryCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsMemory = await response
                    .Deserialize<BetaManagedAgentsMemory>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsMemory.Validate();
                }
                return betaManagedAgentsMemory;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsMemory>> Create(
        string memoryStoreID,
        MemoryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { MemoryStoreID = memoryStoreID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsMemory>> Retrieve(
        MemoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MemoryID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MemoryID' cannot be null");
        }

        HttpRequest<MemoryRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsMemory = await response
                    .Deserialize<BetaManagedAgentsMemory>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsMemory.Validate();
                }
                return betaManagedAgentsMemory;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsMemory>> Retrieve(
        string memoryID,
        MemoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { MemoryID = memoryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsMemory>> Update(
        MemoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MemoryID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MemoryID' cannot be null");
        }

        HttpRequest<MemoryUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsMemory = await response
                    .Deserialize<BetaManagedAgentsMemory>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsMemory.Validate();
                }
                return betaManagedAgentsMemory;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsMemory>> Update(
        string memoryID,
        MemoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { MemoryID = memoryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MemoryListPage>> List(
        MemoryListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MemoryStoreID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MemoryStoreID' cannot be null");
        }

        HttpRequest<MemoryListParams> request = new()
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
                    .Deserialize<MemoryListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new MemoryListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MemoryListPage>> List(
        string memoryStoreID,
        MemoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { MemoryStoreID = memoryStoreID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsDeletedMemory>> Delete(
        MemoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MemoryID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MemoryID' cannot be null");
        }

        HttpRequest<MemoryDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsDeletedMemory = await response
                    .Deserialize<BetaManagedAgentsDeletedMemory>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsDeletedMemory.Validate();
                }
                return betaManagedAgentsDeletedMemory;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsDeletedMemory>> Delete(
        string memoryID,
        MemoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { MemoryID = memoryID }, cancellationToken);
    }
}
