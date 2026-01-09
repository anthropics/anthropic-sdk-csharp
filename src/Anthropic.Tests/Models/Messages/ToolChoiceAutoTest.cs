using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolChoiceAutoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolChoiceAuto { DisableParallelToolUse = true };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"auto\"");
        bool expectedDisableParallelToolUse = true;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisableParallelToolUse, model.DisableParallelToolUse);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolChoiceAuto { DisableParallelToolUse = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ToolChoiceAuto>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolChoiceAuto { DisableParallelToolUse = true };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ToolChoiceAuto>(element);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"auto\"");
        bool expectedDisableParallelToolUse = true;

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDisableParallelToolUse, deserialized.DisableParallelToolUse);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolChoiceAuto { DisableParallelToolUse = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolChoiceAuto { };

        Assert.Null(model.DisableParallelToolUse);
        Assert.False(model.RawData.ContainsKey("disable_parallel_tool_use"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolChoiceAuto { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ToolChoiceAuto
        {
            // Null should be interpreted as omitted for these properties
            DisableParallelToolUse = null,
        };

        Assert.Null(model.DisableParallelToolUse);
        Assert.False(model.RawData.ContainsKey("disable_parallel_tool_use"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolChoiceAuto
        {
            // Null should be interpreted as omitted for these properties
            DisableParallelToolUse = null,
        };

        model.Validate();
    }
}
