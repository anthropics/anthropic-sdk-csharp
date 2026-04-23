using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Models;

namespace Anthropic.Tests.Models.Models;

public class EffortCapabilityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EffortCapability
        {
            High = new(true),
            Low = new(true),
            Max = new(true),
            Medium = new(true),
            Supported = true,
        };

        CapabilitySupport expectedHigh = new(true);
        CapabilitySupport expectedLow = new(true);
        CapabilitySupport expectedMax = new(true);
        CapabilitySupport expectedMedium = new(true);
        bool expectedSupported = true;

        Assert.Equal(expectedHigh, model.High);
        Assert.Equal(expectedLow, model.Low);
        Assert.Equal(expectedMax, model.Max);
        Assert.Equal(expectedMedium, model.Medium);
        Assert.Equal(expectedSupported, model.Supported);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EffortCapability
        {
            High = new(true),
            Low = new(true),
            Max = new(true),
            Medium = new(true),
            Supported = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EffortCapability>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EffortCapability
        {
            High = new(true),
            Low = new(true),
            Max = new(true),
            Medium = new(true),
            Supported = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EffortCapability>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CapabilitySupport expectedHigh = new(true);
        CapabilitySupport expectedLow = new(true);
        CapabilitySupport expectedMax = new(true);
        CapabilitySupport expectedMedium = new(true);
        bool expectedSupported = true;

        Assert.Equal(expectedHigh, deserialized.High);
        Assert.Equal(expectedLow, deserialized.Low);
        Assert.Equal(expectedMax, deserialized.Max);
        Assert.Equal(expectedMedium, deserialized.Medium);
        Assert.Equal(expectedSupported, deserialized.Supported);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EffortCapability
        {
            High = new(true),
            Low = new(true),
            Max = new(true),
            Medium = new(true),
            Supported = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EffortCapability
        {
            High = new(true),
            Low = new(true),
            Max = new(true),
            Medium = new(true),
            Supported = true,
        };

        EffortCapability copied = new(model);

        Assert.Equal(model, copied);
    }
}
