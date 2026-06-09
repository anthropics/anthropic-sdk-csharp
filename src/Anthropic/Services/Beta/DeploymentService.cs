using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Services.Beta;

/// <inheritdoc/>
public sealed class DeploymentService : IDeploymentService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "managed-agents-2026-04-01");
    }

    readonly Lazy<IDeploymentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDeploymentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IDeploymentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DeploymentService(this._client.WithOptions(modifier));
    }

    public DeploymentService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DeploymentServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsDeployment> Create(
        DeploymentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsDeployment> Retrieve(
        DeploymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsDeployment> Retrieve(
        string deploymentID,
        DeploymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { DeploymentID = deploymentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsDeployment> Update(
        DeploymentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsDeployment> Update(
        string deploymentID,
        DeploymentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { DeploymentID = deploymentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DeploymentListPage> List(
        DeploymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsDeployment> Archive(
        DeploymentArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsDeployment> Archive(
        string deploymentID,
        DeploymentArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { DeploymentID = deploymentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsDeployment> Pause(
        DeploymentPauseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Pause(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsDeployment> Pause(
        string deploymentID,
        DeploymentPauseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Pause(parameters with { DeploymentID = deploymentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsDeploymentRun> Run(
        DeploymentRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Run(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsDeploymentRun> Run(
        string deploymentID,
        DeploymentRunParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Run(parameters with { DeploymentID = deploymentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaManagedAgentsDeployment> Unpause(
        DeploymentUnpauseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Unpause(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaManagedAgentsDeployment> Unpause(
        string deploymentID,
        DeploymentUnpauseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unpause(parameters with { DeploymentID = deploymentID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DeploymentServiceWithRawResponse : IDeploymentServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDeploymentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DeploymentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DeploymentServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsDeployment>> Create(
        DeploymentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DeploymentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsDeployment = await response
                    .Deserialize<BetaManagedAgentsDeployment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsDeployment.Validate();
                }
                return betaManagedAgentsDeployment;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsDeployment>> Retrieve(
        DeploymentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DeploymentID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.DeploymentID' cannot be null");
        }

        HttpRequest<DeploymentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsDeployment = await response
                    .Deserialize<BetaManagedAgentsDeployment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsDeployment.Validate();
                }
                return betaManagedAgentsDeployment;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsDeployment>> Retrieve(
        string deploymentID,
        DeploymentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { DeploymentID = deploymentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsDeployment>> Update(
        DeploymentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DeploymentID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.DeploymentID' cannot be null");
        }

        HttpRequest<DeploymentUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsDeployment = await response
                    .Deserialize<BetaManagedAgentsDeployment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsDeployment.Validate();
                }
                return betaManagedAgentsDeployment;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsDeployment>> Update(
        string deploymentID,
        DeploymentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { DeploymentID = deploymentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DeploymentListPage>> List(
        DeploymentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DeploymentListParams> request = new()
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
                    .Deserialize<DeploymentListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new DeploymentListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsDeployment>> Archive(
        DeploymentArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DeploymentID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.DeploymentID' cannot be null");
        }

        HttpRequest<DeploymentArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsDeployment = await response
                    .Deserialize<BetaManagedAgentsDeployment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsDeployment.Validate();
                }
                return betaManagedAgentsDeployment;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsDeployment>> Archive(
        string deploymentID,
        DeploymentArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { DeploymentID = deploymentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsDeployment>> Pause(
        DeploymentPauseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DeploymentID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.DeploymentID' cannot be null");
        }

        HttpRequest<DeploymentPauseParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsDeployment = await response
                    .Deserialize<BetaManagedAgentsDeployment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsDeployment.Validate();
                }
                return betaManagedAgentsDeployment;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsDeployment>> Pause(
        string deploymentID,
        DeploymentPauseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Pause(parameters with { DeploymentID = deploymentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsDeploymentRun>> Run(
        DeploymentRunParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DeploymentID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.DeploymentID' cannot be null");
        }

        HttpRequest<DeploymentRunParams> request = new()
        {
            Method = HttpMethod.Post,
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
    public Task<HttpResponse<BetaManagedAgentsDeploymentRun>> Run(
        string deploymentID,
        DeploymentRunParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Run(parameters with { DeploymentID = deploymentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaManagedAgentsDeployment>> Unpause(
        DeploymentUnpauseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DeploymentID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.DeploymentID' cannot be null");
        }

        HttpRequest<DeploymentUnpauseParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaManagedAgentsDeployment = await response
                    .Deserialize<BetaManagedAgentsDeployment>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaManagedAgentsDeployment.Validate();
                }
                return betaManagedAgentsDeployment;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaManagedAgentsDeployment>> Unpause(
        string deploymentID,
        DeploymentUnpauseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unpause(parameters with { DeploymentID = deploymentID }, cancellationToken);
    }
}
