using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolChoiceTest : TestBase
{
    [Fact]
    public void AutoValidationWorks()
    {
        ToolChoice value = new ToolChoiceAuto() { DisableParallelToolUse = true };
        value.Validate();
    }

    [Fact]
    public void AnyValidationWorks()
    {
        ToolChoice value = new ToolChoiceAny() { DisableParallelToolUse = true };
        value.Validate();
    }

    [Fact]
    public void ToolValidationWorks()
    {
        ToolChoice value = new ToolChoiceTool() { Name = "name", DisableParallelToolUse = true };
        value.Validate();
    }

    [Fact]
    public void NoneValidationWorks()
    {
        ToolChoice value = new ToolChoiceNone();
        value.Validate();
    }

    [Fact]
    public void AutoSerializationRoundtripWorks()
    {
        ToolChoice value = new ToolChoiceAuto() { DisableParallelToolUse = true };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AnySerializationRoundtripWorks()
    {
        ToolChoice value = new ToolChoiceAny() { DisableParallelToolUse = true };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolSerializationRoundtripWorks()
    {
        ToolChoice value = new ToolChoiceTool() { Name = "name", DisableParallelToolUse = true };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NoneSerializationRoundtripWorks()
    {
        ToolChoice value = new ToolChoiceNone();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
