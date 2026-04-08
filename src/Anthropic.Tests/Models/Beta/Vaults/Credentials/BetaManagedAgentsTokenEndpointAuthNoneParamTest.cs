using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsTokenEndpointAuthNoneParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthNoneParam
        {
            Type = BetaManagedAgentsTokenEndpointAuthNoneParamType.None,
        };

        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthNoneParamType> expectedType =
            BetaManagedAgentsTokenEndpointAuthNoneParamType.None;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthNoneParam
        {
            Type = BetaManagedAgentsTokenEndpointAuthNoneParamType.None,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthNoneParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthNoneParam
        {
            Type = BetaManagedAgentsTokenEndpointAuthNoneParamType.None,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthNoneParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthNoneParamType> expectedType =
            BetaManagedAgentsTokenEndpointAuthNoneParamType.None;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthNoneParam
        {
            Type = BetaManagedAgentsTokenEndpointAuthNoneParamType.None,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthNoneParam
        {
            Type = BetaManagedAgentsTokenEndpointAuthNoneParamType.None,
        };

        BetaManagedAgentsTokenEndpointAuthNoneParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsTokenEndpointAuthNoneParamTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsTokenEndpointAuthNoneParamType.None)]
    public void Validation_Works(BetaManagedAgentsTokenEndpointAuthNoneParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthNoneParamType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthNoneParamType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsTokenEndpointAuthNoneParamType.None)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsTokenEndpointAuthNoneParamType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthNoneParamType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthNoneParamType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthNoneParamType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthNoneParamType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
