using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CacheControlEphemeralTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CacheControlEphemeral { TTL = TTL.TTL5m };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"ephemeral\"");
        ApiEnum<string, TTL> expectedTTL = TTL.TTL5m;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedTTL, model.TTL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CacheControlEphemeral { TTL = TTL.TTL5m };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CacheControlEphemeral>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CacheControlEphemeral { TTL = TTL.TTL5m };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CacheControlEphemeral>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"ephemeral\"");
        ApiEnum<string, TTL> expectedTTL = TTL.TTL5m;

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedTTL, deserialized.TTL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CacheControlEphemeral { TTL = TTL.TTL5m };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CacheControlEphemeral { };

        Assert.Null(model.TTL);
        Assert.False(model.RawData.ContainsKey("ttl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CacheControlEphemeral { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CacheControlEphemeral
        {
            // Null should be interpreted as omitted for these properties
            TTL = null,
        };

        Assert.Null(model.TTL);
        Assert.False(model.RawData.ContainsKey("ttl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CacheControlEphemeral
        {
            // Null should be interpreted as omitted for these properties
            TTL = null,
        };

        model.Validate();
    }
}
