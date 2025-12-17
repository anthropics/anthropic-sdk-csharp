using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolChoiceTest : TestBase
{
    [Fact]
    public void AutoValidationWorks()
    {
        ToolChoice value = new(new ToolChoiceAuto() { DisableParallelToolUse = true });
        value.Validate();
    }

    [Fact]
    public void AnyValidationWorks()
    {
        ToolChoice value = new(new ToolChoiceAny() { DisableParallelToolUse = true });
        value.Validate();
    }

    [Fact]
    public void ToolValidationWorks()
    {
        ToolChoice value = new(
            new ToolChoiceTool() { Name = "name", DisableParallelToolUse = true }
        );
        value.Validate();
    }

    [Fact]
    public void NoneValidationWorks()
    {
        ToolChoice value = new(new ToolChoiceNone());
        value.Validate();
    }

    [Fact]
    public void AutoSerializationRoundtripWorks()
    {
        ToolChoice value = new(new ToolChoiceAuto() { DisableParallelToolUse = true });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AnySerializationRoundtripWorks()
    {
        ToolChoice value = new(new ToolChoiceAny() { DisableParallelToolUse = true });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolSerializationRoundtripWorks()
    {
        ToolChoice value = new(
            new ToolChoiceTool() { Name = "name", DisableParallelToolUse = true }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NoneSerializationRoundtripWorks()
    {
        ToolChoice value = new(new ToolChoiceNone());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(json);

        Assert.Equal(value, deserialized);
    }
}
