using Anthropic;
using Anthropic.Services;
using System;
using System.Threading.Tasks;

#pragma warning disable MEAI001

namespace Microsoft.Extensions.AI.Tests;

public class AnthropicClientBetaExtensionsTests : AnthropicClientExtensionsTestsBase
{
    protected override IChatClient CreateChatClient(AnthropicClient client, string? modelId) =>
        client.Beta.AsIChatClient(modelId);

    [Fact]
    public void AsIChatClient_ReturnsValidChatClient()
    {
        var client = new AnthropicClient { APIKey = "test-key" }.Beta;
        Assert.NotNull(client.AsIChatClient("claude-haiku-4-5"));
    }

    [Fact]
    public void AsIChatClient_ThrowsOnNullClient()
    {
        Anthropic.Services.IBetaService client = null!;
        Assert.Throws<ArgumentNullException>(() => client.AsIChatClient());
    }

    [Fact]
    public void AsIChatClient_GetService_ReturnsClient()
    {
        var client = new AnthropicClient { APIKey = "test-key" };
        IChatClient chatClient = CreateChatClient(client, "claude-haiku-4-5");

        Assert.Same(client.Beta, chatClient.GetService<IBetaService>());
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

        var rawMessage = response.RawRepresentation as Anthropic.Models.Beta.Messages.BetaMessage;
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

    [Fact]
    public async Task GetResponseAsync_VariousContentBlocks_HaveRawRepresentation()
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
                        "text": "Test various content types"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_multi_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [
                    {
                        "type": "text",
                        "text": "Here's my response"
                    },
                    {
                        "type": "thinking",
                        "thinking": "Let me think...",
                        "signature": "sig123"
                    },
                    {
                        "type": "tool_use",
                        "id": "tool_call_1",
                        "name": "test_tool",
                        "input": {}
                    }
                ],
                "stop_reason": "tool_use",
                "usage": {
                    "input_tokens": 20,
                    "output_tokens": 30
                }
            }
            """);

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatResponse response = await chatClient.GetResponseAsync("Test various content types");

        var textContent = response.Messages[0].Contents[0] as TextContent;
        Assert.NotNull(textContent);
        Assert.NotNull(textContent.RawRepresentation);
        Assert.IsType<Anthropic.Models.Beta.Messages.BetaTextBlock>(textContent.RawRepresentation);

        var thinkingContent = response.Messages[0].Contents[1] as TextReasoningContent;
        Assert.NotNull(thinkingContent);
        Assert.NotNull(thinkingContent.RawRepresentation);
        Assert.IsType<Anthropic.Models.Beta.Messages.BetaThinkingBlock>(thinkingContent.RawRepresentation);

        var toolCall = response.Messages[0].Contents[2] as FunctionCallContent;
        Assert.NotNull(toolCall);
        Assert.NotNull(toolCall.RawRepresentation);
        Assert.IsType<Anthropic.Models.Beta.Messages.BetaToolUseBlock>(toolCall.RawRepresentation);
    }

    [Fact]
    public async Task GetResponseAsync_McpToolUseBlock_CreatesCorrectContent()
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
                        "text": "Use MCP tool"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_mcp_tool_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "mcp_tool_use",
                    "id": "mcp_call_123",
                    "name": "search",
                    "server_name": "my-mcp-server",
                    "input": {
                        "query": "test query"
                    }
                }],
                "stop_reason": "tool_use",
                "usage": {
                    "input_tokens": 10,
                    "output_tokens": 15
                }
            }
            """);

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");
        ChatResponse response = await chatClient.GetResponseAsync("Use MCP tool");

        var mcpToolCall = response.Messages[0].Contents[0] as McpServerToolCallContent;
        Assert.NotNull(mcpToolCall);
        Assert.Equal("mcp_call_123", mcpToolCall.CallId);
        Assert.Equal("search", mcpToolCall.ToolName);
        Assert.Equal("my-mcp-server", mcpToolCall.ServerName);
        Assert.NotNull(mcpToolCall.Arguments);
        Assert.True(mcpToolCall.Arguments.ContainsKey("query"));
        Assert.NotNull(mcpToolCall.RawRepresentation);
        Assert.IsType<Anthropic.Models.Beta.Messages.BetaMCPToolUseBlock>(mcpToolCall.RawRepresentation);
    }

    [Fact]
    public async Task GetResponseAsync_McpToolResultBlock_WithTextContent()
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
                "id": "msg_mcp_result_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "mcp_tool_result",
                    "tool_use_id": "mcp_call_456",
                    "is_error": false,
                    "content": [{
                        "type": "text",
                        "text": "Result from MCP tool"
                    }]
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 10,
                    "output_tokens": 15
                }
            }
            """);

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");
        ChatResponse response = await chatClient.GetResponseAsync("Test");

        var mcpResult = response.Messages[0].Contents[0] as McpServerToolResultContent;
        Assert.NotNull(mcpResult);
        Assert.Equal("mcp_call_456", mcpResult.CallId);
        Assert.NotNull(mcpResult.Output);
        Assert.Single(mcpResult.Output);
        Assert.Equal("Result from MCP tool", ((TextContent)mcpResult.Output[0]).Text);
        Assert.NotNull(mcpResult.RawRepresentation);
        Assert.IsType<Anthropic.Models.Beta.Messages.BetaMCPToolResultBlock>(mcpResult.RawRepresentation);
    }
}
