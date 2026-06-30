using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Environments.Work;

namespace Anthropic.Tests.Models.Beta.Environments.Work;

public class BetaSelfHostedWorkTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSelfHostedWork
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
        };

        string expectedID = "id";
        string expectedAcknowledgedAt = "acknowledged_at";
        string expectedCreatedAt = "created_at";
        BetaSessionWorkData expectedData = new("id");
        string expectedEnvironmentID = "environment_id";
        string expectedLatestHeartbeatAt = "latest_heartbeat_at";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedSecret = "secret";
        string expectedStartedAt = "started_at";
        ApiEnum<string, State> expectedState = State.Queued;
        string expectedStopRequestedAt = "stop_requested_at";
        string expectedStoppedAt = "stopped_at";
        JsonElement expectedType = JsonSerializer.SerializeToElement("work");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAcknowledgedAt, model.AcknowledgedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedEnvironmentID, model.EnvironmentID);
        Assert.Equal(expectedLatestHeartbeatAt, model.LatestHeartbeatAt);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedSecret, model.Secret);
        Assert.Equal(expectedStartedAt, model.StartedAt);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStopRequestedAt, model.StopRequestedAt);
        Assert.Equal(expectedStoppedAt, model.StoppedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSelfHostedWork
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSelfHostedWork>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSelfHostedWork
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSelfHostedWork>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAcknowledgedAt = "acknowledged_at";
        string expectedCreatedAt = "created_at";
        BetaSessionWorkData expectedData = new("id");
        string expectedEnvironmentID = "environment_id";
        string expectedLatestHeartbeatAt = "latest_heartbeat_at";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedSecret = "secret";
        string expectedStartedAt = "started_at";
        ApiEnum<string, State> expectedState = State.Queued;
        string expectedStopRequestedAt = "stop_requested_at";
        string expectedStoppedAt = "stopped_at";
        JsonElement expectedType = JsonSerializer.SerializeToElement("work");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAcknowledgedAt, deserialized.AcknowledgedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedEnvironmentID, deserialized.EnvironmentID);
        Assert.Equal(expectedLatestHeartbeatAt, deserialized.LatestHeartbeatAt);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedSecret, deserialized.Secret);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStopRequestedAt, deserialized.StopRequestedAt);
        Assert.Equal(expectedStoppedAt, deserialized.StoppedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSelfHostedWork
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSelfHostedWork
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
        };

        BetaSelfHostedWork copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StateTest : TestBase
{
    [Theory]
    [InlineData(State.Queued)]
    [InlineData(State.Starting)]
    [InlineData(State.Active)]
    [InlineData(State.Stopping)]
    [InlineData(State.Stopped)]
    public void Validation_Works(State rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, State> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(State.Queued)]
    [InlineData(State.Starting)]
    [InlineData(State.Active)]
    [InlineData(State.Stopping)]
    [InlineData(State.Stopped)]
    public void SerializationRoundtrip_Works(State rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, State> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
