using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolTextEditor20250429Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolTextEditor20250429 { CacheControl = new() { TTL = TTL.TTL5m } };

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>(
            "\"str_replace_based_edit_tool\""
        );
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_20250429\""
        );
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolTextEditor20250429 { CacheControl = new() { TTL = TTL.TTL5m } };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ToolTextEditor20250429>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolTextEditor20250429 { CacheControl = new() { TTL = TTL.TTL5m } };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ToolTextEditor20250429>(element);
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>(
            "\"str_replace_based_edit_tool\""
        );
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_20250429\""
        );
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };

        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolTextEditor20250429 { CacheControl = new() { TTL = TTL.TTL5m } };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolTextEditor20250429 { };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolTextEditor20250429 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ToolTextEditor20250429 { CacheControl = null };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolTextEditor20250429 { CacheControl = null };

        model.Validate();
    }
}
