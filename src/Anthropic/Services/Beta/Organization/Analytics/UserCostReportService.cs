using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.UserCostReport;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <inheritdoc/>
public sealed class UserCostReportService : IUserCostReportService
{
    readonly Lazy<IUserCostReportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUserCostReportServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IUserCostReportService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserCostReportService(this._client.WithOptions(modifier));
    }

    public UserCostReportService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new UserCostReportServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<UserCostReportListPage> List(
        UserCostReportListParams parameters,
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
public sealed class UserCostReportServiceWithRawResponse : IUserCostReportServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUserCostReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new UserCostReportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UserCostReportServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserCostReportListPage>> List(
        UserCostReportListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UserCostReportListParams> request = new()
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
                    .Deserialize<UserCostReportListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new UserCostReportListPage(this, parameters, page);
            }
        );
    }
}
