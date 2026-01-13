using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class RawMessageStreamEventTest : TestBase
{
    [Fact]
    public void StartValidationWorks()
    {
        RawMessageStreamEvent value = new RawMessageStartEvent(
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
                Model = Model.ClaudeSonnet4_5_20250929,
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
        );
        value.Validate();
    }

    [Fact]
    public void DeltaValidationWorks()
    {
        RawMessageStreamEvent value = new RawMessageDeltaEvent()
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
        };
        value.Validate();
    }

    [Fact]
    public void StopValidationWorks()
    {
        RawMessageStreamEvent value = new RawMessageStopEvent();
        value.Validate();
    }

    [Fact]
    public void ContentBlockStartValidationWorks()
    {
        RawMessageStreamEvent value = new RawContentBlockStartEvent()
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
        };
        value.Validate();
    }

    [Fact]
    public void ContentBlockDeltaValidationWorks()
    {
        RawMessageStreamEvent value = new RawContentBlockDeltaEvent()
        {
            Delta = new TextDelta("text"),
            Index = 0,
        };
        value.Validate();
    }

    [Fact]
    public void ContentBlockStopValidationWorks()
    {
        RawMessageStreamEvent value = new RawContentBlockStopEvent(0);
        value.Validate();
    }

    [Fact]
    public void StartSerializationRoundtripWorks()
    {
        RawMessageStreamEvent value = new RawMessageStartEvent(
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
                Model = Model.ClaudeSonnet4_5_20250929,
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
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DeltaSerializationRoundtripWorks()
    {
        RawMessageStreamEvent value = new RawMessageDeltaEvent()
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
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StopSerializationRoundtripWorks()
    {
        RawMessageStreamEvent value = new RawMessageStopEvent();
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContentBlockStartSerializationRoundtripWorks()
    {
        RawMessageStreamEvent value = new RawContentBlockStartEvent()
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
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContentBlockDeltaSerializationRoundtripWorks()
    {
        RawMessageStreamEvent value = new RawContentBlockDeltaEvent()
        {
            Delta = new TextDelta("text"),
            Index = 0,
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContentBlockStopSerializationRoundtripWorks()
    {
        RawMessageStreamEvent value = new RawContentBlockStopEvent(0);
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(element);

        Assert.Equal(value, deserialized);
    }
}
