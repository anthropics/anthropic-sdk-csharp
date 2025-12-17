using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaThinkingConfigParamTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        BetaThinkingConfigParam value = new(new BetaThinkingConfigEnabled(1024));
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        BetaThinkingConfigParam value = new(new BetaThinkingConfigDisabled());
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaThinkingConfigParam value = new(new BetaThinkingConfigEnabled(1024));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaThinkingConfigParam value = new(new BetaThinkingConfigDisabled());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigParam>(json);

        Assert.Equal(value, deserialized);
    }
}
