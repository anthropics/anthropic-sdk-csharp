using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Tunnels;
using Anthropic.Services.Beta.Tunnels;

namespace Anthropic.Services.Beta;

/// <inheritdoc/>
public sealed class TunnelService : ITunnelService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "mcp-tunnels-2026-06-22");
    }

    readonly Lazy<ITunnelServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITunnelServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public ITunnelService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TunnelService(this._client.WithOptions(modifier));
    }

    public TunnelService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TunnelServiceWithRawResponse(client.WithRawResponse));
        _certificates = new(() => new CertificateService(client));
    }

    readonly Lazy<ICertificateService> _certificates;
    public ICertificateService Certificates
    {
        get { return _certificates.Value; }
    }

    /// <inheritdoc/>
    public async Task<BetaTunnel> Create(
        TunnelCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaTunnel> Retrieve(
        TunnelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaTunnel> Retrieve(
        string tunnelID,
        TunnelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TunnelID = tunnelID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TunnelListPage> List(
        TunnelListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaTunnel> Archive(
        TunnelArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaTunnel> Archive(
        string tunnelID,
        TunnelArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { TunnelID = tunnelID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaTunnelToken> RevealToken(
        TunnelRevealTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RevealToken(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaTunnelToken> RevealToken(
        string tunnelID,
        TunnelRevealTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RevealToken(parameters with { TunnelID = tunnelID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaTunnelToken> RotateToken(
        TunnelRotateTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RotateToken(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaTunnelToken> RotateToken(
        string tunnelID,
        TunnelRotateTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RotateToken(parameters with { TunnelID = tunnelID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TunnelServiceWithRawResponse : ITunnelServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITunnelServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TunnelServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TunnelServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _certificates = new(() => new CertificateServiceWithRawResponse(client));
    }

    readonly Lazy<ICertificateServiceWithRawResponse> _certificates;
    public ICertificateServiceWithRawResponse Certificates
    {
        get { return _certificates.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaTunnel>> Create(
        TunnelCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TunnelCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaTunnel = await response
                    .Deserialize<BetaTunnel>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaTunnel.Validate();
                }
                return betaTunnel;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaTunnel>> Retrieve(
        TunnelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TunnelID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.TunnelID' cannot be null");
        }

        HttpRequest<TunnelRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaTunnel = await response
                    .Deserialize<BetaTunnel>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaTunnel.Validate();
                }
                return betaTunnel;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaTunnel>> Retrieve(
        string tunnelID,
        TunnelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TunnelID = tunnelID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TunnelListPage>> List(
        TunnelListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TunnelListParams> request = new()
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
                    .Deserialize<TunnelListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TunnelListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaTunnel>> Archive(
        TunnelArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TunnelID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.TunnelID' cannot be null");
        }

        HttpRequest<TunnelArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaTunnel = await response
                    .Deserialize<BetaTunnel>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaTunnel.Validate();
                }
                return betaTunnel;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaTunnel>> Archive(
        string tunnelID,
        TunnelArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { TunnelID = tunnelID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaTunnelToken>> RevealToken(
        TunnelRevealTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TunnelID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.TunnelID' cannot be null");
        }

        HttpRequest<TunnelRevealTokenParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaTunnelToken = await response
                    .Deserialize<BetaTunnelToken>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaTunnelToken.Validate();
                }
                return betaTunnelToken;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaTunnelToken>> RevealToken(
        string tunnelID,
        TunnelRevealTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RevealToken(parameters with { TunnelID = tunnelID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaTunnelToken>> RotateToken(
        TunnelRotateTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TunnelID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.TunnelID' cannot be null");
        }

        HttpRequest<TunnelRotateTokenParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaTunnelToken = await response
                    .Deserialize<BetaTunnelToken>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaTunnelToken.Validate();
                }
                return betaTunnelToken;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaTunnelToken>> RotateToken(
        string tunnelID,
        TunnelRotateTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RotateToken(parameters with { TunnelID = tunnelID }, cancellationToken);
    }
}
