using System;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Services.Beta.UserProfiles.Providers.Google;

namespace Anthropic.Services.Beta.UserProfiles.Providers;

/// <inheritdoc/>
public sealed class GoogleService : IGoogleService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "user-profiles-2026-08-18");
    }

    readonly Lazy<IGoogleServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGoogleServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IGoogleService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GoogleService(this._client.WithOptions(modifier));
    }

    public GoogleService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new GoogleServiceWithRawResponse(client.WithRawResponse));
        _dataControls = new(() => new DataControlService(client));
    }

    readonly Lazy<IDataControlService> _dataControls;
    public IDataControlService DataControls
    {
        get { return _dataControls.Value; }
    }
}

/// <inheritdoc/>
public sealed class GoogleServiceWithRawResponse : IGoogleServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGoogleServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GoogleServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GoogleServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _dataControls = new(() => new DataControlServiceWithRawResponse(client));
    }

    readonly Lazy<IDataControlServiceWithRawResponse> _dataControls;
    public IDataControlServiceWithRawResponse DataControls
    {
        get { return _dataControls.Value; }
    }
}
