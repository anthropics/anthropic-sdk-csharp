using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class RedactedThinkingBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RedactedThinkingBlockParam { Data = "data" };

        string expectedData = "data";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\"");

        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RedactedThinkingBlockParam { Data = "data" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RedactedThinkingBlockParam>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RedactedThinkingBlockParam { Data = "data" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RedactedThinkingBlockParam>(element);
        Assert.NotNull(deserialized);

        string expectedData = "data";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\"");

        Assert.Equal(expectedData, deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RedactedThinkingBlockParam { Data = "data" };

        model.Validate();
    }
}
