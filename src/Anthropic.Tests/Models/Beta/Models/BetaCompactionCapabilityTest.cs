using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Models;

namespace Anthropic.Tests.Models.Beta.Models;

public class BetaCompactionCapabilityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCompactionCapability { Summarize = new(true), Supported = true };

        BetaCapabilitySupport expectedSummarize = new(true);
        bool expectedSupported = true;

        Assert.Equal(expectedSummarize, model.Summarize);
        Assert.Equal(expectedSupported, model.Supported);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCompactionCapability { Summarize = new(true), Supported = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCompactionCapability>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCompactionCapability { Summarize = new(true), Supported = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCompactionCapability>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaCapabilitySupport expectedSummarize = new(true);
        bool expectedSupported = true;

        Assert.Equal(expectedSummarize, deserialized.Summarize);
        Assert.Equal(expectedSupported, deserialized.Supported);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCompactionCapability { Summarize = new(true), Supported = true };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaCompactionCapability { Summarize = new(true), Supported = true };

        BetaCompactionCapability copied = new(model);

        Assert.Equal(model, copied);
    }
}
