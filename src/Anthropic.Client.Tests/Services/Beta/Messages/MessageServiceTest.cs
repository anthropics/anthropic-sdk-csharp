using System.Threading.Tasks;
using Anthropic.Client.Models.Beta.Messages.BetaMessageParamProperties;
using Anthropic.Client.Models.Messages;

namespace Anthropic.Client.Tests.Services.Beta.Messages;

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
                Model = Model.Claude3_7SonnetLatest,
            }
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
                Model = Model.Claude3_7SonnetLatest,
            }
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
                Model = Model.Claude3_7SonnetLatest,
            }
        );
        betaMessageTokensCount.Validate();
    }
}
