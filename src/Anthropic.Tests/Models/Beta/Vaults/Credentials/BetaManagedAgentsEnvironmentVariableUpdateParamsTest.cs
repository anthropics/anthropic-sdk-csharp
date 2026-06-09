using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsEnvironmentVariableUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            Type = BetaManagedAgentsEnvironmentVariableUpdateParamsType.EnvironmentVariable,
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted
            ),
            SecretValue = "x",
        };

        ApiEnum<string, BetaManagedAgentsEnvironmentVariableUpdateParamsType> expectedType =
            BetaManagedAgentsEnvironmentVariableUpdateParamsType.EnvironmentVariable;
        BetaManagedAgentsCredentialNetworkingParams expectedNetworking =
            new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted
            );
        string expectedSecretValue = "x";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedNetworking, model.Networking);
        Assert.Equal(expectedSecretValue, model.SecretValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            Type = BetaManagedAgentsEnvironmentVariableUpdateParamsType.EnvironmentVariable,
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted
            ),
            SecretValue = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentVariableUpdateParams>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            Type = BetaManagedAgentsEnvironmentVariableUpdateParamsType.EnvironmentVariable,
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted
            ),
            SecretValue = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentVariableUpdateParams>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsEnvironmentVariableUpdateParamsType> expectedType =
            BetaManagedAgentsEnvironmentVariableUpdateParamsType.EnvironmentVariable;
        BetaManagedAgentsCredentialNetworkingParams expectedNetworking =
            new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted
            );
        string expectedSecretValue = "x";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedNetworking, deserialized.Networking);
        Assert.Equal(expectedSecretValue, deserialized.SecretValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            Type = BetaManagedAgentsEnvironmentVariableUpdateParamsType.EnvironmentVariable,
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted
            ),
            SecretValue = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            Type = BetaManagedAgentsEnvironmentVariableUpdateParamsType.EnvironmentVariable,
        };

        Assert.Null(model.Networking);
        Assert.False(model.RawData.ContainsKey("networking"));
        Assert.Null(model.SecretValue);
        Assert.False(model.RawData.ContainsKey("secret_value"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            Type = BetaManagedAgentsEnvironmentVariableUpdateParamsType.EnvironmentVariable,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            Type = BetaManagedAgentsEnvironmentVariableUpdateParamsType.EnvironmentVariable,

            Networking = null,
            SecretValue = null,
        };

        Assert.Null(model.Networking);
        Assert.True(model.RawData.ContainsKey("networking"));
        Assert.Null(model.SecretValue);
        Assert.True(model.RawData.ContainsKey("secret_value"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            Type = BetaManagedAgentsEnvironmentVariableUpdateParamsType.EnvironmentVariable,

            Networking = null,
            SecretValue = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            Type = BetaManagedAgentsEnvironmentVariableUpdateParamsType.EnvironmentVariable,
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted
            ),
            SecretValue = "x",
        };

        BetaManagedAgentsEnvironmentVariableUpdateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsEnvironmentVariableUpdateParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsEnvironmentVariableUpdateParamsType.EnvironmentVariable)]
    public void Validation_Works(BetaManagedAgentsEnvironmentVariableUpdateParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEnvironmentVariableUpdateParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentVariableUpdateParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsEnvironmentVariableUpdateParamsType.EnvironmentVariable)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsEnvironmentVariableUpdateParamsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEnvironmentVariableUpdateParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentVariableUpdateParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentVariableUpdateParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentVariableUpdateParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
