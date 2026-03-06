using System.Collections.Generic;
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
            StopReason = StopReason.ToolUse,
            StopSequence = "",
            Usage = new()
            {
                CacheCreation = null,
                CacheCreationInputTokens = null,
                CacheReadInputTokens = null,
                InputTokens = 25,
                OutputTokens = 25,
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
}
