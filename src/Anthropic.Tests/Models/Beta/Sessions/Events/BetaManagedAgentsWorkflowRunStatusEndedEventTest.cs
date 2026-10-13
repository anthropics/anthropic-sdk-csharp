using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsWorkflowRunStatusEndedEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunStatusEndedEvent
        {
            ID = "sevt_01JQ8ZC1V5B7N9M1K3J5H7GA",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.337Z"),
            Result = new BetaManagedAgentsWorkflowRunResultCompleted(),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };

        string expectedID = "sevt_01JQ8ZC1V5B7N9M1K3J5H7GA";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.337Z");
        BetaManagedAgentsWorkflowRunResult expectedResult =
            new BetaManagedAgentsWorkflowRunResultCompleted();
        JsonElement expectedType = JsonSerializer.SerializeToElement("workflow_run.status_ended");
        string expectedWorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedResult, model.Result);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkflowRunID, model.WorkflowRunID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunStatusEndedEvent
        {
            ID = "sevt_01JQ8ZC1V5B7N9M1K3J5H7GA",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.337Z"),
            Result = new BetaManagedAgentsWorkflowRunResultCompleted(),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunStatusEndedEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunStatusEndedEvent
        {
            ID = "sevt_01JQ8ZC1V5B7N9M1K3J5H7GA",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.337Z"),
            Result = new BetaManagedAgentsWorkflowRunResultCompleted(),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunStatusEndedEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_01JQ8ZC1V5B7N9M1K3J5H7GA";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.337Z");
        BetaManagedAgentsWorkflowRunResult expectedResult =
            new BetaManagedAgentsWorkflowRunResultCompleted();
        JsonElement expectedType = JsonSerializer.SerializeToElement("workflow_run.status_ended");
        string expectedWorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkflowRunID, deserialized.WorkflowRunID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunStatusEndedEvent
        {
            ID = "sevt_01JQ8ZC1V5B7N9M1K3J5H7GA",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.337Z"),
            Result = new BetaManagedAgentsWorkflowRunResultCompleted(),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunStatusEndedEvent
        {
            ID = "sevt_01JQ8ZC1V5B7N9M1K3J5H7GA",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:05:02.337Z"),
            Result = new BetaManagedAgentsWorkflowRunResultCompleted(),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };

        BetaManagedAgentsWorkflowRunStatusEndedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
