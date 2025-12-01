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
            Model = Model.ClaudeOpus4_5_20251101,
            Role = JsonSerializer.Deserialize<JsonElement>("\"assistant\""),
            StopReason = StopReason.EndTurn,
            StopSequence = null,
            Type = JsonSerializer.Deserialize<JsonElement>("\"message\""),
            Usage = new()
            {
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 2051,
                CacheReadInputTokens = 2051,
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
        ApiEnum<string, Model> expectedModel = Model.ClaudeOpus4_5_20251101;
        JsonElement expectedRole = JsonSerializer.Deserialize<JsonElement>("\"assistant\"");
        ApiEnum<string, StopReason> expectedStopReason = StopReason.EndTurn;
        string expectedStopSequence = null;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"message\"");
        Usage expectedUsage = new()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
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
        Assert.Equal(expectedStopSequence, model.StopSequence);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUsage, model.Usage);
    }
}
