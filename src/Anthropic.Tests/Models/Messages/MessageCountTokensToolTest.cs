using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class MessageCountTokensToolTest : TestBase
{
    [Fact]
    public void ToolValidationWorks()
    {
        MessageCountTokensTool value = new Tool()
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
            Strict = true,
            Type = Type.Custom,
        };
        value.Validate();
    }

    [Fact]
    public void ToolBash20250124ValidationWorks()
    {
        MessageCountTokensTool value = new ToolBash20250124()
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void ToolTextEditor20250124ValidationWorks()
    {
        MessageCountTokensTool value = new ToolTextEditor20250124()
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void ToolTextEditor20250429ValidationWorks()
    {
        MessageCountTokensTool value = new ToolTextEditor20250429()
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void ToolTextEditor20250728ValidationWorks()
    {
        MessageCountTokensTool value = new ToolTextEditor20250728()
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxCharacters = 1,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void WebSearchTool20250305ValidationWorks()
    {
        MessageCountTokensTool value = new WebSearchTool20250305()
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxUses = 1,
            Strict = true,
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
        MessageCountTokensTool value = new Tool()
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
            Strict = true,
            Type = Type.Custom,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolBash20250124SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new ToolBash20250124()
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolTextEditor20250124SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new ToolTextEditor20250124()
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolTextEditor20250429SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new ToolTextEditor20250429()
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolTextEditor20250728SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new ToolTextEditor20250728()
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxCharacters = 1,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchTool20250305SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new WebSearchTool20250305()
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxUses = 1,
            Strict = true,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
