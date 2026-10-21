using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Models;

namespace Anthropic.Tests.Models.Beta.Models;

public class BetaServerToolsCapabilityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaServerToolsCapability
        {
            CodeExecution = new(true),
            Supported = true,
            WebSearch = new(true),
        };

        BetaCapabilitySupport expectedCodeExecution = new(true);
        bool expectedSupported = true;
        BetaCapabilitySupport expectedWebSearch = new(true);

        Assert.Equal(expectedCodeExecution, model.CodeExecution);
        Assert.Equal(expectedSupported, model.Supported);
        Assert.Equal(expectedWebSearch, model.WebSearch);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaServerToolsCapability
        {
            CodeExecution = new(true),
            Supported = true,
            WebSearch = new(true),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaServerToolsCapability>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaServerToolsCapability
        {
            CodeExecution = new(true),
            Supported = true,
            WebSearch = new(true),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaServerToolsCapability>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaCapabilitySupport expectedCodeExecution = new(true);
        bool expectedSupported = true;
        BetaCapabilitySupport expectedWebSearch = new(true);

        Assert.Equal(expectedCodeExecution, deserialized.CodeExecution);
        Assert.Equal(expectedSupported, deserialized.Supported);
        Assert.Equal(expectedWebSearch, deserialized.WebSearch);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaServerToolsCapability
        {
            CodeExecution = new(true),
            Supported = true,
            WebSearch = new(true),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaServerToolsCapability
        {
            CodeExecution = new(true),
            Supported = true,
            WebSearch = new(true),
        };

        BetaServerToolsCapability copied = new(model);

        Assert.Equal(model, copied);
    }
}
