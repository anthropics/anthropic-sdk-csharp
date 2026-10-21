using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsEnvironmentVariableCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableCreateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretName = "x",
            SecretValue = "x",
            InjectionLocation = new() { Body = true, Header = true },
        };

        BetaManagedAgentsCredentialNetworkingParams expectedNetworking =
            new BetaManagedAgentsUnrestrictedCredentialNetworkingParams();
        string expectedSecretName = "x";
        string expectedSecretValue = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("environment_variable");
        BetaManagedAgentsInjectionLocationParams expectedInjectionLocation = new()
        {
            Body = true,
            Header = true,
        };

        Assert.Equal(expectedNetworking, model.Networking);
        Assert.Equal(expectedSecretName, model.SecretName);
        Assert.Equal(expectedSecretValue, model.SecretValue);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedInjectionLocation, model.InjectionLocation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableCreateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretName = "x",
            SecretValue = "x",
            InjectionLocation = new() { Body = true, Header = true },
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
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretName = "x",
            SecretValue = "x",
            InjectionLocation = new() { Body = true, Header = true },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentVariableCreateParams>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        BetaManagedAgentsCredentialNetworkingParams expectedNetworking =
            new BetaManagedAgentsUnrestrictedCredentialNetworkingParams();
        string expectedSecretName = "x";
        string expectedSecretValue = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("environment_variable");
        BetaManagedAgentsInjectionLocationParams expectedInjectionLocation = new()
        {
            Body = true,
            Header = true,
        };

        Assert.Equal(expectedNetworking, deserialized.Networking);
        Assert.Equal(expectedSecretName, deserialized.SecretName);
        Assert.Equal(expectedSecretValue, deserialized.SecretValue);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedInjectionLocation, deserialized.InjectionLocation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableCreateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretName = "x",
            SecretValue = "x",
            InjectionLocation = new() { Body = true, Header = true },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableCreateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretName = "x",
            SecretValue = "x",
        };

        Assert.Null(model.InjectionLocation);
        Assert.False(model.RawData.ContainsKey("injection_location"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableCreateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretName = "x",
            SecretValue = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableCreateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretName = "x",
            SecretValue = "x",

            // Null should be interpreted as omitted for these properties
            InjectionLocation = null,
        };

        Assert.Null(model.InjectionLocation);
        Assert.False(model.RawData.ContainsKey("injection_location"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableCreateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretName = "x",
            SecretValue = "x",
            InjectionLocation = new() { Body = true, Header = true },
        } with
        {
            // Null should be interpreted as omitted for these properties
            InjectionLocation = null,
        };

        Assert.Null(model.InjectionLocation);
        Assert.False(model.RawData.ContainsKey("injection_location"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableCreateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretName = "x",
            SecretValue = "x",

            // Null should be interpreted as omitted for these properties
            InjectionLocation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableCreateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretName = "x",
            SecretValue = "x",
            InjectionLocation = new() { Body = true, Header = true },
        };

        BetaManagedAgentsEnvironmentVariableCreateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
