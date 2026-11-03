using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Environments.Work;

namespace Anthropic.Tests.Models.Beta.Environments.Work;

public class BetaHeartbeatPreconditionFailedErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaHeartbeatPreconditionFailedErrorDetails
        {
            CurrentState = new()
            {
                LastHeartbeat = "last_heartbeat",
                LeaseExtended = true,
                State = BetaWorkLeaseStateState.Queued,
                TtlSeconds = 0,
            },
        };

        BetaWorkLeaseState expectedCurrentState = new()
        {
            LastHeartbeat = "last_heartbeat",
            LeaseExtended = true,
            State = BetaWorkLeaseStateState.Queued,
            TtlSeconds = 0,
        };
        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "heartbeat_precondition_failed"
        );

        Assert.Equal(expectedCurrentState, model.CurrentState);
        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaHeartbeatPreconditionFailedErrorDetails
        {
            CurrentState = new()
            {
                LastHeartbeat = "last_heartbeat",
                LeaseExtended = true,
                State = BetaWorkLeaseStateState.Queued,
                TtlSeconds = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaHeartbeatPreconditionFailedErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaHeartbeatPreconditionFailedErrorDetails
        {
            CurrentState = new()
            {
                LastHeartbeat = "last_heartbeat",
                LeaseExtended = true,
                State = BetaWorkLeaseStateState.Queued,
                TtlSeconds = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaHeartbeatPreconditionFailedErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaWorkLeaseState expectedCurrentState = new()
        {
            LastHeartbeat = "last_heartbeat",
            LeaseExtended = true,
            State = BetaWorkLeaseStateState.Queued,
            TtlSeconds = 0,
        };
        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "heartbeat_precondition_failed"
        );

        Assert.Equal(expectedCurrentState, deserialized.CurrentState);
        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaHeartbeatPreconditionFailedErrorDetails
        {
            CurrentState = new()
            {
                LastHeartbeat = "last_heartbeat",
                LeaseExtended = true,
                State = BetaWorkLeaseStateState.Queued,
                TtlSeconds = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaHeartbeatPreconditionFailedErrorDetails
        {
            CurrentState = new()
            {
                LastHeartbeat = "last_heartbeat",
                LeaseExtended = true,
                State = BetaWorkLeaseStateState.Queued,
                TtlSeconds = 0,
            },
        };

        BetaHeartbeatPreconditionFailedErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
