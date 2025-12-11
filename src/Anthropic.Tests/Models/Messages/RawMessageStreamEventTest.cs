using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class RawMessageStreamEventTest : TestBase
{
    [Fact]
    public void startValidation_Works()
    {
        RawMessageStreamEvent value = new(
            new RawMessageStartEvent(
                new Message()
                {
                    ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                    Content =
                    [
                        new TextBlock()
                        {
                            Citations =
                            [
                                new CitationCharLocation()
                                {
                                    CitedText = "cited_text",
                                    DocumentIndex = 0,
                                    DocumentTitle = "document_title",
                                    EndCharIndex = 0,
                                    FileID = "file_id",
                                    StartCharIndex = 0,
                                },
                            ],
                            Text = "Hi! My name is Claude.",
                        },
                    ],
                    Model = Model.ClaudeOpus4_5_20251101,
                    StopReason = StopReason.EndTurn,
                    StopSequence = null,
                    Usage = new()
                    {
                        CacheCreation = new()
                        {
                            Ephemeral1hInputTokens = 0,
                            Ephemeral5mInputTokens = 0,
                        },
                        CacheCreationInputTokens = 2051,
                        CacheReadInputTokens = 2051,
                        InputTokens = 2095,
                        OutputTokens = 503,
                        ServerToolUse = new(0),
                        ServiceTier = UsageServiceTier.Standard,
                    },
                }
            )
        );
        value.Validate();
    }

    [Fact]
    public void deltaValidation_Works()
    {
        RawMessageStreamEvent value = new(
            new RawMessageDeltaEvent()
            {
                Delta = new() { StopReason = StopReason.EndTurn, StopSequence = "stop_sequence" },
                Usage = new()
                {
                    CacheCreationInputTokens = 2051,
                    CacheReadInputTokens = 2051,
                    InputTokens = 2095,
                    OutputTokens = 503,
                    ServerToolUse = new(0),
                },
            }
        );
        value.Validate();
    }

    [Fact]
    public void stopValidation_Works()
    {
        RawMessageStreamEvent value = new(new RawMessageStopEvent());
        value.Validate();
    }

    [Fact]
    public void content_block_startValidation_Works()
    {
        RawMessageStreamEvent value = new(
            new RawContentBlockStartEvent()
            {
                ContentBlock = new TextBlock()
                {
                    Citations =
                    [
                        new CitationCharLocation()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "document_title",
                            EndCharIndex = 0,
                            FileID = "file_id",
                            StartCharIndex = 0,
                        },
                    ],
                    Text = "text",
                },
                Index = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void content_block_deltaValidation_Works()
    {
        RawMessageStreamEvent value = new(
            new RawContentBlockDeltaEvent() { Delta = new TextDelta("text"), Index = 0 }
        );
        value.Validate();
    }

    [Fact]
    public void content_block_stopValidation_Works()
    {
        RawMessageStreamEvent value = new(new RawContentBlockStopEvent(0));
        value.Validate();
    }

    [Fact]
    public void startSerializationRoundtrip_Works()
    {
        RawMessageStreamEvent value = new(
            new RawMessageStartEvent(
                new Message()
                {
                    ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                    Content =
                    [
                        new TextBlock()
                        {
                            Citations =
                            [
                                new CitationCharLocation()
                                {
                                    CitedText = "cited_text",
                                    DocumentIndex = 0,
                                    DocumentTitle = "document_title",
                                    EndCharIndex = 0,
                                    FileID = "file_id",
                                    StartCharIndex = 0,
                                },
                            ],
                            Text = "Hi! My name is Claude.",
                        },
                    ],
                    Model = Model.ClaudeOpus4_5_20251101,
                    StopReason = StopReason.EndTurn,
                    StopSequence = null,
                    Usage = new()
                    {
                        CacheCreation = new()
                        {
                            Ephemeral1hInputTokens = 0,
                            Ephemeral5mInputTokens = 0,
                        },
                        CacheCreationInputTokens = 2051,
                        CacheReadInputTokens = 2051,
                        InputTokens = 2095,
                        OutputTokens = 503,
                        ServerToolUse = new(0),
                        ServiceTier = UsageServiceTier.Standard,
                    },
                }
            )
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void deltaSerializationRoundtrip_Works()
    {
        RawMessageStreamEvent value = new(
            new RawMessageDeltaEvent()
            {
                Delta = new() { StopReason = StopReason.EndTurn, StopSequence = "stop_sequence" },
                Usage = new()
                {
                    CacheCreationInputTokens = 2051,
                    CacheReadInputTokens = 2051,
                    InputTokens = 2095,
                    OutputTokens = 503,
                    ServerToolUse = new(0),
                },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void stopSerializationRoundtrip_Works()
    {
        RawMessageStreamEvent value = new(new RawMessageStopEvent());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void content_block_startSerializationRoundtrip_Works()
    {
        RawMessageStreamEvent value = new(
            new RawContentBlockStartEvent()
            {
                ContentBlock = new TextBlock()
                {
                    Citations =
                    [
                        new CitationCharLocation()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "document_title",
                            EndCharIndex = 0,
                            FileID = "file_id",
                            StartCharIndex = 0,
                        },
                    ],
                    Text = "text",
                },
                Index = 0,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void content_block_deltaSerializationRoundtrip_Works()
    {
        RawMessageStreamEvent value = new(
            new RawContentBlockDeltaEvent() { Delta = new TextDelta("text"), Index = 0 }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void content_block_stopSerializationRoundtrip_Works()
    {
        RawMessageStreamEvent value = new(new RawContentBlockStopEvent(0));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(json);

        Assert.Equal(value, deserialized);
    }
}
