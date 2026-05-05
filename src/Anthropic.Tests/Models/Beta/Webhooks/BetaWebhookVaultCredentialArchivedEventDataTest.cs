using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Webhooks;

namespace Anthropic.Tests.Models.Beta.Webhooks;

public class BetaWebhookVaultCredentialArchivedEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebhookVaultCredentialArchivedEventData
        {
            ID = "id",
            OrganizationID = "organization_id",
            VaultID = "vault_id",
            WorkspaceID = "workspace_id",
        };

        string expectedID = "id";
        string expectedOrganizationID = "organization_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("vault_credential.archived");
        string expectedVaultID = "vault_id";
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedVaultID, model.VaultID);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWebhookVaultCredentialArchivedEventData
        {
            ID = "id",
            OrganizationID = "organization_id",
            VaultID = "vault_id",
            WorkspaceID = "workspace_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookVaultCredentialArchivedEventData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebhookVaultCredentialArchivedEventData
        {
            ID = "id",
            OrganizationID = "organization_id",
            VaultID = "vault_id",
            WorkspaceID = "workspace_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookVaultCredentialArchivedEventData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedOrganizationID = "organization_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("vault_credential.archived");
        string expectedVaultID = "vault_id";
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedVaultID, deserialized.VaultID);
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWebhookVaultCredentialArchivedEventData
        {
            ID = "id",
            OrganizationID = "organization_id",
            VaultID = "vault_id",
            WorkspaceID = "workspace_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWebhookVaultCredentialArchivedEventData
        {
            ID = "id",
            OrganizationID = "organization_id",
            VaultID = "vault_id",
            WorkspaceID = "workspace_id",
        };

        BetaWebhookVaultCredentialArchivedEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}
