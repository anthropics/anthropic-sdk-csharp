using System.Text.Json;
using Anthropic.Models.Beta.Messages.Batches;

namespace Anthropic.Tests.Models.Beta.Messages.Batches;

public class BetaMessageBatchExpiredResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMessageBatchExpiredResult { };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"expired\"");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMessageBatchExpiredResult { };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMessageBatchExpiredResult>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMessageBatchExpiredResult { };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMessageBatchExpiredResult>(element);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"expired\"");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMessageBatchExpiredResult { };

        model.Validate();
    }
}
