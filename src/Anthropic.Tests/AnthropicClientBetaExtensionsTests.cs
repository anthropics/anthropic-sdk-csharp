using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;
using Anthropic.Services;

#pragma warning disable MEAI001 // [Experimental] APIs in Microsoft.Extensions.AI
#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace Microsoft.Extensions.AI.Tests;

public class AnthropicClientBetaExtensionsTests : AnthropicClientExtensionsTestsBase
{
    protected override IChatClient CreateChatClient(
        AnthropicClient client,
        string? modelId = null,
        int? defaultMaxOutputTokens = null
    ) => client.Beta.AsIChatClient(modelId, defaultMaxOutputTokens);

    [Fact]
    public void AsIChatClient_ReturnsValidChatClient()
    {
        var client = new AnthropicClient { ApiKey = "test-key" }.Beta;
        Assert.NotNull(client.AsIChatClient("claude-haiku-4-5"));
    }

    [Fact]
    public void AsIChatClient_ThrowsOnNullClient()
    {
        IBetaService client = null!;
        Assert.Throws<ArgumentNullException>("betaService", () => client.AsIChatClient());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void AsIChatClient_ThrowsOnNonPositiveDefaultMaxTokens(int defaultMaxTokens)
    {
        var client = new AnthropicClient { ApiKey = "test-key" }.Beta;
        Assert.Throws<ArgumentOutOfRangeException>(
            "defaultMaxOutputTokens",
            () => client.AsIChatClient(defaultMaxOutputTokens: defaultMaxTokens)
        );
    }

    [Fact]
    public void AsIChatClient_GetService_ReturnsClient()
    {
        AnthropicClient client = new() { ApiKey = "test-key" };
        IChatClient chatClient = CreateChatClient(client, "claude-haiku-4-5");

        Assert.Same(client.Beta, chatClient.GetService<IBetaService>());
    }

    [Fact]
    public void AsAITool_ThrowsOnNullToolUnion()
    {
        Assert.Throws<ArgumentNullException>("tool", () => ((BetaToolUnion)null!).AsAITool());
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
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatResponse response = await chatClient.GetResponseAsync(
            "Test",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
        Assert.NotNull(response.RawRepresentation);

        BetaMessage rawMessage = Assert.IsType<BetaMessage>(response.RawRepresentation);
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
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new()
        {
            Tools =
            [
                new HostedMcpServerTool("my-mcp-server", new Uri("https://mcp.example.com/server")),
            ],
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Use the MCP server",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        TextContent textContent = Assert.IsType<TextContent>(response.Messages[0].Contents[0]);
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
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new()
        {
            Tools =
            [
                new HostedMcpServerTool("my-mcp-server", new Uri("https://mcp.example.com/server"))
                {
                    AllowedTools = ["tool1", "tool2", "tool3"],
                },
            ],
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Use specific tools",
            options,
            TestContext.Current.CancellationToken
        );
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
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new()
        {
            Tools =
            [
                new HostedMcpServerTool("server1", new Uri("https://server1.example.com")),
                new HostedMcpServerTool("server2", new Uri("https://server2.example.com"))
                {
                    AllowedTools = ["tool_a", "tool_b"],
                },
            ],
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Use multiple servers",
            options,
            TestContext.Current.CancellationToken
        );
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
                        "input": {},
                        "caller": {"type": "direct"}
                    }
                ],
                "stop_reason": "tool_use",
                "usage": {
                    "input_tokens": 20,
                    "output_tokens": 30
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatResponse response = await chatClient.GetResponseAsync(
            "Test various content types",
            new(),
            TestContext.Current.CancellationToken
        );

        TextContent textContent = Assert.IsType<TextContent>(response.Messages[0].Contents[0]);
        Assert.NotNull(textContent.RawRepresentation);
        Assert.IsType<BetaTextBlock>(textContent.RawRepresentation);

        TextReasoningContent thinkingContent = Assert.IsType<TextReasoningContent>(
            response.Messages[0].Contents[1]
        );
        Assert.NotNull(thinkingContent);
        Assert.NotNull(thinkingContent.RawRepresentation);
        Assert.IsType<BetaThinkingBlock>(thinkingContent.RawRepresentation);

        FunctionCallContent toolCall = Assert.IsType<FunctionCallContent>(
            response.Messages[0].Contents[2]
        );
        Assert.NotNull(toolCall);
        Assert.NotNull(toolCall.RawRepresentation);
        Assert.IsType<BetaToolUseBlock>(toolCall.RawRepresentation);
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
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");
        ChatResponse response = await chatClient.GetResponseAsync(
            "Use MCP tool",
            new(),
            TestContext.Current.CancellationToken
        );

        McpServerToolCallContent mcpToolCall = Assert.IsType<McpServerToolCallContent>(
            response.Messages[0].Contents[0]
        );
        Assert.NotNull(mcpToolCall);
        Assert.Equal("mcp_call_123", mcpToolCall.CallId);
        Assert.Equal("search", mcpToolCall.Name);
        Assert.Equal("my-mcp-server", mcpToolCall.ServerName);
        Assert.NotNull(mcpToolCall.Arguments);
        Assert.True(mcpToolCall.Arguments.ContainsKey("query"));
        Assert.NotNull(mcpToolCall.RawRepresentation);
        Assert.IsType<BetaMcpToolUseBlock>(mcpToolCall.RawRepresentation);
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
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");
        ChatResponse response = await chatClient.GetResponseAsync(
            "Test",
            new(),
            TestContext.Current.CancellationToken
        );

        McpServerToolResultContent mcpResult = Assert.IsType<McpServerToolResultContent>(
            response.Messages[0].Contents[0]
        );
        Assert.NotNull(mcpResult);
        Assert.Equal("mcp_call_456", mcpResult.CallId);
        Assert.NotNull(mcpResult.Outputs);
        Assert.Single(mcpResult.Outputs);
        Assert.Equal("Result from MCP tool", ((TextContent)mcpResult.Outputs[0]).Text);
        Assert.NotNull(mcpResult.RawRepresentation);
        Assert.IsType<BetaMcpToolResultBlock>(mcpResult.RawRepresentation);
    }

    [Fact]
    public async Task GetResponseAsync_WithMultipleBetaToolUnionsAsAITools_FlowsThroughToRequest()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "messages": [
                    {
                        "role": "user",
                        "content": [
                            {
                                "type": "text",
                                "text": "Use multiple tools"
                            }
                        ]
                    }
                ],
                "model": "claude-haiku-4-5",
                "tools": [
                    {
                        "name": "web_search",
                        "type": "web_search_20250305",
                        "allowed_domains": [
                            "github.com"
                        ],
                        "max_uses": 42,
                        "user_location": {
                            "type": "approximate",
                            "city": "Boston"
                        }
                    },
                    {
                        "name": "code_execution",
                        "type": "code_execution_20250825"
                    },
                    {
                        "name": "custom_tool",
                        "description": "Custom tool",
                        "input_schema": {
                            "type": "object"
                        }
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_multi_beta_tools_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I have access to multiple tools."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 25,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        BetaToolUnion webSearchTool = new BetaWebSearchTool20250305()
        {
            AllowedDomains = ["github.com"],
            MaxUses = 42,
            UserLocation = new() { City = "Boston" },
        };
        BetaToolUnion codeExecTool = new BetaCodeExecutionTool20250825();
        BetaToolUnion customTool = new BetaTool
        {
            Name = "custom_tool",
            Description = "Custom tool",
            InputSchema = new InputSchema(new Dictionary<string, JsonElement>()),
        };

        ChatOptions options = new()
        {
            Tools = [webSearchTool.AsAITool(), codeExecTool.AsAITool(), customTool.AsAITool()],
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Use multiple tools",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_McpToolResultBlock_WithError()
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
                        "text": "Test MCP error"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_mcp_error_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "mcp_tool_result",
                    "tool_use_id": "mcp_call_error_1",
                    "is_error": true,
                    "content": "Connection timeout"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 10,
                    "output_tokens": 5
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");
        ChatResponse response = await chatClient.GetResponseAsync(
            "Test MCP error",
            new(),
            TestContext.Current.CancellationToken
        );

        McpServerToolResultContent mcpResult = Assert.IsType<McpServerToolResultContent>(
            response.Messages[0].Contents[0]
        );
        Assert.NotNull(mcpResult);
        Assert.Equal("mcp_call_error_1", mcpResult.CallId);
        Assert.NotNull(mcpResult.Outputs);
        Assert.Single(mcpResult.Outputs);

        ErrorContent errorContent = Assert.IsType<ErrorContent>(mcpResult.Outputs[0]);
        Assert.Equal("Connection timeout", errorContent.Message);
    }

    [Fact]
    public async Task GetResponseAsync_WithFunctionResultContent_HostedFileContent()
    {
        IEnumerable<string>? capturedBetaHeaders = null;
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-haiku-4-5",
                "messages": [
                    {
                        "role": "user",
                        "content": [{
                            "type": "text",
                            "text": "Get file"
                        }]
                    },
                    {
                        "role": "assistant",
                        "content": [{
                            "type": "tool_use",
                            "id": "tool_file",
                            "name": "file_tool",
                            "input": {}
                        }]
                    },
                    {
                        "role": "user",
                        "content": [{
                            "type": "tool_result",
                            "tool_use_id": "tool_file",
                            "is_error": false,
                            "content": [{
                                "type": "document",
                                "source": {
                                    "type": "file",
                                    "file_id": "file_abc123"
                                }
                            }]
                        }]
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_file_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "File received"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 28,
                    "output_tokens": 7
                }
            }
            """
        )
        {
            OnRequestHeaders = headers =>
                headers.TryGetValues("anthropic-beta", out capturedBetaHeaders),
        };

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatMessage> messages =
        [
            new ChatMessage(ChatRole.User, "Get file"),
            new ChatMessage(
                ChatRole.Assistant,
                [
                    new FunctionCallContent(
                        "tool_file",
                        "file_tool",
                        new Dictionary<string, object?>()
                    ),
                ]
            ),
            new ChatMessage(
                ChatRole.User,
                [new FunctionResultContent("tool_file", new HostedFileContent("file_abc123"))]
            ),
        ];

        ChatResponse response = await chatClient.GetResponseAsync(
            messages,
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
        Assert.NotNull(capturedBetaHeaders);
        Assert.Contains("files-api-2025-04-14", capturedBetaHeaders);
    }

    [Fact]
    public async Task GetResponseAsync_WithFunctionResultContent_HostedFileContent_Image()
    {
        IEnumerable<string>? capturedBetaHeaders = null;
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-haiku-4-5",
                "messages": [
                    {
                        "role": "user",
                        "content": [{
                            "type": "text",
                            "text": "Get image"
                        }]
                    },
                    {
                        "role": "assistant",
                        "content": [{
                            "type": "tool_use",
                            "id": "tool_image",
                            "name": "image_tool",
                            "input": {}
                        }]
                    },
                    {
                        "role": "user",
                        "content": [{
                            "type": "tool_result",
                            "tool_use_id": "tool_image",
                            "is_error": false,
                            "content": [{
                                "type": "image",
                                "source": {
                                    "type": "file",
                                    "file_id": "file_abc123"
                                }
                            }]
                        }]
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_image_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Image received"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 28,
                    "output_tokens": 7
                }
            }
            """
        )
        {
            OnRequestHeaders = headers =>
                headers.TryGetValues("anthropic-beta", out capturedBetaHeaders),
        };

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatMessage> messages =
        [
            new ChatMessage(ChatRole.User, "Get image"),
            new ChatMessage(
                ChatRole.Assistant,
                [
                    new FunctionCallContent(
                        "tool_image",
                        "image_tool",
                        new Dictionary<string, object?>()
                    ),
                ]
            ),
            new ChatMessage(
                ChatRole.User,
                [
                    new FunctionResultContent(
                        "tool_image",
                        new HostedFileContent("file_abc123") { MediaType = "image/png" }
                    ),
                ]
            ),
        ];

        ChatResponse response = await chatClient.GetResponseAsync(
            messages,
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
        Assert.NotNull(capturedBetaHeaders);
        Assert.Contains("files-api-2025-04-14", capturedBetaHeaders);
    }

    [Fact]
    public void AsAITool_GetService_ReturnsToolUnion()
    {
        BetaToolUnion toolUnion = new BetaWebSearchTool20250305()
        {
            AllowedDomains = ["example.com"],
        };
        AITool aiTool = toolUnion.AsAITool();
        Assert.Same(toolUnion, aiTool.GetService<BetaToolUnion>());

        Assert.Null(aiTool.GetService<BetaToolUnion>("key"));
        Assert.Null(aiTool.GetService<string>());

        Assert.Contains(nameof(BetaWebSearchTool20250305), aiTool.Name);
    }

    [Fact]
    public void AsAITool_GetService_ThrowsOnNullServiceType()
    {
        AITool aiTool = (
            (BetaToolUnion)new BetaWebSearchTool20250305() { AllowedDomains = ["example.com"] }
        ).AsAITool();
        Assert.Throws<ArgumentNullException>(() => aiTool.GetService(null!, null));
    }

    [Fact]
    public async Task GetResponseAsync_WithHostedFileContent()
    {
        IEnumerable<string>? capturedBetaHeaders = null;
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "document",
                        "source": {
                            "type": "file",
                            "file_id": "file_abc123"
                        }
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_hosted_file_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I read the hosted file."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 20,
                    "output_tokens": 6
                }
            }
            """
        )
        {
            OnRequestHeaders = headers =>
                headers.TryGetValues("anthropic-beta", out capturedBetaHeaders),
        };

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var hostedFile = new HostedFileContent("file_abc123");

        ChatResponse response = await chatClient.GetResponseAsync(
            [new ChatMessage(ChatRole.User, [hostedFile])],
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
        Assert.NotNull(capturedBetaHeaders);
        Assert.Contains("files-api-2025-04-14", capturedBetaHeaders);
    }

    [Fact]
    public async Task GetResponseAsync_WithHostedFileContent_Image()
    {
        IEnumerable<string>? capturedBetaHeaders = null;
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "image",
                        "source": {
                            "type": "file",
                            "file_id": "file_abc123"
                        }
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_hosted_image_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I see an image."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 20,
                    "output_tokens": 5
                }
            }
            """
        )
        {
            OnRequestHeaders = headers =>
                headers.TryGetValues("anthropic-beta", out capturedBetaHeaders),
        };

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var hostedFile = new HostedFileContent("file_abc123") { MediaType = "image/png" };

        ChatResponse response = await chatClient.GetResponseAsync(
            [new ChatMessage(ChatRole.User, [hostedFile])],
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
        Assert.Equal("I see an image.", response.Text);
        Assert.NotNull(capturedBetaHeaders);
        Assert.Contains("files-api-2025-04-14", capturedBetaHeaders);
    }

    [Fact]
    public async Task GetResponseAsync_WithResponseFormatAndPreconfiguredOutputConfig_MergesFormat()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 2048,
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Return JSON"
                    }]
                }],
                "output_config": {
                    "effort": "medium",
                    "format": {
                        "type": "json_schema",
                        "schema": {
                            "type": "object",
                            "properties": {
                                "answer": { "type": "string" }
                            },
                            "required": ["answer"],
                            "additionalProperties": false
                        }
                    }
                }
            }
            """,
            actualResponse: """
            {
                "id": "msg_factory_output_config_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "{\"answer\":\"Response\"}"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 20,
                    "output_tokens": 5
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new()
        {
            RawRepresentationFactory = _ => new MessageCreateParams()
            {
                MaxTokens = 2048,
                Model = "claude-haiku-4-5",
                Messages = [],
                OutputConfig = new BetaOutputConfig() { Effort = Effort.Medium },
            },
            ResponseFormat = ChatResponseFormat.ForJsonSchema(
                JsonElement.Parse(
                    """
                    {
                        "type": "object",
                        "properties": {
                            "answer": { "type": "string" }
                        },
                        "required": ["answer"]
                    }
                    """
                ),
                "answer_response"
            ),
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Return JSON",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithNonEmptyMessageParams_EmptyMessages()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 2048,
                "model": "claude-haiku-4-5",
                "messages": [
                    {
                        "role": "user",
                        "content": [{
                            "type": "text",
                            "text": "Preconfigured message"
                        }]
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_factory_02",
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
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new()
        {
            RawRepresentationFactory = _ => new MessageCreateParams()
            {
                MaxTokens = 2048,
                Model = "claude-haiku-4-5",
                Messages =
                [
                    new BetaMessageParam()
                    {
                        Role = Role.User,
                        Content = new BetaMessageParamContent(
                            [new BetaTextBlockParam() { Text = "Preconfigured message" }]
                        ),
                    },
                ],
            },
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            [],
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithRawRepresentationFactory_SystemMessagesMerged()
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
                }],
                "system": [
                    {
                        "type": "text",
                        "text": "Existing system message"
                    },
                    {
                        "type": "text",
                        "text": "New system message"
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_sys_merge_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Response"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 15,
                    "output_tokens": 5
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new()
        {
            RawRepresentationFactory = _ => new MessageCreateParams()
            {
                MaxTokens = 1024,
                Model = "claude-haiku-4-5",
                Messages = [],
                System = "Existing system message",
            },
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            [
                new ChatMessage(ChatRole.System, "New system message"),
                new ChatMessage(ChatRole.User, "Test"),
            ],
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithRawRepresentationFactory_SystemMessagesListMerged()
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
                }],
                "system": [
                    {
                        "type": "text",
                        "text": "First"
                    },
                    {
                        "type": "text",
                        "text": "Second"
                    },
                    {
                        "type": "text",
                        "text": "Third"
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_sys_list_merge_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Response"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 15,
                    "output_tokens": 5
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new()
        {
            RawRepresentationFactory = _ => new MessageCreateParams()
            {
                MaxTokens = 1024,
                Model = "claude-haiku-4-5",
                Messages = [],
                System = new System.Collections.Generic.List<BetaTextBlockParam>
                {
                    new() { Text = "First" },
                    new() { Text = "Second" },
                },
            },
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            [new ChatMessage(ChatRole.System, "Third"), new ChatMessage(ChatRole.User, "Test")],
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_SystemMessageRawRepresentationPreserved()
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
                }],
                "system": [{
                    "type": "text",
                    "text": "Cached system message",
                    "cache_control": {
                        "type": "ephemeral"
                    }
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_sys_cache_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Response"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 15,
                    "output_tokens": 5
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var systemContent = new TextContent("Cached system message")
        {
            RawRepresentation = new BetaTextBlockParam()
            {
                Text = "Cached system message",
                CacheControl = new BetaCacheControlEphemeral(),
            },
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            [
                new ChatMessage(ChatRole.System, [systemContent]),
                new ChatMessage(ChatRole.User, "Test"),
            ],
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_McpToolResultWithTextList()
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
                        "text": "Test MCP text list"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_mcp_text_list_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "mcp_tool_result",
                    "tool_use_id": "mcp_call_789",
                    "is_error": false,
                    "content": [{
                        "type": "text",
                        "text": "First result"
                    }, {
                        "type": "text",
                        "text": "Second result"
                    }]
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 10,
                    "output_tokens": 15
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");
        ChatResponse response = await chatClient.GetResponseAsync(
            "Test MCP text list",
            new(),
            TestContext.Current.CancellationToken
        );

        McpServerToolResultContent mcpResult = Assert.IsType<McpServerToolResultContent>(
            response.Messages[0].Contents[0]
        );
        Assert.NotNull(mcpResult);
        Assert.Equal("mcp_call_789", mcpResult.CallId);
        Assert.NotNull(mcpResult.Outputs);
        Assert.Equal(2, mcpResult.Outputs.Count);
        Assert.Equal("First result", ((TextContent)mcpResult.Outputs[0]).Text);
        Assert.Equal("Second result", ((TextContent)mcpResult.Outputs[1]).Text);
    }

    [Fact]
    public async Task GetResponseAsync_WithHostedTools_AddsBetaHeaders()
    {
        IEnumerable<string>? capturedBetaHeaders = null;
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Use both tools"
                    }]
                }],
                "tools": [{
                    "type": "code_execution_20250825",
                    "name": "code_execution"
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
                "id": "msg_both_beta_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I have access to both tools."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 25,
                    "output_tokens": 10
                }
            }
            """
        )
        {
            OnRequestHeaders = headers =>
                headers.TryGetValues("anthropic-beta", out capturedBetaHeaders),
        };

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new()
        {
            Tools =
            [
                new HostedCodeInterpreterTool(),
                new HostedMcpServerTool("my-mcp-server", new Uri("https://mcp.example.com/server")),
            ],
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Use both tools",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
        Assert.NotNull(capturedBetaHeaders);
        Assert.Contains("code-execution-2025-08-25", capturedBetaHeaders);
        Assert.Contains("mcp-client-2025-11-20", capturedBetaHeaders);
    }

    [Fact]
    public async Task GetResponseAsync_WithHostedToolsAndExistingBetas_PreservesAndDeduplicatesBetas()
    {
        IEnumerable<string>? capturedBetaHeaders = null;
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
                }],
                "tools": [{
                    "type": "code_execution_20250825",
                    "name": "code_execution"
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
                "id": "msg_preserve_beta_01",
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
            """
        )
        {
            OnRequestHeaders = headers =>
                headers.TryGetValues("anthropic-beta", out capturedBetaHeaders),
        };

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new()
        {
            RawRepresentationFactory = _ => new MessageCreateParams()
            {
                MaxTokens = 1024,
                Model = "claude-haiku-4-5",
                Messages = [],
                Betas = ["custom-beta-feature", "code-execution-2025-08-25"],
            },
            Tools =
            [
                new HostedCodeInterpreterTool(),
                new HostedMcpServerTool("my-mcp-server", new Uri("https://mcp.example.com/server")),
            ],
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Test",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
        Assert.NotNull(capturedBetaHeaders);
        Assert.Equal(3, capturedBetaHeaders.Count());
        Assert.Contains("custom-beta-feature", capturedBetaHeaders);
        Assert.Contains("code-execution-2025-08-25", capturedBetaHeaders);
        Assert.Contains("mcp-client-2025-11-20", capturedBetaHeaders);
    }

    [Fact]
    public async Task GetResponseAsync_IncludesMeaiUserAgentHeader()
    {
        string[]? capturedUserAgentValues = null;
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
                "id": "msg_meai_header_01",
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
            """
        )
        {
            OnRequestHeaders = headers =>
            {
                // Verify there's exactly one User-Agent header entry
                Assert.Single(headers, h => h.Key == "User-Agent");
                if (headers.TryGetValues("User-Agent", out var values))
                {
                    capturedUserAgentValues = [.. values];
                }
            },
        };

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatResponse response = await chatClient.GetResponseAsync(
            "Test",
            new(),
            TestContext.Current.CancellationToken
        );

        Assert.NotNull(response);
        Assert.NotNull(capturedUserAgentValues);
        Assert.Contains(capturedUserAgentValues, v => v.Contains("MEAI"));
        Assert.Contains(capturedUserAgentValues, v => v.Contains("AnthropicClient"));
    }

    [Fact]
    public async Task GetStreamingResponseAsync_IncludesMeaiUserAgentHeader()
    {
        string[]? capturedUserAgentValues = null;
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Test streaming"
                    }]
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_stream_meai_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"Response"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":5}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        )
        {
            OnRequestHeaders = headers =>
            {
                // Verify there's exactly one User-Agent header entry
                Assert.Single(headers, h => h.Key == "User-Agent");
                if (headers.TryGetValues("User-Agent", out var values))
                {
                    capturedUserAgentValues = [.. values];
                }
            },
        };

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Test streaming",
                new(),
                TestContext.Current.CancellationToken
            )
        )
        {
            // Consume the stream
        }

        Assert.NotNull(capturedUserAgentValues);
        Assert.Contains(capturedUserAgentValues, v => v.Contains("MEAI"));
        Assert.Contains(capturedUserAgentValues, v => v.Contains("AnthropicClient"));
    }

    [Fact]
    public async Task GetResponseAsync_MeaiUserAgentHeader_HasCorrectFormat()
    {
        string[]? capturedUserAgentValues = null;
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
                "id": "msg_meai_format_01",
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
            """
        )
        {
            OnRequestHeaders = headers =>
            {
                // Verify there's exactly one User-Agent header entry
                Assert.Single(headers, h => h.Key == "User-Agent");
                if (headers.TryGetValues("User-Agent", out var values))
                {
                    capturedUserAgentValues = [.. values];
                }
            },
        };

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatResponse response = await chatClient.GetResponseAsync(
            "Test",
            new(),
            TestContext.Current.CancellationToken
        );

        Assert.NotNull(response);
        Assert.NotNull(capturedUserAgentValues);
        // Verify the MEAI user-agent is present and has correct format (MEAI or MEAI/version)
        Assert.Contains(
            capturedUserAgentValues,
            v => v.StartsWith("MEAI", StringComparison.Ordinal)
        );
        Assert.Contains(capturedUserAgentValues, v => v.Contains("AnthropicClient"));
    }

    [Fact]
    public async Task GetResponseAsync_MeaiUserAgentHeader_PresentAlongsideDefaultHeaders()
    {
        bool hasAnthropicVersion = false;
        bool hasMeaiUserAgent = false;
        bool hasDefaultUserAgent = false;

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
                "id": "msg_headers_01",
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
            """
        )
        {
            OnRequestHeaders = headers =>
            {
                // Verify there's exactly one User-Agent header entry
                Assert.Single(headers, h => h.Key == "User-Agent");
                hasAnthropicVersion = headers.Contains("anthropic-version");
                if (headers.TryGetValues("User-Agent", out var values))
                {
                    var valuesArray = values.ToArray();
                    hasMeaiUserAgent = valuesArray.Any(v => v.Contains("MEAI"));
                    hasDefaultUserAgent = valuesArray.Any(v => v.Contains("AnthropicClient"));
                }
            },
        };

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatResponse response = await chatClient.GetResponseAsync(
            "Test",
            new(),
            TestContext.Current.CancellationToken
        );

        Assert.NotNull(response);
        Assert.True(hasAnthropicVersion, "anthropic-version header should be present");
        Assert.True(hasMeaiUserAgent, "MEAI user-agent header should be present");
        Assert.True(
            hasDefaultUserAgent,
            "Default AnthropicClient user-agent header should be present"
        );
    }

    [Fact]
    public async Task GetResponseAsync_WithReasoningEffort_IgnoredWhenThinkingAlreadyConfigured()
    {
        // When RawRepresentationFactory pre-configures Thinking, the Reasoning option should be ignored.
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 50000,
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Think carefully"
                    }]
                }],
                "thinking": {
                    "type": "enabled",
                    "budget_tokens": 5000
                }
            }
            """,
            actualResponse: """
            {
                "id": "msg_reasoning_preconfigured",
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
                    "output_tokens": 15
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new()
        {
            // RawRepresentationFactory sets Thinking to enabled with 5000 budget.
            // Reasoning.Effort should be ignored since Thinking is already configured.
            RawRepresentationFactory = _ => new MessageCreateParams()
            {
                MaxTokens = 50000,
                Model = "claude-haiku-4-5",
                Messages = [],
                Thinking = new BetaThinkingConfigParam(new BetaThinkingConfigEnabled(5000)),
            },
            Reasoning = new() { Effort = ReasoningEffort.ExtraHigh },
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Think carefully",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithAIFunctionTool_AllowedCallers_FlowsThrough()
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
                        "text": "Use tool"
                    }]
                }],
                "tools": [{
                    "name": "callers_tool",
                    "description": "A tool with allowed callers",
                    "input_schema": {
                        "type": "object",
                        "properties": {
                            "value": {
                                "type": "integer"
                            }
                        },
                        "required": ["value"],
                        "additionalProperties": false
                    },
                    "allowed_callers": [
                        "direct"
                    ]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_callers_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Done"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 30,
                    "output_tokens": 5
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var function = AIFunctionFactory.Create(
            (int value) => value,
            new AIFunctionFactoryOptions
            {
                Name = "callers_tool",
                Description = "A tool with allowed callers",
                AdditionalProperties = new Dictionary<string, object?>
                {
                    [nameof(BetaTool.AllowedCallers)] = new List<
                        ApiEnum<string, BetaToolAllowedCaller>
                    >
                    {
                        new(JsonSerializer.SerializeToElement("direct")),
                    },
                },
            }
        );

        ChatOptions options = new() { Tools = [function] };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Use tool",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithRawRepresentationFactory()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 2048,
                "model": "claude-haiku-4-5",
                "messages": [
                    {
                        "role": "user",
                        "content": [{
                            "type": "text",
                            "text": "Preconfigured message"
                        }]
                    },
                    {
                        "role": "user",
                        "content": [{
                            "type": "text",
                            "text": "New message"
                        }]
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_factory_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Response"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 20,
                    "output_tokens": 5
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new()
        {
            RawRepresentationFactory = _ => new MessageCreateParams()
            {
                MaxTokens = 2048,
                Model = "claude-haiku-4-5",
                Messages =
                [
                    new BetaMessageParam()
                    {
                        Role = Role.User,
                        Content = new BetaMessageParamContent(
                            [new BetaTextBlockParam() { Text = "Preconfigured message" }]
                        ),
                    },
                ],
            },
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "New message",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public void AsIHostedFileClient_ReturnsInstance()
    {
        var client = new AnthropicClient { ApiKey = "test-key" }.Beta;
        IHostedFileClient fileClient = client.AsIHostedFileClient();
        Assert.NotNull(fileClient);
    }

    [Fact]
    public void AsIHostedFileClient_ReturnsHostedFileClientMetadata()
    {
        var client = new AnthropicClient { ApiKey = "test-key" }.Beta;
        IHostedFileClient fileClient = client.AsIHostedFileClient();
        var metadata = fileClient.GetService<HostedFileClientMetadata>();
        Assert.NotNull(metadata);
        Assert.Equal("anthropic", metadata.ProviderName);
    }

    [Fact]
    public void AsIHostedFileClient_ThrowsOnNull()
    {
        Anthropic.Services.IBetaService betaService = null!;
        Anthropic.Services.Beta.IFileService fileService = null!;

        Assert.Throws<ArgumentNullException>(() => betaService.AsIHostedFileClient());
        Assert.Throws<ArgumentNullException>(() => fileService.AsIHostedFileClient());
    }

    [Fact]
    public async Task IHostedFileClient_UploadAsync_NullContent_Throws()
    {
        using IHostedFileClient fileClient = new AnthropicClient
        {
            ApiKey = "test-key",
        }.Beta.AsIHostedFileClient();
        await Assert.ThrowsAsync<ArgumentNullException>(
            "content",
            () =>
                fileClient.UploadAsync(
                    null!,
                    cancellationToken: TestContext.Current.CancellationToken
                )
        );
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task IHostedFileClient_DownloadAsync_InvalidFileId_Throws(string? fileId)
    {
        using IHostedFileClient fileClient = new AnthropicClient
        {
            ApiKey = "test-key",
        }.Beta.AsIHostedFileClient();
        ArgumentException ex = await Assert.ThrowsAnyAsync<ArgumentException>(() =>
            fileClient.DownloadAsync(
                fileId!,
                cancellationToken: TestContext.Current.CancellationToken
            )
        );
        Assert.Equal("fileId", ex.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task IHostedFileClient_GetFileInfoAsync_InvalidFileId_Throws(string? fileId)
    {
        using IHostedFileClient fileClient = new AnthropicClient
        {
            ApiKey = "test-key",
        }.Beta.AsIHostedFileClient();
        ArgumentException ex = await Assert.ThrowsAnyAsync<ArgumentException>(() =>
            fileClient.GetFileInfoAsync(
                fileId!,
                cancellationToken: TestContext.Current.CancellationToken
            )
        );
        Assert.Equal("fileId", ex.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task IHostedFileClient_DeleteAsync_InvalidFileId_Throws(string? fileId)
    {
        using IHostedFileClient fileClient = new AnthropicClient
        {
            ApiKey = "test-key",
        }.Beta.AsIHostedFileClient();
        ArgumentException ex = await Assert.ThrowsAnyAsync<ArgumentException>(() =>
            fileClient.DeleteAsync(
                fileId!,
                cancellationToken: TestContext.Current.CancellationToken
            )
        );
        Assert.Equal("fileId", ex.ParamName);
    }

    [Fact]
    public void IHostedFileClient_GetService_NullServiceType_Throws()
    {
        using IHostedFileClient fileClient = new AnthropicClient
        {
            ApiKey = "test-key",
        }.Beta.AsIHostedFileClient();
        Assert.Throws<ArgumentNullException>("serviceType", () => fileClient.GetService(null!));
    }

    [Fact]
    public void IHostedFileClient_GetService_NonNullServiceKey_ReturnsNull()
    {
        using IHostedFileClient fileClient = new AnthropicClient
        {
            ApiKey = "test-key",
        }.Beta.AsIHostedFileClient();
        Assert.Null(fileClient.GetService(typeof(HostedFileClientMetadata), "key"));
    }

    [Fact]
    public void IHostedFileClient_GetService_ReturnsSelf()
    {
        using IHostedFileClient fileClient = new AnthropicClient
        {
            ApiKey = "test-key",
        }.Beta.AsIHostedFileClient();
        Assert.Same(fileClient, fileClient.GetService<IHostedFileClient>());
    }

    [Fact]
    public void IHostedFileClient_GetService_UnknownType_ReturnsNull()
    {
        using IHostedFileClient fileClient = new AnthropicClient
        {
            ApiKey = "test-key",
        }.Beta.AsIHostedFileClient();
        Assert.Null(fileClient.GetService(typeof(string)));
    }

    [Fact]
    public void IHostedFileClient_GetService_Metadata_HasProviderUri()
    {
        using IHostedFileClient fileClient = new AnthropicClient
        {
            ApiKey = "test-key",
        }.Beta.AsIHostedFileClient();
        var metadata = fileClient.GetService<HostedFileClientMetadata>();
        Assert.NotNull(metadata);
        Assert.NotNull(metadata.ProviderUri);
    }

    [Fact]
    public async Task IHostedFileClient_GetFileInfoAsync_ReturnsHostedFileContent()
    {
        VerbatimHttpHandler handler = new(
            "",
            """
            {
                "id": "file_abc123",
                "created_at": "2024-01-01T00:00:00+00:00",
                "filename": "test.txt",
                "mime_type": "text/plain",
                "size_bytes": 100,
                "type": "file"
            }
            """
        );

        using IHostedFileClient fileClient = CreateAnthropicClient(handler)
            .Beta.AsIHostedFileClient();
        HostedFileContent? result = await fileClient.GetFileInfoAsync(
            "file_abc123",
            cancellationToken: TestContext.Current.CancellationToken
        );

        Assert.NotNull(result);
        Assert.Equal("file_abc123", result.FileId);
        Assert.Equal("text/plain", result.MediaType);
        Assert.Equal("test.txt", result.Name);
        Assert.Equal(100, result.SizeInBytes);
        Assert.NotNull(result.CreatedAt);
        Assert.IsType<Anthropic.Models.Beta.Files.FileMetadata>(result.RawRepresentation);
    }

    [Fact]
    public async Task IHostedFileClient_DeleteAsync_ReturnsTrue()
    {
        VerbatimHttpHandler handler = new(
            "",
            """
            {
                "id": "file_abc123",
                "type": "file_deleted"
            }
            """
        );

        using IHostedFileClient fileClient = CreateAnthropicClient(handler)
            .Beta.AsIHostedFileClient();
        bool result = await fileClient.DeleteAsync(
            "file_abc123",
            cancellationToken: TestContext.Current.CancellationToken
        );

        Assert.True(result);
    }

    [Fact]
    public async Task IHostedFileClient_UploadAsync_ReturnsHostedFileContent()
    {
        VerbatimHttpHandler handler = new(
            "",
            """
            {
                "id": "file_new123",
                "created_at": "2024-06-15T10:30:00+00:00",
                "filename": "report.pdf",
                "mime_type": "application/pdf",
                "size_bytes": 5000,
                "type": "file"
            }
            """
        );

        using IHostedFileClient fileClient = CreateAnthropicClient(handler)
            .Beta.AsIHostedFileClient();
        using var stream = new MemoryStream([1, 2, 3]);

        HostedFileContent result = await fileClient.UploadAsync(
            stream,
            "application/pdf",
            "report.pdf",
            cancellationToken: TestContext.Current.CancellationToken
        );

        Assert.Equal("file_new123", result.FileId);
        Assert.Equal("application/pdf", result.MediaType);
        Assert.Equal("report.pdf", result.Name);
        Assert.Equal(5000, result.SizeInBytes);
    }

    [Fact]
    public async Task IHostedFileClient_UploadAsync_NullMediaType_InfersFromFileName()
    {
        VerbatimHttpHandler handler = new(
            "",
            """
            {
                "id": "file_inferred",
                "created_at": "2024-06-15T10:30:00+00:00",
                "filename": "data.csv",
                "mime_type": "text/csv",
                "size_bytes": 500,
                "type": "file"
            }
            """
        );

        using IHostedFileClient fileClient = CreateAnthropicClient(handler)
            .Beta.AsIHostedFileClient();
        using var stream = new MemoryStream([1, 2, 3]);

        HostedFileContent result = await fileClient.UploadAsync(
            stream,
            null,
            "data.csv",
            cancellationToken: TestContext.Current.CancellationToken
        );

        Assert.Equal("file_inferred", result.FileId);
    }

    [Fact]
    public async Task IHostedFileClient_UploadAsync_NullFileName_GeneratesFromMediaType()
    {
        VerbatimHttpHandler handler = new(
            "",
            """
            {
                "id": "file_gen",
                "created_at": "2024-06-15T10:30:00+00:00",
                "filename": "generated.pdf",
                "mime_type": "application/pdf",
                "size_bytes": 100,
                "type": "file"
            }
            """
        );

        using IHostedFileClient fileClient = CreateAnthropicClient(handler)
            .Beta.AsIHostedFileClient();
        using var stream = new MemoryStream([1, 2, 3]);

        HostedFileContent result = await fileClient.UploadAsync(
            stream,
            "application/pdf",
            null,
            cancellationToken: TestContext.Current.CancellationToken
        );

        Assert.Equal("file_gen", result.FileId);
    }

    [Fact]
    public async Task IHostedFileClient_DownloadAsync_ReturnsReadableStream()
    {
        VerbatimHttpHandler handler = new("", "test file content");

        using IHostedFileClient fileClient = CreateAnthropicClient(handler)
            .Beta.AsIHostedFileClient();
        using HostedFileDownloadStream downloadStream = await fileClient.DownloadAsync(
            "file_abc123",
            cancellationToken: TestContext.Current.CancellationToken
        );

        Assert.NotNull(downloadStream);
        Assert.True(downloadStream.CanRead);
        Assert.False(downloadStream.CanWrite);

        using var reader = new StreamReader(downloadStream);
        string content = await reader.ReadToEndAsync(
#if NET
            TestContext.Current.CancellationToken
#endif
        );
        Assert.Contains("test file content", content);
    }

    [Fact]
    public async Task IHostedFileClient_DownloadAsync_StreamWriteThrows()
    {
        VerbatimHttpHandler handler = new("", "content");

        using IHostedFileClient fileClient = CreateAnthropicClient(handler)
            .Beta.AsIHostedFileClient();
        using HostedFileDownloadStream stream = await fileClient.DownloadAsync(
            "file_abc123",
            cancellationToken: TestContext.Current.CancellationToken
        );

        Assert.Throws<NotSupportedException>(() => stream.Write(new byte[1], 0, 1));
        Assert.Throws<NotSupportedException>(() => stream.SetLength(0));
    }

    [Fact]
    public async Task IHostedFileClient_ListFilesAsync_ReturnsFiles()
    {
        VerbatimHttpHandler handler = new(
            "",
            """
            {
                "data": [
                    {
                        "id": "file_1",
                        "created_at": "2024-01-01T00:00:00+00:00",
                        "filename": "a.txt",
                        "mime_type": "text/plain",
                        "size_bytes": 10,
                        "type": "file"
                    },
                    {
                        "id": "file_2",
                        "created_at": "2024-01-02T00:00:00+00:00",
                        "filename": "b.pdf",
                        "mime_type": "application/pdf",
                        "size_bytes": 2000,
                        "type": "file"
                    }
                ],
                "first_id": "file_1",
                "has_more": false,
                "last_id": null
            }
            """
        );

        using IHostedFileClient fileClient = CreateAnthropicClient(handler)
            .Beta.AsIHostedFileClient();

        List<HostedFileContent> files = new();
        await foreach (
            HostedFileContent file in fileClient.ListFilesAsync(
                cancellationToken: TestContext.Current.CancellationToken
            )
        )
        {
            files.Add(file);
        }

        Assert.Equal(2, files.Count);
        Assert.Equal("file_1", files[0].FileId);
        Assert.Equal("a.txt", files[0].Name);
        Assert.Equal("text/plain", files[0].MediaType);
        Assert.Equal(10, files[0].SizeInBytes);
        Assert.Equal("file_2", files[1].FileId);
        Assert.Equal("b.pdf", files[1].Name);
        Assert.Equal("application/pdf", files[1].MediaType);
        Assert.Equal(2000, files[1].SizeInBytes);
    }

    [Fact]
    public async Task GetResponseAsync_WithNullableUnionType_TransformsToSimpleType()
    {
        // The C# MCP SDK generates schemas with "type": ["integer", "null"], "default": null
        // for optional nullable parameters. This test verifies the transformation removes
        // the null from the union type and the default: null for non-required properties.
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Call tool with optional param"
                    }]
                }],
                "tools": [{
                    "name": "tool_with_optional",
                    "description": "A tool with an optional nullable parameter",
                    "input_schema": {
                        "type": "object",
                        "properties": {
                            "required_param": {
                                "type": "string"
                            },
                            "optional_number": {
                                "type": "integer",
                                "description": "{default: null}"
                            }
                        },
                        "required": ["required_param"],
                        "additionalProperties": false
                    }
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_nullable_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Tool ready"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 30,
                    "output_tokens": 5
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        // Create a function with an optional nullable parameter - the schema will have
        // "type": ["integer", "null"], "default": null which should be transformed
        var functionWithOptional = AIFunctionFactory.Create(
            (string required_param, int? optional_number = null) => "result",
            new AIFunctionFactoryOptions
            {
                Name = "tool_with_optional",
                Description = "A tool with an optional nullable parameter",
            }
        );

        ChatOptions options = new() { Tools = [functionWithOptional] };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Call tool with optional param",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithRequiredNullableUnionType_PreservesUnionType()
    {
        // When a property IS in the required array but has a nullable union type,
        // we should NOT transform it - let the API fail with a meaningful error
        // rather than silently misrepresenting the schema.
        // Using BetaTool.AsAITool() bypasses the schema transformation, so this test
        // verifies the raw tool passes through unchanged.
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Call tool with required nullable"
                    }]
                }],
                "tools": [{
                    "name": "tool_with_required_nullable",
                    "description": "A tool with a required nullable parameter",
                    "input_schema": {
                        "nullable_number": {
                            "type": ["integer", "null"],
                            "description": "A required but nullable number"
                        },
                        "type": "object",
                        "required": ["nullable_number"]
                    }
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_required_nullable_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Tool ready"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 30,
                    "output_tokens": 5
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        // Create a BetaTool with a required nullable parameter using raw schema
        // This simulates a schema that came from elsewhere (not C# MCP SDK pattern)
#pragma warning disable CA1861 // Prefer 'static readonly' fields over constant array arguments - test method only runs once
        BetaToolUnion rawTool = new BetaTool
        {
            Name = "tool_with_required_nullable",
            Description = "A tool with a required nullable parameter",
            InputSchema = new InputSchema(
                new Dictionary<string, JsonElement>
                {
                    ["nullable_number"] = JsonSerializer.SerializeToElement(
                        new
                        {
                            type = new[] { "integer", "null" },
                            description = "A required but nullable number",
                        }
                    ),
                }
            )
            {
                Required = ["nullable_number"],
            },
        };
#pragma warning restore CA1861

        ChatOptions options = new() { Tools = [rawTool.AsAITool()] };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Call tool with required nullable",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }
}
