using System.Text.Json;
using Anthropic.Core;
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
                Content =
                [
                    new TextBlock()
                    {
                        Citations =
                        [
                            new CitationCharLocation()
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
                Model = Model.ClaudeOpus4_6,
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
                    InferenceGeo = "inference_geo",
                    InputTokens = 2095,
                    OutputTokens = 503,
                    ServerToolUse = new(0),
                    ServiceTier = UsageServiceTier.Standard,
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
                Content =
                [
                    new TextBlock()
                    {
                        Citations =
                        [
                            new CitationCharLocation()
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
                Model = Model.ClaudeOpus4_6,
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
                    InferenceGeo = "inference_geo",
                    InputTokens = 2095,
                    OutputTokens = 503,
                    ServerToolUse = new(0),
                    ServiceTier = UsageServiceTier.Standard,
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
}
