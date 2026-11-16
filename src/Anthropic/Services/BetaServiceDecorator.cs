using System;
using Anthropic.Core;
using Beta = Anthropic.Services.Beta;

namespace Anthropic.Services;

/// <summary>
/// Base class for wrappers of this service. Every subresource property calls
/// <see cref="Subresource"/>. To block a subresource, override that method, and also
/// WithOptions and WithRawResponse, which return the unwrapped service.
/// </summary>
internal abstract class BetaServiceDecorator : IBetaService
{
    protected IBetaService InnerService { get; }

    protected BetaServiceDecorator(IBetaService inner)
    {
        InnerService = inner;
    }

    protected virtual T Subresource<T>(string name, Func<IBetaService, T> get)
    {
        return get(InnerService);
    }

    public virtual IBetaServiceWithRawResponse WithRawResponse
    {
        get { return InnerService.WithRawResponse; }
    }

    public virtual IBetaService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return InnerService.WithOptions(modifier);
    }

    public Beta::IModelService Models
    {
        get { return Subresource(nameof(Models), service => service.Models); }
    }

    public Beta::IMessageService Messages
    {
        get { return Subresource(nameof(Messages), service => service.Messages); }
    }

    public Beta::IAgentService Agents
    {
        get { return Subresource(nameof(Agents), service => service.Agents); }
    }

    public Beta::IEnvironmentService Environments
    {
        get { return Subresource(nameof(Environments), service => service.Environments); }
    }

    public Beta::ISessionService Sessions
    {
        get { return Subresource(nameof(Sessions), service => service.Sessions); }
    }

    public Beta::IDeploymentService Deployments
    {
        get { return Subresource(nameof(Deployments), service => service.Deployments); }
    }

    public Beta::IDeploymentRunService DeploymentRuns
    {
        get { return Subresource(nameof(DeploymentRuns), service => service.DeploymentRuns); }
    }

    public Beta::IVaultService Vaults
    {
        get { return Subresource(nameof(Vaults), service => service.Vaults); }
    }

    public Beta::IMemoryStoreService MemoryStores
    {
        get { return Subresource(nameof(MemoryStores), service => service.MemoryStores); }
    }

    public Beta::IFileService Files
    {
        get { return Subresource(nameof(Files), service => service.Files); }
    }

    public Beta::ISkillService Skills
    {
        get { return Subresource(nameof(Skills), service => service.Skills); }
    }

    public Beta::IWebhookService Webhooks
    {
        get { return Subresource(nameof(Webhooks), service => service.Webhooks); }
    }

    public Beta::IUserProfileService UserProfiles
    {
        get { return Subresource(nameof(UserProfiles), service => service.UserProfiles); }
    }

    public Beta::IDreamService Dreams
    {
        get { return Subresource(nameof(Dreams), service => service.Dreams); }
    }

    public Beta::ITunnelService Tunnels
    {
        get { return Subresource(nameof(Tunnels), service => service.Tunnels); }
    }

    public Beta::IOrganizationService Organization
    {
        get { return Subresource(nameof(Organization), service => service.Organization); }
    }
}

internal abstract class BetaServiceWithRawResponseDecorator : IBetaServiceWithRawResponse
{
    protected IBetaServiceWithRawResponse InnerService { get; }

    protected BetaServiceWithRawResponseDecorator(IBetaServiceWithRawResponse inner)
    {
        InnerService = inner;
    }

    protected virtual T Subresource<T>(string name, Func<IBetaServiceWithRawResponse, T> get)
    {
        return get(InnerService);
    }

    public virtual IBetaServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return InnerService.WithOptions(modifier);
    }

    public Beta::IModelServiceWithRawResponse Models
    {
        get { return Subresource(nameof(Models), service => service.Models); }
    }

    public Beta::IMessageServiceWithRawResponse Messages
    {
        get { return Subresource(nameof(Messages), service => service.Messages); }
    }

    public Beta::IAgentServiceWithRawResponse Agents
    {
        get { return Subresource(nameof(Agents), service => service.Agents); }
    }

    public Beta::IEnvironmentServiceWithRawResponse Environments
    {
        get { return Subresource(nameof(Environments), service => service.Environments); }
    }

    public Beta::ISessionServiceWithRawResponse Sessions
    {
        get { return Subresource(nameof(Sessions), service => service.Sessions); }
    }

    public Beta::IDeploymentServiceWithRawResponse Deployments
    {
        get { return Subresource(nameof(Deployments), service => service.Deployments); }
    }

    public Beta::IDeploymentRunServiceWithRawResponse DeploymentRuns
    {
        get { return Subresource(nameof(DeploymentRuns), service => service.DeploymentRuns); }
    }

    public Beta::IVaultServiceWithRawResponse Vaults
    {
        get { return Subresource(nameof(Vaults), service => service.Vaults); }
    }

    public Beta::IMemoryStoreServiceWithRawResponse MemoryStores
    {
        get { return Subresource(nameof(MemoryStores), service => service.MemoryStores); }
    }

    public Beta::IFileServiceWithRawResponse Files
    {
        get { return Subresource(nameof(Files), service => service.Files); }
    }

    public Beta::ISkillServiceWithRawResponse Skills
    {
        get { return Subresource(nameof(Skills), service => service.Skills); }
    }

    public Beta::IWebhookServiceWithRawResponse Webhooks
    {
        get { return Subresource(nameof(Webhooks), service => service.Webhooks); }
    }

    public Beta::IUserProfileServiceWithRawResponse UserProfiles
    {
        get { return Subresource(nameof(UserProfiles), service => service.UserProfiles); }
    }

    public Beta::IDreamServiceWithRawResponse Dreams
    {
        get { return Subresource(nameof(Dreams), service => service.Dreams); }
    }

    public Beta::ITunnelServiceWithRawResponse Tunnels
    {
        get { return Subresource(nameof(Tunnels), service => service.Tunnels); }
    }

    public Beta::IOrganizationServiceWithRawResponse Organization
    {
        get { return Subresource(nameof(Organization), service => service.Organization); }
    }
}
