using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMessageParamTest : TestBase
{
    [Fact]
    public void UserValidationWorks()
    {
        BetaMessageParam value = new BetaUserMessageParam(
            new BetaMessageContentParam(
                [
                    new BetaContentBlockParam(
                        new BetaTextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new BetaCitationCharLocationParam()
                                {
                                    CitedText = "The grass is green. The sky is blue.",
                                    DocumentIndex = 0,
                                    DocumentTitle = "x",
                                    EndCharIndex = 0,
                                    StartCharIndex = 0,
                                },
                            ],
                        }
                    ),
                ]
            )
        );
        value.Validate();
    }

    [Fact]
    public void AssistantValidationWorks()
    {
        BetaMessageParam value = new BetaAssistantMessageParam(
            new BetaMessageContentParam(
                [
                    new BetaContentBlockParam(
                        new BetaTextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new BetaCitationCharLocationParam()
                                {
                                    CitedText = "The grass is green. The sky is blue.",
                                    DocumentIndex = 0,
                                    DocumentTitle = "x",
                                    EndCharIndex = 0,
                                    StartCharIndex = 0,
                                },
                            ],
                        }
                    ),
                ]
            )
        );
        value.Validate();
    }

    [Fact]
    public void SystemValidationWorks()
    {
        BetaMessageParam value = new BetaSystemMessageParam()
        {
            ClearAt = ClearAt.NextUserMessage,
            Content = "string",
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },
        };
        value.Validate();
    }

    [Fact]
    public void UserSerializationRoundtripWorks()
    {
        BetaMessageParam value = new BetaUserMessageParam(
            new BetaMessageContentParam(
                [
                    new BetaContentBlockParam(
                        new BetaTextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new BetaCitationCharLocationParam()
                                {
                                    CitedText = "The grass is green. The sky is blue.",
                                    DocumentIndex = 0,
                                    DocumentTitle = "x",
                                    EndCharIndex = 0,
                                    StartCharIndex = 0,
                                },
                            ],
                        }
                    ),
                ]
            )
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AssistantSerializationRoundtripWorks()
    {
        BetaMessageParam value = new BetaAssistantMessageParam(
            new BetaMessageContentParam(
                [
                    new BetaContentBlockParam(
                        new BetaTextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new BetaCitationCharLocationParam()
                                {
                                    CitedText = "The grass is green. The sky is blue.",
                                    DocumentIndex = 0,
                                    DocumentTitle = "x",
                                    EndCharIndex = 0,
                                    StartCharIndex = 0,
                                },
                            ],
                        }
                    ),
                ]
            )
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SystemSerializationRoundtripWorks()
    {
        BetaMessageParam value = new BetaSystemMessageParam()
        {
            ClearAt = ClearAt.NextUserMessage,
            Content = "string",
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserRoleWorks()
    {
        BetaMessageParam value = new BetaUserMessageParam(
            new BetaMessageContentParam(
                [
                    new BetaContentBlockParam(
                        new BetaTextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new BetaCitationCharLocationParam()
                                {
                                    CitedText = "The grass is green. The sky is blue.",
                                    DocumentIndex = 0,
                                    DocumentTitle = "x",
                                    EndCharIndex = 0,
                                    StartCharIndex = 0,
                                },
                            ],
                        }
                    ),
                ]
            )
        );
        Assert.Equal(BetaMessageParamRole.User, value.Role.Value());
    }

    [Fact]
    public void AssistantRoleWorks()
    {
        BetaMessageParam value = new BetaAssistantMessageParam(
            new BetaMessageContentParam(
                [
                    new BetaContentBlockParam(
                        new BetaTextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new BetaCitationCharLocationParam()
                                {
                                    CitedText = "The grass is green. The sky is blue.",
                                    DocumentIndex = 0,
                                    DocumentTitle = "x",
                                    EndCharIndex = 0,
                                    StartCharIndex = 0,
                                },
                            ],
                        }
                    ),
                ]
            )
        );
        Assert.Equal(BetaMessageParamRole.Assistant, value.Role.Value());
    }

    [Fact]
    public void SystemRoleWorks()
    {
        BetaMessageParam value = new BetaSystemMessageParam()
        {
            ClearAt = ClearAt.NextUserMessage,
            Content = "string",
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },
        };
        Assert.Equal(BetaMessageParamRole.System, value.Role.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaMessageParam value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "content": [
                    {
                      "text": "What is a quaternion?",
                      "type": "text",
                      "cache_control": {
                        "type": "ephemeral",
                        "ttl": "5m"
                      },
                      "citations": [
                        {
                          "cited_text": "The grass is green. The sky is blue.",
                          "document_index": 0,
                          "document_title": "x",
                          "end_char_index": 0,
                          "start_char_index": 0,
                          "type": "char_location"
                        }
                      ]
                    }
                  ],
                  "role": "user"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        BetaMessageContentParam expectedContent = new(
            [
                new BetaContentBlockParam(
                    new BetaTextBlockParam()
                    {
                        Text = "What is a quaternion?",
                        CacheControl = new() { Ttl = Ttl.Ttl5m },
                        Citations =
                        [
                            new BetaCitationCharLocationParam()
                            {
                                CitedText = "The grass is green. The sky is blue.",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    }
                ),
            ]
        );
        ApiEnum<string, BetaMessageParamRole> expectedRole = BetaMessageParamRole.User;

        Assert.Equal(expectedContent, value.Content);
        Assert.Equal(expectedRole, value.Role);

        BetaMessageParam emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Null(emptyValue.Content);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Role);
    }
}

public class BetaMessageParamRoleTest : TestBase
{
    [Theory]
    [InlineData(BetaMessageParamRole.User)]
    [InlineData(BetaMessageParamRole.Assistant)]
    [InlineData(BetaMessageParamRole.System)]
    public void Validation_Works(BetaMessageParamRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaMessageParamRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaMessageParamRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaMessageParamRole.User)]
    [InlineData(BetaMessageParamRole.Assistant)]
    [InlineData(BetaMessageParamRole.System)]
    public void SerializationRoundtrip_Works(BetaMessageParamRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaMessageParamRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaMessageParamRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaMessageParamRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaMessageParamRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
