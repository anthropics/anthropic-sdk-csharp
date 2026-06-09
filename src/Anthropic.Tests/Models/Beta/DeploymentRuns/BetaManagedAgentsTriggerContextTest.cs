using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsTriggerContextTest : TestBase
{
    [Fact]
    public void ScheduleValidationWorks()
    {
        BetaManagedAgentsTriggerContext value = new BetaManagedAgentsScheduleTriggerContext()
        {
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsScheduleTriggerContextType.Schedule,
        };
        value.Validate();
    }

    [Fact]
    public void ManualValidationWorks()
    {
        BetaManagedAgentsTriggerContext value = new BetaManagedAgentsManualTriggerContext(
            BetaManagedAgentsManualTriggerContextType.Manual
        );
        value.Validate();
    }

    [Fact]
    public void ScheduleSerializationRoundtripWorks()
    {
        BetaManagedAgentsTriggerContext value = new BetaManagedAgentsScheduleTriggerContext()
        {
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsScheduleTriggerContextType.Schedule,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTriggerContext>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ManualSerializationRoundtripWorks()
    {
        BetaManagedAgentsTriggerContext value = new BetaManagedAgentsManualTriggerContext(
            BetaManagedAgentsManualTriggerContextType.Manual
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTriggerContext>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
