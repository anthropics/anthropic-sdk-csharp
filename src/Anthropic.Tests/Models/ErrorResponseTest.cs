using System.Text.Json;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class ErrorResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ErrorResponse
        {
            Error = new InvalidRequestError("message"),
            RequestID = "request_id",
        };

        ErrorObject expectedError = new InvalidRequestError("message");
        string expectedRequestID = "request_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"error\"");

        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedRequestID, model.RequestID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ErrorResponse
        {
            Error = new InvalidRequestError("message"),
            RequestID = "request_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ErrorResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ErrorResponse
        {
            Error = new InvalidRequestError("message"),
            RequestID = "request_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ErrorResponse>(json);
        Assert.NotNull(deserialized);

        ErrorObject expectedError = new InvalidRequestError("message");
        string expectedRequestID = "request_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"error\"");

        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedRequestID, deserialized.RequestID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ErrorResponse
        {
            Error = new InvalidRequestError("message"),
            RequestID = "request_id",
        };

        model.Validate();
    }
}
