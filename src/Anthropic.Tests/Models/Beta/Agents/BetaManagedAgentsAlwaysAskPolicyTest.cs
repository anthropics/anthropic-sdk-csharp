using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAlwaysAskPolicyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAlwaysAskPolicy
        {
            Type = BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk,
        };

        ApiEnum<string, BetaManagedAgentsAlwaysAskPolicyType> expectedType =
            BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAlwaysAskPolicy
        {
            Type = BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAlwaysAskPolicy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAlwaysAskPolicy
        {
            Type = BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAlwaysAskPolicy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsAlwaysAskPolicyType> expectedType =
            BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAlwaysAskPolicy
        {
            Type = BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAlwaysAskPolicy
        {
            Type = BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk,
        };

        BetaManagedAgentsAlwaysAskPolicy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsAlwaysAskPolicyTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk)]
    public void Validation_Works(BetaManagedAgentsAlwaysAskPolicyType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAlwaysAskPolicyType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAlwaysAskPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAlwaysAskPolicyType.AlwaysAsk)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAlwaysAskPolicyType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAlwaysAskPolicyType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAlwaysAskPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAlwaysAskPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAlwaysAskPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
