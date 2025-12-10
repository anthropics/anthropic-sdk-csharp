using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Request>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Request>(json);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedCustomID, deserialized.CustomID);
        Assert.Equal(expectedParams, deserialized.Params);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Params>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Params>(json);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedMaxTokens, deserialized.MaxTokens);
        Assert.Equal(expectedMessages.Count, deserialized.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], deserialized.Messages[i]);
        }
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedServiceTier, deserialized.ServiceTier);
        Assert.Equal(expectedStopSequences.Count, deserialized.StopSequences.Count);
        for (int i = 0; i < expectedStopSequences.Count; i++)
        {
            Assert.Equal(expectedStopSequences[i], deserialized.StopSequences[i]);
        }
        Assert.Equal(expectedStream, deserialized.Stream);
        Assert.Equal(expectedSystem, deserialized.System);
        Assert.Equal(expectedTemperature, deserialized.Temperature);
        Assert.Equal(expectedThinking, deserialized.Thinking);
        Assert.Equal(expectedToolChoice, deserialized.ToolChoice);
        Assert.Equal(expectedTools.Count, deserialized.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], deserialized.Tools[i]);
        }
        Assert.Equal(expectedTopK, deserialized.TopK);
        Assert.Equal(expectedTopP, deserialized.TopP);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_5_20251101,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ServiceTier);
        Assert.False(model.RawData.ContainsKey("service_tier"));
        Assert.Null(model.StopSequences);
        Assert.False(model.RawData.ContainsKey("stop_sequences"));
        Assert.Null(model.Stream);
        Assert.False(model.RawData.ContainsKey("stream"));
        Assert.Null(model.System);
        Assert.False(model.RawData.ContainsKey("system"));
        Assert.Null(model.Temperature);
        Assert.False(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.Thinking);
        Assert.False(model.RawData.ContainsKey("thinking"));
        Assert.Null(model.ToolChoice);
        Assert.False(model.RawData.ContainsKey("tool_choice"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.TopK);
        Assert.False(model.RawData.ContainsKey("top_k"));
        Assert.Null(model.TopP);
        Assert.False(model.RawData.ContainsKey("top_p"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_5_20251101,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_5_20251101,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            ServiceTier = null,
            StopSequences = null,
            Stream = null,
            System = null,
            Temperature = null,
            Thinking = null,
            ToolChoice = null,
            Tools = null,
            TopK = null,
            TopP = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ServiceTier);
        Assert.False(model.RawData.ContainsKey("service_tier"));
        Assert.Null(model.StopSequences);
        Assert.False(model.RawData.ContainsKey("stop_sequences"));
        Assert.Null(model.Stream);
        Assert.False(model.RawData.ContainsKey("stream"));
        Assert.Null(model.System);
        Assert.False(model.RawData.ContainsKey("system"));
        Assert.Null(model.Temperature);
        Assert.False(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.Thinking);
        Assert.False(model.RawData.ContainsKey("thinking"));
        Assert.Null(model.ToolChoice);
        Assert.False(model.RawData.ContainsKey("tool_choice"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.TopK);
        Assert.False(model.RawData.ContainsKey("top_k"));
        Assert.Null(model.TopP);
        Assert.False(model.RawData.ContainsKey("top_p"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Params
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_5_20251101,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            ServiceTier = null,
            StopSequences = null,
            Stream = null,
            System = null,
            Temperature = null,
            Thinking = null,
            ToolChoice = null,
            Tools = null,
            TopK = null,
            TopP = null,
        };

        model.Validate();
    }
}

public class ServiceTierTest : TestBase
{
    [Theory]
    [InlineData(ServiceTier.Auto)]
    [InlineData(ServiceTier.StandardOnly)]
    public void Validation_Works(ServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServiceTier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ServiceTier.Auto)]
    [InlineData(ServiceTier.StandardOnly)]
    public void SerializationRoundtrip_Works(ServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServiceTier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
