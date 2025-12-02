using System.Text.Json;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Tests.Models.Messages.Batches;

public class MessageBatchCanceledResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageBatchCanceledResult
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"canceled\""),
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"canceled\"");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
