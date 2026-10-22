using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebSearchToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebSearchToolResultBlock
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            Caller = new BetaDirectCaller(),
        };

        BetaWebSearchToolResultBlockContent expectedContent = new BetaWebSearchToolResultError(
            BetaWebSearchToolResultErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_c";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_tool_result");
        BetaWebSearchToolResultBlockCaller expectedCaller = new BetaDirectCaller();

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCaller, model.Caller);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWebSearchToolResultBlock
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            Caller = new BetaDirectCaller(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebSearchToolResultBlock
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            Caller = new BetaDirectCaller(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaWebSearchToolResultBlockContent expectedContent = new BetaWebSearchToolResultError(
            BetaWebSearchToolResultErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_c";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_tool_result");
        BetaWebSearchToolResultBlockCaller expectedCaller = new BetaDirectCaller();

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCaller, deserialized.Caller);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWebSearchToolResultBlock
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            Caller = new BetaDirectCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaWebSearchToolResultBlock
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaWebSearchToolResultBlock
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaWebSearchToolResultBlock
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaWebSearchToolResultBlock
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            Caller = new BetaDirectCaller(),
        } with
        {
            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaWebSearchToolResultBlock
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWebSearchToolResultBlock
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
            Caller = new BetaDirectCaller(),
        };

        BetaWebSearchToolResultBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaWebSearchToolResultBlockCallerTest : TestBase
{
    [Fact]
    public void BetaDirectValidationWorks()
    {
        BetaWebSearchToolResultBlockCaller value = new BetaDirectCaller();
        value.Validate();
    }

    [Fact]
    public void BetaServerToolValidationWorks()
    {
        BetaWebSearchToolResultBlockCaller value = new BetaServerToolCaller("srvtoolu_c");
        value.Validate();
    }

    [Fact]
    public void BetaServerToolCaller20260120ValidationWorks()
    {
        BetaWebSearchToolResultBlockCaller value = new BetaServerToolCaller20260120("srvtoolu_c");
        value.Validate();
    }

    [Fact]
    public void BetaDirectSerializationRoundtripWorks()
    {
        BetaWebSearchToolResultBlockCaller value = new BetaDirectCaller();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaServerToolSerializationRoundtripWorks()
    {
        BetaWebSearchToolResultBlockCaller value = new BetaServerToolCaller("srvtoolu_c");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaServerToolCaller20260120SerializationRoundtripWorks()
    {
        BetaWebSearchToolResultBlockCaller value = new BetaServerToolCaller20260120("srvtoolu_c");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaDirectTypeWorks()
    {
        BetaWebSearchToolResultBlockCaller value = new BetaDirectCaller();
        Assert.Equal(BetaWebSearchToolResultBlockCallerType.Direct, value.Type.Value());
    }

    [Fact]
    public void BetaServerToolTypeWorks()
    {
        BetaWebSearchToolResultBlockCaller value = new BetaServerToolCaller("srvtoolu_c");
        Assert.Equal(
            BetaWebSearchToolResultBlockCallerType.CodeExecution20250825,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaServerToolCaller20260120TypeWorks()
    {
        BetaWebSearchToolResultBlockCaller value = new BetaServerToolCaller20260120("srvtoolu_c");
        Assert.Equal(
            BetaWebSearchToolResultBlockCallerType.CodeExecution20260120,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaWebSearchToolResultBlockCaller value = new(
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

        ApiEnum<string, BetaWebSearchToolResultBlockCallerType> expectedType =
            BetaWebSearchToolResultBlockCallerType.Direct;
        string expectedToolID = "srvtoolu_c";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedToolID, value.ToolID);

        BetaWebSearchToolResultBlockCaller emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ToolID);

        BetaWebSearchToolResultBlockCaller mismatchedValue = new(
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

public class BetaWebSearchToolResultBlockCallerTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaWebSearchToolResultBlockCallerType.Direct)]
    [InlineData(BetaWebSearchToolResultBlockCallerType.CodeExecution20250825)]
    [InlineData(BetaWebSearchToolResultBlockCallerType.CodeExecution20260120)]
    public void Validation_Works(BetaWebSearchToolResultBlockCallerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWebSearchToolResultBlockCallerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebSearchToolResultBlockCallerType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaWebSearchToolResultBlockCallerType.Direct)]
    [InlineData(BetaWebSearchToolResultBlockCallerType.CodeExecution20250825)]
    [InlineData(BetaWebSearchToolResultBlockCallerType.CodeExecution20260120)]
    public void SerializationRoundtrip_Works(BetaWebSearchToolResultBlockCallerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWebSearchToolResultBlockCallerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebSearchToolResultBlockCallerType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebSearchToolResultBlockCallerType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebSearchToolResultBlockCallerType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
