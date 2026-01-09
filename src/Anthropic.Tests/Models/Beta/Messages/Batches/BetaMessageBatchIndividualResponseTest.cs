using System;
using System.Text.Json;
using Anthropic.Models.Beta.Messages.Batches;
using Anthropic.Models.Messages;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages.Batches;

public class BetaMessageBatchIndividualResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMessageBatchIndividualResponse
        {
            CustomID = "my-custom-id-1",
            Result = new BetaMessageBatchSucceededResult(
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
            ),
        };

        string expectedCustomID = "my-custom-id-1";
        BetaMessageBatchResult expectedResult = new BetaMessageBatchSucceededResult(
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
        );

        Assert.Equal(expectedCustomID, model.CustomID);
        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMessageBatchIndividualResponse
        {
            CustomID = "my-custom-id-1",
            Result = new BetaMessageBatchSucceededResult(
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
            ),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMessageBatchIndividualResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMessageBatchIndividualResponse
        {
            CustomID = "my-custom-id-1",
            Result = new BetaMessageBatchSucceededResult(
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
            ),
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMessageBatchIndividualResponse>(element);
        Assert.NotNull(deserialized);

        string expectedCustomID = "my-custom-id-1";
        BetaMessageBatchResult expectedResult = new BetaMessageBatchSucceededResult(
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
        );

        Assert.Equal(expectedCustomID, deserialized.CustomID);
        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMessageBatchIndividualResponse
        {
            CustomID = "my-custom-id-1",
            Result = new BetaMessageBatchSucceededResult(
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
            ),
        };

        model.Validate();
    }
}
