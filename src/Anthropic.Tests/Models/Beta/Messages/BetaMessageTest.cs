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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InputTokens = 2095,
                OutputTokens = 503,
                ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                ServiceTier = Messages::BetaUsageServiceTier.Standard,
            },
        };

        string expectedID = "msg_013Zva2CMHLNnXjNJJKqJ2EF";
        Messages::BetaContainer expectedContainer = new()
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
        };
        List<Messages::BetaContentBlock> expectedContent =
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
        ApiEnum<string, Model> expectedModel = Model.ClaudeSonnet4_5_20250929;
        JsonElement expectedRole = JsonSerializer.SerializeToElement("assistant");
        ApiEnum<string, Messages::BetaStopReason> expectedStopReason =
            Messages::BetaStopReason.EndTurn;
        JsonElement expectedType = JsonSerializer.SerializeToElement("message");
        Messages::BetaUsage expectedUsage = new()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InputTokens = 2095,
            OutputTokens = 503,
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
            ServiceTier = Messages::BetaUsageServiceTier.Standard,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContainer, model.Container);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedContextManagement, model.ContextManagement);
        Assert.Equal(expectedModel, model.Model);
        Assert.True(JsonElement.DeepEquals(expectedRole, model.Role));
        Assert.Equal(expectedStopReason, model.StopReason);
        Assert.Null(model.StopSequence);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Messages::BetaMessage
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InputTokens = 2095,
                OutputTokens = 503,
                ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                ServiceTier = Messages::BetaUsageServiceTier.Standard,
            },
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InputTokens = 2095,
                OutputTokens = 503,
                ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                ServiceTier = Messages::BetaUsageServiceTier.Standard,
            },
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
        };
        List<Messages::BetaContentBlock> expectedContent =
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
        ApiEnum<string, Model> expectedModel = Model.ClaudeSonnet4_5_20250929;
        JsonElement expectedRole = JsonSerializer.SerializeToElement("assistant");
        ApiEnum<string, Messages::BetaStopReason> expectedStopReason =
            Messages::BetaStopReason.EndTurn;
        JsonElement expectedType = JsonSerializer.SerializeToElement("message");
        Messages::BetaUsage expectedUsage = new()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InputTokens = 2095,
            OutputTokens = 503,
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
            ServiceTier = Messages::BetaUsageServiceTier.Standard,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContainer, deserialized.Container);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedContextManagement, deserialized.ContextManagement);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.True(JsonElement.DeepEquals(expectedRole, deserialized.Role));
        Assert.Equal(expectedStopReason, deserialized.StopReason);
        Assert.Null(deserialized.StopSequence);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Messages::BetaMessage
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InputTokens = 2095,
                OutputTokens = 503,
                ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                ServiceTier = Messages::BetaUsageServiceTier.Standard,
            },
        };

        model.Validate();
    }
}
