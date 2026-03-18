using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Models;

namespace Anthropic.Tests.Models.Beta.Models;

public class BetaThinkingTypesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaThinkingTypes { Adaptive = new(true), Enabled = new(true) };

        BetaCapabilitySupport expectedAdaptive = new(true);
        BetaCapabilitySupport expectedEnabled = new(true);

        Assert.Equal(expectedAdaptive, model.Adaptive);
        Assert.Equal(expectedEnabled, model.Enabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaThinkingTypes { Adaptive = new(true), Enabled = new(true) };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingTypes>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaThinkingTypes { Adaptive = new(true), Enabled = new(true) };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingTypes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaCapabilitySupport expectedAdaptive = new(true);
        BetaCapabilitySupport expectedEnabled = new(true);

        Assert.Equal(expectedAdaptive, deserialized.Adaptive);
        Assert.Equal(expectedEnabled, deserialized.Enabled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaThinkingTypes { Adaptive = new(true), Enabled = new(true) };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaThinkingTypes { Adaptive = new(true), Enabled = new(true) };

        BetaThinkingTypes copied = new(model);

        Assert.Equal(model, copied);
    }
}
