using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;

namespace Anthropic.Tests.Models.Beta;

public class BetaMonetaryAmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMonetaryAmount { Amount = "2500", Currency = BetaCurrency.Usd };

        string expectedAmount = "2500";
        ApiEnum<string, BetaCurrency> expectedCurrency = BetaCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMonetaryAmount { Amount = "2500", Currency = BetaCurrency.Usd };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMonetaryAmount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMonetaryAmount { Amount = "2500", Currency = BetaCurrency.Usd };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMonetaryAmount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAmount = "2500";
        ApiEnum<string, BetaCurrency> expectedCurrency = BetaCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMonetaryAmount { Amount = "2500", Currency = BetaCurrency.Usd };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaMonetaryAmount { Amount = "2500", Currency = BetaCurrency.Usd };

        BetaMonetaryAmount copied = new(model);

        Assert.Equal(model, copied);
    }
}
