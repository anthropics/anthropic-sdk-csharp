using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Plugins.InstallationSettings;

namespace Anthropic.Services.Beta.Organization.Plugins;

/// <inheritdoc/>
public sealed class InstallationSettingService : IInstallationSettingService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "ce-plugins-2026-09-01");
    }

    readonly Lazy<IInstallationSettingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInstallationSettingServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IInstallationSettingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InstallationSettingService(this._client.WithOptions(modifier));
    }

    public InstallationSettingService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new InstallationSettingServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<InstallationSettingListPage> List(
        InstallationSettingListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InstallationSettingListPage> List(
        string pluginID,
        InstallationSettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PluginID = pluginID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaDeletedPluginInstallationSetting> Remove(
        InstallationSettingRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Remove(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaDeletedPluginInstallationSetting> Remove(
        string target,
        InstallationSettingRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with { Target = target }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaPluginInstallationSetting> Set(
        InstallationSettingSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Set(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaPluginInstallationSetting> Set(
        string target,
        InstallationSettingSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Set(parameters with { Target = target }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class InstallationSettingServiceWithRawResponse
    : IInstallationSettingServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInstallationSettingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InstallationSettingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InstallationSettingServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InstallationSettingListPage>> List(
        InstallationSettingListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PluginID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.PluginID' cannot be null");
        }

        HttpRequest<InstallationSettingListParams> request = new()
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
                    .Deserialize<InstallationSettingListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new InstallationSettingListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InstallationSettingListPage>> List(
        string pluginID,
        InstallationSettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PluginID = pluginID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaDeletedPluginInstallationSetting>> Remove(
        InstallationSettingRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Target == null)
        {
            throw new AnthropicInvalidDataException("'parameters.Target' cannot be null");
        }

        HttpRequest<InstallationSettingRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaDeletedPluginInstallationSetting = await response
                    .Deserialize<BetaDeletedPluginInstallationSetting>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaDeletedPluginInstallationSetting.Validate();
                }
                return betaDeletedPluginInstallationSetting;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaDeletedPluginInstallationSetting>> Remove(
        string target,
        InstallationSettingRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with { Target = target }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaPluginInstallationSetting>> Set(
        InstallationSettingSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Target == null)
        {
            throw new AnthropicInvalidDataException("'parameters.Target' cannot be null");
        }

        HttpRequest<InstallationSettingSetParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaPluginInstallationSetting = await response
                    .Deserialize<BetaPluginInstallationSetting>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaPluginInstallationSetting.Validate();
                }
                return betaPluginInstallationSetting;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaPluginInstallationSetting>> Set(
        string target,
        InstallationSettingSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Set(parameters with { Target = target }, cancellationToken);
    }
}
