using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Models;

namespace Anthropic.Tests.Models.Models;

public class ModelInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelInfo
        {
            ID = "claude-opus-5",
            Capabilities = new()
            {
                Batch = new(true),
                Citations = new(true),
                CodeExecution = new(true),
                ContextManagement = new()
                {
                    ClearThinking20251015 = new(true),
                    ClearToolUses20250919 = new(true),
                    Compact20260112 = new(true),
                    Supported = true,
                },
                Effort = new()
                {
                    High = new(true),
                    Low = new(true),
                    Max = new(true),
                    Medium = new(true),
                    Supported = true,
                    Xhigh = new(true),
                },
                ImageInput = new(true),
                PdfInput = new(true),
                ServerTools = new()
                {
                    CodeExecution = new(true),
                    Supported = true,
                    WebSearch = new(true),
                },
                StructuredOutputs = new(true),
                Thinking = new()
                {
                    Supported = true,
                    Types = new()
                    {
                        Adaptive = new(true),
                        Disabled = new(true),
                        Enabled = new(true),
                    },
                },
            },
            CreatedAt = DateTimeOffset.Parse("2026-07-24T00:00:00Z"),
            DeprecatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "Claude Opus 5",
            Lifecycle = ModelInfoLifecycle.Active,
            Line = ModelLine.Haiku,
            MaxInputTokens = 0,
            MaxTokens = 0,
            RetiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "claude-opus-5";
        ModelCapabilities expectedCapabilities = new()
        {
            Batch = new(true),
            Citations = new(true),
            CodeExecution = new(true),
            ContextManagement = new()
            {
                ClearThinking20251015 = new(true),
                ClearToolUses20250919 = new(true),
                Compact20260112 = new(true),
                Supported = true,
            },
            Effort = new()
            {
                High = new(true),
                Low = new(true),
                Max = new(true),
                Medium = new(true),
                Supported = true,
                Xhigh = new(true),
            },
            ImageInput = new(true),
            PdfInput = new(true),
            ServerTools = new()
            {
                CodeExecution = new(true),
                Supported = true,
                WebSearch = new(true),
            },
            StructuredOutputs = new(true),
            Thinking = new()
            {
                Supported = true,
                Types = new()
                {
                    Adaptive = new(true),
                    Disabled = new(true),
                    Enabled = new(true),
                },
            },
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-07-24T00:00:00Z");
        DateTimeOffset expectedDeprecatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDisplayName = "Claude Opus 5";
        ApiEnum<string, ModelInfoLifecycle> expectedLifecycle = ModelInfoLifecycle.Active;
        ApiEnum<string, ModelLine> expectedLine = ModelLine.Haiku;
        long expectedMaxInputTokens = 0;
        long expectedMaxTokens = 0;
        DateTimeOffset expectedRetiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("model");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCapabilities, model.Capabilities);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDeprecatedAt, model.DeprecatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedLifecycle, model.Lifecycle);
        Assert.Equal(expectedLine, model.Line);
        Assert.Equal(expectedMaxInputTokens, model.MaxInputTokens);
        Assert.Equal(expectedMaxTokens, model.MaxTokens);
        Assert.Equal(expectedRetiresAt, model.RetiresAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ModelInfo
        {
            ID = "claude-opus-5",
            Capabilities = new()
            {
                Batch = new(true),
                Citations = new(true),
                CodeExecution = new(true),
                ContextManagement = new()
                {
                    ClearThinking20251015 = new(true),
                    ClearToolUses20250919 = new(true),
                    Compact20260112 = new(true),
                    Supported = true,
                },
                Effort = new()
                {
                    High = new(true),
                    Low = new(true),
                    Max = new(true),
                    Medium = new(true),
                    Supported = true,
                    Xhigh = new(true),
                },
                ImageInput = new(true),
                PdfInput = new(true),
                ServerTools = new()
                {
                    CodeExecution = new(true),
                    Supported = true,
                    WebSearch = new(true),
                },
                StructuredOutputs = new(true),
                Thinking = new()
                {
                    Supported = true,
                    Types = new()
                    {
                        Adaptive = new(true),
                        Disabled = new(true),
                        Enabled = new(true),
                    },
                },
            },
            CreatedAt = DateTimeOffset.Parse("2026-07-24T00:00:00Z"),
            DeprecatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "Claude Opus 5",
            Lifecycle = ModelInfoLifecycle.Active,
            Line = ModelLine.Haiku,
            MaxInputTokens = 0,
            MaxTokens = 0,
            RetiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelInfo>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelInfo
        {
            ID = "claude-opus-5",
            Capabilities = new()
            {
                Batch = new(true),
                Citations = new(true),
                CodeExecution = new(true),
                ContextManagement = new()
                {
                    ClearThinking20251015 = new(true),
                    ClearToolUses20250919 = new(true),
                    Compact20260112 = new(true),
                    Supported = true,
                },
                Effort = new()
                {
                    High = new(true),
                    Low = new(true),
                    Max = new(true),
                    Medium = new(true),
                    Supported = true,
                    Xhigh = new(true),
                },
                ImageInput = new(true),
                PdfInput = new(true),
                ServerTools = new()
                {
                    CodeExecution = new(true),
                    Supported = true,
                    WebSearch = new(true),
                },
                StructuredOutputs = new(true),
                Thinking = new()
                {
                    Supported = true,
                    Types = new()
                    {
                        Adaptive = new(true),
                        Disabled = new(true),
                        Enabled = new(true),
                    },
                },
            },
            CreatedAt = DateTimeOffset.Parse("2026-07-24T00:00:00Z"),
            DeprecatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "Claude Opus 5",
            Lifecycle = ModelInfoLifecycle.Active,
            Line = ModelLine.Haiku,
            MaxInputTokens = 0,
            MaxTokens = 0,
            RetiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ModelInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "claude-opus-5";
        ModelCapabilities expectedCapabilities = new()
        {
            Batch = new(true),
            Citations = new(true),
            CodeExecution = new(true),
            ContextManagement = new()
            {
                ClearThinking20251015 = new(true),
                ClearToolUses20250919 = new(true),
                Compact20260112 = new(true),
                Supported = true,
            },
            Effort = new()
            {
                High = new(true),
                Low = new(true),
                Max = new(true),
                Medium = new(true),
                Supported = true,
                Xhigh = new(true),
            },
            ImageInput = new(true),
            PdfInput = new(true),
            ServerTools = new()
            {
                CodeExecution = new(true),
                Supported = true,
                WebSearch = new(true),
            },
            StructuredOutputs = new(true),
            Thinking = new()
            {
                Supported = true,
                Types = new()
                {
                    Adaptive = new(true),
                    Disabled = new(true),
                    Enabled = new(true),
                },
            },
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-07-24T00:00:00Z");
        DateTimeOffset expectedDeprecatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDisplayName = "Claude Opus 5";
        ApiEnum<string, ModelInfoLifecycle> expectedLifecycle = ModelInfoLifecycle.Active;
        ApiEnum<string, ModelLine> expectedLine = ModelLine.Haiku;
        long expectedMaxInputTokens = 0;
        long expectedMaxTokens = 0;
        DateTimeOffset expectedRetiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("model");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCapabilities, deserialized.Capabilities);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDeprecatedAt, deserialized.DeprecatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedLifecycle, deserialized.Lifecycle);
        Assert.Equal(expectedLine, deserialized.Line);
        Assert.Equal(expectedMaxInputTokens, deserialized.MaxInputTokens);
        Assert.Equal(expectedMaxTokens, deserialized.MaxTokens);
        Assert.Equal(expectedRetiresAt, deserialized.RetiresAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ModelInfo
        {
            ID = "claude-opus-5",
            Capabilities = new()
            {
                Batch = new(true),
                Citations = new(true),
                CodeExecution = new(true),
                ContextManagement = new()
                {
                    ClearThinking20251015 = new(true),
                    ClearToolUses20250919 = new(true),
                    Compact20260112 = new(true),
                    Supported = true,
                },
                Effort = new()
                {
                    High = new(true),
                    Low = new(true),
                    Max = new(true),
                    Medium = new(true),
                    Supported = true,
                    Xhigh = new(true),
                },
                ImageInput = new(true),
                PdfInput = new(true),
                ServerTools = new()
                {
                    CodeExecution = new(true),
                    Supported = true,
                    WebSearch = new(true),
                },
                StructuredOutputs = new(true),
                Thinking = new()
                {
                    Supported = true,
                    Types = new()
                    {
                        Adaptive = new(true),
                        Disabled = new(true),
                        Enabled = new(true),
                    },
                },
            },
            CreatedAt = DateTimeOffset.Parse("2026-07-24T00:00:00Z"),
            DeprecatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "Claude Opus 5",
            Lifecycle = ModelInfoLifecycle.Active,
            Line = ModelLine.Haiku,
            MaxInputTokens = 0,
            MaxTokens = 0,
            RetiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ModelInfo
        {
            ID = "claude-opus-5",
            Capabilities = new()
            {
                Batch = new(true),
                Citations = new(true),
                CodeExecution = new(true),
                ContextManagement = new()
                {
                    ClearThinking20251015 = new(true),
                    ClearToolUses20250919 = new(true),
                    Compact20260112 = new(true),
                    Supported = true,
                },
                Effort = new()
                {
                    High = new(true),
                    Low = new(true),
                    Max = new(true),
                    Medium = new(true),
                    Supported = true,
                    Xhigh = new(true),
                },
                ImageInput = new(true),
                PdfInput = new(true),
                ServerTools = new()
                {
                    CodeExecution = new(true),
                    Supported = true,
                    WebSearch = new(true),
                },
                StructuredOutputs = new(true),
                Thinking = new()
                {
                    Supported = true,
                    Types = new()
                    {
                        Adaptive = new(true),
                        Disabled = new(true),
                        Enabled = new(true),
                    },
                },
            },
            CreatedAt = DateTimeOffset.Parse("2026-07-24T00:00:00Z"),
            DeprecatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "Claude Opus 5",
            Lifecycle = ModelInfoLifecycle.Active,
            Line = ModelLine.Haiku,
            MaxInputTokens = 0,
            MaxTokens = 0,
            RetiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ModelInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModelInfoLifecycleTest : TestBase
{
    [Theory]
    [InlineData(ModelInfoLifecycle.Active)]
    [InlineData(ModelInfoLifecycle.Deprecated)]
    [InlineData(ModelInfoLifecycle.Retired)]
    public void Validation_Works(ModelInfoLifecycle rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelInfoLifecycle> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelInfoLifecycle>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ModelInfoLifecycle.Active)]
    [InlineData(ModelInfoLifecycle.Deprecated)]
    [InlineData(ModelInfoLifecycle.Retired)]
    public void SerializationRoundtrip_Works(ModelInfoLifecycle rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelInfoLifecycle> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelInfoLifecycle>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelInfoLifecycle>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelInfoLifecycle>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
