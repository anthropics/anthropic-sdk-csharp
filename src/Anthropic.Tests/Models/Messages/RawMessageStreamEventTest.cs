using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class RawMessageStreamEventTest : TestBase
{
    [Fact]
    public void StartValidationWorks()
    {
        RawMessageStreamEvent value = new RawMessageStartEvent(
            new Message()
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
                            Type = ContainerSkillType.Anthropic,
                            Version = "latest",
                        },
                    ],
                },
                Content =
                [
                    new TextBlock()
                    {
                        Citations =
                        [
                            new CitationCharLocation()
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
                Diagnostics = new(new CacheMissModelChanged(0)),
                Model = Model.ClaudeOpus5_5,
                StopDetails = new()
                {
                    Category = Category.Cyber,
                    Explanation =
                        "This request was declined because it conflicts with Anthropic's Usage Policy.",
                },
                StopReason = StopReason.EndTurn,
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
                    OutputTokens = 503,
                    OutputTokensDetails = new(0),
                    ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                    ServiceTier = UsageServiceTier.Standard,
                    Speed = UsageSpeed.Standard,
                },
            }
        );
        value.Validate();
    }

    [Fact]
    public void DeltaValidationWorks()
    {
        RawMessageStreamEvent value = new RawMessageDeltaEvent()
        {
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
                            Type = ContainerSkillType.Anthropic,
                            Version = "latest",
                        },
                    ],
                },
                StopDetails = new()
                {
                    Category = Category.Cyber,
                    Explanation =
                        "This request was declined because it conflicts with Anthropic's Usage Policy.",
                },
                StopReason = StopReason.EndTurn,
                StopSequence = "stop_sequence",
            },
            Usage = new()
            {
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InputTokens = 2095,
                OutputTokens = 503,
                OutputTokensDetails = new(0),
                ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
            },
        };
        value.Validate();
    }

    [Fact]
    public void StopValidationWorks()
    {
        RawMessageStreamEvent value = new RawMessageStopEvent();
        value.Validate();
    }

    [Fact]
    public void ContentBlockStartValidationWorks()
    {
        RawMessageStreamEvent value = new RawContentBlockStartEvent()
        {
            ContentBlock = new TextBlock()
            {
                Citations =
                [
                    new CitationCharLocation()
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
        RawMessageStreamEvent value = new RawContentBlockDeltaEvent()
        {
            Delta = new TextDelta("text"),
            Index = 0,
        };
        value.Validate();
    }

    [Fact]
    public void ContentBlockStopValidationWorks()
    {
        RawMessageStreamEvent value = new RawContentBlockStopEvent(0);
        value.Validate();
    }

    [Fact]
    public void StartSerializationRoundtripWorks()
    {
        RawMessageStreamEvent value = new RawMessageStartEvent(
            new Message()
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
                            Type = ContainerSkillType.Anthropic,
                            Version = "latest",
                        },
                    ],
                },
                Content =
                [
                    new TextBlock()
                    {
                        Citations =
                        [
                            new CitationCharLocation()
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
                Diagnostics = new(new CacheMissModelChanged(0)),
                Model = Model.ClaudeOpus5_5,
                StopDetails = new()
                {
                    Category = Category.Cyber,
                    Explanation =
                        "This request was declined because it conflicts with Anthropic's Usage Policy.",
                },
                StopReason = StopReason.EndTurn,
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
                    OutputTokens = 503,
                    OutputTokensDetails = new(0),
                    ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                    ServiceTier = UsageServiceTier.Standard,
                    Speed = UsageSpeed.Standard,
                },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DeltaSerializationRoundtripWorks()
    {
        RawMessageStreamEvent value = new RawMessageDeltaEvent()
        {
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
                            Type = ContainerSkillType.Anthropic,
                            Version = "latest",
                        },
                    ],
                },
                StopDetails = new()
                {
                    Category = Category.Cyber,
                    Explanation =
                        "This request was declined because it conflicts with Anthropic's Usage Policy.",
                },
                StopReason = StopReason.EndTurn,
                StopSequence = "stop_sequence",
            },
            Usage = new()
            {
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InputTokens = 2095,
                OutputTokens = 503,
                OutputTokensDetails = new(0),
                ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StopSerializationRoundtripWorks()
    {
        RawMessageStreamEvent value = new RawMessageStopEvent();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContentBlockStartSerializationRoundtripWorks()
    {
        RawMessageStreamEvent value = new RawContentBlockStartEvent()
        {
            ContentBlock = new TextBlock()
            {
                Citations =
                [
                    new CitationCharLocation()
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
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContentBlockDeltaSerializationRoundtripWorks()
    {
        RawMessageStreamEvent value = new RawContentBlockDeltaEvent()
        {
            Delta = new TextDelta("text"),
            Index = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ContentBlockStopSerializationRoundtripWorks()
    {
        RawMessageStreamEvent value = new RawContentBlockStopEvent(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawMessageStreamEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StartTypeWorks()
    {
        RawMessageStreamEvent value = new RawMessageStartEvent(
            new Message()
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
                            Type = ContainerSkillType.Anthropic,
                            Version = "latest",
                        },
                    ],
                },
                Content =
                [
                    new TextBlock()
                    {
                        Citations =
                        [
                            new CitationCharLocation()
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
                Diagnostics = new(new CacheMissModelChanged(0)),
                Model = Model.ClaudeOpus5_5,
                StopDetails = new()
                {
                    Category = Category.Cyber,
                    Explanation =
                        "This request was declined because it conflicts with Anthropic's Usage Policy.",
                },
                StopReason = StopReason.EndTurn,
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
                    OutputTokens = 503,
                    OutputTokensDetails = new(0),
                    ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                    ServiceTier = UsageServiceTier.Standard,
                    Speed = UsageSpeed.Standard,
                },
            }
        );
        Assert.Equal(RawMessageStreamEventType.MessageStart, value.Type.Value());
    }

    [Fact]
    public void DeltaTypeWorks()
    {
        RawMessageStreamEvent value = new RawMessageDeltaEvent()
        {
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
                            Type = ContainerSkillType.Anthropic,
                            Version = "latest",
                        },
                    ],
                },
                StopDetails = new()
                {
                    Category = Category.Cyber,
                    Explanation =
                        "This request was declined because it conflicts with Anthropic's Usage Policy.",
                },
                StopReason = StopReason.EndTurn,
                StopSequence = "stop_sequence",
            },
            Usage = new()
            {
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InputTokens = 2095,
                OutputTokens = 503,
                OutputTokensDetails = new(0),
                ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
            },
        };
        Assert.Equal(RawMessageStreamEventType.MessageDelta, value.Type.Value());
    }

    [Fact]
    public void StopTypeWorks()
    {
        RawMessageStreamEvent value = new RawMessageStopEvent();
        Assert.Equal(RawMessageStreamEventType.MessageStop, value.Type.Value());
    }

    [Fact]
    public void ContentBlockStartTypeWorks()
    {
        RawMessageStreamEvent value = new RawContentBlockStartEvent()
        {
            ContentBlock = new TextBlock()
            {
                Citations =
                [
                    new CitationCharLocation()
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
        Assert.Equal(RawMessageStreamEventType.ContentBlockStart, value.Type.Value());
    }

    [Fact]
    public void ContentBlockDeltaTypeWorks()
    {
        RawMessageStreamEvent value = new RawContentBlockDeltaEvent()
        {
            Delta = new TextDelta("text"),
            Index = 0,
        };
        Assert.Equal(RawMessageStreamEventType.ContentBlockDelta, value.Type.Value());
    }

    [Fact]
    public void ContentBlockStopTypeWorks()
    {
        RawMessageStreamEvent value = new RawContentBlockStopEvent(0);
        Assert.Equal(RawMessageStreamEventType.ContentBlockStop, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        RawMessageStreamEvent value = new(
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

        ApiEnum<string, RawMessageStreamEventType> expectedType =
            RawMessageStreamEventType.MessageStart;
        long expectedIndex = 0;

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedIndex, value.Index);

        RawMessageStreamEvent emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.Index);

        RawMessageStreamEvent mismatchedValue = new(
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

public class RawMessageStreamEventTypeTest : TestBase
{
    [Theory]
    [InlineData(RawMessageStreamEventType.MessageStart)]
    [InlineData(RawMessageStreamEventType.MessageDelta)]
    [InlineData(RawMessageStreamEventType.MessageStop)]
    [InlineData(RawMessageStreamEventType.ContentBlockStart)]
    [InlineData(RawMessageStreamEventType.ContentBlockDelta)]
    [InlineData(RawMessageStreamEventType.ContentBlockStop)]
    public void Validation_Works(RawMessageStreamEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RawMessageStreamEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RawMessageStreamEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RawMessageStreamEventType.MessageStart)]
    [InlineData(RawMessageStreamEventType.MessageDelta)]
    [InlineData(RawMessageStreamEventType.MessageStop)]
    [InlineData(RawMessageStreamEventType.ContentBlockStart)]
    [InlineData(RawMessageStreamEventType.ContentBlockDelta)]
    [InlineData(RawMessageStreamEventType.ContentBlockStop)]
    public void SerializationRoundtrip_Works(RawMessageStreamEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RawMessageStreamEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RawMessageStreamEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RawMessageStreamEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RawMessageStreamEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
