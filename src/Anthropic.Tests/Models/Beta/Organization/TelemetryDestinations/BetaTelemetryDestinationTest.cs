using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class BetaTelemetryDestinationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTelemetryDestination
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryHealth = new()
            {
                LastError = "last_error",
                LastErrorAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            HeaderNames = ["string"],
            State = new BetaTelemetryDestinationStateEnabled(),
            Traces = new()
            {
                ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
                Enabled = true,
                EndpointUrl = "endpoint_url",
                MaxContentBytes = 0,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Workspaces = new BetaTelemetryDestinationWorkspacesAll(),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaTelemetryDestinationDeliveryHealth expectedDeliveryHealth = new()
        {
            LastError = "last_error",
            LastErrorAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedDisplayName = "display_name";
        string expectedEndpointUrl = "endpoint_url";
        List<string> expectedHeaderNames = ["string"];
        BetaTelemetryDestinationState expectedState = new BetaTelemetryDestinationStateEnabled();
        BetaTelemetryDestinationTraces expectedTraces = new()
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            Enabled = true,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("telemetry_destination");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaTelemetryDestinationWorkspaces expectedWorkspaces =
            new BetaTelemetryDestinationWorkspacesAll();

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDeliveryHealth, model.DeliveryHealth);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedEndpointUrl, model.EndpointUrl);
        Assert.Equal(expectedHeaderNames.Count, model.HeaderNames.Count);
        for (int i = 0; i < expectedHeaderNames.Count; i++)
        {
            Assert.Equal(expectedHeaderNames[i], model.HeaderNames[i]);
        }
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedTraces, model.Traces);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedWorkspaces, model.Workspaces);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTelemetryDestination
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryHealth = new()
            {
                LastError = "last_error",
                LastErrorAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            HeaderNames = ["string"],
            State = new BetaTelemetryDestinationStateEnabled(),
            Traces = new()
            {
                ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
                Enabled = true,
                EndpointUrl = "endpoint_url",
                MaxContentBytes = 0,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Workspaces = new BetaTelemetryDestinationWorkspacesAll(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTelemetryDestination
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryHealth = new()
            {
                LastError = "last_error",
                LastErrorAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            HeaderNames = ["string"],
            State = new BetaTelemetryDestinationStateEnabled(),
            Traces = new()
            {
                ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
                Enabled = true,
                EndpointUrl = "endpoint_url",
                MaxContentBytes = 0,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Workspaces = new BetaTelemetryDestinationWorkspacesAll(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestination>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaTelemetryDestinationDeliveryHealth expectedDeliveryHealth = new()
        {
            LastError = "last_error",
            LastErrorAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedDisplayName = "display_name";
        string expectedEndpointUrl = "endpoint_url";
        List<string> expectedHeaderNames = ["string"];
        BetaTelemetryDestinationState expectedState = new BetaTelemetryDestinationStateEnabled();
        BetaTelemetryDestinationTraces expectedTraces = new()
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            Enabled = true,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("telemetry_destination");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaTelemetryDestinationWorkspaces expectedWorkspaces =
            new BetaTelemetryDestinationWorkspacesAll();

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDeliveryHealth, deserialized.DeliveryHealth);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedEndpointUrl, deserialized.EndpointUrl);
        Assert.Equal(expectedHeaderNames.Count, deserialized.HeaderNames.Count);
        for (int i = 0; i < expectedHeaderNames.Count; i++)
        {
            Assert.Equal(expectedHeaderNames[i], deserialized.HeaderNames[i]);
        }
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedTraces, deserialized.Traces);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedWorkspaces, deserialized.Workspaces);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTelemetryDestination
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryHealth = new()
            {
                LastError = "last_error",
                LastErrorAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            HeaderNames = ["string"],
            State = new BetaTelemetryDestinationStateEnabled(),
            Traces = new()
            {
                ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
                Enabled = true,
                EndpointUrl = "endpoint_url",
                MaxContentBytes = 0,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Workspaces = new BetaTelemetryDestinationWorkspacesAll(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaTelemetryDestination
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeliveryHealth = new()
            {
                LastError = "last_error",
                LastErrorAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            DisplayName = "display_name",
            EndpointUrl = "endpoint_url",
            HeaderNames = ["string"],
            State = new BetaTelemetryDestinationStateEnabled(),
            Traces = new()
            {
                ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
                Enabled = true,
                EndpointUrl = "endpoint_url",
                MaxContentBytes = 0,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Workspaces = new BetaTelemetryDestinationWorkspacesAll(),
        };

        BetaTelemetryDestination copied = new(model);

        Assert.Equal(model, copied);
    }
}
