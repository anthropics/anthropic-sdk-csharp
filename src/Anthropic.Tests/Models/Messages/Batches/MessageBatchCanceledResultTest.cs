using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Tests.Models.Messages.Batches;

public class MessageBatchCanceledResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageBatchCanceledResult { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("canceled");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageBatchCanceledResult { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageBatchCanceledResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageBatchCanceledResult { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageBatchCanceledResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("canceled");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageBatchCanceledResult { };

        model.Validate();
    }
}
