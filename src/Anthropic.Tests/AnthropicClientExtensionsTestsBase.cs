using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic;
using Anthropic.Core;
using Anthropic.Models.Messages;

#pragma warning disable MEAI001 // [Experimental] APIs in Microsoft.Extensions.AI
#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace Microsoft.Extensions.AI.Tests;

public abstract class AnthropicClientExtensionsTestsBase
{
    protected abstract IChatClient CreateChatClient(
        AnthropicClient client,
        string? modelId = null,
        int? defaultMaxOutputTokens = null
    );

    protected static AnthropicClient CreateAnthropicClient(VerbatimHttpHandler handler)
    {
        return new AnthropicClient
        {
            HttpClient = new(handler) { BaseAddress = new Uri("http://localhost") },
            ApiKey = "test-key",
        };
    }

    protected IChatClient CreateChatClient(
        VerbatimHttpHandler handler,
        string? modelId = null,
        int? defaultMaxOutputTokens = null
    ) => CreateChatClient(CreateAnthropicClient(handler), modelId, defaultMaxOutputTokens);

    [Theory]
    [InlineData(null)]
    [InlineData("claude-haiku-4-5")]
    public void AsIChatClient_GetService_ReturnsKnownTypes(string? defaultModelId)
    {
        IChatClient chatClient = CreateChatClient(new VerbatimHttpHandler("", ""), defaultModelId);

        ChatClientMetadata? metadata = chatClient.GetService<ChatClientMetadata>();
        Assert.NotNull(metadata);
        Assert.Equal("anthropic", metadata.ProviderName);
        Assert.Equal(new Uri("https://api.anthropic.com/"), metadata.ProviderUri);
        Assert.Equal(defaultModelId, metadata.DefaultModelId);

        Assert.Same(chatClient, chatClient.GetService<IChatClient>());

        Assert.Null(chatClient.GetService<string>());
    }

    [Fact]
    public void AsIChatClient_GetService_ThrowsOnNullServiceType()
    {
        IChatClient chatClient = CreateChatClient(
            new VerbatimHttpHandler("", ""),
            "claude-haiku-4-5"
        );
        Assert.Throws<ArgumentNullException>(() => chatClient.GetService(null!, null));
    }

    [Fact]
    public void AsIChatClient_GetService_ReturnsNullWithNonNullServiceKey()
    {
        IChatClient chatClient = CreateChatClient(
            new VerbatimHttpHandler("", ""),
            "claude-haiku-4-5"
        );
        Assert.Null(chatClient.GetService(typeof(string), "someKey"));
    }

    [Fact]
    public void AsIChatClient_GetService_ReturnsMetadata()
    {
        AnthropicClient client = new() { ApiKey = "test-key" };
        IChatClient chatClient = CreateChatClient(client, "claude-haiku-4-5");

        var metadata = chatClient.GetService<ChatClientMetadata>();

        Assert.NotNull(metadata);
        Assert.Equal("anthropic", metadata.ProviderName);
        Assert.Equal("claude-haiku-4-5", metadata.DefaultModelId);
    }

    [Fact]
    public void AsIChatClient_GetService_ReturnsSelf()
    {
        AnthropicClient client = new() { ApiKey = "test-key" };
        IChatClient chatClient = CreateChatClient(client, "claude-haiku-4-5");

        var self = chatClient.GetService<IChatClient>();

        Assert.NotNull(self);
        Assert.Same(chatClient, self);
    }

    [Fact]
    public void IChatClient_Dispose_Nop()
    {
        IChatClient chatClient = CreateChatClient(
            new VerbatimHttpHandler("", ""),
            "claude-haiku-4-5"
        );
        Assert.NotNull(chatClient);
        chatClient.Dispose();
        chatClient.Dispose();
    }

