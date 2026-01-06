using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebSearchToolResultErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebSearchToolResultError
        {
            ErrorCode = BetaWebSearchToolResultErrorCode.InvalidToolInput,
        };

        ApiEnum<string, BetaWebSearchToolResultErrorCode> expectedErrorCode =
            BetaWebSearchToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWebSearchToolResultError
        {
            ErrorCode = BetaWebSearchToolResultErrorCode.InvalidToolInput,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultError>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebSearchToolResultError
        {
            ErrorCode = BetaWebSearchToolResultErrorCode.InvalidToolInput,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultError>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaWebSearchToolResultErrorCode> expectedErrorCode =
            BetaWebSearchToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWebSearchToolResultError
        {
            ErrorCode = BetaWebSearchToolResultErrorCode.InvalidToolInput,
        };

        model.Validate();
    }
}
