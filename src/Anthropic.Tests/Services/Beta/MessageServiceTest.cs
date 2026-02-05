using System.Threading.Tasks;
using Anthropic.Models.Beta.Messages;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Services.Beta;

public class MessageServiceTest : TestBase
{
    [Fact(Skip = "prism validates based on the non-beta endpoint")]
    public async Task Create_Works()
    {
        var betaMessage = await this.client.Beta.Messages.Create(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "Hello, world", Role = Role.User }],
                Model = Messages::Model.ClaudeOpus4_6,
            },
            TestContext.Current.CancellationToken
        );
        betaMessage.Validate();
    }

    [Fact(Skip = "prism validates based on the non-beta endpoint")]
    public async Task CreateStreaming_Works()
    {
        var stream = this.client.Beta.Messages.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "Hello, world", Role = Role.User }],
                Model = Messages::Model.ClaudeOpus4_6,
            },
            TestContext.Current.CancellationToken
        );

        await foreach (var betaMessage in stream)
        {
            betaMessage.Validate();
        }
    }

    [Fact(Skip = "prism validates based on the non-beta endpoint")]
    public async Task CountTokens_Works()
    {
        var betaMessageTokensCount = await this.client.Beta.Messages.CountTokens(
            new()
            {
                Messages = [new() { Content = "string", Role = Role.User }],
                Model = Messages::Model.ClaudeOpus4_6,
            },
            TestContext.Current.CancellationToken
        );
        betaMessageTokensCount.Validate();
    }
}
