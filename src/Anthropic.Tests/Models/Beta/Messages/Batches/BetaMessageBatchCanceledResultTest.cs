using System.Text.Json;
using Anthropic.Models.Beta.Messages.Batches;

namespace Anthropic.Tests.Models.Beta.Messages.Batches;

public class BetaMessageBatchCanceledResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMessageBatchCanceledResult
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"canceled\""),
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"canceled\"");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
