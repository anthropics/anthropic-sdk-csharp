using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsDeploymentRunTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeploymentRun
        {
            ID = "id",
            Agent = new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeploymentID = "deployment_id",
            Error = new BetaManagedAgentsEnvironmentArchivedRunError("message"),
            SessionID = "session_id",
            TriggerContext = new BetaManagedAgentsScheduleTriggerContext(
                DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
            ),
        };

        string expectedID = "id";
        BetaManagedAgentsAgentReference expectedAgent = new()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Version = 1,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDeploymentID = "deployment_id";
        Error expectedError = new BetaManagedAgentsEnvironmentArchivedRunError("message");
        string expectedSessionID = "session_id";
        BetaManagedAgentsTriggerContext expectedTriggerContext =
            new BetaManagedAgentsScheduleTriggerContext(
                DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
            );
        JsonElement expectedType = JsonSerializer.SerializeToElement("deployment_run");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgent, model.Agent);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDeploymentID, model.DeploymentID);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedSessionID, model.SessionID);
        Assert.Equal(expectedTriggerContext, model.TriggerContext);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeploymentRun
        {
            ID = "id",
            Agent = new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeploymentID = "deployment_id",
            Error = new BetaManagedAgentsEnvironmentArchivedRunError("message"),
            SessionID = "session_id",
            TriggerContext = new BetaManagedAgentsScheduleTriggerContext(
                DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentRun>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsDeploymentRun
        {
            ID = "id",
            Agent = new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeploymentID = "deployment_id",
            Error = new BetaManagedAgentsEnvironmentArchivedRunError("message"),
            SessionID = "session_id",
            TriggerContext = new BetaManagedAgentsScheduleTriggerContext(
                DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentRun>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        BetaManagedAgentsAgentReference expectedAgent = new()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Version = 1,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDeploymentID = "deployment_id";
        Error expectedError = new BetaManagedAgentsEnvironmentArchivedRunError("message");
        string expectedSessionID = "session_id";
        BetaManagedAgentsTriggerContext expectedTriggerContext =
            new BetaManagedAgentsScheduleTriggerContext(
                DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
            );
        JsonElement expectedType = JsonSerializer.SerializeToElement("deployment_run");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgent, deserialized.Agent);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDeploymentID, deserialized.DeploymentID);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedSessionID, deserialized.SessionID);
        Assert.Equal(expectedTriggerContext, deserialized.TriggerContext);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDeploymentRun
        {
            ID = "id",
            Agent = new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeploymentID = "deployment_id",
            Error = new BetaManagedAgentsEnvironmentArchivedRunError("message"),
            SessionID = "session_id",
            TriggerContext = new BetaManagedAgentsScheduleTriggerContext(
                DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
            ),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeploymentRun
        {
            ID = "id",
            Agent = new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeploymentID = "deployment_id",
            Error = new BetaManagedAgentsEnvironmentArchivedRunError("message"),
            SessionID = "session_id",
            TriggerContext = new BetaManagedAgentsScheduleTriggerContext(
                DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
            ),
        };

        BetaManagedAgentsDeploymentRun copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ErrorTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsEnvironmentArchivedRunValidationWorks()
    {
        Error value = new BetaManagedAgentsEnvironmentArchivedRunError("message");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAgentArchivedRunValidationWorks()
    {
        Error value = new BetaManagedAgentsAgentArchivedRunError("message");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsEnvironmentNotFoundRunValidationWorks()
    {
        Error value = new BetaManagedAgentsEnvironmentNotFoundRunError("message");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsVaultNotFoundRunValidationWorks()
    {
        Error value = new BetaManagedAgentsVaultNotFoundRunError("message");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsVaultArchivedRunValidationWorks()
    {
        Error value = new BetaManagedAgentsVaultArchivedRunError("message");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsFileNotFoundRunValidationWorks()
    {
        Error value = new BetaManagedAgentsFileNotFoundRunError("message");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMemoryStoreArchivedRunValidationWorks()
    {
        Error value = new BetaManagedAgentsMemoryStoreArchivedRunError("message");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSkillNotFoundRunValidationWorks()
    {
        Error value = new BetaManagedAgentsSkillNotFoundRunError("message");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionResourceNotFoundRunValidationWorks()
    {
        Error value = new BetaManagedAgentsSessionResourceNotFoundRunError("message");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsWorkspaceArchivedRunValidationWorks()
    {
        Error value = new BetaManagedAgentsWorkspaceArchivedRunError("message");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsOrganizationDisabledRunValidationWorks()
    {
        Error value = new BetaManagedAgentsOrganizationDisabledRunError("message");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionRateLimitedRunValidationWorks()
    {
        Error value = new BetaManagedAgentsSessionRateLimitedRunError("message");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSessionCreationRejectedRunValidationWorks()
    {
        Error value = new BetaManagedAgentsSessionCreationRejectedRunError("message");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUnknownRunValidationWorks()
    {
        Error value = new BetaManagedAgentsUnknownRunError("message");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSelfHostedResourcesUnsupportedRunValidationWorks()
    {
        Error value = new BetaManagedAgentsSelfHostedResourcesUnsupportedRunError("message");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMcpEgressBlockedRunValidationWorks()
    {
        Error value = new BetaManagedAgentsMcpEgressBlockedRunError("message");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsEnvironmentArchivedRunSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsEnvironmentArchivedRunError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAgentArchivedRunSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsAgentArchivedRunError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsEnvironmentNotFoundRunSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsEnvironmentNotFoundRunError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsVaultNotFoundRunSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsVaultNotFoundRunError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsVaultArchivedRunSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsVaultArchivedRunError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsFileNotFoundRunSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsFileNotFoundRunError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMemoryStoreArchivedRunSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsMemoryStoreArchivedRunError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSkillNotFoundRunSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsSkillNotFoundRunError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionResourceNotFoundRunSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsSessionResourceNotFoundRunError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsWorkspaceArchivedRunSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsWorkspaceArchivedRunError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsOrganizationDisabledRunSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsOrganizationDisabledRunError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionRateLimitedRunSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsSessionRateLimitedRunError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSessionCreationRejectedRunSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsSessionCreationRejectedRunError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsUnknownRunSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsUnknownRunError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSelfHostedResourcesUnsupportedRunSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsSelfHostedResourcesUnsupportedRunError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMcpEgressBlockedRunSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsMcpEgressBlockedRunError("message");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsEnvironmentArchivedRunTypeWorks()
    {
        Error value = new BetaManagedAgentsEnvironmentArchivedRunError("message");
        Assert.Equal(ErrorType.EnvironmentArchivedError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsAgentArchivedRunTypeWorks()
    {
        Error value = new BetaManagedAgentsAgentArchivedRunError("message");
        Assert.Equal(ErrorType.AgentArchivedError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsEnvironmentNotFoundRunTypeWorks()
    {
        Error value = new BetaManagedAgentsEnvironmentNotFoundRunError("message");
        Assert.Equal(ErrorType.EnvironmentNotFoundError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsVaultNotFoundRunTypeWorks()
    {
        Error value = new BetaManagedAgentsVaultNotFoundRunError("message");
        Assert.Equal(ErrorType.VaultNotFoundError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsVaultArchivedRunTypeWorks()
    {
        Error value = new BetaManagedAgentsVaultArchivedRunError("message");
        Assert.Equal(ErrorType.VaultArchivedError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsFileNotFoundRunTypeWorks()
    {
        Error value = new BetaManagedAgentsFileNotFoundRunError("message");
        Assert.Equal(ErrorType.FileNotFoundError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsMemoryStoreArchivedRunTypeWorks()
    {
        Error value = new BetaManagedAgentsMemoryStoreArchivedRunError("message");
        Assert.Equal(ErrorType.MemoryStoreArchivedError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsSkillNotFoundRunTypeWorks()
    {
        Error value = new BetaManagedAgentsSkillNotFoundRunError("message");
        Assert.Equal(ErrorType.SkillNotFoundError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsSessionResourceNotFoundRunTypeWorks()
    {
        Error value = new BetaManagedAgentsSessionResourceNotFoundRunError("message");
        Assert.Equal(ErrorType.SessionResourceNotFoundError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsWorkspaceArchivedRunTypeWorks()
    {
        Error value = new BetaManagedAgentsWorkspaceArchivedRunError("message");
        Assert.Equal(ErrorType.WorkspaceArchivedError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsOrganizationDisabledRunTypeWorks()
    {
        Error value = new BetaManagedAgentsOrganizationDisabledRunError("message");
        Assert.Equal(ErrorType.OrganizationDisabledError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsSessionRateLimitedRunTypeWorks()
    {
        Error value = new BetaManagedAgentsSessionRateLimitedRunError("message");
        Assert.Equal(ErrorType.SessionRateLimitedError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsSessionCreationRejectedRunTypeWorks()
    {
        Error value = new BetaManagedAgentsSessionCreationRejectedRunError("message");
        Assert.Equal(ErrorType.SessionCreationRejectedError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsUnknownRunTypeWorks()
    {
        Error value = new BetaManagedAgentsUnknownRunError("message");
        Assert.Equal(ErrorType.UnknownError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsSelfHostedResourcesUnsupportedRunTypeWorks()
    {
        Error value = new BetaManagedAgentsSelfHostedResourcesUnsupportedRunError("message");
        Assert.Equal(ErrorType.SelfHostedResourcesUnsupportedError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsMcpEgressBlockedRunTypeWorks()
    {
        Error value = new BetaManagedAgentsMcpEgressBlockedRunError("message");
        Assert.Equal(ErrorType.McpEgressBlockedError, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Error value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "message": "message",
                  "type": "environment_archived_error"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedMessage = "message";
        ApiEnum<string, ErrorType> expectedType = ErrorType.EnvironmentArchivedError;

        Assert.Equal(expectedMessage, value.Message);
        Assert.Equal(expectedType, value.Type);

        Error emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Message);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        Error mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "message": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.Message);
    }
}

public class ErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(ErrorType.EnvironmentArchivedError)]
    [InlineData(ErrorType.AgentArchivedError)]
    [InlineData(ErrorType.EnvironmentNotFoundError)]
    [InlineData(ErrorType.VaultNotFoundError)]
    [InlineData(ErrorType.VaultArchivedError)]
    [InlineData(ErrorType.FileNotFoundError)]
    [InlineData(ErrorType.MemoryStoreArchivedError)]
    [InlineData(ErrorType.SkillNotFoundError)]
    [InlineData(ErrorType.SessionResourceNotFoundError)]
    [InlineData(ErrorType.WorkspaceArchivedError)]
    [InlineData(ErrorType.OrganizationDisabledError)]
    [InlineData(ErrorType.SessionRateLimitedError)]
    [InlineData(ErrorType.SessionCreationRejectedError)]
    [InlineData(ErrorType.UnknownError)]
    [InlineData(ErrorType.SelfHostedResourcesUnsupportedError)]
    [InlineData(ErrorType.McpEgressBlockedError)]
    public void Validation_Works(ErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ErrorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ErrorType.EnvironmentArchivedError)]
    [InlineData(ErrorType.AgentArchivedError)]
    [InlineData(ErrorType.EnvironmentNotFoundError)]
    [InlineData(ErrorType.VaultNotFoundError)]
    [InlineData(ErrorType.VaultArchivedError)]
    [InlineData(ErrorType.FileNotFoundError)]
    [InlineData(ErrorType.MemoryStoreArchivedError)]
    [InlineData(ErrorType.SkillNotFoundError)]
    [InlineData(ErrorType.SessionResourceNotFoundError)]
    [InlineData(ErrorType.WorkspaceArchivedError)]
    [InlineData(ErrorType.OrganizationDisabledError)]
    [InlineData(ErrorType.SessionRateLimitedError)]
    [InlineData(ErrorType.SessionCreationRejectedError)]
    [InlineData(ErrorType.UnknownError)]
    [InlineData(ErrorType.SelfHostedResourcesUnsupportedError)]
    [InlineData(ErrorType.McpEgressBlockedError)]
    public void SerializationRoundtrip_Works(ErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ErrorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ErrorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ErrorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
