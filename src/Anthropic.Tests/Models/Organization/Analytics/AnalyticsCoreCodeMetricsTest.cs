using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Analytics;

namespace Anthropic.Tests.Models.Organization.Analytics;

public class AnalyticsCoreCodeMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AnalyticsCoreCodeMetrics
        {
            ArtifactsCreatedCount = 0,
            CommitCount = 0,
            DistinctSessionCount = 0,
            LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
            PullRequestCount = 0,
        };

        long expectedArtifactsCreatedCount = 0;
        long expectedCommitCount = 0;
        long expectedDistinctSessionCount = 0;
        AnalyticsLinesOfCode expectedLinesOfCode = new() { AddedCount = 0, RemovedCount = 0 };
        long expectedPullRequestCount = 0;

        Assert.Equal(expectedArtifactsCreatedCount, model.ArtifactsCreatedCount);
        Assert.Equal(expectedCommitCount, model.CommitCount);
        Assert.Equal(expectedDistinctSessionCount, model.DistinctSessionCount);
        Assert.Equal(expectedLinesOfCode, model.LinesOfCode);
        Assert.Equal(expectedPullRequestCount, model.PullRequestCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AnalyticsCoreCodeMetrics
        {
            ArtifactsCreatedCount = 0,
            CommitCount = 0,
            DistinctSessionCount = 0,
            LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
            PullRequestCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsCoreCodeMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AnalyticsCoreCodeMetrics
        {
            ArtifactsCreatedCount = 0,
            CommitCount = 0,
            DistinctSessionCount = 0,
            LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
            PullRequestCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsCoreCodeMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedArtifactsCreatedCount = 0;
        long expectedCommitCount = 0;
        long expectedDistinctSessionCount = 0;
        AnalyticsLinesOfCode expectedLinesOfCode = new() { AddedCount = 0, RemovedCount = 0 };
        long expectedPullRequestCount = 0;

        Assert.Equal(expectedArtifactsCreatedCount, deserialized.ArtifactsCreatedCount);
        Assert.Equal(expectedCommitCount, deserialized.CommitCount);
        Assert.Equal(expectedDistinctSessionCount, deserialized.DistinctSessionCount);
        Assert.Equal(expectedLinesOfCode, deserialized.LinesOfCode);
        Assert.Equal(expectedPullRequestCount, deserialized.PullRequestCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AnalyticsCoreCodeMetrics
        {
            ArtifactsCreatedCount = 0,
            CommitCount = 0,
            DistinctSessionCount = 0,
            LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
            PullRequestCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AnalyticsCoreCodeMetrics
        {
            ArtifactsCreatedCount = 0,
            CommitCount = 0,
            DistinctSessionCount = 0,
            LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
            PullRequestCount = 0,
        };

        AnalyticsCoreCodeMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
