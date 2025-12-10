using System;
using System.Text.Json;
using Anthropic.Models.Messages;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRawMessageStreamEventTest : TestBase
{
    [Fact]
    public void startValidation_Works()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new(
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
                    Model = Model.ClaudeOpus4_5_20251101,
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
    public void deltaValidation_Works()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new()
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
    public void stopValidation_Works()
    {
        Messages::BetaRawMessageStreamEvent value = new(new());
        value.Validate();
    }

    [Fact]
    public void content_block_startValidation_Works()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new()
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
    public void content_block_deltaValidation_Works()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new() { Delta = new Messages::BetaTextDelta("text"), Index = 0 }
        );
        value.Validate();
    }

    [Fact]
    public void content_block_stopValidation_Works()
    {
        Messages::BetaRawMessageStreamEvent value = new(new(0));
        value.Validate();
    }

    [Fact]
    public void startSerializationRoundtrip_Works()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new(
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
                    Model = Model.ClaudeOpus4_5_20251101,
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void deltaSerializationRoundtrip_Works()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new()
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void stopSerializationRoundtrip_Works()
    {
        Messages::BetaRawMessageStreamEvent value = new(new());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void content_block_startSerializationRoundtrip_Works()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new()
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void content_block_deltaSerializationRoundtrip_Works()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            new() { Delta = new Messages::BetaTextDelta("text"), Index = 0 }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void content_block_stopSerializationRoundtrip_Works()
    {
        Messages::BetaRawMessageStreamEvent value = new(new(0));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(json);

        Assert.Equal(value, deserialized);
    }
}
