using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Webhooks;

namespace Anthropic.Tests.Models.Beta.Webhooks;

public class BetaWebhookEventDataTest : TestBase
{
    [Fact]
    public void SessionCreatedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionCreatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void SessionPendingValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionPendingEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void SessionRunningValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionRunningEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void SessionIdledValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionIdledEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void SessionRequiresActionValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionRequiresActionEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void SessionArchivedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionArchivedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void SessionDeletedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionDeletedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void SessionStatusScheduledValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionStatusScheduledEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void SessionStatusRunStartedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionStatusRunStartedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void SessionStatusIdledValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionStatusIdledEventData()
        {
            ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            OrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };
        value.Validate();
    }

    [Fact]
    public void SessionStatusTerminatedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionStatusTerminatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void SessionThreadCreatedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionThreadCreatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void SessionThreadIdledValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionThreadIdledEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void SessionThreadTerminatedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionThreadTerminatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void SessionOutcomeEvaluationEndedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionOutcomeEvaluationEndedEventData()
        {
            ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            OrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };
        value.Validate();
    }

    [Fact]
    public void VaultCreatedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookVaultCreatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void VaultArchivedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookVaultArchivedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void VaultDeletedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookVaultDeletedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void VaultCredentialCreatedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookVaultCredentialCreatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            VaultID = "vault_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void VaultCredentialArchivedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookVaultCredentialArchivedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            VaultID = "vault_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void VaultCredentialDeletedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookVaultCredentialDeletedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            VaultID = "vault_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void VaultCredentialRefreshFailedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookVaultCredentialRefreshFailedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            VaultID = "vault_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void SessionCreatedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionCreatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionPendingSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionPendingEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionRunningSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionRunningEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionIdledSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionIdledEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionRequiresActionSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionRequiresActionEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionArchivedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionArchivedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionDeletedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionDeletedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionStatusScheduledSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionStatusScheduledEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionStatusRunStartedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionStatusRunStartedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionStatusIdledSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionStatusIdledEventData()
        {
            ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            OrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionStatusTerminatedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionStatusTerminatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionThreadCreatedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionThreadCreatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionThreadIdledSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionThreadIdledEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionThreadTerminatedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionThreadTerminatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionOutcomeEvaluationEndedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionOutcomeEvaluationEndedEventData()
        {
            ID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
            OrganizationID = "org_011CZkZZAe0sMna4vkBdtrfx",
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VaultCreatedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookVaultCreatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VaultArchivedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookVaultArchivedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VaultDeletedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookVaultDeletedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VaultCredentialCreatedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookVaultCredentialCreatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            VaultID = "vault_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VaultCredentialArchivedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookVaultCredentialArchivedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            VaultID = "vault_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VaultCredentialDeletedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookVaultCredentialDeletedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            VaultID = "vault_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VaultCredentialRefreshFailedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookVaultCredentialRefreshFailedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            VaultID = "vault_id",
            WorkspaceID = "workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
