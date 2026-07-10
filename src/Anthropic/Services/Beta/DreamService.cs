using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Services.Beta;

/// <inheritdoc/>
public sealed class DreamService : IDreamService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "dreaming-2026-04-21");
    }

    readonly Lazy<IDreamServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDreamServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IDreamService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DreamService(this._client.WithOptions(modifier));
    }

    public DreamService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DreamServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaDream> Create(
        DreamCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaDream> Retrieve(
        DreamRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaDream> Retrieve(
        string dreamID,
        DreamRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { DreamID = dreamID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DreamListPage> List(
        DreamListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaDream> Archive(
        DreamArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaDream> Archive(
        string dreamID,
        DreamArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { DreamID = dreamID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaDream> Cancel(
        DreamCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaDream> Cancel(
        string dreamID,
        DreamCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { DreamID = dreamID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DreamServiceWithRawResponse : IDreamServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDreamServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DreamServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DreamServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaDream>> Create(
        DreamCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DreamCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaDream = await response.Deserialize<BetaDream>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaDream.Validate();
                }
                return betaDream;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaDream>> Retrieve(
        DreamRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DreamID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.DreamID' cannot be null");
        }

        HttpRequest<DreamRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaDream = await response.Deserialize<BetaDream>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaDream.Validate();
                }
                return betaDream;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaDream>> Retrieve(
        string dreamID,
        DreamRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { DreamID = dreamID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DreamListPage>> List(
        DreamListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DreamListParams> request = new()
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
                    .Deserialize<DreamListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new DreamListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaDream>> Archive(
        DreamArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DreamID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.DreamID' cannot be null");
        }

        HttpRequest<DreamArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaDream = await response.Deserialize<BetaDream>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaDream.Validate();
                }
                return betaDream;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaDream>> Archive(
        string dreamID,
        DreamArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { DreamID = dreamID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaDream>> Cancel(
        DreamCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DreamID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.DreamID' cannot be null");
        }

        HttpRequest<DreamCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaDream = await response.Deserialize<BetaDream>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaDream.Validate();
                }
                return betaDream;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaDream>> Cancel(
        string dreamID,
        DreamCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { DreamID = dreamID }, cancellationToken);
    }
}
