using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebSearchToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebSearchToolResultBlock
        {
            Caller = new DirectCaller(),
            Content = new WebSearchToolResultError(WebSearchToolResultErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_c",
        };

        WebSearchToolResultBlockCaller expectedCaller = new DirectCaller();
        WebSearchToolResultBlockContent expectedContent = new WebSearchToolResultError(
            WebSearchToolResultErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_c";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_tool_result");

        Assert.Equal(expectedCaller, model.Caller);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebSearchToolResultBlock
        {
            Caller = new DirectCaller(),
            Content = new WebSearchToolResultError(WebSearchToolResultErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_c",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebSearchToolResultBlock
        {
            Caller = new DirectCaller(),
            Content = new WebSearchToolResultError(WebSearchToolResultErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_c",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WebSearchToolResultBlockCaller expectedCaller = new DirectCaller();
        WebSearchToolResultBlockContent expectedContent = new WebSearchToolResultError(
            WebSearchToolResultErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_c";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_tool_result");

        Assert.Equal(expectedCaller, deserialized.Caller);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebSearchToolResultBlock
        {
            Caller = new DirectCaller(),
            Content = new WebSearchToolResultError(WebSearchToolResultErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_c",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebSearchToolResultBlock
        {
            Caller = new DirectCaller(),
            Content = new WebSearchToolResultError(WebSearchToolResultErrorCode.InvalidToolInput),
            ToolUseID = "srvtoolu_c",
        };

        WebSearchToolResultBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebSearchToolResultBlockCallerTest : TestBase
{
    [Fact]
    public void DirectValidationWorks()
    {
        WebSearchToolResultBlockCaller value = new DirectCaller();
        value.Validate();
    }

    [Fact]
    public void ServerToolValidationWorks()
    {
        WebSearchToolResultBlockCaller value = new ServerToolCaller("srvtoolu_c");
        value.Validate();
    }

    [Fact]
    public void ServerToolCaller20260120ValidationWorks()
    {
        WebSearchToolResultBlockCaller value = new ServerToolCaller20260120("srvtoolu_c");
        value.Validate();
    }

    [Fact]
    public void DirectSerializationRoundtripWorks()
    {
        WebSearchToolResultBlockCaller value = new DirectCaller();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolSerializationRoundtripWorks()
    {
        WebSearchToolResultBlockCaller value = new ServerToolCaller("srvtoolu_c");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolCaller20260120SerializationRoundtripWorks()
    {
        WebSearchToolResultBlockCaller value = new ServerToolCaller20260120("srvtoolu_c");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DirectTypeWorks()
    {
        WebSearchToolResultBlockCaller value = new DirectCaller();
        Assert.Equal(WebSearchToolResultBlockCallerType.Direct, value.Type.Value());
    }

    [Fact]
    public void ServerToolTypeWorks()
    {
        WebSearchToolResultBlockCaller value = new ServerToolCaller("srvtoolu_c");
        Assert.Equal(WebSearchToolResultBlockCallerType.CodeExecution20250825, value.Type.Value());
    }

    [Fact]
    public void ServerToolCaller20260120TypeWorks()
    {
        WebSearchToolResultBlockCaller value = new ServerToolCaller20260120("srvtoolu_c");
        Assert.Equal(WebSearchToolResultBlockCallerType.CodeExecution20260120, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        WebSearchToolResultBlockCaller value = new(
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

        ApiEnum<string, WebSearchToolResultBlockCallerType> expectedType =
            WebSearchToolResultBlockCallerType.Direct;
        string expectedToolID = "srvtoolu_c";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedToolID, value.ToolID);

        WebSearchToolResultBlockCaller emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ToolID);

        WebSearchToolResultBlockCaller mismatchedValue = new(
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

public class WebSearchToolResultBlockCallerTypeTest : TestBase
{
    [Theory]
    [InlineData(WebSearchToolResultBlockCallerType.Direct)]
    [InlineData(WebSearchToolResultBlockCallerType.CodeExecution20250825)]
    [InlineData(WebSearchToolResultBlockCallerType.CodeExecution20260120)]
    public void Validation_Works(WebSearchToolResultBlockCallerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebSearchToolResultBlockCallerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebSearchToolResultBlockCallerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebSearchToolResultBlockCallerType.Direct)]
    [InlineData(WebSearchToolResultBlockCallerType.CodeExecution20250825)]
    [InlineData(WebSearchToolResultBlockCallerType.CodeExecution20260120)]
    public void SerializationRoundtrip_Works(WebSearchToolResultBlockCallerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebSearchToolResultBlockCallerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebSearchToolResultBlockCallerType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebSearchToolResultBlockCallerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebSearchToolResultBlockCallerType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
