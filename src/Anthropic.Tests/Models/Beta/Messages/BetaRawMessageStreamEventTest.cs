using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRawMessageStreamEventTest : TestBase
{
    [Fact]
    public void StartValidationWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawMessageStartEvent(
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
                Diagnostics = new(new Messages::BetaCacheMissModelChanged(0)),
                Model = Model.ClaudeOpus5_5,
                StopDetails = new()
                {
                    Category = Messages::Category.Cyber,
                    Explanation =
                        "This request was declined because it conflicts with Anthropic's Usage Policy.",
                    FallbackCreditToken = "QW50aHJvcGljL0NsYXVkZQ==",
                    FallbackHasPrefillClaim = true,
                    RecommendedModel = "claude-opus-4-8",
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
                            Model = Model.ClaudeHaiku5_5,
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
        value.Validate();
    }

    [Fact]
    public void DeltaValidationWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawMessageDeltaEvent()
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
                StopDetails = new()
                {
                    Category = Messages::Category.Cyber,
                    Explanation =
                        "This request was declined because it conflicts with Anthropic's Usage Policy.",
                    FallbackCreditToken = "QW50aHJvcGljL0NsYXVkZQ==",
                    FallbackHasPrefillClaim = true,
                    RecommendedModel = "claude-opus-4-8",
                },
                StopReason = Messages::BetaStopReason.EndTurn,
                StopSequence = "stop_sequence",
            },
            Usage = new()
            {
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                FallbackCredit = new(new Messages::BetaFallbackCreditRedeemed()),
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
                        Model = Model.ClaudeHaiku5_5,
                        OutputTokens = 0,
                    },
                ],
                OutputTokens = 503,
                OutputTokensDetails = new(0),
                ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
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
        };
        value.Validate();
    }

    [Fact]
    public void StopValidationWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawMessageStopEvent();
        value.Validate();
    }

    [Fact]
    public void ContentBlockStartValidationWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawContentBlockStartEvent()
        {
            ContentBlock = new Messages::BetaTextBlock()
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
                Text = "text",
            },
            Index = 0,
        };
        value.Validate();
    }

    [Fact]
    public void ContentBlockDeltaValidationWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawContentBlockDeltaEvent()
        {
            Delta = new Messages::BetaTextDelta("text"),
            Index = 0,
        };
        value.Validate();
    }

    [Fact]
    public void ContentBlockStopValidationWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawContentBlockStopEvent(0);
        value.Validate();
    }

    [Fact]
    public void StartSerializationRoundtripWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawMessageStartEvent(
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
                Diagnostics = new(new Messages::BetaCacheMissModelChanged(0)),
                Model = Model.ClaudeOpus5_5,
                StopDetails = new()
                {
                    Category = Messages::Category.Cyber,
                    Explanation =
                        "This request was declined because it conflicts with Anthropic's Usage Policy.",
                    FallbackCreditToken = "QW50aHJvcGljL0NsYXVkZQ==",
                    FallbackHasPrefillClaim = true,
                    RecommendedModel = "claude-opus-4-8",
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
                            Model = Model.ClaudeHaiku5_5,
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DeltaSerializationRoundtripWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawMessageDeltaEvent()
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
                StopDetails = new()
                {
                    Category = Messages::Category.Cyber,
                    Explanation =
                        "This request was declined because it conflicts with Anthropic's Usage Policy.",
                    FallbackCreditToken = "QW50aHJvcGljL0NsYXVkZQ==",
                    FallbackHasPrefillClaim = true,
                    RecommendedModel = "claude-opus-4-8",
                },
                StopReason = Messages::BetaStopReason.EndTurn,
                StopSequence = "stop_sequence",
            },
            Usage = new()
            {
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                FallbackCredit = new(new Messages::BetaFallbackCreditRedeemed()),
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
                        Model = Model.ClaudeHaiku5_5,
                        OutputTokens = 0,
                    },
                ],
                OutputTokens = 503,
                OutputTokensDetails = new(0),
                ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
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
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StopSerializationRoundtripWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawMessageStopEvent();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContentBlockStartSerializationRoundtripWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawContentBlockStartEvent()
        {
            ContentBlock = new Messages::BetaTextBlock()
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
                Text = "text",
            },
            Index = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContentBlockDeltaSerializationRoundtripWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawContentBlockDeltaEvent()
        {
            Delta = new Messages::BetaTextDelta("text"),
            Index = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContentBlockStopSerializationRoundtripWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawContentBlockStopEvent(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageStreamEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StartTypeWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawMessageStartEvent(
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
                Diagnostics = new(new Messages::BetaCacheMissModelChanged(0)),
                Model = Model.ClaudeOpus5_5,
                StopDetails = new()
                {
                    Category = Messages::Category.Cyber,
                    Explanation =
                        "This request was declined because it conflicts with Anthropic's Usage Policy.",
                    FallbackCreditToken = "QW50aHJvcGljL0NsYXVkZQ==",
                    FallbackHasPrefillClaim = true,
                    RecommendedModel = "claude-opus-4-8",
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
                            Model = Model.ClaudeHaiku5_5,
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
        Assert.Equal(Messages::BetaRawMessageStreamEventType.MessageStart, value.Type.Value());
    }

    [Fact]
    public void DeltaTypeWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawMessageDeltaEvent()
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
                StopDetails = new()
                {
                    Category = Messages::Category.Cyber,
                    Explanation =
                        "This request was declined because it conflicts with Anthropic's Usage Policy.",
                    FallbackCreditToken = "QW50aHJvcGljL0NsYXVkZQ==",
                    FallbackHasPrefillClaim = true,
                    RecommendedModel = "claude-opus-4-8",
                },
                StopReason = Messages::BetaStopReason.EndTurn,
                StopSequence = "stop_sequence",
            },
            Usage = new()
            {
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                FallbackCredit = new(new Messages::BetaFallbackCreditRedeemed()),
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
                        Model = Model.ClaudeHaiku5_5,
                        OutputTokens = 0,
                    },
                ],
                OutputTokens = 503,
                OutputTokensDetails = new(0),
                ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
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
        };
        Assert.Equal(Messages::BetaRawMessageStreamEventType.MessageDelta, value.Type.Value());
    }

    [Fact]
    public void StopTypeWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawMessageStopEvent();
        Assert.Equal(Messages::BetaRawMessageStreamEventType.MessageStop, value.Type.Value());
    }

    [Fact]
    public void ContentBlockStartTypeWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawContentBlockStartEvent()
        {
            ContentBlock = new Messages::BetaTextBlock()
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
                Text = "text",
            },
            Index = 0,
        };
        Assert.Equal(Messages::BetaRawMessageStreamEventType.ContentBlockStart, value.Type.Value());
    }

    [Fact]
    public void ContentBlockDeltaTypeWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawContentBlockDeltaEvent()
        {
            Delta = new Messages::BetaTextDelta("text"),
            Index = 0,
        };
        Assert.Equal(Messages::BetaRawMessageStreamEventType.ContentBlockDelta, value.Type.Value());
    }

    [Fact]
    public void ContentBlockStopTypeWorks()
    {
        Messages::BetaRawMessageStreamEvent value = new Messages::BetaRawContentBlockStopEvent(0);
        Assert.Equal(Messages::BetaRawMessageStreamEventType.ContentBlockStop, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Messages::BetaRawMessageStreamEvent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "message_start",
                  "index": 0
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, Messages::BetaRawMessageStreamEventType> expectedType =
            Messages::BetaRawMessageStreamEventType.MessageStart;
        long expectedIndex = 0;

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedIndex, value.Index);

        Messages::BetaRawMessageStreamEvent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.Index);

        Messages::BetaRawMessageStreamEvent mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "index": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.Index);
    }
}

