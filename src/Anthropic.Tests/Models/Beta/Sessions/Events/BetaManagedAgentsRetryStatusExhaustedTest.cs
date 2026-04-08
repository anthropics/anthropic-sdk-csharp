using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsRetryStatusExhaustedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRetryStatusExhausted
        {
            Type = BetaManagedAgentsRetryStatusExhaustedType.Exhausted,
        };

        ApiEnum<string, BetaManagedAgentsRetryStatusExhaustedType> expectedType =
            BetaManagedAgentsRetryStatusExhaustedType.Exhausted;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRetryStatusExhausted
        {
            Type = BetaManagedAgentsRetryStatusExhaustedType.Exhausted,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsRetryStatusExhausted>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsRetryStatusExhausted
        {
            Type = BetaManagedAgentsRetryStatusExhaustedType.Exhausted,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsRetryStatusExhausted>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsRetryStatusExhaustedType> expectedType =
            BetaManagedAgentsRetryStatusExhaustedType.Exhausted;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsRetryStatusExhausted
        {
            Type = BetaManagedAgentsRetryStatusExhaustedType.Exhausted,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsRetryStatusExhausted
        {
            Type = BetaManagedAgentsRetryStatusExhaustedType.Exhausted,
        };

        BetaManagedAgentsRetryStatusExhausted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsRetryStatusExhaustedTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsRetryStatusExhaustedType.Exhausted)]
    public void Validation_Works(BetaManagedAgentsRetryStatusExhaustedType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsRetryStatusExhaustedType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRetryStatusExhaustedType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsRetryStatusExhaustedType.Exhausted)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsRetryStatusExhaustedType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsRetryStatusExhaustedType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRetryStatusExhaustedType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRetryStatusExhaustedType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRetryStatusExhaustedType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
