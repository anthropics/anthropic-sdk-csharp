using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
            Type = BetaManagedAgentsBudgetLimitType.Limit,
        };

        BetaMonetaryAmount expectedMaxListCost = new()
        {
            Amount = "2500",
            Currency = BetaCurrency.Usd,
        };
        ApiEnum<string, BetaManagedAgentsBudgetLimitType> expectedType =
            BetaManagedAgentsBudgetLimitType.Limit;

        Assert.Equal(expectedMaxListCost, model.MaxListCost);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsBudgetLimit
        {
            MaxListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            Type = BetaManagedAgentsBudgetLimitType.Limit,
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
            Type = BetaManagedAgentsBudgetLimitType.Limit,
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
        ApiEnum<string, BetaManagedAgentsBudgetLimitType> expectedType =
            BetaManagedAgentsBudgetLimitType.Limit;

        Assert.Equal(expectedMaxListCost, deserialized.MaxListCost);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsBudgetLimit
        {
            MaxListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            Type = BetaManagedAgentsBudgetLimitType.Limit,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsBudgetLimit
        {
            MaxListCost = new() { Amount = "2500", Currency = BetaCurrency.Usd },
            Type = BetaManagedAgentsBudgetLimitType.Limit,
        };

        BetaManagedAgentsBudgetLimit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsBudgetLimitTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsBudgetLimitType.Limit)]
    public void Validation_Works(BetaManagedAgentsBudgetLimitType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsBudgetLimitType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsBudgetLimitType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsBudgetLimitType.Limit)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsBudgetLimitType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsBudgetLimitType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsBudgetLimitType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsBudgetLimitType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsBudgetLimitType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
