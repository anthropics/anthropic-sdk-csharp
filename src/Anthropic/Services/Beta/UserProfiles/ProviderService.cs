using System;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Services.Beta.UserProfiles.Providers;

namespace Anthropic.Services.Beta.UserProfiles;

/// <inheritdoc/>
public sealed class ProviderService : IProviderService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "user-profiles-2026-08-18");
    }

    readonly Lazy<IProviderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProviderServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IProviderService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProviderService(this._client.WithOptions(modifier));
    }

    public ProviderService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ProviderServiceWithRawResponse(client.WithRawResponse));
        _google = new(() => new GoogleService(client));
    }

    readonly Lazy<IGoogleService> _google;
    public IGoogleService Google
    {
        get { return _google.Value; }
    }
}

/// <inheritdoc/>
public sealed class ProviderServiceWithRawResponse : IProviderServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProviderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProviderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProviderServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _google = new(() => new GoogleServiceWithRawResponse(client));
    }

    readonly Lazy<IGoogleServiceWithRawResponse> _google;
    public IGoogleServiceWithRawResponse Google
    {
        get { return _google.Value; }
    }
}
