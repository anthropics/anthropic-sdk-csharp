using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaFallbackBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaFallbackBlock
        {
            From = new(Model.ClaudeSonnet5),
            To = new(Model.ClaudeSonnet5),
            Trigger = new(BetaFallbackRefusalTriggerCategory.Cyber),
        };

        BetaFallbackInfo expectedFrom = new(Model.ClaudeSonnet5);
        BetaFallbackInfo expectedTo = new(Model.ClaudeSonnet5);
        BetaFallbackRefusalTrigger expectedTrigger = new(BetaFallbackRefusalTriggerCategory.Cyber);
        JsonElement expectedType = JsonSerializer.SerializeToElement("fallback");

        Assert.Equal(expectedFrom, model.From);
        Assert.Equal(expectedTo, model.To);
        Assert.Equal(expectedTrigger, model.Trigger);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaFallbackBlock
        {
            From = new(Model.ClaudeSonnet5),
            To = new(Model.ClaudeSonnet5),
            Trigger = new(BetaFallbackRefusalTriggerCategory.Cyber),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbackBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaFallbackBlock
        {
            From = new(Model.ClaudeSonnet5),
            To = new(Model.ClaudeSonnet5),
            Trigger = new(BetaFallbackRefusalTriggerCategory.Cyber),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbackBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaFallbackInfo expectedFrom = new(Model.ClaudeSonnet5);
        BetaFallbackInfo expectedTo = new(Model.ClaudeSonnet5);
        BetaFallbackRefusalTrigger expectedTrigger = new(BetaFallbackRefusalTriggerCategory.Cyber);
        JsonElement expectedType = JsonSerializer.SerializeToElement("fallback");

        Assert.Equal(expectedFrom, deserialized.From);
        Assert.Equal(expectedTo, deserialized.To);
        Assert.Equal(expectedTrigger, deserialized.Trigger);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaFallbackBlock
        {
            From = new(Model.ClaudeSonnet5),
            To = new(Model.ClaudeSonnet5),
            Trigger = new(BetaFallbackRefusalTriggerCategory.Cyber),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaFallbackBlock
        {
            From = new(Model.ClaudeSonnet5),
            To = new(Model.ClaudeSonnet5),
            Trigger = new(BetaFallbackRefusalTriggerCategory.Cyber),
        };

        BetaFallbackBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
