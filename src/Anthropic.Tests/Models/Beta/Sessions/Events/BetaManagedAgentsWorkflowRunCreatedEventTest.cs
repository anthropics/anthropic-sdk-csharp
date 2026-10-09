using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsWorkflowRunCreatedEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunCreatedEvent
        {
            ID = "sevt_01JQ8Z6X8K2N4V7T9B3C5D1E",
            Description = "Reads each vendor's pricing page and tabulates the plans.",
            Name = "Compare the vendors",
            Phases =
            [
                new()
                {
                    ID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
                    Description = null,
                    Name = "Collect the sources",
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:11.412Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };

        string expectedID = "sevt_01JQ8Z6X8K2N4V7T9B3C5D1E";
        string expectedDescription = "Reads each vendor's pricing page and tabulates the plans.";
        string expectedName = "Compare the vendors";
        List<BetaManagedAgentsWorkflowRunPhase> expectedPhases =
        [
            new()
            {
                ID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
                Description = null,
                Name = "Collect the sources",
            },
        ];
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:11.412Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("workflow_run.created");
        string expectedWorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPhases.Count, model.Phases.Count);
        for (int i = 0; i < expectedPhases.Count; i++)
        {
            Assert.Equal(expectedPhases[i], model.Phases[i]);
        }
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkflowRunID, model.WorkflowRunID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunCreatedEvent
        {
            ID = "sevt_01JQ8Z6X8K2N4V7T9B3C5D1E",
            Description = "Reads each vendor's pricing page and tabulates the plans.",
            Name = "Compare the vendors",
            Phases =
            [
                new()
                {
                    ID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
                    Description = null,
                    Name = "Collect the sources",
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:11.412Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunCreatedEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunCreatedEvent
        {
            ID = "sevt_01JQ8Z6X8K2N4V7T9B3C5D1E",
            Description = "Reads each vendor's pricing page and tabulates the plans.",
            Name = "Compare the vendors",
            Phases =
            [
                new()
                {
                    ID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
                    Description = null,
                    Name = "Collect the sources",
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:11.412Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWorkflowRunCreatedEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_01JQ8Z6X8K2N4V7T9B3C5D1E";
        string expectedDescription = "Reads each vendor's pricing page and tabulates the plans.";
        string expectedName = "Compare the vendors";
        List<BetaManagedAgentsWorkflowRunPhase> expectedPhases =
        [
            new()
            {
                ID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
                Description = null,
                Name = "Collect the sources",
            },
        ];
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:11.412Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("workflow_run.created");
        string expectedWorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPhases.Count, deserialized.Phases.Count);
        for (int i = 0; i < expectedPhases.Count; i++)
        {
            Assert.Equal(expectedPhases[i], deserialized.Phases[i]);
        }
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkflowRunID, deserialized.WorkflowRunID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunCreatedEvent
        {
            ID = "sevt_01JQ8Z6X8K2N4V7T9B3C5D1E",
            Description = "Reads each vendor's pricing page and tabulates the plans.",
            Name = "Compare the vendors",
            Phases =
            [
                new()
                {
                    ID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
                    Description = null,
                    Name = "Collect the sources",
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:11.412Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsWorkflowRunCreatedEvent
        {
            ID = "sevt_01JQ8Z6X8K2N4V7T9B3C5D1E",
            Description = "Reads each vendor's pricing page and tabulates the plans.",
            Name = "Compare the vendors",
            Phases =
            [
                new()
                {
                    ID = "wrph_011CZm4Kq7RtY2Wn8Vx3LbHd",
                    Description = null,
                    Name = "Collect the sources",
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2026-10-01T18:02:11.412Z"),
            WorkflowRunID = "wrun_011CZm3vQ8pKx2Lr7Nq9TbYd",
        };

        BetaManagedAgentsWorkflowRunCreatedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
