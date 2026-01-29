using System;
using System.Text.Json;
using Anthropic.Core;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRawMessageDeltaEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Messages::BetaRawMessageDeltaEvent
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
        };

        Messages::BetaContextManagementResponse expectedContextManagement = new(
            [
                new Messages::BetaClearToolUses20250919EditResponse()
                {
                    ClearedInputTokens = 0,
                    ClearedToolUses = 0,
                },
            ]
        );
        Messages::Delta expectedDelta = new()
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
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("message_delta");
        Messages::BetaMessageDeltaUsage expectedUsage = new()
        {
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InputTokens = 2095,
            OutputTokens = 503,
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
        };

        Assert.Equal(expectedContextManagement, model.ContextManagement);
        Assert.Equal(expectedDelta, model.Delta);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Messages::BetaRawMessageDeltaEvent
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageDeltaEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Messages::BetaRawMessageDeltaEvent
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Messages::BetaRawMessageDeltaEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Messages::BetaContextManagementResponse expectedContextManagement = new(
            [
                new Messages::BetaClearToolUses20250919EditResponse()
                {
                    ClearedInputTokens = 0,
                    ClearedToolUses = 0,
                },
            ]
        );
        Messages::Delta expectedDelta = new()
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
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("message_delta");
        Messages::BetaMessageDeltaUsage expectedUsage = new()
        {
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InputTokens = 2095,
            OutputTokens = 503,
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
        };

        Assert.Equal(expectedContextManagement, deserialized.ContextManagement);
        Assert.Equal(expectedDelta, deserialized.Delta);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Messages::BetaRawMessageDeltaEvent
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Messages::BetaRawMessageDeltaEvent
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
        };

        Messages::BetaRawMessageDeltaEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Messages::Delta
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
        };

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
        ApiEnum<string, Messages::BetaStopReason> expectedStopReason =
            Messages::BetaStopReason.EndTurn;
        string expectedStopSequence = "stop_sequence";

        Assert.Equal(expectedContainer, model.Container);
        Assert.Equal(expectedStopReason, model.StopReason);
        Assert.Equal(expectedStopSequence, model.StopSequence);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Messages::Delta
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Messages::Delta>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Messages::Delta
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Messages::Delta>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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
        ApiEnum<string, Messages::BetaStopReason> expectedStopReason =
            Messages::BetaStopReason.EndTurn;
        string expectedStopSequence = "stop_sequence";

        Assert.Equal(expectedContainer, deserialized.Container);
        Assert.Equal(expectedStopReason, deserialized.StopReason);
        Assert.Equal(expectedStopSequence, deserialized.StopSequence);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Messages::Delta
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Messages::Delta
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
        };

        Messages::Delta copied = new(model);

        Assert.Equal(model, copied);
    }
}
