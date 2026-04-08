using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Environments;

namespace Anthropic.Services.Beta;

/// <inheritdoc/>
public sealed class EnvironmentService : IEnvironmentService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "managed-agents-2026-04-01");
    }

    readonly Lazy<IEnvironmentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEnvironmentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IEnvironmentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EnvironmentService(this._client.WithOptions(modifier));
    }

    public EnvironmentService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EnvironmentServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaEnvironment> Create(
        EnvironmentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaEnvironment> Retrieve(
        EnvironmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaEnvironment> Retrieve(
        string environmentID,
        EnvironmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { EnvironmentID = environmentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaEnvironment> Update(
        EnvironmentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaEnvironment> Update(
        string environmentID,
        EnvironmentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { EnvironmentID = environmentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EnvironmentListPage> List(
        EnvironmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaEnvironmentDeleteResponse> Delete(
        EnvironmentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaEnvironmentDeleteResponse> Delete(
        string environmentID,
        EnvironmentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { EnvironmentID = environmentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaEnvironment> Archive(
        EnvironmentArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaEnvironment> Archive(
        string environmentID,
        EnvironmentArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { EnvironmentID = environmentID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class EnvironmentServiceWithRawResponse : IEnvironmentServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEnvironmentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EnvironmentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EnvironmentServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaEnvironment>> Create(
        EnvironmentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EnvironmentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaEnvironment = await response
                    .Deserialize<BetaEnvironment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaEnvironment.Validate();
                }
                return betaEnvironment;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaEnvironment>> Retrieve(
        EnvironmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnvironmentID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.EnvironmentID' cannot be null");
        }

        HttpRequest<EnvironmentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaEnvironment = await response
                    .Deserialize<BetaEnvironment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaEnvironment.Validate();
                }
                return betaEnvironment;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaEnvironment>> Retrieve(
        string environmentID,
        EnvironmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { EnvironmentID = environmentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaEnvironment>> Update(
        EnvironmentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnvironmentID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.EnvironmentID' cannot be null");
        }

        HttpRequest<EnvironmentUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaEnvironment = await response
                    .Deserialize<BetaEnvironment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaEnvironment.Validate();
                }
                return betaEnvironment;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaEnvironment>> Update(
        string environmentID,
        EnvironmentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { EnvironmentID = environmentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EnvironmentListPage>> List(
        EnvironmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EnvironmentListParams> request = new()
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
                    .Deserialize<EnvironmentListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new EnvironmentListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaEnvironmentDeleteResponse>> Delete(
        EnvironmentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnvironmentID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.EnvironmentID' cannot be null");
        }

        HttpRequest<EnvironmentDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaEnvironmentDeleteResponse = await response
                    .Deserialize<BetaEnvironmentDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaEnvironmentDeleteResponse.Validate();
                }
                return betaEnvironmentDeleteResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaEnvironmentDeleteResponse>> Delete(
        string environmentID,
        EnvironmentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { EnvironmentID = environmentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaEnvironment>> Archive(
        EnvironmentArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnvironmentID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.EnvironmentID' cannot be null");
        }

        HttpRequest<EnvironmentArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaEnvironment = await response
                    .Deserialize<BetaEnvironment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaEnvironment.Validate();
                }
                return betaEnvironment;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaEnvironment>> Archive(
        string environmentID,
        EnvironmentArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { EnvironmentID = environmentID }, cancellationToken);
    }
}
