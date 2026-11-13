using System;
using System.Collections.Generic;
using Anthropic.Services;

namespace Anthropic.Tests.Core;

public class BetaServiceDecoratorTest : TestBase
{
    private sealed class RecordingDecorator : BetaServiceDecorator
    {
        private readonly List<string> _names;

        public RecordingDecorator(IBetaService inner, List<string> names)
            : base(inner)
        {
            _names = names;
        }

        protected override T Subresource<T>(string name, Func<IBetaService, T> get)
        {
            _names.Add(name);
            return base.Subresource(name, get);
        }
    }

    private sealed class RawRecordingDecorator : BetaServiceWithRawResponseDecorator
    {
        private readonly List<string> _names;

        public RawRecordingDecorator(IBetaServiceWithRawResponse inner, List<string> names)
            : base(inner)
        {
            _names = names;
        }

        protected override T Subresource<T>(string name, Func<IBetaServiceWithRawResponse, T> get)
        {
            _names.Add(name);
            return base.Subresource(name, get);
        }
    }

    [Fact]
    public void Properties_CallSubresource()
    {
        var inner = this.client.Beta;
        var names = new List<string>();
        var decorator = new RecordingDecorator(inner, names);

        Assert.Same(inner.Models, decorator.Models);
        Assert.Same(inner.Messages, decorator.Messages);
        Assert.Same(inner.Agents, decorator.Agents);
        Assert.Same(inner.Environments, decorator.Environments);
        Assert.Same(inner.Sessions, decorator.Sessions);
        Assert.Same(inner.Deployments, decorator.Deployments);
        Assert.Same(inner.DeploymentRuns, decorator.DeploymentRuns);
        Assert.Same(inner.Vaults, decorator.Vaults);
        Assert.Same(inner.MemoryStores, decorator.MemoryStores);
        Assert.Same(inner.Files, decorator.Files);
        Assert.Same(inner.Skills, decorator.Skills);
        Assert.Same(inner.Webhooks, decorator.Webhooks);
        Assert.Same(inner.UserProfiles, decorator.UserProfiles);
        Assert.Same(inner.Dreams, decorator.Dreams);
        Assert.Same(inner.Tunnels, decorator.Tunnels);
        Assert.Same(inner.Organization, decorator.Organization);
        Assert.Equal(
            new[]
            {
                nameof(inner.Models),
                nameof(inner.Messages),
                nameof(inner.Agents),
                nameof(inner.Environments),
                nameof(inner.Sessions),
                nameof(inner.Deployments),
                nameof(inner.DeploymentRuns),
                nameof(inner.Vaults),
                nameof(inner.MemoryStores),
                nameof(inner.Files),
                nameof(inner.Skills),
                nameof(inner.Webhooks),
                nameof(inner.UserProfiles),
                nameof(inner.Dreams),
                nameof(inner.Tunnels),
                nameof(inner.Organization),
            },
            names
        );
    }

    [Fact]
    public void RawProperties_CallSubresource()
    {
        var inner = this.client.WithRawResponse.Beta;
        var names = new List<string>();
        var decorator = new RawRecordingDecorator(inner, names);

        Assert.Same(inner.Models, decorator.Models);
        Assert.Same(inner.Messages, decorator.Messages);
        Assert.Same(inner.Agents, decorator.Agents);
        Assert.Same(inner.Environments, decorator.Environments);
        Assert.Same(inner.Sessions, decorator.Sessions);
        Assert.Same(inner.Deployments, decorator.Deployments);
        Assert.Same(inner.DeploymentRuns, decorator.DeploymentRuns);
        Assert.Same(inner.Vaults, decorator.Vaults);
        Assert.Same(inner.MemoryStores, decorator.MemoryStores);
        Assert.Same(inner.Files, decorator.Files);
        Assert.Same(inner.Skills, decorator.Skills);
        Assert.Same(inner.Webhooks, decorator.Webhooks);
        Assert.Same(inner.UserProfiles, decorator.UserProfiles);
        Assert.Same(inner.Dreams, decorator.Dreams);
        Assert.Same(inner.Tunnels, decorator.Tunnels);
        Assert.Same(inner.Organization, decorator.Organization);
        Assert.Equal(
            new[]
            {
                nameof(inner.Models),
                nameof(inner.Messages),
                nameof(inner.Agents),
                nameof(inner.Environments),
                nameof(inner.Sessions),
                nameof(inner.Deployments),
                nameof(inner.DeploymentRuns),
                nameof(inner.Vaults),
                nameof(inner.MemoryStores),
                nameof(inner.Files),
                nameof(inner.Skills),
                nameof(inner.Webhooks),
                nameof(inner.UserProfiles),
                nameof(inner.Dreams),
                nameof(inner.Tunnels),
                nameof(inner.Organization),
            },
            names
        );
    }
}
