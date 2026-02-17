using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
    public void ToolBash20250124ValidationWorks()
    {
        MessageCountTokensTool value = new ToolBash20250124()
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
        MessageCountTokensTool value = new CodeExecutionTool20250522()
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
        MessageCountTokensTool value = new CodeExecutionTool20250825()
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
        MessageCountTokensTool value = new CodeExecutionTool20260120()
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
        MessageCountTokensTool value = new MemoryTool20250818()
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
    public void ToolTextEditor20250124ValidationWorks()
    {
        MessageCountTokensTool value = new ToolTextEditor20250124()
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
    public void ToolTextEditor20250429ValidationWorks()
    {
        MessageCountTokensTool value = new ToolTextEditor20250429()
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
    public void ToolTextEditor20250728ValidationWorks()
    {
        MessageCountTokensTool value = new ToolTextEditor20250728()
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
        MessageCountTokensTool value = new WebSearchTool20250305()
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
        MessageCountTokensTool value = new WebFetchTool20250910()
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
        MessageCountTokensTool value = new WebSearchTool20260209()
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
        MessageCountTokensTool value = new WebFetchTool20260209()
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
    public void ToolSearchToolBm25_20251119ValidationWorks()
    {
        MessageCountTokensTool value = new ToolSearchToolBm25_20251119()
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
    public void ToolSearchToolRegex20251119ValidationWorks()
    {
        MessageCountTokensTool value = new ToolSearchToolRegex20251119()
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
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionTool20250522SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new CodeExecutionTool20250522()
        {
            AllowedCallers = [AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
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
    public void CodeExecutionTool20250825SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new CodeExecutionTool20250825()
        {
            AllowedCallers = [CodeExecutionTool20250825AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
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
    public void CodeExecutionTool20260120SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new CodeExecutionTool20260120()
        {
            AllowedCallers = [CodeExecutionTool20260120AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
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
    public void MemoryTool20250818SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new MemoryTool20250818()
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
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchTool20250910SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new WebFetchTool20250910()
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
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebSearchTool20260209SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new WebSearchTool20260209()
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
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchTool20260209SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new WebFetchTool20260209()
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
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolSearchToolBm25_20251119SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new ToolSearchToolBm25_20251119()
        {
            Type = ToolSearchToolBm25_20251119Type.ToolSearchToolBm25_20251119,
            AllowedCallers = [ToolSearchToolBm25_20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
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
    public void ToolSearchToolRegex20251119SerializationRoundtripWorks()
    {
        MessageCountTokensTool value = new ToolSearchToolRegex20251119()
        {
            Type = ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [ToolSearchToolRegex20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageCountTokensTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CodeExecutionTool20260120Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CodeExecutionTool20260120
        {
            AllowedCallers = [CodeExecutionTool20260120AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };

        JsonElement expectedName = JsonSerializer.SerializeToElement("code_execution");
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_20260120");
        List<ApiEnum<string, CodeExecutionTool20260120AllowedCaller>> expectedAllowedCallers =
        [
            CodeExecutionTool20260120AllowedCaller.Direct,
        ];
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        bool expectedStrict = true;

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.AllowedCallers);
        Assert.Equal(expectedAllowedCallers.Count, model.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], model.AllowedCallers[i]);
        }
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedDeferLoading, model.DeferLoading);
        Assert.Equal(expectedStrict, model.Strict);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CodeExecutionTool20260120
        {
            AllowedCallers = [CodeExecutionTool20260120AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionTool20260120>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CodeExecutionTool20260120
        {
            AllowedCallers = [CodeExecutionTool20260120AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionTool20260120>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("code_execution");
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_20260120");
        List<ApiEnum<string, CodeExecutionTool20260120AllowedCaller>> expectedAllowedCallers =
        [
            CodeExecutionTool20260120AllowedCaller.Direct,
        ];
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        bool expectedStrict = true;

        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.AllowedCallers);
        Assert.Equal(expectedAllowedCallers.Count, deserialized.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], deserialized.AllowedCallers[i]);
        }
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedDeferLoading, deserialized.DeferLoading);
        Assert.Equal(expectedStrict, deserialized.Strict);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CodeExecutionTool20260120
        {
            AllowedCallers = [CodeExecutionTool20260120AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CodeExecutionTool20260120 { CacheControl = new() { Ttl = Ttl.Ttl5m } };

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CodeExecutionTool20260120 { CacheControl = new() { Ttl = Ttl.Ttl5m } };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CodeExecutionTool20260120
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
            DeferLoading = null,
            Strict = null,
        };

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CodeExecutionTool20260120
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
            DeferLoading = null,
            Strict = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CodeExecutionTool20260120
        {
            AllowedCallers = [CodeExecutionTool20260120AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CodeExecutionTool20260120
        {
            AllowedCallers = [CodeExecutionTool20260120AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CodeExecutionTool20260120
        {
            AllowedCallers = [CodeExecutionTool20260120AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,

            CacheControl = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CodeExecutionTool20260120
        {
            AllowedCallers = [CodeExecutionTool20260120AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,

            CacheControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CodeExecutionTool20260120
        {
            AllowedCallers = [CodeExecutionTool20260120AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };

        CodeExecutionTool20260120 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CodeExecutionTool20260120AllowedCallerTest : TestBase
{
    [Theory]
    [InlineData(CodeExecutionTool20260120AllowedCaller.Direct)]
    [InlineData(CodeExecutionTool20260120AllowedCaller.CodeExecution20250825)]
    public void Validation_Works(CodeExecutionTool20260120AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CodeExecutionTool20260120AllowedCaller> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CodeExecutionTool20260120AllowedCaller>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CodeExecutionTool20260120AllowedCaller.Direct)]
    [InlineData(CodeExecutionTool20260120AllowedCaller.CodeExecution20250825)]
    public void SerializationRoundtrip_Works(CodeExecutionTool20260120AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CodeExecutionTool20260120AllowedCaller> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CodeExecutionTool20260120AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CodeExecutionTool20260120AllowedCaller>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CodeExecutionTool20260120AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class WebSearchTool20260209Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebSearchTool20260209
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

        JsonElement expectedName = JsonSerializer.SerializeToElement("web_search");
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_20260209");
        List<ApiEnum<string, WebSearchTool20260209AllowedCaller>> expectedAllowedCallers =
        [
            WebSearchTool20260209AllowedCaller.Direct,
        ];
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        long expectedMaxUses = 1;
        bool expectedStrict = true;
        UserLocation expectedUserLocation = new()
        {
            City = "New York",
            Country = "US",
            Region = "California",
            Timezone = "America/New_York",
        };

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.AllowedCallers);
        Assert.Equal(expectedAllowedCallers.Count, model.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], model.AllowedCallers[i]);
        }
        Assert.NotNull(model.AllowedDomains);
        Assert.Equal(expectedAllowedDomains.Count, model.AllowedDomains.Count);
        for (int i = 0; i < expectedAllowedDomains.Count; i++)
        {
            Assert.Equal(expectedAllowedDomains[i], model.AllowedDomains[i]);
        }
        Assert.NotNull(model.BlockedDomains);
        Assert.Equal(expectedBlockedDomains.Count, model.BlockedDomains.Count);
        for (int i = 0; i < expectedBlockedDomains.Count; i++)
        {
            Assert.Equal(expectedBlockedDomains[i], model.BlockedDomains[i]);
        }
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedDeferLoading, model.DeferLoading);
        Assert.Equal(expectedMaxUses, model.MaxUses);
        Assert.Equal(expectedStrict, model.Strict);
        Assert.Equal(expectedUserLocation, model.UserLocation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebSearchTool20260209
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchTool20260209>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebSearchTool20260209
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchTool20260209>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("web_search");
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_20260209");
        List<ApiEnum<string, WebSearchTool20260209AllowedCaller>> expectedAllowedCallers =
        [
            WebSearchTool20260209AllowedCaller.Direct,
        ];
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        long expectedMaxUses = 1;
        bool expectedStrict = true;
        UserLocation expectedUserLocation = new()
        {
            City = "New York",
            Country = "US",
            Region = "California",
            Timezone = "America/New_York",
        };

        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.AllowedCallers);
        Assert.Equal(expectedAllowedCallers.Count, deserialized.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], deserialized.AllowedCallers[i]);
        }
        Assert.NotNull(deserialized.AllowedDomains);
        Assert.Equal(expectedAllowedDomains.Count, deserialized.AllowedDomains.Count);
        for (int i = 0; i < expectedAllowedDomains.Count; i++)
        {
            Assert.Equal(expectedAllowedDomains[i], deserialized.AllowedDomains[i]);
        }
        Assert.NotNull(deserialized.BlockedDomains);
        Assert.Equal(expectedBlockedDomains.Count, deserialized.BlockedDomains.Count);
        for (int i = 0; i < expectedBlockedDomains.Count; i++)
        {
            Assert.Equal(expectedBlockedDomains[i], deserialized.BlockedDomains[i]);
        }
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedDeferLoading, deserialized.DeferLoading);
        Assert.Equal(expectedMaxUses, deserialized.MaxUses);
        Assert.Equal(expectedStrict, deserialized.Strict);
        Assert.Equal(expectedUserLocation, deserialized.UserLocation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebSearchTool20260209
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebSearchTool20260209
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

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebSearchTool20260209
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebSearchTool20260209
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

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
            DeferLoading = null,
            Strict = null,
        };

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebSearchTool20260209
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

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
            DeferLoading = null,
            Strict = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebSearchTool20260209
        {
            AllowedCallers = [WebSearchTool20260209AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,
        };

        Assert.Null(model.AllowedDomains);
        Assert.False(model.RawData.ContainsKey("allowed_domains"));
        Assert.Null(model.BlockedDomains);
        Assert.False(model.RawData.ContainsKey("blocked_domains"));
        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.MaxUses);
        Assert.False(model.RawData.ContainsKey("max_uses"));
        Assert.Null(model.UserLocation);
        Assert.False(model.RawData.ContainsKey("user_location"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebSearchTool20260209
        {
            AllowedCallers = [WebSearchTool20260209AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebSearchTool20260209
        {
            AllowedCallers = [WebSearchTool20260209AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,

            AllowedDomains = null,
            BlockedDomains = null,
            CacheControl = null,
            MaxUses = null,
            UserLocation = null,
        };

        Assert.Null(model.AllowedDomains);
        Assert.True(model.RawData.ContainsKey("allowed_domains"));
        Assert.Null(model.BlockedDomains);
        Assert.True(model.RawData.ContainsKey("blocked_domains"));
        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.MaxUses);
        Assert.True(model.RawData.ContainsKey("max_uses"));
        Assert.Null(model.UserLocation);
        Assert.True(model.RawData.ContainsKey("user_location"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebSearchTool20260209
        {
            AllowedCallers = [WebSearchTool20260209AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,

            AllowedDomains = null,
            BlockedDomains = null,
            CacheControl = null,
            MaxUses = null,
            UserLocation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebSearchTool20260209
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

        WebSearchTool20260209 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebSearchTool20260209AllowedCallerTest : TestBase
{
    [Theory]
    [InlineData(WebSearchTool20260209AllowedCaller.Direct)]
    [InlineData(WebSearchTool20260209AllowedCaller.CodeExecution20250825)]
    public void Validation_Works(WebSearchTool20260209AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebSearchTool20260209AllowedCaller> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebSearchTool20260209AllowedCaller>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebSearchTool20260209AllowedCaller.Direct)]
    [InlineData(WebSearchTool20260209AllowedCaller.CodeExecution20250825)]
    public void SerializationRoundtrip_Works(WebSearchTool20260209AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebSearchTool20260209AllowedCaller> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebSearchTool20260209AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebSearchTool20260209AllowedCaller>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebSearchTool20260209AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UserLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserLocation
        {
            City = "New York",
            Country = "US",
            Region = "California",
            Timezone = "America/New_York",
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("approximate");
        string expectedCity = "New York";
        string expectedCountry = "US";
        string expectedRegion = "California";
        string expectedTimezone = "America/New_York";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedTimezone, model.Timezone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserLocation
        {
            City = "New York",
            Country = "US",
            Region = "California",
            Timezone = "America/New_York",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserLocation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserLocation
        {
            City = "New York",
            Country = "US",
            Region = "California",
            Timezone = "America/New_York",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserLocation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("approximate");
        string expectedCity = "New York";
        string expectedCountry = "US";
        string expectedRegion = "California";
        string expectedTimezone = "America/New_York";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedTimezone, deserialized.Timezone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserLocation
        {
            City = "New York",
            Country = "US",
            Region = "California",
            Timezone = "America/New_York",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserLocation { };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
        Assert.Null(model.Timezone);
        Assert.False(model.RawData.ContainsKey("timezone"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserLocation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UserLocation
        {
            City = null,
            Country = null,
            Region = null,
            Timezone = null,
        };

        Assert.Null(model.City);
        Assert.True(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.True(model.RawData.ContainsKey("country"));
        Assert.Null(model.Region);
        Assert.True(model.RawData.ContainsKey("region"));
        Assert.Null(model.Timezone);
        Assert.True(model.RawData.ContainsKey("timezone"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserLocation
        {
            City = null,
            Country = null,
            Region = null,
            Timezone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserLocation
        {
            City = "New York",
            Country = "US",
            Region = "California",
            Timezone = "America/New_York",
        };

        UserLocation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebFetchTool20260209Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebFetchTool20260209
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

        JsonElement expectedName = JsonSerializer.SerializeToElement("web_fetch");
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_20260209");
        List<ApiEnum<string, WebFetchTool20260209AllowedCaller>> expectedAllowedCallers =
        [
            WebFetchTool20260209AllowedCaller.Direct,
        ];
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        CitationsConfigParam expectedCitations = new() { Enabled = true };
        bool expectedDeferLoading = true;
        long expectedMaxContentTokens = 1;
        long expectedMaxUses = 1;
        bool expectedStrict = true;

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.AllowedCallers);
        Assert.Equal(expectedAllowedCallers.Count, model.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], model.AllowedCallers[i]);
        }
        Assert.NotNull(model.AllowedDomains);
        Assert.Equal(expectedAllowedDomains.Count, model.AllowedDomains.Count);
        for (int i = 0; i < expectedAllowedDomains.Count; i++)
        {
            Assert.Equal(expectedAllowedDomains[i], model.AllowedDomains[i]);
        }
        Assert.NotNull(model.BlockedDomains);
        Assert.Equal(expectedBlockedDomains.Count, model.BlockedDomains.Count);
        for (int i = 0; i < expectedBlockedDomains.Count; i++)
        {
            Assert.Equal(expectedBlockedDomains[i], model.BlockedDomains[i]);
        }
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedCitations, model.Citations);
        Assert.Equal(expectedDeferLoading, model.DeferLoading);
        Assert.Equal(expectedMaxContentTokens, model.MaxContentTokens);
        Assert.Equal(expectedMaxUses, model.MaxUses);
        Assert.Equal(expectedStrict, model.Strict);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebFetchTool20260209
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchTool20260209>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebFetchTool20260209
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchTool20260209>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("web_fetch");
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_20260209");
        List<ApiEnum<string, WebFetchTool20260209AllowedCaller>> expectedAllowedCallers =
        [
            WebFetchTool20260209AllowedCaller.Direct,
        ];
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        CitationsConfigParam expectedCitations = new() { Enabled = true };
        bool expectedDeferLoading = true;
        long expectedMaxContentTokens = 1;
        long expectedMaxUses = 1;
        bool expectedStrict = true;

        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.AllowedCallers);
        Assert.Equal(expectedAllowedCallers.Count, deserialized.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], deserialized.AllowedCallers[i]);
        }
        Assert.NotNull(deserialized.AllowedDomains);
        Assert.Equal(expectedAllowedDomains.Count, deserialized.AllowedDomains.Count);
        for (int i = 0; i < expectedAllowedDomains.Count; i++)
        {
            Assert.Equal(expectedAllowedDomains[i], deserialized.AllowedDomains[i]);
        }
        Assert.NotNull(deserialized.BlockedDomains);
        Assert.Equal(expectedBlockedDomains.Count, deserialized.BlockedDomains.Count);
        for (int i = 0; i < expectedBlockedDomains.Count; i++)
        {
            Assert.Equal(expectedBlockedDomains[i], deserialized.BlockedDomains[i]);
        }
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedCitations, deserialized.Citations);
        Assert.Equal(expectedDeferLoading, deserialized.DeferLoading);
        Assert.Equal(expectedMaxContentTokens, deserialized.MaxContentTokens);
        Assert.Equal(expectedMaxUses, deserialized.MaxUses);
        Assert.Equal(expectedStrict, deserialized.Strict);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebFetchTool20260209
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebFetchTool20260209
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            MaxContentTokens = 1,
            MaxUses = 1,
        };

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebFetchTool20260209
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            MaxContentTokens = 1,
            MaxUses = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebFetchTool20260209
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            MaxContentTokens = 1,
            MaxUses = 1,

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
            DeferLoading = null,
            Strict = null,
        };

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebFetchTool20260209
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            MaxContentTokens = 1,
            MaxUses = 1,

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
            DeferLoading = null,
            Strict = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebFetchTool20260209
        {
            AllowedCallers = [WebFetchTool20260209AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,
        };

        Assert.Null(model.AllowedDomains);
        Assert.False(model.RawData.ContainsKey("allowed_domains"));
        Assert.Null(model.BlockedDomains);
        Assert.False(model.RawData.ContainsKey("blocked_domains"));
        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Citations);
        Assert.False(model.RawData.ContainsKey("citations"));
        Assert.Null(model.MaxContentTokens);
        Assert.False(model.RawData.ContainsKey("max_content_tokens"));
        Assert.Null(model.MaxUses);
        Assert.False(model.RawData.ContainsKey("max_uses"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebFetchTool20260209
        {
            AllowedCallers = [WebFetchTool20260209AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebFetchTool20260209
        {
            AllowedCallers = [WebFetchTool20260209AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,

            AllowedDomains = null,
            BlockedDomains = null,
            CacheControl = null,
            Citations = null,
            MaxContentTokens = null,
            MaxUses = null,
        };

        Assert.Null(model.AllowedDomains);
        Assert.True(model.RawData.ContainsKey("allowed_domains"));
        Assert.Null(model.BlockedDomains);
        Assert.True(model.RawData.ContainsKey("blocked_domains"));
        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Citations);
        Assert.True(model.RawData.ContainsKey("citations"));
        Assert.Null(model.MaxContentTokens);
        Assert.True(model.RawData.ContainsKey("max_content_tokens"));
        Assert.Null(model.MaxUses);
        Assert.True(model.RawData.ContainsKey("max_uses"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebFetchTool20260209
        {
            AllowedCallers = [WebFetchTool20260209AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,

            AllowedDomains = null,
            BlockedDomains = null,
            CacheControl = null,
            Citations = null,
            MaxContentTokens = null,
            MaxUses = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebFetchTool20260209
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

        WebFetchTool20260209 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebFetchTool20260209AllowedCallerTest : TestBase
{
    [Theory]
    [InlineData(WebFetchTool20260209AllowedCaller.Direct)]
    [InlineData(WebFetchTool20260209AllowedCaller.CodeExecution20250825)]
    public void Validation_Works(WebFetchTool20260209AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebFetchTool20260209AllowedCaller> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebFetchTool20260209AllowedCaller>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebFetchTool20260209AllowedCaller.Direct)]
    [InlineData(WebFetchTool20260209AllowedCaller.CodeExecution20250825)]
    public void SerializationRoundtrip_Works(WebFetchTool20260209AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebFetchTool20260209AllowedCaller> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebFetchTool20260209AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebFetchTool20260209AllowedCaller>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebFetchTool20260209AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
