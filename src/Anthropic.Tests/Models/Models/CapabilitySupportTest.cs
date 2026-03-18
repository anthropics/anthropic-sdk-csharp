using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Models;

namespace Anthropic.Tests.Models.Models;

public class CapabilitySupportTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CapabilitySupport { Supported = true };

        bool expectedSupported = true;

        Assert.Equal(expectedSupported, model.Supported);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CapabilitySupport { Supported = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CapabilitySupport>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CapabilitySupport { Supported = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CapabilitySupport>(
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
        var model = new CapabilitySupport { Supported = true };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CapabilitySupport { Supported = true };

        CapabilitySupport copied = new(model);

        Assert.Equal(model, copied);
    }
}
