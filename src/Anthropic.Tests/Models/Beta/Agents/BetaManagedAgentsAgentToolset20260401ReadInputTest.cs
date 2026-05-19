using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAgentToolset20260401ReadInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401ReadInput
        {
            FilePath = "file_path",
            ViewRange = [0, 0],
        };

        string expectedFilePath = "file_path";
        List<long> expectedViewRange = [0, 0];

        Assert.Equal(expectedFilePath, model.FilePath);
        Assert.NotNull(model.ViewRange);
        Assert.Equal(expectedViewRange.Count, model.ViewRange.Count);
        for (int i = 0; i < expectedViewRange.Count; i++)
        {
            Assert.Equal(expectedViewRange[i], model.ViewRange[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401ReadInput
        {
            FilePath = "file_path",
            ViewRange = [0, 0],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401ReadInput>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401ReadInput
        {
            FilePath = "file_path",
            ViewRange = [0, 0],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401ReadInput>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedFilePath = "file_path";
        List<long> expectedViewRange = [0, 0];

        Assert.Equal(expectedFilePath, deserialized.FilePath);
        Assert.NotNull(deserialized.ViewRange);
        Assert.Equal(expectedViewRange.Count, deserialized.ViewRange.Count);
        for (int i = 0; i < expectedViewRange.Count; i++)
        {
            Assert.Equal(expectedViewRange[i], deserialized.ViewRange[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401ReadInput
        {
            FilePath = "file_path",
            ViewRange = [0, 0],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401ReadInput { FilePath = "file_path" };

        Assert.Null(model.ViewRange);
        Assert.False(model.RawData.ContainsKey("view_range"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401ReadInput { FilePath = "file_path" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401ReadInput
        {
            FilePath = "file_path",

            // Null should be interpreted as omitted for these properties
            ViewRange = null,
        };

        Assert.Null(model.ViewRange);
        Assert.False(model.RawData.ContainsKey("view_range"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401ReadInput
        {
            FilePath = "file_path",

            // Null should be interpreted as omitted for these properties
            ViewRange = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401ReadInput
        {
            FilePath = "file_path",
            ViewRange = [0, 0],
        };

        BetaManagedAgentsAgentToolset20260401ReadInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
