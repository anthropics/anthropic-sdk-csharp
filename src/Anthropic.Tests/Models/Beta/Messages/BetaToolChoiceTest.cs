using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolChoiceTest : TestBase
{
    [Fact]
    public void autoValidation_Works()
    {
        BetaToolChoice value = new(new() { DisableParallelToolUse = true });
        value.Validate();
    }

    [Fact]
    public void anyValidation_Works()
    {
        BetaToolChoice value = new(new() { DisableParallelToolUse = true });
        value.Validate();
    }

    [Fact]
    public void toolValidation_Works()
    {
        BetaToolChoice value = new(new() { Name = "name", DisableParallelToolUse = true });
        value.Validate();
    }

    [Fact]
    public void noneValidation_Works()
    {
        BetaToolChoice value = new(new());
        value.Validate();
    }

    [Fact]
    public void autoSerializationRoundtrip_Works()
    {
        BetaToolChoice value = new(new() { DisableParallelToolUse = true });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolChoice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void anySerializationRoundtrip_Works()
    {
        BetaToolChoice value = new(new() { DisableParallelToolUse = true });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolChoice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void toolSerializationRoundtrip_Works()
    {
        BetaToolChoice value = new(new() { Name = "name", DisableParallelToolUse = true });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolChoice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void noneSerializationRoundtrip_Works()
    {
        BetaToolChoice value = new(new());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolChoice>(json);

        Assert.Equal(value, deserialized);
    }
}
