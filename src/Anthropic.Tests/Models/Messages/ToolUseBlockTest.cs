using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolUseBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            ToolsetName = "toolset_name",
        };

        string expectedID = "id";
        ToolUseBlockCaller expectedCaller = new DirectCaller();
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");
        string expectedToolsetName = "toolset_name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCaller, model.Caller);
        Assert.Equal(expectedInput.Count, model.Input.Count);
        foreach (var item in expectedInput)
        {
            Assert.True(model.Input.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Input[item.Key]));
        }
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedToolsetName, model.ToolsetName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            ToolsetName = "toolset_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            ToolsetName = "toolset_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ToolUseBlockCaller expectedCaller = new DirectCaller();
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");
        string expectedToolsetName = "toolset_name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCaller, deserialized.Caller);
        Assert.Equal(expectedInput.Count, deserialized.Input.Count);
        foreach (var item in expectedInput)
        {
            Assert.True(deserialized.Input.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Input[item.Key]));
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedToolsetName, deserialized.ToolsetName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            ToolsetName = "toolset_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
        };

        Assert.Null(model.ToolsetName);
        Assert.False(model.RawData.ContainsKey("toolset_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",

            ToolsetName = null,
        };

        Assert.Null(model.ToolsetName);
        Assert.True(model.RawData.ContainsKey("toolset_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",

            ToolsetName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            ToolsetName = "toolset_name",
        };

        ToolUseBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ToolUseBlockCallerTest : TestBase
{
    [Fact]
    public void DirectValidationWorks()
    {
        ToolUseBlockCaller value = new DirectCaller();
        value.Validate();
    }

    [Fact]
    public void ServerToolValidationWorks()
    {
        ToolUseBlockCaller value = new ServerToolCaller("srvtoolu_c");
        value.Validate();
    }

    [Fact]
    public void ServerToolCaller20260120ValidationWorks()
    {
        ToolUseBlockCaller value = new ServerToolCaller20260120("srvtoolu_c");
        value.Validate();
    }

    [Fact]
    public void DirectSerializationRoundtripWorks()
    {
        ToolUseBlockCaller value = new DirectCaller();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolSerializationRoundtripWorks()
    {
        ToolUseBlockCaller value = new ServerToolCaller("srvtoolu_c");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolCaller20260120SerializationRoundtripWorks()
    {
        ToolUseBlockCaller value = new ServerToolCaller20260120("srvtoolu_c");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DirectTypeWorks()
    {
        ToolUseBlockCaller value = new DirectCaller();
        Assert.Equal(ToolUseBlockCallerType.Direct, value.Type.Value());
    }

    [Fact]
    public void ServerToolTypeWorks()
    {
        ToolUseBlockCaller value = new ServerToolCaller("srvtoolu_c");
        Assert.Equal(ToolUseBlockCallerType.CodeExecution20250825, value.Type.Value());
    }

    [Fact]
    public void ServerToolCaller20260120TypeWorks()
    {
        ToolUseBlockCaller value = new ServerToolCaller20260120("srvtoolu_c");
        Assert.Equal(ToolUseBlockCallerType.CodeExecution20260120, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ToolUseBlockCaller value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "direct",
                  "tool_id": "srvtoolu_c"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, ToolUseBlockCallerType> expectedType = ToolUseBlockCallerType.Direct;
        string expectedToolID = "srvtoolu_c";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedToolID, value.ToolID);

        ToolUseBlockCaller emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ToolID);

        ToolUseBlockCaller mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "tool_id": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.ToolID);
    }
}

public class ToolUseBlockCallerTypeTest : TestBase
{
    [Theory]
    [InlineData(ToolUseBlockCallerType.Direct)]
    [InlineData(ToolUseBlockCallerType.CodeExecution20250825)]
    [InlineData(ToolUseBlockCallerType.CodeExecution20260120)]
    public void Validation_Works(ToolUseBlockCallerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolUseBlockCallerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolUseBlockCallerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ToolUseBlockCallerType.Direct)]
    [InlineData(ToolUseBlockCallerType.CodeExecution20250825)]
    [InlineData(ToolUseBlockCallerType.CodeExecution20260120)]
    public void SerializationRoundtrip_Works(ToolUseBlockCallerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolUseBlockCallerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolUseBlockCallerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolUseBlockCallerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolUseBlockCallerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
