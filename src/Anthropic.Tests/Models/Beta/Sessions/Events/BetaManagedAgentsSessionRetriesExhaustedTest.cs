using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSessionRetriesExhaustedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionRetriesExhausted
        {
            Type = BetaManagedAgentsSessionRetriesExhaustedType.RetriesExhausted,
        };

        ApiEnum<string, BetaManagedAgentsSessionRetriesExhaustedType> expectedType =
            BetaManagedAgentsSessionRetriesExhaustedType.RetriesExhausted;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionRetriesExhausted
        {
            Type = BetaManagedAgentsSessionRetriesExhaustedType.RetriesExhausted,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionRetriesExhausted>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionRetriesExhausted
        {
            Type = BetaManagedAgentsSessionRetriesExhaustedType.RetriesExhausted,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionRetriesExhausted>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsSessionRetriesExhaustedType> expectedType =
            BetaManagedAgentsSessionRetriesExhaustedType.RetriesExhausted;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionRetriesExhausted
        {
            Type = BetaManagedAgentsSessionRetriesExhaustedType.RetriesExhausted,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionRetriesExhausted
        {
            Type = BetaManagedAgentsSessionRetriesExhaustedType.RetriesExhausted,
        };

        BetaManagedAgentsSessionRetriesExhausted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionRetriesExhaustedTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionRetriesExhaustedType.RetriesExhausted)]
    public void Validation_Works(BetaManagedAgentsSessionRetriesExhaustedType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionRetriesExhaustedType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionRetriesExhaustedType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionRetriesExhaustedType.RetriesExhausted)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionRetriesExhaustedType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionRetriesExhaustedType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionRetriesExhaustedType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionRetriesExhaustedType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionRetriesExhaustedType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
