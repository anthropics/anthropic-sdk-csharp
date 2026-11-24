using System;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.Providers.Google.Projects;

namespace Anthropic.Services.Beta.Organization.Providers.Google;

/// <inheritdoc/>
public sealed class ProjectService : IProjectService
{
    readonly Lazy<IProjectServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProjectServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IProjectService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProjectService(this._client.WithOptions(modifier));
    }

    public ProjectService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ProjectServiceWithRawResponse(client.WithRawResponse));
        _dataControls = new(() => new DataControlService(client));
    }

    readonly Lazy<IDataControlService> _dataControls;
    public IDataControlService DataControls
    {
        get { return _dataControls.Value; }
    }
}

/// <inheritdoc/>
public sealed class ProjectServiceWithRawResponse : IProjectServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProjectServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProjectServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProjectServiceWithRawResponse(IAnthropicClientWithRawResponse client)
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
