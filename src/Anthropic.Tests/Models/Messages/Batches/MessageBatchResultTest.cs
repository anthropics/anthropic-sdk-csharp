using System.Text.Json;
using Anthropic.Models;
using Anthropic.Models.Messages;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Tests.Models.Messages.Batches;

public class MessageBatchResultTest : TestBase
{
    [Fact]
    public void succeededValidation_Works()
    {
        MessageBatchResult value = new(
            new MessageBatchSucceededResult(
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
                    Model = Model.ClaudeOpus4_5_20251101,
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
                        InputTokens = 2095,
                        OutputTokens = 503,
                        ServerToolUse = new(0),
                        ServiceTier = UsageServiceTier.Standard,
                    },
                }
            )
        );
        value.Validate();
    }

    [Fact]
    public void erroredValidation_Works()
    {
        MessageBatchResult value = new(
            new MessageBatchErroredResult(
                new ErrorResponse()
                {
                    Error = new InvalidRequestError("message"),
                    RequestID = "request_id",
                }
            )
        );
        value.Validate();
    }

    [Fact]
    public void canceledValidation_Works()
    {
        MessageBatchResult value = new(new MessageBatchCanceledResult());
        value.Validate();
    }

    [Fact]
    public void expiredValidation_Works()
    {
        MessageBatchResult value = new(new MessageBatchExpiredResult());
        value.Validate();
    }

    [Fact]
    public void succeededSerializationRoundtrip_Works()
    {
        MessageBatchResult value = new(
            new MessageBatchSucceededResult(
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
                    Model = Model.ClaudeOpus4_5_20251101,
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
                        InputTokens = 2095,
                        OutputTokens = 503,
                        ServerToolUse = new(0),
                        ServiceTier = UsageServiceTier.Standard,
                    },
                }
            )
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageBatchResult>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void erroredSerializationRoundtrip_Works()
    {
        MessageBatchResult value = new(
            new MessageBatchErroredResult(
                new ErrorResponse()
                {
                    Error = new InvalidRequestError("message"),
                    RequestID = "request_id",
                }
            )
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageBatchResult>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void canceledSerializationRoundtrip_Works()
    {
        MessageBatchResult value = new(new MessageBatchCanceledResult());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageBatchResult>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void expiredSerializationRoundtrip_Works()
    {
        MessageBatchResult value = new(new MessageBatchExpiredResult());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageBatchResult>(json);

        Assert.Equal(value, deserialized);
    }
}
