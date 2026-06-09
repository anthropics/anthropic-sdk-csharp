using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Services.Beta;

/// <inheritdoc/>
public sealed class DeploymentRunService : IDeploymentRunService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "managed-agents-2026-04-01");
    }

    readonly Lazy<IDeploymentRunServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDeploymentRunServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IDeploymentRunService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DeploymentRunService(this._client.WithOptions(modifier));
    }

    public DeploymentRunService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new DeploymentRunServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsDeploymentRun> Retrieve(
        DeploymentRunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsDeploymentRun> Retrieve(
        string deploymentRunID,
        DeploymentRunRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                DeploymentRunID = deploymentRunID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<DeploymentRunListPage> List(
        DeploymentRunListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class DeploymentRunServiceWithRawResponse : IDeploymentRunServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDeploymentRunServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DeploymentRunServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DeploymentRunServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsDeploymentRun>> Retrieve(
        DeploymentRunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DeploymentRunID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.DeploymentRunID' cannot be null");
        }

        HttpRequest<DeploymentRunRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsDeploymentRun = await response
                    .Deserialize<BetaManagedAgentsDeploymentRun>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsDeploymentRun.Validate();
                }
                return betaManagedAgentsDeploymentRun;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsDeploymentRun>> Retrieve(
        string deploymentRunID,
        DeploymentRunRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                DeploymentRunID = deploymentRunID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DeploymentRunListPage>> List(
        DeploymentRunListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DeploymentRunListParams> request = new()
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
                    .Deserialize<DeploymentRunListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new DeploymentRunListPage(this, parameters, page);
            }
        );
    }
}
