using System.Text.Json;
using Anthropic.Models.Beta.Messages.Batches;

namespace Anthropic.Tests.Models.Beta.Messages.Batches;

public class BetaDeletedMessageBatchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDeletedMessageBatch
        {
            ID = "msgbatch_013Zva2CMHLNnXjNJJKqJ2EF",
            Type = JsonSerializer.Deserialize<JsonElement>("\"message_batch_deleted\""),
        };

        string expectedID = "msgbatch_013Zva2CMHLNnXjNJJKqJ2EF";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"message_batch_deleted\""
        );

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
