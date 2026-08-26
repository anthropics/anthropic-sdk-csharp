using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ExternalKeys;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalKeys;

public class BetaAzureExternalKeyConfigParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAzureExternalKeyConfigParam
        {
            KeyName = "key_name",
            TenantID = "tenant_id",
            VaultUri = "https://my-vault.vault.azure.net/",
            ClientID = "client_id",
        };

        string expectedKeyName = "key_name";
        string expectedTenantID = "tenant_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("azure");
        string expectedVaultUri = "https://my-vault.vault.azure.net/";
        string expectedClientID = "client_id";

        Assert.Equal(expectedKeyName, model.KeyName);
        Assert.Equal(expectedTenantID, model.TenantID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedVaultUri, model.VaultUri);
        Assert.Equal(expectedClientID, model.ClientID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAzureExternalKeyConfigParam
        {
            KeyName = "key_name",
            TenantID = "tenant_id",
            VaultUri = "https://my-vault.vault.azure.net/",
            ClientID = "client_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAzureExternalKeyConfigParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAzureExternalKeyConfigParam
        {
            KeyName = "key_name",
            TenantID = "tenant_id",
            VaultUri = "https://my-vault.vault.azure.net/",
            ClientID = "client_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAzureExternalKeyConfigParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedKeyName = "key_name";
        string expectedTenantID = "tenant_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("azure");
        string expectedVaultUri = "https://my-vault.vault.azure.net/";
        string expectedClientID = "client_id";

        Assert.Equal(expectedKeyName, deserialized.KeyName);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedVaultUri, deserialized.VaultUri);
        Assert.Equal(expectedClientID, deserialized.ClientID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAzureExternalKeyConfigParam
        {
            KeyName = "key_name",
            TenantID = "tenant_id",
            VaultUri = "https://my-vault.vault.azure.net/",
            ClientID = "client_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaAzureExternalKeyConfigParam
        {
            KeyName = "key_name",
            TenantID = "tenant_id",
            VaultUri = "https://my-vault.vault.azure.net/",
        };

        Assert.Null(model.ClientID);
        Assert.False(model.RawData.ContainsKey("client_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaAzureExternalKeyConfigParam
        {
            KeyName = "key_name",
            TenantID = "tenant_id",
            VaultUri = "https://my-vault.vault.azure.net/",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaAzureExternalKeyConfigParam
        {
            KeyName = "key_name",
            TenantID = "tenant_id",
            VaultUri = "https://my-vault.vault.azure.net/",

            ClientID = null,
        };

        Assert.Null(model.ClientID);
        Assert.True(model.RawData.ContainsKey("client_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaAzureExternalKeyConfigParam
        {
            KeyName = "key_name",
            TenantID = "tenant_id",
            VaultUri = "https://my-vault.vault.azure.net/",

            ClientID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAzureExternalKeyConfigParam
        {
            KeyName = "key_name",
            TenantID = "tenant_id",
            VaultUri = "https://my-vault.vault.azure.net/",
            ClientID = "client_id",
        };

        BetaAzureExternalKeyConfigParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
