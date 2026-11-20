using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Environments.Work;

namespace Anthropic.Tests.Models.Beta.Environments.Work;

public class BetaSelfHostedWorkHeartbeatResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSelfHostedWorkHeartbeatResponse
        {
            LastHeartbeat = "last_heartbeat",
            LeaseExtended = true,
            State = BetaSelfHostedWorkHeartbeatResponseState.Queued,
            TtlSeconds = 0,
        };

        string expectedLastHeartbeat = "last_heartbeat";
        bool expectedLeaseExtended = true;
        ApiEnum<string, BetaSelfHostedWorkHeartbeatResponseState> expectedState =
            BetaSelfHostedWorkHeartbeatResponseState.Queued;
        long expectedTtlSeconds = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("work_heartbeat");

        Assert.Equal(expectedLastHeartbeat, model.LastHeartbeat);
        Assert.Equal(expectedLeaseExtended, model.LeaseExtended);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedTtlSeconds, model.TtlSeconds);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSelfHostedWorkHeartbeatResponse
        {
            LastHeartbeat = "last_heartbeat",
            LeaseExtended = true,
            State = BetaSelfHostedWorkHeartbeatResponseState.Queued,
            TtlSeconds = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSelfHostedWorkHeartbeatResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSelfHostedWorkHeartbeatResponse
        {
            LastHeartbeat = "last_heartbeat",
            LeaseExtended = true,
            State = BetaSelfHostedWorkHeartbeatResponseState.Queued,
            TtlSeconds = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSelfHostedWorkHeartbeatResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedLastHeartbeat = "last_heartbeat";
        bool expectedLeaseExtended = true;
        ApiEnum<string, BetaSelfHostedWorkHeartbeatResponseState> expectedState =
            BetaSelfHostedWorkHeartbeatResponseState.Queued;
        long expectedTtlSeconds = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("work_heartbeat");

        Assert.Equal(expectedLastHeartbeat, deserialized.LastHeartbeat);
        Assert.Equal(expectedLeaseExtended, deserialized.LeaseExtended);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedTtlSeconds, deserialized.TtlSeconds);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSelfHostedWorkHeartbeatResponse
        {
            LastHeartbeat = "last_heartbeat",
            LeaseExtended = true,
            State = BetaSelfHostedWorkHeartbeatResponseState.Queued,
            TtlSeconds = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSelfHostedWorkHeartbeatResponse
        {
            LastHeartbeat = "last_heartbeat",
            LeaseExtended = true,
            State = BetaSelfHostedWorkHeartbeatResponseState.Queued,
            TtlSeconds = 0,
        };

        BetaSelfHostedWorkHeartbeatResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaSelfHostedWorkHeartbeatResponseStateTest : TestBase
{
    [Theory]
    [InlineData(BetaSelfHostedWorkHeartbeatResponseState.Queued)]
    [InlineData(BetaSelfHostedWorkHeartbeatResponseState.Starting)]
    [InlineData(BetaSelfHostedWorkHeartbeatResponseState.Active)]
    [InlineData(BetaSelfHostedWorkHeartbeatResponseState.Stopping)]
    [InlineData(BetaSelfHostedWorkHeartbeatResponseState.Stopped)]
    public void Validation_Works(BetaSelfHostedWorkHeartbeatResponseState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaSelfHostedWorkHeartbeatResponseState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSelfHostedWorkHeartbeatResponseState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaSelfHostedWorkHeartbeatResponseState.Queued, 0, "queued")]
    [InlineData(BetaSelfHostedWorkHeartbeatResponseState.Starting, 1, "starting")]
    [InlineData(BetaSelfHostedWorkHeartbeatResponseState.Active, 2, "active")]
    [InlineData(BetaSelfHostedWorkHeartbeatResponseState.Stopping, 3, "stopping")]
    [InlineData(BetaSelfHostedWorkHeartbeatResponseState.Stopped, 4, "stopped")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaSelfHostedWorkHeartbeatResponseState rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaSelfHostedWorkHeartbeatResponseState> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSelfHostedWorkHeartbeatResponseState>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSelfHostedWorkHeartbeatResponseState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSelfHostedWorkHeartbeatResponseState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
