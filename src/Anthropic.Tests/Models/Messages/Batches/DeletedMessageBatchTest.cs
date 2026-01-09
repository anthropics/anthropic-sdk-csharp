using System.Text.Json;
using Anthropic.Models.Messages.Batches;

namespace Anthropic.Tests.Models.Messages.Batches;

public class DeletedMessageBatchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeletedMessageBatch { ID = "msgbatch_013Zva2CMHLNnXjNJJKqJ2EF" };

        string expectedID = "msgbatch_013Zva2CMHLNnXjNJJKqJ2EF";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"message_batch_deleted\""
        );

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeletedMessageBatch { ID = "msgbatch_013Zva2CMHLNnXjNJJKqJ2EF" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DeletedMessageBatch>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeletedMessageBatch { ID = "msgbatch_013Zva2CMHLNnXjNJJKqJ2EF" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DeletedMessageBatch>(element);
        Assert.NotNull(deserialized);

        string expectedID = "msgbatch_013Zva2CMHLNnXjNJJKqJ2EF";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"message_batch_deleted\""
        );

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeletedMessageBatch { ID = "msgbatch_013Zva2CMHLNnXjNJJKqJ2EF" };

        model.Validate();
    }
}
