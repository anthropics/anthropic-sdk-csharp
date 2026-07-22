using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Environments.Work;

namespace Anthropic.Tests.Models.Beta.Environments.Work;

public class BetaSelfHostedWorkListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSelfHostedWorkListResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    AcknowledgedAt = "acknowledged_at",
                    CreatedAt = "created_at",
                    Data = new("id"),
                    EnvironmentID = "environment_id",
                    LatestHeartbeatAt = "latest_heartbeat_at",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Secret = "secret",
                    StartedAt = "started_at",
                    State = State.Queued,
                    StopRequestedAt = "stop_requested_at",
                    StoppedAt = "stopped_at",
                },
            ],
            NextPage = "next_page",
        };

        List<BetaSelfHostedWork> expectedData =
        [
            new()
            {
                ID = "id",
                AcknowledgedAt = "acknowledged_at",
                CreatedAt = "created_at",
                Data = new("id"),
                EnvironmentID = "environment_id",
                LatestHeartbeatAt = "latest_heartbeat_at",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Secret = "secret",
                StartedAt = "started_at",
                State = State.Queued,
                StopRequestedAt = "stop_requested_at",
                StoppedAt = "stopped_at",
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
        var model = new BetaSelfHostedWorkListResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    AcknowledgedAt = "acknowledged_at",
                    CreatedAt = "created_at",
                    Data = new("id"),
                    EnvironmentID = "environment_id",
                    LatestHeartbeatAt = "latest_heartbeat_at",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Secret = "secret",
                    StartedAt = "started_at",
                    State = State.Queued,
                    StopRequestedAt = "stop_requested_at",
                    StoppedAt = "stopped_at",
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSelfHostedWorkListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSelfHostedWorkListResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    AcknowledgedAt = "acknowledged_at",
                    CreatedAt = "created_at",
                    Data = new("id"),
                    EnvironmentID = "environment_id",
                    LatestHeartbeatAt = "latest_heartbeat_at",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Secret = "secret",
                    StartedAt = "started_at",
                    State = State.Queued,
                    StopRequestedAt = "stop_requested_at",
                    StoppedAt = "stopped_at",
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSelfHostedWorkListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaSelfHostedWork> expectedData =
        [
            new()
            {
                ID = "id",
                AcknowledgedAt = "acknowledged_at",
                CreatedAt = "created_at",
                Data = new("id"),
                EnvironmentID = "environment_id",
                LatestHeartbeatAt = "latest_heartbeat_at",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Secret = "secret",
                StartedAt = "started_at",
                State = State.Queued,
                StopRequestedAt = "stop_requested_at",
                StoppedAt = "stopped_at",
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
        var model = new BetaSelfHostedWorkListResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    AcknowledgedAt = "acknowledged_at",
                    CreatedAt = "created_at",
                    Data = new("id"),
                    EnvironmentID = "environment_id",
                    LatestHeartbeatAt = "latest_heartbeat_at",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Secret = "secret",
                    StartedAt = "started_at",
                    State = State.Queued,
                    StopRequestedAt = "stop_requested_at",
                    StoppedAt = "stopped_at",
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSelfHostedWorkListResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    AcknowledgedAt = "acknowledged_at",
                    CreatedAt = "created_at",
                    Data = new("id"),
                    EnvironmentID = "environment_id",
                    LatestHeartbeatAt = "latest_heartbeat_at",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    Secret = "secret",
                    StartedAt = "started_at",
                    State = State.Queued,
                    StopRequestedAt = "stop_requested_at",
                    StoppedAt = "stopped_at",
                },
            ],
            NextPage = "next_page",
        };

        BetaSelfHostedWorkListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
