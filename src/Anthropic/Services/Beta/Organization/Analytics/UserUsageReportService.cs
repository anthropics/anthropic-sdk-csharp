using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.UserUsageReport;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <inheritdoc/>
public sealed class UserUsageReportService : IUserUsageReportService
{
    readonly Lazy<IUserUsageReportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUserUsageReportServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IUserUsageReportService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserUsageReportService(this._client.WithOptions(modifier));
    }

    public UserUsageReportService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new UserUsageReportServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<UserUsageReportListPage> List(
        UserUsageReportListParams parameters,
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
public sealed class UserUsageReportServiceWithRawResponse : IUserUsageReportServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUserUsageReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new UserUsageReportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UserUsageReportServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserUsageReportListPage>> List(
        UserUsageReportListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UserUsageReportListParams> request = new()
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
                    .Deserialize<UserUsageReportListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new UserUsageReportListPage(this, parameters, page);
            }
        );
    }
}
