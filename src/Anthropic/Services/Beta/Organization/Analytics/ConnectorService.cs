using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.Connectors;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <inheritdoc/>
public sealed class ConnectorService : IConnectorService
{
    readonly Lazy<IConnectorServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IConnectorServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IConnectorService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ConnectorService(this._client.WithOptions(modifier));
    }

    public ConnectorService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ConnectorServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ConnectorListPage> List(
        ConnectorListParams? parameters = null,
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
public sealed class ConnectorServiceWithRawResponse : IConnectorServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IConnectorServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ConnectorServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ConnectorServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConnectorListPage>> List(
        ConnectorListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ConnectorListParams> request = new()
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
                    .Deserialize<ConnectorListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ConnectorListPage(this, parameters, page);
            }
        );
    }
}
