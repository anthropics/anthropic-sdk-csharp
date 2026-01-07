using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class CacheControlEphemeralTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CacheControlEphemeral { Ttl = Ttl.Ttl5m };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"ephemeral\"");
        ApiEnum<string, Ttl> expectedTtl = Ttl.Ttl5m;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedTtl, model.Ttl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CacheControlEphemeral { Ttl = Ttl.Ttl5m };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CacheControlEphemeral>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CacheControlEphemeral { Ttl = Ttl.Ttl5m };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CacheControlEphemeral>(element);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"ephemeral\"");
        ApiEnum<string, Ttl> expectedTtl = Ttl.Ttl5m;

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedTtl, deserialized.Ttl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CacheControlEphemeral { Ttl = Ttl.Ttl5m };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CacheControlEphemeral { };

        Assert.Null(model.Ttl);
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
            Ttl = null,
        };

        Assert.Null(model.Ttl);
        Assert.False(model.RawData.ContainsKey("ttl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CacheControlEphemeral
        {
            // Null should be interpreted as omitted for these properties
            Ttl = null,
        };

        model.Validate();
    }
}

public class TtlTest : TestBase
{
    [Theory]
    [InlineData(Ttl.Ttl5m)]
    [InlineData(Ttl.Ttl1h)]
    public void Validation_Works(Ttl rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Ttl> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Ttl>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Ttl.Ttl5m)]
    [InlineData(Ttl.Ttl1h)]
    public void SerializationRoundtrip_Works(Ttl rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Ttl> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Ttl>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Ttl>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Ttl>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