    [Theory]
    [InlineData(null, 1024)]
    [InlineData(42, 42)]
    [InlineData(2048, 2048)]
    public async Task GetResponseAsync_BasicTextCompletion(
        int? defaultMaxOutputTokens,
        int expectedMaxTokens
    )
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: $$"""
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "What is 2+2?"
                    }]
                }],
                "max_tokens": {{expectedMaxTokens}}
            }
            """,
            actualResponse: """
            {
                "id": "msg_01XFDUDYJgAACzvnptvVoYEL",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "4"
                }],
                "stop_reason": "end_turn",
                "stop_sequence": null,
                "usage": {
                    "input_tokens": 12,
                    "output_tokens": 5
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(
            handler,
            "claude-haiku-4-5",
            defaultMaxOutputTokens
        );

        ChatResponse response = await chatClient.GetResponseAsync(
            "What is 2+2?",
            new(),
            TestContext.Current.CancellationToken
        );

        Assert.NotNull(response);
        Assert.Single(response.Messages);
        Assert.Equal(ChatRole.Assistant, response.Messages[0].Role);
        Assert.Single(response.Messages[0].Contents);

        var textContent = response.Messages[0].Contents[0] as TextContent;
        Assert.NotNull(textContent);
        Assert.Equal("4", textContent.Text);

        Assert.NotNull(response.Usage);
        Assert.Equal(12, response.Usage.InputTokenCount);
        Assert.Equal(5, response.Usage.OutputTokenCount);
        Assert.Equal(17, response.Usage.TotalTokenCount);
    }

    [Fact]
    public async Task GetResponseAsync_WithSystemMessage()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Say hello"
                    }]
                }],
                "max_tokens": 1024,
                "system": [{
                    "type": "text",
                    "text": "You are a helpful assistant that responds in French."
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_02",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Bonjour!"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 20,
                    "output_tokens": 3
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatMessage> messages =
        [
            new(ChatRole.System, "You are a helpful assistant that responds in French."),
            new(ChatRole.User, "Say hello"),
        ];

        ChatResponse response = await chatClient.GetResponseAsync(
            messages,
            new(),
            TestContext.Current.CancellationToken
        );

        Assert.NotNull(response);
        var textContent = response.Messages[0].Contents[0] as TextContent;
        Assert.NotNull(textContent);
        Assert.Equal("Bonjour!", textContent.Text);
    }

    [Fact]
    public async Task GetResponseAsync_WithChatOptions()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Tell me a story"
                    }]
                }],
                "max_tokens": 100,
                "temperature": 0.5,
                "top_p": 0.75
            }
            """,
            actualResponse: """
            {
                "id": "msg_03",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Creative response"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 15,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new()
        {
            Temperature = 0.5f,
            MaxOutputTokens = 100,
            TopP = 0.75f,
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Tell me a story",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Theory]
    [InlineData(null, 100, 100)]
    [InlineData(42, 100, 100)]
    [InlineData(500, null, 500)]
    [InlineData(500, 100, 100)]
    public async Task GetResponseAsync_MaxOutputTokens_OptionsOverridesDefault(
        int? defaultMaxOutputTokens,
        int? optionsMaxOutputTokens,
        int expectedMaxTokens
    )
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: $$"""
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Generate text"
                    }]
                }],
                "max_tokens": {{expectedMaxTokens}}
            }
            """,
            actualResponse: """
            {
                "id": "msg_max_tokens_01",
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

        IChatClient chatClient = CreateChatClient(
            handler,
            "claude-haiku-4-5",
            defaultMaxOutputTokens
        );

        ChatOptions? options = optionsMaxOutputTokens.HasValue
            ? new() { MaxOutputTokens = optionsMaxOutputTokens.Value }
            : null;

        ChatResponse response = await chatClient.GetResponseAsync(
            "Generate text",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_MultiTurnConversation()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [
                    {
                        "role": "user",
                        "content": [{
                            "type": "text",
                            "text": "Hi!"
                        }]
                    },
                    {
                        "role": "assistant",
                        "content": [{
                            "type": "text",
                            "text": "Hello! How can I help you?"
                        }]
                    },
                    {
                        "role": "user",
                        "content": [{
                            "type": "text",
                            "text": "How are you?"
                        }]
                    }
                ],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_04",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I'm doing great, thanks!"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 25,
                    "output_tokens": 8
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatMessage> messages =
        [
            new(ChatRole.User, "Hi!"),
            new(ChatRole.Assistant, "Hello! How can I help you?"),
            new(ChatRole.User, "How are you?"),
        ];

        ChatResponse response = await chatClient.GetResponseAsync(
            messages,
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        var textContent = response.Messages[0].Contents[0] as TextContent;
        Assert.NotNull(textContent);
        Assert.Equal("I'm doing great, thanks!", textContent.Text);
    }

    [Fact]
    public async Task GetResponseAsync_WithStopSequences()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Generate text"
                    }]
                }],
                "max_tokens": 1024,
                "stop_sequences": ["###", "DONE"]
            }
            """,
            actualResponse: """
            {
                "id": "msg_05",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Response stopped early"
                }],
                "stop_reason": "stop_sequence",
                "stop_sequence": "###",
                "usage": {
                    "input_tokens": 10,
                    "output_tokens": 4
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new() { StopSequences = ["###", "DONE"] };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Generate text",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        Assert.Equal(ChatFinishReason.Stop, response.FinishReason);
    }

    [Fact]
    public async Task GetResponseAsync_WithMaxTokensStop()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Write a long story"
                    }]
                }],
                "max_tokens": 50
            }
            """,
            actualResponse: """
            {
                "id": "msg_06",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "This response was cut off because it reached the maximum token limit"
                }],
                "stop_reason": "max_tokens",
                "usage": {
                    "input_tokens": 10,
                    "output_tokens": 50
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new() { MaxOutputTokens = 50 };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Write a long story",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        Assert.Equal(ChatFinishReason.Length, response.FinishReason);
    }

    [Fact]
    public async Task GetResponseAsync_VerifiesModelIdRequired()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: string.Empty,
            actualResponse: string.Empty
        );
        var client = CreateAnthropicClient(handler);
        IChatClient chatClient = client.AsIChatClient(); // No default model

        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await chatClient.GetResponseAsync("Test", new(), TestContext.Current.CancellationToken)
        );
    }

    [Fact]
    public async Task GetResponseAsync_UsesModelIdFromOptions()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-3-opus-20240229",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Test"
                    }]
                }],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_07",
                "type": "message",
                "role": "assistant",
                "model": "claude-3-opus-20240229",
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

        ChatOptions options = new() { ModelId = "claude-3-opus-20240229" };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Test",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_HandlesEmptyContentList()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": "\u200b"
                }],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_08",
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
                    "output_tokens": 2
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatMessage> messages = [new(ChatRole.User, [])];

        ChatResponse response = await chatClient.GetResponseAsync(
            messages,
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetStreamingResponseAsync_BasicTextCompletion()
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
                        "text": "Say hello"
                    }]
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_stream_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"Hello"}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":" world"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":5}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Say hello",
                new(),
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }
        Assert.NotEmpty(updates);

        // Check that we received text deltas
        var textUpdates = updates.Where(u => u.Contents.Any(c => c is TextContent)).ToList();
        Assert.NotEmpty(textUpdates);

        // Concatenate all text
        var allText = string.Concat(
            textUpdates.SelectMany(u => u.Contents.OfType<TextContent>()).Select(c => c.Text)
        );
        Assert.Contains("Hello", allText);
        Assert.Contains("world", allText);

        // Check for usage update
        var usageUpdates = updates.Where(u => u.Contents.Any(c => c is UsageContent)).ToList();
        Assert.NotEmpty(usageUpdates);

        var usageContent = usageUpdates
            .SelectMany(u => u.Contents.OfType<UsageContent>())
            .FirstOrDefault();
        Assert.NotNull(usageContent);
        Assert.True(usageContent.Details.TotalTokenCount > 0);
    }

    [Fact]
    public async Task GetResponseAsync_WithTextDataContent()
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
                            "type": "text",
                            "media_type": "text/plain",
                            "data": "Sample text content"
                        }
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_text_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I read the text."
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

        var dataContent = new DataContent(
            Encoding.UTF8.GetBytes("Sample text content"),
            "text/plain"
        );

        ChatResponse response = await chatClient.GetResponseAsync(
            [new ChatMessage(ChatRole.User, [dataContent])],
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithImageUriContent()
    {
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
                            "type": "url",
                            "url": "https://example.com/image.jpg"
                        }
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_img_uri_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I see the image."
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

        var imageUri = new UriContent(new Uri("https://example.com/image.jpg"), "image/jpeg");

        ChatResponse response = await chatClient.GetResponseAsync(
            [new ChatMessage(ChatRole.User, [imageUri])],
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithPdfUriContent()
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
                            "type": "url",
                            "url": "https://example.com/document.pdf"
                        }
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_pdf_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I analyzed the PDF."
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

        var pdfUri = new UriContent(new Uri("https://example.com/document.pdf"), "application/pdf");

        ChatResponse response = await chatClient.GetResponseAsync(
            [new ChatMessage(ChatRole.User, [pdfUri])],
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithToolCalls()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "What's the weather in San Francisco?"
                    }]
                }],
                "max_tokens": 1024,
                "tools": [{
                    "name": "get_weather",
                    "description": "Get the current weather for a location",
                    "input_schema": {
                        "type": "object",
                        "properties": {
                            "location": { "type": "string", "description": "The city and state" },
                            "unit": { "type": "string", "description": "Temperature unit" }
                        },
                        "required": ["location", "unit"],
                        "additionalProperties": false
                    }
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_tool_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "tool_use",
                    "id": "toolu_12345",
                    "name": "get_weather",
                    "input": {
                        "location": "San Francisco",
                        "unit": "celsius"
                    },
                    "caller": {"type": "direct"}
                }],
                "stop_reason": "tool_use",
                "usage": {
                    "input_tokens": 30,
                    "output_tokens": 15
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        // Create a proper AIFunction with complete schema
        var weatherFunction = AIFunctionFactory.CreateDeclaration(
            "get_weather",
            "Get the current weather for a location",
            JsonElement.Parse(
                """
                {
                    "type": "object",
                    "properties": {
                        "location": { "type": "string", "description": "The city and state" },
                        "unit": { "type": "string", "description": "Temperature unit" }
                    },
                    "required": ["location", "unit"]
                }
                """
            )
        );

        ChatOptions options = new() { Tools = [weatherFunction] };

        ChatResponse response = await chatClient.GetResponseAsync(
            "What's the weather in San Francisco?",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
        Assert.Equal(ChatFinishReason.ToolCalls, response.FinishReason);

        var functionCall = response
            .Messages[0]
            .Contents.OfType<FunctionCallContent>()
            .FirstOrDefault();
        Assert.NotNull(functionCall);
        Assert.Equal("get_weather", functionCall.Name);
        Assert.Equal("toolu_12345", functionCall.CallId);
        Assert.NotNull(functionCall.Arguments);
        Assert.Contains("location", functionCall.Arguments.Keys);
        Assert.Contains("unit", functionCall.Arguments.Keys);
    }

    [Fact]
    public async Task GetResponseAsync_WithParameterlessToolCall()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Get the current time"
                    }]
                }],
                "max_tokens": 1024,
                "tools": [{
                    "name": "get_current_time",
                    "description": "Gets the current time",
                    "input_schema": {
                        "type": "object",
                        "properties": {},
                        "additionalProperties": false
                    }
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_parameterless_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "tool_use",
                    "id": "toolu_paramless_1",
                    "name": "get_current_time",
                    "input": {},
                    "caller": {"type": "direct"}
                }],
                "stop_reason": "tool_use",
                "usage": {
                    "input_tokens": 20,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var timeFunction = AIFunctionFactory.Create(
            () => DateTime.Now.ToString(),
            "get_current_time",
            "Gets the current time"
        );

        ChatOptions options = new() { Tools = [timeFunction] };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Get the current time",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
        Assert.Equal(ChatFinishReason.ToolCalls, response.FinishReason);

        var functionCall = response
            .Messages[0]
            .Contents.OfType<FunctionCallContent>()
            .FirstOrDefault();
        Assert.NotNull(functionCall);
        Assert.Equal("get_current_time", functionCall.Name);
        Assert.Equal("toolu_paramless_1", functionCall.CallId);
        Assert.True(functionCall.Arguments == null || functionCall.Arguments.Count == 0);
    }

    [Fact]
    public async Task GetResponseAsync_WithMultiModalContent()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [
                    {
                        "role": "user",
                        "content": [
                            {
                                "type": "text",
                                "text": "What do you see in this image?"
                            },
                            {
                                "type": "image",
                                "source": {
                                    "type": "base64",
                                    "media_type": "image/png",
                                    "data": "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+M9QDwADhgGAWjR9awAAAABJRU5ErkJggg=="
                                }
                            }
                        ]
                    }
                ],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_multimodal_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I see a cat in the image."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 1050,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatMessage> messages =
        [
            new(
                ChatRole.User,
                [
                    new TextContent("What do you see in this image?"),
                    new DataContent(
                        "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+M9QDwADhgGAWjR9awAAAABJRU5ErkJggg==",
                        "image/png"
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

        var textContent = response.Messages[0].Contents.OfType<TextContent>().FirstOrDefault();
        Assert.NotNull(textContent);
        Assert.Contains("cat", textContent.Text, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task GetResponseAsync_WithInstructions()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Say hello"
                    }]
                }],
                "max_tokens": 1024,
                "system": [{
                    "type": "text",
                    "text": "Always respond in French."
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_instructions_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Bonjour mon ami!"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 25,
                    "output_tokens": 5
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new() { Instructions = "Always respond in French." };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Say hello",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithFunctionResults()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [
                    {
                        "role": "user",
                        "content": [{
                            "type": "text",
                            "text": "What's the weather?"
                        }]
                    },
                    {
                        "role": "assistant",
                        "content": [{
                            "type": "tool_use",
                            "id": "toolu_12345",
                            "name": "get_weather",
                            "input": {
                                "location": "San Francisco",
                                "unit": "celsius"
                            }
                        }]
                    },
                    {
                        "role": "user",
                        "content": [{
                            "type": "tool_result",
                            "tool_use_id": "toolu_12345",
                            "content": "Sunny, 22 degrees celsius",
                            "is_error": false
                        }]
                    }
                ],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_func_result_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Based on the weather data, it's a beautiful sunny day in San Francisco with 22 degrees!"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 45,
                    "output_tokens": 20
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatMessage> messages =
        [
            new(ChatRole.User, "What's the weather?"),
            new(
                ChatRole.Assistant,
                [
                    new FunctionCallContent(
                        "toolu_12345",
                        "get_weather",
                        new Dictionary<string, object?>
                        {
                            ["location"] = "San Francisco",
                            ["unit"] = "celsius",
                        }
                    ),
                ]
            ),
            new(
                ChatRole.User,
                [new FunctionResultContent("toolu_12345", "Sunny, 22 degrees celsius")]
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
    public async Task GetResponseAsync_WithTopK()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Test"
                    }]
                }],
                "max_tokens": 1024,
                "top_k": 50
            }
            """,
            actualResponse: """
            {
                "id": "msg_topk_01",
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

        ChatOptions options = new() { TopK = 50 };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Test",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithCacheCreationTokens()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Test with caching"
                    }]
                }],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_cache_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Response"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 100,
                    "output_tokens": 10,
                    "cache_creation_input_tokens": 50,
                    "cache_read_input_tokens": 25
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatResponse response = await chatClient.GetResponseAsync(
            "Test with caching",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        Assert.NotNull(response.Usage);
        Assert.Equal(175, response.Usage.InputTokenCount);
        Assert.Equal(10, response.Usage.OutputTokenCount);
        Assert.Equal(185, response.Usage.TotalTokenCount);
        Assert.NotNull(response.Usage.AdditionalCounts);
        Assert.Equal(50L, response.Usage.AdditionalCounts["CacheCreationInputTokens"]);
        Assert.Equal(25L, response.Usage.CachedInputTokenCount);
    }

    [Fact]
    public async Task GetResponseAsync_WithResponseIdAndMessageId()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Test"
                    }]
                }],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_id_test_01",
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

        Assert.Equal("msg_id_test_01", response.ResponseId);
        Assert.Single(response.Messages);
        Assert.Equal("msg_id_test_01", response.Messages[0].MessageId);
    }

    [Fact]
    public async Task GetResponseAsync_WithToolModeAuto()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "What's the weather?"
                    }]
                }],
                "model": "claude-haiku-4-5",
                "max_tokens": 1024,
                "tool_choice": {
                    "type": "auto"
                },
                "tools": [{
                    "name": "get_weather",
                    "description": "Get weather",
                    "input_schema": {
                        "type": "object",
                        "properties": {
                            "location": { "type": "string", "description": "The location" }
                        },
                        "required": ["location"],
                        "additionalProperties": false
                    }
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_toolmode_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I'll help you with that."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 20,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var weatherFunction = AIFunctionFactory.CreateDeclaration(
            "get_weather",
            "Get weather",
            JsonElement.Parse(
                """
                {
                    "type": "object",
                    "properties": {
                        "location": { "type": "string", "description": "The location" }
                    },
                    "required": ["location"]
                }
                """
            )
        );

        ChatOptions options = new() { Tools = [weatherFunction], ToolMode = ChatToolMode.Auto };

        ChatResponse response = await chatClient.GetResponseAsync(
            "What's the weather?",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithToolModeRequired()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Tell me the weather"
                    }]
                }],
                "max_tokens": 1024,
                "tool_choice": {
                    "type": "any"
                },
                "tools": [{
                    "name": "get_weather",
                    "description": "Get weather",
                    "input_schema": {
                        "type": "object",
                        "properties": {
                            "location": { "type": "string", "description": "The location" }
                        },
                        "required": ["location"],
                        "additionalProperties": false
                    }
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_toolmode_02",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "tool_use",
                    "id": "toolu_abc",
                    "name": "get_weather",
                    "input": {"location": "Paris"},
                    "caller": {"type": "direct"}
                }],
                "stop_reason": "tool_use",
                "usage": {
                    "input_tokens": 20,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var weatherFunction = AIFunctionFactory.CreateDeclaration(
            "get_weather",
            "Get weather",
            JsonElement.Parse(
                """
                {
                    "type": "object",
                    "properties": {
                        "location": { "type": "string", "description": "The location" }
                    },
                    "required": ["location"]
                }
                """
            )
        );

        ChatOptions options = new()
        {
            Tools = [weatherFunction],
            ToolMode = ChatToolMode.RequireAny,
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Tell me the weather",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithToolModeNone()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Tell me about weather"
                    }]
                }],
                "max_tokens": 1024,
                "tool_choice": {
                    "type": "none"
                },
                "tools": [{
                    "name": "get_weather",
                    "description": "Get weather",
                    "input_schema": {
                        "type": "object",
                        "properties": {
                            "location": { "type": "string", "description": "The location" }
                        },
                        "required": ["location"],
                        "additionalProperties": false
                    }
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_toolmode_03",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I cannot use tools for this."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 20,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var weatherFunction = AIFunctionFactory.CreateDeclaration(
            "get_weather",
            "Get weather",
            JsonElement.Parse(
                """
                {
                    "type": "object",
                    "properties": {
                        "location": { "type": "string", "description": "The location" }
                    },
                    "required": ["location"]
                }
                """
            )
        );

        ChatOptions options = new() { Tools = [weatherFunction], ToolMode = ChatToolMode.None };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Tell me about weather",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithMultipleToolCalls()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "What's the weather in Paris and London?"
                    }]
                }],
                "max_tokens": 1024,
                "tools": [{
                    "name": "get_weather",
                    "description": "",
                    "input_schema": {
                        "type": "object",
                        "properties": {
                            "location": { "type": "string" }
                        },
                        "required": ["location"],
                        "additionalProperties": false
                    }
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_multi_tools_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "tool_use",
                    "id": "toolu_1",
                    "name": "get_weather",
                    "input": {"location": "Paris"},
                    "caller": {"type": "direct"}
                }, {
                    "type": "tool_use",
                    "id": "toolu_2",
                    "name": "get_weather",
                    "input": {"location": "London"},
                    "caller": {"type": "direct"}
                }],
                "stop_reason": "tool_use",
                "usage": {
                    "input_tokens": 30,
                    "output_tokens": 20
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var weatherFunction = AIFunctionFactory.Create((string location) => "Sunny", "get_weather");

        ChatOptions options = new() { Tools = [weatherFunction], AllowMultipleToolCalls = true };

        ChatResponse response = await chatClient.GetResponseAsync(
            "What's the weather in Paris and London?",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        var functionCalls = response.Messages[0].Contents.OfType<FunctionCallContent>().ToList();
        Assert.Equal(2, functionCalls.Count);
        Assert.All(functionCalls, fc => Assert.Equal("get_weather", fc.Name));
    }

    [Fact]
    public async Task GetResponseAsync_WithPdfDocument()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [
                    {
                        "role": "user",
                        "content": [
                            {
                                "type": "text",
                                "text": "What is this document about?"
                            },
                            {
                                "type": "document",
                                "source": {
                                    "type": "base64",
                                    "media_type": "application/pdf",
                                    "data": "JVBERi0xLjQKJeLjz9MKMSAwIG9iag=="
                                }
                            }
                        ]
                    }
                ],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_pdf_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "This is a PDF document about AI."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 2000,
                    "output_tokens": 15
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatMessage> messages =
        [
            new(
                ChatRole.User,
                [
                    new TextContent("What is this document about?"),
                    new DataContent(
                        "data:application/pdf;base64,JVBERi0xLjQKJeLjz9MKMSAwIG9iag==",
                        "application/pdf"
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
    }

    [Fact]
    public async Task GetResponseAsync_WithUriBasedImage()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [
                    {
                        "role": "user",
                        "content": [
                            {
                                "type": "text",
                                "text": "What's in this image?"
                            },
                            {
                                "type": "image",
                                "source": {
                                    "type": "url",
                                    "url": "https://example.com/image.jpg"
                                }
                            }
                        ]
                    }
                ],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_uri_img_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I see a beautiful landscape."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 1200,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatMessage> messages =
        [
            new(
                ChatRole.User,
                [
                    new TextContent("What's in this image?"),
                    new UriContent(new Uri("https://example.com/image.jpg"), "image/jpeg"),
                ]
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
    public async Task GetResponseAsync_WithRefusalFinishReason()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Inappropriate request"
                    }]
                }],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_refusal_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I cannot help with that request."
                }],
                "stop_reason": "refusal",
                "usage": {
                    "input_tokens": 15,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatResponse response = await chatClient.GetResponseAsync(
            "Inappropriate request",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        Assert.Equal(ChatFinishReason.ContentFilter, response.FinishReason);
    }

    [Fact]
    public async Task GetResponseAsync_WithInstructionsAndSystemMessage()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Say hello"
                    }]
                }],
                "max_tokens": 1024,
                "system": [{
                    "type": "text",
                    "text": "You respond in French."
                }, {
                    "type": "text",
                    "text": "Always use formal language."
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_combined_sys_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Bonjour en style formel!"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 25,
                    "output_tokens": 8
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new() { Instructions = "Always use formal language." };

        List<ChatMessage> messages =
        [
            new(ChatRole.System, "You respond in French."),
            new(ChatRole.User, "Say hello"),
        ];

        ChatResponse response = await chatClient.GetResponseAsync(
            messages,
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithMultipleSystemMessages()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Tell me about AI"
                    }]
                }],
                "max_tokens": 1024,
                "system": [{
                        "type": "text",
                        "text": "You are helpful."
                    },
                    {
                        "type": "text",
                        "text": "You are concise."
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_multi_sys_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Response combining all system instructions"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 30,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatMessage> messages =
        [
            new(ChatRole.System, "You are helpful."),
            new(ChatRole.System, "You are concise."),
            new(ChatRole.User, "Tell me about AI"),
        ];

        ChatResponse response = await chatClient.GetResponseAsync(
            messages,
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithMixedContentTypes()
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
                            "text": "Analyze this content:"
                        },
                        {
                            "type": "image",
                            "source": {
                                "type": "base64",
                                "media_type": "image/png",
                                "data": "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+M9QDwADhgGAWjR9awAAAABJRU5ErkJggg=="
                            }
                        },
                        {
                            "type": "text",
                            "text": "And also this image:"
                        },
                        {
                            "type": "image",
                            "source": {
                                "type": "url",
                                "url": "https://example.com/photo.jpg"
                            }
                        }
                    ]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_mixed_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I analyzed all the provided content."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 3000,
                    "output_tokens": 15
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var imageDataUri =
            "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+M9QDwADhgGAWjR9awAAAABJRU5ErkJggg==";

        List<ChatMessage> messages =
        [
            new(
                ChatRole.User,
                [
                    new TextContent("Analyze this content:"),
                    new DataContent(imageDataUri, "image/png"),
                    new TextContent("And also this image:"),
                    new UriContent(new Uri("https://example.com/photo.jpg"), "image/jpeg"),
                ]
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
    public async Task GetStreamingResponseAsync_WithToolCallInputDelta()
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
                        "text": "Call a tool"
                    }]
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_tool_stream_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"tool_use","id":"toolu_stream_1","name":"test_tool","input":{},"caller":{"type":"direct"}}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"{\"arg\":"}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"\"value\"}"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"tool_use","stop_sequence":null},"usage":{"output_tokens":10}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Call a tool",
                new(),
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }

        Assert.NotEmpty(updates);
        var functionUpdates = updates
            .Where(u => u.Contents.Any(c => c is FunctionCallContent))
            .ToList();
        Assert.NotEmpty(functionUpdates);

        var functionCall = functionUpdates
            .SelectMany(u => u.Contents.OfType<FunctionCallContent>())
            .FirstOrDefault();
        Assert.NotNull(functionCall);
        Assert.Equal("test_tool", functionCall.Name);

        // Verify arguments were properly accumulated from multiple delta events
        Assert.NotNull(functionCall.Arguments);
        Assert.True(functionCall.Arguments.ContainsKey("arg"));
        Assert.Equal("value", functionCall.Arguments["arg"]?.ToString());
    }

    [Fact]
    public async Task GetStreamingResponseAsync_WithServerToolUseInputDelta_PopulatesCodeInterpreterToolCallContent()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Run a bash command"
                    }]
                }],
                "max_tokens": 1024,
                "tools": [{
                    "type": "code_execution_20250825",
                    "name": "code_execution"
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_server_tool_stream_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"server_tool_use","id":"srvtoolu_stream_01","name":"bash_code_execution","input":{},"caller":{"type":"direct"}}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"{\"command\":\"echo"}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":" hello\"}"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":10}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Run a bash command",
                new() { Tools = [new HostedCodeInterpreterTool()] },
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }

        var ciCall = Assert.Single(
            updates.SelectMany(u => u.Contents.OfType<CodeInterpreterToolCallContent>())
        );
        Assert.Equal("srvtoolu_stream_01", ciCall.CallId);
        Assert.NotNull(ciCall.Inputs);
        var codeInput = Assert.IsType<DataContent>(Assert.Single(ciCall.Inputs));
        Assert.Equal("application/x-sh", codeInput.MediaType);
        Assert.Equal("echo hello", Encoding.UTF8.GetString(codeInput.Data.ToArray()));

        ChatResponse response = updates.ToChatResponse();
        var responseCiCall = Assert.IsType<CodeInterpreterToolCallContent>(
            response.Messages[0].Contents[0]
        );
        Assert.NotNull(responseCiCall.Inputs);
        var responseCodeInput = Assert.IsType<DataContent>(Assert.Single(responseCiCall.Inputs));
        Assert.Equal("application/x-sh", responseCodeInput.MediaType);
        Assert.Equal("echo hello", Encoding.UTF8.GetString(responseCodeInput.Data.ToArray()));
    }

    [Fact]
    public async Task GetStreamingResponseAsync_WithServerToolUseInputDelta_WebSearch_PopulatesWebSearchToolCallContent()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Search for AI news"
                    }]
                }],
                "max_tokens": 1024,
                "tools": [{
                    "name": "web_search",
                    "type": "web_search_20250305"
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_ws_stream_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"server_tool_use","id":"srvtoolu_ws_stream_01","name":"web_search","input":{},"caller":{"type":"direct"}}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"{\"query\":\"latest"}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":" AI news\"}"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":10}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Search for AI news",
                new() { Tools = [new HostedWebSearchTool()] },
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }

        var wsCall = Assert.Single(
            updates.SelectMany(u => u.Contents.OfType<WebSearchToolCallContent>())
        );
        Assert.Equal("srvtoolu_ws_stream_01", wsCall.CallId);
        Assert.NotNull(wsCall.Queries);
        Assert.Equal("latest AI news", Assert.Single(wsCall.Queries));

        ChatResponse response = updates.ToChatResponse();
        var responseWsCall = Assert.IsType<WebSearchToolCallContent>(
            response.Messages[0].Contents[0]
        );
        Assert.NotNull(responseWsCall.Queries);
        Assert.Equal("latest AI news", Assert.Single(responseWsCall.Queries));
    }

    [Fact]
    public async Task GetStreamingResponseAsync_WithServerToolUseInputDelta_CodeExecution_PopulatesCodeInterpreterToolCallContent()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Compute 2**10"
                    }]
                }],
                "max_tokens": 1024,
                "tools": [{
                    "type": "code_execution_20250825",
                    "name": "code_execution"
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_ce_stream_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"server_tool_use","id":"srvtoolu_ce_stream_01","name":"code_execution","input":{},"caller":{"type":"direct"}}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"{\"code\":\"print(2"}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"**10)\"}"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":10}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Compute 2**10",
                new() { Tools = [new HostedCodeInterpreterTool()] },
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }

        var ciCall = Assert.Single(
            updates.SelectMany(u => u.Contents.OfType<CodeInterpreterToolCallContent>())
        );
        Assert.Equal("srvtoolu_ce_stream_01", ciCall.CallId);
        Assert.NotNull(ciCall.Inputs);
        var codeInput = Assert.IsType<DataContent>(Assert.Single(ciCall.Inputs));
        Assert.Equal("text/x-python", codeInput.MediaType);
        Assert.Equal("print(2**10)", Encoding.UTF8.GetString(codeInput.Data.ToArray()));

        ChatResponse response = updates.ToChatResponse();
        var responseCiCall = Assert.IsType<CodeInterpreterToolCallContent>(
            response.Messages[0].Contents[0]
        );
        Assert.NotNull(responseCiCall.Inputs);
        var responseCodeInput = Assert.IsType<DataContent>(Assert.Single(responseCiCall.Inputs));
        Assert.Equal("text/x-python", responseCodeInput.MediaType);
        Assert.Equal("print(2**10)", Encoding.UTF8.GetString(responseCodeInput.Data.ToArray()));
    }

    [Fact]
    public async Task GetStreamingResponseAsync_WithServerToolUseInputDelta_TextEditorCodeExecution_PopulatesCodeInterpreterToolCallContent()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Create a file"
                    }]
                }],
                "max_tokens": 1024,
                "tools": [{
                    "type": "code_execution_20250825",
                    "name": "code_execution"
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_te_stream_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"server_tool_use","id":"srvtoolu_te_stream_01","name":"text_editor_code_execution","input":{},"caller":{"type":"direct"}}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"{\"command\":\"create"}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"\"}"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":10}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Create a file",
                new() { Tools = [new HostedCodeInterpreterTool()] },
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }

        var ciCall = Assert.Single(
            updates.SelectMany(u => u.Contents.OfType<CodeInterpreterToolCallContent>())
        );
        Assert.Equal("srvtoolu_te_stream_01", ciCall.CallId);
        Assert.NotNull(ciCall.Inputs);
        var codeInput = Assert.IsType<DataContent>(Assert.Single(ciCall.Inputs));
        Assert.Equal("text/plain", codeInput.MediaType);
        Assert.Equal("create", Encoding.UTF8.GetString(codeInput.Data.ToArray()));

        ChatResponse response = updates.ToChatResponse();
        var responseCiCall = Assert.IsType<CodeInterpreterToolCallContent>(
            response.Messages[0].Contents[0]
        );
        Assert.NotNull(responseCiCall.Inputs);
        var responseCodeInput = Assert.IsType<DataContent>(Assert.Single(responseCiCall.Inputs));
        Assert.Equal("text/plain", responseCodeInput.MediaType);
        Assert.Equal("create", Encoding.UTF8.GetString(responseCodeInput.Data.ToArray()));
    }

    [Fact]
    public async Task GetStreamingResponseAsync_WithServerToolUseInputDelta_UnknownName_MapsToToolCallContent()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Search tools"
                    }]
                }],
                "max_tokens": 1024,
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_unknown_stream_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"server_tool_use","id":"srvtoolu_unknown_stream_01","name":"tool_search_tool_regex","input":{},"caller":{"type":"direct"}}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":5}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Search tools",
                new(),
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }

        var tc = Assert.Single(updates.SelectMany(u => u.Contents.OfType<ToolCallContent>()));
        Assert.Equal("srvtoolu_unknown_stream_01", tc.CallId);

        ChatResponse response = updates.ToChatResponse();
        var responseTc = Assert.IsType<ToolCallContent>(response.Messages[0].Contents[0]);
        Assert.Equal("srvtoolu_unknown_stream_01", responseTc.CallId);
    }

    [Fact]
    public async Task GetStreamingResponseAsync_WithServerToolUseInputDelta_InitialInputPopulated_UsesAccumulatedArguments()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Run a command"
                    }]
                }],
                "max_tokens": 1024,
                "tools": [{
                    "type": "code_execution_20250825",
                    "name": "code_execution"
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_initial_input_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"server_tool_use","id":"srvtoolu_initial_01","name":"bash_code_execution","input":{"command":"initial"},"caller":{"type":"direct"}}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"{\"command\":\"ls"}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":" -la\"}"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":10}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Run a command",
                new() { Tools = [new HostedCodeInterpreterTool()] },
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }

        // Accumulated arguments should override the initial input
        var ciCall = Assert.Single(
            updates.SelectMany(u => u.Contents.OfType<CodeInterpreterToolCallContent>())
        );
        Assert.Equal("srvtoolu_initial_01", ciCall.CallId);
        Assert.NotNull(ciCall.Inputs);
        var codeInput = Assert.IsType<DataContent>(Assert.Single(ciCall.Inputs));
        Assert.Equal("application/x-sh", codeInput.MediaType);
        Assert.Equal("ls -la", Encoding.UTF8.GetString(codeInput.Data.ToArray()));
    }

    [Fact]
    public async Task GetStreamingResponseAsync_WithParameterlessToolCall()
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
                        "text": "Call parameterless tool"
                    }]
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_stream_paramless_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"tool_use","id":"toolu_stream_paramless_1","name":"get_time","input":{},"caller":{"type":"direct"}}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"tool_use","stop_sequence":null},"usage":{"output_tokens":5}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Call parameterless tool",
                new(),
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }

        Assert.NotEmpty(updates);
        var functionUpdates = updates
            .Where(u => u.Contents.Any(c => c is FunctionCallContent))
            .ToList();
        Assert.NotEmpty(functionUpdates);

        var functionCall = functionUpdates
            .SelectMany(u => u.Contents.OfType<FunctionCallContent>())
            .FirstOrDefault();
        Assert.NotNull(functionCall);
        Assert.Equal("get_time", functionCall.Name);
        Assert.Equal("toolu_stream_paramless_1", functionCall.CallId);
        Assert.True(functionCall.Arguments == null || functionCall.Arguments.Count == 0);
    }

    [Fact]
    public async Task GetStreamingResponseAsync_WithMultipleToolCalls_DoesNotDuplicateFunctionCalls()
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
                        "text": "Call multiple tools"
                    }]
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_multi_tool_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"tool_use","id":"toolu_1","name":"tool_a","input":{},"caller":{"type":"direct"}}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"{\"arg\":\"a\"}"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: content_block_start
            data: {"type":"content_block_start","index":1,"content_block":{"type":"tool_use","id":"toolu_2","name":"tool_b","input":{},"caller":{"type":"direct"}}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":1,"delta":{"type":"input_json_delta","partial_json":"{\"arg\":\"b\"}"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":1}

            event: content_block_start
            data: {"type":"content_block_start","index":2,"content_block":{"type":"tool_use","id":"toolu_3","name":"tool_c","input":{},"caller":{"type":"direct"}}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":2,"delta":{"type":"input_json_delta","partial_json":"{\"arg\":\"c\"}"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":2}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"tool_use","stop_sequence":null},"usage":{"output_tokens":15}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Call multiple tools",
                new(),
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }

        var allFunctionCalls = updates
            .SelectMany(u => u.Contents.OfType<FunctionCallContent>())
            .ToList();

        Assert.Equal(3, allFunctionCalls.Count);

        var fccA = allFunctionCalls.First(fc => fc.Name == "tool_a");
        Assert.Equal("toolu_1", fccA.CallId);
        Assert.Equal("a", fccA.Arguments?["arg"]?.ToString());

        var fccB = allFunctionCalls.First(fc => fc.Name == "tool_b");
        Assert.Equal("toolu_2", fccB.CallId);
        Assert.Equal("b", fccB.Arguments?["arg"]?.ToString());

        var fccC = allFunctionCalls.First(fc => fc.Name == "tool_c");
        Assert.Equal("toolu_3", fccC.CallId);
        Assert.Equal("c", fccC.Arguments?["arg"]?.ToString());
    }

    [Fact]
    public async Task GetStreamingResponseAsync_WithManyToolCallsAndFragmentedArguments()
    {
        // Build a streaming response with 5 tool calls, each with arguments spread across many small delta events
        var responseBuilder = new StringBuilder();
        responseBuilder.AppendLine(
            """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_many_tools_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            """
        );

        // Create 5 tool calls, each with complex arguments spread over multiple deltas
        for (int toolIndex = 0; toolIndex < 5; toolIndex++)
        {
            char toolLetter = (char)('a' + toolIndex);
            string toolId = $"toolu_{toolIndex + 1}";
            string toolName = $"tool_{toolLetter}";

            // Start the tool use block
            responseBuilder.AppendLine(
                $"event: content_block_start\n"
                    + $"data: {{\"type\":\"content_block_start\",\"index\":{toolIndex},\"content_block\":{{\"type\":\"tool_use\",\"id\":\"{toolId}\",\"name\":\"{toolName}\",\"input\":{{}},\"caller\":{{\"type\":\"direct\"}}}}}}\n"
            );

            // Build the JSON argument piece by piece
            string fullJson =
                $"{{\"name\":\"tool_{toolLetter}_value\",\"count\":{toolIndex + 1},\"description\":\"This is tool {toolLetter} with a longer description to test accumulation\"}}";

            // Split the JSON into small chunks (3 characters each) to simulate realistic streaming
            int chunkSize = 3;
            for (int i = 0; i < fullJson.Length; i += chunkSize)
            {
                string chunk = fullJson.Substring(i, Math.Min(chunkSize, fullJson.Length - i));
                // Escape the chunk for JSON embedding
                string escapedChunk = chunk.Replace("\\", "\\\\").Replace("\"", "\\\"");
                responseBuilder.AppendLine(
                    $"event: content_block_delta\n"
                        + $"data: {{\"type\":\"content_block_delta\",\"index\":{toolIndex},\"delta\":{{\"type\":\"input_json_delta\",\"partial_json\":\"{escapedChunk}\"}}}}\n"
                );
            }

            // Stop the content block
            responseBuilder.AppendLine(
                $"event: content_block_stop\n"
                    + $"data: {{\"type\":\"content_block_stop\",\"index\":{toolIndex}}}\n"
            );
        }

        // End the message
        responseBuilder.AppendLine(
            """
            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"tool_use","stop_sequence":null},"usage":{"output_tokens":50}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Call many tools"
                    }]
                }],
                "stream": true
            }
            """,
            actualResponse: responseBuilder.ToString()
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Call many tools",
                new(),
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }

        var allFunctionCalls = updates
            .SelectMany(u => u.Contents.OfType<FunctionCallContent>())
            .ToList();

        Assert.Equal(5, allFunctionCalls.Count);
        for (int i = 0; i < 5; i++)
        {
            string expectedCallId = $"toolu_{i + 1}";
            string expectedName = $"tool_{(char)('a' + i)}";
            string expectedNameValue = $"tool_{(char)('a' + i)}_value";
            int expectedCount = i + 1;

            var functionCall = allFunctionCalls.SingleOrDefault(fc => fc.CallId == expectedCallId);
            Assert.NotNull(functionCall);
            Assert.Equal(expectedName, functionCall.Name);

            Assert.NotNull(functionCall.Arguments);
            Assert.Equal(expectedNameValue, functionCall.Arguments["name"]?.ToString());
            Assert.Equal(expectedCount.ToString(), functionCall.Arguments["count"]?.ToString());
            Assert.Contains(
                $"This is tool {(char)('a' + i)}",
                functionCall.Arguments["description"]?.ToString()
            );
        }
    }

    [Fact]
    public async Task GetStreamingResponseAsync_WithInterleavedToolCallDeltas()
    {
        // This test simulates a scenario where multiple tool calls are being streamed
        // with their argument deltas interleaved (receiving parts of all tools before any completes)
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Call interleaved tools"
                    }]
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_interleaved_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"tool_use","id":"toolu_alpha","name":"tool_alpha","input":{},"caller":{"type":"direct"}}}

            event: content_block_start
            data: {"type":"content_block_start","index":1,"content_block":{"type":"tool_use","id":"toolu_beta","name":"tool_beta","input":{},"caller":{"type":"direct"}}}

            event: content_block_start
            data: {"type":"content_block_start","index":2,"content_block":{"type":"tool_use","id":"toolu_gamma","name":"tool_gamma","input":{},"caller":{"type":"direct"}}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"{\"city\":"}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":1,"delta":{"type":"input_json_delta","partial_json":"{\"query\":"}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":2,"delta":{"type":"input_json_delta","partial_json":"{\"id\":"}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"\"San Fran"}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":1,"delta":{"type":"input_json_delta","partial_json":"\"weather "}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":2,"delta":{"type":"input_json_delta","partial_json":"123,\"act"}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"input_json_delta","partial_json":"cisco\"}"}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":1,"delta":{"type":"input_json_delta","partial_json":"forecast\"}"}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":2,"delta":{"type":"input_json_delta","partial_json":"ive\":true}"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: content_block_stop
            data: {"type":"content_block_stop","index":1}

            event: content_block_stop
            data: {"type":"content_block_stop","index":2}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"tool_use","stop_sequence":null},"usage":{"output_tokens":25}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Call interleaved tools",
                new(),
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }

        var allFunctionCalls = updates
            .SelectMany(u => u.Contents.OfType<FunctionCallContent>())
            .ToList();

        Assert.Equal(3, allFunctionCalls.Count);

        var alphaCall = allFunctionCalls.SingleOrDefault(fc => fc.CallId == "toolu_alpha");
        Assert.NotNull(alphaCall);
        Assert.Equal("tool_alpha", alphaCall.Name);
        Assert.NotNull(alphaCall.Arguments);
        Assert.Equal("San Francisco", alphaCall.Arguments["city"]?.ToString());

        var betaCall = allFunctionCalls.SingleOrDefault(fc => fc.CallId == "toolu_beta");
        Assert.NotNull(betaCall);
        Assert.Equal("tool_beta", betaCall.Name);
        Assert.NotNull(betaCall.Arguments);
        Assert.Equal("weather forecast", betaCall.Arguments["query"]?.ToString());

        var gammaCall = allFunctionCalls.SingleOrDefault(fc => fc.CallId == "toolu_gamma");
        Assert.NotNull(gammaCall);
        Assert.Equal("tool_gamma", gammaCall.Name);
        Assert.NotNull(gammaCall.Arguments);
        Assert.Equal("123", gammaCall.Arguments["id"]?.ToString());
        Assert.Equal("True", gammaCall.Arguments["active"]?.ToString());
    }

    [Fact]
    public async Task GetResponseAsync_WithAdditionalUsageCounts()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Test with caching"
                    }]
                }],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_usage_ext_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Response with extended usage"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 100,
                    "output_tokens": 20,
                    "cache_creation_input_tokens": 50,
                    "cache_read_input_tokens": 25
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatResponse response = await chatClient.GetResponseAsync(
            "Test with caching",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        Assert.NotNull(response.Usage);
        Assert.Equal(175, response.Usage.InputTokenCount);
        Assert.Equal(20, response.Usage.OutputTokenCount);
        Assert.Equal(195, response.Usage.TotalTokenCount);
        Assert.NotNull(response.Usage.AdditionalCounts);
        Assert.Equal(50L, response.Usage.AdditionalCounts["CacheCreationInputTokens"]);
        Assert.Equal(25L, response.Usage.CachedInputTokenCount);
    }

    [Fact]
    public async Task GetResponseAsync_WithNullFinishReason()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Test null finish reason"
                    }]
                }],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_null_finish_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Response"
                }],
                "stop_reason": null,
                "usage": {
                    "input_tokens": 10,
                    "output_tokens": 5
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatResponse response = await chatClient.GetResponseAsync(
            "Test null finish reason",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        Assert.Null(response.FinishReason);
    }

    [Theory]
    [InlineData(ReasoningEffort.Low, 1024)]
    [InlineData(ReasoningEffort.Medium, 8192)]
    [InlineData(ReasoningEffort.High, 16384)]
    [InlineData(ReasoningEffort.ExtraHigh, 32768)]
    public async Task GetResponseAsync_WithReasoningEffort_SetsThinkingEnabled(
        ReasoningEffort effort,
        int expectedBudgetTokens
    )
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: $$"""
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Think carefully"
                    }]
                }],
                "max_tokens": 100000,
                "thinking": {
                    "type": "enabled",
                    "budget_tokens": {{expectedBudgetTokens}}
                }
            }
            """,
            actualResponse: """
            {
                "id": "msg_reasoning_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Here is my response"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 10,
                    "output_tokens": 20
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new()
        {
            MaxOutputTokens = 100000,
            Reasoning = new() { Effort = effort },
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Think carefully",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithReasoningEffortNone_SetsThinkingDisabled()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Simple question"
                    }]
                }],
                "max_tokens": 1024,
                "thinking": {
                    "type": "disabled"
                }
            }
            """,
            actualResponse: """
            {
                "id": "msg_reasoning_02",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Quick answer"
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

        ChatOptions options = new() { Reasoning = new() { Effort = ReasoningEffort.None } };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Simple question",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithReasoningEffort_ClampsBudgetToExplicitMaxTokens()
    {
        // High effort maps to 16384, but caller explicitly set max_tokens to 5000,
        // so budget should clamp to 4999.
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Think carefully"
                    }]
                }],
                "max_tokens": 5000,
                "thinking": {
                    "type": "enabled",
                    "budget_tokens": 4999
                }
            }
            """,
            actualResponse: """
            {
                "id": "msg_reasoning_03",
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
            MaxOutputTokens = 5000,
            Reasoning = new() { Effort = ReasoningEffort.High },
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Think carefully",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithReasoningEffort_SkipsThinkingWhenExplicitMaxTokensTooSmall()
    {
        // Medium effort maps to 8192, but caller explicitly set max_tokens to 1024,
        // so after clamping budget would be 1023 which is < 1024 minimum. Thinking is skipped.
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Think carefully"
                    }]
                }],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_reasoning_04",
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
            MaxOutputTokens = 1024,
            Reasoning = new() { Effort = ReasoningEffort.Medium },
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Think carefully",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithReasoningEffort_AutoIncreasesMaxTokensFromDefault()
    {
        // Medium effort maps to 8192. Default max_tokens is 1024, so max_tokens should
        // auto-increase to budget (8192) + default (1024) = 9216.
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Think carefully"
                    }]
                }],
                "max_tokens": 9216,
                "thinking": {
                    "type": "enabled",
                    "budget_tokens": 8192
                }
            }
            """,
            actualResponse: """
            {
                "id": "msg_reasoning_05",
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

        ChatOptions options = new() { Reasoning = new() { Effort = ReasoningEffort.Medium } };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Think carefully",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithReasoningEffortLow_AutoIncreasesFromDefaultMaxTokens()
    {
        // Low effort maps to 1024. Default max_tokens is also 1024, so 1024 <= 1024
        // triggers auto-increase to budget (1024) + default (1024) = 2048.
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Think a little"
                    }]
                }],
                "max_tokens": 2048,
                "thinking": {
                    "type": "enabled",
                    "budget_tokens": 1024
                }
            }
            """,
            actualResponse: """
            {
                "id": "msg_reasoning_06",
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

        ChatOptions options = new() { Reasoning = new() { Effort = ReasoningEffort.Low } };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Think a little",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithReasoningEffort_ExactFitMaxTokensOneBeyondBudget()
    {
        // Low effort maps to 1024. MaxOutputTokens is 1025, so 1025 > 1024 means
        // no auto-increase needed — budget fits exactly.
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Think a little"
                    }]
                }],
                "max_tokens": 1025,
                "thinking": {
                    "type": "enabled",
                    "budget_tokens": 1024
                }
            }
            """,
            actualResponse: """
            {
                "id": "msg_reasoning_07",
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
            MaxOutputTokens = 1025,
            Reasoning = new() { Effort = ReasoningEffort.Low },
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Think a little",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithReasoningEffort_NoAutoIncreaseWhenDefaultMaxTokensSufficient()
    {
        // Low effort maps to 1024. Custom default max_tokens is 5000, so 5000 > 1024 means
        // no auto-increase is needed.
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Think a little"
                    }]
                }],
                "max_tokens": 5000,
                "thinking": {
                    "type": "enabled",
                    "budget_tokens": 1024
                }
            }
            """,
            actualResponse: """
            {
                "id": "msg_reasoning_08",
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

        IChatClient chatClient = CreateChatClient(
            handler,
            "claude-haiku-4-5",
            defaultMaxOutputTokens: 5000
        );

        ChatOptions options = new() { Reasoning = new() { Effort = ReasoningEffort.Low } };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Think a little",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithReasoningOutputNone_SetsThinkingDisplayOmitted()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Think carefully"
                    }]
                }],
                "max_tokens": 100000,
                "thinking": {
                    "type": "enabled",
                    "budget_tokens": 16384,
                    "display": "omitted"
                }
            }
            """,
            actualResponse: """
            {
                "id": "msg_reasoning_display_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "thinking",
                    "thinking": "",
                    "signature": "sig_abc123"
                }, {
                    "type": "text",
                    "text": "Here is my response"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 10,
                    "output_tokens": 20
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new()
        {
            MaxOutputTokens = 100000,
            Reasoning = new() { Effort = ReasoningEffort.High, Output = ReasoningOutput.None },
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Think carefully",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Theory]
    [InlineData(ReasoningOutput.Summary)]
    [InlineData(ReasoningOutput.Full)]
    public async Task GetResponseAsync_WithReasoningOutputSummaryOrFull_DoesNotSetDisplay(
        ReasoningOutput output
    )
    {
        // Summary and Full should not set display, letting the server default to "summarized".
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Think carefully"
                    }]
                }],
                "max_tokens": 100000,
                "thinking": {
                    "type": "enabled",
                    "budget_tokens": 16384
                }
            }
            """,
            actualResponse: """
            {
                "id": "msg_reasoning_display_02",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Here is my response"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 10,
                    "output_tokens": 20
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new()
        {
            MaxOutputTokens = 100000,
            Reasoning = new() { Effort = ReasoningEffort.High, Output = output },
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Think carefully",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithReasoningOutputNone_OmittedThinkingYieldsRedactedReasoningContent()
    {
        // When display is omitted, the response contains thinking blocks with empty thinking
        // but a valid signature. These should map to TextReasoningContent with ProtectedData.
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Think carefully"
                    }]
                }],
                "max_tokens": 100000,
                "thinking": {
                    "type": "enabled",
                    "budget_tokens": 16384,
                    "display": "omitted"
                }
            }
            """,
            actualResponse: """
            {
                "id": "msg_reasoning_display_03",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "thinking",
                    "thinking": "",
                    "signature": "sig_omitted_abc123"
                }, {
                    "type": "text",
                    "text": "Here is my response"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 10,
                    "output_tokens": 20
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new()
        {
            MaxOutputTokens = 100000,
            Reasoning = new() { Effort = ReasoningEffort.High, Output = ReasoningOutput.None },
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Think carefully",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        // The response should contain a TextReasoningContent with the signature
        // and empty text (since display was omitted).
        TextReasoningContent thinkingContent = Assert.IsType<TextReasoningContent>(
            response.Messages.SelectMany(m => m.Contents).OfType<TextReasoningContent>().Single()
        );
        Assert.Equal(string.Empty, thinkingContent.Text);
        Assert.Equal("sig_omitted_abc123", thinkingContent.ProtectedData);
    }

    [Fact]
    public async Task GetResponseAsync_SendsTextReasoningAsThinkingBlock()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [
                    {
                        "role": "user",
                        "content": [{
                            "type": "text",
                            "text": "Think about this"
                        }]
                    },
                    {
                        "role": "assistant",
                        "content": [{
                            "type": "thinking",
                            "thinking": "My detailed reasoning...",
                            "signature": "sig_123"
                        }]
                    },
                    {
                        "role": "user",
                        "content": [{
                            "type": "text",
                            "text": "What did you conclude?"
                        }]
                    }
                ],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_reasoning_sent_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Response after thinking"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 30,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatMessage> messages =
        [
            new(ChatRole.User, "Think about this"),
            new(
                ChatRole.Assistant,
                [new TextReasoningContent("My detailed reasoning...") { ProtectedData = "sig_123" }]
            ),
            new(ChatRole.User, "What did you conclude?"),
        ];

        ChatResponse response = await chatClient.GetResponseAsync(
            messages,
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_SendsRedactedTextReasoningAsRedactedThinkingBlock()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [
                    {
                        "role": "user",
                        "content": [{
                            "type": "text",
                            "text": "Previous question"
                        }]
                    },
                    {
                        "role": "assistant",
                        "content": [{
                            "type": "redacted_thinking",
                            "data": "encrypted_data_xyz"
                        }]
                    },
                    {
                        "role": "user",
                        "content": [{
                            "type": "text",
                            "text": "Follow up question"
                        }]
                    }
                ],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_redacted_sent_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Response after redacted thinking"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 30,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatMessage> messages =
        [
            new(ChatRole.User, "Previous question"),
            new(
                ChatRole.Assistant,
                [new TextReasoningContent(string.Empty) { ProtectedData = "encrypted_data_xyz" }]
            ),
            new(ChatRole.User, "Follow up question"),
        ];

        ChatResponse response = await chatClient.GetResponseAsync(
            messages,
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_SkipsEmptyTextReasoningContent()
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
                            "text": "Question"
                        }]
                    },
                    {
                        "role": "user",
                        "content": [{
                            "type": "text",
                            "text": "Follow up"
                        }]
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_skip_empty_01",
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

        List<ChatMessage> messages =
        [
            new(ChatRole.User, "Question"),
            new(ChatRole.Assistant, [new TextReasoningContent(null)]),
            new(ChatRole.User, "Follow up"),
        ];

        ChatResponse response = await chatClient.GetResponseAsync(
            messages,
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetStreamingResponseAsync_WithThinkingBlockInStream()
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
                        "text": "Analyze this problem"
                    }]
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_thinking_stream_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"thinking","thinking":"","signature":"sig_123"}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"thinking_delta","thinking":"Let me analyze this..."}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: content_block_start
            data: {"type":"content_block_start","index":1,"content_block":{"type":"text","text":""}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":1,"delta":{"type":"text_delta","text":"Based on my analysis"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":1}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":10}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Analyze this problem",
                new(),
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }

        Assert.NotEmpty(updates);
        var reasoningUpdates = updates
            .Where(u => u.Contents.Any(c => c is TextReasoningContent))
            .ToList();
        Assert.NotEmpty(reasoningUpdates);

        var reasoningContent = reasoningUpdates
            .SelectMany(u => u.Contents.OfType<TextReasoningContent>())
            .FirstOrDefault();
        Assert.NotNull(reasoningContent);
    }

    [Fact]
    public async Task GetStreamingResponseAsync_WithRedactedThinkingBlockInStream()
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
                        "text": "Test redacted thinking"
                    }]
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_redacted_stream_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"redacted_thinking","data":"encrypted_xyz"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: content_block_start
            data: {"type":"content_block_start","index":1,"content_block":{"type":"text","text":""}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":1,"delta":{"type":"text_delta","text":"Response"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":1}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":5}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Test redacted thinking",
                new(),
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }

        Assert.NotEmpty(updates);
        var reasoningUpdates = updates
            .Where(u => u.Contents.Any(c => c is TextReasoningContent))
            .ToList();
        Assert.NotEmpty(reasoningUpdates);

        var reasoningContent = reasoningUpdates
            .SelectMany(u => u.Contents.OfType<TextReasoningContent>())
            .FirstOrDefault();
        Assert.NotNull(reasoningContent);
        Assert.Equal(string.Empty, reasoningContent.Text);
        Assert.Equal("encrypted_xyz", reasoningContent.ProtectedData);
    }

    [Fact]
    public async Task GetStreamingResponseAsync_WithSignatureDeltaInStream()
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
                        "text": "Test signature delta"
                    }]
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_sig_delta_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"thinking","thinking":"","signature":""}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"thinking_delta","thinking":"Analyzing..."}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"signature_delta","signature":"sig_part1"}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"signature_delta","signature":"sig_part2"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":5}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Test signature delta",
                new(),
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }

        Assert.NotEmpty(updates);
        var reasoningUpdates = updates
            .Where(u => u.Contents.Any(c => c is TextReasoningContent))
            .ToList();
        Assert.NotEmpty(reasoningUpdates);

        var allReasoningContent = reasoningUpdates
            .SelectMany(u => u.Contents.OfType<TextReasoningContent>())
            .ToList();
        Assert.NotEmpty(allReasoningContent);
    }

    [Fact]
    public async Task GetResponseAsync_WithThinkingBlockInResponse()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "What is the answer?"
                    }]
                }],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_thinking_resp_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "thinking",
                    "thinking": "Let me think through this step by step...",
                    "signature": "sig_abc123"
                }, {
                    "type": "text",
                    "text": "Based on my analysis, the answer is 42."
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

        ChatResponse response = await chatClient.GetResponseAsync(
            "What is the answer?",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        Assert.Equal(2, response.Messages[0].Contents.Count);

        var reasoningContent = response
            .Messages[0]
            .Contents.OfType<TextReasoningContent>()
            .FirstOrDefault();
        Assert.NotNull(reasoningContent);
        Assert.Equal("Let me think through this step by step...", reasoningContent.Text);
        Assert.Equal("sig_abc123", reasoningContent.ProtectedData);

        var textContent = response.Messages[0].Contents.OfType<TextContent>().FirstOrDefault();
        Assert.NotNull(textContent);
        Assert.Equal("Based on my analysis, the answer is 42.", textContent.Text);
    }

    [Fact]
    public async Task GetResponseAsync_WithRedactedThinkingBlockInResponse()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Tell me your conclusion"
                    }]
                }],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_redacted_resp_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "redacted_thinking",
                    "data": "encrypted_thinking_data_xyz"
                }, {
                    "type": "text",
                    "text": "Here is my conclusion."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 20,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatResponse response = await chatClient.GetResponseAsync(
            "Tell me your conclusion",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        Assert.Equal(2, response.Messages[0].Contents.Count);

        var reasoningContent = response
            .Messages[0]
            .Contents.OfType<TextReasoningContent>()
            .FirstOrDefault();
        Assert.NotNull(reasoningContent);
        Assert.Equal(string.Empty, reasoningContent.Text);
        Assert.Equal("encrypted_thinking_data_xyz", reasoningContent.ProtectedData);

        var textContent = response.Messages[0].Contents.OfType<TextContent>().FirstOrDefault();
        Assert.NotNull(textContent);
        Assert.Equal("Here is my conclusion.", textContent.Text);
    }

    [Fact]
    public async Task GetResponseAsync_WithToolUseBlockInResponse()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "What is 6 times 7?"
                    }]
                }],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_tooluse_resp_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "tool_use",
                    "id": "toolu_detailed_01",
                    "name": "calculate",
                    "input": {
                        "operation": "multiply",
                        "a": 6,
                        "b": 7
                    },
                    "caller": {"type": "direct"}
                }],
                "stop_reason": "tool_use",
                "usage": {
                    "input_tokens": 30,
                    "output_tokens": 15
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var calcFunction = AIFunctionFactory.Create(
            (string operation, int a, int b) =>
            {
                return operation == "multiply" ? a * b : 0;
            },
            "calculate"
        );

        ChatOptions options = new() { Tools = [calcFunction] };

        ChatResponse response = await chatClient.GetResponseAsync(
            "What is 6 times 7?",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        Assert.Equal(ChatFinishReason.ToolCalls, response.FinishReason);

        var functionCall = response
            .Messages[0]
            .Contents.OfType<FunctionCallContent>()
            .FirstOrDefault();
        Assert.NotNull(functionCall);
        Assert.Equal("calculate", functionCall.Name);
        Assert.Equal("toolu_detailed_01", functionCall.CallId);
        Assert.NotNull(functionCall.Arguments);
        Assert.True(functionCall.Arguments.ContainsKey("operation"));
        Assert.Equal("multiply", functionCall.Arguments["operation"]?.ToString());
        Assert.True(functionCall.Arguments.ContainsKey("a"));
        Assert.True(functionCall.Arguments.ContainsKey("b"));
    }

    [Fact]
    public async Task GetResponseAsync_WithHostedWebSearchToolOptionTriggersConversion()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Find recent news about AI"
                    }]
                }],
                "max_tokens": 1024,
                "tools": [
                    {
                        "name": "web_search",
                        "type": "web_search_20250305"
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_websearch_opt_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I'll search for that information."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 20,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatOptions options = new() { Tools = [new HostedWebSearchTool()] };

        ChatResponse response = await chatClient.GetResponseAsync(
            "Find recent news about AI",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithTextBlockWithoutCitations()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Tell me about AI"
                    }]
                }],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_no_citations_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "AI is transforming the world."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 20,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatResponse response = await chatClient.GetResponseAsync(
            "Tell me about AI",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        var textContent = response.Messages[0].Contents.OfType<TextContent>().FirstOrDefault();
        Assert.NotNull(textContent);
        Assert.Equal("AI is transforming the world.", textContent.Text);
        Assert.True(textContent.Annotations is null || !textContent.Annotations.Any());
    }

    [Fact]
    public async Task GetResponseAsync_WithWebSearchCitationsInTextBlock()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Tell me about recent AI developments with sources"
                    }]
                }],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_with_citations_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "According to recent research [1], artificial intelligence is rapidly advancing.",
                    "citations": [{
                        "type": "web_search_result_location",
                        "cited_text": "artificial intelligence is rapidly advancing",
                        "title": "AI Research 2024",
                        "url": "https://example.com/ai-research",
                        "encrypted_index": "enc_idx_123"
                    }]
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

        ChatResponse response = await chatClient.GetResponseAsync(
            "Tell me about recent AI developments with sources",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        var textContent = response.Messages[0].Contents.OfType<TextContent>().FirstOrDefault();
        Assert.NotNull(textContent);
        Assert.Contains("artificial intelligence", textContent.Text);
        Assert.NotNull(textContent.Annotations);
        Assert.NotEmpty(textContent.Annotations);

        var citation = textContent.Annotations.OfType<CitationAnnotation>().FirstOrDefault();
        Assert.NotNull(citation);
        Assert.Equal("AI Research 2024", citation.Title);
        Assert.Equal("artificial intelligence is rapidly advancing", citation.Snippet);
        Assert.NotNull(citation.Url);
        Assert.Equal("https://example.com/ai-research", citation.Url.ToString());
        Assert.Null(citation.AnnotatedRegions);
    }

    [Fact]
    public async Task GetResponseAsync_WithContentBlockLocationCitationsInTextBlock()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "What does the document say about ML?"
                    }]
                }],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_doc_citations_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "As stated in the document [1], machine learning requires large datasets.",
                    "citations": [{
                        "type": "content_block_location",
                        "cited_text": "machine learning requires large datasets",
                        "document_title": "ML Fundamentals",
                        "file_id": "file_abc123",
                        "document_index": 0,
                        "start_block_index": 15,
                        "end_block_index": 45
                    }]
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

        ChatResponse response = await chatClient.GetResponseAsync(
            "What does the document say about ML?",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        var textContent = response.Messages[0].Contents.OfType<TextContent>().FirstOrDefault();
        Assert.NotNull(textContent);
        Assert.NotNull(textContent.Annotations);
        Assert.NotEmpty(textContent.Annotations);

        var citation = textContent.Annotations.OfType<CitationAnnotation>().FirstOrDefault();
        Assert.NotNull(citation);

        Assert.Equal("machine learning requires large datasets", citation.Snippet);
        Assert.Equal("file_abc123", citation.FileId);
        Assert.Null(citation.Url);
        Assert.Null(citation.AnnotatedRegions);
    }

    [Fact]
    public async Task GetResponseAsync_ServerToolUseBlock_WebSearch_MapsToWebSearchToolCallContent()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Search for AI news"
                    }]
                }],
                "max_tokens": 1024,
                "tools": [{
                    "name": "web_search",
                    "type": "web_search_20250305"
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_ws_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [
                    {
                        "type": "server_tool_use",
                        "id": "srvtoolu_ws_01",
                        "name": "web_search",
                        "caller": { "type": "direct" },
                        "input": { "query": "latest AI news 2026" }
                    },
                    {
                        "type": "web_search_tool_result",
                        "tool_use_id": "srvtoolu_ws_01",
                        "caller": { "type": "direct" },
                        "content": [
                            {
                                "type": "web_search_result",
                                "title": "AI Breakthroughs in 2026",
                                "url": "https://example.com/ai-news",
                                "encrypted_content": "enc_abc123",
                                "page_age": "2 days ago"
                            },
                            {
                                "type": "web_search_result",
                                "title": "Latest AI Research",
                                "url": "https://example.com/ai-research",
                                "encrypted_content": "enc_def456",
                                "page_age": "1 week ago"
                            }
                        ]
                    },
                    {
                        "type": "text",
                        "text": "Here are some recent AI news articles."
                    }
                ],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 30,
                    "output_tokens": 25
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatResponse response = await chatClient.GetResponseAsync(
            "Search for AI news",
            new() { Tools = [new HostedWebSearchTool()] },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        var contents = response.Messages[0].Contents;

        // Verify WebSearchToolCallContent
        var wsCall = Assert.IsType<WebSearchToolCallContent>(contents[0]);
        Assert.Equal("srvtoolu_ws_01", wsCall.CallId);
        Assert.NotNull(wsCall.Queries);
        Assert.Single(wsCall.Queries);
        Assert.Equal("latest AI news 2026", wsCall.Queries[0]);

        // Verify WebSearchToolResultContent
        var wsResult = Assert.IsType<WebSearchToolResultContent>(contents[1]);
        Assert.Equal("srvtoolu_ws_01", wsResult.CallId);
        Assert.NotNull(wsResult.Results);
        Assert.Equal(2, wsResult.Results.Count);

        var firstResult = Assert.IsType<UriContent>(wsResult.Results[0]);
        Assert.Equal(new Uri("https://example.com/ai-news"), firstResult.Uri);

        var secondResult = Assert.IsType<UriContent>(wsResult.Results[1]);
        Assert.Equal(new Uri("https://example.com/ai-research"), secondResult.Uri);

        // Verify text content
        var text = Assert.IsType<TextContent>(contents[2]);
        Assert.Equal("Here are some recent AI news articles.", text.Text);
    }

    [Fact]
    public async Task GetResponseAsync_ServerToolUseBlock_CodeExecution_MapsToCodeInterpreterToolCallContent()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Compute 2**10"
                    }]
                }],
                "max_tokens": 1024,
                "tools": [{
                    "type": "code_execution_20250825",
                    "name": "code_execution"
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_ce_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [
                    {
                        "type": "server_tool_use",
                        "id": "srvtoolu_ce_01",
                        "name": "code_execution",
                        "caller": { "type": "direct" },
                        "input": { "code": "print(2**10)" }
                    },
                    {
                        "type": "code_execution_tool_result",
                        "tool_use_id": "srvtoolu_ce_01",
                        "content": {
                            "type": "code_execution_result",
                            "content": [],
                            "stdout": "1024\n",
                            "stderr": "",
                            "return_code": 0
                        }
                    },
                    {
                        "type": "text",
                        "text": "The result is 1024."
                    }
                ],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 25,
                    "output_tokens": 20
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatResponse response = await chatClient.GetResponseAsync(
            "Compute 2**10",
            new() { Tools = [new HostedCodeInterpreterTool()] },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        var contents = response.Messages[0].Contents;

        // Verify CodeInterpreterToolCallContent
        var ciCall = Assert.IsType<CodeInterpreterToolCallContent>(contents[0]);
        Assert.Equal("srvtoolu_ce_01", ciCall.CallId);
        Assert.NotNull(ciCall.Inputs);
        Assert.Single(ciCall.Inputs);
        var codeInput = Assert.IsType<DataContent>(ciCall.Inputs[0]);
        Assert.Equal("text/x-python", codeInput.MediaType);
        Assert.Equal("print(2**10)", Encoding.UTF8.GetString(codeInput.Data.ToArray()));

        // Verify CodeInterpreterToolResultContent
        var ciResult = Assert.IsType<CodeInterpreterToolResultContent>(contents[1]);
        Assert.Equal("srvtoolu_ce_01", ciResult.CallId);
        Assert.NotNull(ciResult.Outputs);
        var stdoutOutput = Assert.IsType<TextContent>(ciResult.Outputs[0]);
        Assert.Equal("1024\n", stdoutOutput.Text);

        // Verify text content
        var text = Assert.IsType<TextContent>(contents[2]);
        Assert.Equal("The result is 1024.", text.Text);
    }

    [Fact]
    public async Task GetResponseAsync_WebSearchToolResult_WithError_MapsToErrorContent()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Search for something"
                    }]
                }],
                "max_tokens": 1024,
                "tools": [{
                    "name": "web_search",
                    "type": "web_search_20250305"
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_ws_err_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [
                    {
                        "type": "server_tool_use",
                        "id": "srvtoolu_ws_err_01",
                        "name": "web_search",
                        "caller": { "type": "direct" },
                        "input": { "query": "test query" }
                    },
                    {
                        "type": "web_search_tool_result",
                        "tool_use_id": "srvtoolu_ws_err_01",
                        "caller": { "type": "direct" },
                        "content": {
                            "type": "web_search_tool_result_error",
                            "error_code": "max_uses_exceeded"
                        }
                    },
                    {
                        "type": "text",
                        "text": "Search encountered an error."
                    }
                ],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 20,
                    "output_tokens": 15
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatResponse response = await chatClient.GetResponseAsync(
            "Search for something",
            new() { Tools = [new HostedWebSearchTool()] },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        var contents = response.Messages[0].Contents;

        var wsResult = Assert.IsType<WebSearchToolResultContent>(contents[1]);
        Assert.Equal("srvtoolu_ws_err_01", wsResult.CallId);
        Assert.NotNull(wsResult.Results);
        Assert.Single(wsResult.Results);
        var errorResult = Assert.IsType<ErrorContent>(wsResult.Results[0]);
        Assert.Equal("MaxUsesExceeded", errorResult.ErrorCode);
    }

    [Fact]
    public async Task GetResponseAsync_FinishReasonNullHandling()
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
                "id": "msg_no_finish_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Response"
                }],
                "stop_reason": null,
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

        Assert.Null(response.FinishReason);
    }

    [Fact]
    public async Task GetStreamingResponseAsync_AccumulatesUsageFromMultipleMessageStartEvents()
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
                        "text": "Test multiple message starts"
                    }]
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_multi_start_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: message_start
            data: {"type":"message_start","message":{"id":"msg_multi_start_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":5,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"Response"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"input_tokens":15,"output_tokens":2}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Test multiple message starts",
                new(),
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }

        Assert.NotEmpty(updates);
        var usageUpdates = updates.Where(u => u.Contents.Any(c => c is UsageContent)).ToList();
        Assert.NotEmpty(usageUpdates);

        var usageContent = usageUpdates
            .SelectMany(u => u.Contents.OfType<UsageContent>())
            .FirstOrDefault();
        Assert.NotNull(usageContent);

        Assert.Equal(15, usageContent.Details.InputTokenCount);
        Assert.Equal(2, usageContent.Details.OutputTokenCount);
    }

    [Fact]
    public async Task GetStreamingResponseAsync_UsageFromDeltaOverridesStartEvent()
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
                        "text": "hello"
                    }]
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":8,"cache_creation_input_tokens":0,"cache_read_input_tokens":0,"output_tokens":8}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"Hello!"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"input_tokens":8,"cache_creation_input_tokens":0,"cache_read_input_tokens":0,"output_tokens":12}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "hello",
                new(),
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }

        Assert.NotEmpty(updates);
        var usageUpdates = updates.Where(u => u.Contents.Any(c => c is UsageContent)).ToList();
        Assert.NotEmpty(usageUpdates);

        var usageContent = usageUpdates
            .SelectMany(u => u.Contents.OfType<UsageContent>())
            .FirstOrDefault();
        Assert.NotNull(usageContent);

        Assert.Equal(8, usageContent.Details.InputTokenCount);
        Assert.Equal(12, usageContent.Details.OutputTokenCount);
        Assert.Equal(20, usageContent.Details.TotalTokenCount);
    }

    [Fact]
    public async Task GetResponseAsync_FunctionResult_WithSingleTextContent()
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
                            "text": "What's the weather in Seattle?"
                        }]
                    },
                    {
                        "role": "assistant",
                        "content": [{
                            "type": "tool_use",
                            "id": "toolu_012ji4C9Dx9qiGwDPfWSjRVC",
                            "name": "get_weather",
                            "input": {
                                "location": "Seattle"
                            }
                        }]
                    },
                    {
                        "role": "user",
                        "content": [{
                            "type": "tool_result",
                            "tool_use_id": "toolu_012ji4C9Dx9qiGwDPfWSjRVC",
                            "is_error": false,
                            "content": [{
                                "type": "text",
                                "text": "The weather in Seattle is sunny and 72�F"
                            }]
                        }]
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_01DzfU3ta5z9nrJo6EGamXqV",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5-20251001",
                "content": [{
                    "type": "text",
                    "text": "The weather in Seattle is currently **sunny** with a temperature of **72�F** (about 22�C). Great weather for outdoor activities!"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 91,
                    "output_tokens": 34
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatMessage> messages =
        [
            new(ChatRole.User, "What's the weather in Seattle?"),
            new(
                ChatRole.Assistant,
                [
                    new FunctionCallContent(
                        "toolu_012ji4C9Dx9qiGwDPfWSjRVC",
                        "get_weather",
                        new Dictionary<string, object?> { ["location"] = "Seattle" }
                    ),
                ]
            ),
            new(
                ChatRole.User,
                [
                    new FunctionResultContent(
                        "toolu_012ji4C9Dx9qiGwDPfWSjRVC",
                        new TextContent("The weather in Seattle is sunny and 72�F")
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
        TextContent textContent = Assert.IsType<TextContent>(response.Messages[0].Contents[0]);
        Assert.Contains("sunny", textContent.Text, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("72", textContent.Text);
    }

    [Fact]
    public async Task GetResponseAsync_FunctionResult_WithMultipleTextContents()
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
                            "text": "Get me news about AI"
                        }]
                    },
                    {
                        "role": "assistant",
                        "content": [{
                            "type": "tool_use",
                            "id": "toolu_01TQkFntpAPUXLijpPu5Q1dT",
                            "name": "get_news",
                            "input": {
                                "topic": "AI"
                            }
                        }]
                    },
                    {
                        "role": "user",
                        "content": [{
                            "type": "tool_result",
                            "tool_use_id": "toolu_01TQkFntpAPUXLijpPu5Q1dT",
                            "is_error": false,
                            "content": [
                                {
                                    "type": "text",
                                    "text": "Breaking: AI advances"
                                },
                                {
                                    "type": "text",
                                    "text": "Research shows improvements"
                                },
                                {
                                    "type": "text",
                                    "text": "Industry adoption grows"
                                }
                            ]
                        }]
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_01G8oMUpScZWsMe5JsNuLkgJ",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5-20251001",
                "content": [{
                    "type": "text",
                    "text": "Here's the latest AI news:\\n\\n**Breaking: AI Advances**\\n- Researchers are demonstrating significant improvements in AI capabilities across various domains\\n\\n**Research Shows Improvements**\\n- Ongoing studies continue to push the boundaries of what AI systems can accomplish\\n\\n**Industry Adoption Grows**\\n- Companies across sectors are increasingly implementing AI solutions into their operations"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 95,
                    "output_tokens": 100
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatMessage> messages =
        [
            new(ChatRole.User, "Get me news about AI"),
            new(
                ChatRole.Assistant,
                [
                    new FunctionCallContent(
                        "toolu_01TQkFntpAPUXLijpPu5Q1dT",
                        "get_news",
                        new Dictionary<string, object?> { ["topic"] = "AI" }
                    ),
                ]
            ),
            new(
                ChatRole.User,
                [
                    new FunctionResultContent(
                        "toolu_01TQkFntpAPUXLijpPu5Q1dT",
                        new AIContent[]
                        {
                            new TextContent("Breaking: AI advances"),
                            new TextContent("Research shows improvements"),
                            new TextContent("Industry adoption grows"),
                        }
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
        TextContent textContent = Assert.IsType<TextContent>(response.Messages[0].Contents[0]);
        Assert.Contains("AI", textContent.Text);
        Assert.Contains("advances", textContent.Text, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task GetResponseAsync_FunctionResult_WithImageDataContent()
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
                            "text": "Generate a bar chart"
                        }]
                    },
                    {
                        "role": "assistant",
                        "content": [{
                            "type": "tool_use",
                            "id": "toolu_01RFvjHBAxq1z9kgH7vtVioW",
                            "name": "generate_chart",
                            "input": {
                                "type": "bar"
                            }
                        }]
                    },
                    {
                        "role": "user",
                        "content": [{
                            "type": "tool_result",
                            "tool_use_id": "toolu_01RFvjHBAxq1z9kgH7vtVioW",
                            "is_error": false,
                            "content": [{
                                "type": "image",
                                "source": {
                                    "type": "base64",
                                    "media_type": "image/png",
                                    "data": "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+M9QDwADhgGAWjR9awAAAABJRU5ErkJggg=="
                                }
                            }]
                        }]
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_01JVBwA4cipSnmopX4ywyZ36",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5-20251001",
                "content": [{
                    "type": "text",
                    "text": "I've generated a simple bar chart for you! \\n\\nSince you didn't specify particular data, here's a basic example. If you'd like me to create a bar chart with specific data, categories, or a particular theme, please let me know."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 92,
                    "output_tokens": 50
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        byte[] pngData = Convert.FromBase64String(
            "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+M9QDwADhgGAWjR9awAAAABJRU5ErkJggg=="
        );

        List<ChatMessage> messages =
        [
            new(ChatRole.User, "Generate a bar chart"),
            new(
                ChatRole.Assistant,
                [
                    new FunctionCallContent(
                        "toolu_01RFvjHBAxq1z9kgH7vtVioW",
                        "generate_chart",
                        new Dictionary<string, object?> { ["type"] = "bar" }
                    ),
                ]
            ),
            new(
                ChatRole.User,
                [
                    new FunctionResultContent(
                        "toolu_01RFvjHBAxq1z9kgH7vtVioW",
                        new DataContent(pngData, "image/png")
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
        TextContent textContent = Assert.IsType<TextContent>(response.Messages[0].Contents[0]);
        Assert.Contains("chart", textContent.Text, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task GetResponseAsync_FunctionResult_WithPdfDataContent()
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
                            "text": "Generate a sales report"
                        }]
                    },
                    {
                        "role": "assistant",
                        "content": [{
                            "type": "tool_use",
                            "id": "toolu_01Xp2XKeM6KcpCrGKbh96biN",
                            "name": "generate_report",
                            "input": {
                                "type": "sales"
                            }
                        }]
                    },
                    {
                        "role": "user",
                        "content": [{
                            "type": "tool_result",
                            "tool_use_id": "toolu_01Xp2XKeM6KcpCrGKbh96biN",
                            "is_error": false,
                            "content": [{
                                "type": "document",
                                "source": {
                                    "type": "base64",
                                    "media_type": "application/pdf",
                                    "data": "JVBERi0xLjQKMSAwIG9iajw8L1R5cGUvQ2F0YWxvZy9QYWdlcyAyIDAgUj4+ZW5kb2JqIDIgMCBvYmo8PC9UeXBlL1BhZ2VzL0tpZHNbMyAwIFJdL0NvdW50IDE+PmVuZG9iaiAzIDAgb2JqPDwvVHlwZS9QYWdlL01lZGlhQm94WzAgMCA2MTIgNzkyXS9QYXJlbnQgMiAwIFIvUmVzb3VyY2VzPDw+Pj4+ZW5kb2JqCnhyZWYKMCA0CjAwMDAwMDAwMDAgNjU1MzUgZgowMDAwMDAwMDA5IDAwMDAwIG4KMDAwMDAwMDA1MiAwMDAwMCBuCjAwMDAwMDAxMDEgMDAwMDAgbgp0cmFpbGVyPDwvU2l6ZSA0L1Jvb3QgMSAwIFI+PgpzdGFydHhyZWYKMTc4CiUlRU9G"
                                }
                            }]
                        }]
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_01WhQmBXmH4zHd1fB2VYGRWW",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5-20251001",
                "content": [{
                    "type": "text",
                    "text": "I attempted to generate a sales report, but the generated document appears to be blank. Let me provide you with a sample **Sales Report** instead with key metrics and insights."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 1653,
                    "output_tokens": 50
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        string pdfContent =
            "%PDF-1.4\n1 0 obj<</Type/Catalog/Pages 2 0 R>>endobj 2 0 obj<</Type/Pages/Kids[3 0 R]/Count 1>>endobj 3 0 obj<</Type/Page/MediaBox[0 0 612 792]/Parent 2 0 R/Resources<<>>>>endobj\nxref\n0 4\n0000000000 65535 f\n0000000009 00000 n\n0000000052 00000 n\n0000000101 00000 n\ntrailer<</Size 4/Root 1 0 R>>\nstartxref\n178\n%%EOF";
        byte[] pdfData = Encoding.UTF8.GetBytes(pdfContent);

        List<ChatMessage> messages =
        [
            new(ChatRole.User, "Generate a sales report"),
            new(
                ChatRole.Assistant,
                [
                    new FunctionCallContent(
                        "toolu_01Xp2XKeM6KcpCrGKbh96biN",
                        "generate_report",
                        new Dictionary<string, object?> { ["type"] = "sales" }
                    ),
                ]
            ),
            new(
                ChatRole.User,
                [
                    new FunctionResultContent(
                        "toolu_01Xp2XKeM6KcpCrGKbh96biN",
                        new DataContent(pdfData, "application/pdf")
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
        TextContent textContent = Assert.IsType<TextContent>(response.Messages[0].Contents[0]);
        Assert.Contains("report", textContent.Text, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task GetResponseAsync_FunctionResult_WithTextPlainDataContent()
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
                            "text": "Get the system logs"
                        }]
                    },
                    {
                        "role": "assistant",
                        "content": [
                            {
                                "type": "text",
                                "text": "I'll retrieve the system logs for you."
                            },
                            {
                                "type": "tool_use",
                                "id": "toolu_01JqNHMtbwFQExUwDMWy3wHe",
                                "name": "get_logs",
                                "input": {
                                    "type": "system"
                                }
                            }
                        ]
                    },
                    {
                        "role": "user",
                        "content": [{
                            "type": "tool_result",
                            "tool_use_id": "toolu_01JqNHMtbwFQExUwDMWy3wHe",
                            "is_error": false,
                            "content": [{
                                "type": "document",
                                "source": {
                                    "type": "text",
                                    "media_type": "text/plain",
                                    "data": "Log Entry 1: System started\nLog Entry 2: Processing data\nLog Entry 3: Task completed"
                                }
                            }]
                        }]
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_01RxuuTbpsvFyNpim6uoXujV",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5-20251001",
                "content": [{
                    "type": "text",
                    "text": "Here are the system logs:\\n\\n**System Logs:**\\n1. System started\\n2. Processing data\\n3. Task completed\\n\\nThese are the current entries in the system log."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 148,
                    "output_tokens": 50
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        string logContent =
            "Log Entry 1: System started\nLog Entry 2: Processing data\nLog Entry 3: Task completed";
        byte[] logData = Encoding.UTF8.GetBytes(logContent);

        List<ChatMessage> messages =
        [
            new(ChatRole.User, "Get the system logs"),
            new(
                ChatRole.Assistant,
                [
                    new TextContent("I'll retrieve the system logs for you."),
                    new FunctionCallContent(
                        "toolu_01JqNHMtbwFQExUwDMWy3wHe",
                        "get_logs",
                        new Dictionary<string, object?> { ["type"] = "system" }
                    ),
                ]
            ),
            new(
                ChatRole.User,
                [
                    new FunctionResultContent(
                        "toolu_01JqNHMtbwFQExUwDMWy3wHe",
                        new DataContent(logData, "text/plain")
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
        TextContent textContent = Assert.IsType<TextContent>(response.Messages[0].Contents[0]);
        Assert.Contains("System started", textContent.Text);
        Assert.Contains("Task completed", textContent.Text);
    }

    [Fact]
    public async Task GetResponseAsync_FunctionResult_WithMixedContent()
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
                            "text": "Analyze the sales data"
                        }]
                    },
                    {
                        "role": "assistant",
                        "content": [{
                            "type": "tool_use",
                            "id": "toolu_01ABC123",
                            "name": "analyze_data",
                            "input": {
                                "dataset": "sales"
                            }
                        }]
                    },
                    {
                        "role": "user",
                        "content": [{
                            "type": "tool_result",
                            "tool_use_id": "toolu_01ABC123",
                            "is_error": false,
                            "content": [
                                {
                                    "type": "text",
                                    "text": "Analysis: Mean=42.5, Median=40"
                                },
                                {
                                    "type": "image",
                                    "source": {
                                        "type": "base64",
                                        "media_type": "image/png",
                                        "data": "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+M9QDwADhgGAWjR9awAAAABJRU5ErkJggg=="
                                    }
                                }
                            ]
                        }]
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_01MixedContent",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5-20251001",
                "content": [{
                    "type": "text",
                    "text": "Based on the analysis, your sales data shows a mean of 42.5 and median of 40. The chart visualization helps illustrate the distribution."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 120,
                    "output_tokens": 35
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        byte[] chartData = Convert.FromBase64String(
            "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+M9QDwADhgGAWjR9awAAAABJRU5ErkJggg=="
        );

        List<ChatMessage> messages =
        [
            new(ChatRole.User, "Analyze the sales data"),
            new(
                ChatRole.Assistant,
                [
                    new FunctionCallContent(
                        "toolu_01ABC123",
                        "analyze_data",
                        new Dictionary<string, object?> { ["dataset"] = "sales" }
                    ),
                ]
            ),
            new(
                ChatRole.User,
                [
                    new FunctionResultContent(
                        "toolu_01ABC123",
                        new AIContent[]
                        {
                            new TextContent("Analysis: Mean=42.5, Median=40"),
                            new DataContent(chartData, "image/png"),
                        }
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
        TextContent textContent = Assert.IsType<TextContent>(response.Messages[0].Contents[0]);
        Assert.Contains("42.5", textContent.Text);
        Assert.Contains("40", textContent.Text);
    }

    [Fact]
    public async Task GetResponseAsync_WithFunctionResultContent_UriContent_Image()
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
                            "text": "Get image URL"
                        }]
                    },
                    {
                        "role": "assistant",
                        "content": [{
                            "type": "tool_use",
                            "id": "tool_uri_img",
                            "name": "url_tool",
                            "input": {}
                        }]
                    },
                    {
                        "role": "user",
                        "content": [{
                            "type": "tool_result",
                            "tool_use_id": "tool_uri_img",
                            "is_error": false,
                            "content": [{
                                "type": "image",
                                "source": {
                                    "type": "url",
                                    "url": "https://example.com/image.png"
                                }
                            }]
                        }]
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_uri_img_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Image URL received"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 32,
                    "output_tokens": 8
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatMessage> messages =
        [
            new ChatMessage(ChatRole.User, "Get image URL"),
            new ChatMessage(
                ChatRole.Assistant,
                [
                    new FunctionCallContent(
                        "tool_uri_img",
                        "url_tool",
                        new Dictionary<string, object?>()
                    ),
                ]
            ),
            new ChatMessage(
                ChatRole.User,
                [
                    new FunctionResultContent(
                        "tool_uri_img",
                        new UriContent(new Uri("https://example.com/image.png"), "image/png")
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
    }

    [Fact]
    public async Task GetResponseAsync_WithFunctionResultContent_UriContent_PDF()
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
                            "text": "Get PDF URL"
                        }]
                    },
                    {
                        "role": "assistant",
                        "content": [{
                            "type": "tool_use",
                            "id": "tool_uri_pdf",
                            "name": "pdf_url_tool",
                            "input": {}
                        }]
                    },
                    {
                        "role": "user",
                        "content": [{
                            "type": "tool_result",
                            "tool_use_id": "tool_uri_pdf",
                            "is_error": false,
                            "content": [{
                                "type": "document",
                                "source": {
                                    "type": "url",
                                    "url": "https://example.com/document.pdf"
                                }
                            }]
                        }]
                    }
                ]
            }
            """,
            actualResponse: """
            {
                "id": "msg_uri_pdf_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "PDF URL received"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 35,
                    "output_tokens": 9
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatMessage> messages =
        [
            new ChatMessage(ChatRole.User, "Get PDF URL"),
            new ChatMessage(
                ChatRole.Assistant,
                [
                    new FunctionCallContent(
                        "tool_uri_pdf",
                        "pdf_url_tool",
                        new Dictionary<string, object?>()
                    ),
                ]
            ),
            new ChatMessage(
                ChatRole.User,
                [
                    new FunctionResultContent(
                        "tool_uri_pdf",
                        new UriContent(
                            new Uri("https://example.com/document.pdf"),
                            "application/pdf"
                        )
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
                "output_config": {
                    "format": {
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
                "output_config": {
                    "format": {
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
                "output_config": {
                    "format": {
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

    [Theory]
    [InlineData("code_execution")]
    [InlineData("bash_code_execution")]
    public async Task GetResponseAsync_CodeExecutionResult_WithStdout(string executionType)
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
            actualResponse: $$"""
            {
                "id": "msg_stdout_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "{{executionType}}_tool_result",
                    "tool_use_id": "exec_1",
                    "content": {
                        "type": "{{executionType}}_result",
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
        Assert.Equal("exec_1", codeResult.CallId);
        Assert.NotNull(codeResult.Outputs);
        Assert.Single(codeResult.Outputs);

        TextContent textOutput = Assert.IsType<TextContent>(codeResult.Outputs[0]);
        Assert.Equal("Hello World\n42\n", textOutput.Text);
    }

    [Theory]
    [InlineData("code_execution", "Division by zero error", 1)]
    [InlineData("bash_code_execution", "bash: command not found: nonexistent", 127)]
    public async Task GetResponseAsync_CodeExecutionResult_WithStderrAndNonZeroReturnCode(
        string executionType,
        string stderrMessage,
        int returnCode
    )
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
            actualResponse: $$"""
            {
                "id": "msg_stderr_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "{{executionType}}_tool_result",
                    "tool_use_id": "exec_2",
                    "content": {
                        "type": "{{executionType}}_result",
                        "stdout": "",
                        "stderr": "{{stderrMessage}}",
                        "return_code": {{returnCode}},
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
        Assert.Equal(stderrMessage, errorOutput.Message);
        Assert.Equal(
            returnCode.ToString(System.Globalization.CultureInfo.InvariantCulture),
            errorOutput.ErrorCode
        );
    }

    [Theory]
    [InlineData("code_execution")]
    [InlineData("bash_code_execution")]
    public async Task GetResponseAsync_CodeExecutionResult_WithFileOutputs(string executionType)
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
            actualResponse: $$"""
            {
                "id": "msg_files_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "{{executionType}}_tool_result",
                    "tool_use_id": "exec_3",
                    "content": {
                        "type": "{{executionType}}_result",
                        "stdout": "File created",
                        "stderr": "",
                        "return_code": 0,
                        "content": [{
                            "type": "{{executionType}}_output",
                            "file_id": "file_output_123"
                        }, {
                            "type": "{{executionType}}_output",
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
                        "required": ["query"],
                        "additionalProperties": false
                    },
                    "defer_loading": true,
                    "strict": true,
                    "input_examples": [
                        {
                            "query": "example query"
                        }
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
                    [nameof(Tool.DeferLoading)] = true,
                    [nameof(Tool.Strict)] = true,
                    [nameof(Tool.InputExamples)] = new List<Dictionary<string, JsonElement>>
                    {
                        new() { ["query"] = JsonSerializer.SerializeToElement("example query") },
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
                        "required": ["value"],
                        "additionalProperties": false
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
                    [nameof(Tool.Strict)] = true,
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

    /// <summary>
    /// Validates that all JSON schema transformations are applied correctly when using
    /// ChatResponseFormat.ForJsonSchema. Tests:
    /// <list type="bullet">
    /// <item>Numeric constraints (minimum, maximum, multipleOf) → description</item>
    /// <item>String constraints (minLength, maxLength, pattern) → description</item>
    /// <item>Unsupported string format → description</item>
    /// <item>Supported string format (email) preserved</item>
    /// <item>Array minItems &gt; 1 → description</item>
    /// <item>Array minItems ≤ 1 preserved</item>
    /// <item>oneOf → anyOf conversion (with nested object getting additionalProperties: false)</item>
    /// <item>enum preserved</item>
    /// <item>const preserved</item>
    /// <item>title preserved</item>
    /// <item>Unsupported properties (default) → description</item>
    /// <item>Nested object gets additionalProperties: false</item>
    /// <item>Root object gets additionalProperties: false</item>
    /// </list>
    /// </summary>
    [Fact]
    public async Task GetResponseAsync_ResponseFormatSchema_AllTransformationsApplied()
    {
        string inputSchema = """
            {
                "type": "object",
                "properties": {
                    "score": {
                        "type": "integer",
                        "description": "A score",
                        "minimum": 0,
                        "maximum": 100,
                        "multipleOf": 5
                    },
                    "code": {
                        "type": "string",
                        "minLength": 3,
                        "maxLength": 10,
                        "pattern": "^[A-Z]+$"
                    },
                    "phone": {
                        "type": "string",
                        "format": "phone"
                    },
                    "email": {
                        "type": "string",
                        "format": "email"
                    },
                    "tags": {
                        "type": "array",
                        "items": { "type": "string" },
                        "minItems": 3
                    },
                    "ids": {
                        "type": "array",
                        "items": { "type": "string" },
                        "minItems": 1
                    },
                    "value": {
                        "oneOf": [
                            { "type": "string" },
                            {
                                "type": "object",
                                "properties": { "x": { "type": "integer" } },
                                "required": ["x"]
                            }
                        ]
                    },
                    "status": {
                        "type": "string",
                        "enum": ["active", "inactive"]
                    },
                    "level": {
                        "type": "string",
                        "const": "admin"
                    },
                    "name": {
                        "type": "string",
                        "title": "Full Name"
                    },
                    "note": {
                        "type": "string",
                        "default": "N/A"
                    },
                    "nested": {
                        "type": "object",
                        "properties": {
                            "inner": { "type": "string" }
                        },
                        "required": ["inner"]
                    }
                },
                "required": ["score", "code", "phone", "email", "tags", "ids", "value", "status", "level", "name", "note", "nested"]
            }
            """;

        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-sonnet-4-5-20250929",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "test"
                    }]
                }],
                "output_config": {
                    "format": {
                        "type": "json_schema",
                        "schema": {
                            "type": "object",
                            "properties": {
                                "score": {
                                    "type": "integer",
                                    "description": "A score\n\n{minimum: 0, maximum: 100, multipleOf: 5}"
                                },
                                "code": {
                                    "type": "string",
                                    "description": "{minLength: 3, maxLength: 10, pattern: \"^[A-Z]+$\"}"
                                },
                                "phone": {
                                    "type": "string",
                                    "description": "{format: \"phone\"}"
                                },
                                "email": {
                                    "type": "string",
                                    "format": "email"
                                },
                                "tags": {
                                    "type": "array",
                                    "items": { "type": "string" },
                                    "description": "{minItems: 3}"
                                },
                                "ids": {
                                    "type": "array",
                                    "items": { "type": "string" },
                                    "minItems": 1
                                },
                                "value": {
                                    "anyOf": [
                                        { "type": "string" },
                                        {
                                            "type": "object",
                                            "properties": { "x": { "type": "integer" } },
                                            "required": ["x"],
                                            "additionalProperties": false
                                        }
                                    ]
                                },
                                "status": {
                                    "type": "string",
                                    "enum": ["active", "inactive"]
                                },
                                "level": {
                                    "type": "string",
                                    "const": "admin"
                                },
                                "name": {
                                    "type": "string",
                                    "title": "Full Name"
                                },
                                "note": {
                                    "type": "string",
                                    "description": "{default: \"N/A\"}"
                                },
                                "nested": {
                                    "type": "object",
                                    "properties": {
                                        "inner": { "type": "string" }
                                    },
                                    "required": ["inner"],
                                    "additionalProperties": false
                                }
                            },
                            "required": ["score", "code", "phone", "email", "tags", "ids", "value", "status", "level", "name", "note", "nested"],
                            "additionalProperties": false
                        }
                    }
                }
            }
            """,
            actualResponse: """
            {
                "id": "msg_transform_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-sonnet-4-5-20250929",
                "content": [{
                    "type": "text",
                    "text": "{}"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 25,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-sonnet-4-5-20250929");

        ChatOptions options = new()
        {
            ResponseFormat = ChatResponseFormat.ForJsonSchema(
                JsonElement.Parse(inputSchema),
                "test_schema"
            ),
        };

        ChatResponse response = await chatClient.GetResponseAsync(
            "test",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    /// <summary>
    /// Validates the same schema transformations as
    /// <see cref="GetResponseAsync_ResponseFormatSchema_AllTransformationsApplied"/> but through
    /// the <see cref="AIFunctionDeclaration"/> tool path, ensuring both code paths apply the same
    /// transform pipeline.
    /// </summary>
    [Fact]
    public async Task GetResponseAsync_ToolDeclarationSchema_AllTransformationsApplied()
    {
        string inputSchema = """
            {
                "type": "object",
                "properties": {
                    "score": {
                        "type": "integer",
                        "description": "A score",
                        "minimum": 0,
                        "maximum": 100,
                        "multipleOf": 5
                    },
                    "code": {
                        "type": "string",
                        "minLength": 3,
                        "maxLength": 10,
                        "pattern": "^[A-Z]+$"
                    },
                    "phone": {
                        "type": "string",
                        "format": "phone"
                    },
                    "email": {
                        "type": "string",
                        "format": "email"
                    },
                    "tags": {
                        "type": "array",
                        "items": { "type": "string" },
                        "minItems": 3
                    },
                    "ids": {
                        "type": "array",
                        "items": { "type": "string" },
                        "minItems": 1
                    },
                    "value": {
                        "oneOf": [
                            { "type": "string" },
                            {
                                "type": "object",
                                "properties": { "x": { "type": "integer" } },
                                "required": ["x"]
                            }
                        ]
                    },
                    "status": {
                        "type": "string",
                        "enum": ["active", "inactive"]
                    },
                    "level": {
                        "type": "string",
                        "const": "admin"
                    },
                    "name": {
                        "type": "string",
                        "title": "Full Name"
                    },
                    "note": {
                        "type": "string",
                        "default": "N/A"
                    },
                    "nested": {
                        "type": "object",
                        "properties": {
                            "inner": { "type": "string" }
                        },
                        "required": ["inner"]
                    }
                },
                "required": ["score", "code", "phone", "email", "tags", "ids", "value", "status", "level", "name", "note", "nested"]
            }
            """;

        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "max_tokens": 1024,
                "model": "claude-sonnet-4-5-20250929",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "test"
                    }]
                }],
                "tools": [{
                    "name": "test_tool",
                    "description": "A test tool",
                    "input_schema": {
                        "type": "object",
                        "properties": {
                            "score": {
                                "type": "integer",
                                "description": "A score\n\n{minimum: 0, maximum: 100, multipleOf: 5}"
                            },
                            "code": {
                                "type": "string",
                                "description": "{minLength: 3, maxLength: 10, pattern: \"^[A-Z]+$\"}"
                            },
                            "phone": {
                                "type": "string",
                                "description": "{format: \"phone\"}"
                            },
                            "email": {
                                "type": "string",
                                "format": "email"
                            },
                            "tags": {
                                "type": "array",
                                "items": { "type": "string" },
                                "description": "{minItems: 3}"
                            },
                            "ids": {
                                "type": "array",
                                "items": { "type": "string" },
                                "minItems": 1
                            },
                            "value": {
                                "anyOf": [
                                    { "type": "string" },
                                    {
                                        "type": "object",
                                        "properties": { "x": { "type": "integer" } },
                                        "required": ["x"],
                                        "additionalProperties": false
                                    }
                                ]
                            },
                            "status": {
                                "type": "string",
                                "enum": ["active", "inactive"]
                            },
                            "level": {
                                "type": "string",
                                "const": "admin"
                            },
                            "name": {
                                "type": "string",
                                "title": "Full Name"
                            },
                            "note": {
                                "type": "string",
                                "description": "{default: \"N/A\"}"
                            },
                            "nested": {
                                "type": "object",
                                "properties": {
                                    "inner": { "type": "string" }
                                },
                                "required": ["inner"],
                                "additionalProperties": false
                            }
                        },
                        "required": ["score", "code", "phone", "email", "tags", "ids", "value", "status", "level", "name", "note", "nested"],
                        "additionalProperties": false
                    }
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_transform_02",
                "type": "message",
                "role": "assistant",
                "model": "claude-sonnet-4-5-20250929",
                "content": [{
                    "type": "text",
                    "text": "ok"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 25,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-sonnet-4-5-20250929");

        var declaration = AIFunctionFactory.CreateDeclaration(
            "test_tool",
            "A test tool",
            JsonElement.Parse(inputSchema),
            null
        );

        ChatOptions options = new() { Tools = [declaration] };

        ChatResponse response = await chatClient.GetResponseAsync(
            "test",
            options,
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_ServerToolUseBlock_BashCodeExecution_MapsToDataContentWithShMediaType()
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
                        "text": "Run a bash command"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_bash_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [
                    {
                        "type": "server_tool_use",
                        "id": "srvtoolu_bash_01",
                        "name": "bash_code_execution",
                        "caller": { "type": "direct" },
                        "input": { "command": "echo hello" }
                    }
                ],
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
            "Run a bash command",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        var contents = response.Messages[0].Contents;
        var ciCall = Assert.IsType<CodeInterpreterToolCallContent>(contents[0]);
        Assert.Equal("srvtoolu_bash_01", ciCall.CallId);
        Assert.NotNull(ciCall.Inputs);
        Assert.Single(ciCall.Inputs);
        var codeInput = Assert.IsType<DataContent>(ciCall.Inputs[0]);
        Assert.Equal("application/x-sh", codeInput.MediaType);
        Assert.Equal("echo hello", Encoding.UTF8.GetString(codeInput.Data.ToArray()));
    }

    [Fact]
    public async Task GetResponseAsync_ServerToolUseBlock_TextEditorCodeExecution_MapsToDataContentWithTextPlainMediaType()
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
                        "text": "Create a file"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_te_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [
                    {
                        "type": "server_tool_use",
                        "id": "srvtoolu_te_01",
                        "name": "text_editor_code_execution",
                        "caller": { "type": "direct" },
                        "input": { "command": "create" }
                    }
                ],
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
            "Create a file",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        var contents = response.Messages[0].Contents;
        var ciCall = Assert.IsType<CodeInterpreterToolCallContent>(contents[0]);
        Assert.Equal("srvtoolu_te_01", ciCall.CallId);
        Assert.NotNull(ciCall.Inputs);
        Assert.Single(ciCall.Inputs);
        var codeInput = Assert.IsType<DataContent>(ciCall.Inputs[0]);
        Assert.Equal("text/plain", codeInput.MediaType);
        Assert.Equal("create", Encoding.UTF8.GetString(codeInput.Data.ToArray()));
    }

    [Fact]
    public async Task GetResponseAsync_ServerToolUseBlock_CodeExecution_WithMissingCodeKey_InputsNotPopulated()
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
                        "text": "Execute something"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_nocode_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [
                    {
                        "type": "server_tool_use",
                        "id": "srvtoolu_nocode_01",
                        "name": "code_execution",
                        "caller": { "type": "direct" },
                        "input": { "language": "python" }
                    }
                ],
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
            "Execute something",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        var contents = response.Messages[0].Contents;
        var ciCall = Assert.IsType<CodeInterpreterToolCallContent>(contents[0]);
        Assert.Equal("srvtoolu_nocode_01", ciCall.CallId);
        Assert.Null(ciCall.Inputs);
    }

    [Fact]
    public async Task GetResponseAsync_ServerToolUseBlock_UnknownName_MapsToToolCallContent()
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
                        "text": "Search tools"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_unknown_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [
                    {
                        "type": "server_tool_use",
                        "id": "srvtoolu_ts_01",
                        "name": "tool_search_tool_regex",
                        "caller": { "type": "direct" },
                        "input": {}
                    }
                ],
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
            "Search tools",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        var contents = response.Messages[0].Contents;
        var tc = Assert.IsType<ToolCallContent>(contents[0]);
        Assert.Equal("srvtoolu_ts_01", tc.CallId);
    }

    [Fact]
    public async Task GetResponseAsync_ServerToolUseBlock_WebSearch_WithoutQueryInput_QueriesNotPopulated()
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
                        "text": "Search the web"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_ws_noquery_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [
                    {
                        "type": "server_tool_use",
                        "id": "srvtoolu_ws_noq_01",
                        "name": "web_search",
                        "caller": { "type": "direct" },
                        "input": {}
                    }
                ],
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
            "Search the web",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        var contents = response.Messages[0].Contents;
        var wsc = Assert.IsType<WebSearchToolCallContent>(contents[0]);
        Assert.Equal("srvtoolu_ws_noq_01", wsc.CallId);
        Assert.Null(wsc.Queries);
    }

    [Fact]
    public async Task GetResponseAsync_WebFetchToolResultBlock_MapsToWebSearchToolResultContent()
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
                        "text": "Fetch a page"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_wf_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [
                    {
                        "type": "web_fetch_tool_result",
                        "tool_use_id": "srvtoolu_wf_01",
                        "caller": { "type": "direct" },
                        "content": {
                            "type": "web_fetch_result",
                            "url": "https://example.com/article.html",
                            "retrieved_at": "2025-01-01T00:00:00Z",
                            "content": {
                                "type": "document",
                                "citations": null,
                                "source": {
                                    "type": "text",
                                    "media_type": "text/plain",
                                    "data": "fetched content"
                                },
                                "title": "Article"
                            }
                        }
                    }
                ],
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
            "Fetch a page",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        var contents = response.Messages[0].Contents;
        var result = Assert.IsType<WebSearchToolResultContent>(contents[0]);
        Assert.Equal("srvtoolu_wf_01", result.CallId);
        Assert.NotNull(result.Results);
        Assert.Single(result.Results);
        var uriContent = Assert.IsType<UriContent>(result.Results[0]);
        Assert.Equal(new Uri("https://example.com/article.html"), uriContent.Uri);
        Assert.Equal("text/html", uriContent.MediaType);
    }

    [Fact]
    public async Task GetResponseAsync_TextEditorCodeExecutionResult_ViewOperation()
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
                        "text": "View a file"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_te_view_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [
                    {
                        "type": "text_editor_code_execution_tool_result",
                        "tool_use_id": "srvtoolu_te_01",
                        "content": {
                            "type": "text_editor_code_execution_view_result",
                            "file_type": "text",
                            "content": "print('hello')",
                            "num_lines": 1,
                            "start_line": 1,
                            "total_lines": 1
                        }
                    }
                ],
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
            "View a file",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        var contents = response.Messages[0].Contents;
        var ciResult = Assert.IsType<CodeInterpreterToolResultContent>(contents[0]);
        Assert.Equal("srvtoolu_te_01", ciResult.CallId);
        Assert.NotNull(ciResult.Outputs);
        Assert.Single(ciResult.Outputs);
        var textOutput = Assert.IsType<TextContent>(ciResult.Outputs[0]);
        Assert.Equal("print('hello')", textOutput.Text);
    }

    [Fact]
    public async Task GetResponseAsync_TextEditorCodeExecutionResult_WithError()
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
                        "text": "Edit missing file"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_te_err_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [
                    {
                        "type": "text_editor_code_execution_tool_result",
                        "tool_use_id": "srvtoolu_te_02",
                        "content": {
                            "type": "text_editor_code_execution_tool_result_error",
                            "error_code": "file_not_found",
                            "error_message": "File not found: /tmp/missing.py"
                        }
                    }
                ],
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
            "Edit missing file",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        var contents = response.Messages[0].Contents;
        var ciResult = Assert.IsType<CodeInterpreterToolResultContent>(contents[0]);
        Assert.Equal("srvtoolu_te_02", ciResult.CallId);
        Assert.NotNull(ciResult.Outputs);
        Assert.Single(ciResult.Outputs);
        var errorContent = Assert.IsType<ErrorContent>(ciResult.Outputs[0]);
        Assert.Equal("File not found: /tmp/missing.py", errorContent.Message);
        Assert.Equal("FileNotFound", errorContent.ErrorCode);
    }

    [Fact]
    public async Task GetResponseAsync_ToolSearchToolResultBlock_MapsToToolResultContent()
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
                        "text": "Find tools"
                    }]
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_ts_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [
                    {
                        "type": "tool_search_tool_result",
                        "tool_use_id": "srvtoolu_ts_01",
                        "content": {
                            "type": "tool_search_tool_search_result",
                            "tool_references": []
                        }
                    }
                ],
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
            "Find tools",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);

        var contents = response.Messages[0].Contents;
        var result = Assert.IsType<ToolResultContent>(contents[0]);
        Assert.Equal("srvtoolu_ts_01", result.CallId);
    }

    [Fact]
    public async Task GetStreamingResponseAsync_WithServerToolResultInContentBlockStart()
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
                        "text": "Search the web"
                    }]
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_stream_ws_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"web_search_tool_result","tool_use_id":"srvtoolu_ws_stream_01","caller":{"type":"direct"},"content":[{"type":"web_search_result","title":"Stream Result","url":"https://example.com/stream","encrypted_content":"enc_stream","page_age":"1 day ago"}]}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":5}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Search the web",
                new(),
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }
        Assert.NotEmpty(updates);

        var wsResultUpdates = updates
            .SelectMany(u => u.Contents.OfType<WebSearchToolResultContent>())
            .ToList();
        Assert.Single(wsResultUpdates);

        var wsResult = wsResultUpdates[0];
        Assert.Equal("srvtoolu_ws_stream_01", wsResult.CallId);
        Assert.NotNull(wsResult.Results);
        Assert.Single(wsResult.Results);

        var uriContent = Assert.IsType<UriContent>(wsResult.Results[0]);
        Assert.Equal(new Uri("https://example.com/stream"), uriContent.Uri);
    }

    [Fact]
    public async Task GetResponseAsync_EncryptedCodeExecutionResult_MapsStderrAndFiles()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Run code"
                    }]
                }],
                "max_tokens": 1024,
                "tools": [{
                    "type": "code_execution_20250825",
                    "name": "code_execution"
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_enc_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [
                    {
                        "type": "server_tool_use",
                        "id": "srvtoolu_enc_01",
                        "name": "code_execution",
                        "caller": { "type": "direct" },
                        "input": { "code": "print('hello')" }
                    },
                    {
                        "type": "code_execution_tool_result",
                        "tool_use_id": "srvtoolu_enc_01",
                        "content": {
                            "type": "encrypted_code_execution_result",
                            "encrypted_stdout": "base64encryptedstuff",
                            "stderr": "warning: something",
                            "return_code": 1,
                            "content": [
                                { "type": "code_execution_output", "file_id": "file_out_01" },
                                { "type": "code_execution_output", "file_id": "file_out_02" }
                            ]
                        }
                    }
                ],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 25,
                    "output_tokens": 20
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        ChatResponse response = await chatClient.GetResponseAsync(
            "Run code",
            new() { Tools = [new HostedCodeInterpreterTool()] },
            TestContext.Current.CancellationToken
        );

        var contents = response.Messages[0].Contents;
        var ciResult = Assert.IsType<CodeInterpreterToolResultContent>(contents[1]);
        Assert.Equal("srvtoolu_enc_01", ciResult.CallId);
        Assert.NotNull(ciResult.Outputs);

        // Encrypted stdout is not surfaced, but stderr and files are
        var errorOutput = Assert.IsType<ErrorContent>(ciResult.Outputs[0]);
        Assert.Equal("warning: something", errorOutput.Message);
        Assert.Equal("1", errorOutput.ErrorCode);

        var file1 = Assert.IsType<HostedFileContent>(ciResult.Outputs[1]);
        Assert.Equal("file_out_01", file1.FileId);

        var file2 = Assert.IsType<HostedFileContent>(ciResult.Outputs[2]);
        Assert.Equal("file_out_02", file2.FileId);
    }

    [Fact]
    public async Task GetResponseAsync_ContainerUploadBlock_MapsToHostedFileContent()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Upload a file"
                    }]
                }],
                "max_tokens": 1024,
                "tools": [{
                    "type": "code_execution_20250825",
                    "name": "code_execution"
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_cu_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [
                    {
                        "type": "container_upload",
                        "file_id": "file_container_01"
                    },
                    {
                        "type": "text",
                        "text": "File uploaded."
                    }
                ],
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
            "Upload a file",
            new() { Tools = [new HostedCodeInterpreterTool()] },
            TestContext.Current.CancellationToken
        );

        var contents = response.Messages[0].Contents;

        var hostedFile = Assert.IsType<HostedFileContent>(contents[0]);
        Assert.Equal("file_container_01", hostedFile.FileId);
        Assert.NotNull(hostedFile.RawRepresentation);

        var text = Assert.IsType<TextContent>(contents[1]);
        Assert.Equal("File uploaded.", text.Text);
    }

    [Fact]
    public async Task GetStreamingResponseAsync_ContainerUploadBlock_MapsToHostedFileContent()
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
                        "text": "Upload a file"
                    }]
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_stream_cu_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"container_upload","file_id":"file_stream_container_01"}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":5}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Upload a file",
                new(),
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }
        Assert.NotEmpty(updates);

        var hostedFiles = updates.SelectMany(u => u.Contents.OfType<HostedFileContent>()).ToList();
        Assert.Single(hostedFiles);
        Assert.Equal("file_stream_container_01", hostedFiles[0].FileId);
    }

    [Fact]
    public async Task GetStreamingResponseAsync_CitationsDelta_MapsToAnnotation()
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
                        "text": "Search and cite"
                    }]
                }],
                "stream": true
            }
            """,
            actualResponse: """
            event: message_start
            data: {"type":"message_start","message":{"id":"msg_stream_cite_01","type":"message","role":"assistant","model":"claude-haiku-4-5","content":[],"stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"output_tokens":0}}}

            event: content_block_start
            data: {"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"The Eiffel Tower is 330m tall."}}

            event: content_block_delta
            data: {"type":"content_block_delta","index":0,"delta":{"type":"citations_delta","citation":{"type":"web_search_result_location","cited_text":"330 meters tall","encrypted_index":"enc","title":"Eiffel Tower Facts","url":"https://example.com/eiffel"}}}

            event: content_block_stop
            data: {"type":"content_block_stop","index":0}

            event: message_delta
            data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":15}}

            event: message_stop
            data: {"type":"message_stop"}

            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        List<ChatResponseUpdate> updates = [];
        await foreach (
            var update in chatClient.GetStreamingResponseAsync(
                "Search and cite",
                new(),
                TestContext.Current.CancellationToken
            )
        )
        {
            updates.Add(update);
        }
        Assert.NotEmpty(updates);

        // Verify text came through
        var allText = string.Concat(
            updates.SelectMany(u => u.Contents.OfType<TextContent>()).Select(c => c.Text)
        );
        Assert.Contains("Eiffel Tower", allText);

        // Verify citation annotation came through
        var annotatedContents = updates
            .SelectMany(u => u.Contents.OfType<TextContent>())
            .Where(t => t.Annotations is { Count: > 0 })
            .ToList();
        Assert.Single(annotatedContents);

        var annotation = Assert.IsType<CitationAnnotation>(annotatedContents[0].Annotations![0]);
        Assert.Equal("Eiffel Tower Facts", annotation.Title);
        Assert.Equal("330 meters tall", annotation.Snippet);
        Assert.Equal(new Uri("https://example.com/eiffel"), annotation.Url);
    }

    [Fact]
    public void WithCacheControl_SetsAdditionalProperty()
    {
        var content = new TextContent("Hello, world!");

        content.WithCacheControl(Anthropic.Models.Messages.Ttl.Ttl5m);

        Assert.NotNull(content.AdditionalProperties);
        var cacheControl = content.GetCacheControl();
        Assert.NotNull(cacheControl);
        Assert.True(cacheControl.Ttl == Anthropic.Models.Messages.Ttl.Ttl5m);
    }

    [Fact]
    public void WithCacheControl_CacheControlEphemeral_SetsAdditionalProperty()
    {
        var content = new TextContent("Hello, world!");
        var cacheControl = new Anthropic.Models.Messages.CacheControlEphemeral
        {
            Ttl = Anthropic.Models.Messages.Ttl.Ttl1h,
        };

        content.WithCacheControl(cacheControl);

        var retrieved = content.GetCacheControl();
        Assert.NotNull(retrieved);
        Assert.True(retrieved.Ttl == Anthropic.Models.Messages.Ttl.Ttl1h);
    }

    [Fact]
    public void WithCacheControl_Null_RemovesCacheControl()
    {
        var content = new TextContent("Hello, world!");
        content.WithCacheControl(Anthropic.Models.Messages.Ttl.Ttl5m);

        Assert.NotNull(content.GetCacheControl());

        content.WithCacheControl((Anthropic.Models.Messages.CacheControlEphemeral?)null);

        Assert.Null(content.GetCacheControl());
    }

    [Fact]
    public async Task GetResponseAsync_WithCacheControlOnSystemMessage()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "Hello"
                    }]
                }],
                "max_tokens": 1024,
                "system": [{
                    "type": "text",
                    "text": "You are a helpful assistant.",
                    "cache_control": {
                        "type": "ephemeral",
                        "ttl": "1h"
                    }
                }]
            }
            """,
            actualResponse: """
            {
                "id": "msg_cache_01",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "Hello!"
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

        var systemContent = new TextContent("You are a helpful assistant.").WithCacheControl(
            Anthropic.Models.Messages.Ttl.Ttl1h
        );

        List<ChatMessage> messages =
        [
            new(ChatRole.System, [systemContent]),
            new(ChatRole.User, "Hello"),
        ];

        ChatResponse response = await chatClient.GetResponseAsync(
            messages,
            cancellationToken: TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithCacheControlOnUserMessage()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "text",
                        "text": "What is the meaning of life?",
                        "cache_control": {
                            "type": "ephemeral",
                            "ttl": "5m"
                        }
                    }]
                }],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_cache_02",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "42"
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 15,
                    "output_tokens": 3
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var userContent = new TextContent("What is the meaning of life?").WithCacheControl(
            Anthropic.Models.Messages.Ttl.Ttl5m
        );

        List<ChatMessage> messages = [new(ChatRole.User, [userContent])];

        ChatResponse response = await chatClient.GetResponseAsync(
            messages,
            cancellationToken: TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetResponseAsync_WithCacheControlOnImage()
    {
        VerbatimHttpHandler handler = new(
            expectedRequest: """
            {
                "model": "claude-haiku-4-5",
                "messages": [{
                    "role": "user",
                    "content": [{
                        "type": "image",
                        "source": {
                            "type": "base64",
                            "media_type": "image/png",
                            "data": "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+M9QDwADhgGAWjR9awAAAABJRU5ErkJggg=="
                        },
                        "cache_control": {
                            "type": "ephemeral",
                            "ttl": "1h"
                        }
                    }, {
                        "type": "text",
                        "text": "What do you see?"
                    }]
                }],
                "max_tokens": 1024
            }
            """,
            actualResponse: """
            {
                "id": "msg_cache_03",
                "type": "message",
                "role": "assistant",
                "model": "claude-haiku-4-5",
                "content": [{
                    "type": "text",
                    "text": "I see a small image."
                }],
                "stop_reason": "end_turn",
                "usage": {
                    "input_tokens": 100,
                    "output_tokens": 10
                }
            }
            """
        );

        IChatClient chatClient = CreateChatClient(handler, "claude-haiku-4-5");

        var imageContent = new DataContent(
            "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+M9QDwADhgGAWjR9awAAAABJRU5ErkJggg==",
            "image/png"
        ).WithCacheControl(Anthropic.Models.Messages.Ttl.Ttl1h);

        List<ChatMessage> messages =
        [
            new(ChatRole.User, [imageContent, new TextContent("What do you see?")]),
        ];

        ChatResponse response = await chatClient.GetResponseAsync(
            messages,
            cancellationToken: TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    protected sealed class VerbatimHttpHandler(string expectedRequest, string actualResponse)
        : HttpMessageHandler
    {
        public Action<HttpRequestHeaders>? OnRequestHeaders { get; set; }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            OnRequestHeaders?.Invoke(request.Headers);

            if (!string.IsNullOrEmpty(expectedRequest))
            {
                Assert.NotNull(request.Content);
                string actualRequest = await request.Content.ReadAsStringAsync(
#if NET
                    cancellationToken
#endif
                );
                Assert.True(
                    JsonNode.DeepEquals(
                        JsonNode.Parse(expectedRequest),
                        JsonNode.Parse(actualRequest)
                    ),
                    $"Expected:\n{expectedRequest}\nActual:\n{actualRequest}"
                );
            }

            return new()
            {
                Content = new StringContent(actualResponse, Encoding.UTF8, "application/json"),
            };
        }
    }

    [Theory]
    [InlineData("https://example.com/doc.pdf", "application/pdf")]
    [InlineData("https://example.com/page.html", "text/html")]
    [InlineData("https://example.com/path/resource", "application/octet-stream")]
    [InlineData("https://example.com/Photo.JPG", "image/jpeg")]
    [InlineData("https://example.com/file.xyz123", "application/octet-stream")]
    [InlineData(".py", "text/x-python")]
    [InlineData(".sh", "application/x-sh")]
    [InlineData(".js", "text/javascript")]
    [InlineData(".pdf", "application/pdf")]
    [InlineData(".PY", "text/x-python")]
    [InlineData(".PNG", "image/png")]
    [InlineData(".unknown", "application/octet-stream")]
    public void InferMediaTypeFromExtension_ReturnsExpectedType(
        string urlOrPath,
        string expectedMediaType
    )
    {
        Assert.Equal(
            expectedMediaType,
            AnthropicClientExtensions.InferMediaTypeFromExtension(urlOrPath)
        );
    }

    [Theory]
    [InlineData(null, "")]
    [InlineData("image/jpeg", ".jpg")]
    [InlineData("text/x-python", ".py")]
    [InlineData("application/pdf", ".pdf")]
    [InlineData("application/yaml", ".yaml")]
    [InlineData("text/javascript", ".js")]
    [InlineData("text/typescript", ".ts")]
    [InlineData("application/x-custom-unknown", "")]
    public void InferExtensionFromMediaType_ReturnsExpectedExtension(
        string? mediaType,
        string expectedExtension
    )
    {
        Assert.Equal(
            expectedExtension,
            AnthropicClientExtensions.InferExtensionFromMediaType(mediaType)
        );
    }
}
