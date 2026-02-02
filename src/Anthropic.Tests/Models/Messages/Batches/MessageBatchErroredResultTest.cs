using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Tests.Models.Messages.Batches;

public class MessageBatchErroredResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageBatchErroredResult
        {
            Error = new() { Error = new InvalidRequestError("message"), RequestID = "request_id" },
        };

        ErrorResponse expectedError = new()
        {
            Error = new InvalidRequestError("message"),
            RequestID = "request_id",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("errored");

        Assert.Equal(expectedError, model.Error);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageBatchErroredResult
        {
            Error = new() { Error = new InvalidRequestError("message"), RequestID = "request_id" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageBatchErroredResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageBatchErroredResult
        {
            Error = new() { Error = new InvalidRequestError("message"), RequestID = "request_id" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageBatchErroredResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ErrorResponse expectedError = new()
        {
            Error = new InvalidRequestError("message"),
            RequestID = "request_id",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("errored");

        Assert.Equal(expectedError, deserialized.Error);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageBatchErroredResult
        {
            Error = new() { Error = new InvalidRequestError("message"), RequestID = "request_id" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageBatchErroredResult
        {
            Error = new() { Error = new InvalidRequestError("message"), RequestID = "request_id" },
        };

        MessageBatchErroredResult copied = new(model);

        Assert.Equal(model, copied);
    }
}
