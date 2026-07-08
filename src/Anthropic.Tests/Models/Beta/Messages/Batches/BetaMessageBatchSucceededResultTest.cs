using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages.Batches;
using Anthropic.Models.Messages;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages.Batches;

public class BetaMessageBatchSucceededResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMessageBatchSucceededResult
        {
            Message = new()
            {
                ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                Container = new()
                {
                    ID = "container_011CpZohnwH4vuy7gazohgSP",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Skills =
                    [
                        new()
                        {
                            SkillID = "pdf",
                            Type = Messages::Type.Anthropic,
                            Version = "latest",
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
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "My Document",
                                EndCharIndex = 0,
                                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
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
                Diagnostics = new(
                    new Messages::CacheMissReason(new Messages::BetaCacheMissModelChanged(0))
                ),
                Model = Model.ClaudeOpus4_6,
                StopDetails = new()
                {
                    Category = Messages::Category.Cyber,
                    Explanation =
                        "This request was declined because it conflicts with Anthropic's Usage Policy.",
                    FallbackCreditToken = "QW50aHJvcGljL0NsYXVkZQ==",
                    FallbackHasPrefillClaim = true,
                    RecommendedModel = "claude-sonnet-4-6",
                },
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
                    InferenceGeo = "global",
                    InputTokens = 2095,
                    Iterations =
                    [
                        new Messages::BetaMessageIterationUsage()
                        {
                            CacheCreation = new()
                            {
                                Ephemeral1hInputTokens = 0,
                                Ephemeral5mInputTokens = 0,
                            },
                            CacheCreationInputTokens = 0,
                            CacheReadInputTokens = 0,
                            InputTokens = 0,
                            Model = Model.ClaudeSonnet5,
                            OutputTokens = 0,
                        },
                    ],
                    OutputTokens = 503,
                    OutputTokensDetails = new(0),
                    ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                    ServiceTier = Messages::BetaUsageServiceTier.Standard,
                    Speed = Messages::BetaUsageSpeed.Standard,
                },
            },
        };

        Messages::BetaMessage expectedMessage = new()
        {
            ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
            Container = new()
            {
                ID = "container_011CpZohnwH4vuy7gazohgSP",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Skills =
                [
                    new()
                    {
                        SkillID = "pdf",
                        Type = Messages::Type.Anthropic,
                        Version = "latest",
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
                            CitedText = "The grass is green. The sky is blue.",
                            DocumentIndex = 0,
                            DocumentTitle = "My Document",
                            EndCharIndex = 0,
                            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
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
            Diagnostics = new(
                new Messages::CacheMissReason(new Messages::BetaCacheMissModelChanged(0))
            ),
            Model = Model.ClaudeOpus4_6,
            StopDetails = new()
            {
                Category = Messages::Category.Cyber,
                Explanation =
                    "This request was declined because it conflicts with Anthropic's Usage Policy.",
                FallbackCreditToken = "QW50aHJvcGljL0NsYXVkZQ==",
                FallbackHasPrefillClaim = true,
                RecommendedModel = "claude-sonnet-4-6",
            },
            StopReason = Messages::BetaStopReason.EndTurn,
            StopSequence = null,
            Usage = new()
            {
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InferenceGeo = "global",
                InputTokens = 2095,
                Iterations =
                [
                    new Messages::BetaMessageIterationUsage()
                    {
                        CacheCreation = new()
                        {
                            Ephemeral1hInputTokens = 0,
                            Ephemeral5mInputTokens = 0,
                        },
                        CacheCreationInputTokens = 0,
                        CacheReadInputTokens = 0,
                        InputTokens = 0,
                        Model = Model.ClaudeSonnet5,
                        OutputTokens = 0,
                    },
                ],
                OutputTokens = 503,
                OutputTokensDetails = new(0),
                ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                ServiceTier = Messages::BetaUsageServiceTier.Standard,
                Speed = Messages::BetaUsageSpeed.Standard,
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("succeeded");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMessageBatchSucceededResult
        {
            Message = new()
            {
                ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                Container = new()
                {
                    ID = "container_011CpZohnwH4vuy7gazohgSP",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Skills =
                    [
                        new()
                        {
                            SkillID = "pdf",
                            Type = Messages::Type.Anthropic,
                            Version = "latest",
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
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "My Document",
                                EndCharIndex = 0,
                                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
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
                Diagnostics = new(
                    new Messages::CacheMissReason(new Messages::BetaCacheMissModelChanged(0))
                ),
                Model = Model.ClaudeOpus4_6,
                StopDetails = new()
                {
                    Category = Messages::Category.Cyber,
                    Explanation =
                        "This request was declined because it conflicts with Anthropic's Usage Policy.",
                    FallbackCreditToken = "QW50aHJvcGljL0NsYXVkZQ==",
                    FallbackHasPrefillClaim = true,
                    RecommendedModel = "claude-sonnet-4-6",
                },
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
                    InferenceGeo = "global",
                    InputTokens = 2095,
                    Iterations =
                    [
                        new Messages::BetaMessageIterationUsage()
                        {
                            CacheCreation = new()
                            {
                                Ephemeral1hInputTokens = 0,
                                Ephemeral5mInputTokens = 0,
                            },
                            CacheCreationInputTokens = 0,
                            CacheReadInputTokens = 0,
                            InputTokens = 0,
                            Model = Model.ClaudeSonnet5,
                            OutputTokens = 0,
                        },
                    ],
                    OutputTokens = 503,
                    OutputTokensDetails = new(0),
                    ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                    ServiceTier = Messages::BetaUsageServiceTier.Standard,
                    Speed = Messages::BetaUsageSpeed.Standard,
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageBatchSucceededResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMessageBatchSucceededResult
        {
            Message = new()
            {
                ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                Container = new()
                {
                    ID = "container_011CpZohnwH4vuy7gazohgSP",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Skills =
                    [
                        new()
                        {
                            SkillID = "pdf",
                            Type = Messages::Type.Anthropic,
                            Version = "latest",
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
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "My Document",
                                EndCharIndex = 0,
                                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
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
                Diagnostics = new(
                    new Messages::CacheMissReason(new Messages::BetaCacheMissModelChanged(0))
                ),
                Model = Model.ClaudeOpus4_6,
                StopDetails = new()
                {
                    Category = Messages::Category.Cyber,
                    Explanation =
                        "This request was declined because it conflicts with Anthropic's Usage Policy.",
                    FallbackCreditToken = "QW50aHJvcGljL0NsYXVkZQ==",
                    FallbackHasPrefillClaim = true,
                    RecommendedModel = "claude-sonnet-4-6",
                },
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
                    InferenceGeo = "global",
                    InputTokens = 2095,
                    Iterations =
                    [
                        new Messages::BetaMessageIterationUsage()
                        {
                            CacheCreation = new()
                            {
                                Ephemeral1hInputTokens = 0,
                                Ephemeral5mInputTokens = 0,
                            },
                            CacheCreationInputTokens = 0,
                            CacheReadInputTokens = 0,
                            InputTokens = 0,
                            Model = Model.ClaudeSonnet5,
                            OutputTokens = 0,
                        },
                    ],
                    OutputTokens = 503,
                    OutputTokensDetails = new(0),
                    ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                    ServiceTier = Messages::BetaUsageServiceTier.Standard,
                    Speed = Messages::BetaUsageSpeed.Standard,
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageBatchSucceededResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Messages::BetaMessage expectedMessage = new()
        {
            ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
            Container = new()
            {
                ID = "container_011CpZohnwH4vuy7gazohgSP",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Skills =
                [
                    new()
                    {
                        SkillID = "pdf",
                        Type = Messages::Type.Anthropic,
                        Version = "latest",
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
                            CitedText = "The grass is green. The sky is blue.",
                            DocumentIndex = 0,
                            DocumentTitle = "My Document",
                            EndCharIndex = 0,
                            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
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
            Diagnostics = new(
                new Messages::CacheMissReason(new Messages::BetaCacheMissModelChanged(0))
            ),
            Model = Model.ClaudeOpus4_6,
            StopDetails = new()
            {
                Category = Messages::Category.Cyber,
                Explanation =
                    "This request was declined because it conflicts with Anthropic's Usage Policy.",
                FallbackCreditToken = "QW50aHJvcGljL0NsYXVkZQ==",
                FallbackHasPrefillClaim = true,
                RecommendedModel = "claude-sonnet-4-6",
            },
            StopReason = Messages::BetaStopReason.EndTurn,
            StopSequence = null,
            Usage = new()
            {
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InferenceGeo = "global",
                InputTokens = 2095,
                Iterations =
                [
                    new Messages::BetaMessageIterationUsage()
                    {
                        CacheCreation = new()
                        {
                            Ephemeral1hInputTokens = 0,
                            Ephemeral5mInputTokens = 0,
                        },
                        CacheCreationInputTokens = 0,
                        CacheReadInputTokens = 0,
                        InputTokens = 0,
                        Model = Model.ClaudeSonnet5,
                        OutputTokens = 0,
                    },
                ],
                OutputTokens = 503,
                OutputTokensDetails = new(0),
                ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                ServiceTier = Messages::BetaUsageServiceTier.Standard,
                Speed = Messages::BetaUsageSpeed.Standard,
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("succeeded");

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMessageBatchSucceededResult
        {
            Message = new()
            {
                ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                Container = new()
                {
                    ID = "container_011CpZohnwH4vuy7gazohgSP",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Skills =
                    [
                        new()
                        {
                            SkillID = "pdf",
                            Type = Messages::Type.Anthropic,
                            Version = "latest",
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
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "My Document",
                                EndCharIndex = 0,
                                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
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
                Diagnostics = new(
                    new Messages::CacheMissReason(new Messages::BetaCacheMissModelChanged(0))
                ),
                Model = Model.ClaudeOpus4_6,
                StopDetails = new()
                {
                    Category = Messages::Category.Cyber,
                    Explanation =
                        "This request was declined because it conflicts with Anthropic's Usage Policy.",
                    FallbackCreditToken = "QW50aHJvcGljL0NsYXVkZQ==",
                    FallbackHasPrefillClaim = true,
                    RecommendedModel = "claude-sonnet-4-6",
                },
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
                    InferenceGeo = "global",
                    InputTokens = 2095,
                    Iterations =
                    [
                        new Messages::BetaMessageIterationUsage()
                        {
                            CacheCreation = new()
                            {
                                Ephemeral1hInputTokens = 0,
                                Ephemeral5mInputTokens = 0,
                            },
                            CacheCreationInputTokens = 0,
                            CacheReadInputTokens = 0,
                            InputTokens = 0,
                            Model = Model.ClaudeSonnet5,
                            OutputTokens = 0,
                        },
                    ],
                    OutputTokens = 503,
                    OutputTokensDetails = new(0),
                    ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                    ServiceTier = Messages::BetaUsageServiceTier.Standard,
                    Speed = Messages::BetaUsageSpeed.Standard,
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaMessageBatchSucceededResult
        {
            Message = new()
            {
                ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                Container = new()
                {
                    ID = "container_011CpZohnwH4vuy7gazohgSP",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Skills =
                    [
                        new()
                        {
                            SkillID = "pdf",
                            Type = Messages::Type.Anthropic,
                            Version = "latest",
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
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "My Document",
                                EndCharIndex = 0,
                                FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
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
                Diagnostics = new(
                    new Messages::CacheMissReason(new Messages::BetaCacheMissModelChanged(0))
                ),
                Model = Model.ClaudeOpus4_6,
                StopDetails = new()
                {
                    Category = Messages::Category.Cyber,
                    Explanation =
                        "This request was declined because it conflicts with Anthropic's Usage Policy.",
                    FallbackCreditToken = "QW50aHJvcGljL0NsYXVkZQ==",
                    FallbackHasPrefillClaim = true,
                    RecommendedModel = "claude-sonnet-4-6",
                },
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
                    InferenceGeo = "global",
                    InputTokens = 2095,
                    Iterations =
                    [
                        new Messages::BetaMessageIterationUsage()
                        {
                            CacheCreation = new()
                            {
                                Ephemeral1hInputTokens = 0,
                                Ephemeral5mInputTokens = 0,
                            },
                            CacheCreationInputTokens = 0,
                            CacheReadInputTokens = 0,
                            InputTokens = 0,
                            Model = Model.ClaudeSonnet5,
                            OutputTokens = 0,
                        },
                    ],
                    OutputTokens = 503,
                    OutputTokensDetails = new(0),
                    ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                    ServiceTier = Messages::BetaUsageServiceTier.Standard,
                    Speed = Messages::BetaUsageSpeed.Standard,
                },
            },
        };

        BetaMessageBatchSucceededResult copied = new(model);

        Assert.Equal(model, copied);
    }
}
