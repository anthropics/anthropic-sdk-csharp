using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ThinkingConfigParamTest : TestBase
{
    [Fact]
    public void enabledValidation_Works()
    {
        ThinkingConfigParam value = new(new(1024));
        value.Validate();
    }

    [Fact]
    public void disabledValidation_Works()
    {
        ThinkingConfigParam value = new(new());
        value.Validate();
    }

    [Fact]
    public void enabledSerializationRoundtrip_Works()
    {
        ThinkingConfigParam value = new(new(1024));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigParam>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void disabledSerializationRoundtrip_Works()
    {
        ThinkingConfigParam value = new(new());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigParam>(json);

        Assert.Equal(value, deserialized);
    }
}
