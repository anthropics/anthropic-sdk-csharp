using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Models;

namespace Anthropic.Tests.Models.Models;

public class ThinkingCapabilityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThinkingCapability
        {
            Supported = true,
            Types = new() { Adaptive = new(true), Enabled = new(true) },
        };

        bool expectedSupported = true;
        ThinkingTypes expectedTypes = new() { Adaptive = new(true), Enabled = new(true) };

        Assert.Equal(expectedSupported, model.Supported);
        Assert.Equal(expectedTypes, model.Types);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThinkingCapability
        {
            Supported = true,
            Types = new() { Adaptive = new(true), Enabled = new(true) },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingCapability>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThinkingCapability
        {
            Supported = true,
            Types = new() { Adaptive = new(true), Enabled = new(true) },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingCapability>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedSupported = true;
        ThinkingTypes expectedTypes = new() { Adaptive = new(true), Enabled = new(true) };

        Assert.Equal(expectedSupported, deserialized.Supported);
        Assert.Equal(expectedTypes, deserialized.Types);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThinkingCapability
        {
            Supported = true,
            Types = new() { Adaptive = new(true), Enabled = new(true) },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ThinkingCapability
        {
            Supported = true,
            Types = new() { Adaptive = new(true), Enabled = new(true) },
        };

        ThinkingCapability copied = new(model);

        Assert.Equal(model, copied);
    }
}
