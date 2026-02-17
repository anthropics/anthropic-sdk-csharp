using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebFetchToolResultErrorBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebFetchToolResultErrorBlockParam
        {
            ErrorCode = WebFetchToolResultErrorCode.InvalidToolInput,
        };

        ApiEnum<string, WebFetchToolResultErrorCode> expectedErrorCode =
            WebFetchToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_tool_result_error");

        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebFetchToolResultErrorBlockParam
        {
            ErrorCode = WebFetchToolResultErrorCode.InvalidToolInput,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchToolResultErrorBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebFetchToolResultErrorBlockParam
        {
            ErrorCode = WebFetchToolResultErrorCode.InvalidToolInput,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchToolResultErrorBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, WebFetchToolResultErrorCode> expectedErrorCode =
            WebFetchToolResultErrorCode.InvalidToolInput;
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_tool_result_error");

        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebFetchToolResultErrorBlockParam
        {
            ErrorCode = WebFetchToolResultErrorCode.InvalidToolInput,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebFetchToolResultErrorBlockParam
        {
            ErrorCode = WebFetchToolResultErrorCode.InvalidToolInput,
        };

        WebFetchToolResultErrorBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
