using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolSearchToolResultErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolSearchToolResultError
        {
            ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        ApiEnum<string, BetaToolSearchToolResultErrorErrorCode> expectedErrorCode =
            BetaToolSearchToolResultErrorErrorCode.InvalidToolInput;
        string expectedErrorMessage = "error_message";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"tool_search_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaToolSearchToolResultError
        {
            ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultError>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaToolSearchToolResultError
        {
            ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultError>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaToolSearchToolResultErrorErrorCode> expectedErrorCode =
            BetaToolSearchToolResultErrorErrorCode.InvalidToolInput;
        string expectedErrorMessage = "error_message";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"tool_search_tool_result_error\""
        );

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaToolSearchToolResultError
        {
            ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };

        model.Validate();
    }
}
