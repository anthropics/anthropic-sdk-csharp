using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsTokenEndpointAuthPostParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostParam
        {
            ClientSecret = "x",
            Type = BetaManagedAgentsTokenEndpointAuthPostParamType.ClientSecretPost,
        };

        string expectedClientSecret = "x";
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostParamType> expectedType =
            BetaManagedAgentsTokenEndpointAuthPostParamType.ClientSecretPost;

        Assert.Equal(expectedClientSecret, model.ClientSecret);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostParam
        {
            ClientSecret = "x",
            Type = BetaManagedAgentsTokenEndpointAuthPostParamType.ClientSecretPost,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthPostParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostParam
        {
            ClientSecret = "x",
            Type = BetaManagedAgentsTokenEndpointAuthPostParamType.ClientSecretPost,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthPostParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClientSecret = "x";
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostParamType> expectedType =
            BetaManagedAgentsTokenEndpointAuthPostParamType.ClientSecretPost;

        Assert.Equal(expectedClientSecret, deserialized.ClientSecret);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostParam
        {
            ClientSecret = "x",
            Type = BetaManagedAgentsTokenEndpointAuthPostParamType.ClientSecretPost,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostParam
        {
            ClientSecret = "x",
            Type = BetaManagedAgentsTokenEndpointAuthPostParamType.ClientSecretPost,
        };

        BetaManagedAgentsTokenEndpointAuthPostParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsTokenEndpointAuthPostParamTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsTokenEndpointAuthPostParamType.ClientSecretPost)]
    public void Validation_Works(BetaManagedAgentsTokenEndpointAuthPostParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostParamType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostParamType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsTokenEndpointAuthPostParamType.ClientSecretPost)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsTokenEndpointAuthPostParamType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostParamType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostParamType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostParamType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostParamType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
