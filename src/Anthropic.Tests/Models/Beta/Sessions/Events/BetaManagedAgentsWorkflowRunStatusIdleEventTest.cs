using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsWorkflowRunStatusIdleEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunStatusIdleEvent
        {
            ID = "sevt_01JQ8Z9A4C6E8G1J2L4N6Q8S",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:03:20.118Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };

        string expectedID = "sevt_01JQ8Z9A4C6E8G1J2L4N6Q8S";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-10-01T18:03:20.118Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("workflow_run.status_idle");
        string expectedWorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkflowRunID, model.WorkflowRunID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunStatusIdleEvent
        {
            ID = "sevt_01JQ8Z9A4C6E8G1J2L4N6Q8S",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:03:20.118Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunStatusIdleEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunStatusIdleEvent
        {
            ID = "sevt_01JQ8Z9A4C6E8G1J2L4N6Q8S",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:03:20.118Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunStatusIdleEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_01JQ8Z9A4C6E8G1J2L4N6Q8S";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-10-01T18:03:20.118Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("workflow_run.status_idle");
        string expectedWorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkflowRunID, deserialized.WorkflowRunID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunStatusIdleEvent
        {
            ID = "sevt_01JQ8Z9A4C6E8G1J2L4N6Q8S",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:03:20.118Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunStatusIdleEvent
        {
            ID = "sevt_01JQ8Z9A4C6E8G1J2L4N6Q8S",
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:03:20.118Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };

        BetaManagedAgentsWorkflowRunStatusIdleEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
