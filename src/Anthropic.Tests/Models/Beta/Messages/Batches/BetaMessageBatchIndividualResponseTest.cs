using System;
using System.Text.Json;
using Anthropic.Core;
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
                            Citations = null,
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
                    Diagnostics = null,
                    Model = Model.ClaudeOpus5_5,
                    StopDetails = null,
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
                        FallbackCredit = new(new Messages::BetaFallbackCreditRedeemed()),
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
                                Model = Model.ClaudeFable5_2,
                                OutputTokens = 0,
                            },
                        ],
                        OutputTokens = 503,
                        OutputTokensDetails = new(0),
                        ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                        ServiceTier = Messages::BetaUsageServiceTier.Standard,
                        Speed = Messages::BetaUsageSpeed.Standard,
                    },
                    InputTransformations =
                    [
                        new Messages::BetaThinkingDroppedInputTransformation()
                        {
                            Path = "path",
                            Reason =
                                Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                        },
                    ],
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
                        Citations = null,
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
                Diagnostics = null,
                Model = Model.ClaudeOpus5_5,
                StopDetails = null,
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
                    FallbackCredit = new(new Messages::BetaFallbackCreditRedeemed()),
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
                            Model = Model.ClaudeFable5_2,
                            OutputTokens = 0,
                        },
                    ],
                    OutputTokens = 503,
                    OutputTokensDetails = new(0),
                    ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                    ServiceTier = Messages::BetaUsageServiceTier.Standard,
                    Speed = Messages::BetaUsageSpeed.Standard,
                },
                InputTransformations =
                [
                    new Messages::BetaThinkingDroppedInputTransformation()
                    {
                        Path = "path",
                        Reason =
                            Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                    },
                ],
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
                            Citations = null,
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
                    Diagnostics = null,
                    Model = Model.ClaudeOpus5_5,
                    StopDetails = null,
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
                        FallbackCredit = new(new Messages::BetaFallbackCreditRedeemed()),
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
                                Model = Model.ClaudeFable5_2,
                                OutputTokens = 0,
                            },
                        ],
                        OutputTokens = 503,
                        OutputTokensDetails = new(0),
                        ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                        ServiceTier = Messages::BetaUsageServiceTier.Standard,
                        Speed = Messages::BetaUsageSpeed.Standard,
                    },
                    InputTransformations =
                    [
                        new Messages::BetaThinkingDroppedInputTransformation()
                        {
                            Path = "path",
                            Reason =
                                Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                        },
                    ],
                }
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageBatchIndividualResponse>(
            json,
            ModelBase.SerializerOptions
        );

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
                            Citations = null,
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
                    Diagnostics = null,
                    Model = Model.ClaudeOpus5_5,
                    StopDetails = null,
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
                        FallbackCredit = new(new Messages::BetaFallbackCreditRedeemed()),
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
                                Model = Model.ClaudeFable5_2,
                                OutputTokens = 0,
                            },
                        ],
                        OutputTokens = 503,
                        OutputTokensDetails = new(0),
                        ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                        ServiceTier = Messages::BetaUsageServiceTier.Standard,
                        Speed = Messages::BetaUsageSpeed.Standard,
                    },
                    InputTransformations =
                    [
                        new Messages::BetaThinkingDroppedInputTransformation()
                        {
                            Path = "path",
                            Reason =
                                Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                        },
                    ],
                }
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageBatchIndividualResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCustomID = "my-custom-id-1";
        BetaMessageBatchResult expectedResult = new BetaMessageBatchSucceededResult(
            new Messages::BetaMessage()
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
                        Citations = null,
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
                Diagnostics = null,
                Model = Model.ClaudeOpus5_5,
                StopDetails = null,
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
                    FallbackCredit = new(new Messages::BetaFallbackCreditRedeemed()),
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
                            Model = Model.ClaudeFable5_2,
                            OutputTokens = 0,
                        },
                    ],
                    OutputTokens = 503,
                    OutputTokensDetails = new(0),
                    ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                    ServiceTier = Messages::BetaUsageServiceTier.Standard,
                    Speed = Messages::BetaUsageSpeed.Standard,
                },
                InputTransformations =
                [
                    new Messages::BetaThinkingDroppedInputTransformation()
                    {
                        Path = "path",
                        Reason =
                            Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                    },
                ],
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
                            Citations = null,
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
                    Diagnostics = null,
                    Model = Model.ClaudeOpus5_5,
                    StopDetails = null,
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
                        FallbackCredit = new(new Messages::BetaFallbackCreditRedeemed()),
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
                                Model = Model.ClaudeFable5_2,
                                OutputTokens = 0,
                            },
                        ],
                        OutputTokens = 503,
                        OutputTokensDetails = new(0),
                        ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                        ServiceTier = Messages::BetaUsageServiceTier.Standard,
                        Speed = Messages::BetaUsageSpeed.Standard,
                    },
                    InputTransformations =
                    [
                        new Messages::BetaThinkingDroppedInputTransformation()
                        {
                            Path = "path",
                            Reason =
                                Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                        },
                    ],
                }
            ),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
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
                            Citations = null,
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
                    Diagnostics = null,
                    Model = Model.ClaudeOpus5_5,
                    StopDetails = null,
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
                        FallbackCredit = new(new Messages::BetaFallbackCreditRedeemed()),
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
                                Model = Model.ClaudeFable5_2,
                                OutputTokens = 0,
                            },
                        ],
                        OutputTokens = 503,
                        OutputTokensDetails = new(0),
                        ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                        ServiceTier = Messages::BetaUsageServiceTier.Standard,
                        Speed = Messages::BetaUsageSpeed.Standard,
                    },
                    InputTransformations =
                    [
                        new Messages::BetaThinkingDroppedInputTransformation()
                        {
                            Path = "path",
                            Reason =
                                Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                        },
                    ],
                }
            ),
        };

        BetaMessageBatchIndividualResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
