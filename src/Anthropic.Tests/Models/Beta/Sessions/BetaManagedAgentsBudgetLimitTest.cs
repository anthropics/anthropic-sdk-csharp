using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsBudgetLimitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsBudgetLimit
        {
            MaxListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
        };

        BetaMonetaryAmount expectedMaxListCost = new()
        {
            Amount = "2500",
            Currency = BetaCurrency.Usd,
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("limit");

        Assert.Equal(expectedMaxListCost, model.MaxListCost);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsBudgetLimit
        {
            MaxListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsBudgetLimit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsBudgetLimit
        {
            MaxListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsBudgetLimit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaMonetaryAmount expectedMaxListCost = new()
        {
            Amount = "2500",
            Currency = BetaCurrency.Usd,
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("limit");

        Assert.Equal(expectedMaxListCost, deserialized.MaxListCost);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsBudgetLimit
        {
            MaxListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsBudgetLimit
        {
            MaxListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
        };

        BetaManagedAgentsBudgetLimit copied = new(model);

        Assert.Equal(model, copied);
    }
}