public class BetaRawMessageStreamEventTypeTest : TestBase
{
    [Theory]
    [InlineData(Messages::BetaRawMessageStreamEventType.MessageStart)]
    [InlineData(Messages::BetaRawMessageStreamEventType.MessageDelta)]
    [InlineData(Messages::BetaRawMessageStreamEventType.MessageStop)]
    [InlineData(Messages::BetaRawMessageStreamEventType.ContentBlockStart)]
    [InlineData(Messages::BetaRawMessageStreamEventType.ContentBlockDelta)]
    [InlineData(Messages::BetaRawMessageStreamEventType.ContentBlockStop)]
    public void Validation_Works(Messages::BetaRawMessageStreamEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Messages::BetaRawMessageStreamEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Messages::BetaRawMessageStreamEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Messages::BetaRawMessageStreamEventType.MessageStart)]
    [InlineData(Messages::BetaRawMessageStreamEventType.MessageDelta)]
    [InlineData(Messages::BetaRawMessageStreamEventType.MessageStop)]
    [InlineData(Messages::BetaRawMessageStreamEventType.ContentBlockStart)]
    [InlineData(Messages::BetaRawMessageStreamEventType.ContentBlockDelta)]
    [InlineData(Messages::BetaRawMessageStreamEventType.ContentBlockStop)]
    public void SerializationRoundtrip_Works(Messages::BetaRawMessageStreamEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Messages::BetaRawMessageStreamEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Messages::BetaRawMessageStreamEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Messages::BetaRawMessageStreamEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Messages::BetaRawMessageStreamEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
