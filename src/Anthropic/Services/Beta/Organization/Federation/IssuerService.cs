using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Federation.Issuers;

namespace Anthropic.Services.Beta.Organization.Federation;

/// <inheritdoc/>
public sealed class IssuerService : IIssuerService
{
    readonly Lazy<IIssuerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IIssuerServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IIssuerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IssuerService(this._client.WithOptions(modifier));
    }

    public IssuerService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new IssuerServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaFederationIssuer> Create(
        IssuerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaFederationIssuer> Retrieve(
        IssuerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaFederationIssuer> Retrieve(
        string federationIssuerID,
        IssuerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                FederationIssuerID = federationIssuerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<BetaFederationIssuer> Update(
        IssuerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaFederationIssuer> Update(
        string federationIssuerID,
        IssuerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                FederationIssuerID = federationIssuerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<IssuerListPage> List(
        IssuerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaFederationIssuer> Archive(
        IssuerArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaFederationIssuer> Archive(
        string federationIssuerID,
        IssuerArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(
            parameters with
            {
                FederationIssuerID = federationIssuerID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class IssuerServiceWithRawResponse : IIssuerServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IIssuerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IssuerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public IssuerServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaFederationIssuer>> Create(
        IssuerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IssuerCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaFederationIssuer = await response
                    .Deserialize<BetaFederationIssuer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaFederationIssuer.Validate();
                }
                return betaFederationIssuer;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaFederationIssuer>> Retrieve(
        IssuerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FederationIssuerID == null)
        {
            throw new AnthropicInvalidDataException(
                "'parameters.FederationIssuerID' cannot be null"
            );
        }

        HttpRequest<IssuerRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaFederationIssuer = await response
                    .Deserialize<BetaFederationIssuer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaFederationIssuer.Validate();
                }
                return betaFederationIssuer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaFederationIssuer>> Retrieve(
        string federationIssuerID,
        IssuerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                FederationIssuerID = federationIssuerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaFederationIssuer>> Update(
        IssuerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FederationIssuerID == null)
        {
            throw new AnthropicInvalidDataException(
                "'parameters.FederationIssuerID' cannot be null"
            );
        }

        HttpRequest<IssuerUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaFederationIssuer = await response
                    .Deserialize<BetaFederationIssuer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaFederationIssuer.Validate();
                }
                return betaFederationIssuer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaFederationIssuer>> Update(
        string federationIssuerID,
        IssuerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                FederationIssuerID = federationIssuerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IssuerListPage>> List(
        IssuerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<IssuerListParams> request = new()
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
                    .Deserialize<IssuerListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new IssuerListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaFederationIssuer>> Archive(
        IssuerArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FederationIssuerID == null)
        {
            throw new AnthropicInvalidDataException(
                "'parameters.FederationIssuerID' cannot be null"
            );
        }

        HttpRequest<IssuerArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaFederationIssuer = await response
                    .Deserialize<BetaFederationIssuer>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaFederationIssuer.Validate();
                }
                return betaFederationIssuer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaFederationIssuer>> Archive(
        string federationIssuerID,
        IssuerArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(
            parameters with
            {
                FederationIssuerID = federationIssuerID,
            },
            cancellationToken
        );
    }
}
