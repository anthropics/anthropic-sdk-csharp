using System.Text.Json;
using Anthropic.Core;
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
        JsonElement expectedType = JsonSerializer.SerializeToElement("error");

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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaErrorResponse>(
            json,
            ModelBase.SerializerOptions
        );

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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaErrorResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaError expectedError = new BetaInvalidRequestError("message");
        string expectedRequestID = "request_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("error");

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

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaErrorResponse
        {
            Error = new BetaInvalidRequestError("message"),
            RequestID = "request_id",
        };

        BetaErrorResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
