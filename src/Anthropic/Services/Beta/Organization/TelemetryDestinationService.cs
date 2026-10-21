using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;
using TelemetryDestinations = Anthropic.Services.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Services.Beta.Organization;

/// <inheritdoc/>
public sealed class TelemetryDestinationService : ITelemetryDestinationService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "telemetry-destinations-2026-08-11");
    }

    readonly Lazy<ITelemetryDestinationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITelemetryDestinationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public ITelemetryDestinationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TelemetryDestinationService(this._client.WithOptions(modifier));
    }

    public TelemetryDestinationService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new TelemetryDestinationServiceWithRawResponse(client.WithRawResponse)
        );
        _workspaces = new(() => new TelemetryDestinations::WorkspaceService(client));
    }

    readonly Lazy<TelemetryDestinations::IWorkspaceService> _workspaces;
    public TelemetryDestinations::IWorkspaceService Workspaces
    {
        get { return _workspaces.Value; }
    }

    /// <inheritdoc/>
    public async Task<BetaTelemetryDestination> Create(
        TelemetryDestinationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaTelemetryDestination> Retrieve(
        TelemetryDestinationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaTelemetryDestination> Retrieve(
        string destinationID,
        TelemetryDestinationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { DestinationID = destinationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaTelemetryDestination> Update(
        TelemetryDestinationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaTelemetryDestination> Update(
        string destinationID,
        TelemetryDestinationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { DestinationID = destinationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TelemetryDestinationListPage> List(
        TelemetryDestinationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaDeletedTelemetryDestination> Delete(
        TelemetryDestinationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaDeletedTelemetryDestination> Delete(
        string destinationID,
        TelemetryDestinationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { DestinationID = destinationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaTelemetryDestinationTestResponse> Test(
        TelemetryDestinationTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Test(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaTelemetryDestinationTestResponse> Test(
        string destinationID,
        TelemetryDestinationTestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Test(parameters with { DestinationID = destinationID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TelemetryDestinationServiceWithRawResponse
    : ITelemetryDestinationServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITelemetryDestinationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TelemetryDestinationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TelemetryDestinationServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _workspaces = new(() => new TelemetryDestinations::WorkspaceServiceWithRawResponse(client));
    }

    readonly Lazy<TelemetryDestinations::IWorkspaceServiceWithRawResponse> _workspaces;
    public TelemetryDestinations::IWorkspaceServiceWithRawResponse Workspaces
    {
        get { return _workspaces.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaTelemetryDestination>> Create(
        TelemetryDestinationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TelemetryDestinationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            SpanName = "anthropic.organization.telemetry_destinations.create",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaTelemetryDestination = await response
                    .Deserialize<BetaTelemetryDestination>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaTelemetryDestination.Validate();
                }
                Tracing.SetCreatedId(
                    response.Span,
                    "anthropic.organization.telemetry_destination.id",
                    betaTelemetryDestination,
                    static created => created.ID
                );
                return betaTelemetryDestination;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaTelemetryDestination>> Retrieve(
        TelemetryDestinationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DestinationID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.DestinationID' cannot be null");
        }

        HttpRequest<TelemetryDestinationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            SpanName = "anthropic.organization.telemetry_destinations.retrieve",
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
                var betaTelemetryDestination = await response
                    .Deserialize<BetaTelemetryDestination>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaTelemetryDestination.Validate();
                }
                return betaTelemetryDestination;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaTelemetryDestination>> Retrieve(
        string destinationID,
        TelemetryDestinationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { DestinationID = destinationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaTelemetryDestination>> Update(
        TelemetryDestinationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DestinationID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.DestinationID' cannot be null");
        }

        HttpRequest<TelemetryDestinationUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            SpanName = "anthropic.organization.telemetry_destinations.update",
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
                var betaTelemetryDestination = await response
                    .Deserialize<BetaTelemetryDestination>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaTelemetryDestination.Validate();
                }
                return betaTelemetryDestination;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaTelemetryDestination>> Update(
        string destinationID,
        TelemetryDestinationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { DestinationID = destinationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TelemetryDestinationListPage>> List(
        TelemetryDestinationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TelemetryDestinationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            SpanName = "anthropic.organization.telemetry_destinations.list",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<TelemetryDestinationListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TelemetryDestinationListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaDeletedTelemetryDestination>> Delete(
        TelemetryDestinationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DestinationID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.DestinationID' cannot be null");
        }

        HttpRequest<TelemetryDestinationDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
            SpanName = "anthropic.organization.telemetry_destinations.delete",
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
                var betaDeletedTelemetryDestination = await response
                    .Deserialize<BetaDeletedTelemetryDestination>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaDeletedTelemetryDestination.Validate();
                }
                return betaDeletedTelemetryDestination;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaDeletedTelemetryDestination>> Delete(
        string destinationID,
        TelemetryDestinationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { DestinationID = destinationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaTelemetryDestinationTestResponse>> Test(
        TelemetryDestinationTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DestinationID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.DestinationID' cannot be null");
        }

        HttpRequest<TelemetryDestinationTestParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            SpanName = "anthropic.organization.telemetry_destinations.test",
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
                var betaTelemetryDestinationTestResponse = await response
                    .Deserialize<BetaTelemetryDestinationTestResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaTelemetryDestinationTestResponse.Validate();
                }
                return betaTelemetryDestinationTestResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaTelemetryDestinationTestResponse>> Test(
        string destinationID,
        TelemetryDestinationTestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Test(parameters with { DestinationID = destinationID }, cancellationToken);
    }
}
