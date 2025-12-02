using System.Text.Json;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Messages.Batches;

namespace Anthropic.Tests.Models.Beta.Messages.Batches;

public class BetaMessageBatchErroredResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMessageBatchErroredResult
        {
            Error = new()
            {
                Error = new BetaInvalidRequestError("message"),
                RequestID = "request_id",
            },
        };

        BetaErrorResponse expectedError = new()
        {
            Error = new BetaInvalidRequestError("message"),
            RequestID = "request_id",
        };
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"errored\"");

        Assert.Equal(expectedError, model.Error);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMessageBatchErroredResult
        {
            Error = new()
            {
                Error = new BetaInvalidRequestError("message"),
                RequestID = "request_id",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMessageBatchErroredResult>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMessageBatchErroredResult
        {
            Error = new()
            {
                Error = new BetaInvalidRequestError("message"),
                RequestID = "request_id",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMessageBatchErroredResult>(json);
        Assert.NotNull(deserialized);

        BetaErrorResponse expectedError = new()
        {
            Error = new BetaInvalidRequestError("message"),
            RequestID = "request_id",
        };
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"errored\"");

        Assert.Equal(expectedError, deserialized.Error);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMessageBatchErroredResult
        {
            Error = new()
            {
                Error = new BetaInvalidRequestError("message"),
                RequestID = "request_id",
            },
        };

        model.Validate();
    }
}
