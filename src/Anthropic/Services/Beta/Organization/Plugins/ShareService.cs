using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Plugins.Shares;

namespace Anthropic.Services.Beta.Organization.Plugins;

/// <inheritdoc/>
public sealed class ShareService : IShareService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "ce-plugins-2026-09-01");
    }

    readonly Lazy<IShareServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IShareServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IShareService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ShareService(this._client.WithOptions(modifier));
    }

    public ShareService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ShareServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ShareListPage> List(
        ShareListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ShareListPage> List(
        string pluginID,
        ShareListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PluginID = pluginID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ShareServiceWithRawResponse : IShareServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IShareServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ShareServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ShareServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ShareListPage>> List(
        ShareListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PluginID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.PluginID' cannot be null");
        }

        HttpRequest<ShareListParams> request = new()
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
                    .Deserialize<ShareListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ShareListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ShareListPage>> List(
        string pluginID,
        ShareListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PluginID = pluginID }, cancellationToken);
    }
}
