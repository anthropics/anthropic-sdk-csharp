using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ThinkingConfigParamTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        ThinkingConfigParam value = new(new ThinkingConfigEnabled(1024));
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        ThinkingConfigParam value = new(new ThinkingConfigDisabled());
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        ThinkingConfigParam value = new(new ThinkingConfigEnabled(1024));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigParam>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        ThinkingConfigParam value = new(new ThinkingConfigDisabled());
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigParam>(element);

        Assert.Equal(value, deserialized);
    }
}
