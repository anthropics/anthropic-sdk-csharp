using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsWorkflowRunErrorEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunErrorEvent
        {
            ID = "sevt_01JQ8ZB7T3X5Z7C9E1G3J5L7",
            Error = new BetaManagedAgentsProgramWorkflowRunError("The workflow run's plan failed."),
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.301Z"),
            WorkflowRunID = "wrun_011CZm5tR2nHw6Jc9Ys4PdKf",
        };

        string expectedID = "sevt_01JQ8ZB7T3X5Z7C9E1G3J5L7";
        BetaManagedAgentsWorkflowRunError expectedError =
            new BetaManagedAgentsProgramWorkflowRunError("The workflow run's plan failed.");
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.301Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("workflow_run.error");
        string expectedWorkflowRunID = "wrun_011CZm5tR2nHw6Jc9Ys4PdKf";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkflowRunID, model.WorkflowRunID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunErrorEvent
        {
            ID = "sevt_01JQ8ZB7T3X5Z7C9E1G3J5L7",
            Error = new BetaManagedAgentsProgramWorkflowRunError("The workflow run's plan failed."),
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.301Z"),
            WorkflowRunID = "wrun_011CZm5tR2nHw6Jc9Ys4PdKf",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunErrorEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunErrorEvent
        {
            ID = "sevt_01JQ8ZB7T3X5Z7C9E1G3J5L7",
            Error = new BetaManagedAgentsProgramWorkflowRunError("The workflow run's plan failed."),
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.301Z"),
            WorkflowRunID = "wrun_011CZm5tR2nHw6Jc9Ys4PdKf",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunErrorEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_01JQ8ZB7T3X5Z7C9E1G3J5L7";
        BetaManagedAgentsWorkflowRunError expectedError =
            new BetaManagedAgentsProgramWorkflowRunError("The workflow run's plan failed.");
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.301Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("workflow_run.error");
        string expectedWorkflowRunID = "wrun_011CZm5tR2nHw6Jc9Ys4PdKf";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkflowRunID, deserialized.WorkflowRunID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunErrorEvent
        {
            ID = "sevt_01JQ8ZB7T3X5Z7C9E1G3J5L7",
            Error = new BetaManagedAgentsProgramWorkflowRunError("The workflow run's plan failed."),
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.301Z"),
            WorkflowRunID = "wrun_011CZm5tR2nHw6Jc9Ys4PdKf",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunErrorEvent
        {
            ID = "sevt_01JQ8ZB7T3X5Z7C9E1G3J5L7",
            Error = new BetaManagedAgentsProgramWorkflowRunError("The workflow run's plan failed."),
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.301Z"),
            WorkflowRunID = "wrun_011CZm5tR2nHw6Jc9Ys4PdKf",
        };

        BetaManagedAgentsWorkflowRunErrorEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
