using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolChoiceTest : TestBase
{
    [Fact]
    public void autoValidation_Works()
    {
        BetaToolChoice value = new(new BetaToolChoiceAuto() { DisableParallelToolUse = true });
        value.Validate();
    }

    [Fact]
    public void anyValidation_Works()
    {
        BetaToolChoice value = new(new BetaToolChoiceAny() { DisableParallelToolUse = true });
        value.Validate();
    }

    [Fact]
    public void toolValidation_Works()
    {
        BetaToolChoice value = new(
            new BetaToolChoiceTool() { Name = "name", DisableParallelToolUse = true }
        );
        value.Validate();
    }

    [Fact]
    public void noneValidation_Works()
    {
        BetaToolChoice value = new(new BetaToolChoiceNone());
        value.Validate();
    }

    [Fact]
    public void autoSerializationRoundtrip_Works()
    {
        BetaToolChoice value = new(new BetaToolChoiceAuto() { DisableParallelToolUse = true });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolChoice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void anySerializationRoundtrip_Works()
    {
        BetaToolChoice value = new(new BetaToolChoiceAny() { DisableParallelToolUse = true });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolChoice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void toolSerializationRoundtrip_Works()
    {
        BetaToolChoice value = new(
            new BetaToolChoiceTool() { Name = "name", DisableParallelToolUse = true }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolChoice>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void noneSerializationRoundtrip_Works()
    {
        BetaToolChoice value = new(new BetaToolChoiceNone());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolChoice>(json);

        Assert.Equal(value, deserialized);
    }
}
