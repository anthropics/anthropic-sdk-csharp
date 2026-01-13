using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolChoiceTest : TestBase
{
    [Fact]
    public void AutoValidationWorks()
    {
        BetaToolChoice value = new BetaToolChoiceAuto() { DisableParallelToolUse = true };
        value.Validate();
    }

    [Fact]
    public void AnyValidationWorks()
    {
        BetaToolChoice value = new BetaToolChoiceAny() { DisableParallelToolUse = true };
        value.Validate();
    }

    [Fact]
    public void ToolValidationWorks()
    {
        BetaToolChoice value = new BetaToolChoiceTool()
        {
            Name = "name",
            DisableParallelToolUse = true,
        };
        value.Validate();
    }

    [Fact]
    public void NoneValidationWorks()
    {
        BetaToolChoice value = new BetaToolChoiceNone();
        value.Validate();
    }

    [Fact]
    public void AutoSerializationRoundtripWorks()
    {
        BetaToolChoice value = new BetaToolChoiceAuto() { DisableParallelToolUse = true };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolChoice>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AnySerializationRoundtripWorks()
    {
        BetaToolChoice value = new BetaToolChoiceAny() { DisableParallelToolUse = true };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolChoice>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolSerializationRoundtripWorks()
    {
        BetaToolChoice value = new BetaToolChoiceTool()
        {
            Name = "name",
            DisableParallelToolUse = true,
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolChoice>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NoneSerializationRoundtripWorks()
    {
        BetaToolChoice value = new BetaToolChoiceNone();
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolChoice>(element);

        Assert.Equal(value, deserialized);
    }
}
