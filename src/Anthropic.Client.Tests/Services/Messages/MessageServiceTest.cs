using System.Threading.Tasks;
using Anthropic.Client.Models.Messages;
using Anthropic.Client.Models.Messages.MessageParamProperties;

namespace Anthropic.Client.Tests.Services.Messages;

public class MessageServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var message = await this.client.Messages.Create(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "Hello, world", Role = Role.User }],
                Model = Model.Claude3_7SonnetLatest,
            }
        );
        message.Validate();
    }

    [Fact]
    public async Task CreateStreaming_Works()
    {
        var stream = this.client.Messages.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "Hello, world", Role = Role.User }],
                Model = Model.Claude3_7SonnetLatest,
            }
        );

        await foreach (var message in stream)
        {
            message.Validate();
        }
    }

    [Fact]
    public async Task CountTokens_Works()
    {
        var messageTokensCount = await this.client.Messages.CountTokens(
            new()
            {
                Messages = [new() { Content = "string", Role = Role.User }],
                Model = Model.Claude3_7SonnetLatest,
            }
        );
        messageTokensCount.Validate();
    }
}
