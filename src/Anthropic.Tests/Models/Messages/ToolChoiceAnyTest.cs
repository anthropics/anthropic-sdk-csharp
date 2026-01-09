using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolChoiceAnyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolChoiceAny { DisableParallelToolUse = true };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"any\"");
        bool expectedDisableParallelToolUse = true;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisableParallelToolUse, model.DisableParallelToolUse);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolChoiceAny { DisableParallelToolUse = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ToolChoiceAny>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolChoiceAny { DisableParallelToolUse = true };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ToolChoiceAny>(element);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"any\"");
        bool expectedDisableParallelToolUse = true;

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDisableParallelToolUse, deserialized.DisableParallelToolUse);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolChoiceAny { DisableParallelToolUse = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolChoiceAny { };

        Assert.Null(model.DisableParallelToolUse);
        Assert.False(model.RawData.ContainsKey("disable_parallel_tool_use"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolChoiceAny { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ToolChoiceAny
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
        var model = new ToolChoiceAny
        {
            // Null should be interpreted as omitted for these properties
            DisableParallelToolUse = null,
        };

        model.Validate();
    }
}
