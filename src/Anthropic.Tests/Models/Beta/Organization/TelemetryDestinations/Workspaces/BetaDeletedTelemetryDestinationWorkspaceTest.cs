using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.TelemetryDestinations.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations.Workspaces;

public class BetaDeletedTelemetryDestinationWorkspaceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDeletedTelemetryDestinationWorkspace
        {
            TelemetryDestinationID = "telemetry_destination_id",
            WorkspaceID = "workspace_id",
        };

        string expectedTelemetryDestinationID = "telemetry_destination_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "telemetry_destination_workspace_deleted"
        );
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedTelemetryDestinationID, model.TelemetryDestinationID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDeletedTelemetryDestinationWorkspace
        {
            TelemetryDestinationID = "telemetry_destination_id",
            WorkspaceID = "workspace_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDeletedTelemetryDestinationWorkspace>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDeletedTelemetryDestinationWorkspace
        {
            TelemetryDestinationID = "telemetry_destination_id",
            WorkspaceID = "workspace_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDeletedTelemetryDestinationWorkspace>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTelemetryDestinationID = "telemetry_destination_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "telemetry_destination_workspace_deleted"
        );
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedTelemetryDestinationID, deserialized.TelemetryDestinationID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDeletedTelemetryDestinationWorkspace
        {
            TelemetryDestinationID = "telemetry_destination_id",
            WorkspaceID = "workspace_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDeletedTelemetryDestinationWorkspace
        {
            TelemetryDestinationID = "telemetry_destination_id",
            WorkspaceID = "workspace_id",
        };

        BetaDeletedTelemetryDestinationWorkspace copied = new(model);

        Assert.Equal(model, copied);
    }
}
