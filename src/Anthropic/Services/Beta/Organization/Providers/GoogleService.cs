using System;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.Providers.Google;

namespace Anthropic.Services.Beta.Organization.Providers;

/// <inheritdoc/>
public sealed class GoogleService : IGoogleService
{
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
        _projects = new(() => new ProjectService(client));
    }

    readonly Lazy<IProjectService> _projects;
    public IProjectService Projects
    {
        get { return _projects.Value; }
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

        _projects = new(() => new ProjectServiceWithRawResponse(client));
    }

    readonly Lazy<IProjectServiceWithRawResponse> _projects;
    public IProjectServiceWithRawResponse Projects
    {
        get { return _projects.Value; }
    }
}
