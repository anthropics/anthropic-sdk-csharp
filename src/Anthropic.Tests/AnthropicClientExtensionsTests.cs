using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anthropic;
using Anthropic.Models.Messages;

#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace Microsoft.Extensions.AI.Tests;

public class AnthropicClientExtensionsTests : AnthropicClientExtensionsTestsBase
{
    protected override IChatClient CreateChatClient(
        AnthropicClient client,
        string? modelId = null,
        int? defaultMaxOutputTokens = null
    ) => client.AsIChatClient(modelId, defaultMaxOutputTokens);

    [Fact]
    public void AsIChatClient_ReturnsValidChatClient()
    {
        AnthropicClient client = new() { APIKey = "test-key" };
        Assert.NotNull(client.AsIChatClient("claude-haiku-4-5"));
    }

    [Fact]
    public void AsIChatClient_ThrowsOnNullClient()
    {
        IAnthropicClient client = null!;
        Assert.Throws<ArgumentNullException>(() => client.AsIChatClient());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void AsIChatClient_ThrowsOnNonPositiveDefaultMaxTokens(int defaultMaxTokens)
    {
        AnthropicClient client = new() { APIKey = "test-key" };
        Assert.Throws<ArgumentOutOfRangeException>(
            "defaultMaxOutputTokens",
            () => client.AsIChatClient(defaultMaxOutputTokens: defaultMaxTokens)
        );
    }

    [Fact]
    public void AsIChatClient_GetService_ReturnsClient()
    {
        AnthropicClient client = new() { APIKey = "test-key" };
        IChatClient chatClient = CreateChatClient(client, "claude-haiku-4-5");

        Assert.Same(client, chatClient.GetService<AnthropicClient>());
        Assert.Same(client, chatClient.GetService<IAnthropicClient>());
    }

    [Fact]
    public void AsAITool_ThrowsOnNullToolUnion()
    {
        Assert.Throws<ArgumentNullException>("tool", () => ((ToolUnion)null!).AsAITool());
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

        var rawMessage = response.RawRepresentation as Message;
        Assert.NotNull(rawMessage);
        Assert.Equal("msg_raw_01", rawMessage.ID);
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

        var textContent = response.Messages[0].Contents[0] as TextContent;
        Assert.NotNull(textContent);
        Assert.NotNull(textContent.RawRepresentation);
        Assert.IsType<TextBlock>(textContent.RawRepresentation);

        var toolCall = response.Messages[0].Contents[1] as FunctionCallContent;
        Assert.NotNull(toolCall);
        Assert.NotNull(toolCall.RawRepresentation);
        Assert.IsType<ToolUseBlock>(toolCall.RawRepresentation);
    }

    [Fact]
    public async Task GetResponseAsync_WithToolUnionAsAITool_FlowsThroughToRequest()
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
                                "text": "Search the web"
                            }
                        ]
                    }
                ],
                "model": "claude-haiku-4-5",
                "tools": [
                    {
                        "type": "web_search_20250305",
                        "name": "web_search",
                        "allowed_domains": [
                            "github.com"
                        ]
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_toolunion_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I'll search for that."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 15,
                    "output_tokens": 8
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ToolUnion toolUnion = new WebSearchTool20250305() { AllowedDomains = ["github.com"] };

        ChatOptions options = new() { Tools = [toolUnion.AsAITool()] };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Search the web",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public void AsAITool_GetService_ReturnsToolUnion()
    {
        ToolUnion toolUnion = new WebSearchTool20250305() { AllowedDomains = ["example.com"] };
        AITool aiTool = toolUnion.AsAITool();

        Assert.Same(toolUnion, aiTool.GetService<ToolUnion>());

        Assert.Null(aiTool.GetService<ToolUnion>("key"));
        Assert.Null(aiTool.GetService<string>());

        Assert.NotNull(aiTool.Name);
        Assert.Contains(nameof(WebSearchTool20250305), aiTool.Name);
    }

    [Fact]
    public void AsAITool_GetService_ThrowsOnNullServiceType()
    {
        AITool aiTool = (
            (ToolUnion)new WebSearchTool20250305() { AllowedDomains = ["example.com"] }
        ).AsAITool();
        Assert.Throws<ArgumentNullException>(() => aiTool.GetService(null!, null));
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
                    new MessageParam()
                    {
                        Role = Role.User,
                        Content = new MessageParamContent(
                            [new TextBlockParam() { Text = "Preconfigured message" }]
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
                System = new System.Collections.Generic.List<TextBlockParam>
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
}
