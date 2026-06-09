using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using DeploymentRuns = Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsDeploymentRunTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeploymentRuns::BetaManagedAgentsDeploymentRun
        {
            ID = "id",
            Agent = new()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Type = BetaManagedAgentsAgentReferenceType.Agent,
                Version = 1,
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeploymentID = "deployment_id",
            Error = new DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError,
            },
            SessionID = "session_id",
            TriggerContext = new DeploymentRuns::BetaManagedAgentsScheduleTriggerContext()
            {
                ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = DeploymentRuns::BetaManagedAgentsScheduleTriggerContextType.Schedule,
            },
            Type = DeploymentRuns::BetaManagedAgentsDeploymentRunType.DeploymentRun,
        };

        string expectedID = "id";
        BetaManagedAgentsAgentReference expectedAgent = new()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Type = BetaManagedAgentsAgentReferenceType.Agent,
            Version = 1,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDeploymentID = "deployment_id";
        DeploymentRuns::Error expectedError =
            new DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError,
            };
        string expectedSessionID = "session_id";
        DeploymentRuns::BetaManagedAgentsTriggerContext expectedTriggerContext =
            new DeploymentRuns::BetaManagedAgentsScheduleTriggerContext()
            {
                ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = DeploymentRuns::BetaManagedAgentsScheduleTriggerContextType.Schedule,
            };
        ApiEnum<string, DeploymentRuns::BetaManagedAgentsDeploymentRunType> expectedType =
            DeploymentRuns::BetaManagedAgentsDeploymentRunType.DeploymentRun;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgent, model.Agent);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDeploymentID, model.DeploymentID);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedSessionID, model.SessionID);
        Assert.Equal(expectedTriggerContext, model.TriggerContext);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeploymentRuns::BetaManagedAgentsDeploymentRun
        {
            ID = "id",
            Agent = new()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Type = BetaManagedAgentsAgentReferenceType.Agent,
                Version = 1,
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeploymentID = "deployment_id",
            Error = new DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError,
            },
            SessionID = "session_id",
            TriggerContext = new DeploymentRuns::BetaManagedAgentsScheduleTriggerContext()
            {
                ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = DeploymentRuns::BetaManagedAgentsScheduleTriggerContextType.Schedule,
            },
            Type = DeploymentRuns::BetaManagedAgentsDeploymentRunType.DeploymentRun,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DeploymentRuns::BetaManagedAgentsDeploymentRun>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeploymentRuns::BetaManagedAgentsDeploymentRun
        {
            ID = "id",
            Agent = new()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Type = BetaManagedAgentsAgentReferenceType.Agent,
                Version = 1,
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeploymentID = "deployment_id",
            Error = new DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError,
            },
            SessionID = "session_id",
            TriggerContext = new DeploymentRuns::BetaManagedAgentsScheduleTriggerContext()
            {
                ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = DeploymentRuns::BetaManagedAgentsScheduleTriggerContextType.Schedule,
            },
            Type = DeploymentRuns::BetaManagedAgentsDeploymentRunType.DeploymentRun,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DeploymentRuns::BetaManagedAgentsDeploymentRun>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        BetaManagedAgentsAgentReference expectedAgent = new()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Type = BetaManagedAgentsAgentReferenceType.Agent,
            Version = 1,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDeploymentID = "deployment_id";
        DeploymentRuns::Error expectedError =
            new DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError,
            };
        string expectedSessionID = "session_id";
        DeploymentRuns::BetaManagedAgentsTriggerContext expectedTriggerContext =
            new DeploymentRuns::BetaManagedAgentsScheduleTriggerContext()
            {
                ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = DeploymentRuns::BetaManagedAgentsScheduleTriggerContextType.Schedule,
            };
        ApiEnum<string, DeploymentRuns::BetaManagedAgentsDeploymentRunType> expectedType =
            DeploymentRuns::BetaManagedAgentsDeploymentRunType.DeploymentRun;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgent, deserialized.Agent);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDeploymentID, deserialized.DeploymentID);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedSessionID, deserialized.SessionID);
        Assert.Equal(expectedTriggerContext, deserialized.TriggerContext);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeploymentRuns::BetaManagedAgentsDeploymentRun
        {
            ID = "id",
            Agent = new()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Type = BetaManagedAgentsAgentReferenceType.Agent,
                Version = 1,
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeploymentID = "deployment_id",
            Error = new DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError,
            },
            SessionID = "session_id",
            TriggerContext = new DeploymentRuns::BetaManagedAgentsScheduleTriggerContext()
            {
                ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = DeploymentRuns::BetaManagedAgentsScheduleTriggerContextType.Schedule,
            },
            Type = DeploymentRuns::BetaManagedAgentsDeploymentRunType.DeploymentRun,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeploymentRuns::BetaManagedAgentsDeploymentRun
        {
            ID = "id",
            Agent = new()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Type = BetaManagedAgentsAgentReferenceType.Agent,
                Version = 1,
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeploymentID = "deployment_id",
            Error = new DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError,
            },
            SessionID = "session_id",
            TriggerContext = new DeploymentRuns::BetaManagedAgentsScheduleTriggerContext()
            {
                ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = DeploymentRuns::BetaManagedAgentsScheduleTriggerContextType.Schedule,
            },
            Type = DeploymentRuns::BetaManagedAgentsDeploymentRunType.DeploymentRun,
        };

        DeploymentRuns::BetaManagedAgentsDeploymentRun copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ErrorTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsEnvironmentArchivedRunValidationWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError,
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAgentArchivedRunValidationWorks()
    {
        DeploymentRuns::Error value = new DeploymentRuns::BetaManagedAgentsAgentArchivedRunError()
        {
            Message = "message",
            Type = DeploymentRuns::Type.AgentArchivedError,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsEnvironmentNotFoundRunValidationWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsEnvironmentNotFoundRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsEnvironmentNotFoundRunErrorType.EnvironmentNotFoundError,
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsVaultNotFoundRunValidationWorks()
    {
        DeploymentRuns::Error value = new DeploymentRuns::BetaManagedAgentsVaultNotFoundRunError()
        {
            Message = "message",
            Type = DeploymentRuns::BetaManagedAgentsVaultNotFoundRunErrorType.VaultNotFoundError,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsVaultArchivedRunValidationWorks()
    {
        DeploymentRuns::Error value = new DeploymentRuns::BetaManagedAgentsVaultArchivedRunError()
        {
            Message = "message",
            Type = DeploymentRuns::BetaManagedAgentsVaultArchivedRunErrorType.VaultArchivedError,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsFileNotFoundRunValidationWorks()
    {
        DeploymentRuns::Error value = new DeploymentRuns::BetaManagedAgentsFileNotFoundRunError()
        {
            Message = "message",
            Type = DeploymentRuns::BetaManagedAgentsFileNotFoundRunErrorType.FileNotFoundError,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMemoryStoreArchivedRunValidationWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsMemoryStoreArchivedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsMemoryStoreArchivedRunErrorType.MemoryStoreArchivedError,
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSkillNotFoundRunValidationWorks()
    {
        DeploymentRuns::Error value = new DeploymentRuns::BetaManagedAgentsSkillNotFoundRunError()
        {
            Message = "message",
            Type = DeploymentRuns::BetaManagedAgentsSkillNotFoundRunErrorType.SkillNotFoundError,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionResourceNotFoundRunValidationWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsSessionResourceNotFoundRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsSessionResourceNotFoundRunErrorType.SessionResourceNotFoundError,
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsWorkspaceArchivedRunValidationWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsWorkspaceArchivedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsWorkspaceArchivedRunErrorType.WorkspaceArchivedError,
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsOrganizationDisabledRunValidationWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsOrganizationDisabledRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsOrganizationDisabledRunErrorType.OrganizationDisabledError,
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionRateLimitedRunValidationWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsSessionRateLimitedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsSessionRateLimitedRunErrorType.SessionRateLimitedError,
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionCreationRejectedRunValidationWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsSessionCreationRejectedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsSessionCreationRejectedRunErrorType.SessionCreationRejectedError,
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUnknownRunValidationWorks()
    {
        DeploymentRuns::Error value = new DeploymentRuns::BetaManagedAgentsUnknownRunError()
        {
            Message = "message",
            Type = DeploymentRuns::BetaManagedAgentsUnknownRunErrorType.UnknownError,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSelfHostedResourcesUnsupportedRunValidationWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsSelfHostedResourcesUnsupportedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType.SelfHostedResourcesUnsupportedError,
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMcpEgressBlockedRunValidationWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsMcpEgressBlockedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsMcpEgressBlockedRunErrorType.McpEgressBlockedError,
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsEnvironmentArchivedRunSerializationRoundtripWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsEnvironmentArchivedRunErrorType.EnvironmentArchivedError,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRuns::Error>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAgentArchivedRunSerializationRoundtripWorks()
    {
        DeploymentRuns::Error value = new DeploymentRuns::BetaManagedAgentsAgentArchivedRunError()
        {
            Message = "message",
            Type = DeploymentRuns::Type.AgentArchivedError,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRuns::Error>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsEnvironmentNotFoundRunSerializationRoundtripWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsEnvironmentNotFoundRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsEnvironmentNotFoundRunErrorType.EnvironmentNotFoundError,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRuns::Error>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsVaultNotFoundRunSerializationRoundtripWorks()
    {
        DeploymentRuns::Error value = new DeploymentRuns::BetaManagedAgentsVaultNotFoundRunError()
        {
            Message = "message",
            Type = DeploymentRuns::BetaManagedAgentsVaultNotFoundRunErrorType.VaultNotFoundError,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRuns::Error>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsVaultArchivedRunSerializationRoundtripWorks()
    {
        DeploymentRuns::Error value = new DeploymentRuns::BetaManagedAgentsVaultArchivedRunError()
        {
            Message = "message",
            Type = DeploymentRuns::BetaManagedAgentsVaultArchivedRunErrorType.VaultArchivedError,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRuns::Error>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsFileNotFoundRunSerializationRoundtripWorks()
    {
        DeploymentRuns::Error value = new DeploymentRuns::BetaManagedAgentsFileNotFoundRunError()
        {
            Message = "message",
            Type = DeploymentRuns::BetaManagedAgentsFileNotFoundRunErrorType.FileNotFoundError,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRuns::Error>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMemoryStoreArchivedRunSerializationRoundtripWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsMemoryStoreArchivedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsMemoryStoreArchivedRunErrorType.MemoryStoreArchivedError,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRuns::Error>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSkillNotFoundRunSerializationRoundtripWorks()
    {
        DeploymentRuns::Error value = new DeploymentRuns::BetaManagedAgentsSkillNotFoundRunError()
        {
            Message = "message",
            Type = DeploymentRuns::BetaManagedAgentsSkillNotFoundRunErrorType.SkillNotFoundError,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRuns::Error>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionResourceNotFoundRunSerializationRoundtripWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsSessionResourceNotFoundRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsSessionResourceNotFoundRunErrorType.SessionResourceNotFoundError,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRuns::Error>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsWorkspaceArchivedRunSerializationRoundtripWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsWorkspaceArchivedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsWorkspaceArchivedRunErrorType.WorkspaceArchivedError,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRuns::Error>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsOrganizationDisabledRunSerializationRoundtripWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsOrganizationDisabledRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsOrganizationDisabledRunErrorType.OrganizationDisabledError,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRuns::Error>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionRateLimitedRunSerializationRoundtripWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsSessionRateLimitedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsSessionRateLimitedRunErrorType.SessionRateLimitedError,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRuns::Error>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionCreationRejectedRunSerializationRoundtripWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsSessionCreationRejectedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsSessionCreationRejectedRunErrorType.SessionCreationRejectedError,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRuns::Error>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsUnknownRunSerializationRoundtripWorks()
    {
        DeploymentRuns::Error value = new DeploymentRuns::BetaManagedAgentsUnknownRunError()
        {
            Message = "message",
            Type = DeploymentRuns::BetaManagedAgentsUnknownRunErrorType.UnknownError,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRuns::Error>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSelfHostedResourcesUnsupportedRunSerializationRoundtripWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsSelfHostedResourcesUnsupportedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsSelfHostedResourcesUnsupportedRunErrorType.SelfHostedResourcesUnsupportedError,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRuns::Error>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMcpEgressBlockedRunSerializationRoundtripWorks()
    {
        DeploymentRuns::Error value =
            new DeploymentRuns::BetaManagedAgentsMcpEgressBlockedRunError()
            {
                Message = "message",
                Type =
                    DeploymentRuns::BetaManagedAgentsMcpEgressBlockedRunErrorType.McpEgressBlockedError,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRuns::Error>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsDeploymentRunTypeTest : TestBase
{
    [Theory]
    [InlineData(DeploymentRuns::BetaManagedAgentsDeploymentRunType.DeploymentRun)]
    public void Validation_Works(DeploymentRuns::BetaManagedAgentsDeploymentRunType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeploymentRuns::BetaManagedAgentsDeploymentRunType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeploymentRuns::BetaManagedAgentsDeploymentRunType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeploymentRuns::BetaManagedAgentsDeploymentRunType.DeploymentRun)]
    public void SerializationRoundtrip_Works(
        DeploymentRuns::BetaManagedAgentsDeploymentRunType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeploymentRuns::BetaManagedAgentsDeploymentRunType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeploymentRuns::BetaManagedAgentsDeploymentRunType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DeploymentRuns::BetaManagedAgentsDeploymentRunType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DeploymentRuns::BetaManagedAgentsDeploymentRunType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
