using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaResponseToolRemovalBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaResponseToolRemovalBlock
        {
            Tool = new BetaResponseToolChangeToolReference("name"),
        };

        BetaResponseToolRemovalBlockTool expectedTool = new BetaResponseToolChangeToolReference(
            "name"
        );
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_removal");

        Assert.Equal(expectedTool, model.Tool);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaResponseToolRemovalBlock
        {
            Tool = new BetaResponseToolChangeToolReference("name"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaResponseToolRemovalBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaResponseToolRemovalBlock
        {
            Tool = new BetaResponseToolChangeToolReference("name"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaResponseToolRemovalBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaResponseToolRemovalBlockTool expectedTool = new BetaResponseToolChangeToolReference(
            "name"
        );
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_removal");

        Assert.Equal(expectedTool, deserialized.Tool);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaResponseToolRemovalBlock
        {
            Tool = new BetaResponseToolChangeToolReference("name"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaResponseToolRemovalBlock
        {
            Tool = new BetaResponseToolChangeToolReference("name"),
        };

        BetaResponseToolRemovalBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaResponseToolRemovalBlockToolTest : TestBase
{
    [Fact]
    public void BetaResponseToolChangeToolReferenceValidationWorks()
    {
        BetaResponseToolRemovalBlockTool value = new BetaResponseToolChangeToolReference("name");
        value.Validate();
    }

    [Fact]
    public void BetaResponseToolChangeMcpToolReferenceValidationWorks()
    {
        BetaResponseToolRemovalBlockTool value = new BetaResponseToolChangeMcpToolReference()
        {
            Name = "name",
            ServerName = "server_name",
        };
        value.Validate();
    }

    [Fact]
    public void BetaResponseToolChangeMcpToolsetReferenceValidationWorks()
    {
        BetaResponseToolRemovalBlockTool value = new BetaResponseToolChangeMcpToolsetReference(
            "server_name"
        );
        value.Validate();
    }

    [Fact]
    public void BetaResponseToolChangeToolReferenceSerializationRoundtripWorks()
    {
        BetaResponseToolRemovalBlockTool value = new BetaResponseToolChangeToolReference("name");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaResponseToolRemovalBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaResponseToolChangeMcpToolReferenceSerializationRoundtripWorks()
    {
        BetaResponseToolRemovalBlockTool value = new BetaResponseToolChangeMcpToolReference()
        {
            Name = "name",
            ServerName = "server_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaResponseToolRemovalBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaResponseToolChangeMcpToolsetReferenceSerializationRoundtripWorks()
    {
        BetaResponseToolRemovalBlockTool value = new BetaResponseToolChangeMcpToolsetReference(
            "server_name"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaResponseToolRemovalBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaResponseToolChangeToolReferenceTypeWorks()
    {
        BetaResponseToolRemovalBlockTool value = new BetaResponseToolChangeToolReference("name");
        Assert.Equal(BetaResponseToolRemovalBlockToolType.ToolReference, value.Type.Value());
    }

    [Fact]
    public void BetaResponseToolChangeMcpToolReferenceTypeWorks()
    {
        BetaResponseToolRemovalBlockTool value = new BetaResponseToolChangeMcpToolReference()
        {
            Name = "name",
            ServerName = "server_name",
        };
        Assert.Equal(BetaResponseToolRemovalBlockToolType.McpToolReference, value.Type.Value());
    }

    [Fact]
    public void BetaResponseToolChangeMcpToolsetReferenceTypeWorks()
    {
        BetaResponseToolRemovalBlockTool value = new BetaResponseToolChangeMcpToolsetReference(
            "server_name"
        );
        Assert.Equal(BetaResponseToolRemovalBlockToolType.McpToolsetReference, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaResponseToolRemovalBlockTool value = new(
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
        ApiEnum<string, BetaResponseToolRemovalBlockToolType> expectedType =
            BetaResponseToolRemovalBlockToolType.ToolReference;
        string expectedServerName = "server_name";

        Assert.Equal(expectedName, value.Name);
        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedServerName, value.ServerName);

        BetaResponseToolRemovalBlockTool emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Null(emptyValue.Name);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ServerName);

        BetaResponseToolRemovalBlockTool mismatchedValue = new(
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

public class BetaResponseToolRemovalBlockToolTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaResponseToolRemovalBlockToolType.ToolReference)]
    [InlineData(BetaResponseToolRemovalBlockToolType.McpToolReference)]
    [InlineData(BetaResponseToolRemovalBlockToolType.McpToolsetReference)]
    public void Validation_Works(BetaResponseToolRemovalBlockToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaResponseToolRemovalBlockToolType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaResponseToolRemovalBlockToolType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaResponseToolRemovalBlockToolType.ToolReference)]
    [InlineData(BetaResponseToolRemovalBlockToolType.McpToolReference)]
    [InlineData(BetaResponseToolRemovalBlockToolType.McpToolsetReference)]
    public void SerializationRoundtrip_Works(BetaResponseToolRemovalBlockToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaResponseToolRemovalBlockToolType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaResponseToolRemovalBlockToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaResponseToolRemovalBlockToolType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaResponseToolRemovalBlockToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
