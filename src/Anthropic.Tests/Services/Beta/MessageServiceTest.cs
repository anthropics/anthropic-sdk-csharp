using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Models.Beta.Messages;
using Anthropic.Services.Beta;
using Moq;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Services.Beta;

public class MessageServiceTest
{
    private static BetaMessage GenerateStartMessage =>
        new()
        {
            ID = "Test",
            Content = [],
            Model = Messages::Model.Claude3OpusLatest,
            StopReason = BetaStopReason.ToolUse,
            StopSequence = "",
            Usage = new()
            {
                CacheCreation = null,
                CacheCreationInputTokens = null,
                CacheReadInputTokens = null,
                InputTokens = 25,
                OutputTokens = 25,
                ServerToolUse = null,
                ServiceTier = BetaUsageServiceTier.Standard,
            },
            Container = null,
            ContextManagement = null,
        };

    private static MessageCreateParams StreamingParam =>
        new()
        {
            MaxTokens = 1024,
            Messages = [new() { Content = new(""), Role = Role.User }],
            Model = Messages::Model.Claude3OpusLatest,
        };

    [Theory(Skip = "prism validates based on the non-beta endpoint")]
    [AnthropicTestClients]
    public async Task Create_Works(IAnthropicClient client)
    {
        var betaMessage = await client.Beta.Messages.Create(
            new()
            {
                MaxTokens = 1024,
                Messages =
                [
                    new()
                    {
                        Content = "Hello, world",
                        Role = Anthropic.Models.Beta.Messages.Role.User,
                    },
                ],
                Model = Messages::Model.ClaudeSonnet4_5_20250929,
            },
            TestContext.Current.CancellationToken
        );
        betaMessage.Validate();
    }

