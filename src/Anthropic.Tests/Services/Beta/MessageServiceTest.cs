using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Models.Beta.Messages;
using Anthropic.Models.Messages;
using Anthropic.Services;
using Moq;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Services.Beta;

public class MessageServiceTest
{
    [Theory(Skip = "prism validates based on the non-beta endpoint")]
    [AnthropicTestClients]
    public async Task Create_Works(IAnthropicClient client)
    {
        var betaMessage = await client.Beta.Messages.Create(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "Hello, world", Role = Anthropic.Models.Beta.Messages.Role.User }],
                Model = Messages::Model.ClaudeOpus4_5_20251101,
            }
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
                Messages = [new() { Content = "Hello, world", Role = Anthropic.Models.Beta.Messages.Role.User }],
                Model = Messages::Model.ClaudeOpus4_5_20251101,
            }
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
                Messages = [new() { Content = "string", Role = Anthropic.Models.Beta.Messages.Role.User }],
                Model = Messages::Model.ClaudeOpus4_5_20251101,
            }
        );
        betaMessageTokensCount.Validate();
    }

    [Fact]
    public async Task CreateStreamingAggregation_WorksNoContent_RawMessageStartEvent()
    {
        // arrange

        var messagesServiceMock = new Mock<IMessageService>();
        static async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            yield return new(new RawMessageStartEvent(GenerateStartMessage()));
            yield return new(new RawMessageStopEvent());
            await Task.CompletedTask;
        }
        messagesServiceMock.Setup(e => e.CreateStreaming(It.IsAny<Anthropic.Models.Messages.MessageCreateParams>(), It.IsAny<CancellationToken>())).Returns(GetTestValues);

        // act

        var stream = await messagesServiceMock.Object.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = new(""), Role = Anthropic.Models.Messages.Role.User }],
                Model = Model.Claude3_7SonnetLatest,
            }
        ).Aggregate();

        // assert

        Assert.NotNull(stream);
        Assert.Null(stream.Text);
        Assert.Null(stream.Thinking);
        Assert.NotNull(stream.Citations);
        Assert.Empty(stream.Citations);
        Assert.Null(stream.Thinking);
    }

    [Fact]
    public async Task CreateStreamingAggregation_HandlesNoEndMessageInterrupt()
    {
        // arrange

        var messagesServiceMock = new Mock<IMessageService>();
        static async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            yield return new(new RawMessageStartEvent(GenerateStartMessage()));
            await Task.CompletedTask;
        }
        messagesServiceMock.Setup(e => e.CreateStreaming(It.IsAny<Anthropic.Models.Messages.MessageCreateParams>(), It.IsAny<CancellationToken>())).Returns(GetTestValues);

        // act

        // assert

        await Assert.ThrowsAsync<InvalidOperationException>(async () => await messagesServiceMock.Object.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = new(""), Role = Anthropic.Models.Messages.Role.User }],
                Model = Model.Claude3_7SonnetLatest,
            }
        ).Aggregate());
    }

    [Fact]
    public async Task CreateStreamingAggregation_WorksNoContent_RawContentBlockStartEvent()
    {
        // arrange

        var messagesServiceMock = new Mock<IMessageService>();
        static async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            yield return new(new RawContentBlockStartEvent()
            {
                Index = 0,
                ContentBlock = null
            });
            yield return new(new RawContentBlockStopEvent()
            {
                Index = 1,
            });
            await Task.CompletedTask;
        }

        messagesServiceMock.Setup(e => e.CreateStreaming(It.IsAny<Anthropic.Models.Messages.MessageCreateParams>(), It.IsAny<CancellationToken>())).Returns(GetTestValues);

        // act

        var stream = await messagesServiceMock.Object.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = new(""), Role = Anthropic.Models.Messages.Role.User }],
                Model = Model.Claude3_7SonnetLatest,
            }
        ).Aggregate();

        // assert

        Assert.NotNull(stream);
        Assert.Null(stream.Text);
        Assert.Null(stream.Thinking);
        Assert.NotNull(stream.Citations);
        Assert.Empty(stream.Citations);
        Assert.Null(stream.Thinking);
    }

    [Fact]
    public async Task CreateStreamingAggregation_WorksStopEndEvent()
    {
        // arrange

        var messagesServiceMock = new Mock<IMessageService>();
        static async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            yield return new(new RawContentBlockStartEvent()
            {
                Index = 0,
                ContentBlock = null
            });
            yield return new(new RawContentBlockStopEvent()
            {
                Index = 1,
            });
            yield return new(new RawContentBlockDeltaEvent()
            {
                Index = 2,
                Delta = new(new TextDelta("Test"))
            });
            await Task.CompletedTask;
        }
        messagesServiceMock.Setup(e => e.CreateStreaming(It.IsAny<Anthropic.Models.Messages.MessageCreateParams>(), It.IsAny<CancellationToken>())).Returns(GetTestValues);

        // act

        var stream = await messagesServiceMock.Object.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = new(""), Role = Anthropic.Models.Messages.Role.User }],
                Model = Model.Claude3_7SonnetLatest,
            }
        ).Aggregate();

        // assert

        Assert.NotNull(stream);
        Assert.Null(stream.Text);
        Assert.Null(stream.Thinking);
        Assert.NotNull(stream.Citations);
        Assert.Empty(stream.Citations);
        Assert.Null(stream.Thinking);
    }

    [Fact]
    public async Task CreateStreamingAggregation_Works()
    {
        // arrange

        var messagesServiceMock = new Mock<IMessageService>();
        static async IAsyncEnumerable<RawMessageStreamEvent> GetTestValues()
        {
            int index = 0;
            yield return new(new RawContentBlockStartEvent()
            {
                Index = index++,
                ContentBlock = null
            });
            yield return new(new RawContentBlockDeltaEvent()
            {
                Index = index++,
                Delta = new(new TextDelta("Test"))
            });
            yield return new(new RawContentBlockDeltaEvent()
            {
                Index = index++,
                Delta = new(new CitationsDelta(new Anthropic.Models.Messages.Citation(new CitationsWebSearchResultLocation()
                {
                    CitedText = "Somewhere",
                    EncryptedIndex = "0",
                    Title = "Over",
                    URL = "the://rainbow"
                })))
            });
            yield return new(new RawContentBlockDeltaEvent()
            {
                Index = index++,
                Delta = new(new ThinkingDelta("Other Test"))
            });
            yield return new(new RawContentBlockStopEvent()
            {
                Index = index++,
            });
            await Task.CompletedTask;
        }
        messagesServiceMock.Setup(e => e.CreateStreaming(It.IsAny<Anthropic.Models.Messages.MessageCreateParams>(), It.IsAny<CancellationToken>())).Returns(GetTestValues);

        // act

        var stream = await messagesServiceMock.Object.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = new(""), Role = Anthropic.Models.Messages.Role.User }],
                Model = Model.Claude3_7SonnetLatest,
            }
        ).Aggregate();

        // assert

        Assert.NotNull(stream);
        Assert.Equal("Test", stream.Text);
        Assert.NotNull(stream.Citations);
        Assert.NotEmpty(stream.Citations);
        Assert.Equal("Other Test", stream.Thinking);
    }

    private static Message GenerateStartMessage()
    {
        return new Message()
        {
            ID = "Test",
            Content = [],
            Model = Model.Claude3OpusLatest,
            StopReason = StopReason.ToolUse,
            StopSequence = "",
            Usage = null
        };
    }
}
