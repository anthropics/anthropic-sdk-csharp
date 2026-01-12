using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRedactedThinkingBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRedactedThinkingBlock { Data = "data" };

        string expectedData = "data";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\"");

        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRedactedThinkingBlock { Data = "data" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaRedactedThinkingBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRedactedThinkingBlock { Data = "data" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaRedactedThinkingBlock>(element);
        Assert.NotNull(deserialized);

        string expectedData = "data";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\"");

        Assert.Equal(expectedData, deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaRedactedThinkingBlock { Data = "data" };

        model.Validate();
    }
}
