using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class MessageCountTokensParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Messages::MessageCountTokensParams
        {
            Messages = [new() { Content = "string", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_5_20251101,
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
                    CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                    Description = "Get the current weather in a given location",
                    Type = Messages::Type.Custom,
                },
            ],
        };

        List<Messages::MessageParam> expectedMessages =
        [
            new() { Content = "string", Role = Messages::Role.User },
        ];
        ApiEnum<string, Messages::Model> expectedModel = Messages::Model.ClaudeOpus4_5_20251101;
        Messages::MessageCountTokensParamsSystem expectedSystem = new(
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
        Messages::ThinkingConfigParam expectedThinking = new Messages::ThinkingConfigEnabled(1024);
        Messages::ToolChoice expectedToolChoice = new Messages::ToolChoiceAuto()
        {
            DisableParallelToolUse = true,
        };
        List<Messages::MessageCountTokensTool> expectedTools =
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
                CacheControl = new() { Ttl = Messages::Ttl.Ttl5m },
                Description = "Get the current weather in a given location",
                Type = Messages::Type.Custom,
            },
        ];

        Assert.Equal(expectedMessages.Count, parameters.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], parameters.Messages[i]);
        }
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedSystem, parameters.System);
        Assert.Equal(expectedThinking, parameters.Thinking);
        Assert.Equal(expectedToolChoice, parameters.ToolChoice);
        Assert.NotNull(parameters.Tools);
        Assert.Equal(expectedTools.Count, parameters.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], parameters.Tools[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Messages::MessageCountTokensParams
        {
            Messages = [new() { Content = "string", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_5_20251101,
        };

        Assert.Null(parameters.System);
        Assert.False(parameters.RawBodyData.ContainsKey("system"));
        Assert.Null(parameters.Thinking);
        Assert.False(parameters.RawBodyData.ContainsKey("thinking"));
        Assert.Null(parameters.ToolChoice);
        Assert.False(parameters.RawBodyData.ContainsKey("tool_choice"));
        Assert.Null(parameters.Tools);
        Assert.False(parameters.RawBodyData.ContainsKey("tools"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Messages::MessageCountTokensParams
        {
            Messages = [new() { Content = "string", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_5_20251101,

            // Null should be interpreted as omitted for these properties
            System = null,
            Thinking = null,
            ToolChoice = null,
            Tools = null,
        };

        Assert.Null(parameters.System);
        Assert.False(parameters.RawBodyData.ContainsKey("system"));
        Assert.Null(parameters.Thinking);
        Assert.False(parameters.RawBodyData.ContainsKey("thinking"));
        Assert.Null(parameters.ToolChoice);
        Assert.False(parameters.RawBodyData.ContainsKey("tool_choice"));
        Assert.Null(parameters.Tools);
        Assert.False(parameters.RawBodyData.ContainsKey("tools"));
    }

    [Fact]
    public void Url_Works()
    {
        Messages::MessageCountTokensParams parameters = new()
        {
            Messages = [new() { Content = "string", Role = Messages::Role.User }],
            Model = Messages::Model.ClaudeOpus4_5_20251101,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(new Uri("https://api.anthropic.com/v1/messages/count_tokens"), url);
    }
}

public class MessageCountTokensParamsSystemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Messages::MessageCountTokensParamsSystem value = "string";
        value.Validate();
    }

    [Fact]
    public void TextBlockParamsValidationWorks()
    {
        Messages::MessageCountTokensParamsSystem value = new(
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
        Messages::MessageCountTokensParamsSystem value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Messages::MessageCountTokensParamsSystem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextBlockParamsSerializationRoundtripWorks()
    {
        Messages::MessageCountTokensParamsSystem value = new(
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
        var deserialized = JsonSerializer.Deserialize<Messages::MessageCountTokensParamsSystem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
