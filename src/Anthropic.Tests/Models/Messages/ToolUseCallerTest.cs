using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolUseCallerTest : TestBase
{
    [Fact]
    public void DirectValidationWorks()
    {
        ToolUseCaller value = new DirectCaller();
        value.Validate();
    }

    [Fact]
    public void ServerToolValidationWorks()
    {
        ToolUseCaller value = new ServerToolCaller("srvtoolu_c");
        value.Validate();
    }

    [Fact]
    public void ServerToolCaller20260120ValidationWorks()
    {
        ToolUseCaller value = new ServerToolCaller20260120("srvtoolu_c");
        value.Validate();
    }

    [Fact]
    public void DirectSerializationRoundtripWorks()
    {
        ToolUseCaller value = new DirectCaller();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolSerializationRoundtripWorks()
    {
        ToolUseCaller value = new ServerToolCaller("srvtoolu_c");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolCaller20260120SerializationRoundtripWorks()
    {
        ToolUseCaller value = new ServerToolCaller20260120("srvtoolu_c");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DirectTypeWorks()
    {
        ToolUseCaller value = new DirectCaller();
        Assert.Equal(ToolUseCallerType.Direct, value.Type.Value());
    }

    [Fact]
    public void ServerToolTypeWorks()
    {
        ToolUseCaller value = new ServerToolCaller("srvtoolu_c");
        Assert.Equal(ToolUseCallerType.CodeExecution20250825, value.Type.Value());
    }

    [Fact]
    public void ServerToolCaller20260120TypeWorks()
    {
        ToolUseCaller value = new ServerToolCaller20260120("srvtoolu_c");
        Assert.Equal(ToolUseCallerType.CodeExecution20260120, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ToolUseCaller value = new(
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

        ApiEnum<string, ToolUseCallerType> expectedType = ToolUseCallerType.Direct;
        string expectedToolID = "srvtoolu_c";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedToolID, value.ToolID);

        ToolUseCaller emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ToolID);

        ToolUseCaller mismatchedValue = new(
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

public class ToolUseCallerTypeTest : TestBase
{
    [Theory]
    [InlineData(ToolUseCallerType.Direct)]
    [InlineData(ToolUseCallerType.CodeExecution20250825)]
    [InlineData(ToolUseCallerType.CodeExecution20260120)]
    public void Validation_Works(ToolUseCallerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolUseCallerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolUseCallerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ToolUseCallerType.Direct)]
    [InlineData(ToolUseCallerType.CodeExecution20250825)]
    [InlineData(ToolUseCallerType.CodeExecution20260120)]
    public void SerializationRoundtrip_Works(ToolUseCallerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolUseCallerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolUseCallerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolUseCallerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolUseCallerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
