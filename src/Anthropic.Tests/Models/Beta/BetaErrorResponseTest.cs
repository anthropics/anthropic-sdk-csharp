using System.Text.Json;
using Anthropic.Models.Beta;

namespace Anthropic.Tests.Models.Beta;

public class BetaErrorResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaErrorResponse
        {
            Error = new BetaInvalidRequestError("message"),
            RequestID = "request_id",
        };

        BetaError expectedError = new BetaInvalidRequestError("message");
        string expectedRequestID = "request_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"error\"");

        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedRequestID, model.RequestID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaErrorResponse
        {
            Error = new BetaInvalidRequestError("message"),
            RequestID = "request_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaErrorResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaErrorResponse
        {
            Error = new BetaInvalidRequestError("message"),
            RequestID = "request_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaErrorResponse>(element);
        Assert.NotNull(deserialized);

        BetaError expectedError = new BetaInvalidRequestError("message");
        string expectedRequestID = "request_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"error\"");

        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedRequestID, deserialized.RequestID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaErrorResponse
        {
            Error = new BetaInvalidRequestError("message"),
            RequestID = "request_id",
        };

        model.Validate();
    }
}
