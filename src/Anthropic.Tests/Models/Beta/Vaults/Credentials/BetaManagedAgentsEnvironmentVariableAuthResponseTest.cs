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
            InjectionLocation = new() { Body = true, Header = true },
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(),
            SecretName = "secret_name",
        };

        BetaManagedAgentsInjectionLocationResponse expectedInjectionLocation = new()
        {
            Body = true,
            Header = true,
        };
        Networking expectedNetworking =
            new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse();
        string expectedSecretName = "secret_name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("environment_variable");

        Assert.Equal(expectedInjectionLocation, model.InjectionLocation);
        Assert.Equal(expectedNetworking, model.Networking);
        Assert.Equal(expectedSecretName, model.SecretName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableAuthResponse
        {
            InjectionLocation = new() { Body = true, Header = true },
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(),
            SecretName = "secret_name",
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
            InjectionLocation = new() { Body = true, Header = true },
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(),
            SecretName = "secret_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentVariableAuthResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        BetaManagedAgentsInjectionLocationResponse expectedInjectionLocation = new()
        {
            Body = true,
            Header = true,
        };
        Networking expectedNetworking =
            new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse();
        string expectedSecretName = "secret_name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("environment_variable");

        Assert.Equal(expectedInjectionLocation, deserialized.InjectionLocation);
        Assert.Equal(expectedNetworking, deserialized.Networking);
        Assert.Equal(expectedSecretName, deserialized.SecretName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableAuthResponse
        {
            InjectionLocation = new() { Body = true, Header = true },
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(),
            SecretName = "secret_name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableAuthResponse
        {
            InjectionLocation = new() { Body = true, Header = true },
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(),
            SecretName = "secret_name",
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
        Networking value = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsLimitedCredentialNetworkingResponseValidationWorks()
    {
        Networking value = new BetaManagedAgentsLimitedCredentialNetworkingResponse(["string"]);
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUnrestrictedCredentialNetworkingResponseSerializationRoundtripWorks()
    {
        Networking value = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse();
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
        Networking value = new BetaManagedAgentsLimitedCredentialNetworkingResponse(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Networking>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsUnrestrictedCredentialNetworkingResponseTypeWorks()
    {
        Networking value = new BetaManagedAgentsUnrestrictedCredentialNetworkingResponse();
        Assert.Equal(NetworkingType.Unrestricted, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsLimitedCredentialNetworkingResponseTypeWorks()
    {
        Networking value = new BetaManagedAgentsLimitedCredentialNetworkingResponse(["string"]);
        Assert.Equal(NetworkingType.Limited, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Networking value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "unrestricted"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, NetworkingType> expectedType = NetworkingType.Unrestricted;

        Assert.Equal(expectedType, value.Type);

        Networking emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class NetworkingTypeTest : TestBase
{
    [Theory]
    [InlineData(NetworkingType.Unrestricted)]
    [InlineData(NetworkingType.Limited)]
    public void Validation_Works(NetworkingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NetworkingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NetworkingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NetworkingType.Unrestricted)]
    [InlineData(NetworkingType.Limited)]
    public void SerializationRoundtrip_Works(NetworkingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NetworkingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NetworkingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NetworkingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NetworkingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
