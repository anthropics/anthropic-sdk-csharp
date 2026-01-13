using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolChoiceToolTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolChoiceTool { Name = "name", DisableParallelToolUse = true };

        string expectedName = "name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool");
        bool expectedDisableParallelToolUse = true;

        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDisableParallelToolUse, model.DisableParallelToolUse);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolChoiceTool { Name = "name", DisableParallelToolUse = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoiceTool>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolChoiceTool { Name = "name", DisableParallelToolUse = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoiceTool>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool");
        bool expectedDisableParallelToolUse = true;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDisableParallelToolUse, deserialized.DisableParallelToolUse);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolChoiceTool { Name = "name", DisableParallelToolUse = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolChoiceTool { Name = "name" };

        Assert.Null(model.DisableParallelToolUse);
        Assert.False(model.RawData.ContainsKey("disable_parallel_tool_use"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolChoiceTool { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ToolChoiceTool
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            DisableParallelToolUse = null,
        };

        Assert.Null(model.DisableParallelToolUse);
        Assert.False(model.RawData.ContainsKey("disable_parallel_tool_use"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolChoiceTool
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            DisableParallelToolUse = null,
        };

        model.Validate();
    }
}
