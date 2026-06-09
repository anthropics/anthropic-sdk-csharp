using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsEnvironmentVariableAuthResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableAuthResponse
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(
                BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType.Unrestricted
            ),
            SecretName = "secret_name",
            Type = BetaManagedAgentsEnvironmentVariableAuthResponseType.EnvironmentVariable,
        };

        Networking expectedNetworking =
            new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(
                BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType.Unrestricted
            );
        string expectedSecretName = "secret_name";
        ApiEnum<string, BetaManagedAgentsEnvironmentVariableAuthResponseType> expectedType =
            BetaManagedAgentsEnvironmentVariableAuthResponseType.EnvironmentVariable;

        Assert.Equal(expectedNetworking, model.Networking);
        Assert.Equal(expectedSecretName, model.SecretName);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableAuthResponse
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(
                BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType.Unrestricted
            ),
            SecretName = "secret_name",
            Type = BetaManagedAgentsEnvironmentVariableAuthResponseType.EnvironmentVariable,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentVariableAuthResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableAuthResponse
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(
                BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType.Unrestricted
            ),
            SecretName = "secret_name",
            Type = BetaManagedAgentsEnvironmentVariableAuthResponseType.EnvironmentVariable,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentVariableAuthResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        Networking expectedNetworking =
            new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(
                BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType.Unrestricted
            );
        string expectedSecretName = "secret_name";
        ApiEnum<string, BetaManagedAgentsEnvironmentVariableAuthResponseType> expectedType =
            BetaManagedAgentsEnvironmentVariableAuthResponseType.EnvironmentVariable;

        Assert.Equal(expectedNetworking, deserialized.Networking);
        Assert.Equal(expectedSecretName, deserialized.SecretName);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableAuthResponse
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(
                BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType.Unrestricted
            ),
            SecretName = "secret_name",
            Type = BetaManagedAgentsEnvironmentVariableAuthResponseType.EnvironmentVariable,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableAuthResponse
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(
                BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType.Unrestricted
            ),
            SecretName = "secret_name",
            Type = BetaManagedAgentsEnvironmentVariableAuthResponseType.EnvironmentVariable,
        };

        BetaManagedAgentsEnvironmentVariableAuthResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NetworkingTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsUnrestrictedCredentialNetworkingResponseValidationWorks()
    {
        Networking value = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(
            BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType.Unrestricted
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsLimitedCredentialNetworkingResponseValidationWorks()
    {
        Networking value = new BetaManagedAgentsLimitedCredentialNetworkingResponse()
        {
            AllowedHosts = ["string"],
            Type = BetaManagedAgentsLimitedCredentialNetworkingResponseType.Limited,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUnrestrictedCredentialNetworkingResponseSerializationRoundtripWorks()
    {
        Networking value = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(
            BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType.Unrestricted
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Networking>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsLimitedCredentialNetworkingResponseSerializationRoundtripWorks()
    {
        Networking value = new BetaManagedAgentsLimitedCredentialNetworkingResponse()
        {
            AllowedHosts = ["string"],
            Type = BetaManagedAgentsLimitedCredentialNetworkingResponseType.Limited,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Networking>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsEnvironmentVariableAuthResponseTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsEnvironmentVariableAuthResponseType.EnvironmentVariable)]
    public void Validation_Works(BetaManagedAgentsEnvironmentVariableAuthResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEnvironmentVariableAuthResponseType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentVariableAuthResponseType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsEnvironmentVariableAuthResponseType.EnvironmentVariable)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsEnvironmentVariableAuthResponseType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEnvironmentVariableAuthResponseType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentVariableAuthResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentVariableAuthResponseType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEnvironmentVariableAuthResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
