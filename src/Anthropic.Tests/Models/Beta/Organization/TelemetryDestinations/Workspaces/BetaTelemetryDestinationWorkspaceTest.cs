using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.TelemetryDestinations.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations.Workspaces;

public class BetaTelemetryDestinationWorkspaceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTelemetryDestinationWorkspace
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TelemetryDestinationID = "telemetry_destination_id",
            WorkspaceID = "workspace_id",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTelemetryDestinationID = "telemetry_destination_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "telemetry_destination_workspace"
        );
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedTelemetryDestinationID, model.TelemetryDestinationID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTelemetryDestinationWorkspace
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TelemetryDestinationID = "telemetry_destination_id",
            WorkspaceID = "workspace_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationWorkspace>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTelemetryDestinationWorkspace
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TelemetryDestinationID = "telemetry_destination_id",
            WorkspaceID = "workspace_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationWorkspace>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTelemetryDestinationID = "telemetry_destination_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "telemetry_destination_workspace"
        );
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedTelemetryDestinationID, deserialized.TelemetryDestinationID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTelemetryDestinationWorkspace
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TelemetryDestinationID = "telemetry_destination_id",
            WorkspaceID = "workspace_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaTelemetryDestinationWorkspace
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TelemetryDestinationID = "telemetry_destination_id",
            WorkspaceID = "workspace_id",
        };

        BetaTelemetryDestinationWorkspace copied = new(model);

        Assert.Equal(model, copied);
    }
}
