using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.PluginMarketplaces;

namespace Anthropic.Services.Beta.Organization;

/// <inheritdoc/>
public sealed class PluginMarketplaceService : IPluginMarketplaceService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "ce-plugins-2026-09-01");
    }

    readonly Lazy<IPluginMarketplaceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPluginMarketplaceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IPluginMarketplaceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PluginMarketplaceService(this._client.WithOptions(modifier));
    }

    public PluginMarketplaceService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new PluginMarketplaceServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<BetaPluginMarketplace> Retrieve(
        PluginMarketplaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaPluginMarketplace> Retrieve(
        string marketplaceID,
        PluginMarketplaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { MarketplaceID = marketplaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaPluginMarketplace> Update(
        PluginMarketplaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaPluginMarketplace> Update(
        string marketplaceID,
        PluginMarketplaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { MarketplaceID = marketplaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PluginMarketplaceListPage> List(
        PluginMarketplaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaPluginMarketplaceValidationReport> ValidateArchive(
        PluginMarketplaceValidateArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ValidateArchive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaPluginMarketplaceValidationReport> ValidateRepository(
        PluginMarketplaceValidateRepositoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ValidateRepository(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PluginMarketplaceServiceWithRawResponse
    : IPluginMarketplaceServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPluginMarketplaceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PluginMarketplaceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PluginMarketplaceServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaPluginMarketplace>> Retrieve(
        PluginMarketplaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MarketplaceID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MarketplaceID' cannot be null");
        }

        HttpRequest<PluginMarketplaceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaPluginMarketplace = await response
                    .Deserialize<BetaPluginMarketplace>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaPluginMarketplace.Validate();
                }
                return betaPluginMarketplace;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaPluginMarketplace>> Retrieve(
        string marketplaceID,
        PluginMarketplaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { MarketplaceID = marketplaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaPluginMarketplace>> Update(
        PluginMarketplaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MarketplaceID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.MarketplaceID' cannot be null");
        }

        HttpRequest<PluginMarketplaceUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaPluginMarketplace = await response
                    .Deserialize<BetaPluginMarketplace>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaPluginMarketplace.Validate();
                }
                return betaPluginMarketplace;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaPluginMarketplace>> Update(
        string marketplaceID,
        PluginMarketplaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { MarketplaceID = marketplaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PluginMarketplaceListPage>> List(
        PluginMarketplaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PluginMarketplaceListParams> request = new()
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
                    .Deserialize<PluginMarketplaceListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new PluginMarketplaceListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaPluginMarketplaceValidationReport>> ValidateArchive(
        PluginMarketplaceValidateArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PluginMarketplaceValidateArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaPluginMarketplaceValidationReport = await response
                    .Deserialize<BetaPluginMarketplaceValidationReport>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaPluginMarketplaceValidationReport.Validate();
                }
                return betaPluginMarketplaceValidationReport;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaPluginMarketplaceValidationReport>> ValidateRepository(
        PluginMarketplaceValidateRepositoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PluginMarketplaceValidateRepositoryParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaPluginMarketplaceValidationReport = await response
                    .Deserialize<BetaPluginMarketplaceValidationReport>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaPluginMarketplaceValidationReport.Validate();
                }
                return betaPluginMarketplaceValidationReport;
            }
        );
    }
}
