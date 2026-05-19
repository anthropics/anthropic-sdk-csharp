using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Environments.Work;

namespace Anthropic.Services.Beta.Environments;

/// <inheritdoc/>
public sealed class WorkService : IWorkService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "managed-agents-2026-04-01");
    }

    readonly Lazy<IWorkServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWorkServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IWorkService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WorkService(this._client.WithOptions(modifier));
    }

    public WorkService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WorkServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaSelfHostedWork> Retrieve(
        WorkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaSelfHostedWork> Retrieve(
        string workID,
        WorkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { WorkID = workID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaSelfHostedWork> Update(
        WorkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaSelfHostedWork> Update(
        string workID,
        WorkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { WorkID = workID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WorkListPage> List(
        WorkListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WorkListPage> List(
        string environmentID,
        WorkListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { EnvironmentID = environmentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaSelfHostedWork> Ack(
        WorkAckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Ack(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaSelfHostedWork> Ack(
        string workID,
        WorkAckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Ack(parameters with { WorkID = workID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaSelfHostedWorkHeartbeatResponse> Heartbeat(
        WorkHeartbeatParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Heartbeat(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaSelfHostedWorkHeartbeatResponse> Heartbeat(
        string workID,
        WorkHeartbeatParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Heartbeat(parameters with { WorkID = workID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaSelfHostedWork?> Poll(
        WorkPollParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Poll(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaSelfHostedWork?> Poll(
        string environmentID,
        WorkPollParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Poll(parameters with { EnvironmentID = environmentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaSelfHostedWorkQueueStats> Stats(
        WorkStatsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Stats(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaSelfHostedWorkQueueStats> Stats(
        string environmentID,
        WorkStatsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Stats(parameters with { EnvironmentID = environmentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaSelfHostedWork> Stop(
        WorkStopParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Stop(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaSelfHostedWork> Stop(
        string workID,
        WorkStopParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Stop(parameters with { WorkID = workID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class WorkServiceWithRawResponse : IWorkServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWorkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WorkServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WorkServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaSelfHostedWork>> Retrieve(
        WorkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.WorkID' cannot be null");
        }

        HttpRequest<WorkRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaSelfHostedWork = await response
                    .Deserialize<BetaSelfHostedWork>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaSelfHostedWork.Validate();
                }
                return betaSelfHostedWork;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaSelfHostedWork>> Retrieve(
        string workID,
        WorkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { WorkID = workID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaSelfHostedWork>> Update(
        WorkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.WorkID' cannot be null");
        }

        HttpRequest<WorkUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaSelfHostedWork = await response
                    .Deserialize<BetaSelfHostedWork>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaSelfHostedWork.Validate();
                }
                return betaSelfHostedWork;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaSelfHostedWork>> Update(
        string workID,
        WorkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { WorkID = workID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WorkListPage>> List(
        WorkListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnvironmentID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.EnvironmentID' cannot be null");
        }

        HttpRequest<WorkListParams> request = new()
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
                    .Deserialize<BetaSelfHostedWorkListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new WorkListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WorkListPage>> List(
        string environmentID,
        WorkListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { EnvironmentID = environmentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaSelfHostedWork>> Ack(
        WorkAckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.WorkID' cannot be null");
        }

        HttpRequest<WorkAckParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaSelfHostedWork = await response
                    .Deserialize<BetaSelfHostedWork>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaSelfHostedWork.Validate();
                }
                return betaSelfHostedWork;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaSelfHostedWork>> Ack(
        string workID,
        WorkAckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Ack(parameters with { WorkID = workID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaSelfHostedWorkHeartbeatResponse>> Heartbeat(
        WorkHeartbeatParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.WorkID' cannot be null");
        }

        HttpRequest<WorkHeartbeatParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaSelfHostedWorkHeartbeatResponse = await response
                    .Deserialize<BetaSelfHostedWorkHeartbeatResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaSelfHostedWorkHeartbeatResponse.Validate();
                }
                return betaSelfHostedWorkHeartbeatResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaSelfHostedWorkHeartbeatResponse>> Heartbeat(
        string workID,
        WorkHeartbeatParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Heartbeat(parameters with { WorkID = workID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaSelfHostedWork?>> Poll(
        WorkPollParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnvironmentID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.EnvironmentID' cannot be null");
        }

        HttpRequest<WorkPollParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaSelfHostedWork = await response
                    .Deserialize<BetaSelfHostedWork?>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaSelfHostedWork?.Validate();
                }
                return betaSelfHostedWork;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaSelfHostedWork?>> Poll(
        string environmentID,
        WorkPollParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Poll(parameters with { EnvironmentID = environmentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaSelfHostedWorkQueueStats>> Stats(
        WorkStatsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnvironmentID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.EnvironmentID' cannot be null");
        }

        HttpRequest<WorkStatsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaSelfHostedWorkQueueStats = await response
                    .Deserialize<BetaSelfHostedWorkQueueStats>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaSelfHostedWorkQueueStats.Validate();
                }
                return betaSelfHostedWorkQueueStats;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaSelfHostedWorkQueueStats>> Stats(
        string environmentID,
        WorkStatsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Stats(parameters with { EnvironmentID = environmentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaSelfHostedWork>> Stop(
        WorkStopParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.WorkID' cannot be null");
        }

        HttpRequest<WorkStopParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaSelfHostedWork = await response
                    .Deserialize<BetaSelfHostedWork>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaSelfHostedWork.Validate();
                }
                return betaSelfHostedWork;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaSelfHostedWork>> Stop(
        string workID,
        WorkStopParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Stop(parameters with { WorkID = workID }, cancellationToken);
    }
}
