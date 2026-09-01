using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMessageParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMessageParam
        {
            Content = new(
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
            ),
            Role = Role.User,
            ClearAt = ClearAt.NextUserMessage,
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },
        };

        BetaMessageParamContent expectedContent = new(
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
        ApiEnum<string, Role> expectedRole = Role.User;
        ApiEnum<string, ClearAt> expectedClearAt = ClearAt.NextUserMessage;
        BetaSystemMessageOutputConfig expectedOutputConfig = new()
        {
            Effort = BetaSystemMessageOutputConfigEffort.Low,
        };

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedRole, model.Role);
        Assert.Equal(expectedClearAt, model.ClearAt);
        Assert.Equal(expectedOutputConfig, model.OutputConfig);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMessageParam
        {
            Content = new(
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
            ),
            Role = Role.User,
            ClearAt = ClearAt.NextUserMessage,
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMessageParam
        {
            Content = new(
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
            ),
            Role = Role.User,
            ClearAt = ClearAt.NextUserMessage,
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaMessageParamContent expectedContent = new(
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
        ApiEnum<string, Role> expectedRole = Role.User;
        ApiEnum<string, ClearAt> expectedClearAt = ClearAt.NextUserMessage;
        BetaSystemMessageOutputConfig expectedOutputConfig = new()
        {
            Effort = BetaSystemMessageOutputConfigEffort.Low,
        };

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedRole, deserialized.Role);
        Assert.Equal(expectedClearAt, deserialized.ClearAt);
        Assert.Equal(expectedOutputConfig, deserialized.OutputConfig);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMessageParam
        {
            Content = new(
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
            ),
            Role = Role.User,
            ClearAt = ClearAt.NextUserMessage,
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaMessageParam
        {
            Content = new(
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
            ),
            Role = Role.User,
        };

        Assert.Null(model.ClearAt);
        Assert.False(model.RawData.ContainsKey("clear_at"));
        Assert.Null(model.OutputConfig);
        Assert.False(model.RawData.ContainsKey("output_config"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaMessageParam
        {
            Content = new(
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
            ),
            Role = Role.User,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaMessageParam
        {
            Content = new(
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
            ),
            Role = Role.User,

            ClearAt = null,
            OutputConfig = null,
        };

        Assert.Null(model.ClearAt);
        Assert.True(model.RawData.ContainsKey("clear_at"));
        Assert.Null(model.OutputConfig);
        Assert.True(model.RawData.ContainsKey("output_config"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaMessageParam
        {
            Content = new(
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
            ),
            Role = Role.User,

            ClearAt = null,
            OutputConfig = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaMessageParam
        {
            Content = new(
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
            ),
            Role = Role.User,
            ClearAt = ClearAt.NextUserMessage,
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },
        };

        BetaMessageParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaMessageParamContentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        BetaMessageParamContent value = "string";
        value.Validate();
    }

    [Fact]
    public void BetaContentBlockParamsValidationWorks()
    {
        BetaMessageParamContent value = new(
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
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        BetaMessageParamContent value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaContentBlockParamsSerializationRoundtripWorks()
    {
        BetaMessageParamContent value = new(
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RoleTest : TestBase
{
    [Theory]
    [InlineData(Role.User)]
    [InlineData(Role.Assistant)]
    [InlineData(Role.System)]
    public void Validation_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Role.User)]
    [InlineData(Role.Assistant)]
    [InlineData(Role.System)]
    public void SerializationRoundtrip_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ClearAtTest : TestBase
{
    [Theory]
    [InlineData(ClearAt.NextUserMessage)]
    [InlineData(ClearAt.Never)]
    public void Validation_Works(ClearAt rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClearAt> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClearAt>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ClearAt.NextUserMessage)]
    [InlineData(ClearAt.Never)]
    public void SerializationRoundtrip_Works(ClearAt rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClearAt> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ClearAt>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClearAt>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ClearAt>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
