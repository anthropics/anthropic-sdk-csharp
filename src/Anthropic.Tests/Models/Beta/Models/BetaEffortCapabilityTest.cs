using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Models;

namespace Anthropic.Tests.Models.Beta.Models;

public class BetaEffortCapabilityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaEffortCapability
        {
            High = new(true),
            Low = new(true),
            Max = new(true),
            Medium = new(true),
            Supported = true,
            Xhigh = new(true),
        };

        BetaCapabilitySupport expectedHigh = new(true);
        BetaCapabilitySupport expectedLow = new(true);
        BetaCapabilitySupport expectedMax = new(true);
        BetaCapabilitySupport expectedMedium = new(true);
        bool expectedSupported = true;
        BetaCapabilitySupport expectedXhigh = new(true);

        Assert.Equal(expectedHigh, model.High);
        Assert.Equal(expectedLow, model.Low);
        Assert.Equal(expectedMax, model.Max);
        Assert.Equal(expectedMedium, model.Medium);
        Assert.Equal(expectedSupported, model.Supported);
        Assert.Equal(expectedXhigh, model.Xhigh);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaEffortCapability
        {
            High = new(true),
            Low = new(true),
            Max = new(true),
            Medium = new(true),
            Supported = true,
            Xhigh = new(true),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaEffortCapability>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaEffortCapability
        {
            High = new(true),
            Low = new(true),
            Max = new(true),
            Medium = new(true),
            Supported = true,
            Xhigh = new(true),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaEffortCapability>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaCapabilitySupport expectedHigh = new(true);
        BetaCapabilitySupport expectedLow = new(true);
        BetaCapabilitySupport expectedMax = new(true);
        BetaCapabilitySupport expectedMedium = new(true);
        bool expectedSupported = true;
        BetaCapabilitySupport expectedXhigh = new(true);

        Assert.Equal(expectedHigh, deserialized.High);
        Assert.Equal(expectedLow, deserialized.Low);
        Assert.Equal(expectedMax, deserialized.Max);
        Assert.Equal(expectedMedium, deserialized.Medium);
        Assert.Equal(expectedSupported, deserialized.Supported);
        Assert.Equal(expectedXhigh, deserialized.Xhigh);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaEffortCapability
        {
            High = new(true),
            Low = new(true),
            Max = new(true),
            Medium = new(true),
            Supported = true,
            Xhigh = new(true),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaEffortCapability
        {
            High = new(true),
            Low = new(true),
            Max = new(true),
            Medium = new(true),
            Supported = true,
            Xhigh = new(true),
        };

        BetaEffortCapability copied = new(model);

        Assert.Equal(model, copied);
    }
}
