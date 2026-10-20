using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.TelemetryDestinations.Workspaces;

namespace Anthropic.Services.Beta.Organization.TelemetryDestinations;

/// <inheritdoc/>
public sealed class WorkspaceService : IWorkspaceService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "telemetry-destinations-2026-08-11");
    }

    readonly Lazy<IWorkspaceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWorkspaceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IWorkspaceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WorkspaceService(this._client.WithOptions(modifier));
    }

    public WorkspaceService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WorkspaceServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<WorkspaceListPage> List(
        WorkspaceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WorkspaceListPage> List(
        string destinationID,
        WorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { DestinationID = destinationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaTelemetryDestinationWorkspace> Add(
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Add(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaTelemetryDestinationWorkspace> Add(
        string workspaceID,
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaDeletedTelemetryDestinationWorkspace> Remove(
        WorkspaceRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Remove(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaDeletedTelemetryDestinationWorkspace> Remove(
        string workspaceID,
        WorkspaceRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class WorkspaceServiceWithRawResponse : IWorkspaceServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWorkspaceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WorkspaceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WorkspaceServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WorkspaceListPage>> List(
        WorkspaceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DestinationID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.DestinationID' cannot be null");
        }

        HttpRequest<WorkspaceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            SpanName = "anthropic.organization.telemetry_destinations.workspaces.list",
            SpanResourceIds =
            [
                new("anthropic.organization.telemetry_destination.id", parameters.DestinationID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<WorkspaceListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new WorkspaceListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WorkspaceListPage>> List(
        string destinationID,
        WorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { DestinationID = destinationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaTelemetryDestinationWorkspace>> Add(
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkspaceID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.WorkspaceID' cannot be null");
        }

        HttpRequest<WorkspaceAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            SpanName = "anthropic.organization.telemetry_destinations.workspaces.add",
            SpanResourceIds =
            [
                new("anthropic.organization.telemetry_destination.id", parameters.DestinationID),
                new(
                    "anthropic.organization.telemetry_destination.workspace.id",
                    parameters.WorkspaceID
                ),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaTelemetryDestinationWorkspace = await response
                    .Deserialize<BetaTelemetryDestinationWorkspace>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaTelemetryDestinationWorkspace.Validate();
                }
                return betaTelemetryDestinationWorkspace;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaTelemetryDestinationWorkspace>> Add(
        string workspaceID,
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaDeletedTelemetryDestinationWorkspace>> Remove(
        WorkspaceRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkspaceID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.WorkspaceID' cannot be null");
        }

        HttpRequest<WorkspaceRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
            SpanName = "anthropic.organization.telemetry_destinations.workspaces.remove",
            SpanResourceIds =
            [
                new("anthropic.organization.telemetry_destination.id", parameters.DestinationID),
                new(
                    "anthropic.organization.telemetry_destination.workspace.id",
                    parameters.WorkspaceID
                ),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaDeletedTelemetryDestinationWorkspace = await response
                    .Deserialize<BetaDeletedTelemetryDestinationWorkspace>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaDeletedTelemetryDestinationWorkspace.Validate();
                }
                return betaDeletedTelemetryDestinationWorkspace;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaDeletedTelemetryDestinationWorkspace>> Remove(
        string workspaceID,
        WorkspaceRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }
}
