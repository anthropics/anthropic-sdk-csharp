using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ComplianceSettings;

namespace Anthropic.Services.Beta.Organization;

/// <inheritdoc/>
public sealed class ComplianceSettingService : IComplianceSettingService
{
    readonly Lazy<IComplianceSettingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IComplianceSettingServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IComplianceSettingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ComplianceSettingService(this._client.WithOptions(modifier));
    }

    public ComplianceSettingService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ComplianceSettingServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<BetaComplianceSettings> Retrieve(
        ComplianceSettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaComplianceSettings> Update(
        ComplianceSettingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ComplianceSettingServiceWithRawResponse
    : IComplianceSettingServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IComplianceSettingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ComplianceSettingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ComplianceSettingServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaComplianceSettings>> Retrieve(
        ComplianceSettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ComplianceSettingRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaComplianceSettings = await response
                    .Deserialize<BetaComplianceSettings>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaComplianceSettings.Validate();
                }
                return betaComplianceSettings;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaComplianceSettings>> Update(
        ComplianceSettingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ComplianceSettingUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaComplianceSettings = await response
                    .Deserialize<BetaComplianceSettings>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaComplianceSettings.Validate();
                }
                return betaComplianceSettings;
            }
        );
    }
}
