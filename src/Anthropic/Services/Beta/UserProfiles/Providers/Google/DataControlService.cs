using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

namespace Anthropic.Services.Beta.UserProfiles.Providers.Google;

/// <inheritdoc/>
public sealed class DataControlService : IDataControlService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add(
            "anthropic-beta",
            "user-profiles-2026-09-04,google-managed-data-controls-2026-09-01"
        );
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
    public async Task<BetaGoogleManagedDataControls> Retrieve(
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
    public Task<BetaGoogleManagedDataControls> Retrieve(
        string userProfileID,
        DataControlRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { UserProfileID = userProfileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaGoogleManagedDataControls> Update(
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
    public Task<BetaGoogleManagedDataControls> Update(
        string userProfileID,
        DataControlUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { UserProfileID = userProfileID }, cancellationToken);
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
    public async Task<HttpResponse<BetaGoogleManagedDataControls>> Retrieve(
        DataControlRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserProfileID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.UserProfileID' cannot be null");
        }

        HttpRequest<DataControlRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.user_profiles.providers.google.data_controls.retrieve",
            SpanResourceIds = [new("anthropic.user_profile.id", parameters.UserProfileID)],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaGoogleManagedDataControls = await response
                    .Deserialize<BetaGoogleManagedDataControls>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaGoogleManagedDataControls.Validate();
                }
                return betaGoogleManagedDataControls;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaGoogleManagedDataControls>> Retrieve(
        string userProfileID,
        DataControlRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { UserProfileID = userProfileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaGoogleManagedDataControls>> Update(
        DataControlUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserProfileID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.UserProfileID' cannot be null");
        }

        HttpRequest<DataControlUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.user_profiles.providers.google.data_controls.update",
            SpanResourceIds = [new("anthropic.user_profile.id", parameters.UserProfileID)],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaGoogleManagedDataControls = await response
                    .Deserialize<BetaGoogleManagedDataControls>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaGoogleManagedDataControls.Validate();
                }
                return betaGoogleManagedDataControls;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaGoogleManagedDataControls>> Update(
        string userProfileID,
        DataControlUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { UserProfileID = userProfileID }, cancellationToken);
    }
}
