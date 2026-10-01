using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.Summaries;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <inheritdoc/>
public sealed class SummaryService : ISummaryService
{
    readonly Lazy<ISummaryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISummaryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public ISummaryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SummaryService(this._client.WithOptions(modifier));
    }

    public SummaryService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SummaryServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<SummaryListPage> List(
        SummaryListParams parameters,
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
public sealed class SummaryServiceWithRawResponse : ISummaryServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISummaryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SummaryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SummaryServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SummaryListPage>> List(
        SummaryListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SummaryListParams> request = new()
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
                    .Deserialize<SummaryListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SummaryListPage(this, parameters, page);
            }
        );
    }
}
