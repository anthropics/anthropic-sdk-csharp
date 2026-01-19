using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaInputJsonDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaInputJsonDelta { PartialJson = "partial_json" };

        string expectedPartialJson = "partial_json";
        JsonElement expectedType = JsonSerializer.SerializeToElement("input_json_delta");

        Assert.Equal(expectedPartialJson, model.PartialJson);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaInputJsonDelta { PartialJson = "partial_json" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaInputJsonDelta>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaInputJsonDelta { PartialJson = "partial_json" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaInputJsonDelta>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPartialJson = "partial_json";
        JsonElement expectedType = JsonSerializer.SerializeToElement("input_json_delta");

        Assert.Equal(expectedPartialJson, deserialized.PartialJson);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaInputJsonDelta { PartialJson = "partial_json" };

        model.Validate();
    }
}
