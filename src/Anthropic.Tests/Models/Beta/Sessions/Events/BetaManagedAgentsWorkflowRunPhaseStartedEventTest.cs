using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsWorkflowRunPhaseStartedEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunPhaseStartedEvent
        {
            ID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:14.020Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            WorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
        };

        string expectedID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:14.020Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("workflow_run.phase_started");
        string expectedWorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd";
        string expectedWorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkflowRunID, model.WorkflowRunID);
        Assert.Equal(expectedWorkflowRunPhaseID, model.WorkflowRunPhaseID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunPhaseStartedEvent
        {
            ID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:14.020Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            WorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunPhaseStartedEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunPhaseStartedEvent
        {
            ID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:14.020Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            WorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunPhaseStartedEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:14.020Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("workflow_run.phase_started");
        string expectedWorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd";
        string expectedWorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkflowRunID, deserialized.WorkflowRunID);
        Assert.Equal(expectedWorkflowRunPhaseID, deserialized.WorkflowRunPhaseID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunPhaseStartedEvent
        {
            ID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:14.020Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            WorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunPhaseStartedEvent
        {
            ID = "sevt_01JQ8Z7M3P5R7T9V1X3Z5B7D",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:14.020Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
            WorkflowRunPhaseID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
        };

        BetaManagedAgentsWorkflowRunPhaseStartedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
