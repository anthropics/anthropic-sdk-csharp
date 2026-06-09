using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsDeploymentPausedReasonErrorTest : TestBase
{
    [Fact]
    public void EnvironmentArchivedValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(
                BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType.EnvironmentArchivedError
            );
        value.Validate();
    }

    [Fact]
    public void AgentArchivedValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsAgentArchivedDeploymentPausedReasonError(Type.AgentArchivedError);
        value.Validate();
    }

    [Fact]
    public void EnvironmentNotFoundValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError(
                BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType.EnvironmentNotFoundError
            );
        value.Validate();
    }

    [Fact]
    public void VaultNotFoundValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError(
                BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorType.VaultNotFoundError
            );
        value.Validate();
    }

    [Fact]
    public void FileNotFoundValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsFileNotFoundDeploymentPausedReasonError(
                BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorType.FileNotFoundError
            );
        value.Validate();
    }

    [Fact]
    public void SessionResourceNotFoundValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError(
                BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType.SessionResourceNotFoundError
            );
        value.Validate();
    }

    [Fact]
    public void WorkspaceArchivedValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError(
                BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType.WorkspaceArchivedError
            );
        value.Validate();
    }

    [Fact]
    public void OrganizationDisabledValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError(
                BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorType.OrganizationDisabledError
            );
        value.Validate();
    }

    [Fact]
    public void MemoryStoreArchivedValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError(
                BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType.MemoryStoreArchivedError
            );
        value.Validate();
    }

    [Fact]
    public void SkillNotFoundValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError(
                BetaManagedAgentsSkillNotFoundDeploymentPausedReasonErrorType.SkillNotFoundError
            );
        value.Validate();
    }

    [Fact]
    public void VaultArchivedValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsVaultArchivedDeploymentPausedReasonError(
                BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType.VaultArchivedError
            );
        value.Validate();
    }

    [Fact]
    public void UnknownValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsUnknownDeploymentPausedReasonError(
                BetaManagedAgentsUnknownDeploymentPausedReasonErrorType.UnknownError
            );
        value.Validate();
    }

    [Fact]
    public void SelfHostedResourcesUnsupportedValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError(
                BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorType.SelfHostedResourcesUnsupportedError
            );
        value.Validate();
    }

    [Fact]
    public void McpEgressBlockedValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError(
                BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType.McpEgressBlockedError
            );
        value.Validate();
    }

    [Fact]
    public void EnvironmentArchivedSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(
                BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType.EnvironmentArchivedError
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReasonError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AgentArchivedSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsAgentArchivedDeploymentPausedReasonError(Type.AgentArchivedError);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReasonError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnvironmentNotFoundSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError(
                BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonErrorType.EnvironmentNotFoundError
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReasonError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VaultNotFoundSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError(
                BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorType.VaultNotFoundError
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReasonError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileNotFoundSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsFileNotFoundDeploymentPausedReasonError(
                BetaManagedAgentsFileNotFoundDeploymentPausedReasonErrorType.FileNotFoundError
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReasonError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionResourceNotFoundSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError(
                BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonErrorType.SessionResourceNotFoundError
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReasonError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkspaceArchivedSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError(
                BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType.WorkspaceArchivedError
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReasonError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OrganizationDisabledSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError(
                BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonErrorType.OrganizationDisabledError
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReasonError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MemoryStoreArchivedSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError(
                BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonErrorType.MemoryStoreArchivedError
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReasonError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SkillNotFoundSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError(
                BetaManagedAgentsSkillNotFoundDeploymentPausedReasonErrorType.SkillNotFoundError
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReasonError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VaultArchivedSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsVaultArchivedDeploymentPausedReasonError(
                BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType.VaultArchivedError
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReasonError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsUnknownDeploymentPausedReasonError(
                BetaManagedAgentsUnknownDeploymentPausedReasonErrorType.UnknownError
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReasonError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SelfHostedResourcesUnsupportedSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError(
                BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonErrorType.SelfHostedResourcesUnsupportedError
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReasonError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpEgressBlockedSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError(
                BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType.McpEgressBlockedError
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReasonError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
