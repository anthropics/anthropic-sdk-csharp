using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsToolActionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsToolActions
        {
            EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
        };

        BetaAnalyticsToolActionCounts expectedEditTool = new()
        {
            AcceptedCount = 0,
            RejectedCount = 0,
        };
        BetaAnalyticsToolActionCounts expectedMultiEditTool = new()
        {
            AcceptedCount = 0,
            RejectedCount = 0,
        };
        BetaAnalyticsToolActionCounts expectedNotebookEditTool = new()
        {
            AcceptedCount = 0,
            RejectedCount = 0,
        };
        BetaAnalyticsToolActionCounts expectedWriteTool = new()
        {
            AcceptedCount = 0,
            RejectedCount = 0,
        };

        Assert.Equal(expectedEditTool, model.EditTool);
        Assert.Equal(expectedMultiEditTool, model.MultiEditTool);
        Assert.Equal(expectedNotebookEditTool, model.NotebookEditTool);
        Assert.Equal(expectedWriteTool, model.WriteTool);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsToolActions
        {
            EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsToolActions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsToolActions
        {
            EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsToolActions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaAnalyticsToolActionCounts expectedEditTool = new()
        {
            AcceptedCount = 0,
            RejectedCount = 0,
        };
        BetaAnalyticsToolActionCounts expectedMultiEditTool = new()
        {
            AcceptedCount = 0,
            RejectedCount = 0,
        };
        BetaAnalyticsToolActionCounts expectedNotebookEditTool = new()
        {
            AcceptedCount = 0,
            RejectedCount = 0,
        };
        BetaAnalyticsToolActionCounts expectedWriteTool = new()
        {
            AcceptedCount = 0,
            RejectedCount = 0,
        };

        Assert.Equal(expectedEditTool, deserialized.EditTool);
        Assert.Equal(expectedMultiEditTool, deserialized.MultiEditTool);
        Assert.Equal(expectedNotebookEditTool, deserialized.NotebookEditTool);
        Assert.Equal(expectedWriteTool, deserialized.WriteTool);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsToolActions
        {
            EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsToolActions
        {
            EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
        };

        BetaAnalyticsToolActions copied = new(model);

        Assert.Equal(model, copied);
    }
}
