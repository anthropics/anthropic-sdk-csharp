using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRequestToolAdditionBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        BetaRequestToolAdditionBlockTool expectedTool = new BetaToolChangeToolReference("name");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_addition");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedTool, model.Tool);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolAdditionBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolAdditionBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaRequestToolAdditionBlockTool expectedTool = new BetaToolChangeToolReference("name");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_addition");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedTool, deserialized.Tool);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),

            CacheControl = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),

            CacheControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        BetaRequestToolAdditionBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaRequestToolAdditionBlockToolTest : TestBase
{
    [Fact]
    public void BetaToolChangeToolReferenceValidationWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeToolReference("name");
        value.Validate();
    }

    [Fact]
    public void BetaToolChangeMcpToolReferenceValidationWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeMcpToolReference()
        {
            Name = "name",
            ServerName = "server_name",
        };
        value.Validate();
    }

    [Fact]
    public void BetaToolChangeMcpToolsetReferenceValidationWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeMcpToolsetReference(
            "server_name"
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolChangeToolDefinitionParamValidationWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeToolDefinitionParam(
            new BetaTool()
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
                AllowedCallers = [BetaToolAllowedCaller.Direct],
                CacheControl = new() { Ttl = Ttl.Ttl5m },
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
                Type = BetaToolType.Custom,
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolChangeToolReferenceSerializationRoundtripWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeToolReference("name");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolAdditionBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolChangeMcpToolReferenceSerializationRoundtripWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeMcpToolReference()
        {
            Name = "name",
            ServerName = "server_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolAdditionBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolChangeMcpToolsetReferenceSerializationRoundtripWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeMcpToolsetReference(
            "server_name"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolAdditionBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolChangeToolDefinitionParamSerializationRoundtripWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeToolDefinitionParam(
            new BetaTool()
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
                AllowedCallers = [BetaToolAllowedCaller.Direct],
                CacheControl = new() { Ttl = Ttl.Ttl5m },
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
                Type = BetaToolType.Custom,
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolAdditionBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolChangeToolReferenceTypeWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeToolReference("name");
        Assert.Equal(BetaRequestToolAdditionBlockToolType.ToolReference, value.Type.Value());
    }

    [Fact]
    public void BetaToolChangeMcpToolReferenceTypeWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeMcpToolReference()
        {
            Name = "name",
            ServerName = "server_name",
        };
        Assert.Equal(BetaRequestToolAdditionBlockToolType.McpToolReference, value.Type.Value());
    }

    [Fact]
    public void BetaToolChangeMcpToolsetReferenceTypeWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeMcpToolsetReference(
            "server_name"
        );
        Assert.Equal(BetaRequestToolAdditionBlockToolType.McpToolsetReference, value.Type.Value());
    }

    [Fact]
    public void BetaToolChangeToolDefinitionParamTypeWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeToolDefinitionParam(
            new BetaTool()
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
                AllowedCallers = [BetaToolAllowedCaller.Direct],
                CacheControl = new() { Ttl = Ttl.Ttl5m },
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
                Type = BetaToolType.Custom,
            }
        );
        Assert.Equal(BetaRequestToolAdditionBlockToolType.ToolDefinition, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaRequestToolAdditionBlockTool value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "name": "name",
                  "type": "tool_reference",
                  "server_name": "server_name"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedName = "name";
        ApiEnum<string, BetaRequestToolAdditionBlockToolType> expectedType =
            BetaRequestToolAdditionBlockToolType.ToolReference;
        string expectedServerName = "server_name";

        Assert.Equal(expectedName, value.Name);
        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedServerName, value.ServerName);

        BetaRequestToolAdditionBlockTool emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Null(emptyValue.Name);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ServerName);

        BetaRequestToolAdditionBlockTool mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "name": [
                    "invalid"
                  ],
                  "server_name": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.Name);
        Assert.Null(mismatchedValue.ServerName);
    }
}

public class BetaRequestToolAdditionBlockToolTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaRequestToolAdditionBlockToolType.ToolReference)]
    [InlineData(BetaRequestToolAdditionBlockToolType.McpToolReference)]
    [InlineData(BetaRequestToolAdditionBlockToolType.McpToolsetReference)]
    [InlineData(BetaRequestToolAdditionBlockToolType.ToolDefinition)]
    public void Validation_Works(BetaRequestToolAdditionBlockToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaRequestToolAdditionBlockToolType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaRequestToolAdditionBlockToolType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaRequestToolAdditionBlockToolType.ToolReference)]
    [InlineData(BetaRequestToolAdditionBlockToolType.McpToolReference)]
    [InlineData(BetaRequestToolAdditionBlockToolType.McpToolsetReference)]
    [InlineData(BetaRequestToolAdditionBlockToolType.ToolDefinition)]
    public void SerializationRoundtrip_Works(BetaRequestToolAdditionBlockToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaRequestToolAdditionBlockToolType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaRequestToolAdditionBlockToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaRequestToolAdditionBlockToolType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaRequestToolAdditionBlockToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
