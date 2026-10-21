using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits;

public class BetaSpendLimitSeatTierScopeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSpendLimitSeatTierScope { SeatTier = "seat_tier" };

        string expectedSeatTier = "seat_tier";
        JsonElement expectedType = JsonSerializer.SerializeToElement("seat_tier");

        Assert.Equal(expectedSeatTier, model.SeatTier);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSpendLimitSeatTierScope { SeatTier = "seat_tier" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitSeatTierScope>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSpendLimitSeatTierScope { SeatTier = "seat_tier" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitSeatTierScope>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSeatTier = "seat_tier";
        JsonElement expectedType = JsonSerializer.SerializeToElement("seat_tier");

        Assert.Equal(expectedSeatTier, deserialized.SeatTier);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSpendLimitSeatTierScope { SeatTier = "seat_tier" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSpendLimitSeatTierScope { SeatTier = "seat_tier" };

        BetaSpendLimitSeatTierScope copied = new(model);

        Assert.Equal(model, copied);
    }
}
