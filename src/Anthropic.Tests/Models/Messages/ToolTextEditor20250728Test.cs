using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolTextEditor20250728Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolTextEditor20250728
        {
            CacheControl = new() { TTL = TTL.TTL5m },
            MaxCharacters = 1,
        };

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>(
            "\"str_replace_based_edit_tool\""
        );
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_20250728\""
        );
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        long expectedMaxCharacters = 1;

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedMaxCharacters, model.MaxCharacters);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolTextEditor20250728
        {
            CacheControl = new() { TTL = TTL.TTL5m },
            MaxCharacters = 1,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ToolTextEditor20250728>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolTextEditor20250728
        {
            CacheControl = new() { TTL = TTL.TTL5m },
            MaxCharacters = 1,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ToolTextEditor20250728>(element);
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>(
            "\"str_replace_based_edit_tool\""
        );
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_20250728\""
        );
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        long expectedMaxCharacters = 1;

        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedMaxCharacters, deserialized.MaxCharacters);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolTextEditor20250728
        {
            CacheControl = new() { TTL = TTL.TTL5m },
            MaxCharacters = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolTextEditor20250728 { };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.MaxCharacters);
        Assert.False(model.RawData.ContainsKey("max_characters"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolTextEditor20250728 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ToolTextEditor20250728 { CacheControl = null, MaxCharacters = null };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.MaxCharacters);
        Assert.True(model.RawData.ContainsKey("max_characters"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolTextEditor20250728 { CacheControl = null, MaxCharacters = null };

        model.Validate();
    }
}
