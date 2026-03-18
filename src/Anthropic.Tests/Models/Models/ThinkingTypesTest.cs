using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Models;

namespace Anthropic.Tests.Models.Models;

public class ThinkingTypesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThinkingTypes { Adaptive = new(true), Enabled = new(true) };

        CapabilitySupport expectedAdaptive = new(true);
        CapabilitySupport expectedEnabled = new(true);

        Assert.Equal(expectedAdaptive, model.Adaptive);
        Assert.Equal(expectedEnabled, model.Enabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThinkingTypes { Adaptive = new(true), Enabled = new(true) };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingTypes>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThinkingTypes { Adaptive = new(true), Enabled = new(true) };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingTypes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CapabilitySupport expectedAdaptive = new(true);
        CapabilitySupport expectedEnabled = new(true);

        Assert.Equal(expectedAdaptive, deserialized.Adaptive);
        Assert.Equal(expectedEnabled, deserialized.Enabled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThinkingTypes { Adaptive = new(true), Enabled = new(true) };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ThinkingTypes { Adaptive = new(true), Enabled = new(true) };

        ThinkingTypes copied = new(model);

        Assert.Equal(model, copied);
    }
}
