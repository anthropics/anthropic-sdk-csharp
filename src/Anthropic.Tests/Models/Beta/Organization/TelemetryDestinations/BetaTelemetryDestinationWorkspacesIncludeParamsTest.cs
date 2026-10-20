using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class BetaTelemetryDestinationWorkspacesIncludeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTelemetryDestinationWorkspacesIncludeParams
        {
            WorkspaceIds = ["string"],
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("include");
        List<string> expectedWorkspaceIds = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.WorkspaceIds);
        Assert.Equal(expectedWorkspaceIds.Count, model.WorkspaceIds.Count);
        for (int i = 0; i < expectedWorkspaceIds.Count; i++)
        {
            Assert.Equal(expectedWorkspaceIds[i], model.WorkspaceIds[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTelemetryDestinationWorkspacesIncludeParams
        {
            WorkspaceIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaTelemetryDestinationWorkspacesIncludeParams>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTelemetryDestinationWorkspacesIncludeParams
        {
            WorkspaceIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaTelemetryDestinationWorkspacesIncludeParams>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("include");
        List<string> expectedWorkspaceIds = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.WorkspaceIds);
        Assert.Equal(expectedWorkspaceIds.Count, deserialized.WorkspaceIds.Count);
        for (int i = 0; i < expectedWorkspaceIds.Count; i++)
        {
            Assert.Equal(expectedWorkspaceIds[i], deserialized.WorkspaceIds[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTelemetryDestinationWorkspacesIncludeParams
        {
            WorkspaceIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaTelemetryDestinationWorkspacesIncludeParams { };

        Assert.Null(model.WorkspaceIds);
        Assert.False(model.RawData.ContainsKey("workspace_ids"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaTelemetryDestinationWorkspacesIncludeParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaTelemetryDestinationWorkspacesIncludeParams
        {
            // Null should be interpreted as omitted for these properties
            WorkspaceIds = null,
        };

        Assert.Null(model.WorkspaceIds);
        Assert.False(model.RawData.ContainsKey("workspace_ids"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaTelemetryDestinationWorkspacesIncludeParams
        {
            WorkspaceIds = ["string"],
        } with
        {
            // Null should be interpreted as omitted for these properties
            WorkspaceIds = null,
        };

        Assert.Null(model.WorkspaceIds);
        Assert.False(model.RawData.ContainsKey("workspace_ids"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaTelemetryDestinationWorkspacesIncludeParams
        {
            // Null should be interpreted as omitted for these properties
            WorkspaceIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaTelemetryDestinationWorkspacesIncludeParams
        {
            WorkspaceIds = ["string"],
        };

        BetaTelemetryDestinationWorkspacesIncludeParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
