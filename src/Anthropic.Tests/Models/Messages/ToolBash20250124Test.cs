using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolBash20250124Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolBash20250124 { CacheControl = new() { TTL = TTL.TTL5m } };

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>("\"bash\"");
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"bash_20250124\"");
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolBash20250124 { CacheControl = new() { TTL = TTL.TTL5m } };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ToolBash20250124>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolBash20250124 { CacheControl = new() { TTL = TTL.TTL5m } };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ToolBash20250124>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>("\"bash\"");
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"bash_20250124\"");
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };

        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolBash20250124 { CacheControl = new() { TTL = TTL.TTL5m } };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolBash20250124 { };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolBash20250124 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ToolBash20250124 { CacheControl = null };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolBash20250124 { CacheControl = null };

        model.Validate();
    }
}
