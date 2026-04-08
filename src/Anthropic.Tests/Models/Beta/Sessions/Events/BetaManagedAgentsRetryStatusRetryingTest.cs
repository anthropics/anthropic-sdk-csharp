using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsRetryStatusRetryingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRetryStatusRetrying
        {
            Type = BetaManagedAgentsRetryStatusRetryingType.Retrying,
        };

        ApiEnum<string, BetaManagedAgentsRetryStatusRetryingType> expectedType =
            BetaManagedAgentsRetryStatusRetryingType.Retrying;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsRetryStatusRetrying
        {
            Type = BetaManagedAgentsRetryStatusRetryingType.Retrying,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsRetryStatusRetrying>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsRetryStatusRetrying
        {
            Type = BetaManagedAgentsRetryStatusRetryingType.Retrying,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsRetryStatusRetrying>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsRetryStatusRetryingType> expectedType =
            BetaManagedAgentsRetryStatusRetryingType.Retrying;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsRetryStatusRetrying
        {
            Type = BetaManagedAgentsRetryStatusRetryingType.Retrying,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsRetryStatusRetrying
        {
            Type = BetaManagedAgentsRetryStatusRetryingType.Retrying,
        };

        BetaManagedAgentsRetryStatusRetrying copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsRetryStatusRetryingTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsRetryStatusRetryingType.Retrying)]
    public void Validation_Works(BetaManagedAgentsRetryStatusRetryingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsRetryStatusRetryingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRetryStatusRetryingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsRetryStatusRetryingType.Retrying)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsRetryStatusRetryingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsRetryStatusRetryingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRetryStatusRetryingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRetryStatusRetryingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsRetryStatusRetryingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
