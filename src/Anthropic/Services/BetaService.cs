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
        _agents = new(() => new Beta::AgentService(client));
        _environments = new(() => new Beta::EnvironmentService(client));
        _sessions = new(() => new Beta::SessionService(client));
        _vaults = new(() => new Beta::VaultService(client));
        _memoryStores = new(() => new Beta::MemoryStoreService(client));
        _files = new(() => new Beta::FileService(client));
        _skills = new(() => new Beta::SkillService(client));
        _userProfiles = new(() => new Beta::UserProfileService(client));
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

    readonly Lazy<Beta::IAgentService> _agents;
    public Beta::IAgentService Agents
    {
        get { return _agents.Value; }
    }

    readonly Lazy<Beta::IEnvironmentService> _environments;
    public Beta::IEnvironmentService Environments
    {
        get { return _environments.Value; }
    }

    readonly Lazy<Beta::ISessionService> _sessions;
    public Beta::ISessionService Sessions
    {
        get { return _sessions.Value; }
    }

    readonly Lazy<Beta::IVaultService> _vaults;
    public Beta::IVaultService Vaults
    {
        get { return _vaults.Value; }
    }

    readonly Lazy<Beta::IMemoryStoreService> _memoryStores;
    public Beta::IMemoryStoreService MemoryStores
    {
        get { return _memoryStores.Value; }
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

    readonly Lazy<Beta::IUserProfileService> _userProfiles;
    public Beta::IUserProfileService UserProfiles
    {
        get { return _userProfiles.Value; }
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
        _agents = new(() => new Beta::AgentServiceWithRawResponse(client));
        _environments = new(() => new Beta::EnvironmentServiceWithRawResponse(client));
        _sessions = new(() => new Beta::SessionServiceWithRawResponse(client));
        _vaults = new(() => new Beta::VaultServiceWithRawResponse(client));
        _memoryStores = new(() => new Beta::MemoryStoreServiceWithRawResponse(client));
        _files = new(() => new Beta::FileServiceWithRawResponse(client));
        _skills = new(() => new Beta::SkillServiceWithRawResponse(client));
        _userProfiles = new(() => new Beta::UserProfileServiceWithRawResponse(client));
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

    readonly Lazy<Beta::IAgentServiceWithRawResponse> _agents;
    public Beta::IAgentServiceWithRawResponse Agents
    {
        get { return _agents.Value; }
    }

    readonly Lazy<Beta::IEnvironmentServiceWithRawResponse> _environments;
    public Beta::IEnvironmentServiceWithRawResponse Environments
    {
        get { return _environments.Value; }
    }

    readonly Lazy<Beta::ISessionServiceWithRawResponse> _sessions;
    public Beta::ISessionServiceWithRawResponse Sessions
    {
        get { return _sessions.Value; }
    }

    readonly Lazy<Beta::IVaultServiceWithRawResponse> _vaults;
    public Beta::IVaultServiceWithRawResponse Vaults
    {
        get { return _vaults.Value; }
    }

    readonly Lazy<Beta::IMemoryStoreServiceWithRawResponse> _memoryStores;
    public Beta::IMemoryStoreServiceWithRawResponse MemoryStores
    {
        get { return _memoryStores.Value; }
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

    readonly Lazy<Beta::IUserProfileServiceWithRawResponse> _userProfiles;
    public Beta::IUserProfileServiceWithRawResponse UserProfiles
    {
        get { return _userProfiles.Value; }
    }
}
