using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Plugins.Versions;

namespace Anthropic.Services.Beta.Organization.Plugins;

/// <inheritdoc/>
public sealed class VersionService : IVersionService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "ce-plugins-2026-09-01");
    }

    readonly Lazy<IVersionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVersionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VersionService(this._client.WithOptions(modifier));
    }

    public VersionService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new VersionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaPluginVersion> Create(
        VersionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaPluginVersion> Create(
        string pluginID,
        VersionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { PluginID = pluginID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaPluginVersion> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaPluginVersion> Retrieve(
        string version,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { Version = version }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VersionListPage> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<VersionListPage> List(
        string pluginID,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PluginID = pluginID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        VersionDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Download(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        string version,
        VersionDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Download(parameters with { Version = version }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class VersionServiceWithRawResponse : IVersionServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVersionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VersionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VersionServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaPluginVersion>> Create(
        VersionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PluginID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.PluginID' cannot be null");
        }

        HttpRequest<VersionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaPluginVersion = await response
                    .Deserialize<BetaPluginVersion>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaPluginVersion.Validate();
                }
                return betaPluginVersion;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaPluginVersion>> Create(
        string pluginID,
        VersionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { PluginID = pluginID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaPluginVersion>> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Version == null)
        {
            throw new AnthropicInvalidDataException("'parameters.Version' cannot be null");
        }

        HttpRequest<VersionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaPluginVersion = await response
                    .Deserialize<BetaPluginVersion>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaPluginVersion.Validate();
                }
                return betaPluginVersion;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaPluginVersion>> Retrieve(
        string version,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { Version = version }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VersionListPage>> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PluginID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.PluginID' cannot be null");
        }

        HttpRequest<VersionListParams> request = new()
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
                    .Deserialize<VersionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new VersionListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<VersionListPage>> List(
        string pluginID,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PluginID = pluginID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        VersionDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Version == null)
        {
            throw new AnthropicInvalidDataException("'parameters.Version' cannot be null");
        }

        HttpRequest<VersionDownloadParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        string version,
        VersionDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Download(parameters with { Version = version }, cancellationToken);
    }
}
