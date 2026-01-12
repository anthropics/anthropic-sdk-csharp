using System;
using Anthropic.Core;
using Beta = Anthropic.Services.Beta;

namespace Anthropic.Services;

/// <inheritdoc/>
public sealed class BetaService : IBetaService
{
    readonly Lazy<IBetaServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBetaServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IBetaService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BetaService(this._client.WithOptions(modifier));
    }

    public BetaService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BetaServiceWithRawResponse(client.WithRawResponse));
        _models = new(() => new Beta::ModelService(client));
        _messages = new(() => new Beta::MessageService(client));
        _files = new(() => new Beta::FileService(client));
        _skills = new(() => new Beta::SkillService(client));
    }

    readonly Lazy<Beta::IModelService> _models;
    public Beta::IModelService Models
    {
        get { return _models.Value; }
    }

    readonly Lazy<Beta::IMessageService> _messages;
    public Beta::IMessageService Messages
    {
        get { return _messages.Value; }
    }

    readonly Lazy<Beta::IFileService> _files;
    public Beta::IFileService Files
    {
        get { return _files.Value; }
    }

    readonly Lazy<Beta::ISkillService> _skills;
    public Beta::ISkillService Skills
    {
        get { return _skills.Value; }
    }
}

/// <inheritdoc/>
public sealed class BetaServiceWithRawResponse : IBetaServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBetaServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BetaServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BetaServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _models = new(() => new Beta::ModelServiceWithRawResponse(client));
        _messages = new(() => new Beta::MessageServiceWithRawResponse(client));
        _files = new(() => new Beta::FileServiceWithRawResponse(client));
        _skills = new(() => new Beta::SkillServiceWithRawResponse(client));
    }

    readonly Lazy<Beta::IModelServiceWithRawResponse> _models;
    public Beta::IModelServiceWithRawResponse Models
    {
        get { return _models.Value; }
    }

    readonly Lazy<Beta::IMessageServiceWithRawResponse> _messages;
    public Beta::IMessageServiceWithRawResponse Messages
    {
        get { return _messages.Value; }
    }

    readonly Lazy<Beta::IFileServiceWithRawResponse> _files;
    public Beta::IFileServiceWithRawResponse Files
    {
        get { return _files.Value; }
    }

    readonly Lazy<Beta::ISkillServiceWithRawResponse> _skills;
    public Beta::ISkillServiceWithRawResponse Skills
    {
        get { return _skills.Value; }
    }
}
