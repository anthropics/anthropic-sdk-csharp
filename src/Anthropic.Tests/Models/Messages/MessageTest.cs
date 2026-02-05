using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class MessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Message
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InferenceGeo = "inference_geo",
                InputTokens = 2095,
                OutputTokens = 503,
                ServerToolUse = new(0),
                ServiceTier = UsageServiceTier.Standard,
            },
        };

        string expectedID = "msg_013Zva2CMHLNnXjNJJKqJ2EF";
        List<ContentBlock> expectedContent =
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
        ];
        ApiEnum<string, Model> expectedModel = Model.ClaudeOpus4_6;
        JsonElement expectedRole = JsonSerializer.SerializeToElement("assistant");
        ApiEnum<string, StopReason> expectedStopReason = StopReason.EndTurn;
        JsonElement expectedType = JsonSerializer.SerializeToElement("message");
        Usage expectedUsage = new()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InferenceGeo = "inference_geo",
            InputTokens = 2095,
            OutputTokens = 503,
            ServerToolUse = new(0),
            ServiceTier = UsageServiceTier.Standard,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
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
        var model = new Message
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InferenceGeo = "inference_geo",
                InputTokens = 2095,
                OutputTokens = 503,
                ServerToolUse = new(0),
                ServiceTier = UsageServiceTier.Standard,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Message>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Message
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InferenceGeo = "inference_geo",
                InputTokens = 2095,
                OutputTokens = 503,
                ServerToolUse = new(0),
                ServiceTier = UsageServiceTier.Standard,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Message>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "msg_013Zva2CMHLNnXjNJJKqJ2EF";
        List<ContentBlock> expectedContent =
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
        ];
        ApiEnum<string, Model> expectedModel = Model.ClaudeOpus4_6;
        JsonElement expectedRole = JsonSerializer.SerializeToElement("assistant");
        ApiEnum<string, StopReason> expectedStopReason = StopReason.EndTurn;
        JsonElement expectedType = JsonSerializer.SerializeToElement("message");
        Usage expectedUsage = new()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InferenceGeo = "inference_geo",
            InputTokens = 2095,
            OutputTokens = 503,
            ServerToolUse = new(0),
            ServiceTier = UsageServiceTier.Standard,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
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
        var model = new Message
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InferenceGeo = "inference_geo",
                InputTokens = 2095,
                OutputTokens = 503,
                ServerToolUse = new(0),
                ServiceTier = UsageServiceTier.Standard,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Message
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
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
                InferenceGeo = "inference_geo",
                InputTokens = 2095,
                OutputTokens = 503,
                ServerToolUse = new(0),
                ServiceTier = UsageServiceTier.Standard,
            },
        };

        Message copied = new(model);

        Assert.Equal(model, copied);
    }
}
