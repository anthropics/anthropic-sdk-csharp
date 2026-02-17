using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class RawMessageStartEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RawMessageStartEvent
        {
            Message = new()
            {
                ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                Container = new()
                {
                    ID = "id",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
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
                    ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                    ServiceTier = UsageServiceTier.Standard,
                },
            },
        };

        Message expectedMessage = new()
        {
            ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
            Container = new()
            {
                ID = "id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InferenceGeo = "inference_geo",
                InputTokens = 2095,
                OutputTokens = 503,
                ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                ServiceTier = UsageServiceTier.Standard,
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("message_start");

        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RawMessageStartEvent
        {
            Message = new()
            {
                ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                Container = new()
                {
                    ID = "id",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
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
                    ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                    ServiceTier = UsageServiceTier.Standard,
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawMessageStartEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RawMessageStartEvent
        {
            Message = new()
            {
                ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                Container = new()
                {
                    ID = "id",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
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
                    ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                    ServiceTier = UsageServiceTier.Standard,
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawMessageStartEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Message expectedMessage = new()
        {
            ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
            Container = new()
            {
                ID = "id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InferenceGeo = "inference_geo",
                InputTokens = 2095,
                OutputTokens = 503,
                ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                ServiceTier = UsageServiceTier.Standard,
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("message_start");

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RawMessageStartEvent
        {
            Message = new()
            {
                ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                Container = new()
                {
                    ID = "id",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
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
                    ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                    ServiceTier = UsageServiceTier.Standard,
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RawMessageStartEvent
        {
            Message = new()
            {
                ID = "msg_013Zva2CMHLNnXjNJJKqJ2EF",
                Container = new()
                {
                    ID = "id",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
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
                    ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
                    ServiceTier = UsageServiceTier.Standard,
                },
            },
        };

        RawMessageStartEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
