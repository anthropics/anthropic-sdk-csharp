using System;
using Anthropic.Core;
using Beta = Anthropic.Services.Beta;

namespace Anthropic.Services;

/// <inheritdoc />
public sealed class BetaService : IBetaService
{
    /// <inheritdoc/>
    public IBetaService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BetaService(this._client.WithOptions(modifier));
    }

    readonly IAnthropicClient _client;

    public BetaService(IAnthropicClient client)
    {
        _client = client;
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