    [Theory(Skip = "prism validates based on the non-beta endpoint")]
    [AnthropicTestClients]
    public async Task CreateStreaming_Works(IAnthropicClient client)
    {
        var stream = client.Beta.Messages.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages =
                [
                    new()
                    {
                        Content = "Hello, world",
                        Role = Anthropic.Models.Beta.Messages.Role.User,
                    },
                ],
                Model = Messages::Model.ClaudeSonnet4_5_20250929,
            },
            TestContext.Current.CancellationToken
        );

        await foreach (var betaMessage in stream)
        {
            betaMessage.Validate();
        }
    }

    [Theory(Skip = "prism validates based on the non-beta endpoint")]
    [AnthropicTestClients]
    public async Task CountTokens_Works(IAnthropicClient client)
    {
        var betaMessageTokensCount = await client.Beta.Messages.CountTokens(
            new()
            {
                Messages =
                [
                    new() { Content = "string", Role = Anthropic.Models.Beta.Messages.Role.User },
                ],
                Model = Messages::Model.ClaudeOpus4_5_20251101,
            },
            TestContext.Current.CancellationToken
        );
        betaMessageTokensCount.Validate();
    }

    [Fact]
    public async Task CreateStreamingAggregation_WorksNoContent_RawMessageStartEvent()
    {
        // arrange

        var messagesServiceMock = new Mock<IMessageService>();
        static async IAsyncEnumerable<BetaRawMessageStreamEvent> GetTestValues()
        {
            yield return new(new BetaRawMessageStartEvent(GenerateStartMessage));
            yield return new(new BetaRawMessageStopEvent());
            await Task.CompletedTask;
        }
        messagesServiceMock
            .Setup(e =>
                e.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>())
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
        static async IAsyncEnumerable<BetaRawMessageStreamEvent> GetTestValues()
        {
            yield return new(new BetaRawMessageStartEvent(GenerateStartMessage));
            await Task.CompletedTask;
        }
        messagesServiceMock
            .Setup(e =>
                e.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>())
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
        static async IAsyncEnumerable<BetaRawMessageStreamEvent> GetTestValues()
        {
            yield return new(new BetaRawMessageStartEvent(GenerateStartMessage));
            yield return new(
                new BetaRawContentBlockStartEvent()
                {
                    Index = 0,
                    ContentBlock = new(
                        new BetaTextBlock() { Citations = [], Text = "Test Output" }
                    ),
                }
            );
            yield return new(new BetaRawContentBlockStopEvent() { Index = 0 });
            yield return new(new BetaRawMessageStopEvent());
            await Task.CompletedTask;
        }

        messagesServiceMock
            .Setup(e =>
                e.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>())
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
        Assert.IsType<BetaTextBlock>(stream.Content[0].Value);
        Assert.Equal("Test Output", ((BetaTextBlock)stream.Content[0].Value!).Text);
    }

    [Fact]
    public async Task CreateStreamingAggregation_WorksStopEndEvent()
    {
        // arrange

        var messagesServiceMock = new Mock<IMessageService>();
        static async IAsyncEnumerable<BetaRawMessageStreamEvent> GetTestValues()
        {
            yield return new(new BetaRawMessageStartEvent(GenerateStartMessage));
            yield return new(
                new BetaRawContentBlockStartEvent()
                {
                    Index = 0,
                    ContentBlock = new BetaTextBlock() { Citations = [], Text = "this is a " },
                }
            );
            yield return new(new BetaRawContentBlockStopEvent() { Index = 0 });
            yield return new(
                new BetaRawContentBlockDeltaEvent()
                {
                    Index = 0,
                    Delta = new(new BetaTextDelta("Test")),
                }
            );
            yield return new(new BetaRawMessageStopEvent());
            await Task.CompletedTask;
        }
        messagesServiceMock
            .Setup(e =>
                e.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>())
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
        Assert.IsType<BetaTextBlock>(stream.Content[0].Value);
        Assert.Equal("this is a Test", ((BetaTextBlock)stream.Content[0].Value!).Text);
    }

    [Fact]
    public async Task CreateStreamingAggregation_Works()
    {
        // arrange

        var messagesServiceMock = new Mock<IMessageService>();
        static async IAsyncEnumerable<BetaRawMessageStreamEvent> GetTestValues()
        {
            yield return new(new BetaRawMessageStartEvent(GenerateStartMessage));
            yield return new(
                new BetaRawContentBlockStartEvent()
                {
                    Index = 0,
                    ContentBlock = new(new BetaTextBlock() { Citations = [], Text = "This is a " }),
                }
            );
            yield return new(
                new BetaRawContentBlockDeltaEvent()
                {
                    Index = 0,
                    Delta = new(new BetaTextDelta("Test")),
                }
            );
            yield return new(
                new BetaRawContentBlockDeltaEvent()
                {
                    Index = 0,
                    Delta = new(
                        new BetaCitationsDelta(
                            new Citation(
                                new BetaCitationsWebSearchResultLocation()
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
            yield return new(new BetaRawContentBlockStopEvent() { Index = 0 });
            yield return new(
                new BetaRawContentBlockStartEvent()
                {
                    Index = 1,
                    ContentBlock = new(
                        new BetaThinkingBlock() { Signature = "", Thinking = "Other Test" }
                    ),
                }
            );
            yield return new(new BetaRawContentBlockStopEvent() { Index = 1 });
            yield return new(new BetaRawMessageStopEvent());
            await Task.CompletedTask;
        }
        messagesServiceMock
            .Setup(e =>
                e.CreateStreaming(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>())
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
        Assert.IsType<BetaTextBlock>(stream.Content[0].Value);
        Assert.IsType<BetaThinkingBlock>(stream.Content[1].Value);
        Assert.Equal("This is a Test", ((BetaTextBlock)stream.Content[0].Value!).Text);
        Assert.NotNull(((BetaTextBlock)stream.Content[0].Value!).Citations);
        Assert.NotEmpty(((BetaTextBlock)stream.Content[0].Value!).Citations!);
        Assert.Equal("Other Test", ((BetaThinkingBlock)stream.Content[1].Value!).Thinking);
    }
}
