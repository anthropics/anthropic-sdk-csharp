using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRequestToolRemovalBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRequestToolRemovalBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        BetaRequestToolRemovalBlockTool expectedTool = new BetaToolChangeToolReference("name");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_removal");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedTool, model.Tool);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRequestToolRemovalBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolRemovalBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRequestToolRemovalBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolRemovalBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaRequestToolRemovalBlockTool expectedTool = new BetaToolChangeToolReference("name");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_removal");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedTool, deserialized.Tool);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaRequestToolRemovalBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaRequestToolRemovalBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaRequestToolRemovalBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaRequestToolRemovalBlock
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
        var model = new BetaRequestToolRemovalBlock
        {
            Tool = new BetaToolChangeToolReference("name"),

            CacheControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaRequestToolRemovalBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        BetaRequestToolRemovalBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaRequestToolRemovalBlockToolTest : TestBase
{
    [Fact]
    public void BetaToolChangeToolReferenceValidationWorks()
    {
        BetaRequestToolRemovalBlockTool value = new BetaToolChangeToolReference("name");
        value.Validate();
    }

    [Fact]
    public void BetaToolChangeMcpToolReferenceValidationWorks()
    {
        BetaRequestToolRemovalBlockTool value = new BetaToolChangeMcpToolReference()
        {
            Name = "name",
            ServerName = "server_name",
        };
        value.Validate();
    }

    [Fact]
    public void BetaToolChangeMcpToolsetReferenceValidationWorks()
    {
        BetaRequestToolRemovalBlockTool value = new BetaToolChangeMcpToolsetReference(
            "server_name"
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolChangeToolReferenceSerializationRoundtripWorks()
    {
        BetaRequestToolRemovalBlockTool value = new BetaToolChangeToolReference("name");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolRemovalBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolChangeMcpToolReferenceSerializationRoundtripWorks()
    {
        BetaRequestToolRemovalBlockTool value = new BetaToolChangeMcpToolReference()
        {
            Name = "name",
            ServerName = "server_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolRemovalBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolChangeMcpToolsetReferenceSerializationRoundtripWorks()
    {
        BetaRequestToolRemovalBlockTool value = new BetaToolChangeMcpToolsetReference(
            "server_name"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolRemovalBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolChangeToolReferenceTypeWorks()
    {
        BetaRequestToolRemovalBlockTool value = new BetaToolChangeToolReference("name");
        Assert.Equal(BetaRequestToolRemovalBlockToolType.ToolReference, value.Type.Value());
    }

    [Fact]
    public void BetaToolChangeMcpToolReferenceTypeWorks()
    {
        BetaRequestToolRemovalBlockTool value = new BetaToolChangeMcpToolReference()
        {
            Name = "name",
            ServerName = "server_name",
        };
        Assert.Equal(BetaRequestToolRemovalBlockToolType.McpToolReference, value.Type.Value());
    }

    [Fact]
    public void BetaToolChangeMcpToolsetReferenceTypeWorks()
    {
        BetaRequestToolRemovalBlockTool value = new BetaToolChangeMcpToolsetReference(
            "server_name"
        );
        Assert.Equal(BetaRequestToolRemovalBlockToolType.McpToolsetReference, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaRequestToolRemovalBlockTool value = new(
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
        ApiEnum<string, BetaRequestToolRemovalBlockToolType> expectedType =
            BetaRequestToolRemovalBlockToolType.ToolReference;
        string expectedServerName = "server_name";

        Assert.Equal(expectedName, value.Name);
        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedServerName, value.ServerName);

        BetaRequestToolRemovalBlockTool emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Null(emptyValue.Name);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ServerName);

        BetaRequestToolRemovalBlockTool mismatchedValue = new(
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

public class BetaRequestToolRemovalBlockToolTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaRequestToolRemovalBlockToolType.ToolReference)]
    [InlineData(BetaRequestToolRemovalBlockToolType.McpToolReference)]
    [InlineData(BetaRequestToolRemovalBlockToolType.McpToolsetReference)]
    public void Validation_Works(BetaRequestToolRemovalBlockToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaRequestToolRemovalBlockToolType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaRequestToolRemovalBlockToolType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaRequestToolRemovalBlockToolType.ToolReference)]
    [InlineData(BetaRequestToolRemovalBlockToolType.McpToolReference)]
    [InlineData(BetaRequestToolRemovalBlockToolType.McpToolsetReference)]
    public void SerializationRoundtrip_Works(BetaRequestToolRemovalBlockToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaRequestToolRemovalBlockToolType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaRequestToolRemovalBlockToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaRequestToolRemovalBlockToolType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaRequestToolRemovalBlockToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
