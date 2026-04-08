using System.Threading.Tasks;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Services.Beta;

public class AgentServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaManagedAgentsAgent = await this.client.Beta.Agents.Create(
            new() { Model = BetaManagedAgentsModel.ClaudeSonnet4_6, Name = "My First Agent" },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsAgent.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task Retrieve_Works()
    {
        var betaManagedAgentsAgent = await this.client.Beta.Agents.Retrieve(
            "agent_011CZkYpogX7uDKUyvBTophP",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsAgent.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaManagedAgentsAgent = await this.client.Beta.Agents.Update(
            "agent_011CZkYpogX7uDKUyvBTophP",
            new() { Version = 1 },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsAgent.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Agents.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var betaManagedAgentsAgent = await this.client.Beta.Agents.Archive(
            "agent_011CZkYpogX7uDKUyvBTophP",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsAgent.Validate();
    }
}
