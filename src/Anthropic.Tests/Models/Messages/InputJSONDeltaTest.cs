using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class InputJSONDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InputJSONDelta { PartialJSON = "partial_json" };

        string expectedPartialJSON = "partial_json";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\"");

        Assert.Equal(expectedPartialJSON, model.PartialJSON);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InputJSONDelta { PartialJSON = "partial_json" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InputJSONDelta>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InputJSONDelta { PartialJSON = "partial_json" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InputJSONDelta>(element);
        Assert.NotNull(deserialized);

        string expectedPartialJSON = "partial_json";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\"");

        Assert.Equal(expectedPartialJSON, deserialized.PartialJSON);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InputJSONDelta { PartialJSON = "partial_json" };

        model.Validate();
    }
}
