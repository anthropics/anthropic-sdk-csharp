using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsDeploymentPausedReasonErrorTest : TestBase
{
    [Fact]
    public void EnvironmentArchivedValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError();
        value.Validate();
    }

    [Fact]
    public void AgentArchivedValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsAgentArchivedDeploymentPausedReasonError();
        value.Validate();
    }

    [Fact]
    public void EnvironmentNotFoundValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError();
        value.Validate();
    }

    [Fact]
    public void VaultNotFoundValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError();
        value.Validate();
    }

    [Fact]
    public void FileNotFoundValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsFileNotFoundDeploymentPausedReasonError();
        value.Validate();
    }

    [Fact]
    public void SessionResourceNotFoundValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError();
        value.Validate();
    }

    [Fact]
    public void WorkspaceArchivedValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError();
        value.Validate();
    }

    [Fact]
    public void OrganizationDisabledValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError();
        value.Validate();
    }

    [Fact]
    public void MemoryStoreArchivedValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError();
        value.Validate();
    }

    [Fact]
    public void SkillNotFoundValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError();
        value.Validate();
    }

    [Fact]
    public void VaultArchivedValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsVaultArchivedDeploymentPausedReasonError();
        value.Validate();
    }

    [Fact]
    public void UnknownValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsUnknownDeploymentPausedReasonError();
        value.Validate();
    }

    [Fact]
    public void SelfHostedResourcesUnsupportedValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError();
        value.Validate();
    }

    [Fact]
    public void McpEgressBlockedValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError();
        value.Validate();
    }

    [Fact]
    public void EnvironmentArchivedSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError();
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
            new BetaManagedAgentsAgentArchivedDeploymentPausedReasonError();
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
            new BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError();
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
            new BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError();
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
            new BetaManagedAgentsFileNotFoundDeploymentPausedReasonError();
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
            new BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError();
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
            new BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError();
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
            new BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError();
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
            new BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError();
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
            new BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError();
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
            new BetaManagedAgentsVaultArchivedDeploymentPausedReasonError();
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
            new BetaManagedAgentsUnknownDeploymentPausedReasonError();
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
            new BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError();
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
            new BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReasonError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EnvironmentArchivedTypeWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError();
        Assert.Equal(
            BetaManagedAgentsDeploymentPausedReasonErrorType.EnvironmentArchivedError,
            value.Type.Value()
        );
    }

    [Fact]
    public void AgentArchivedTypeWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsAgentArchivedDeploymentPausedReasonError();
        Assert.Equal(
            BetaManagedAgentsDeploymentPausedReasonErrorType.AgentArchivedError,
            value.Type.Value()
        );
    }

    [Fact]
    public void EnvironmentNotFoundTypeWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsEnvironmentNotFoundDeploymentPausedReasonError();
        Assert.Equal(
            BetaManagedAgentsDeploymentPausedReasonErrorType.EnvironmentNotFoundError,
            value.Type.Value()
        );
    }

    [Fact]
    public void VaultNotFoundTypeWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError();
        Assert.Equal(
            BetaManagedAgentsDeploymentPausedReasonErrorType.VaultNotFoundError,
            value.Type.Value()
        );
    }

    [Fact]
    public void FileNotFoundTypeWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsFileNotFoundDeploymentPausedReasonError();
        Assert.Equal(
            BetaManagedAgentsDeploymentPausedReasonErrorType.FileNotFoundError,
            value.Type.Value()
        );
    }

    [Fact]
    public void SessionResourceNotFoundTypeWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsSessionResourceNotFoundDeploymentPausedReasonError();
        Assert.Equal(
            BetaManagedAgentsDeploymentPausedReasonErrorType.SessionResourceNotFoundError,
            value.Type.Value()
        );
    }

    [Fact]
    public void WorkspaceArchivedTypeWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError();
        Assert.Equal(
            BetaManagedAgentsDeploymentPausedReasonErrorType.WorkspaceArchivedError,
            value.Type.Value()
        );
    }

    [Fact]
    public void OrganizationDisabledTypeWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsOrganizationDisabledDeploymentPausedReasonError();
        Assert.Equal(
            BetaManagedAgentsDeploymentPausedReasonErrorType.OrganizationDisabledError,
            value.Type.Value()
        );
    }

    [Fact]
    public void MemoryStoreArchivedTypeWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsMemoryStoreArchivedDeploymentPausedReasonError();
        Assert.Equal(
            BetaManagedAgentsDeploymentPausedReasonErrorType.MemoryStoreArchivedError,
            value.Type.Value()
        );
    }

    [Fact]
    public void SkillNotFoundTypeWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsSkillNotFoundDeploymentPausedReasonError();
        Assert.Equal(
            BetaManagedAgentsDeploymentPausedReasonErrorType.SkillNotFoundError,
            value.Type.Value()
        );
    }

    [Fact]
    public void VaultArchivedTypeWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsVaultArchivedDeploymentPausedReasonError();
        Assert.Equal(
            BetaManagedAgentsDeploymentPausedReasonErrorType.VaultArchivedError,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownTypeWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsUnknownDeploymentPausedReasonError();
        Assert.Equal(
            BetaManagedAgentsDeploymentPausedReasonErrorType.UnknownError,
            value.Type.Value()
        );
    }

    [Fact]
    public void SelfHostedResourcesUnsupportedTypeWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsSelfHostedResourcesUnsupportedDeploymentPausedReasonError();
        Assert.Equal(
            BetaManagedAgentsDeploymentPausedReasonErrorType.SelfHostedResourcesUnsupportedError,
            value.Type.Value()
        );
    }

    [Fact]
    public void McpEgressBlockedTypeWorks()
    {
        BetaManagedAgentsDeploymentPausedReasonError value =
            new BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError();
        Assert.Equal(
            BetaManagedAgentsDeploymentPausedReasonErrorType.McpEgressBlockedError,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsDeploymentPausedReasonError value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "environment_archived_error"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsDeploymentPausedReasonErrorType> expectedType =
            BetaManagedAgentsDeploymentPausedReasonErrorType.EnvironmentArchivedError;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsDeploymentPausedReasonError emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsDeploymentPausedReasonErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.EnvironmentArchivedError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.AgentArchivedError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.EnvironmentNotFoundError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.VaultNotFoundError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.FileNotFoundError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.SessionResourceNotFoundError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.WorkspaceArchivedError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.OrganizationDisabledError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.MemoryStoreArchivedError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.SkillNotFoundError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.VaultArchivedError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.UnknownError)]
    [InlineData(
        BetaManagedAgentsDeploymentPausedReasonErrorType.SelfHostedResourcesUnsupportedError
    )]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.McpEgressBlockedError)]
    public void Validation_Works(BetaManagedAgentsDeploymentPausedReasonErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeploymentPausedReasonErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentPausedReasonErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.EnvironmentArchivedError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.AgentArchivedError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.EnvironmentNotFoundError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.VaultNotFoundError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.FileNotFoundError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.SessionResourceNotFoundError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.WorkspaceArchivedError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.OrganizationDisabledError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.MemoryStoreArchivedError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.SkillNotFoundError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.VaultArchivedError)]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.UnknownError)]
    [InlineData(
        BetaManagedAgentsDeploymentPausedReasonErrorType.SelfHostedResourcesUnsupportedError
    )]
    [InlineData(BetaManagedAgentsDeploymentPausedReasonErrorType.McpEgressBlockedError)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsDeploymentPausedReasonErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeploymentPausedReasonErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentPausedReasonErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentPausedReasonErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentPausedReasonErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
