using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anthropic.Client.Models.Messages;
using Anthropic.Client.Models.Messages.MessageParamProperties;
using Anthropic.Client.Services.Messages;
using Moq;

namespace Anthropic.Client.Tests.Services.Messages;

public class MessageServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var message = await this.client.Messages.Create(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = new("Hello, world"), Role = Role.User }],
                Model = Model.Claude3_7SonnetLatest,
            }
        );
        message.Validate();
    }

    [Fact]
    public async Task CreateStreaming_Works()
    {
        var stream = this.client.Messages.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = new("Hello, world"), Role = Role.User }],
                Model = Model.Claude3_7SonnetLatest,
            }
        );

        await foreach (var message in stream)
        {
            message.Validate();
        }
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
        // act
        messagesServiceMock.Setup(e => e.CreateStreaming(It.IsAny<MessageCreateParams>())).Returns(GetTestValues);
        var stream = await messagesServiceMock.Object.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = new(""), Role = Role.User }],
                Model = Model.Claude3_7SonnetLatest,
            }
        ).Aggregate();

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
        // act
        messagesServiceMock.Setup(e => e.CreateStreaming(It.IsAny<MessageCreateParams>())).Returns(GetTestValues);

        // assert
        await Assert.ThrowsAsync<InvalidOperationException>(async () => await messagesServiceMock.Object.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = new(""), Role = Role.User }],
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
        messagesServiceMock.Setup(e => e.CreateStreaming(It.IsAny<MessageCreateParams>())).Returns(GetTestValues);
        // act
        var stream = await messagesServiceMock.Object.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = new(""), Role = Role.User }],
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
        messagesServiceMock.Setup(e => e.CreateStreaming(It.IsAny<MessageCreateParams>())).Returns(GetTestValues);
        // act
        var stream = await messagesServiceMock.Object.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = new(""), Role = Role.User }],
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
                Delta = new(new CitationsDelta(new(new CitationsWebSearchResultLocation()
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
        messagesServiceMock.Setup(e => e.CreateStreaming(It.IsAny<MessageCreateParams>())).Returns(GetTestValues);
        // act
        var stream = await messagesServiceMock.Object.CreateStreaming(
            new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = new(""), Role = Role.User }],
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

    [Fact]
    public async Task CountTokens_Works()
    {
        var messageTokensCount = await this.client.Messages.CountTokens(
            new()
            {
                Messages = [new() { Content = new("string"), Role = Role.User }],
                Model = Model.Claude3_7SonnetLatest,
            }
        );
        messageTokensCount.Validate();
    }
}
