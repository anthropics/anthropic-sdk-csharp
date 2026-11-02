using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Analytics;

namespace Anthropic.Tests.Models.Organization.Analytics;

public class AnalyticsToolActionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AnalyticsToolActions
        {
            EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
        };

        AnalyticsToolActionCounts expectedEditTool = new() { AcceptedCount = 0, RejectedCount = 0 };
        AnalyticsToolActionCounts expectedMultiEditTool = new()
        {
            AcceptedCount = 0,
            RejectedCount = 0,
        };
        AnalyticsToolActionCounts expectedNotebookEditTool = new()
        {
            AcceptedCount = 0,
            RejectedCount = 0,
        };
        AnalyticsToolActionCounts expectedWriteTool = new()
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
        var model = new AnalyticsToolActions
        {
            EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsToolActions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AnalyticsToolActions
        {
            EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsToolActions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AnalyticsToolActionCounts expectedEditTool = new() { AcceptedCount = 0, RejectedCount = 0 };
        AnalyticsToolActionCounts expectedMultiEditTool = new()
        {
            AcceptedCount = 0,
            RejectedCount = 0,
        };
        AnalyticsToolActionCounts expectedNotebookEditTool = new()
        {
            AcceptedCount = 0,
            RejectedCount = 0,
        };
        AnalyticsToolActionCounts expectedWriteTool = new()
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
        var model = new AnalyticsToolActions
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
        var model = new AnalyticsToolActions
        {
            EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
        };

        AnalyticsToolActions copied = new(model);

        Assert.Equal(model, copied);
    }
}
