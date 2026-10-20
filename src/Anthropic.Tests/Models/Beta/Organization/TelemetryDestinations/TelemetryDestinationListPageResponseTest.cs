using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class TelemetryDestinationListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TelemetryDestinationListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        List<BetaTelemetryDestination> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TelemetryDestinationListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TelemetryDestinationListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TelemetryDestinationListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TelemetryDestinationListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaTelemetryDestination> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TelemetryDestinationListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TelemetryDestinationListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        TelemetryDestinationListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
