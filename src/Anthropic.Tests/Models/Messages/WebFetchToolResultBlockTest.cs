using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebFetchToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebFetchToolResultBlock
        {
            Caller = new DirectCaller(),
            Content = new WebFetchToolResultErrorBlock(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
        };

        WebFetchToolResultBlockCaller expectedCaller = new DirectCaller();
        WebFetchToolResultBlockContent expectedContent = new WebFetchToolResultErrorBlock(
            WebFetchToolResultErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_c";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_tool_result");

        Assert.Equal(expectedCaller, model.Caller);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebFetchToolResultBlock
        {
            Caller = new DirectCaller(),
            Content = new WebFetchToolResultErrorBlock(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchToolResultBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebFetchToolResultBlock
        {
            Caller = new DirectCaller(),
            Content = new WebFetchToolResultErrorBlock(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchToolResultBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WebFetchToolResultBlockCaller expectedCaller = new DirectCaller();
        WebFetchToolResultBlockContent expectedContent = new WebFetchToolResultErrorBlock(
            WebFetchToolResultErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_c";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_tool_result");

        Assert.Equal(expectedCaller, deserialized.Caller);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebFetchToolResultBlock
        {
            Caller = new DirectCaller(),
            Content = new WebFetchToolResultErrorBlock(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebFetchToolResultBlock
        {
            Caller = new DirectCaller(),
            Content = new WebFetchToolResultErrorBlock(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_c",
        };

        WebFetchToolResultBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebFetchToolResultBlockCallerTest : TestBase
{
    [Fact]
    public void DirectValidationWorks()
    {
        WebFetchToolResultBlockCaller value = new DirectCaller();
        value.Validate();
    }

    [Fact]
    public void ServerToolValidationWorks()
    {
        WebFetchToolResultBlockCaller value = new ServerToolCaller("srvtoolu_c");
        value.Validate();
    }

    [Fact]
    public void ServerToolCaller20260120ValidationWorks()
    {
        WebFetchToolResultBlockCaller value = new ServerToolCaller20260120("srvtoolu_c");
        value.Validate();
    }

    [Fact]
    public void DirectSerializationRoundtripWorks()
    {
        WebFetchToolResultBlockCaller value = new DirectCaller();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchToolResultBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolSerializationRoundtripWorks()
    {
        WebFetchToolResultBlockCaller value = new ServerToolCaller("srvtoolu_c");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchToolResultBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolCaller20260120SerializationRoundtripWorks()
    {
        WebFetchToolResultBlockCaller value = new ServerToolCaller20260120("srvtoolu_c");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchToolResultBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DirectTypeWorks()
    {
        WebFetchToolResultBlockCaller value = new DirectCaller();
        Assert.Equal(WebFetchToolResultBlockCallerType.Direct, value.Type.Value());
    }

    [Fact]
    public void ServerToolTypeWorks()
    {
        WebFetchToolResultBlockCaller value = new ServerToolCaller("srvtoolu_c");
        Assert.Equal(WebFetchToolResultBlockCallerType.CodeExecution20250825, value.Type.Value());
    }

    [Fact]
    public void ServerToolCaller20260120TypeWorks()
    {
        WebFetchToolResultBlockCaller value = new ServerToolCaller20260120("srvtoolu_c");
        Assert.Equal(WebFetchToolResultBlockCallerType.CodeExecution20260120, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        WebFetchToolResultBlockCaller value = new(
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

        ApiEnum<string, WebFetchToolResultBlockCallerType> expectedType =
            WebFetchToolResultBlockCallerType.Direct;
        string expectedToolID = "srvtoolu_c";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedToolID, value.ToolID);

        WebFetchToolResultBlockCaller emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ToolID);

        WebFetchToolResultBlockCaller mismatchedValue = new(
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

public class WebFetchToolResultBlockCallerTypeTest : TestBase
{
    [Theory]
    [InlineData(WebFetchToolResultBlockCallerType.Direct)]
    [InlineData(WebFetchToolResultBlockCallerType.CodeExecution20250825)]
    [InlineData(WebFetchToolResultBlockCallerType.CodeExecution20260120)]
    public void Validation_Works(WebFetchToolResultBlockCallerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebFetchToolResultBlockCallerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebFetchToolResultBlockCallerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebFetchToolResultBlockCallerType.Direct)]
    [InlineData(WebFetchToolResultBlockCallerType.CodeExecution20250825)]
    [InlineData(WebFetchToolResultBlockCallerType.CodeExecution20260120)]
    public void SerializationRoundtrip_Works(WebFetchToolResultBlockCallerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebFetchToolResultBlockCallerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebFetchToolResultBlockCallerType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebFetchToolResultBlockCallerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebFetchToolResultBlockCallerType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class WebFetchToolResultBlockContentTest : TestBase
{
    [Fact]
    public void WebFetchToolResultErrorBlockValidationWorks()
    {
        WebFetchToolResultBlockContent value = new WebFetchToolResultErrorBlock(
            WebFetchToolResultErrorCode.InvalidToolInput
        );
        value.Validate();
    }

    [Fact]
    public void WebFetchBlockValidationWorks()
    {
        WebFetchToolResultBlockContent value = new WebFetchBlock()
        {
            Content = new()
            {
                Citations = new(true),
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                Title = "title",
            },
            RetrievedAt = "retrieved_at",
            Url = "url",
        };
        value.Validate();
    }

    [Fact]
    public void WebFetchToolResultErrorBlockSerializationRoundtripWorks()
    {
        WebFetchToolResultBlockContent value = new WebFetchToolResultErrorBlock(
            WebFetchToolResultErrorCode.InvalidToolInput
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchToolResultBlockContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchBlockSerializationRoundtripWorks()
    {
        WebFetchToolResultBlockContent value = new WebFetchBlock()
        {
            Content = new()
            {
                Citations = new(true),
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                Title = "title",
            },
            RetrievedAt = "retrieved_at",
            Url = "url",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchToolResultBlockContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        WebFetchToolResultBlockContent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "web_fetch_tool_result_error"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_tool_result_error");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        WebFetchToolResultBlockContent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
