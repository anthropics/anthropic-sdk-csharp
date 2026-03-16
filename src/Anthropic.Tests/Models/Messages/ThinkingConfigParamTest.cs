using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ThinkingConfigParamTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigEnabled()
        {
            BudgetTokens = 1024,
            Display = ThinkingConfigEnabledDisplay.Summarized,
        };
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigDisabled();
        value.Validate();
    }

    [Fact]
    public void AdaptiveValidationWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigAdaptive() { Display = Display.Summarized };
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigEnabled()
        {
            BudgetTokens = 1024,
            Display = ThinkingConfigEnabledDisplay.Summarized,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigDisabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AdaptiveSerializationRoundtripWorks()
    {
        ThinkingConfigParam value = new ThinkingConfigAdaptive() { Display = Display.Summarized };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThinkingConfigParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
