using System.Text.Json;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Tests.Models.Messages.Batches;

public class MessageBatchExpiredResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageBatchExpiredResult
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"expired\""),
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"expired\"");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
