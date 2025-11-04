using System;
using System.Threading.Tasks;
using Anthropic.Client;

#nullable enable

namespace Microsoft.Extensions.AI.Tests;

public class AnthropicClientExtensionsTests : AnthropicClientExtensionsTestsBase
{
    protected override IChatClient CreateChatClient(AnthropicClient client, string? modelId) =>
        client.AsIChatClient(modelId);

    [Fact]
    public void AsIChatClient_ReturnsValidChatClient()
    {
        AnthropicClient client = new() { APIKey = "test-key" };
        Assert.NotNull(client.AsIChatClient("claude-haiku-4-5"));
    }

    [Fact]
    public void AsIChatClient_MessageService_ReturnsValidChatClient()
    {
        AnthropicClient client = new() { APIKey = "test-key" };
        Assert.NotNull(client.Messages.AsIChatClient("claude-haiku-4-5"));
    }

    [Fact]
    public void AsIChatClient_ThrowsOnNullClient()
    {
        IAnthropicClient client = null!;
        Assert.Throws<ArgumentNullException>(() => client.AsIChatClient());
    }

    [Fact]
    public void AsIChatClient_GetService_ReturnsMessageService()
    {
        AnthropicClient client = new() { APIKey = "test-key" };
        IChatClient chatClient = CreateChatClient(client, "claude-haiku-4-5");

        var messageService = chatClient.GetService<Anthropic.Client.Services.Messages.IMessageService>();

        Assert.NotNull(messageService);
        Assert.Same(client.Messages, messageService);
    }

    [Fact]
    public async Task GetResponseAsync_WithRawRepresentation()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Test"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_raw_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Response"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 10,
                    "output_tokens": 5
                }
            }
            """);

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatResponse response = await chatClient.GetResponseAsync("Test");
        Assert.NotNull(response);
        Assert.NotNull(response.RawRepresentation);

        var rawMessage = response.RawRepresentation as Anthropic.Client.Models.Messages.Message;
        Assert.NotNull(rawMessage);
        Assert.Equal("msg_raw_01", rawMessage.ID);
    }
}
