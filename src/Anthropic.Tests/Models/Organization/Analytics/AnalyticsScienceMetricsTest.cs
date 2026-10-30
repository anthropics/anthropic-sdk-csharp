using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Analytics;

namespace Anthropic.Tests.Models.Organization.Analytics;

public class AnalyticsScienceMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AnalyticsScienceMetrics
        {
            DelegationCount = 0,
            DistinctSessionCount = 0,
            MessageCount = 0,
            RemoteComputeJobCount = 0,
            SkillsUsedCount = 0,
        };

        long expectedDelegationCount = 0;
        long expectedDistinctSessionCount = 0;
        long expectedMessageCount = 0;
        long expectedRemoteComputeJobCount = 0;
        long expectedSkillsUsedCount = 0;

        Assert.Equal(expectedDelegationCount, model.DelegationCount);
        Assert.Equal(expectedDistinctSessionCount, model.DistinctSessionCount);
        Assert.Equal(expectedMessageCount, model.MessageCount);
        Assert.Equal(expectedRemoteComputeJobCount, model.RemoteComputeJobCount);
        Assert.Equal(expectedSkillsUsedCount, model.SkillsUsedCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AnalyticsScienceMetrics
        {
            DelegationCount = 0,
            DistinctSessionCount = 0,
            MessageCount = 0,
            RemoteComputeJobCount = 0,
            SkillsUsedCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsScienceMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AnalyticsScienceMetrics
        {
            DelegationCount = 0,
            DistinctSessionCount = 0,
            MessageCount = 0,
            RemoteComputeJobCount = 0,
            SkillsUsedCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsScienceMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDelegationCount = 0;
        long expectedDistinctSessionCount = 0;
        long expectedMessageCount = 0;
        long expectedRemoteComputeJobCount = 0;
        long expectedSkillsUsedCount = 0;

        Assert.Equal(expectedDelegationCount, deserialized.DelegationCount);
        Assert.Equal(expectedDistinctSessionCount, deserialized.DistinctSessionCount);
        Assert.Equal(expectedMessageCount, deserialized.MessageCount);
        Assert.Equal(expectedRemoteComputeJobCount, deserialized.RemoteComputeJobCount);
        Assert.Equal(expectedSkillsUsedCount, deserialized.SkillsUsedCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AnalyticsScienceMetrics
        {
            DelegationCount = 0,
            DistinctSessionCount = 0,
            MessageCount = 0,
            RemoteComputeJobCount = 0,
            SkillsUsedCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AnalyticsScienceMetrics
        {
            DelegationCount = 0,
            DistinctSessionCount = 0,
            MessageCount = 0,
            RemoteComputeJobCount = 0,
            SkillsUsedCount = 0,
        };

        AnalyticsScienceMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
