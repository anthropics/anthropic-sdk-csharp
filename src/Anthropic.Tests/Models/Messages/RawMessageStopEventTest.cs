using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class RawMessageStopEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RawMessageStopEvent { };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"message_stop\"");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RawMessageStopEvent { };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RawMessageStopEvent>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RawMessageStopEvent { };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RawMessageStopEvent>(element);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"message_stop\"");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RawMessageStopEvent { };

        model.Validate();
    }
}
