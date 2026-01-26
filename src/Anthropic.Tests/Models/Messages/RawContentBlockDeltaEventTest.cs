using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class RawContentBlockDeltaEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RawContentBlockDeltaEvent { Delta = new TextDelta("text"), Index = 0 };

        RawContentBlockDelta expectedDelta = new TextDelta("text");
        long expectedIndex = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("content_block_delta");

        Assert.Equal(expectedDelta, model.Delta);
        Assert.Equal(expectedIndex, model.Index);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RawContentBlockDeltaEvent { Delta = new TextDelta("text"), Index = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockDeltaEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RawContentBlockDeltaEvent { Delta = new TextDelta("text"), Index = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RawContentBlockDeltaEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        RawContentBlockDelta expectedDelta = new TextDelta("text");
        long expectedIndex = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("content_block_delta");

        Assert.Equal(expectedDelta, deserialized.Delta);
        Assert.Equal(expectedIndex, deserialized.Index);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RawContentBlockDeltaEvent { Delta = new TextDelta("text"), Index = 0 };

        model.Validate();
    }
}
