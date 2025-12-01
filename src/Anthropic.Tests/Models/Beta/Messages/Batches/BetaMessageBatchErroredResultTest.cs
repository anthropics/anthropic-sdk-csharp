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
            Type = JsonSerializer.Deserialize<JsonElement>("\"errored\""),
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
}
