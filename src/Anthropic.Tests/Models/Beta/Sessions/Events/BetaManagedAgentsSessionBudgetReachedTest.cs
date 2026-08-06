using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSessionBudgetReachedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionBudgetReached
        {
            Type = BetaManagedAgentsSessionBudgetReachedType.BudgetReached,
        };

        ApiEnum<string, BetaManagedAgentsSessionBudgetReachedType> expectedType =
            BetaManagedAgentsSessionBudgetReachedType.BudgetReached;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionBudgetReached
        {
            Type = BetaManagedAgentsSessionBudgetReachedType.BudgetReached,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionBudgetReached>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionBudgetReached
        {
            Type = BetaManagedAgentsSessionBudgetReachedType.BudgetReached,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionBudgetReached>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsSessionBudgetReachedType> expectedType =
            BetaManagedAgentsSessionBudgetReachedType.BudgetReached;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionBudgetReached
        {
            Type = BetaManagedAgentsSessionBudgetReachedType.BudgetReached,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionBudgetReached
        {
            Type = BetaManagedAgentsSessionBudgetReachedType.BudgetReached,
        };

        BetaManagedAgentsSessionBudgetReached copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionBudgetReachedTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionBudgetReachedType.BudgetReached)]
    public void Validation_Works(BetaManagedAgentsSessionBudgetReachedType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionBudgetReachedType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionBudgetReachedType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionBudgetReachedType.BudgetReached)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionBudgetReachedType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionBudgetReachedType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionBudgetReachedType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionBudgetReachedType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionBudgetReachedType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
