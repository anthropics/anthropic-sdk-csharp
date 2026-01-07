using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class InputJsonDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InputJsonDelta { PartialJson = "partial_json" };

        string expectedPartialJson = "partial_json";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\"");

        Assert.Equal(expectedPartialJson, model.PartialJson);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InputJsonDelta { PartialJson = "partial_json" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InputJsonDelta>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InputJsonDelta { PartialJson = "partial_json" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InputJsonDelta>(element);
        Assert.NotNull(deserialized);

        string expectedPartialJson = "partial_json";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\"");

        Assert.Equal(expectedPartialJson, deserialized.PartialJson);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InputJsonDelta { PartialJson = "partial_json" };

        model.Validate();
    }
}
