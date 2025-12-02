using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages.Batches;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages.Batches;

public class RequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Request
        {
            CustomID = "my-custom-id-1",
            Params = new()
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
                Model = Messages::Model.ClaudeOpus4_5_20251101,
                Metadata = new() { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" },
                ServiceTier = ServiceTier.Auto,
                StopSequences = ["string"],
                Stream = true,
                System = new(
                    [
                        new()
                        {
                            Text = "Today's date is 2024-06-01.",
                            CacheControl = new() { TTL = Messages::TTL.TTL5m },
                            Citations =
                            [
                                new Messages::CitationCharLocationParam()
                                {
                                    CitedText = "cited_text",
                                    DocumentIndex = 0,
                                    DocumentTitle = "x",
                                    EndCharIndex = 0,
                                    StartCharIndex = 0,
                                },
                            ],
                        },
                    ]
                ),
                Temperature = 1,
                Thinking = new Messages::ThinkingConfigEnabled(1024),
                ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
                Tools =
                [
                    new Messages::Tool()
                    {
                        InputSchema = new()
                        {
                            Properties = new Dictionary<string, JsonElement>()
                            {
                                { "location", JsonSerializer.SerializeToElement("bar") },
                                { "unit", JsonSerializer.SerializeToElement("bar") },
                            },
                            Required = ["location"],
                        },
                        Name = "name",
                        CacheControl = new() { TTL = Messages::TTL.TTL5m },
                        Description = "Get the current weather in a given location",
                        Type = Messages::Type.Custom,
                    },
                ],
                TopK = 5,
                TopP = 0.7,
            },
        };

        string expectedCustomID = "my-custom-id-1";
        Params expectedParams = new()
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_5_20251101,
            Metadata = new() { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" },
            ServiceTier = ServiceTier.Auto,
            StopSequences = ["string"],
            Stream = true,
            System = new(
                [
                    new()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { TTL = Messages::TTL.TTL5m },
                        Citations =
                        [
                            new Messages::CitationCharLocationParam()
                            {
                                CitedText = "cited_text",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ]
            ),
            Temperature = 1,
            Thinking = new Messages::ThinkingConfigEnabled(1024),
            ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::Tool()
                {
                    InputSchema = new()
                    {
                        Properties = new Dictionary<string, JsonElement>()
                        {
                            { "location", JsonSerializer.SerializeToElement("bar") },
                            { "unit", JsonSerializer.SerializeToElement("bar") },
                        },
                        Required = ["location"],
                    },
                    Name = "name",
                    CacheControl = new() { TTL = Messages::TTL.TTL5m },
                    Description = "Get the current weather in a given location",
                    Type = Messages::Type.Custom,
                },
            ],
            TopK = 5,
            TopP = 0.7,
        };

        Assert.Equal(expectedCustomID, model.CustomID);
        Assert.Equal(expectedParams, model.Params);
    }
}

public class ParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_5_20251101,
            Metadata = new() { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" },
            ServiceTier = ServiceTier.Auto,
            StopSequences = ["string"],
            Stream = true,
            System = new(
                [
                    new()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { TTL = Messages::TTL.TTL5m },
                        Citations =
                        [
                            new Messages::CitationCharLocationParam()
                            {
                                CitedText = "cited_text",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ]
            ),
            Temperature = 1,
            Thinking = new Messages::ThinkingConfigEnabled(1024),
            ToolChoice = new Messages::ToolChoiceAuto() { DisableParallelToolUse = true },
            Tools =
            [
                new Messages::Tool()
                {
                    InputSchema = new()
                    {
                        Properties = new Dictionary<string, JsonElement>()
                        {
                            { "location", JsonSerializer.SerializeToElement("bar") },
                            { "unit", JsonSerializer.SerializeToElement("bar") },
                        },
                        Required = ["location"],
                    },
                    Name = "name",
                    CacheControl = new() { TTL = Messages::TTL.TTL5m },
                    Description = "Get the current weather in a given location",
                    Type = Messages::Type.Custom,
                },
            ],
            TopK = 5,
            TopP = 0.7,
        };

        long expectedMaxTokens = 1024;
        List<Messages::MessageParam> expectedMessages =
        [
            new() { Content = "Hello, world", Role = Messages::Role.User },
        ];
        ApiEnum<string, Messages::Model> expectedModel = Messages::Model.ClaudeOpus4_5_20251101;
        Messages::Metadata expectedMetadata = new()
        {
            UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b",
        };
        ApiEnum<string, ServiceTier> expectedServiceTier = ServiceTier.Auto;
        List<string> expectedStopSequences = ["string"];
        bool expectedStream = true;
        ParamsSystem expectedSystem = new(
            [
                new()
                {
                    Text = "Today's date is 2024-06-01.",
                    CacheControl = new() { TTL = Messages::TTL.TTL5m },
                    Citations =
                    [
                        new Messages::CitationCharLocationParam()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ]
        );
        double expectedTemperature = 1;
        Messages::ThinkingConfigParam expectedThinking = new Messages::ThinkingConfigEnabled(1024);
        Messages::ToolChoice expectedToolChoice = new Messages::ToolChoiceAuto()
        {
            DisableParallelToolUse = true,
        };
        List<Messages::ToolUnion> expectedTools =
        [
            new Messages::Tool()
            {
                InputSchema = new()
                {
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "location", JsonSerializer.SerializeToElement("bar") },
                        { "unit", JsonSerializer.SerializeToElement("bar") },
                    },
                    Required = ["location"],
                },
                Name = "name",
                CacheControl = new() { TTL = Messages::TTL.TTL5m },
                Description = "Get the current weather in a given location",
                Type = Messages::Type.Custom,
            },
        ];
        long expectedTopK = 5;
        double expectedTopP = 0.7;

        Assert.Equal(expectedMaxTokens, model.MaxTokens);
        Assert.Equal(expectedMessages.Count, model.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], model.Messages[i]);
        }
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedServiceTier, model.ServiceTier);
        Assert.Equal(expectedStopSequences.Count, model.StopSequences.Count);
        for (int i = 0; i < expectedStopSequences.Count; i++)
        {
            Assert.Equal(expectedStopSequences[i], model.StopSequences[i]);
        }
        Assert.Equal(expectedStream, model.Stream);
        Assert.Equal(expectedSystem, model.System);
        Assert.Equal(expectedTemperature, model.Temperature);
        Assert.Equal(expectedThinking, model.Thinking);
        Assert.Equal(expectedToolChoice, model.ToolChoice);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
        Assert.Equal(expectedTopK, model.TopK);
        Assert.Equal(expectedTopP, model.TopP);
    }
}
