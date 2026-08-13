using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Helpers;
using Anthropic.Models.Messages;
using Anthropic.Services;
using Moq;

namespace Anthropic.Tests.Services;

public class MessageStreamingAggregationTest
{
    private static Message GenerateStartMessage =>
        new()
        {
            Container = null,
            ID = "Test",
            Content = [],
            Model = Model.ClaudeOpus4_6,
            StopDetails = null,
            StopReason = StopReason.ToolUse,
            StopSequence = "",
            Usage = new()
            {
                CacheCreation = null,
                CacheCreationInputTokens = null,
                CacheReadInputTokens = null,
                InputTokens = 25,
                OutputTokens = 25,
                OutputTokensDetails = new(0),
                ServerToolUse = null,
                ServiceTier = UsageServiceTier.Standard,
                InferenceGeo = "inference_geo",
            },
        };

    private static Anthropic.Models.Messages.MessageCreateParams StreamingParam =>
        new()
        {
            MaxTokens = 1024,
            Messages = [new() { Content = new(""), Role = Anthropic.Models.Messages.Role.User }],
            Model = Model.ClaudeSonnet4_5,
        };

    [Fact]
    public async Task CreateStreamingAggregation_WorksNoContent_RawMessageStartEvent()
    {
        // arrange

        var messagesServiceMock = new Mock<IMessageService>();
        static async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            yield return new(new RawMessageStartEvent(GenerateStartMessage));
            yield return new(new RawMessageStopEvent());
            await Task.CompletedTask;
        }
        messagesServiceMock
            .Setup(e =>
                e.CreateStreaming(
                    It.IsAny<Anthropic.Models.Messages.MessageCreateParams>(),
                    It.IsAny<CancellationToken>()
                )
            )
            .Returns(GetTestValues);

        // act

        var stream = await messagesServiceMock
            .Object.CreateStreaming(StreamingParam, TestContext.Current.CancellationToken)
            .Aggregate();

        // assert

