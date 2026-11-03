using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Environments.Work;

namespace Anthropic.Tests.Models.Beta.Environments.Work;

public class BetaWorkLeaseStateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWorkLeaseState
        {
            LastHeartbeat = "last_heartbeat",
            LeaseExtended = true,
            State = BetaWorkLeaseStateState.Queued,
            TtlSeconds = 0,
        };

        string expectedLastHeartbeat = "last_heartbeat";
        bool expectedLeaseExtended = true;
        ApiEnum<string, BetaWorkLeaseStateState> expectedState = BetaWorkLeaseStateState.Queued;
        long expectedTtlSeconds = 0;

        Assert.Equal(expectedLastHeartbeat, model.LastHeartbeat);
        Assert.Equal(expectedLeaseExtended, model.LeaseExtended);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedTtlSeconds, model.TtlSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWorkLeaseState
        {
            LastHeartbeat = "last_heartbeat",
            LeaseExtended = true,
            State = BetaWorkLeaseStateState.Queued,
            TtlSeconds = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWorkLeaseState>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWorkLeaseState
        {
            LastHeartbeat = "last_heartbeat",
            LeaseExtended = true,
            State = BetaWorkLeaseStateState.Queued,
            TtlSeconds = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWorkLeaseState>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedLastHeartbeat = "last_heartbeat";
        bool expectedLeaseExtended = true;
        ApiEnum<string, BetaWorkLeaseStateState> expectedState = BetaWorkLeaseStateState.Queued;
        long expectedTtlSeconds = 0;

        Assert.Equal(expectedLastHeartbeat, deserialized.LastHeartbeat);
        Assert.Equal(expectedLeaseExtended, deserialized.LeaseExtended);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedTtlSeconds, deserialized.TtlSeconds);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWorkLeaseState
        {
            LastHeartbeat = "last_heartbeat",
            LeaseExtended = true,
            State = BetaWorkLeaseStateState.Queued,
            TtlSeconds = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWorkLeaseState
        {
            LastHeartbeat = "last_heartbeat",
            LeaseExtended = true,
            State = BetaWorkLeaseStateState.Queued,
            TtlSeconds = 0,
        };

        BetaWorkLeaseState copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaWorkLeaseStateStateTest : TestBase
{
    [Theory]
    [InlineData(BetaWorkLeaseStateState.Queued)]
    [InlineData(BetaWorkLeaseStateState.Starting)]
    [InlineData(BetaWorkLeaseStateState.Active)]
    [InlineData(BetaWorkLeaseStateState.Stopping)]
    [InlineData(BetaWorkLeaseStateState.Stopped)]
    public void Validation_Works(BetaWorkLeaseStateState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWorkLeaseStateState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaWorkLeaseStateState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaWorkLeaseStateState.Queued)]
    [InlineData(BetaWorkLeaseStateState.Starting)]
    [InlineData(BetaWorkLeaseStateState.Active)]
    [InlineData(BetaWorkLeaseStateState.Stopping)]
    [InlineData(BetaWorkLeaseStateState.Stopped)]
    public void SerializationRoundtrip_Works(BetaWorkLeaseStateState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWorkLeaseStateState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaWorkLeaseStateState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaWorkLeaseStateState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaWorkLeaseStateState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
