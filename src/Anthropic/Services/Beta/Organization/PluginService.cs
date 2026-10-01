using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Plugins;
using Anthropic.Services.Beta.Organization.Plugins;

namespace Anthropic.Services.Beta.Organization;

/// <inheritdoc/>
public sealed class PluginService : IPluginService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "ce-plugins-2026-09-01");
    }

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
        _versions = new(() => new VersionService(client));
        _installationSettings = new(() => new InstallationSettingService(client));
        _shares = new(() => new ShareService(client));
    }

    readonly Lazy<IVersionService> _versions;
    public IVersionService Versions
    {
        get { return _versions.Value; }
    }

    readonly Lazy<IInstallationSettingService> _installationSettings;
    public IInstallationSettingService InstallationSettings
    {
        get { return _installationSettings.Value; }
    }

    readonly Lazy<IShareService> _shares;
    public IShareService Shares
    {
        get { return _shares.Value; }
    }

    /// <inheritdoc/>
    public async Task<BetaPlugin> Create(
        PluginCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaPlugin> Retrieve(
        PluginRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaPlugin> Retrieve(
        string pluginID,
        PluginRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { PluginID = pluginID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaPlugin> Update(
        PluginUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaPlugin> Update(
        string pluginID,
        PluginUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { PluginID = pluginID }, cancellationToken);
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

    /// <inheritdoc/>
    public async Task<BetaDeletedPlugin> Delete(
        PluginDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaDeletedPlugin> Delete(
        string pluginID,
        PluginDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { PluginID = pluginID }, cancellationToken);
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

        _versions = new(() => new VersionServiceWithRawResponse(client));
        _installationSettings = new(() => new InstallationSettingServiceWithRawResponse(client));
        _shares = new(() => new ShareServiceWithRawResponse(client));
    }

    readonly Lazy<IVersionServiceWithRawResponse> _versions;
    public IVersionServiceWithRawResponse Versions
    {
        get { return _versions.Value; }
    }

    readonly Lazy<IInstallationSettingServiceWithRawResponse> _installationSettings;
    public IInstallationSettingServiceWithRawResponse InstallationSettings
    {
        get { return _installationSettings.Value; }
    }

    readonly Lazy<IShareServiceWithRawResponse> _shares;
    public IShareServiceWithRawResponse Shares
    {
        get { return _shares.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaPlugin>> Create(
        PluginCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PluginCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaPlugin = await response
                    .Deserialize<BetaPlugin>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaPlugin.Validate();
                }
                return betaPlugin;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaPlugin>> Retrieve(
        PluginRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PluginID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.PluginID' cannot be null");
        }

        HttpRequest<PluginRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaPlugin = await response
                    .Deserialize<BetaPlugin>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaPlugin.Validate();
                }
                return betaPlugin;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaPlugin>> Retrieve(
        string pluginID,
        PluginRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { PluginID = pluginID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaPlugin>> Update(
        PluginUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PluginID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.PluginID' cannot be null");
        }

        HttpRequest<PluginUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaPlugin = await response
                    .Deserialize<BetaPlugin>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaPlugin.Validate();
                }
                return betaPlugin;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaPlugin>> Update(
        string pluginID,
        PluginUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { PluginID = pluginID }, cancellationToken);
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

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaDeletedPlugin>> Delete(
        PluginDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PluginID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.PluginID' cannot be null");
        }

        HttpRequest<PluginDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaDeletedPlugin = await response
                    .Deserialize<BetaDeletedPlugin>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaDeletedPlugin.Validate();
                }
                return betaDeletedPlugin;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaDeletedPlugin>> Delete(
        string pluginID,
        PluginDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { PluginID = pluginID }, cancellationToken);
    }
}
