using System.Text.Json;
using Anthropic.Models.Beta.Messages.Batches;

namespace Anthropic.Tests.Models.Beta.Messages.Batches;

public class BetaMessageBatchExpiredResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMessageBatchExpiredResult
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"expired\""),
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"expired\"");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
