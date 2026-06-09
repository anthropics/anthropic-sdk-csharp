using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsDeploymentPausedReasonTest : TestBase
{
    [Fact]
    public void ManualValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReason value =
            new BetaManagedAgentsManualDeploymentPausedReason(
                BetaManagedAgentsManualDeploymentPausedReasonType.Manual
            );
        value.Validate();
    }

    [Fact]
    public void ErrorValidationWorks()
    {
        BetaManagedAgentsDeploymentPausedReason value =
            new BetaManagedAgentsErrorDeploymentPausedReason()
            {
                Error = new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(
                    BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType.EnvironmentArchivedError
                ),
                Type = BetaManagedAgentsErrorDeploymentPausedReasonType.Error,
            };
        value.Validate();
    }

    [Fact]
    public void ManualSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReason value =
            new BetaManagedAgentsManualDeploymentPausedReason(
                BetaManagedAgentsManualDeploymentPausedReasonType.Manual
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ErrorSerializationRoundtripWorks()
    {
        BetaManagedAgentsDeploymentPausedReason value =
            new BetaManagedAgentsErrorDeploymentPausedReason()
            {
                Error = new BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonError(
                    BetaManagedAgentsEnvironmentArchivedDeploymentPausedReasonErrorType.EnvironmentArchivedError
                ),
                Type = BetaManagedAgentsErrorDeploymentPausedReasonType.Error,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentPausedReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
