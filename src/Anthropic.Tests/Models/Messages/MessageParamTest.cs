using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class MessageParamTest : TestBase
{
    [Fact]
    public void UserValidationWorks()
    {
        MessageParam value = new UserMessageParam(
            new MessageContentParam(
                [
                    new ContentBlockParam(
                        new TextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new CitationCharLocationParam()
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
        MessageParam value = new AssistantMessageParam(
            new MessageContentParam(
                [
                    new ContentBlockParam(
                        new TextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new CitationCharLocationParam()
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
        MessageParam value = new SystemMessageParam("string");
        value.Validate();
    }

    [Fact]
    public void UserSerializationRoundtripWorks()
    {
        MessageParam value = new UserMessageParam(
            new MessageContentParam(
                [
                    new ContentBlockParam(
                        new TextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new CitationCharLocationParam()
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
        var deserialized = JsonSerializer.Deserialize<MessageParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AssistantSerializationRoundtripWorks()
    {
        MessageParam value = new AssistantMessageParam(
            new MessageContentParam(
                [
                    new ContentBlockParam(
                        new TextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new CitationCharLocationParam()
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
        var deserialized = JsonSerializer.Deserialize<MessageParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SystemSerializationRoundtripWorks()
    {
        MessageParam value = new SystemMessageParam("string");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserRoleWorks()
    {
        MessageParam value = new UserMessageParam(
            new MessageContentParam(
                [
                    new ContentBlockParam(
                        new TextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new CitationCharLocationParam()
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
        Assert.Equal(MessageParamRole.User, value.Role.Value());
    }

    [Fact]
    public void AssistantRoleWorks()
    {
        MessageParam value = new AssistantMessageParam(
            new MessageContentParam(
                [
                    new ContentBlockParam(
                        new TextBlockParam()
                        {
                            Text = "What is a quaternion?",
                            CacheControl = new() { Ttl = Ttl.Ttl5m },
                            Citations =
                            [
                                new CitationCharLocationParam()
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
        Assert.Equal(MessageParamRole.Assistant, value.Role.Value());
    }

    [Fact]
    public void SystemRoleWorks()
    {
        MessageParam value = new SystemMessageParam("string");
        Assert.Equal(MessageParamRole.System, value.Role.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        MessageParam value = new(
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

        MessageContentParam expectedContent = new(
            [
                new ContentBlockParam(
                    new TextBlockParam()
                    {
                        Text = "What is a quaternion?",
                        CacheControl = new() { Ttl = Ttl.Ttl5m },
                        Citations =
                        [
                            new CitationCharLocationParam()
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
        ApiEnum<string, MessageParamRole> expectedRole = MessageParamRole.User;

        Assert.Equal(expectedContent, value.Content);
        Assert.Equal(expectedRole, value.Role);

        MessageParam emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Content);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Role);
    }
}

public class MessageParamRoleTest : TestBase
{
    [Theory]
    [InlineData(MessageParamRole.User)]
    [InlineData(MessageParamRole.Assistant)]
    [InlineData(MessageParamRole.System)]
    public void Validation_Works(MessageParamRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageParamRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessageParamRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MessageParamRole.User)]
    [InlineData(MessageParamRole.Assistant)]
    [InlineData(MessageParamRole.System)]
    public void SerializationRoundtrip_Works(MessageParamRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageParamRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessageParamRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessageParamRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessageParamRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
