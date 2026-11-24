using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

namespace Anthropic.Services.Beta.Organization.Providers.Google.Projects;

/// <inheritdoc/>
public sealed class DataControlService : IDataControlService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "google-managed-data-controls-2026-09-01");
    }

    readonly Lazy<IDataControlServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDataControlServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IDataControlService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DataControlService(this._client.WithOptions(modifier));
    }

    public DataControlService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DataControlServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaGoogleManagedProjectDataControls> Retrieve(
        DataControlRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaGoogleManagedProjectDataControls> Retrieve(
        string projectNumber,
        DataControlRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ProjectNumber = projectNumber }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaGoogleManagedProjectDataControls> Update(
        DataControlUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaGoogleManagedProjectDataControls> Update(
        string projectNumber,
        DataControlUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ProjectNumber = projectNumber }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DataControlServiceWithRawResponse : IDataControlServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDataControlServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DataControlServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DataControlServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaGoogleManagedProjectDataControls>> Retrieve(
        DataControlRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProjectNumber == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ProjectNumber' cannot be null");
        }

        HttpRequest<DataControlRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.providers.google.projects.data_controls.retrieve",
            SpanResourceIds =
            [
                new("anthropic.organization.provider.google.project.id", parameters.ProjectNumber),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaGoogleManagedProjectDataControls = await response
                    .Deserialize<BetaGoogleManagedProjectDataControls>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaGoogleManagedProjectDataControls.Validate();
                }
                return betaGoogleManagedProjectDataControls;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaGoogleManagedProjectDataControls>> Retrieve(
        string projectNumber,
        DataControlRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ProjectNumber = projectNumber }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaGoogleManagedProjectDataControls>> Update(
        DataControlUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProjectNumber == null)
        {
            throw new AnthropicInvalidDataException("'parameters.ProjectNumber' cannot be null");
        }

        HttpRequest<DataControlUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.providers.google.projects.data_controls.update",
            SpanResourceIds =
            [
                new("anthropic.organization.provider.google.project.id", parameters.ProjectNumber),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaGoogleManagedProjectDataControls = await response
                    .Deserialize<BetaGoogleManagedProjectDataControls>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaGoogleManagedProjectDataControls.Validate();
                }
                return betaGoogleManagedProjectDataControls;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaGoogleManagedProjectDataControls>> Update(
        string projectNumber,
        DataControlUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ProjectNumber = projectNumber }, cancellationToken);
    }
}
