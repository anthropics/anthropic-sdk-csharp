using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsTokenEndpointAuthPostUpdateParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostUpdateParam
        {
            Type = BetaManagedAgentsTokenEndpointAuthPostUpdateParamType.ClientSecretPost,
            ClientSecret = "x",
        };

        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostUpdateParamType> expectedType =
            BetaManagedAgentsTokenEndpointAuthPostUpdateParamType.ClientSecretPost;
        string expectedClientSecret = "x";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedClientSecret, model.ClientSecret);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostUpdateParam
        {
            Type = BetaManagedAgentsTokenEndpointAuthPostUpdateParamType.ClientSecretPost,
            ClientSecret = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthPostUpdateParam>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostUpdateParam
        {
            Type = BetaManagedAgentsTokenEndpointAuthPostUpdateParamType.ClientSecretPost,
            ClientSecret = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthPostUpdateParam>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostUpdateParamType> expectedType =
            BetaManagedAgentsTokenEndpointAuthPostUpdateParamType.ClientSecretPost;
        string expectedClientSecret = "x";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedClientSecret, deserialized.ClientSecret);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostUpdateParam
        {
            Type = BetaManagedAgentsTokenEndpointAuthPostUpdateParamType.ClientSecretPost,
            ClientSecret = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostUpdateParam
        {
            Type = BetaManagedAgentsTokenEndpointAuthPostUpdateParamType.ClientSecretPost,
        };

        Assert.Null(model.ClientSecret);
        Assert.False(model.RawData.ContainsKey("client_secret"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostUpdateParam
        {
            Type = BetaManagedAgentsTokenEndpointAuthPostUpdateParamType.ClientSecretPost,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostUpdateParam
        {
            Type = BetaManagedAgentsTokenEndpointAuthPostUpdateParamType.ClientSecretPost,

            ClientSecret = null,
        };

        Assert.Null(model.ClientSecret);
        Assert.True(model.RawData.ContainsKey("client_secret"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostUpdateParam
        {
            Type = BetaManagedAgentsTokenEndpointAuthPostUpdateParamType.ClientSecretPost,

            ClientSecret = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthPostUpdateParam
        {
            Type = BetaManagedAgentsTokenEndpointAuthPostUpdateParamType.ClientSecretPost,
            ClientSecret = "x",
        };

        BetaManagedAgentsTokenEndpointAuthPostUpdateParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsTokenEndpointAuthPostUpdateParamTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsTokenEndpointAuthPostUpdateParamType.ClientSecretPost)]
    public void Validation_Works(BetaManagedAgentsTokenEndpointAuthPostUpdateParamType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostUpdateParamType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostUpdateParamType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsTokenEndpointAuthPostUpdateParamType.ClientSecretPost)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsTokenEndpointAuthPostUpdateParamType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostUpdateParamType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostUpdateParamType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostUpdateParamType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTokenEndpointAuthPostUpdateParamType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
