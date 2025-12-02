using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaThinkingConfigEnabledTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaThinkingConfigEnabled { BudgetTokens = 1024 };

        long expectedBudgetTokens = 1024;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"enabled\"");

        Assert.Equal(expectedBudgetTokens, model.BudgetTokens);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaThinkingConfigEnabled { BudgetTokens = 1024 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigEnabled>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaThinkingConfigEnabled { BudgetTokens = 1024 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingConfigEnabled>(json);
        Assert.NotNull(deserialized);

        long expectedBudgetTokens = 1024;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"enabled\"");

        Assert.Equal(expectedBudgetTokens, deserialized.BudgetTokens);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaThinkingConfigEnabled { BudgetTokens = 1024 };

        model.Validate();
    }
}
