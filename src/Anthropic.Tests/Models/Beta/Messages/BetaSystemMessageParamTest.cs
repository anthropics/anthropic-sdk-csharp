using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaSystemMessageParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSystemMessageParam
        {
            ClearAt = ClearAt.NextUserMessage,
            Content = "string",
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },
        };

        JsonElement expectedRole = JsonSerializer.SerializeToElement("system");
        ApiEnum<string, ClearAt> expectedClearAt = ClearAt.NextUserMessage;
        BetaSystemMessageParamContent expectedContent = "string";
        BetaSystemMessageOutputConfig expectedOutputConfig = new()
        {
            Effort = BetaSystemMessageOutputConfigEffort.Low,
        };

        Assert.True(JsonElement.DeepEquals(expectedRole, model.Role));
        Assert.Equal(expectedClearAt, model.ClearAt);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedOutputConfig, model.OutputConfig);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSystemMessageParam
        {
            ClearAt = ClearAt.NextUserMessage,
            Content = "string",
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSystemMessageParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSystemMessageParam
        {
            ClearAt = ClearAt.NextUserMessage,
            Content = "string",
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSystemMessageParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedRole = JsonSerializer.SerializeToElement("system");
        ApiEnum<string, ClearAt> expectedClearAt = ClearAt.NextUserMessage;
        BetaSystemMessageParamContent expectedContent = "string";
        BetaSystemMessageOutputConfig expectedOutputConfig = new()
        {
            Effort = BetaSystemMessageOutputConfigEffort.Low,
        };

        Assert.True(JsonElement.DeepEquals(expectedRole, deserialized.Role));
        Assert.Equal(expectedClearAt, deserialized.ClearAt);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedOutputConfig, deserialized.OutputConfig);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSystemMessageParam
        {
            ClearAt = ClearAt.NextUserMessage,
            Content = "string",
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaSystemMessageParam
        {
            ClearAt = ClearAt.NextUserMessage,
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaSystemMessageParam
        {
            ClearAt = ClearAt.NextUserMessage,
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaSystemMessageParam
        {
            ClearAt = ClearAt.NextUserMessage,
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },

            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaSystemMessageParam
        {
            ClearAt = ClearAt.NextUserMessage,
            Content = "string",
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },
        } with
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaSystemMessageParam
        {
            ClearAt = ClearAt.NextUserMessage,
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },

            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaSystemMessageParam { Content = "string" };

        Assert.Null(model.ClearAt);
        Assert.False(model.RawData.ContainsKey("clear_at"));
        Assert.Null(model.OutputConfig);
        Assert.False(model.RawData.ContainsKey("output_config"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaSystemMessageParam { Content = "string" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaSystemMessageParam
        {
            Content = "string",

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
        var model = new BetaSystemMessageParam
        {
            Content = "string",

            ClearAt = null,
            OutputConfig = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSystemMessageParam
        {
            ClearAt = ClearAt.NextUserMessage,
            Content = "string",
            OutputConfig = new() { Effort = BetaSystemMessageOutputConfigEffort.Low },
        };

        BetaSystemMessageParam copied = new(model);

        Assert.Equal(model, copied);
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

public class BetaSystemMessageParamContentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        BetaSystemMessageParamContent value = "string";
        value.Validate();
    }

    [Fact]
    public void BlocksValidationWorks()
    {
        BetaSystemMessageParamContent value = new(
            [
                new SystemMessageContentBlock(
                    new BetaTextBlockParam()
                    {
                        Text = "x",
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
        BetaSystemMessageParamContent value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSystemMessageParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BlocksSerializationRoundtripWorks()
    {
        BetaSystemMessageParamContent value = new(
            [
                new SystemMessageContentBlock(
                    new BetaTextBlockParam()
                    {
                        Text = "x",
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
        var deserialized = JsonSerializer.Deserialize<BetaSystemMessageParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SystemMessageContentBlockTest : TestBase
{
    [Fact]
    public void BetaTextBlockParamValidationWorks()
    {
        SystemMessageContentBlock value = new BetaTextBlockParam()
        {
            Text = "x",
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
        };
        value.Validate();
    }

    [Fact]
    public void BetaRequestToolAdditionValidationWorks()
    {
        SystemMessageContentBlock value = new BetaRequestToolAdditionBlock()
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void BetaRequestToolRemovalValidationWorks()
    {
        SystemMessageContentBlock value = new BetaRequestToolRemovalBlock()
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void BetaTextBlockParamSerializationRoundtripWorks()
    {
        SystemMessageContentBlock value = new BetaTextBlockParam()
        {
            Text = "x",
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
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SystemMessageContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaRequestToolAdditionSerializationRoundtripWorks()
    {
        SystemMessageContentBlock value = new BetaRequestToolAdditionBlock()
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SystemMessageContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaRequestToolRemovalSerializationRoundtripWorks()
    {
        SystemMessageContentBlock value = new BetaRequestToolRemovalBlock()
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SystemMessageContentBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaTextBlockParamTypeWorks()
    {
        SystemMessageContentBlock value = new BetaTextBlockParam()
        {
            Text = "x",
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
        };
        Assert.Equal(SystemMessageContentBlockType.Text, value.Type.Value());
    }

    [Fact]
    public void BetaRequestToolAdditionTypeWorks()
    {
        SystemMessageContentBlock value = new BetaRequestToolAdditionBlock()
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        Assert.Equal(SystemMessageContentBlockType.ToolAddition, value.Type.Value());
    }

    [Fact]
    public void BetaRequestToolRemovalTypeWorks()
    {
        SystemMessageContentBlock value = new BetaRequestToolRemovalBlock()
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        Assert.Equal(SystemMessageContentBlockType.ToolRemoval, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        SystemMessageContentBlock value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "text",
                  "cache_control": {
                    "type": "ephemeral",
                    "ttl": "5m"
                  }
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, SystemMessageContentBlockType> expectedType =
            SystemMessageContentBlockType.Text;
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedCacheControl, value.CacheControl);

        SystemMessageContentBlock emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.CacheControl);

        SystemMessageContentBlock mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "cache_control": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.CacheControl);
    }
}

public class SystemMessageContentBlockTypeTest : TestBase
{
    [Theory]
    [InlineData(SystemMessageContentBlockType.Text)]
    [InlineData(SystemMessageContentBlockType.ToolAddition)]
    [InlineData(SystemMessageContentBlockType.ToolRemoval)]
    public void Validation_Works(SystemMessageContentBlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SystemMessageContentBlockType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SystemMessageContentBlockType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SystemMessageContentBlockType.Text)]
    [InlineData(SystemMessageContentBlockType.ToolAddition)]
    [InlineData(SystemMessageContentBlockType.ToolRemoval)]
    public void SerializationRoundtrip_Works(SystemMessageContentBlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SystemMessageContentBlockType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SystemMessageContentBlockType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SystemMessageContentBlockType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SystemMessageContentBlockType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
