using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.MemoryStores.MemoryVersions;

namespace Anthropic.Services.Beta.MemoryStores;

/// <inheritdoc/>
public sealed class MemoryVersionService : IMemoryVersionService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "managed-agents-2026-04-01");
    }

    readonly Lazy<IMemoryVersionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMemoryVersionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IMemoryVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MemoryVersionService(this._client.WithOptions(modifier));
    }

    public MemoryVersionService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new MemoryVersionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsMemoryVersion> Retrieve(
        MemoryVersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsMemoryVersion> Retrieve(
        string memoryVersionID,
        MemoryVersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(
            parameters with
            {
                MemoryVersionID = memoryVersionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<MemoryVersionListPage> List(
        MemoryVersionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MemoryVersionListPage> List(
        string memoryStoreID,
        MemoryVersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { MemoryStoreID = memoryStoreID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsMemoryVersion> Redact(
        MemoryVersionRedactParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Redact(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsMemoryVersion> Redact(
        string memoryVersionID,
        MemoryVersionRedactParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Redact(
            parameters with
            {
                MemoryVersionID = memoryVersionID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class MemoryVersionServiceWithRawResponse : IMemoryVersionServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMemoryVersionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MemoryVersionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MemoryVersionServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsMemoryVersion>> Retrieve(
        MemoryVersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MemoryVersionID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MemoryVersionID' cannot be null");
        }

        HttpRequest<MemoryVersionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsMemoryVersion = await response
                    .Deserialize<BetaManagedAgentsMemoryVersion>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsMemoryVersion.Validate();
                }
                return betaManagedAgentsMemoryVersion;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsMemoryVersion>> Retrieve(
        string memoryVersionID,
        MemoryVersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(
            parameters with
            {
                MemoryVersionID = memoryVersionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MemoryVersionListPage>> List(
        MemoryVersionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MemoryStoreID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MemoryStoreID' cannot be null");
        }

        HttpRequest<MemoryVersionListParams> request = new()
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
                    .Deserialize<MemoryVersionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new MemoryVersionListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MemoryVersionListPage>> List(
        string memoryStoreID,
        MemoryVersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { MemoryStoreID = memoryStoreID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsMemoryVersion>> Redact(
        MemoryVersionRedactParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MemoryVersionID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MemoryVersionID' cannot be null");
        }

        HttpRequest<MemoryVersionRedactParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsMemoryVersion = await response
                    .Deserialize<BetaManagedAgentsMemoryVersion>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsMemoryVersion.Validate();
                }
                return betaManagedAgentsMemoryVersion;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsMemoryVersion>> Redact(
        string memoryVersionID,
        MemoryVersionRedactParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Redact(
            parameters with
            {
                MemoryVersionID = memoryVersionID,
            },
            cancellationToken
        );
    }
}
