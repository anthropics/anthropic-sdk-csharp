using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class MessageCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Messages::MessageCreateParams
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
            Container = "container",
            InferenceGeo = "inference_geo",
            Metadata = new() { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" },
            OutputConfig = new()
            {
                Effort = Messages::Effort.Low,
                Format = new()
                {
                    Schema = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
            },
            ServiceTier = Messages::ServiceTier.Auto,
            Speed = Messages::Speed.Standard,
            StopSequences = ["string"],
            System = new(
                [
                    new Messages::TextBlockParam()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                    AllowedCallers = [Messages::ToolAllowedCaller.Direct],
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                    DeferLoading = true,
                    Description = "Get the current weather in a given location",
                    EagerInputStreaming = true,
                    InputExamples =
                    [
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    ],
                    Strict = true,
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
        ApiEnum<string, Messages::Model> expectedModel = Messages::Model.ClaudeOpus4_6;
        string expectedContainer = "container";
        string expectedInferenceGeo = "inference_geo";
        Messages::Metadata expectedMetadata = new()
        {
            UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b",
        };
        Messages::OutputConfig expectedOutputConfig = new()
        {
            Effort = Messages::Effort.Low,
            Format = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };
        ApiEnum<string, Messages::ServiceTier> expectedServiceTier = Messages::ServiceTier.Auto;
        ApiEnum<string, Messages::Speed> expectedSpeed = Messages::Speed.Standard;
        List<string> expectedStopSequences = ["string"];
        Messages::MessageCreateParamsSystem expectedSystem = new(
            [
                new Messages::TextBlockParam()
                {
                    Text = "Today's date is 2024-06-01.",
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                AllowedCallers = [Messages::ToolAllowedCaller.Direct],
                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                DeferLoading = true,
                Description = "Get the current weather in a given location",
                EagerInputStreaming = true,
                InputExamples =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Strict = true,
                Type = Messages::Type.Custom,
            },
        ];
        long expectedTopK = 5;
        double expectedTopP = 0.7;

        Assert.Equal(expectedMaxTokens, parameters.MaxTokens);
        Assert.Equal(expectedMessages.Count, parameters.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], parameters.Messages[i]);
        }
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedContainer, parameters.Container);
        Assert.Equal(expectedInferenceGeo, parameters.InferenceGeo);
        Assert.Equal(expectedMetadata, parameters.Metadata);
        Assert.Equal(expectedOutputConfig, parameters.OutputConfig);
        Assert.Equal(expectedServiceTier, parameters.ServiceTier);
        Assert.Equal(expectedSpeed, parameters.Speed);
        Assert.NotNull(parameters.StopSequences);
        Assert.Equal(expectedStopSequences.Count, parameters.StopSequences.Count);
        for (int i = 0; i < expectedStopSequences.Count; i++)
        {
            Assert.Equal(expectedStopSequences[i], parameters.StopSequences[i]);
        }
        Assert.Equal(expectedSystem, parameters.System);
        Assert.Equal(expectedTemperature, parameters.Temperature);
        Assert.Equal(expectedThinking, parameters.Thinking);
        Assert.Equal(expectedToolChoice, parameters.ToolChoice);
        Assert.NotNull(parameters.Tools);
        Assert.Equal(expectedTools.Count, parameters.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], parameters.Tools[i]);
        }
        Assert.Equal(expectedTopK, parameters.TopK);
        Assert.Equal(expectedTopP, parameters.TopP);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Messages::MessageCreateParams
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
            Container = "container",
            InferenceGeo = "inference_geo",
            Speed = Messages::Speed.Standard,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.OutputConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("output_config"));
        Assert.Null(parameters.ServiceTier);
        Assert.False(parameters.RawBodyData.ContainsKey("service_tier"));
        Assert.Null(parameters.StopSequences);
        Assert.False(parameters.RawBodyData.ContainsKey("stop_sequences"));
        Assert.Null(parameters.System);
        Assert.False(parameters.RawBodyData.ContainsKey("system"));
        Assert.Null(parameters.Temperature);
        Assert.False(parameters.RawBodyData.ContainsKey("temperature"));
        Assert.Null(parameters.Thinking);
        Assert.False(parameters.RawBodyData.ContainsKey("thinking"));
        Assert.Null(parameters.ToolChoice);
        Assert.False(parameters.RawBodyData.ContainsKey("tool_choice"));
        Assert.Null(parameters.Tools);
        Assert.False(parameters.RawBodyData.ContainsKey("tools"));
        Assert.Null(parameters.TopK);
        Assert.False(parameters.RawBodyData.ContainsKey("top_k"));
        Assert.Null(parameters.TopP);
        Assert.False(parameters.RawBodyData.ContainsKey("top_p"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Messages::MessageCreateParams
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
            Container = "container",
            InferenceGeo = "inference_geo",
            Speed = Messages::Speed.Standard,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            OutputConfig = null,
            ServiceTier = null,
            StopSequences = null,
            System = null,
            Temperature = null,
            Thinking = null,
            ToolChoice = null,
            Tools = null,
            TopK = null,
            TopP = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.OutputConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("output_config"));
        Assert.Null(parameters.ServiceTier);
        Assert.False(parameters.RawBodyData.ContainsKey("service_tier"));
        Assert.Null(parameters.StopSequences);
        Assert.False(parameters.RawBodyData.ContainsKey("stop_sequences"));
        Assert.Null(parameters.System);
        Assert.False(parameters.RawBodyData.ContainsKey("system"));
        Assert.Null(parameters.Temperature);
        Assert.False(parameters.RawBodyData.ContainsKey("temperature"));
        Assert.Null(parameters.Thinking);
        Assert.False(parameters.RawBodyData.ContainsKey("thinking"));
        Assert.Null(parameters.ToolChoice);
        Assert.False(parameters.RawBodyData.ContainsKey("tool_choice"));
        Assert.Null(parameters.Tools);
        Assert.False(parameters.RawBodyData.ContainsKey("tools"));
        Assert.Null(parameters.TopK);
        Assert.False(parameters.RawBodyData.ContainsKey("top_k"));
        Assert.Null(parameters.TopP);
        Assert.False(parameters.RawBodyData.ContainsKey("top_p"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Messages::MessageCreateParams
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
            Metadata = new() { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" },
            OutputConfig = new()
            {
                Effort = Messages::Effort.Low,
                Format = new()
                {
                    Schema = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
            },
            ServiceTier = Messages::ServiceTier.Auto,
            StopSequences = ["string"],
            System = new(
                [
                    new Messages::TextBlockParam()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                    AllowedCallers = [Messages::ToolAllowedCaller.Direct],
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                    DeferLoading = true,
                    Description = "Get the current weather in a given location",
                    EagerInputStreaming = true,
                    InputExamples =
                    [
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    ],
                    Strict = true,
                    Type = Messages::Type.Custom,
                },
            ],
            TopK = 5,
            TopP = 0.7,
        };

        Assert.Null(parameters.Container);
        Assert.False(parameters.RawBodyData.ContainsKey("container"));
        Assert.Null(parameters.InferenceGeo);
        Assert.False(parameters.RawBodyData.ContainsKey("inference_geo"));
        Assert.Null(parameters.Speed);
        Assert.False(parameters.RawBodyData.ContainsKey("speed"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Messages::MessageCreateParams
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
            Metadata = new() { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" },
            OutputConfig = new()
            {
                Effort = Messages::Effort.Low,
                Format = new()
                {
                    Schema = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
            },
            ServiceTier = Messages::ServiceTier.Auto,
            StopSequences = ["string"],
            System = new(
                [
                    new Messages::TextBlockParam()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                    AllowedCallers = [Messages::ToolAllowedCaller.Direct],
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                    DeferLoading = true,
                    Description = "Get the current weather in a given location",
                    EagerInputStreaming = true,
                    InputExamples =
                    [
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    ],
                    Strict = true,
                    Type = Messages::Type.Custom,
                },
            ],
            TopK = 5,
            TopP = 0.7,

            Container = null,
            InferenceGeo = null,
            Speed = null,
        };

        Assert.Null(parameters.Container);
        Assert.True(parameters.RawBodyData.ContainsKey("container"));
        Assert.Null(parameters.InferenceGeo);
        Assert.True(parameters.RawBodyData.ContainsKey("inference_geo"));
        Assert.Null(parameters.Speed);
        Assert.True(parameters.RawBodyData.ContainsKey("speed"));
    }

    [Fact]
    public void Url_Works()
    {
        Messages::MessageCreateParams parameters = new()
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(new Uri("https://api.anthropic.com/v1/messages"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Messages::MessageCreateParams
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "Hello, world", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
            Container = "container",
            InferenceGeo = "inference_geo",
            Metadata = new() { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" },
            OutputConfig = new()
            {
                Effort = Messages::Effort.Low,
                Format = new()
                {
                    Schema = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
            },
            ServiceTier = Messages::ServiceTier.Auto,
            Speed = Messages::Speed.Standard,
            StopSequences = ["string"],
            System = new(
                [
                    new Messages::TextBlockParam()
                    {
                        Text = "Today's date is 2024-06-01.",
                        CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
                    AllowedCallers = [Messages::ToolAllowedCaller.Direct],
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                    DeferLoading = true,
                    Description = "Get the current weather in a given location",
                    EagerInputStreaming = true,
                    InputExamples =
                    [
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    ],
                    Strict = true,
                    Type = Messages::Type.Custom,
                },
            ],
            TopK = 5,
            TopP = 0.7,
        };

        Messages::MessageCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ServiceTierTest : TestBase
{
    [Theory]
    [InlineData(Messages::ServiceTier.Auto)]
    [InlineData(Messages::ServiceTier.StandardOnly)]
    public void Validation_Works(Messages::ServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Messages::ServiceTier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Messages::ServiceTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Messages::ServiceTier.Auto)]
    [InlineData(Messages::ServiceTier.StandardOnly)]
    public void SerializationRoundtrip_Works(Messages::ServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Messages::ServiceTier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Messages::ServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Messages::ServiceTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Messages::ServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SpeedTest : TestBase
{
    [Theory]
    [InlineData(Messages::Speed.Standard)]
    [InlineData(Messages::Speed.Fast)]
    public void Validation_Works(Messages::Speed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Messages::Speed> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Messages::Speed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Messages::Speed.Standard)]
    [InlineData(Messages::Speed.Fast)]
    public void SerializationRoundtrip_Works(Messages::Speed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Messages::Speed> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Messages::Speed>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Messages::Speed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Messages::Speed>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MessageCreateParamsSystemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Messages::MessageCreateParamsSystem value = "string";
        value.Validate();
    }

    [Fact]
    public void TextBlockParamsValidationWorks()
    {
        Messages::MessageCreateParamsSystem value = new(
            [
                new Messages::TextBlockParam()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Messages::MessageCreateParamsSystem value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Messages::MessageCreateParamsSystem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextBlockParamsSerializationRoundtripWorks()
    {
        Messages::MessageCreateParamsSystem value = new(
            [
                new Messages::TextBlockParam()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Messages::MessageCreateParamsSystem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
