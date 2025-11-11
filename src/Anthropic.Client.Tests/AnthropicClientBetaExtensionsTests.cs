using Anthropic.Client;
using Anthropic.Client.Services.Beta;
using Anthropic.Client.Services.Beta.Messages;
using System;
using System.Threading.Tasks;

#nullable enable
#pragma warning disable MEAI001

namespace Microsoft.Extensions.AI.Tests;

public class AnthropicClientBetaExtensionsTests : AnthropicClientExtensionsTestsBase
{
    protected override IChatClient CreateChatClient(AnthropicClient client, string? modelId) =>
        client.Beta.Messages.AsIChatClient(modelId);

    [Fact]
    public void AsIChatClient_ReturnsValidChatClient()
    {
        var client = new AnthropicClient { APIKey = "test-key" }.Beta;
        Assert.NotNull(client.AsIChatClient("claude-haiku-4-5"));
    }

    [Fact]
    public void AsIChatClient_MessageService_ReturnsValidChatClient()
    {
        var client = new AnthropicClient { APIKey = "test-key" }.Beta;
        Assert.NotNull(client.Messages.AsIChatClient("claude-haiku-4-5"));
    }

    [Fact]
    public void AsIChatClient_ThrowsOnNullClient()
    {
        Anthropic.Client.Services.IBetaService client = null!;
        Assert.Throws<ArgumentNullException>(() => client.AsIChatClient());
    }

    [Fact]
    public void AsIChatClient_GetService_ReturnsMessageService()
    {
        var client = new AnthropicClient { APIKey = "test-key" };
        IChatClient chatClient = CreateChatClient(client, "claude-haiku-4-5");

        var messageService = chatClient.GetService<IMessageService>();

        Assert.NotNull(messageService);
        Assert.Same(client.Beta.Messages, messageService);
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

        var rawMessage = response.RawRepresentation as Anthropic.Client.Models.Beta.Messages.BetaMessage;
        Assert.NotNull(rawMessage);
        Assert.Equal("msg_raw_01", rawMessage.ID);
    }

    [Fact]
    public async Task GetResponseAsync_WithHostedMcpServerTool()
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
                        "text": "Use the MCP server"
                    }]
                }],
                "mcp_servers": [{
                    "name": "mcp",
                    "type": "url",
                    "url": "https://mcp.example.com/server"
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_mcp_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I can help with that using the MCP server tools."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 20,
                    "output_tokens": 15
                }
            }
            """);

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var options = new ChatOptions
        {
            Tools = [new HostedMcpServerTool("my-mcp-server", new Uri("https://mcp.example.com/server"))]
        };

        ChatResponse response = await chatClient.GetResponseAsync("Use the MCP server", options);
        Assert.NotNull(response);

        var textContent = response.Messages[0].Contents[0] as TextContent;
        Assert.NotNull(textContent);
        Assert.Contains("MCP server", textContent.Text);
    }

    [Fact]
    public async Task GetResponseAsync_WithHostedMcpServerToolAndAllowedTools()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [
                        {
                            "type": "text",
                            "text": "Use specific tools"
                        }
                    ]
                }],
                "mcp_servers": [{
                    "name": "mcp",
                    "type": "url",
                    "url": "https://mcp.example.com/server",
                    "tool_configuration": {
                        "enabled": true,
                        "allowed_tools": ["tool1", "tool2", "tool3"]
                    }
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_mcp_02",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I'll use the allowed tools from the MCP server."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 25,
                    "output_tokens": 18
                }
            }
            """);

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var options = new ChatOptions
        {
            Tools = [new HostedMcpServerTool("my-mcp-server",  new Uri("https://mcp.example.com/server"))
            {
                AllowedTools = ["tool1", "tool2", "tool3"]
            }]
        };

        ChatResponse response = await chatClient.GetResponseAsync("Use specific tools", options);
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithMultipleHostedMcpServerTools()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [
                        {
                            "type": "text",
                            "text": "Use multiple servers"
                        }
                    ]
                }],
                "mcp_servers": [
                    {
                        "name": "mcp",
                        "type": "url",
                        "url": "https://server1.example.com/"
                    },
                    {
                        "name": "mcp",
                        "type": "url",
                        "url": "https://server2.example.com/",
                        "tool_configuration": {
                            "enabled": true,
                            "allowed_tools": ["tool_a", "tool_b"]
                        }
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_mcp_03",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I'll use tools from multiple MCP servers."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 30,
                    "output_tokens": 20
                }
            }
            """);

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var options = new ChatOptions
        {
            Tools =
            [
                new HostedMcpServerTool("server1", new Uri("https://server1.example.com")),
                new HostedMcpServerTool("server2", new Uri("https://server2.example.com")) { AllowedTools = ["tool_a", "tool_b"] }
            ]
        };

        ChatResponse response = await chatClient.GetResponseAsync("Use multiple servers", options);
        Assert.NotNull(response);
    }
}
