using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Compliance.Review.Items;
using Anthropic.Models.Messages;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Items;

public class BetaComplianceReviewMessageContentTest : TestBase
{
    [Fact]
    public void CreateValidationWorks()
    {
        BetaComplianceReviewMessageContent value = new BetaComplianceReviewCreateMessageContent()
        {
            Request = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Response = new()
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
            },
        };
        value.Validate();
    }

    [Fact]
    public void CreateSerializationRoundtripWorks()
    {
        BetaComplianceReviewMessageContent value = new BetaComplianceReviewCreateMessageContent()
        {
            Request = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Response = new()
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
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewMessageContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreateTypeWorks()
    {
        BetaComplianceReviewMessageContent value = new BetaComplianceReviewCreateMessageContent()
        {
            Request = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Response = new()
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
            },
        };
        Assert.Equal(BetaComplianceReviewMessageContentType.CreateMessage, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaComplianceReviewMessageContent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "create_message"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaComplianceReviewMessageContentType> expectedType =
            BetaComplianceReviewMessageContentType.CreateMessage;

        Assert.Equal(expectedType, value.Type);

        BetaComplianceReviewMessageContent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaComplianceReviewMessageContentTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaComplianceReviewMessageContentType.CreateMessage)]
    public void Validation_Works(BetaComplianceReviewMessageContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewMessageContentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewMessageContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaComplianceReviewMessageContentType.CreateMessage, 496944901, "create_message")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaComplianceReviewMessageContentType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComplianceReviewMessageContentType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewMessageContentType>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewMessageContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComplianceReviewMessageContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
