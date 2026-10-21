using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models;
using Anthropic.Models.Messages;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Tests.Models.Messages.Batches;

public class MessageBatchResultTest : TestBase
{
    [Fact]
    public void SucceededValidationWorks()
    {
        MessageBatchResult value = new MessageBatchSucceededResult(
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
    public void ErroredValidationWorks()
    {
        MessageBatchResult value = new MessageBatchErroredResult(
            new ErrorResponse()
            {
                Error = new InvalidRequestError("message"),
                RequestID = "request_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void CanceledValidationWorks()
    {
        MessageBatchResult value = new MessageBatchCanceledResult();
        value.Validate();
    }

    [Fact]
    public void ExpiredValidationWorks()
    {
        MessageBatchResult value = new MessageBatchExpiredResult();
        value.Validate();
    }

    [Fact]
    public void SucceededSerializationRoundtripWorks()
    {
        MessageBatchResult value = new MessageBatchSucceededResult(
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
        var deserialized = JsonSerializer.Deserialize<MessageBatchResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ErroredSerializationRoundtripWorks()
    {
        MessageBatchResult value = new MessageBatchErroredResult(
            new ErrorResponse()
            {
                Error = new InvalidRequestError("message"),
                RequestID = "request_id",
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageBatchResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CanceledSerializationRoundtripWorks()
    {
        MessageBatchResult value = new MessageBatchCanceledResult();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageBatchResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExpiredSerializationRoundtripWorks()
    {
        MessageBatchResult value = new MessageBatchExpiredResult();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageBatchResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SucceededTypeWorks()
    {
        MessageBatchResult value = new MessageBatchSucceededResult(
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
        Assert.Equal(MessageBatchResultType.Succeeded, value.Type.Value());
    }

    [Fact]
    public void ErroredTypeWorks()
    {
        MessageBatchResult value = new MessageBatchErroredResult(
            new ErrorResponse()
            {
                Error = new InvalidRequestError("message"),
                RequestID = "request_id",
            }
        );
        Assert.Equal(MessageBatchResultType.Errored, value.Type.Value());
    }

    [Fact]
    public void CanceledTypeWorks()
    {
        MessageBatchResult value = new MessageBatchCanceledResult();
        Assert.Equal(MessageBatchResultType.Canceled, value.Type.Value());
    }

    [Fact]
    public void ExpiredTypeWorks()
    {
        MessageBatchResult value = new MessageBatchExpiredResult();
        Assert.Equal(MessageBatchResultType.Expired, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        MessageBatchResult value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "succeeded"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, MessageBatchResultType> expectedType = MessageBatchResultType.Succeeded;

        Assert.Equal(expectedType, value.Type);

        MessageBatchResult emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class MessageBatchResultTypeTest : TestBase
{
    [Theory]
    [InlineData(MessageBatchResultType.Succeeded)]
    [InlineData(MessageBatchResultType.Errored)]
    [InlineData(MessageBatchResultType.Canceled)]
    [InlineData(MessageBatchResultType.Expired)]
    public void Validation_Works(MessageBatchResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageBatchResultType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessageBatchResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MessageBatchResultType.Succeeded)]
    [InlineData(MessageBatchResultType.Errored)]
    [InlineData(MessageBatchResultType.Canceled)]
    [InlineData(MessageBatchResultType.Expired)]
    public void SerializationRoundtrip_Works(MessageBatchResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageBatchResultType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessageBatchResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessageBatchResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessageBatchResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
