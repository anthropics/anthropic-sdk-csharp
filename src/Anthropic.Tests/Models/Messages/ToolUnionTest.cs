using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
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
            AllowedCallers = [ToolAllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Description = "Get the current weather in a given location",
            EagerInputStreaming = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
            Type = Type.Custom,
        };
        value.Validate();
    }

    [Fact]
    public void Bash20250124ValidationWorks()
    {
        ToolUnion value = new ToolBash20250124()
        {
            AllowedCallers = [ToolBash20250124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void CodeExecutionTool20250522ValidationWorks()
    {
        ToolUnion value = new CodeExecutionTool20250522()
        {
            AllowedCallers = [AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void CodeExecutionTool20250825ValidationWorks()
    {
        ToolUnion value = new CodeExecutionTool20250825()
        {
            AllowedCallers = [CodeExecutionTool20250825AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void CodeExecutionTool20260120ValidationWorks()
    {
        ToolUnion value = new CodeExecutionTool20260120()
        {
            AllowedCallers = [CodeExecutionTool20260120AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void MemoryTool20250818ValidationWorks()
    {
        ToolUnion value = new MemoryTool20250818()
        {
            AllowedCallers = [MemoryTool20250818AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void TextEditor20250124ValidationWorks()
    {
        ToolUnion value = new ToolTextEditor20250124()
        {
            AllowedCallers = [ToolTextEditor20250124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void TextEditor20250429ValidationWorks()
    {
        ToolUnion value = new ToolTextEditor20250429()
        {
            AllowedCallers = [ToolTextEditor20250429AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void TextEditor20250728ValidationWorks()
    {
        ToolUnion value = new ToolTextEditor20250728()
        {
            AllowedCallers = [ToolTextEditor20250728AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            MaxCharacters = 1,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void WebSearchTool20250305ValidationWorks()
    {
        ToolUnion value = new WebSearchTool20250305()
        {
            AllowedCallers = [WebSearchTool20250305AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
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
    public void WebFetchTool20250910ValidationWorks()
    {
        ToolUnion value = new WebFetchTool20250910()
        {
            AllowedCallers = [WebFetchTool20250910AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void WebSearchTool20260209ValidationWorks()
    {
        ToolUnion value = new WebSearchTool20260209()
        {
            AllowedCallers = [WebSearchTool20260209AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
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
    public void WebFetchTool20260209ValidationWorks()
    {
        ToolUnion value = new WebFetchTool20260209()
        {
            AllowedCallers = [WebFetchTool20260209AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void SearchToolBm25_20251119ValidationWorks()
    {
        ToolUnion value = new ToolSearchToolBm25_20251119()
        {
            Type = ToolSearchToolBm25_20251119Type.ToolSearchToolBm25_20251119,
            AllowedCallers = [ToolSearchToolBm25_20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        value.Validate();
    }

    [Fact]
    public void SearchToolRegex20251119ValidationWorks()
    {
        ToolUnion value = new ToolSearchToolRegex20251119()
        {
            Type = ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [ToolSearchToolRegex20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
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
            AllowedCallers = [ToolAllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Description = "Get the current weather in a given location",
            EagerInputStreaming = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
            Type = Type.Custom,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Bash20250124SerializationRoundtripWorks()
    {
        ToolUnion value = new ToolBash20250124()
        {
            AllowedCallers = [ToolBash20250124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionTool20250522SerializationRoundtripWorks()
    {
        ToolUnion value = new CodeExecutionTool20250522()
        {
            AllowedCallers = [AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionTool20250825SerializationRoundtripWorks()
    {
        ToolUnion value = new CodeExecutionTool20250825()
        {
            AllowedCallers = [CodeExecutionTool20250825AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionTool20260120SerializationRoundtripWorks()
    {
        ToolUnion value = new CodeExecutionTool20260120()
        {
            AllowedCallers = [CodeExecutionTool20260120AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MemoryTool20250818SerializationRoundtripWorks()
    {
        ToolUnion value = new MemoryTool20250818()
        {
            AllowedCallers = [MemoryTool20250818AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditor20250124SerializationRoundtripWorks()
    {
        ToolUnion value = new ToolTextEditor20250124()
        {
            AllowedCallers = [ToolTextEditor20250124AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditor20250429SerializationRoundtripWorks()
    {
        ToolUnion value = new ToolTextEditor20250429()
        {
            AllowedCallers = [ToolTextEditor20250429AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextEditor20250728SerializationRoundtripWorks()
    {
        ToolUnion value = new ToolTextEditor20250728()
        {
            AllowedCallers = [ToolTextEditor20250728AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            MaxCharacters = 1,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchTool20250305SerializationRoundtripWorks()
    {
        ToolUnion value = new WebSearchTool20250305()
        {
            AllowedCallers = [WebSearchTool20250305AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
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
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchTool20250910SerializationRoundtripWorks()
    {
        ToolUnion value = new WebFetchTool20250910()
        {
            AllowedCallers = [WebFetchTool20250910AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchTool20260209SerializationRoundtripWorks()
    {
        ToolUnion value = new WebSearchTool20260209()
        {
            AllowedCallers = [WebSearchTool20260209AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
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
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchTool20260209SerializationRoundtripWorks()
    {
        ToolUnion value = new WebFetchTool20260209()
        {
            AllowedCallers = [WebFetchTool20260209AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SearchToolBm25_20251119SerializationRoundtripWorks()
    {
        ToolUnion value = new ToolSearchToolBm25_20251119()
        {
            Type = ToolSearchToolBm25_20251119Type.ToolSearchToolBm25_20251119,
            AllowedCallers = [ToolSearchToolBm25_20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SearchToolRegex20251119SerializationRoundtripWorks()
    {
        ToolUnion value = new ToolSearchToolRegex20251119()
        {
            Type = ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [ToolSearchToolRegex20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUnion>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
