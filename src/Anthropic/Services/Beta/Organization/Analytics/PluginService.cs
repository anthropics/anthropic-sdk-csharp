using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.Plugins;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <inheritdoc/>
public sealed class PluginService : IPluginService
{
    readonly Lazy<IPluginServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPluginServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IPluginService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PluginService(this._client.WithOptions(modifier));
    }

    public PluginService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PluginServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PluginListPage> List(
        PluginListParams? parameters = null,
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
public sealed class PluginServiceWithRawResponse : IPluginServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPluginServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PluginServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PluginServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PluginListPage>> List(
        PluginListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PluginListParams> request = new()
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
                    .Deserialize<PluginListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new PluginListPage(this, parameters, page);
            }
        );
    }
}
