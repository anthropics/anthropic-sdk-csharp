using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaResponseToolAdditionBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaResponseToolAdditionBlock
        {
            Tool = new BetaResponseToolChangeToolReference("name"),
        };

        BetaResponseToolAdditionBlockTool expectedTool = new BetaResponseToolChangeToolReference(
            "name"
        );
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_addition");

        Assert.Equal(expectedTool, model.Tool);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaResponseToolAdditionBlock
        {
            Tool = new BetaResponseToolChangeToolReference("name"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaResponseToolAdditionBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaResponseToolAdditionBlock
        {
            Tool = new BetaResponseToolChangeToolReference("name"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaResponseToolAdditionBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaResponseToolAdditionBlockTool expectedTool = new BetaResponseToolChangeToolReference(
            "name"
        );
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_addition");

        Assert.Equal(expectedTool, deserialized.Tool);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaResponseToolAdditionBlock
        {
            Tool = new BetaResponseToolChangeToolReference("name"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaResponseToolAdditionBlock
        {
            Tool = new BetaResponseToolChangeToolReference("name"),
        };

        BetaResponseToolAdditionBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaResponseToolAdditionBlockToolTest : TestBase
{
    [Fact]
    public void BetaResponseToolChangeToolReferenceValidationWorks()
    {
        BetaResponseToolAdditionBlockTool value = new BetaResponseToolChangeToolReference("name");
        value.Validate();
    }

    [Fact]
    public void BetaResponseToolChangeMcpToolReferenceValidationWorks()
    {
        BetaResponseToolAdditionBlockTool value = new BetaResponseToolChangeMcpToolReference()
        {
            Name = "name",
            ServerName = "server_name",
        };
        value.Validate();
    }

    [Fact]
    public void BetaResponseToolChangeMcpToolsetReferenceValidationWorks()
    {
        BetaResponseToolAdditionBlockTool value = new BetaResponseToolChangeMcpToolsetReference(
            "server_name"
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolChangeToolDefinitionValidationWorks()
    {
        BetaResponseToolAdditionBlockTool value = new BetaToolChangeToolDefinition(
            new BetaResponseToolUnion(
                new BetaResponseTool()
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
                    AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
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
                    Type = BetaResponseToolType.Custom,
                }
            )
        );
        value.Validate();
    }

    [Fact]
    public void BetaResponseToolChangeToolReferenceSerializationRoundtripWorks()
    {
        BetaResponseToolAdditionBlockTool value = new BetaResponseToolChangeToolReference("name");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaResponseToolAdditionBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaResponseToolChangeMcpToolReferenceSerializationRoundtripWorks()
    {
        BetaResponseToolAdditionBlockTool value = new BetaResponseToolChangeMcpToolReference()
        {
            Name = "name",
            ServerName = "server_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaResponseToolAdditionBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaResponseToolChangeMcpToolsetReferenceSerializationRoundtripWorks()
    {
        BetaResponseToolAdditionBlockTool value = new BetaResponseToolChangeMcpToolsetReference(
            "server_name"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaResponseToolAdditionBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolChangeToolDefinitionSerializationRoundtripWorks()
    {
        BetaResponseToolAdditionBlockTool value = new BetaToolChangeToolDefinition(
            new BetaResponseToolUnion(
                new BetaResponseTool()
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
                    AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
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
                    Type = BetaResponseToolType.Custom,
                }
            )
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaResponseToolAdditionBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaResponseToolAdditionBlockTool value = new(
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

        BetaResponseToolAdditionBlockTool emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Null(emptyValue.Name);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ServerName);

        BetaResponseToolAdditionBlockTool mismatchedValue = new(
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
