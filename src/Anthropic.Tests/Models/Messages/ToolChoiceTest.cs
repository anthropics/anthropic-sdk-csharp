using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolChoiceTest : TestBase
{
    [Fact]
    public void autoValidation_Works()
    {
        ToolChoice value = new(new ToolChoiceAuto() { DisableParallelToolUse = true });
        value.Validate();
    }

    [Fact]
    public void anyValidation_Works()
    {
        ToolChoice value = new(new ToolChoiceAny() { DisableParallelToolUse = true });
        value.Validate();
    }

    [Fact]
    public void toolValidation_Works()
    {
        ToolChoice value = new(
            new ToolChoiceTool() { Name = "name", DisableParallelToolUse = true }
        );
        value.Validate();
    }

    [Fact]
    public void noneValidation_Works()
    {
        ToolChoice value = new(new ToolChoiceNone());
        value.Validate();
    }

    [Fact]
    public void autoSerializationRoundtrip_Works()
    {
        ToolChoice value = new(new ToolChoiceAuto() { DisableParallelToolUse = true });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void anySerializationRoundtrip_Works()
    {
        ToolChoice value = new(new ToolChoiceAny() { DisableParallelToolUse = true });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void toolSerializationRoundtrip_Works()
    {
        ToolChoice value = new(
            new ToolChoiceTool() { Name = "name", DisableParallelToolUse = true }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void noneSerializationRoundtrip_Works()
    {
        ToolChoice value = new(new ToolChoiceNone());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(json);

        Assert.Equal(value, deserialized);
    }
}
