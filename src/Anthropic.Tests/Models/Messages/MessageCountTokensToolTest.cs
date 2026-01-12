using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class MessageCountTokensToolTest : TestBase
{
    [Fact]
    public void ToolValidationWorks()
    {
        MessageCountTokensTool value = new(
            new Tool()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void ToolBash20250124ValidationWorks()
    {
        MessageCountTokensTool value = new(
            new ToolBash20250124() { CacheControl = new() { Ttl = Ttl.Ttl5m } }
        );
        value.Validate();
    }

    [Fact]
    public void ToolTextEditor20250124ValidationWorks()
    {
        MessageCountTokensTool value = new(
            new ToolTextEditor20250124() { CacheControl = new() { Ttl = Ttl.Ttl5m } }
        );
        value.Validate();
    }

    [Fact]
    public void ToolTextEditor20250429ValidationWorks()
    {
        MessageCountTokensTool value = new(
            new ToolTextEditor20250429() { CacheControl = new() { Ttl = Ttl.Ttl5m } }
        );
        value.Validate();
    }

    [Fact]
    public void ToolTextEditor20250728ValidationWorks()
    {
        MessageCountTokensTool value = new(
            new ToolTextEditor20250728()
            {
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                MaxCharacters = 1,
            }
        );
        value.Validate();
    }

    [Fact]
    public void WebSearchTool20250305ValidationWorks()
    {
        MessageCountTokensTool value = new(
            new WebSearchTool20250305()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void ToolSerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new(
            new Tool()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolBash20250124SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new(
            new ToolBash20250124() { CacheControl = new() { Ttl = Ttl.Ttl5m } }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolTextEditor20250124SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new(
            new ToolTextEditor20250124() { CacheControl = new() { Ttl = Ttl.Ttl5m } }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolTextEditor20250429SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new(
            new ToolTextEditor20250429() { CacheControl = new() { Ttl = Ttl.Ttl5m } }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolTextEditor20250728SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new(
            new ToolTextEditor20250728()
            {
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                MaxCharacters = 1,
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchTool20250305SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new(
            new WebSearchTool20250305()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(element);

        Assert.Equal(value, deserialized);
    }
}
