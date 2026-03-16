using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaThinkingConfigParamTest : TestBase
{
    [Fact]
    public void EnabledValidationWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigEnabled()
        {
            BudgetTokens = 1024,
            Display = BetaThinkingConfigEnabledDisplay.Summarized,
        };
        value.Validate();
    }

    [Fact]
    public void DisabledValidationWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigDisabled();
        value.Validate();
    }

    [Fact]
    public void AdaptiveValidationWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigAdaptive()
        {
            Display = Display.Summarized,
        };
        value.Validate();
    }

    [Fact]
    public void EnabledSerializationRoundtripWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigEnabled()
        {
            BudgetTokens = 1024,
            Display = BetaThinkingConfigEnabledDisplay.Summarized,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DisabledSerializationRoundtripWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigDisabled();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AdaptiveSerializationRoundtripWorks()
    {
        BetaThinkingConfigParam value = new BetaThinkingConfigAdaptive()
        {
            Display = Display.Summarized,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigParam>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
