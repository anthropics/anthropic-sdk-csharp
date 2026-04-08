using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Resources;

namespace Anthropic.Services.Beta.Sessions;

/// <inheritdoc/>
public sealed class ResourceService : IResourceService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "managed-agents-2026-04-01");
    }

    readonly Lazy<IResourceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IResourceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IResourceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ResourceService(this._client.WithOptions(modifier));
    }

    public ResourceService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ResourceServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ResourceRetrieveResponse> Retrieve(
        ResourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ResourceRetrieveResponse> Retrieve(
        string resourceID,
        ResourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { ResourceID = resourceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ResourceUpdateResponse> Update(
        ResourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ResourceUpdateResponse> Update(
        string resourceID,
        ResourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ResourceID = resourceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ResourceListPage> List(
        ResourceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ResourceListPage> List(
        string sessionID,
        ResourceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsDeleteSessionResource> Delete(
        ResourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsDeleteSessionResource> Delete(
        string resourceID,
        ResourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { ResourceID = resourceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsFileResource> Add(
        ResourceAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Add(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsFileResource> Add(
        string sessionID,
        ResourceAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { SessionID = sessionID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ResourceServiceWithRawResponse : IResourceServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IResourceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ResourceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ResourceServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ResourceRetrieveResponse>> Retrieve(
        ResourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ResourceID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ResourceID' cannot be null");
        }

        HttpRequest<ResourceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var resource = await response
                    .Deserialize<ResourceRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    resource.Validate();
                }
                return resource;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ResourceRetrieveResponse>> Retrieve(
        string resourceID,
        ResourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { ResourceID = resourceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ResourceUpdateResponse>> Update(
        ResourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ResourceID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ResourceID' cannot be null");
        }

        HttpRequest<ResourceUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var resource = await response
                    .Deserialize<ResourceUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    resource.Validate();
                }
                return resource;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ResourceUpdateResponse>> Update(
        string resourceID,
        ResourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ResourceID = resourceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ResourceListPage>> List(
        ResourceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<ResourceListParams> request = new()
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
                    .Deserialize<ResourceListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ResourceListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ResourceListPage>> List(
        string sessionID,
        ResourceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsDeleteSessionResource>> Delete(
        ResourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ResourceID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ResourceID' cannot be null");
        }

        HttpRequest<ResourceDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsDeleteSessionResource = await response
                    .Deserialize<BetaManagedAgentsDeleteSessionResource>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsDeleteSessionResource.Validate();
                }
                return betaManagedAgentsDeleteSessionResource;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsDeleteSessionResource>> Delete(
        string resourceID,
        ResourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { ResourceID = resourceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsFileResource>> Add(
        ResourceAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<ResourceAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsFileResource = await response
                    .Deserialize<BetaManagedAgentsFileResource>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsFileResource.Validate();
                }
                return betaManagedAgentsFileResource;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsFileResource>> Add(
        string sessionID,
        ResourceAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { SessionID = sessionID }, cancellationToken);
    }
}
