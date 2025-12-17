using System.Text.Json;
using Anthropic.Models;
using Anthropic.Models.Messages;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Tests.Models.Messages.Batches;

public class MessageBatchResultTest : TestBase
{
    [Fact]
    public void SucceededValidationWorks()
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
    public void ErroredValidationWorks()
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
    public void CanceledValidationWorks()
    {
        MessageBatchResult value = new(new MessageBatchCanceledResult());
        value.Validate();
    }

    [Fact]
    public void ExpiredValidationWorks()
    {
        MessageBatchResult value = new(new MessageBatchExpiredResult());
        value.Validate();
    }

    [Fact]
    public void SucceededSerializationRoundtripWorks()
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
    public void ErroredSerializationRoundtripWorks()
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
    public void CanceledSerializationRoundtripWorks()
    {
        MessageBatchResult value = new(new MessageBatchCanceledResult());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageBatchResult>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExpiredSerializationRoundtripWorks()
    {
        MessageBatchResult value = new(new MessageBatchExpiredResult());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageBatchResult>(json);

        Assert.Equal(value, deserialized);
    }
}
