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
            From = new(Model.ClaudeFable5),
            To = new(Model.ClaudeFable5),
        };

        BetaFallbackInfoParam expectedFrom = new(Model.ClaudeFable5);
        BetaFallbackInfoParam expectedTo = new(Model.ClaudeFable5);
        JsonElement expectedType = JsonSerializer.SerializeToElement("fallback");

        Assert.Equal(expectedFrom, model.From);
        Assert.Equal(expectedTo, model.To);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaFallbackBlockParam
        {
            From = new(Model.ClaudeFable5),
            To = new(Model.ClaudeFable5),
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
            From = new(Model.ClaudeFable5),
            To = new(Model.ClaudeFable5),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbackBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaFallbackInfoParam expectedFrom = new(Model.ClaudeFable5);
        BetaFallbackInfoParam expectedTo = new(Model.ClaudeFable5);
        JsonElement expectedType = JsonSerializer.SerializeToElement("fallback");

        Assert.Equal(expectedFrom, deserialized.From);
        Assert.Equal(expectedTo, deserialized.To);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaFallbackBlockParam
        {
            From = new(Model.ClaudeFable5),
            To = new(Model.ClaudeFable5),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaFallbackBlockParam
        {
            From = new(Model.ClaudeFable5),
            To = new(Model.ClaudeFable5),
        };

        BetaFallbackBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
