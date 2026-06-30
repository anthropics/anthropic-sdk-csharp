using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaFallbackBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaFallbackBlockParam
        {
            From = new(Model.ClaudeSonnet5),
            To = new(Model.ClaudeSonnet5),
            Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        BetaFallbackInfoParam expectedFrom = new(Model.ClaudeSonnet5);
        BetaFallbackInfoParam expectedTo = new(Model.ClaudeSonnet5);
        JsonElement expectedType = JsonSerializer.SerializeToElement("fallback");
        JsonElement expectedTrigger = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedFrom, model.From);
        Assert.Equal(expectedTo, model.To);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.Trigger);
        Assert.True(JsonElement.DeepEquals(expectedTrigger, model.Trigger.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaFallbackBlockParam
        {
            From = new(Model.ClaudeSonnet5),
            To = new(Model.ClaudeSonnet5),
            Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbackBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaFallbackBlockParam
        {
            From = new(Model.ClaudeSonnet5),
            To = new(Model.ClaudeSonnet5),
            Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbackBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaFallbackInfoParam expectedFrom = new(Model.ClaudeSonnet5);
        BetaFallbackInfoParam expectedTo = new(Model.ClaudeSonnet5);
        JsonElement expectedType = JsonSerializer.SerializeToElement("fallback");
        JsonElement expectedTrigger = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedFrom, deserialized.From);
        Assert.Equal(expectedTo, deserialized.To);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.Trigger);
        Assert.True(JsonElement.DeepEquals(expectedTrigger, deserialized.Trigger.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaFallbackBlockParam
        {
            From = new(Model.ClaudeSonnet5),
            To = new(Model.ClaudeSonnet5),
            Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaFallbackBlockParam
        {
            From = new(Model.ClaudeSonnet5),
            To = new(Model.ClaudeSonnet5),
        };

        Assert.Null(model.Trigger);
        Assert.False(model.RawData.ContainsKey("trigger"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaFallbackBlockParam
        {
            From = new(Model.ClaudeSonnet5),
            To = new(Model.ClaudeSonnet5),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaFallbackBlockParam
        {
            From = new(Model.ClaudeSonnet5),
            To = new(Model.ClaudeSonnet5),

            // Null should be interpreted as omitted for these properties
            Trigger = null,
        };

        Assert.Null(model.Trigger);
        Assert.False(model.RawData.ContainsKey("trigger"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaFallbackBlockParam
        {
            From = new(Model.ClaudeSonnet5),
            To = new(Model.ClaudeSonnet5),

            // Null should be interpreted as omitted for these properties
            Trigger = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaFallbackBlockParam
        {
            From = new(Model.ClaudeSonnet5),
            To = new(Model.ClaudeSonnet5),
            Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        BetaFallbackBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
