using System.Text.Json;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Tests.Models.Messages.Batches;

public class MessageBatchCanceledResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageBatchCanceledResult { };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"canceled\"");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageBatchCanceledResult { };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MessageBatchCanceledResult>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageBatchCanceledResult { };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MessageBatchCanceledResult>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"canceled\"");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageBatchCanceledResult { };

        model.Validate();
    }
}
