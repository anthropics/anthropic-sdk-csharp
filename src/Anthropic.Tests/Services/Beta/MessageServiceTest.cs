using System.Threading.Tasks;
using Anthropic.Models.Beta.Messages;
using Anthropic.Tests;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Services.Beta;

public class MessageServiceTest
{
    [Theory(Skip = "prism validates based on the non-beta endpoint")]
    [AnthropicTestClients]
    public async Task Create_Works(IAnthropicClient client)
    {
        var betaMessage = await client.Beta.Messages.Create(
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

    [Theory(Skip = "prism validates based on the non-beta endpoint")]
    [AnthropicTestClients]
    public async Task CreateStreaming_Works(IAnthropicClient client)
    {
        var stream = client.Beta.Messages.CreateStreaming(
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

    [Theory(Skip = "prism validates based on the non-beta endpoint")]
    [AnthropicTestClients]
    public async Task CountTokens_Works(IAnthropicClient client)
    {
        var betaMessageTokensCount = await client.Beta.Messages.CountTokens(
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
