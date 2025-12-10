using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolChoiceTest : TestBase
{
    [Fact]
    public void autoValidation_Works()
    {
        ToolChoice value = new(new() { DisableParallelToolUse = true });
        value.Validate();
    }

    [Fact]
    public void anyValidation_Works()
    {
        ToolChoice value = new(new() { DisableParallelToolUse = true });
        value.Validate();
    }

    [Fact]
    public void toolValidation_Works()
    {
        ToolChoice value = new(new() { Name = "name", DisableParallelToolUse = true });
        value.Validate();
    }

    [Fact]
    public void noneValidation_Works()
    {
        ToolChoice value = new(new());
        value.Validate();
    }

    [Fact]
    public void autoSerializationRoundtrip_Works()
    {
        ToolChoice value = new(new() { DisableParallelToolUse = true });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void anySerializationRoundtrip_Works()
    {
        ToolChoice value = new(new() { DisableParallelToolUse = true });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void toolSerializationRoundtrip_Works()
    {
        ToolChoice value = new(new() { Name = "name", DisableParallelToolUse = true });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void noneSerializationRoundtrip_Works()
    {
        ToolChoice value = new(new());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(json);

        Assert.Equal(value, deserialized);
    }
}
