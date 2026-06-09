using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsUnrestrictedCredentialNetworkingParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams
        {
            Type = BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted,
        };

        ApiEnum<string, BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType> expectedType =
            BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams
        {
            Type = BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUnrestrictedCredentialNetworkingParams>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams
        {
            Type = BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUnrestrictedCredentialNetworkingParams>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType> expectedType =
            BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams
        {
            Type = BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams
        {
            Type = BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted,
        };

        BetaManagedAgentsUnrestrictedCredentialNetworkingParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsUnrestrictedCredentialNetworkingParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted)]
    public void Validation_Works(
        BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
