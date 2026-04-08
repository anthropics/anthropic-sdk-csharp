using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAlwaysAllowPolicyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAlwaysAllowPolicy
        {
            Type = BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow,
        };

        ApiEnum<string, BetaManagedAgentsAlwaysAllowPolicyType> expectedType =
            BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAlwaysAllowPolicy
        {
            Type = BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAlwaysAllowPolicy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAlwaysAllowPolicy
        {
            Type = BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAlwaysAllowPolicy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsAlwaysAllowPolicyType> expectedType =
            BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAlwaysAllowPolicy
        {
            Type = BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAlwaysAllowPolicy
        {
            Type = BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow,
        };

        BetaManagedAgentsAlwaysAllowPolicy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsAlwaysAllowPolicyTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow)]
    public void Validation_Works(BetaManagedAgentsAlwaysAllowPolicyType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAlwaysAllowPolicyType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAlwaysAllowPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAlwaysAllowPolicyType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAlwaysAllowPolicyType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAlwaysAllowPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAlwaysAllowPolicyType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAlwaysAllowPolicyType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
