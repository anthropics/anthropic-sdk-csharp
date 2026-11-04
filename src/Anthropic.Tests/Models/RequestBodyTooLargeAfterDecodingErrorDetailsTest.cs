using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class RequestBodyTooLargeAfterDecodingErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RequestBodyTooLargeAfterDecodingErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "request_body_too_large_after_decoding"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RequestBodyTooLargeAfterDecodingErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RequestBodyTooLargeAfterDecodingErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RequestBodyTooLargeAfterDecodingErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RequestBodyTooLargeAfterDecodingErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "request_body_too_large_after_decoding"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RequestBodyTooLargeAfterDecodingErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RequestBodyTooLargeAfterDecodingErrorDetails { };

        RequestBodyTooLargeAfterDecodingErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
