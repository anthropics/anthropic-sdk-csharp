using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType.WorkspaceArchivedError,
        };

        ApiEnum<
            string,
            BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType
        > expectedType =
            BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType.WorkspaceArchivedError;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType.WorkspaceArchivedError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType.WorkspaceArchivedError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType
        > expectedType =
            BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType.WorkspaceArchivedError;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType.WorkspaceArchivedError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError
        {
            Type =
                BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType.WorkspaceArchivedError,
        };

        BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(
        BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType.WorkspaceArchivedError
    )]
    public void Validation_Works(
        BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType.WorkspaceArchivedError
    )]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWorkspaceArchivedDeploymentPausedReasonErrorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
