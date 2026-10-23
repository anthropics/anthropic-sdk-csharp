using System.Threading.Tasks;
using Anthropic.Models.Beta.Organization.ClaudeTag;

namespace Anthropic.Tests.Services.Beta.Organization.ClaudeTag;

public class SlackChannelServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaClaudeTagSlackChannel = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeTag.SlackChannels.Create(
                new()
                {
                    Slack = new() { ChannelID = "xx", WorkspaceID = "xx" },
                },
                TestContext.Current.CancellationToken
            );
        betaClaudeTagSlackChannel.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaClaudeTagSlackChannel = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeTag.SlackChannels.Retrieve(
                "slch_01SvpyRQK3nN6eH9uhRA7n1q",
                new(),
                TestContext.Current.CancellationToken
            );
        betaClaudeTagSlackChannel.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaClaudeTagSlackChannel = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeTag.SlackChannels.Update(
                "slch_01SvpyRQK3nN6eH9uhRA7n1q",
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
        betaClaudeTagSlackChannel.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeTag.SlackChannels.List(
                new() { SlackWorkspaceID = "slack_workspace_id" },
                TestContext.Current.CancellationToken
            );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var betaClaudeTagDeletedSlackChannel = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeTag.SlackChannels.Delete(
                "slch_01SvpyRQK3nN6eH9uhRA7n1q",
                new(),
                TestContext.Current.CancellationToken
            );
        betaClaudeTagDeletedSlackChannel.Validate();
    }
}