        Assert.NotNull(stream);
        Assert.Empty(stream.Content);
        stream.Validate();
    }

    [Fact]
    public async Task CreateStreamingAggregation_HandlesNoEndMessageInterrupt()
    {
        // arrange

        var messagesServiceMock = new Mock<IMessageService>();
        static async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            yield return new(new RawMessageStartEvent(GenerateStartMessage));
            await Task.CompletedTask;
        }
        messagesServiceMock
            .Setup(e =>
                e.CreateStreaming(
                    It.IsAny<Anthropic.Models.Messages.MessageCreateParams>(),
                    It.IsAny<CancellationToken>()
                )
            )
            .Returns(GetTestValues);

        // act

        // assert

        await Assert.ThrowsAsync<Exceptions.AnthropicInvalidDataException>(async () =>
            await messagesServiceMock
                .Object.CreateStreaming(StreamingParam, TestContext.Current.CancellationToken)
                .Aggregate()
        );
    }

    [Fact]
    public async Task CreateStreamingAggregation_WorksNoContent_RawContentBlockStartEvent()
    {
        // arrange

        var messagesServiceMock = new Mock<IMessageService>();
        static async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            yield return new(new RawMessageStartEvent(GenerateStartMessage));
            yield return new(
                new RawContentBlockStartEvent()
                {
                    Index = 0,
                    ContentBlock = new(new TextBlock() { Citations = [], Text = "Test Output" }),
                }
            );
            yield return new(new RawContentBlockStopEvent() { Index = 0 });
            yield return new(new RawMessageStopEvent());
            await Task.CompletedTask;
        }

        messagesServiceMock
            .Setup(e =>
                e.CreateStreaming(
                    It.IsAny<Anthropic.Models.Messages.MessageCreateParams>(),
                    It.IsAny<CancellationToken>()
                )
            )
            .Returns(GetTestValues);

        // act

        var stream = await messagesServiceMock
            .Object.CreateStreaming(StreamingParam, TestContext.Current.CancellationToken)
            .Aggregate();

        // assert

        Assert.NotNull(stream);
        stream.Validate();
        Assert.NotEmpty(stream.Content);
        Assert.Single(stream.Content);
        Assert.IsType<TextBlock>(stream.Content[0].Value);
        Assert.Equal("Test Output", ((TextBlock)stream.Content[0].Value!).Text);
    }

    [Fact]
    public async Task CreateStreamingAggregation_WorksStopEndEvent()
    {
        // arrange

        var messagesServiceMock = new Mock<IMessageService>();
        static async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            yield return new(new RawMessageStartEvent(GenerateStartMessage));
            yield return new(
                new RawContentBlockStartEvent()
                {
                    Index = 0,
                    ContentBlock = new TextBlock() { Citations = [], Text = "this is a " },
                }
            );
            yield return new(new RawContentBlockStopEvent() { Index = 0 });
            yield return new(
                new RawContentBlockDeltaEvent() { Index = 0, Delta = new(new TextDelta("Test")) }
            );
            yield return new(new RawMessageStopEvent());
            await Task.CompletedTask;
        }
        messagesServiceMock
            .Setup(e =>
                e.CreateStreaming(
                    It.IsAny<Anthropic.Models.Messages.MessageCreateParams>(),
                    It.IsAny<CancellationToken>()
                )
            )
            .Returns(GetTestValues);

        // act

        var stream = await messagesServiceMock
            .Object.CreateStreaming(StreamingParam, TestContext.Current.CancellationToken)
            .Aggregate();

        // assert

        Assert.NotNull(stream);
        stream.Validate();
        Assert.NotEmpty(stream.Content);
        Assert.Single(stream.Content);
        Assert.IsType<TextBlock>(stream.Content[0].Value);
        Assert.Equal("this is a Test", ((TextBlock)stream.Content[0].Value!).Text);
    }

    [Fact]
    public async Task CreateStreamingAggregationPartialAggregation_Throws()
    {
        // arrange

        var messagesServiceMock = new Mock<IMessageService>();
        static async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            yield return new(new RawMessageStartEvent(GenerateStartMessage));
            yield return new(
                new RawContentBlockStartEvent()
                {
                    Index = 0,
                    ContentBlock = new(new TextBlock() { Citations = [], Text = "This is a " }),
                }
            );
            yield return new(
                new RawContentBlockDeltaEvent() { Index = 0, Delta = new(new TextDelta("Test")) }
            );
            yield return new(
                new RawContentBlockDeltaEvent()
                {
                    Index = 0,
                    Delta = new(
                        new CitationsDelta(
                            new Anthropic.Models.Messages.Citation(
                                new CitationsWebSearchResultLocation()
                                {
                                    CitedText = "Somewhere",
                                    EncryptedIndex = "0",
                                    Title = "Over",
                                    Url = "the://rainbow",
                                }
                            )
                        )
                    ),
                }
            );
            yield return new(new RawContentBlockStopEvent() { Index = 0 });
            yield return new(
                new RawContentBlockStartEvent()
                {
                    Index = 1,
                    ContentBlock = new(
                        new ThinkingBlock() { Signature = "", Thinking = "Other Test" }
                    ),
                }
            );
            yield return new(new RawContentBlockStopEvent() { Index = 1 });
            yield return new(new RawMessageStopEvent());
            await Task.CompletedTask;
        }
        messagesServiceMock
            .Setup(e =>
                e.CreateStreaming(
                    It.IsAny<Anthropic.Models.Messages.MessageCreateParams>(),
                    It.IsAny<CancellationToken>()
                )
            )
            .Returns(GetTestValues);

        // act

        var aggregator = new MessageContentAggregator();
        var stream = messagesServiceMock
            .Object.CreateStreaming(StreamingParam, TestContext.Current.CancellationToken)
            .CollectAsync(aggregator);
        await foreach (var _ in stream)
        {
            // don't iterate entirely
            break;
        }

        // assert

        var exception = Assert.Throws<Exceptions.AnthropicInvalidDataException>(() =>
            aggregator.Message()
        );
        Assert.Equal("stop message not yet received", exception.Message);
    }

    [Fact]
    public async Task CreateStreamingAggregation_Works()
    {
        // arrange

        var messagesServiceMock = new Mock<IMessageService>();
        static async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            yield return new(new RawMessageStartEvent(GenerateStartMessage));
            yield return new(
                new RawContentBlockStartEvent()
                {
                    Index = 0,
                    ContentBlock = new(new TextBlock() { Citations = [], Text = "This is a " }),
                }
            );
            yield return new(
                new RawContentBlockDeltaEvent() { Index = 0, Delta = new(new TextDelta("Test")) }
            );
            yield return new(
                new RawContentBlockDeltaEvent()
                {
                    Index = 0,
                    Delta = new(
                        new CitationsDelta(
                            new Anthropic.Models.Messages.Citation(
                                new CitationsWebSearchResultLocation()
                                {
                                    CitedText = "Somewhere",
                                    EncryptedIndex = "0",
                                    Title = "Over",
                                    Url = "the://rainbow",
                                }
                            )
                        )
                    ),
                }
            );
            yield return new(new RawContentBlockStopEvent() { Index = 0 });
            yield return new(
                new RawContentBlockStartEvent()
                {
                    Index = 1,
                    ContentBlock = new(
                        new ThinkingBlock() { Signature = "", Thinking = "Other Test" }
                    ),
                }
            );
            yield return new(new RawContentBlockStopEvent() { Index = 1 });
            yield return new(new RawMessageStopEvent());
            await Task.CompletedTask;
        }
        messagesServiceMock
            .Setup(e =>
                e.CreateStreaming(
                    It.IsAny<Anthropic.Models.Messages.MessageCreateParams>(),
                    It.IsAny<CancellationToken>()
                )
            )
            .Returns(GetTestValues);

        // act

        var stream = await messagesServiceMock
            .Object.CreateStreaming(StreamingParam, TestContext.Current.CancellationToken)
            .Aggregate();

        // assert

        Assert.NotNull(stream);
        stream.Validate();
        Assert.NotEmpty(stream.Content);
        Assert.Equal(2, stream.Content.Count);
        Assert.IsType<TextBlock>(stream.Content[0].Value);
        Assert.IsType<ThinkingBlock>(stream.Content[1].Value);
        Assert.Equal("This is a Test", ((TextBlock)stream.Content[0].Value!).Text);
        Assert.NotNull(((TextBlock)stream.Content[0].Value!).Citations);
        Assert.NotEmpty(((TextBlock)stream.Content[0].Value!).Citations!);
        Assert.Equal("Other Test", ((ThinkingBlock)stream.Content[1].Value!).Thinking);
    }

    [Fact]
    public async Task CreateStreamingAggregation_ReassemblesToolUseInputFromInputJsonDeltas()
    {
        // Arrange

        var messagesServiceMock = new Mock<IMessageService>();
        static async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            yield return new(new RawMessageStartEvent(GenerateStartMessage));
            yield return new(
                new RawContentBlockStartEvent()
                {
                    Index = 0,
                    ContentBlock = new(
                        new ToolUseBlock()
                        {
                            ID = "toolu_01",
                            Caller = new DirectCaller(),
                            Input = new Dictionary<string, JsonElement>(),
                            Name = "get_weather",
                        }
                    ),
                }
            );
            yield return new(
                new RawContentBlockDeltaEvent()
                {
                    Index = 0,
                    Delta = new(new InputJsonDelta("{\"location\":\"Pa")),
                }
            );
            yield return new(
                new RawContentBlockDeltaEvent()
                {
                    Index = 0,
                    Delta = new(new InputJsonDelta("ris\"}")),
                }
            );
            yield return new(new RawContentBlockStopEvent() { Index = 0 });
            yield return new(new RawMessageStopEvent());
            await Task.CompletedTask;
        }
        messagesServiceMock
            .Setup(e =>
                e.CreateStreaming(
                    It.IsAny<Anthropic.Models.Messages.MessageCreateParams>(),
                    It.IsAny<CancellationToken>()
                )
            )
            .Returns(GetTestValues);

        // Act

        var stream = await messagesServiceMock
            .Object.CreateStreaming(StreamingParam, TestContext.Current.CancellationToken)
            .Aggregate();

        // Assert

        Assert.NotNull(stream);
        stream.Validate();
        Assert.Single(stream.Content);
        var toolUse = Assert.IsType<ToolUseBlock>(stream.Content[0].Value);
        Assert.Equal("toolu_01", toolUse.ID);
        Assert.Equal("get_weather", toolUse.Name);
        Assert.Equal("Paris", toolUse.Input["location"].GetString());
        Assert.IsType<DirectCaller>(toolUse.Caller.Value);
    }

    private static Message GenerateStartMessageWithFullUsage =>
        new()
        {
            Container = null,
            ID = "Test",
            Content = [],
            Model = Model.ClaudeOpus4_6,
            StopDetails = null,
            StopReason = null,
            StopSequence = null,
            Usage = new()
            {
                CacheCreation = new() { Ephemeral1hInputTokens = 2, Ephemeral5mInputTokens = 5 },
                CacheCreationInputTokens = 7,
                CacheReadInputTokens = 3,
                InputTokens = 25,
                OutputTokens = 1,
                OutputTokensDetails = new(11),
                ServerToolUse = new() { WebFetchRequests = 1, WebSearchRequests = 1 },
                ServiceTier = UsageServiceTier.Standard,
                InferenceGeo = "inference_geo",
            },
        };

    [Fact]
    public async Task CreateStreamingAggregation_AppliesContainerAndUsageFromMessageDelta()
    {
        // arrange

        var messagesServiceMock = new Mock<IMessageService>();
        static async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            yield return new(new RawMessageStartEvent(GenerateStartMessage));
            yield return new(
                new RawMessageDeltaEvent()
                {
                    Delta = new()
                    {
                        Container = new()
                        {
                            ID = "container_01",
                            ExpiresAt = new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero),
                        },
                        StopDetails = null,
                        StopReason = StopReason.EndTurn,
                        StopSequence = null,
                    },
                    Usage = new()
                    {
                        CacheCreationInputTokens = 10,
                        CacheReadInputTokens = 5,
                        InputTokens = 100,
                        OutputTokens = 50,
                        OutputTokensDetails = new(30),
                        ServerToolUse = new() { WebFetchRequests = 1, WebSearchRequests = 2 },
                    },
                }
            );
            yield return new(new RawMessageStopEvent());
            await Task.CompletedTask;
        }
        messagesServiceMock
            .Setup(e =>
                e.CreateStreaming(
                    It.IsAny<Anthropic.Models.Messages.MessageCreateParams>(),
                    It.IsAny<CancellationToken>()
                )
            )
            .Returns(GetTestValues);

        // act

        var stream = await messagesServiceMock
            .Object.CreateStreaming(StreamingParam, TestContext.Current.CancellationToken)
            .Aggregate();

        // assert

        Assert.NotNull(stream);
        stream.Validate();
        Assert.NotNull(stream.Container);
        Assert.Equal("container_01", stream.Container!.ID);
        Assert.Equal(StopReason.EndTurn, stream.StopReason!.Value());
        Assert.Equal(100, stream.Usage.InputTokens);
        Assert.Equal(50, stream.Usage.OutputTokens);
        Assert.Equal(10, stream.Usage.CacheCreationInputTokens);
        Assert.Equal(5, stream.Usage.CacheReadInputTokens);
        Assert.NotNull(stream.Usage.OutputTokensDetails);
        Assert.Equal(30, stream.Usage.OutputTokensDetails!.ThinkingTokens);
        Assert.NotNull(stream.Usage.ServerToolUse);
        Assert.Equal(2, stream.Usage.ServerToolUse!.WebSearchRequests);
    }

    [Fact]
    public async Task CreateStreamingAggregation_KeepsStartUsageWhenMessageDeltaOmitsOptionalKeys()
    {
        // arrange

        var messagesServiceMock = new Mock<IMessageService>();
        static async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            yield return new(new RawMessageStartEvent(GenerateStartMessageWithFullUsage));
            yield return new(
                new RawMessageDeltaEvent()
                {
                    Delta = new()
                    {
                        Container = null,
                        StopDetails = null,
                        StopReason = StopReason.EndTurn,
                        StopSequence = null,
                    },
                    Usage = new()
                    {
                        CacheCreationInputTokens = null,
                        CacheReadInputTokens = null,
                        InputTokens = null,
                        OutputTokens = 99,
                        OutputTokensDetails = null,
                        ServerToolUse = null,
                    },
                }
            );
            yield return new(new RawMessageStopEvent());
            await Task.CompletedTask;
        }
        messagesServiceMock
            .Setup(e =>
                e.CreateStreaming(
                    It.IsAny<Anthropic.Models.Messages.MessageCreateParams>(),
                    It.IsAny<CancellationToken>()
                )
            )
            .Returns(GetTestValues);

        // act

        var stream = await messagesServiceMock
            .Object.CreateStreaming(StreamingParam, TestContext.Current.CancellationToken)
            .Aggregate();

        // assert

        Assert.NotNull(stream);
        stream.Validate();
        Assert.Equal(99, stream.Usage.OutputTokens);
        Assert.Equal(25, stream.Usage.InputTokens);
        Assert.Equal(7, stream.Usage.CacheCreationInputTokens);
        Assert.Equal(3, stream.Usage.CacheReadInputTokens);
        Assert.NotNull(stream.Usage.OutputTokensDetails);
        Assert.Equal(11, stream.Usage.OutputTokensDetails!.ThinkingTokens);
        Assert.NotNull(stream.Usage.ServerToolUse);
        Assert.Equal(1, stream.Usage.ServerToolUse!.WebSearchRequests);

        // never re-sent on message_delta, so they must survive from message_start
        Assert.NotNull(stream.Usage.CacheCreation);
        Assert.Equal(5, stream.Usage.CacheCreation!.Ephemeral5mInputTokens);
        Assert.Equal(UsageServiceTier.Standard, stream.Usage.ServiceTier!.Value());
        Assert.Equal("inference_geo", stream.Usage.InferenceGeo);
        Assert.Null(stream.Container);
    }

    [Fact]
    public async Task CreateStreamingAggregation_ReassemblesServerToolUseInputFromInputJsonDeltas()
    {
        static async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            yield return new(new RawMessageStartEvent(GenerateStartMessage));
            yield return new(
                new RawContentBlockStartEvent()
                {
                    Index = 0,
                    ContentBlock = new(
                        new ServerToolUseBlock()
                        {
                            ID = "srvtoolu_01",
                            Caller = new DirectCaller(),
                            Input = new Dictionary<string, JsonElement>(),
                            Name = Name.WebSearch,
                        }
                    ),
                }
            );
            yield return new(
                new RawContentBlockDeltaEvent()
                {
                    Index = 0,
                    Delta = new(new InputJsonDelta("{\"query\":\"latest")),
                }
            );
            yield return new(
                new RawContentBlockDeltaEvent()
                {
                    Index = 0,
                    Delta = new(new InputJsonDelta(" AI news\"}")),
                }
            );
            yield return new(new RawContentBlockStopEvent() { Index = 0 });
            yield return new(new RawMessageStopEvent());
            await Task.CompletedTask;
        }

        var stream = await GetTestValues().Aggregate();

        stream.Validate();
        var serverToolUse = Assert.IsType<ServerToolUseBlock>(Assert.Single(stream.Content).Value);
        Assert.Equal("srvtoolu_01", serverToolUse.ID);
        Assert.Equal(Name.WebSearch, serverToolUse.Name.Value());
        Assert.Equal("latest AI news", serverToolUse.Input["query"].GetString());
        Assert.IsType<DirectCaller>(serverToolUse.Caller.Value);
    }

    [Fact]
    public async Task CreateStreamingAggregation_KeepsStartInputWhenInputJsonDeltasAreTruncated()
    {
        // A stream cut by max_tokens mid-delta is legal; the block must survive with the start
        // event's input rather than failing the whole aggregation.
        static async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            yield return new(new RawMessageStartEvent(GenerateStartMessage));
            yield return new(
                new RawContentBlockStartEvent()
                {
                    Index = 0,
                    ContentBlock = new(
                        new ToolUseBlock()
                        {
                            ID = "toolu_01",
                            Caller = new DirectCaller(),
                            Input = new Dictionary<string, JsonElement>(),
                            Name = "get_weather",
                        }
                    ),
                }
            );
            yield return new(
                new RawContentBlockDeltaEvent()
                {
                    Index = 0,
                    Delta = new(new InputJsonDelta("{\"location\":\"Pa")),
                }
            );
            yield return new(new RawContentBlockStopEvent() { Index = 0 });
            yield return new(new RawMessageStopEvent());
            await Task.CompletedTask;
        }

        var stream = await GetTestValues().Aggregate();

        stream.Validate();
        var toolUse = Assert.IsType<ToolUseBlock>(Assert.Single(stream.Content).Value);
        Assert.Equal("toolu_01", toolUse.ID);
        Assert.Empty(toolUse.Input);
    }

    [Fact]
    public async Task CreateStreamingAggregation_PassesThroughBlocksWithoutDeltaVariants()
    {
        static async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            yield return new(new RawMessageStartEvent(GenerateStartMessage));
            yield return new(
                new RawContentBlockStartEvent()
                {
                    Index = 0,
                    ContentBlock = new(new RedactedThinkingBlock() { Data = "redacted" }),
                }
            );
            yield return new(new RawContentBlockStopEvent() { Index = 0 });
            yield return new(
                new RawContentBlockStartEvent()
                {
                    Index = 1,
                    ContentBlock = new(
                        new WebSearchToolResultBlock()
                        {
                            ToolUseID = "srvtoolu_01",
                            Caller = new DirectCaller(),
                            Content = new(
                                [
                                    new WebSearchResultBlock()
                                    {
                                        EncryptedContent = "encrypted",
                                        PageAge = null,
                                        Title = "Result",
                                        Url = "https://example.com",
                                    },
                                ]
                            ),
                        }
                    ),
                }
            );
            yield return new(new RawContentBlockStopEvent() { Index = 1 });
            yield return new(
                new RawContentBlockStartEvent()
                {
                    Index = 2,
                    ContentBlock = new(new ContainerUploadBlock() { FileID = "file_01" }),
                }
            );
            yield return new(new RawContentBlockStopEvent() { Index = 2 });
            yield return new(new RawMessageStopEvent());
            await Task.CompletedTask;
        }

        var stream = await GetTestValues().Aggregate();

        stream.Validate();
        Assert.Equal(3, stream.Content.Count);
        var redacted = Assert.IsType<RedactedThinkingBlock>(stream.Content[0].Value);
        Assert.Equal("redacted", redacted.Data);
        var webSearch = Assert.IsType<WebSearchToolResultBlock>(stream.Content[1].Value);
        Assert.Equal("srvtoolu_01", webSearch.ToolUseID);
        Assert.True(webSearch.Content.TryPickWebSearchResultBlocks(out var results));
        Assert.Equal("https://example.com", Assert.Single(results).Url);
        var upload = Assert.IsType<ContainerUploadBlock>(stream.Content[2].Value);
        Assert.Equal("file_01", upload.FileID);
    }

    [Fact]
    public async Task CreateStreamingAggregation_PassesThroughUnmodelledBlockTypes()
    {
        // A block type this SDK version doesn't know must survive aggregation as raw JSON, the
        // same way it survives a non-streaming response.
        var unknownBlock = JsonSerializer.Deserialize<JsonElement>(
            "{\"type\":\"shiny_new_block\",\"payload\":42}"
        );
        async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            yield return new(new RawMessageStartEvent(GenerateStartMessage));
            yield return new(
                new RawContentBlockStartEvent() { Index = 0, ContentBlock = new(unknownBlock) }
            );
            yield return new(new RawContentBlockStopEvent() { Index = 0 });
            yield return new(new RawMessageStopEvent());
            await Task.CompletedTask;
        }

        var stream = await GetTestValues().Aggregate();

        var block = Assert.Single(stream.Content);
        Assert.Null(block.Value);
        Assert.True(JsonElement.DeepEquals(unknownBlock, block.Json));
    }
}
