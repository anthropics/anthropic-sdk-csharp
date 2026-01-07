using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRequestMcpServerToolConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRequestMcpServerToolConfiguration
        {
            AllowedTools = ["string"],
            Enabled = true,
        };

        List<string> expectedAllowedTools = ["string"];
        bool expectedEnabled = true;

        Assert.NotNull(model.AllowedTools);
        Assert.Equal(expectedAllowedTools.Count, model.AllowedTools.Count);
        for (int i = 0; i < expectedAllowedTools.Count; i++)
        {
            Assert.Equal(expectedAllowedTools[i], model.AllowedTools[i]);
        }
        Assert.Equal(expectedEnabled, model.Enabled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRequestMcpServerToolConfiguration
        {
            AllowedTools = ["string"],
            Enabled = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaRequestMcpServerToolConfiguration>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRequestMcpServerToolConfiguration
        {
            AllowedTools = ["string"],
            Enabled = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaRequestMcpServerToolConfiguration>(
            element
        );
        Assert.NotNull(deserialized);

        List<string> expectedAllowedTools = ["string"];
        bool expectedEnabled = true;

        Assert.NotNull(deserialized.AllowedTools);
        Assert.Equal(expectedAllowedTools.Count, deserialized.AllowedTools.Count);
        for (int i = 0; i < expectedAllowedTools.Count; i++)
        {
            Assert.Equal(expectedAllowedTools[i], deserialized.AllowedTools[i]);
        }
        Assert.Equal(expectedEnabled, deserialized.Enabled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaRequestMcpServerToolConfiguration
        {
            AllowedTools = ["string"],
            Enabled = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaRequestMcpServerToolConfiguration { };

        Assert.Null(model.AllowedTools);
        Assert.False(model.RawData.ContainsKey("allowed_tools"));
        Assert.Null(model.Enabled);
        Assert.False(model.RawData.ContainsKey("enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaRequestMcpServerToolConfiguration { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaRequestMcpServerToolConfiguration
        {
            AllowedTools = null,
            Enabled = null,
        };

        Assert.Null(model.AllowedTools);
        Assert.True(model.RawData.ContainsKey("allowed_tools"));
        Assert.Null(model.Enabled);
        Assert.True(model.RawData.ContainsKey("enabled"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaRequestMcpServerToolConfiguration
        {
            AllowedTools = null,
            Enabled = null,
        };

        model.Validate();
    }
}
