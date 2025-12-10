using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolUnionTest : TestBase
{
    [Fact]
    public void toolValidation_Works()
    {
        ToolUnion value = new(
            new()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void bash_20250124Validation_Works()
    {
        ToolUnion value = new(new() { CacheControl = new() { TTL = TTL.TTL5m } });
        value.Validate();
    }

    [Fact]
    public void text_editor_20250124Validation_Works()
    {
        ToolUnion value = new(new() { CacheControl = new() { TTL = TTL.TTL5m } });
        value.Validate();
    }

    [Fact]
    public void text_editor_20250429Validation_Works()
    {
        ToolUnion value = new(new() { CacheControl = new() { TTL = TTL.TTL5m } });
        value.Validate();
    }

    [Fact]
    public void text_editor_20250728Validation_Works()
    {
        ToolUnion value = new(
            new()
            {
                CacheControl = new() { TTL = TTL.TTL5m },
                MaxCharacters = 1,
            }
        );
        value.Validate();
    }

    [Fact]
    public void web_search_tool_20250305Validation_Works()
    {
        ToolUnion value = new(
            new()
            {
                AllowedDomains = ["string"],
                BlockedDomains = ["string"],
                CacheControl = new() { TTL = TTL.TTL5m },
                MaxUses = 1,
                UserLocation = new()
                {
                    City = "New York",
                    Country = "US",
                    Region = "California",
                    Timezone = "America/New_York",
                },
            }
        );
        value.Validate();
    }

    [Fact]
    public void toolSerializationRoundtrip_Works()
    {
        ToolUnion value = new(
            new()
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
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void bash_20250124SerializationRoundtrip_Works()
    {
        ToolUnion value = new(new() { CacheControl = new() { TTL = TTL.TTL5m } });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void text_editor_20250124SerializationRoundtrip_Works()
    {
        ToolUnion value = new(new() { CacheControl = new() { TTL = TTL.TTL5m } });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void text_editor_20250429SerializationRoundtrip_Works()
    {
        ToolUnion value = new(new() { CacheControl = new() { TTL = TTL.TTL5m } });
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void text_editor_20250728SerializationRoundtrip_Works()
    {
        ToolUnion value = new(
            new()
            {
                CacheControl = new() { TTL = TTL.TTL5m },
                MaxCharacters = 1,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void web_search_tool_20250305SerializationRoundtrip_Works()
    {
        ToolUnion value = new(
            new()
            {
                AllowedDomains = ["string"],
                BlockedDomains = ["string"],
                CacheControl = new() { TTL = TTL.TTL5m },
                MaxUses = 1,
                UserLocation = new()
                {
                    City = "New York",
                    Country = "US",
                    Region = "California",
                    Timezone = "America/New_York",
                },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(json);

        Assert.Equal(value, deserialized);
    }
}
