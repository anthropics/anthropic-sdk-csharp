using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsCredentialNetworkingParamsTest : TestBase
{
    [Fact]
    public void UnrestrictedValidationWorks()
    {
        BetaManagedAgentsCredentialNetworkingParams value =
            new BetaManagedAgentsUnrestrictedCredentialNetworkingParams();
        value.Validate();
    }

    [Fact]
    public void LimitedValidationWorks()
    {
        BetaManagedAgentsCredentialNetworkingParams value =
            new BetaManagedAgentsLimitedCredentialNetworkingParams(["string"]);
        value.Validate();
    }

    [Fact]
    public void UnrestrictedSerializationRoundtripWorks()
    {
        BetaManagedAgentsCredentialNetworkingParams value =
            new BetaManagedAgentsUnrestrictedCredentialNetworkingParams();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCredentialNetworkingParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LimitedSerializationRoundtripWorks()
    {
        BetaManagedAgentsCredentialNetworkingParams value =
            new BetaManagedAgentsLimitedCredentialNetworkingParams(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCredentialNetworkingParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnrestrictedTypeWorks()
    {
        BetaManagedAgentsCredentialNetworkingParams value =
            new BetaManagedAgentsUnrestrictedCredentialNetworkingParams();
        Assert.Equal(
            BetaManagedAgentsCredentialNetworkingParamsType.Unrestricted,
            value.Type.Value()
        );
    }

    [Fact]
    public void LimitedTypeWorks()
    {
        BetaManagedAgentsCredentialNetworkingParams value =
            new BetaManagedAgentsLimitedCredentialNetworkingParams(["string"]);
        Assert.Equal(BetaManagedAgentsCredentialNetworkingParamsType.Limited, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsCredentialNetworkingParams value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "unrestricted"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsCredentialNetworkingParamsType> expectedType =
            BetaManagedAgentsCredentialNetworkingParamsType.Unrestricted;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsCredentialNetworkingParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsCredentialNetworkingParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsCredentialNetworkingParamsType.Unrestricted)]
    [InlineData(BetaManagedAgentsCredentialNetworkingParamsType.Limited)]
    public void Validation_Works(BetaManagedAgentsCredentialNetworkingParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCredentialNetworkingParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCredentialNetworkingParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsCredentialNetworkingParamsType.Unrestricted)]
    [InlineData(BetaManagedAgentsCredentialNetworkingParamsType.Limited)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsCredentialNetworkingParamsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCredentialNetworkingParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCredentialNetworkingParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCredentialNetworkingParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCredentialNetworkingParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
