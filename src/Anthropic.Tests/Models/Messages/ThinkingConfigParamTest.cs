using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ThinkingConfigParamTest : TestBase
{
    [Fact]
    public void enabledValidation_Works()
    {
        ThinkingConfigParam value = new(new ThinkingConfigEnabled(1024));
        value.Validate();
    }

    [Fact]
    public void disabledValidation_Works()
    {
        ThinkingConfigParam value = new(new ThinkingConfigDisabled());
        value.Validate();
    }

    [Fact]
    public void enabledSerializationRoundtrip_Works()
    {
        ThinkingConfigParam value = new(new ThinkingConfigEnabled(1024));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void disabledSerializationRoundtrip_Works()
    {
        ThinkingConfigParam value = new(new ThinkingConfigDisabled());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigParam>(json);

        Assert.Equal(value, deserialized);
    }
}
