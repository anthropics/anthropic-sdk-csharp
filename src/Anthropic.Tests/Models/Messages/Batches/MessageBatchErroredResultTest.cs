using System.Text.Json;
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
            Type = JsonSerializer.Deserialize<JsonElement>("\"errored\""),
        };

        ErrorResponse expectedError = new()
        {
            Error = new InvalidRequestError("message"),
            RequestID = "request_id",
        };
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"errored\"");

        Assert.Equal(expectedError, model.Error);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
