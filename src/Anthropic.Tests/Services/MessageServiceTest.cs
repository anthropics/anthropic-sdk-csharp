using System.Threading.Tasks;
using Anthropic.Bedrock;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Services;

public class MessageServiceTest
{
    [Theory]
    [AnthropicTestClients]
    [AnthropicTestData(TestSupportTypes.Anthropic, "Claude3_7SonnetLatest")]
    [AnthropicTestData(TestSupportTypes.Foundry, "claude-sonnet-4-5")]
    [AnthropicTestData(TestSupportTypes.Bedrock, "global.anthropic.claude-haiku-4-5-20251001-v1:0")]
    public async Task Create_Works(IAnthropicClient client, string modelName)
    {
        var message = await client.Messages.Create(
            new MessageCreateParams()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "Hello, world", Role = Role.User }],
                Model = modelName,
            }
        );
        message.Validate();
    }

    [Theory]
    [AnthropicTestClients]
    [AnthropicTestData(TestSupportTypes.Anthropic, "Claude3_7SonnetLatest")]
    [AnthropicTestData(TestSupportTypes.Foundry, "claude-sonnet-4-5")]
    [AnthropicTestData(TestSupportTypes.Bedrock, "global.anthropic.claude-haiku-4-5-20251001-v1:0")]
    public async Task CreateStreaming_Works(IAnthropicClient client, string modelName)
    {
        var stream = client.Messages.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "Hello, world", Role = Role.User }],
                Model = modelName,
            }
        );

        await foreach (var message in stream)
        {
            message.Validate();
        }
    }

    [Theory]
    [AnthropicTestClients(TestSupportTypes.Bedrock)]
    [AnthropicTestData(TestSupportTypes.Bedrock, "global.anthropic.claude-haiku-4-5-20251001-v1:0", true)]
    [AnthropicTestData(TestSupportTypes.Bedrock, "global.anthropic.claude-haiku-4-5-20251001-v1:0", false)]
    public async Task CreateStreaming_BedrockAsyncProjection_Works(AnthropicBedrockClient client, string modelName, bool useAsyncProjection)
    {
        client.AsyncStreaming = useAsyncProjection;
        var stream = client.Messages.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "Hello, world", Role = Role.User }],
                Model = modelName,
            }
        );

        await foreach (var message in stream)
        {
            message.Validate();
        }
    }

    [Theory]
    [AnthropicTestClients]
    [AnthropicTestData(TestSupportTypes.Anthropic, "Claude3_7SonnetLatest")]
    [AnthropicTestData(TestSupportTypes.Foundry, "claude-sonnet-4-5")]
    public async Task CountTokens_Works(IAnthropicClient client, string modelName)
    {
        var messageTokensCount = await client.Messages.CountTokens(
            new() { Messages = [new() { Content = "string", Role = Role.User }], Model = modelName }
        );
        messageTokensCount.Validate();
    }
}
