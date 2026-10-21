using System.Threading.Tasks;
using Anthropic.Models.Beta.Messages;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Services.Beta;

public class MessageServiceTest : TestBase
{
    public async Task Create_Works()
    {
        var betaMessage = await this.client.Beta.Messages.Create(
            new()
            {
                MaxTokens = 1024,
                Messages = [new BetaUserMessageParam("Hello, world")],
                Model = Model.ClaudeOpus5_5,
            },
            TestContext.Current.CancellationToken
        );
        betaMessage.Validate();
    }

    public async Task CreateStreaming_Works()
    {
        var stream = this.client.Beta.Messages.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new BetaUserMessageParam("Hello, world")],
                Model = Model.ClaudeOpus5_5,
            },
            TestContext.Current.CancellationToken
        );

        await foreach (var betaMessage in stream)
        {
            betaMessage.Validate();
        }
    }

    public async Task CountTokens_Works()
    {
        var betaMessageTokensCount = await this.client.Beta.Messages.CountTokens(
            new()
            {
                Messages = [new BetaUserMessageParam("Hello, world")],
                Model = Model.ClaudeOpus5_5,
            },
            TestContext.Current.CancellationToken
        );
        betaMessageTokensCount.Validate();
    }
}
