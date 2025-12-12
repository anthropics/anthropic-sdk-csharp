using System;
using System.Text.Json;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Messages.Batches;
using Anthropic.Models.Messages;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages.Batches;

public class BetaMessageBatchResultTest : TestBase
{
    [Fact]
    public void succeededValidation_Works()
    {
        BetaMessageBatchResult value = new(
            new BetaMessageBatchSucceededResult(
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
    public void erroredValidation_Works()
    {
        BetaMessageBatchResult value = new(
            new BetaMessageBatchErroredResult(
                new BetaErrorResponse()
                {
                    Error = new BetaInvalidRequestError("message"),
                    RequestID = "request_id",
                }
            )
        );
        value.Validate();
    }

    [Fact]
    public void canceledValidation_Works()
    {
        BetaMessageBatchResult value = new(new BetaMessageBatchCanceledResult());
        value.Validate();
    }

    [Fact]
    public void expiredValidation_Works()
    {
        BetaMessageBatchResult value = new(new BetaMessageBatchExpiredResult());
        value.Validate();
    }

    [Fact]
    public void succeededSerializationRoundtrip_Works()
    {
        BetaMessageBatchResult value = new(
            new BetaMessageBatchSucceededResult(
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
        var deserialized = JsonSerializer.Deserialize<BetaMessageBatchResult>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void erroredSerializationRoundtrip_Works()
    {
        BetaMessageBatchResult value = new(
            new BetaMessageBatchErroredResult(
                new BetaErrorResponse()
                {
                    Error = new BetaInvalidRequestError("message"),
                    RequestID = "request_id",
                }
            )
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMessageBatchResult>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void canceledSerializationRoundtrip_Works()
    {
        BetaMessageBatchResult value = new(new BetaMessageBatchCanceledResult());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMessageBatchResult>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void expiredSerializationRoundtrip_Works()
    {
        BetaMessageBatchResult value = new(new BetaMessageBatchExpiredResult());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMessageBatchResult>(json);

        Assert.Equal(value, deserialized);
    }
}
