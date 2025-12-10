using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebSearchToolResultErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebSearchToolResultError
        {
            ErrorCode = WebSearchToolResultErrorErrorCode.InvalidToolInput,
        };

        ApiEnum<string, WebSearchToolResultErrorErrorCode> expectedErrorCode =
            WebSearchToolResultErrorErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebSearchToolResultError
        {
            ErrorCode = WebSearchToolResultErrorErrorCode.InvalidToolInput,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultError>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebSearchToolResultError
        {
            ErrorCode = WebSearchToolResultErrorErrorCode.InvalidToolInput,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultError>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, WebSearchToolResultErrorErrorCode> expectedErrorCode =
            WebSearchToolResultErrorErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebSearchToolResultError
        {
            ErrorCode = WebSearchToolResultErrorErrorCode.InvalidToolInput,
        };

        model.Validate();
    }
}

public class WebSearchToolResultErrorErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(WebSearchToolResultErrorErrorCode.InvalidToolInput)]
    [InlineData(WebSearchToolResultErrorErrorCode.Unavailable)]
    [InlineData(WebSearchToolResultErrorErrorCode.MaxUsesExceeded)]
    [InlineData(WebSearchToolResultErrorErrorCode.TooManyRequests)]
    [InlineData(WebSearchToolResultErrorErrorCode.QueryTooLong)]
    public void Validation_Works(WebSearchToolResultErrorErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebSearchToolResultErrorErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebSearchToolResultErrorErrorCode>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebSearchToolResultErrorErrorCode.InvalidToolInput)]
    [InlineData(WebSearchToolResultErrorErrorCode.Unavailable)]
    [InlineData(WebSearchToolResultErrorErrorCode.MaxUsesExceeded)]
    [InlineData(WebSearchToolResultErrorErrorCode.TooManyRequests)]
    [InlineData(WebSearchToolResultErrorErrorCode.QueryTooLong)]
    public void SerializationRoundtrip_Works(WebSearchToolResultErrorErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebSearchToolResultErrorErrorCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebSearchToolResultErrorErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebSearchToolResultErrorErrorCode>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebSearchToolResultErrorErrorCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
