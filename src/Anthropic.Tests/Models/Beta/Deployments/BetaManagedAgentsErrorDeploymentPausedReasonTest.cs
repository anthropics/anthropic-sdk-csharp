using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsErrorDeploymentPausedReasonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsErrorDeploymentPausedReason
        {
            Error = new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(),
        };

        BetaManagedAgentsDeploymentPausedReasonError expectedError =
            new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError();
        JsonElement expectedType = JsonSerializer.SerializeToElement("error");

        Assert.Equal(expectedError, model.Error);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsErrorDeploymentPausedReason
        {
            Error = new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsErrorDeploymentPausedReason>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsErrorDeploymentPausedReason
        {
            Error = new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsErrorDeploymentPausedReason>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsDeploymentPausedReasonError expectedError =
            new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError();
        JsonElement expectedType = JsonSerializer.SerializeToElement("error");

        Assert.Equal(expectedError, deserialized.Error);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsErrorDeploymentPausedReason
        {
            Error = new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsErrorDeploymentPausedReason
        {
            Error = new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(),
        };

        BetaManagedAgentsErrorDeploymentPausedReason copied = new(model);

        Assert.Equal(model, copied);
    }
}
