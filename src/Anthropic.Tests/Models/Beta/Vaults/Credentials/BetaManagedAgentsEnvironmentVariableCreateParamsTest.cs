using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsEnvironmentVariableCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableCreateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted
            ),
            SecretName = "x",
            SecretValue = "x",
            Type = BetaManagedAgentsEnvironmentVariableCreateParamsType.EnvironmentVariable,
        };

        BetaManagedAgentsCredentialNetworkingParams expectedNetworking =
            new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted
            );
        string expectedSecretName = "x";
        string expectedSecretValue = "x";
        ApiEnum<string, BetaManagedAgentsEnvironmentVariableCreateParamsType> expectedType =
            BetaManagedAgentsEnvironmentVariableCreateParamsType.EnvironmentVariable;

        Assert.Equal(expectedNetworking, model.Networking);
        Assert.Equal(expectedSecretName, model.SecretName);
        Assert.Equal(expectedSecretValue, model.SecretValue);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableCreateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted
            ),
            SecretName = "x",
            SecretValue = "x",
            Type = BetaManagedAgentsEnvironmentVariableCreateParamsType.EnvironmentVariable,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentVariableCreateParams>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableCreateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted
            ),
            SecretName = "x",
            SecretValue = "x",
            Type = BetaManagedAgentsEnvironmentVariableCreateParamsType.EnvironmentVariable,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentVariableCreateParams>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        BetaManagedAgentsCredentialNetworkingParams expectedNetworking =
            new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted
            );
        string expectedSecretName = "x";
        string expectedSecretValue = "x";
        ApiEnum<string, BetaManagedAgentsEnvironmentVariableCreateParamsType> expectedType =
            BetaManagedAgentsEnvironmentVariableCreateParamsType.EnvironmentVariable;

        Assert.Equal(expectedNetworking, deserialized.Networking);
        Assert.Equal(expectedSecretName, deserialized.SecretName);
        Assert.Equal(expectedSecretValue, deserialized.SecretValue);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableCreateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted
            ),
            SecretName = "x",
            SecretValue = "x",
            Type = BetaManagedAgentsEnvironmentVariableCreateParamsType.EnvironmentVariable,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableCreateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted
            ),
            SecretName = "x",
            SecretValue = "x",
            Type = BetaManagedAgentsEnvironmentVariableCreateParamsType.EnvironmentVariable,
        };

        BetaManagedAgentsEnvironmentVariableCreateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsEnvironmentVariableCreateParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsEnvironmentVariableCreateParamsType.EnvironmentVariable)]
    public void Validation_Works(BetaManagedAgentsEnvironmentVariableCreateParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEnvironmentVariableCreateParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentVariableCreateParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsEnvironmentVariableCreateParamsType.EnvironmentVariable)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsEnvironmentVariableCreateParamsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEnvironmentVariableCreateParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentVariableCreateParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentVariableCreateParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentVariableCreateParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
