using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            CacheControl = new() { TTL = TTL.TTL5m },
            Description = "Get the current weather in a given location",
            Type = Type.Custom,
        };

        InputSchema expectedInputSchema = new()
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };
        string expectedName = "name";
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        string expectedDescription = "Get the current weather in a given location";
        ApiEnum<string, Type> expectedType = Type.Custom;

        Assert.Equal(expectedInputSchema, model.InputSchema);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            CacheControl = new() { TTL = TTL.TTL5m },
            Description = "Get the current weather in a given location",
            Type = Type.Custom,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Tool>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            CacheControl = new() { TTL = TTL.TTL5m },
            Description = "Get the current weather in a given location",
            Type = Type.Custom,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Tool>(json);
        Assert.NotNull(deserialized);

        InputSchema expectedInputSchema = new()
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };
        string expectedName = "name";
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        string expectedDescription = "Get the current weather in a given location";
        ApiEnum<string, Type> expectedType = Type.Custom;

        Assert.Equal(expectedInputSchema, deserialized.InputSchema);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            CacheControl = new() { TTL = TTL.TTL5m },
            Description = "Get the current weather in a given location",
            Type = Type.Custom,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            CacheControl = new() { TTL = TTL.TTL5m },
            Type = Type.Custom,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            CacheControl = new() { TTL = TTL.TTL5m },
            Type = Type.Custom,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            CacheControl = new() { TTL = TTL.TTL5m },
            Type = Type.Custom,

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            CacheControl = new() { TTL = TTL.TTL5m },
            Type = Type.Custom,

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            Description = "Get the current weather in a given location",
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            Description = "Get the current weather in a given location",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            Description = "Get the current weather in a given location",

            CacheControl = null,
            Type = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Type);
        Assert.True(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            Description = "Get the current weather in a given location",

            CacheControl = null,
            Type = null,
        };

        model.Validate();
    }
}

public class InputSchemaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InputSchema
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"object\"");
        Dictionary<string, JsonElement> expectedProperties = new()
        {
            { "location", JsonSerializer.SerializeToElement("bar") },
            { "unit", JsonSerializer.SerializeToElement("bar") },
        };
        List<string> expectedRequired = ["location"];

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedProperties.Count, model.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(model.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Properties[item.Key]));
        }
        Assert.Equal(expectedRequired.Count, model.Required.Count);
        for (int i = 0; i < expectedRequired.Count; i++)
        {
            Assert.Equal(expectedRequired[i], model.Required[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InputSchema
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InputSchema>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InputSchema
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InputSchema>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"object\"");
        Dictionary<string, JsonElement> expectedProperties = new()
        {
            { "location", JsonSerializer.SerializeToElement("bar") },
            { "unit", JsonSerializer.SerializeToElement("bar") },
        };
        List<string> expectedRequired = ["location"];

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.Properties);
        Assert.Equal(expectedProperties.Count, deserialized.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(deserialized.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Properties[item.Key]));
        }
        Assert.NotNull(deserialized.Required);
        Assert.Equal(expectedRequired.Count, deserialized.Required.Count);
        for (int i = 0; i < expectedRequired.Count; i++)
        {
            Assert.Equal(expectedRequired[i], deserialized.Required[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InputSchema
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InputSchema { };

        Assert.Null(model.Properties);
        Assert.False(model.RawData.ContainsKey("properties"));
        Assert.Null(model.Required);
        Assert.False(model.RawData.ContainsKey("required"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InputSchema { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InputSchema { Properties = null, Required = null };

        Assert.Null(model.Properties);
        Assert.True(model.RawData.ContainsKey("properties"));
        Assert.Null(model.Required);
        Assert.True(model.RawData.ContainsKey("required"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InputSchema { Properties = null, Required = null };

        model.Validate();
    }
}
