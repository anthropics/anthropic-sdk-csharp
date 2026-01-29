using System;
using System.Collections.Generic;
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
                        "input": {}
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
        Assert.Equal("search", mcpToolCall.ToolName);
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
        Assert.NotNull(mcpResult.Output);
        Assert.Single(mcpResult.Output);
        Assert.Equal("Result from MCP tool", ((TextContent)mcpResult.Output[0]).Text);
        Assert.NotNull(mcpResult.RawRepresentation);
        Assert.IsType<BetaMcpToolResultBlock>(mcpResult.RawRepresentation);
    }

    [Fact]
    public async Task GetResponseAsync_WithSimpleResponseFormat_ReturnsStructuredJSON()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-sonnet-4-5-20250929",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Tell me about Albert Einstein. Respond with his name and age at death."
                    }]
                }],
                "output_format": {
                    "type": "json_schema",
                    "schema": {
                        "type": "object",
                        "properties": {
                            "name": { "type": "string" },
                            "age": { "type": "integer" }
                        },
                        "required": ["name", "age"],
                        "additionalProperties": false
                    }
                }
            }
            """,
            actualResponse: """
            {
                "id": "msg_format_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-sonnet-4-5-20250929",
                "content": [{
                    "type": "text",
                    "text": "{\"name\":\"Albert Einstein\",\"age\":76}"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 25,
                    "output_tokens": 15
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-sonnet-4-5-20250929");

        ChatOptions options = new()
        {
            ResponseFormat = ChatResponseFormat.ForJsonSchema(
                JsonElement.Parse(
                    """
                    {
                        "type": "object",
                        "properties": {
                            "name": { "type": "string" },
                            "age": { "type": "integer" }
                        },
                        "required": ["name", "age"]
                    }
                    """
                ),
                "person_info"
            ),
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Tell me about Albert Einstein. Respond with his name and age at death.",
            options,
            TestContext.Current.CancellationToken
        );

        Assert.NotNull(response);
        TextContent textContent = Assert.IsType<TextContent>(response.Messages[0].Contents[0]);
        Assert.Contains("Einstein", textContent.Text);
        Assert.Contains("76", textContent.Text);
    }

    [Fact]
    public async Task GetResponseAsync_WithNestedObjectSchema_ReturnsStructuredJSON()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-sonnet-4-5-20250929",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Tell me about the book '1984' by George Orwell."
                    }]
                }],
                "output_format": {
                    "type": "json_schema",
                    "schema": {
                        "type": "object",
                        "properties": {
                            "title": { "type": "string" },
                            "author": {
                                "type": "object",
                                "properties": {
                                    "name": { "type": "string" },
                                    "birth_year": { "type": "integer" }
                                },
                                "required": ["name", "birth_year"],
                                "additionalProperties": false
                            },
                            "published_year": {
                                "type": "integer"
                            }
                        },
                        "required": ["title", "author", "published_year"],
                        "additionalProperties": false
                    }
                }
            }
            """,
            actualResponse: """
            {
                "id": "msg_format_02",
                "type": "message",
                "role": "assistant",
                "model": "claude-sonnet-4-5-20250929",
                "content": [{
                    "type": "text",
                    "text": "{\"title\":\"1984\",\"author\":{\"name\":\"George Orwell\",\"birth_year\":1903},\"published_year\":1949}"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 30,
                    "output_tokens": 25
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-sonnet-4-5-20250929");

        ChatOptions options = new()
        {
            ResponseFormat = ChatResponseFormat.ForJsonSchema(
                JsonElement.Parse(
                    """
                    {
                        "type": "object",
                        "properties": {
                            "title": { "type": "string" },
                            "author": {
                                "type": "object",
                                "properties": {
                                    "name": { "type": "string" },
                                    "birth_year": { "type": "integer" }
                                },
                                "required": ["name", "birth_year"]
                            },
                            "published_year": { "type": "integer" }
                        },
                        "required": ["title", "author", "published_year"]
                    }
                    """
                ),
                "book_info"
            ),
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Tell me about the book '1984' by George Orwell.",
            options,
            TestContext.Current.CancellationToken
        );

        Assert.NotNull(response);
        TextContent textContent = Assert.IsType<TextContent>(response.Messages[0].Contents[0]);
        Assert.Contains("1984", textContent.Text);
        Assert.Contains("Orwell", textContent.Text);
        Assert.Contains("1903", textContent.Text);
        Assert.Contains("1949", textContent.Text);
    }

    [Fact]
    public async Task GetResponseAsync_WithArraySchema_ReturnsStructuredJSON()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-sonnet-4-5-20250929",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "List 3 common fruits: apple, orange, and banana."
                    }]
                }],
                "output_format": {
                    "type": "json_schema",
                    "schema": {
                        "type": "object",
                        "properties": {
                            "fruits": {
                                "type": "array",
                                "items": {
                                    "type": "object",
                                    "properties": {
                                        "name": { "type": "string" },
                                        "color": { "type": "string" },
                                        "is_citrus": { "type": "boolean" }
                                    },
                                    "required": ["name", "color", "is_citrus"],
                                    "additionalProperties": false
                                }
                            }
                        },
                        "required": ["fruits"],
                        "additionalProperties": false
                    }
                }
            }
            """,
            actualResponse: """
            {
                "id": "msg_format_03",
                "type": "message",
                "role": "assistant",
                "model": "claude-sonnet-4-5-20250929",
                "content": [{
                    "type": "text",
                    "text": "{\"fruits\":[{\"name\":\"apple\",\"color\":\"red\",\"is_citrus\":false},{\"name\":\"orange\",\"color\":\"orange\",\"is_citrus\":true},{\"name\":\"banana\",\"color\":\"yellow\",\"is_citrus\":false}]}"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 35,
                    "output_tokens": 40
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-sonnet-4-5-20250929");

        ChatOptions options = new()
        {
            ResponseFormat = ChatResponseFormat.ForJsonSchema(
                JsonElement.Parse(
                    """
                    {
                        "type": "object",
                        "properties": {
                            "fruits": {
                                "type": "array",
                                "items": {
                                    "type": "object",
                                    "properties": {
                                        "name": { "type": "string" },
                                        "color": { "type": "string" },
                                        "is_citrus": { "type": "boolean" }
                                    },
                                    "required": ["name", "color", "is_citrus"]
                                }
                            }
                        },
                        "required": ["fruits"]
                    }
                    """
                ),
                "fruit_list"
            ),
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "List 3 common fruits: apple, orange, and banana.",
            options,
            TestContext.Current.CancellationToken
        );

        Assert.NotNull(response);
        TextContent textContent = Assert.IsType<TextContent>(response.Messages[0].Contents[0]);
        Assert.Contains("apple", textContent.Text);
        Assert.Contains("orange", textContent.Text);
        Assert.Contains("banana", textContent.Text);
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
        Assert.NotNull(mcpResult.Output);
        Assert.Single(mcpResult.Output);

        ErrorContent errorContent = Assert.IsType<ErrorContent>(mcpResult.Output[0]);
        Assert.Equal("Connection timeout", errorContent.Message);
    }

    [Fact]
    public async Task GetResponseAsync_CodeExecutionToolResult_WithError()
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
                        "text": "Test code execution error"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_code_error_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "code_execution_tool_result",
                    "tool_use_id": "code_exec_error_1",
                    "content": {
                        "type": "code_execution_tool_result_error",
                        "error_code": "execution_time_exceeded"
                    }
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
            "Test code execution error",
            new(),
            TestContext.Current.CancellationToken
        );

        CodeInterpreterToolResultContent codeResult =
            Assert.IsType<CodeInterpreterToolResultContent>(response.Messages[0].Contents[0]);
        Assert.NotNull(codeResult);
        Assert.Equal("code_exec_error_1", codeResult.CallId);
        Assert.NotNull(codeResult.Outputs);
        Assert.Single(codeResult.Outputs);

        ErrorContent errorContent = Assert.IsType<ErrorContent>(codeResult.Outputs[0]);
        Assert.Equal("ExecutionTimeExceeded", errorContent.ErrorCode);
    }

    [Fact]
    public async Task GetResponseAsync_WithFunctionResultContent_HostedFileContent()
    {
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
        );

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
    }

    [Fact]
    public async Task GetResponseAsync_WithAIFunctionTool_AdditionalProperties_FlowsThrough()
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
                        "text": "Use enhanced tool"
                    }]
                }],
                "tools": [{
                    "name": "enhanced_tool",
                    "description": "A tool with additional properties",
                    "input_schema": {
                        "type": "object",
                        "properties": {
                            "query": {
                                "type": "string"
                            }
                        },
                        "required": ["query"]
                    },
                    "defer_loading": true,
                    "strict": true,
                    "input_examples": [
                        {
                            "query": "example query"
                        }
                    ],
                    "allowed_callers": [
                        "direct"
                    ]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_enhanced_tool_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Tool is ready"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 40,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var enhancedFunction = AIFunctionFactory.Create(
            (string query) => "result",
            new AIFunctionFactoryOptions
            {
                Name = "enhanced_tool",
                Description = "A tool with additional properties",
                AdditionalProperties = new Dictionary<string, object?>
                {
                    [nameof(BetaTool.DeferLoading)] = true,
                    [nameof(BetaTool.Strict)] = true,
                    [nameof(BetaTool.InputExamples)] = new List<Dictionary<string, JsonElement>>
                    {
                        new() { ["query"] = JsonSerializer.SerializeToElement("example query") },
                    },
                    [nameof(BetaTool.AllowedCallers)] = new List<
                        ApiEnum<string, BetaToolAllowedCaller>
                    >
                    {
                        new(JsonSerializer.SerializeToElement("direct")),
                    },
                },
            }
        );

        ChatOptions options = new() { Tools = [enhancedFunction] };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Use enhanced tool",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithAIFunctionTool_PartialAdditionalProperties()
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
                        "text": "Use strict tool"
                    }]
                }],
                "tools": [{
                    "name": "strict_tool",
                    "description": "A tool with only strict property",
                    "input_schema": {
                        "type": "object",
                        "properties": {
                            "value": {
                                "type": "integer"
                            }
                        },
                        "required": ["value"]
                    },
                    "strict": true
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_strict_tool_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Strict mode enabled"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 35,
                    "output_tokens": 8
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var strictFunction = AIFunctionFactory.Create(
            (int value) => value * 2,
            new AIFunctionFactoryOptions
            {
                Name = "strict_tool",
                Description = "A tool with only strict property",
                AdditionalProperties = new Dictionary<string, object?>
                {
                    [nameof(BetaTool.Strict)] = true,
                },
            }
        );

        ChatOptions options = new() { Tools = [strictFunction] };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Use strict tool",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
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
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var hostedFile = new HostedFileContent("file_abc123");

        ChatResponse response = await chatClient.GetResponseAsync(
            [new ChatMessage(ChatRole.User, [hostedFile])],
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithHostedCodeInterpreterTool()
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
                        "text": "Execute code"
                    }]
                }],
                "tools": [{
                    "type": "code_execution_20250825",
                    "name": "code_execution"
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_code_exec_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I can execute code."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 15,
                    "output_tokens": 6
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new() { Tools = [new HostedCodeInterpreterTool()] };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Execute code",
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
        Assert.NotNull(mcpResult.Output);
        Assert.Equal(2, mcpResult.Output.Count);
        Assert.Equal("First result", ((TextContent)mcpResult.Output[0]).Text);
        Assert.Equal("Second result", ((TextContent)mcpResult.Output[1]).Text);
    }

    [Fact]
    public async Task GetResponseAsync_CodeExecutionResult_WithStdout()
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
                        "text": "Run code"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_code_stdout_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "code_execution_tool_result",
                    "tool_use_id": "code_exec_1",
                    "content": {
                        "type": "code_execution_result",
                        "stdout": "Hello World\n42\n",
                        "stderr": "",
                        "return_code": 0,
                        "content": []
                    }
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
            "Run code",
            new(),
            TestContext.Current.CancellationToken
        );

        CodeInterpreterToolResultContent codeResult =
            Assert.IsType<CodeInterpreterToolResultContent>(response.Messages[0].Contents[0]);
        Assert.NotNull(codeResult);
        Assert.Equal("code_exec_1", codeResult.CallId);
        Assert.NotNull(codeResult.Outputs);
        Assert.Single(codeResult.Outputs);

        TextContent textOutput = Assert.IsType<TextContent>(codeResult.Outputs[0]);
        Assert.Equal("Hello World\n42\n", textOutput.Text);
    }

    [Fact]
    public async Task GetResponseAsync_CodeExecutionResult_WithStderrAndNonZeroReturnCode()
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
                        "text": "Run failing code"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_code_stderr_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "code_execution_tool_result",
                    "tool_use_id": "code_exec_2",
                    "content": {
                        "type": "code_execution_result",
                        "stdout": "",
                        "stderr": "Division by zero error",
                        "return_code": 1,
                        "content": []
                    }
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
            "Run failing code",
            new(),
            TestContext.Current.CancellationToken
        );

        CodeInterpreterToolResultContent codeResult =
            Assert.IsType<CodeInterpreterToolResultContent>(response.Messages[0].Contents[0]);
        Assert.NotNull(codeResult.Outputs);
        Assert.Single(codeResult.Outputs);

        ErrorContent errorOutput = Assert.IsType<ErrorContent>(codeResult.Outputs[0]);
        Assert.Equal("Division by zero error", errorOutput.Message);
        Assert.Equal("1", errorOutput.ErrorCode);
    }

    [Fact]
    public async Task GetResponseAsync_CodeExecutionResult_WithFileOutputs()
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
                        "text": "Create file"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_code_files_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "code_execution_tool_result",
                    "tool_use_id": "code_exec_3",
                    "content": {
                        "type": "code_execution_result",
                        "stdout": "File created",
                        "stderr": "",
                        "return_code": 0,
                        "content": [{
                            "type": "code_execution_output",
                            "file_id": "file_output_123"
                        }, {
                            "type": "code_execution_output",
                            "file_id": "file_output_456"
                        }]
                    }
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
            "Create file",
            new(),
            TestContext.Current.CancellationToken
        );

        CodeInterpreterToolResultContent codeResult =
            Assert.IsType<CodeInterpreterToolResultContent>(response.Messages[0].Contents[0]);
        Assert.NotNull(codeResult.Outputs);
        Assert.Equal(3, codeResult.Outputs.Count);

        TextContent textOutput = Assert.IsType<TextContent>(codeResult.Outputs[0]);
        Assert.Equal("File created", textOutput.Text);

        HostedFileContent fileOutput1 = Assert.IsType<HostedFileContent>(codeResult.Outputs[1]);
        Assert.Equal("file_output_123", fileOutput1.FileId);

        HostedFileContent fileOutput2 = Assert.IsType<HostedFileContent>(codeResult.Outputs[2]);
        Assert.Equal("file_output_456", fileOutput2.FileId);
    }

    [Fact]
    public async Task GetResponseAsync_BashCodeExecutionResult_WithStdout()
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
                        "text": "Run bash"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_bash_stdout_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "bash_code_execution_tool_result",
                    "tool_use_id": "bash_exec_1",
                    "content": {
                        "type": "bash_code_execution_result",
                        "stdout": "Hello from bash\n5\n",
                        "stderr": "",
                        "return_code": 0,
                        "content": []
                    }
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
            "Run bash",
            new(),
            TestContext.Current.CancellationToken
        );

        CodeInterpreterToolResultContent codeResult =
            Assert.IsType<CodeInterpreterToolResultContent>(response.Messages[0].Contents[0]);
        Assert.NotNull(codeResult);
        Assert.Equal("bash_exec_1", codeResult.CallId);
        Assert.NotNull(codeResult.Outputs);
        Assert.Single(codeResult.Outputs);

        TextContent textOutput = Assert.IsType<TextContent>(codeResult.Outputs[0]);
        Assert.Equal("Hello from bash\n5\n", textOutput.Text);
    }

    [Fact]
    public async Task GetResponseAsync_BashCodeExecutionResult_WithStderrAndNonZeroReturnCode()
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
                        "text": "Run failing bash"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_bash_stderr_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "bash_code_execution_tool_result",
                    "tool_use_id": "bash_exec_2",
                    "content": {
                        "type": "bash_code_execution_result",
                        "stdout": "",
                        "stderr": "bash: command not found: nonexistent",
                        "return_code": 127,
                        "content": []
                    }
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
            "Run failing bash",
            new(),
            TestContext.Current.CancellationToken
        );

        CodeInterpreterToolResultContent codeResult =
            Assert.IsType<CodeInterpreterToolResultContent>(response.Messages[0].Contents[0]);
        Assert.NotNull(codeResult.Outputs);
        Assert.Single(codeResult.Outputs);

        ErrorContent errorOutput = Assert.IsType<ErrorContent>(codeResult.Outputs[0]);
        Assert.Equal("bash: command not found: nonexistent", errorOutput.Message);
        Assert.Equal("127", errorOutput.ErrorCode);
    }

    [Fact]
    public async Task GetResponseAsync_BashCodeExecutionResult_WithFileOutputs()
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
                        "text": "Create files with bash"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_bash_files_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "bash_code_execution_tool_result",
                    "tool_use_id": "bash_exec_3",
                    "content": {
                        "type": "bash_code_execution_result",
                        "stdout": "Files created successfully",
                        "stderr": "",
                        "return_code": 0,
                        "content": [{
                            "type": "bash_code_execution_output",
                            "file_id": "file_bash_123"
                        }, {
                            "type": "bash_code_execution_output",
                            "file_id": "file_bash_456"
                        }]
                    }
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
            "Create files with bash",
            new(),
            TestContext.Current.CancellationToken
        );

        CodeInterpreterToolResultContent codeResult =
            Assert.IsType<CodeInterpreterToolResultContent>(response.Messages[0].Contents[0]);
        Assert.NotNull(codeResult.Outputs);
        Assert.Equal(3, codeResult.Outputs.Count);

        TextContent textOutput = Assert.IsType<TextContent>(codeResult.Outputs[0]);
        Assert.Equal("Files created successfully", textOutput.Text);

        HostedFileContent fileOutput1 = Assert.IsType<HostedFileContent>(codeResult.Outputs[1]);
        Assert.Equal("file_bash_123", fileOutput1.FileId);

        HostedFileContent fileOutput2 = Assert.IsType<HostedFileContent>(codeResult.Outputs[2]);
        Assert.Equal("file_bash_456", fileOutput2.FileId);
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
                    capturedUserAgentValues = values.ToArray();
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
                    capturedUserAgentValues = values.ToArray();
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
                    capturedUserAgentValues = values.ToArray();
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
        // Verify the MEAI user-agent is present and has correct format
        Assert.Contains(
            capturedUserAgentValues,
            v => System.Text.RegularExpressions.Regex.IsMatch(v, @"MEAI(/[\d\.]+)?")
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
}
