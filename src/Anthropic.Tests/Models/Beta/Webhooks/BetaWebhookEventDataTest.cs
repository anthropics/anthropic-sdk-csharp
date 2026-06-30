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
    public void SessionStatusRescheduledValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionStatusRescheduledEventData()
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
            SessionThreadID = "session_thread_id",
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
            SessionThreadID = "session_thread_id",
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
            SessionThreadID = "session_thread_id",
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
    public void SessionUpdatedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionUpdatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void AgentCreatedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookAgentCreatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void AgentArchivedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookAgentArchivedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void AgentDeletedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookAgentDeletedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void DeploymentPausedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentPausedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void DeploymentRunFailedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentRunFailedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void DeploymentCreatedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentCreatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void DeploymentUpdatedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentUpdatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void DeploymentUnpausedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentUnpausedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void AgentUpdatedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookAgentUpdatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void DeploymentArchivedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentArchivedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void DeploymentRunStartedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentRunStartedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void DeploymentDeletedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentDeletedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void DeploymentRunSucceededValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentRunSucceededEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void EnvironmentCreatedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookEnvironmentCreatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void EnvironmentUpdatedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookEnvironmentUpdatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void EnvironmentArchivedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookEnvironmentArchivedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void EnvironmentDeletedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookEnvironmentDeletedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            Type = BetaWebhookEnvironmentDeletedEventType.EnvironmentDeleted,
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void MemoryStoreCreatedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookMemoryStoreCreatedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void MemoryStoreArchivedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookMemoryStoreArchivedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            WorkspaceID = "workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void MemoryStoreDeletedValidationWorks()
    {
        BetaWebhookEventData value = new BetaWebhookMemoryStoreDeletedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
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
    public void SessionStatusRescheduledSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionStatusRescheduledEventData()
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
            SessionThreadID = "session_thread_id",
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
            SessionThreadID = "session_thread_id",
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
            SessionThreadID = "session_thread_id",
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

    [Fact]
    public void SessionUpdatedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookSessionUpdatedEventData()
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
    public void AgentCreatedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookAgentCreatedEventData()
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
    public void AgentArchivedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookAgentArchivedEventData()
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
    public void AgentDeletedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookAgentDeletedEventData()
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
    public void DeploymentPausedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentPausedEventData()
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
    public void DeploymentRunFailedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentRunFailedEventData()
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
    public void DeploymentCreatedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentCreatedEventData()
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
    public void DeploymentUpdatedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentUpdatedEventData()
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
    public void DeploymentUnpausedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentUnpausedEventData()
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
    public void AgentUpdatedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookAgentUpdatedEventData()
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
    public void DeploymentArchivedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentArchivedEventData()
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
    public void DeploymentRunStartedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentRunStartedEventData()
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
    public void DeploymentDeletedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentDeletedEventData()
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
    public void DeploymentRunSucceededSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookDeploymentRunSucceededEventData()
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
    public void EnvironmentCreatedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookEnvironmentCreatedEventData()
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
    public void EnvironmentUpdatedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookEnvironmentUpdatedEventData()
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
    public void EnvironmentArchivedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookEnvironmentArchivedEventData()
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
    public void EnvironmentDeletedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookEnvironmentDeletedEventData()
        {
            ID = "id",
            OrganizationID = "organization_id",
            Type = BetaWebhookEnvironmentDeletedEventType.EnvironmentDeleted,
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
    public void MemoryStoreCreatedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookMemoryStoreCreatedEventData()
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
    public void MemoryStoreArchivedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookMemoryStoreArchivedEventData()
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
    public void MemoryStoreDeletedSerializationRoundtripWorks()
    {
        BetaWebhookEventData value = new BetaWebhookMemoryStoreDeletedEventData()
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
}
