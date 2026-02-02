using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolTextEditor20250728Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolTextEditor20250728
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxCharacters = 1,
            Strict = true,
        };

        JsonElement expectedName = JsonSerializer.SerializeToElement("str_replace_based_edit_tool");
        JsonElement expectedType = JsonSerializer.SerializeToElement("text_editor_20250728");
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        long expectedMaxCharacters = 1;
        bool expectedStrict = true;

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedMaxCharacters, model.MaxCharacters);
        Assert.Equal(expectedStrict, model.Strict);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolTextEditor20250728
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxCharacters = 1,
            Strict = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolTextEditor20250728>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolTextEditor20250728
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxCharacters = 1,
            Strict = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolTextEditor20250728>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("str_replace_based_edit_tool");
        JsonElement expectedType = JsonSerializer.SerializeToElement("text_editor_20250728");
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        long expectedMaxCharacters = 1;
        bool expectedStrict = true;

        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedMaxCharacters, deserialized.MaxCharacters);
        Assert.Equal(expectedStrict, deserialized.Strict);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolTextEditor20250728
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxCharacters = 1,
            Strict = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolTextEditor20250728
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxCharacters = 1,
        };

        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolTextEditor20250728
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxCharacters = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ToolTextEditor20250728
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxCharacters = 1,

            // Null should be interpreted as omitted for these properties
            Strict = null,
        };

        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolTextEditor20250728
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxCharacters = 1,

            // Null should be interpreted as omitted for these properties
            Strict = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolTextEditor20250728 { Strict = true };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.MaxCharacters);
        Assert.False(model.RawData.ContainsKey("max_characters"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolTextEditor20250728 { Strict = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ToolTextEditor20250728
        {
            Strict = true,

            CacheControl = null,
            MaxCharacters = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.MaxCharacters);
        Assert.True(model.RawData.ContainsKey("max_characters"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolTextEditor20250728
        {
            Strict = true,

            CacheControl = null,
            MaxCharacters = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ToolTextEditor20250728
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxCharacters = 1,
            Strict = true,
        };

        ToolTextEditor20250728 copied = new(model);

        Assert.Equal(model, copied);
    }
}
