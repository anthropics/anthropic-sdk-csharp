using System.Text.Json;
using Anthropic.Models.Beta.Messages.Batches;

namespace Anthropic.Tests.Models.Beta.Messages.Batches;

public class BetaMessageBatchCanceledResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMessageBatchCanceledResult { };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"canceled\"");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMessageBatchCanceledResult { };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMessageBatchCanceledResult>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMessageBatchCanceledResult { };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMessageBatchCanceledResult>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"canceled\"");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMessageBatchCanceledResult { };

        model.Validate();
    }
}
