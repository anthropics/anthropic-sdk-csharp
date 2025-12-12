using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMemoryTool20250818ViewCommandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMemoryTool20250818ViewCommand
        {
            Path = "/memories",
            ViewRange = [1, 10],
        };

        JsonElement expectedCommand = JsonSerializer.Deserialize<JsonElement>("\"view\"");
        string expectedPath = "/memories";
        List<long> expectedViewRange = [1, 10];

        Assert.True(JsonElement.DeepEquals(expectedCommand, model.Command));
        Assert.Equal(expectedPath, model.Path);
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
        var model = new BetaMemoryTool20250818ViewCommand
        {
            Path = "/memories",
            ViewRange = [1, 10],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818ViewCommand>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMemoryTool20250818ViewCommand
        {
            Path = "/memories",
            ViewRange = [1, 10],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818ViewCommand>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedCommand = JsonSerializer.Deserialize<JsonElement>("\"view\"");
        string expectedPath = "/memories";
        List<long> expectedViewRange = [1, 10];

        Assert.True(JsonElement.DeepEquals(expectedCommand, deserialized.Command));
        Assert.Equal(expectedPath, deserialized.Path);
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
        var model = new BetaMemoryTool20250818ViewCommand
        {
            Path = "/memories",
            ViewRange = [1, 10],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaMemoryTool20250818ViewCommand { Path = "/memories" };

        Assert.Null(model.ViewRange);
        Assert.False(model.RawData.ContainsKey("view_range"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaMemoryTool20250818ViewCommand { Path = "/memories" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaMemoryTool20250818ViewCommand
        {
            Path = "/memories",

            // Null should be interpreted as omitted for these properties
            ViewRange = null,
        };

        Assert.Null(model.ViewRange);
        Assert.False(model.RawData.ContainsKey("view_range"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaMemoryTool20250818ViewCommand
        {
            Path = "/memories",

            // Null should be interpreted as omitted for these properties
            ViewRange = null,
        };

        model.Validate();
    }
}
