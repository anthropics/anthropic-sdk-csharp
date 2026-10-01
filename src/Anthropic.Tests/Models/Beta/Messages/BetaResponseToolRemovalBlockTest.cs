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
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_reference");
        string expectedServerName = "server_name";

        Assert.Equal(expectedName, value.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));
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
