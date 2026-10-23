using System.Threading.Tasks;
using Anthropic.Models.Beta.Organization.ClaudeTag;

namespace Anthropic.Tests.Services.Beta.Organization.ClaudeTag;

public class SlackWorkspaceServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaClaudeTagSlackWorkspace = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeTag.SlackWorkspaces.Retrieve(
                "slws_01Hq8TzW5mKc2YbX7vNd4RfJ",
                new(),
                TestContext.Current.CancellationToken
            );
        betaClaudeTagSlackWorkspace.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaClaudeTagSlackWorkspace = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeTag.SlackWorkspaces.Update(
                "slws_01Hq8TzW5mKc2YbX7vNd4RfJ",
                new()
                {
                    Settings = new()
                    {
                        Enabled = true,
                        EnvironmentID = "x",
                        GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
                        Instructions = "instructions",
                        Model = "x",
                    },
                },
                TestContext.Current.CancellationToken
            );
        betaClaudeTagSlackWorkspace.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeTag.SlackWorkspaces.List(
                new(),
                TestContext.Current.CancellationToken
            );
        page.Validate();
    }
}
