using System;
using Anthropic.Client.Core;
using Anthropic.Client.Services.Beta.Files;
using Anthropic.Client.Services.Beta.Messages;
using Anthropic.Client.Services.Beta.Models;
using Anthropic.Client.Services.Beta.Skills;

namespace Anthropic.Client.Services.Beta;

public sealed class BetaService : IBetaService
{
    public IBetaService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BetaService(this._client.WithOptions(modifier));
    }

    readonly IAnthropicClient _client;

    public BetaService(IAnthropicClient client)
    {
        _client = client;
        _models = new(() => new ModelService(client));
        _messages = new(() => new MessageService(client));
        _files = new(() => new FileService(client));
        _skills = new(() => new SkillService(client));
    }

    readonly Lazy<IModelService> _models;
    public IModelService Models
    {
        get { return _models.Value; }
    }

    readonly Lazy<IMessageService> _messages;
    public IMessageService Messages
    {
        get { return _messages.Value; }
    }

    readonly Lazy<IFileService> _files;
    public IFileService Files
    {
        get { return _files.Value; }
    }

    readonly Lazy<ISkillService> _skills;
    public ISkillService Skills
    {
        get { return _skills.Value; }
    }
}
