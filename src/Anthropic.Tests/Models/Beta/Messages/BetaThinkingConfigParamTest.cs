using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaThinkingConfigParamTest : TestBase
{
    [Fact]
    public void enabledValidation_Works()
    {
        BetaThinkingConfigParam value = new(new(1024));
        value.Validate();
    }

    [Fact]
    public void disabledValidation_Works()
    {
        BetaThinkingConfigParam value = new(new());
        value.Validate();
    }

    [Fact]
    public void enabledSerializationRoundtrip_Works()
    {
        BetaThinkingConfigParam value = new(new(1024));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void disabledSerializationRoundtrip_Works()
    {
        BetaThinkingConfigParam value = new(new());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigParam>(json);

        Assert.Equal(value, deserialized);
    }
}
