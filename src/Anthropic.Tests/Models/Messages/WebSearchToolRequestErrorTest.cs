using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebSearchToolRequestErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebSearchToolRequestError { ErrorCode = ErrorCode.InvalidToolInput };

        ApiEnum<string, ErrorCode> expectedErrorCode = ErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebSearchToolRequestError { ErrorCode = ErrorCode.InvalidToolInput };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolRequestError>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebSearchToolRequestError { ErrorCode = ErrorCode.InvalidToolInput };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolRequestError>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, ErrorCode> expectedErrorCode = ErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebSearchToolRequestError { ErrorCode = ErrorCode.InvalidToolInput };

        model.Validate();
    }
}
