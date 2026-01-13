using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolUnionTest : TestBase
{
    [Fact]
    public void ToolValidationWorks()
    {
        ToolUnion value = new Tool()
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
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Description = "Get the current weather in a given location",
            Type = Type.Custom,
        };
        value.Validate();
    }

    [Fact]
    public void Bash20250124ValidationWorks()
    {
        ToolUnion value = new ToolBash20250124() { CacheControl = new() { Ttl = Ttl.Ttl5m } };
        value.Validate();
    }

    [Fact]
    public void TextEditor20250124ValidationWorks()
    {
        ToolUnion value = new ToolTextEditor20250124() { CacheControl = new() { Ttl = Ttl.Ttl5m } };
        value.Validate();
    }

    [Fact]
    public void TextEditor20250429ValidationWorks()
    {
        ToolUnion value = new ToolTextEditor20250429() { CacheControl = new() { Ttl = Ttl.Ttl5m } };
        value.Validate();
    }

    [Fact]
    public void TextEditor20250728ValidationWorks()
    {
        ToolUnion value = new ToolTextEditor20250728()
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxCharacters = 1,
        };
        value.Validate();
    }

    [Fact]
    public void WebSearchTool20250305ValidationWorks()
    {
        ToolUnion value = new WebSearchTool20250305()
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxUses = 1,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },
        };
        value.Validate();
    }

    [Fact]
    public void ToolSerializationRoundtripWorks()
    {
        ToolUnion value = new Tool()
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
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Description = "Get the current weather in a given location",
            Type = Type.Custom,
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Bash20250124SerializationRoundtripWorks()
    {
        ToolUnion value = new ToolBash20250124() { CacheControl = new() { Ttl = Ttl.Ttl5m } };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditor20250124SerializationRoundtripWorks()
    {
        ToolUnion value = new ToolTextEditor20250124() { CacheControl = new() { Ttl = Ttl.Ttl5m } };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditor20250429SerializationRoundtripWorks()
    {
        ToolUnion value = new ToolTextEditor20250429() { CacheControl = new() { Ttl = Ttl.Ttl5m } };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditor20250728SerializationRoundtripWorks()
    {
        ToolUnion value = new ToolTextEditor20250728()
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxCharacters = 1,
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchTool20250305SerializationRoundtripWorks()
    {
        ToolUnion value = new WebSearchTool20250305()
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxUses = 1,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(element);

        Assert.Equal(value, deserialized);
    }
}
