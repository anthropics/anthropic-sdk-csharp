using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Tunnels.Certificates;

namespace Anthropic.Services.Beta.Tunnels;

/// <inheritdoc/>
public sealed class CertificateService : ICertificateService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "mcp-tunnels-2026-06-22");
    }

    readonly Lazy<ICertificateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICertificateServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public ICertificateService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CertificateService(this._client.WithOptions(modifier));
    }

    public CertificateService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CertificateServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaTunnelCertificate> Create(
        CertificateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaTunnelCertificate> Create(
        string tunnelID,
        CertificateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { TunnelID = tunnelID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaTunnelCertificate> Retrieve(
        CertificateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaTunnelCertificate> Retrieve(
        string certificateID,
        CertificateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { CertificateID = certificateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CertificateListPage> List(
        CertificateListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CertificateListPage> List(
        string tunnelID,
        CertificateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { TunnelID = tunnelID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaTunnelCertificate> Archive(
        CertificateArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaTunnelCertificate> Archive(
        string certificateID,
        CertificateArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Archive(parameters with { CertificateID = certificateID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CertificateServiceWithRawResponse : ICertificateServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICertificateServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CertificateServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CertificateServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaTunnelCertificate>> Create(
        CertificateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TunnelID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.TunnelID' cannot be null");
        }

        HttpRequest<CertificateCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaTunnelCertificate = await response
                    .Deserialize<BetaTunnelCertificate>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaTunnelCertificate.Validate();
                }
                return betaTunnelCertificate;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaTunnelCertificate>> Create(
        string tunnelID,
        CertificateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { TunnelID = tunnelID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaTunnelCertificate>> Retrieve(
        CertificateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CertificateID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.CertificateID' cannot be null");
        }

        HttpRequest<CertificateRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaTunnelCertificate = await response
                    .Deserialize<BetaTunnelCertificate>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaTunnelCertificate.Validate();
                }
                return betaTunnelCertificate;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaTunnelCertificate>> Retrieve(
        string certificateID,
        CertificateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { CertificateID = certificateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CertificateListPage>> List(
        CertificateListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TunnelID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.TunnelID' cannot be null");
        }

        HttpRequest<CertificateListParams> request = new()
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
                    .Deserialize<CertificateListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CertificateListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CertificateListPage>> List(
        string tunnelID,
        CertificateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { TunnelID = tunnelID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaTunnelCertificate>> Archive(
        CertificateArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CertificateID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.CertificateID' cannot be null");
        }

        HttpRequest<CertificateArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaTunnelCertificate = await response
                    .Deserialize<BetaTunnelCertificate>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaTunnelCertificate.Validate();
                }
                return betaTunnelCertificate;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaTunnelCertificate>> Archive(
        string certificateID,
        CertificateArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Archive(parameters with { CertificateID = certificateID }, cancellationToken);
    }
}
