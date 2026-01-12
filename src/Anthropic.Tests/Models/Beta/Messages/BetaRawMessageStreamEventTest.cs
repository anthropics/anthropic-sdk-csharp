using System;
using System.Text.Json;
using Anthropic.Models.Messages;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRawMessageStreamEventTest : TestBase
{
    [Fact]
    public void StartValidationWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new Messages::BetaRawMessageStartEvent(
                new Messages::BetaMessage()
                {
                    ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                    Container = new()
                    {
                        ID = "id",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Skills =
                        [
                            new()
                            {
                                SkillID = "x",
                                Type = Messages::Type.Anthropic,
                                Version = "x",
                            },
                        ],
                    },
                    Content =
                    [
                        new Messages::BetaTextBlock()
                        {
                            Citations =
                            [
                                new Messages::BetaCitationCharLocation()
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
                    ContextManagement = new(
                        [
                            new Messages::BetaClearToolUses20250919EditResponse()
                            {
                                ClearedInputTokens = 0,
                                ClearedToolUses = 0,
                            },
                        ]
                    ),
                    Model = Model.ClaudeSonnet4_5_20250929,
                    StopReason = Messages::BetaStopReason.EndTurn,
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
                        ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                        ServiceTier = Messages::BetaUsageServiceTier.Standard,
                    },
                }
            )
        );
        value.Validate();
    }

    [Fact]
    public void DeltaValidationWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new Messages::BetaRawMessageDeltaEvent()
            {
                ContextManagement = new(
                    [
                        new Messages::BetaClearToolUses20250919EditResponse()
                        {
                            ClearedInputTokens = 0,
                            ClearedToolUses = 0,
                        },
                    ]
                ),
                Delta = new()
                {
                    Container = new()
                    {
                        ID = "id",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Skills =
                        [
                            new()
                            {
                                SkillID = "x",
                                Type = Messages::Type.Anthropic,
                                Version = "x",
                            },
                        ],
                    },
                    StopReason = Messages::BetaStopReason.EndTurn,
                    StopSequence = "stop_sequence",
                },
                Usage = new()
                {
                    CacheCreationInputTokens = 2051,
                    CacheReadInputTokens = 2051,
                    InputTokens = 2095,
                    OutputTokens = 503,
                    ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                },
            }
        );
        value.Validate();
    }

    [Fact]
    public void StopValidationWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new(new Messages::BetaRawMessageStopEvent());
        value.Validate();
    }

    [Fact]
    public void ContentBlockStartValidationWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new Messages::BetaRawContentBlockStartEvent()
            {
                ContentBlock = new Messages::BetaTextBlock()
                {
                    Citations =
                    [
                        new Messages::BetaCitationCharLocation()
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
    public void ContentBlockDeltaValidationWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new Messages::BetaRawContentBlockDeltaEvent()
            {
                Delta = new Messages::BetaTextDelta("text"),
                Index = 0,
            }
        );
        value.Validate();
    }

    [Fact]
    public void ContentBlockStopValidationWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new Messages::BetaRawContentBlockStopEvent(0)
        );
        value.Validate();
    }

    [Fact]
    public void StartSerializationRoundtripWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new Messages::BetaRawMessageStartEvent(
                new Messages::BetaMessage()
                {
                    ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                    Container = new()
                    {
                        ID = "id",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Skills =
                        [
                            new()
                            {
                                SkillID = "x",
                                Type = Messages::Type.Anthropic,
                                Version = "x",
                            },
                        ],
                    },
                    Content =
                    [
                        new Messages::BetaTextBlock()
                        {
                            Citations =
                            [
                                new Messages::BetaCitationCharLocation()
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
                    ContextManagement = new(
                        [
                            new Messages::BetaClearToolUses20250919EditResponse()
                            {
                                ClearedInputTokens = 0,
                                ClearedToolUses = 0,
                            },
                        ]
                    ),
                    Model = Model.ClaudeSonnet4_5_20250929,
                    StopReason = Messages::BetaStopReason.EndTurn,
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
                        ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                        ServiceTier = Messages::BetaUsageServiceTier.Standard,
                    },
                }
            )
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DeltaSerializationRoundtripWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new Messages::BetaRawMessageDeltaEvent()
            {
                ContextManagement = new(
                    [
                        new Messages::BetaClearToolUses20250919EditResponse()
                        {
                            ClearedInputTokens = 0,
                            ClearedToolUses = 0,
                        },
                    ]
                ),
                Delta = new()
                {
                    Container = new()
                    {
                        ID = "id",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Skills =
                        [
                            new()
                            {
                                SkillID = "x",
                                Type = Messages::Type.Anthropic,
                                Version = "x",
                            },
                        ],
                    },
                    StopReason = Messages::BetaStopReason.EndTurn,
                    StopSequence = "stop_sequence",
                },
                Usage = new()
                {
                    CacheCreationInputTokens = 2051,
                    CacheReadInputTokens = 2051,
                    InputTokens = 2095,
                    OutputTokens = 503,
                    ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                },
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StopSerializationRoundtripWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new(new Messages::BetaRawMessageStopEvent());
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContentBlockStartSerializationRoundtripWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new Messages::BetaRawContentBlockStartEvent()
            {
                ContentBlock = new Messages::BetaTextBlock()
                {
                    Citations =
                    [
                        new Messages::BetaCitationCharLocation()
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
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContentBlockDeltaSerializationRoundtripWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new Messages::BetaRawContentBlockDeltaEvent()
            {
                Delta = new Messages::BetaTextDelta("text"),
                Index = 0,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContentBlockStopSerializationRoundtripWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new Messages::BetaRawContentBlockStopEvent(0)
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(element);

        Assert.Equal(value, deserialized);
    }
}
