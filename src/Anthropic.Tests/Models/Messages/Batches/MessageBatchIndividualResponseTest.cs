using System.Text.Json;
using Anthropic.Models.Messages;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Tests.Models.Messages.Batches;

public class MessageBatchIndividualResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageBatchIndividualResponse
        {
            CustomID = "my-custom-id-1",
            Result = new MessageBatchSucceededResult(
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
            ),
        };

        string expectedCustomID = "my-custom-id-1";
        MessageBatchResult expectedResult = new MessageBatchSucceededResult(
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
        );

        Assert.Equal(expectedCustomID, model.CustomID);
        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageBatchIndividualResponse
        {
            CustomID = "my-custom-id-1",
            Result = new MessageBatchSucceededResult(
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
            ),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MessageBatchIndividualResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageBatchIndividualResponse
        {
            CustomID = "my-custom-id-1",
            Result = new MessageBatchSucceededResult(
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
            ),
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MessageBatchIndividualResponse>(element);
        Assert.NotNull(deserialized);

        string expectedCustomID = "my-custom-id-1";
        MessageBatchResult expectedResult = new MessageBatchSucceededResult(
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
        );

        Assert.Equal(expectedCustomID, deserialized.CustomID);
        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageBatchIndividualResponse
        {
            CustomID = "my-custom-id-1",
            Result = new MessageBatchSucceededResult(
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
            ),
        };

        model.Validate();
    }
}
