using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Messages::BetaMessage
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
            Model = Model.ClaudeOpus5,
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                FallbackCredit = new(
                    new Messages::Status(new Messages::BetaFallbackCreditRedeemed())
                ),
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
                        Model = Model.ClaudeFable5_1,
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
                new()
                {
                    Path = "path",
                    Reason =
                        Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                },
            ],
        };

        string expectedID = "msg_013Zva2CMHLNnXjNJJKqJ2EF";
        Messages::BetaContainer expectedContainer = new()
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
        };
        List<Messages::BetaContentBlock> expectedContent =
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
        ];
        Messages::BetaContextManagementResponse expectedContextManagement = new(
            [
                new Messages::BetaClearToolUses20250919EditResponse()
                {
                    ClearedInputTokens = 0,
                    ClearedToolUses = 0,
                },
            ]
        );
        Messages::BetaDiagnostics expectedDiagnostics = new(
            new Messages::CacheMissReason(new Messages::BetaCacheMissModelChanged(0))
        );
        ApiEnum<string, Model> expectedModel = Model.ClaudeOpus5;
        JsonElement expectedRole = JsonSerializer.SerializeToElement("assistant");
        Messages::BetaRefusalStopDetails expectedStopDetails = new()
        {
            Category = Messages::Category.Cyber,
            Explanation =
                "This request was declined because it conflicts with Anthropic's Usage Policy.",
            FallbackCreditToken = "QW50aHJvcGljL0NsYXVkZQ==",
            FallbackHasPrefillClaim = true,
            RecommendedModel = "claude-opus-4-8",
        };
        ApiEnum<string, Messages::BetaStopReason> expectedStopReason =
            Messages::BetaStopReason.EndTurn;
        JsonElement expectedType = JsonSerializer.SerializeToElement("message");
        Messages::BetaUsage expectedUsage = new()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            FallbackCredit = new(new Messages::Status(new Messages::BetaFallbackCreditRedeemed())),
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
                    Model = Model.ClaudeFable5_1,
                    OutputTokens = 0,
                },
            ],
            OutputTokens = 503,
            OutputTokensDetails = new(0),
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
            ServiceTier = Messages::BetaUsageServiceTier.Standard,
            Speed = Messages::BetaUsageSpeed.Standard,
        };
        List<Messages::BetaThinkingDroppedInputTransformation> expectedInputTransformations =
        [
            new()
            {
                Path = "path",
                Reason =
                    Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContainer, model.Container);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedContextManagement, model.ContextManagement);
        Assert.Equal(expectedDiagnostics, model.Diagnostics);
        Assert.Equal(expectedModel, model.Model);
        Assert.True(JsonElement.DeepEquals(expectedRole, model.Role));
        Assert.Equal(expectedStopDetails, model.StopDetails);
        Assert.Equal(expectedStopReason, model.StopReason);
        Assert.Null(model.StopSequence);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUsage, model.Usage);
        Assert.NotNull(model.InputTransformations);
        Assert.Equal(expectedInputTransformations.Count, model.InputTransformations.Count);
        for (int i = 0; i < expectedInputTransformations.Count; i++)
        {
            Assert.Equal(expectedInputTransformations[i], model.InputTransformations[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Messages::BetaMessage
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
            Model = Model.ClaudeOpus5,
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                FallbackCredit = new(
                    new Messages::Status(new Messages::BetaFallbackCreditRedeemed())
                ),
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
                        Model = Model.ClaudeFable5_1,
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
                new()
                {
                    Path = "path",
                    Reason =
                        Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaMessage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Messages::BetaMessage
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
            Model = Model.ClaudeOpus5,
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                FallbackCredit = new(
                    new Messages::Status(new Messages::BetaFallbackCreditRedeemed())
                ),
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
                        Model = Model.ClaudeFable5_1,
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
                new()
                {
                    Path = "path",
                    Reason =
                        Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaMessage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "msg_013Zva2CMHLNnXjNJJKqJ2EF";
        Messages::BetaContainer expectedContainer = new()
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
        };
        List<Messages::BetaContentBlock> expectedContent =
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
        ];
        Messages::BetaContextManagementResponse expectedContextManagement = new(
            [
                new Messages::BetaClearToolUses20250919EditResponse()
                {
                    ClearedInputTokens = 0,
                    ClearedToolUses = 0,
                },
            ]
        );
        Messages::BetaDiagnostics expectedDiagnostics = new(
            new Messages::CacheMissReason(new Messages::BetaCacheMissModelChanged(0))
        );
        ApiEnum<string, Model> expectedModel = Model.ClaudeOpus5;
        JsonElement expectedRole = JsonSerializer.SerializeToElement("assistant");
        Messages::BetaRefusalStopDetails expectedStopDetails = new()
        {
            Category = Messages::Category.Cyber,
            Explanation =
                "This request was declined because it conflicts with Anthropic's Usage Policy.",
            FallbackCreditToken = "QW50aHJvcGljL0NsYXVkZQ==",
            FallbackHasPrefillClaim = true,
            RecommendedModel = "claude-opus-4-8",
        };
        ApiEnum<string, Messages::BetaStopReason> expectedStopReason =
            Messages::BetaStopReason.EndTurn;
        JsonElement expectedType = JsonSerializer.SerializeToElement("message");
        Messages::BetaUsage expectedUsage = new()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            FallbackCredit = new(new Messages::Status(new Messages::BetaFallbackCreditRedeemed())),
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
                    Model = Model.ClaudeFable5_1,
                    OutputTokens = 0,
                },
            ],
            OutputTokens = 503,
            OutputTokensDetails = new(0),
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
            ServiceTier = Messages::BetaUsageServiceTier.Standard,
            Speed = Messages::BetaUsageSpeed.Standard,
        };
        List<Messages::BetaThinkingDroppedInputTransformation> expectedInputTransformations =
        [
            new()
            {
                Path = "path",
                Reason =
                    Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContainer, deserialized.Container);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedContextManagement, deserialized.ContextManagement);
        Assert.Equal(expectedDiagnostics, deserialized.Diagnostics);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.True(JsonElement.DeepEquals(expectedRole, deserialized.Role));
        Assert.Equal(expectedStopDetails, deserialized.StopDetails);
        Assert.Equal(expectedStopReason, deserialized.StopReason);
        Assert.Null(deserialized.StopSequence);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUsage, deserialized.Usage);
        Assert.NotNull(deserialized.InputTransformations);
        Assert.Equal(expectedInputTransformations.Count, deserialized.InputTransformations.Count);
        for (int i = 0; i < expectedInputTransformations.Count; i++)
        {
            Assert.Equal(expectedInputTransformations[i], deserialized.InputTransformations[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Messages::BetaMessage
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
            Model = Model.ClaudeOpus5,
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                FallbackCredit = new(
                    new Messages::Status(new Messages::BetaFallbackCreditRedeemed())
                ),
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
                        Model = Model.ClaudeFable5_1,
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
                new()
                {
                    Path = "path",
                    Reason =
                        Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Messages::BetaMessage
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
            Model = Model.ClaudeOpus5,
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                FallbackCredit = new(
                    new Messages::Status(new Messages::BetaFallbackCreditRedeemed())
                ),
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
                        Model = Model.ClaudeFable5_1,
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

        Assert.Null(model.InputTransformations);
        Assert.False(model.RawData.ContainsKey("input_transformations"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Messages::BetaMessage
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
            Model = Model.ClaudeOpus5,
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                FallbackCredit = new(
                    new Messages::Status(new Messages::BetaFallbackCreditRedeemed())
                ),
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
                        Model = Model.ClaudeFable5_1,
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Messages::BetaMessage
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
            Model = Model.ClaudeOpus5,
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                FallbackCredit = new(
                    new Messages::Status(new Messages::BetaFallbackCreditRedeemed())
                ),
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
                        Model = Model.ClaudeFable5_1,
                        OutputTokens = 0,
                    },
                ],
                OutputTokens = 503,
                OutputTokensDetails = new(0),
                ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                ServiceTier = Messages::BetaUsageServiceTier.Standard,
                Speed = Messages::BetaUsageSpeed.Standard,
            },

            InputTransformations = null,
        };

        Assert.Null(model.InputTransformations);
        Assert.True(model.RawData.ContainsKey("input_transformations"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Messages::BetaMessage
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
            Model = Model.ClaudeOpus5,
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                FallbackCredit = new(
                    new Messages::Status(new Messages::BetaFallbackCreditRedeemed())
                ),
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
                        Model = Model.ClaudeFable5_1,
                        OutputTokens = 0,
                    },
                ],
                OutputTokens = 503,
                OutputTokensDetails = new(0),
                ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                ServiceTier = Messages::BetaUsageServiceTier.Standard,
                Speed = Messages::BetaUsageSpeed.Standard,
            },

            InputTransformations = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Messages::BetaMessage
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
            Model = Model.ClaudeOpus5,
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                FallbackCredit = new(
                    new Messages::Status(new Messages::BetaFallbackCreditRedeemed())
                ),
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
                        Model = Model.ClaudeFable5_1,
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
                new()
                {
                    Path = "path",
                    Reason =
                        Messages::BetaThinkingDroppedInputTransformationReason.ModelBindingMismatch,
                },
            ],
        };

        Messages::BetaMessage copied = new(model);

        Assert.Equal(model, copied);
    }
}
