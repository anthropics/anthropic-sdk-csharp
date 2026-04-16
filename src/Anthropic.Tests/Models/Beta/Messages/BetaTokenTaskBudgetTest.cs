using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTokenTaskBudgetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTokenTaskBudget { Total = 1024, Remaining = 0 };

        long expectedTotal = 1024;
        JsonElement expectedType = JsonSerializer.SerializeToElement("tokens");
        long expectedRemaining = 0;

        Assert.Equal(expectedTotal, model.Total);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedRemaining, model.Remaining);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTokenTaskBudget { Total = 1024, Remaining = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTokenTaskBudget>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTokenTaskBudget { Total = 1024, Remaining = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTokenTaskBudget>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedTotal = 1024;
        JsonElement expectedType = JsonSerializer.SerializeToElement("tokens");
        long expectedRemaining = 0;

        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedRemaining, deserialized.Remaining);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTokenTaskBudget { Total = 1024, Remaining = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaTokenTaskBudget { Total = 1024 };

        Assert.Null(model.Remaining);
        Assert.False(model.RawData.ContainsKey("remaining"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaTokenTaskBudget { Total = 1024 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaTokenTaskBudget
        {
            Total = 1024,

            Remaining = null,
        };

        Assert.Null(model.Remaining);
        Assert.True(model.RawData.ContainsKey("remaining"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaTokenTaskBudget
        {
            Total = 1024,

            Remaining = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaTokenTaskBudget { Total = 1024, Remaining = 0 };

        BetaTokenTaskBudget copied = new(model);

        Assert.Equal(model, copied);
    }
}
