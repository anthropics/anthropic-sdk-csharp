using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.CostReport;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <inheritdoc/>
public sealed class CostReportService : ICostReportService
{
    readonly Lazy<ICostReportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICostReportServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public ICostReportService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CostReportService(this._client.WithOptions(modifier));
    }

    public CostReportService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CostReportServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CostReportListPage> List(
        CostReportListParams parameters,
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
public sealed class CostReportServiceWithRawResponse : ICostReportServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICostReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CostReportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CostReportServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CostReportListPage>> List(
        CostReportListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CostReportListParams> request = new()
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
                    .Deserialize<CostReportListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CostReportListPage(this, parameters, page);
            }
        );
    }
}
