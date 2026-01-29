using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebFetchToolResultErrorBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebFetchToolResultErrorBlockParam
        {
            ErrorCode = BetaWebFetchToolResultErrorCode.InvalidToolInput,
        };

        ApiEnum<string, BetaWebFetchToolResultErrorCode> expectedErrorCode =
            BetaWebFetchToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_tool_result_error");

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWebFetchToolResultErrorBlockParam
        {
            ErrorCode = BetaWebFetchToolResultErrorCode.InvalidToolInput,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultErrorBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebFetchToolResultErrorBlockParam
        {
            ErrorCode = BetaWebFetchToolResultErrorCode.InvalidToolInput,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultErrorBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaWebFetchToolResultErrorCode> expectedErrorCode =
            BetaWebFetchToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_tool_result_error");

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWebFetchToolResultErrorBlockParam
        {
            ErrorCode = BetaWebFetchToolResultErrorCode.InvalidToolInput,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWebFetchToolResultErrorBlockParam
        {
            ErrorCode = BetaWebFetchToolResultErrorCode.InvalidToolInput,
        };

        BetaWebFetchToolResultErrorBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
