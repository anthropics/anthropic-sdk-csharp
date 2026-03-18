using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Models;

namespace Anthropic.Tests.Models.Beta.Models;

public class BetaCapabilitySupportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCapabilitySupport { Supported = true };

        bool expectedSupported = true;

        Assert.Equal(expectedSupported, model.Supported);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCapabilitySupport { Supported = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCapabilitySupport>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCapabilitySupport { Supported = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCapabilitySupport>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedSupported = true;

        Assert.Equal(expectedSupported, deserialized.Supported);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCapabilitySupport { Supported = true };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaCapabilitySupport { Supported = true };

        BetaCapabilitySupport copied = new(model);

        Assert.Equal(model, copied);
    }
}
