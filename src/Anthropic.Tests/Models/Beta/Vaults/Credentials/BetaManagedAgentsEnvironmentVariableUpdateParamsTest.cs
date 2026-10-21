using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsEnvironmentVariableUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            InjectionLocation = new() { Body = true, Header = true },
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretValue = "x",
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("environment_variable");
        BetaManagedAgentsInjectionLocationUpdateParams expectedInjectionLocation = new()
        {
            Body = true,
            Header = true,
        };
        BetaManagedAgentsCredentialNetworkingParams expectedNetworking =
            new BetaManagedAgentsUnrestrictedCredentialNetworkingParams();
        string expectedSecretValue = "x";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedInjectionLocation, model.InjectionLocation);
        Assert.Equal(expectedNetworking, model.Networking);
        Assert.Equal(expectedSecretValue, model.SecretValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            InjectionLocation = new() { Body = true, Header = true },
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
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
            InjectionLocation = new() { Body = true, Header = true },
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretValue = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsEnvironmentVariableUpdateParams>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("environment_variable");
        BetaManagedAgentsInjectionLocationUpdateParams expectedInjectionLocation = new()
        {
            Body = true,
            Header = true,
        };
        BetaManagedAgentsCredentialNetworkingParams expectedNetworking =
            new BetaManagedAgentsUnrestrictedCredentialNetworkingParams();
        string expectedSecretValue = "x";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedInjectionLocation, deserialized.InjectionLocation);
        Assert.Equal(expectedNetworking, deserialized.Networking);
        Assert.Equal(expectedSecretValue, deserialized.SecretValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            InjectionLocation = new() { Body = true, Header = true },
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretValue = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretValue = "x",
        };

        Assert.Null(model.InjectionLocation);
        Assert.False(model.RawData.ContainsKey("injection_location"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretValue = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
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
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            InjectionLocation = new() { Body = true, Header = true },
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretValue = "x",
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
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretValue = "x",

            // Null should be interpreted as omitted for these properties
            InjectionLocation = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            InjectionLocation = new() { Body = true, Header = true },
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
            InjectionLocation = new() { Body = true, Header = true },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsEnvironmentVariableUpdateParams
        {
            InjectionLocation = new() { Body = true, Header = true },

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
            InjectionLocation = new() { Body = true, Header = true },

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
            InjectionLocation = new() { Body = true, Header = true },
            Networking = new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(),
            SecretValue = "x",
        };

        BetaManagedAgentsEnvironmentVariableUpdateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
