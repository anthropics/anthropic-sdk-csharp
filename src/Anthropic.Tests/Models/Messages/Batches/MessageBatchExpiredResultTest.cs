using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Tests.Models.Messages.Batches;

public class MessageBatchExpiredResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageBatchExpiredResult { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("expired");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageBatchExpiredResult { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageBatchExpiredResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageBatchExpiredResult { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageBatchExpiredResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("expired");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageBatchExpiredResult { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageBatchExpiredResult { };

        MessageBatchExpiredResult copied = new(model);

        Assert.Equal(model, copied);
    }
}
