using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsClaudeCodeMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsClaudeCodeMetrics
        {
            CoreMetrics = new()
            {
                ArtifactsCreatedCount = 0,
                CommitCount = 0,
                DistinctSessionCount = 0,
                LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
                PullRequestCount = 0,
            },
            ToolActions = new()
            {
                EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            },
        };

        BetaAnalyticsCoreCodeMetrics expectedCoreMetrics = new()
        {
            ArtifactsCreatedCount = 0,
            CommitCount = 0,
            DistinctSessionCount = 0,
            LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
            PullRequestCount = 0,
        };
        BetaAnalyticsToolActions expectedToolActions = new()
        {
            EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
        };

        Assert.Equal(expectedCoreMetrics, model.CoreMetrics);
        Assert.Equal(expectedToolActions, model.ToolActions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsClaudeCodeMetrics
        {
            CoreMetrics = new()
            {
                ArtifactsCreatedCount = 0,
                CommitCount = 0,
                DistinctSessionCount = 0,
                LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
                PullRequestCount = 0,
            },
            ToolActions = new()
            {
                EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsClaudeCodeMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsClaudeCodeMetrics
        {
            CoreMetrics = new()
            {
                ArtifactsCreatedCount = 0,
                CommitCount = 0,
                DistinctSessionCount = 0,
                LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
                PullRequestCount = 0,
            },
            ToolActions = new()
            {
                EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsClaudeCodeMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaAnalyticsCoreCodeMetrics expectedCoreMetrics = new()
        {
            ArtifactsCreatedCount = 0,
            CommitCount = 0,
            DistinctSessionCount = 0,
            LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
            PullRequestCount = 0,
        };
        BetaAnalyticsToolActions expectedToolActions = new()
        {
            EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
        };

        Assert.Equal(expectedCoreMetrics, deserialized.CoreMetrics);
        Assert.Equal(expectedToolActions, deserialized.ToolActions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsClaudeCodeMetrics
        {
            CoreMetrics = new()
            {
                ArtifactsCreatedCount = 0,
                CommitCount = 0,
                DistinctSessionCount = 0,
                LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
                PullRequestCount = 0,
            },
            ToolActions = new()
            {
                EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsClaudeCodeMetrics
        {
            CoreMetrics = new()
            {
                ArtifactsCreatedCount = 0,
                CommitCount = 0,
                DistinctSessionCount = 0,
                LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
                PullRequestCount = 0,
            },
            ToolActions = new()
            {
                EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            },
        };

        BetaAnalyticsClaudeCodeMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
