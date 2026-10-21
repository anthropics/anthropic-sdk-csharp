using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Models;

namespace Anthropic.Tests.Models.Models;

public class ServerToolsCapabilityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ServerToolsCapability
        {
            CodeExecution = new(true),
            Supported = true,
            WebSearch = new(true),
        };

        CapabilitySupport expectedCodeExecution = new(true);
        bool expectedSupported = true;
        CapabilitySupport expectedWebSearch = new(true);

        Assert.Equal(expectedCodeExecution, model.CodeExecution);
        Assert.Equal(expectedSupported, model.Supported);
        Assert.Equal(expectedWebSearch, model.WebSearch);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ServerToolsCapability
        {
            CodeExecution = new(true),
            Supported = true,
            WebSearch = new(true),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServerToolsCapability>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ServerToolsCapability
        {
            CodeExecution = new(true),
            Supported = true,
            WebSearch = new(true),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServerToolsCapability>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CapabilitySupport expectedCodeExecution = new(true);
        bool expectedSupported = true;
        CapabilitySupport expectedWebSearch = new(true);

        Assert.Equal(expectedCodeExecution, deserialized.CodeExecution);
        Assert.Equal(expectedSupported, deserialized.Supported);
        Assert.Equal(expectedWebSearch, deserialized.WebSearch);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ServerToolsCapability
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
        var model = new ServerToolsCapability
        {
            CodeExecution = new(true),
            Supported = true,
            WebSearch = new(true),
        };

        ServerToolsCapability copied = new(model);

        Assert.Equal(model, copied);
    }
}
