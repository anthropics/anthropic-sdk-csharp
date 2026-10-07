using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Models;

namespace Anthropic.Tests.Models.Beta.Models;

public class BetaModelInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaModelInfo
        {
            ID = "claude-opus-5",
            AllowedFallbackModels = ["string"],
            Capabilities = new()
            {
                Batch = new(true),
                Citations = new(true),
                CodeExecution = new(true),
                Compaction = new() { Summarize = new(true), Supported = true },
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
            Lifecycle = BetaModelInfoLifecycle.Active,
            Line = BetaModelLine.Haiku,
            MaxInputTokens = 0,
            MaxTokens = 0,
            RetiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "claude-opus-5";
        List<string> expectedAllowedFallbackModels = ["string"];
        BetaModelCapabilities expectedCapabilities = new()
        {
            Batch = new(true),
            Citations = new(true),
            CodeExecution = new(true),
            Compaction = new() { Summarize = new(true), Supported = true },
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
        ApiEnum<string, BetaModelInfoLifecycle> expectedLifecycle = BetaModelInfoLifecycle.Active;
        ApiEnum<string, BetaModelLine> expectedLine = BetaModelLine.Haiku;
        long expectedMaxInputTokens = 0;
        long expectedMaxTokens = 0;
        DateTimeOffset expectedRetiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("model");

        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.AllowedFallbackModels);
        Assert.Equal(expectedAllowedFallbackModels.Count, model.AllowedFallbackModels.Count);
        for (int i = 0; i < expectedAllowedFallbackModels.Count; i++)
        {
            Assert.Equal(expectedAllowedFallbackModels[i], model.AllowedFallbackModels[i]);
        }
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
        var model = new BetaModelInfo
        {
            ID = "claude-opus-5",
            AllowedFallbackModels = ["string"],
            Capabilities = new()
            {
                Batch = new(true),
                Citations = new(true),
                CodeExecution = new(true),
                Compaction = new() { Summarize = new(true), Supported = true },
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
            Lifecycle = BetaModelInfoLifecycle.Active,
            Line = BetaModelLine.Haiku,
            MaxInputTokens = 0,
            MaxTokens = 0,
            RetiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaModelInfo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaModelInfo
        {
            ID = "claude-opus-5",
            AllowedFallbackModels = ["string"],
            Capabilities = new()
            {
                Batch = new(true),
                Citations = new(true),
                CodeExecution = new(true),
                Compaction = new() { Summarize = new(true), Supported = true },
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
            Lifecycle = BetaModelInfoLifecycle.Active,
            Line = BetaModelLine.Haiku,
            MaxInputTokens = 0,
            MaxTokens = 0,
            RetiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaModelInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "claude-opus-5";
        List<string> expectedAllowedFallbackModels = ["string"];
        BetaModelCapabilities expectedCapabilities = new()
        {
            Batch = new(true),
            Citations = new(true),
            CodeExecution = new(true),
            Compaction = new() { Summarize = new(true), Supported = true },
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
        ApiEnum<string, BetaModelInfoLifecycle> expectedLifecycle = BetaModelInfoLifecycle.Active;
        ApiEnum<string, BetaModelLine> expectedLine = BetaModelLine.Haiku;
        long expectedMaxInputTokens = 0;
        long expectedMaxTokens = 0;
        DateTimeOffset expectedRetiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("model");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.AllowedFallbackModels);
        Assert.Equal(expectedAllowedFallbackModels.Count, deserialized.AllowedFallbackModels.Count);
        for (int i = 0; i < expectedAllowedFallbackModels.Count; i++)
        {
            Assert.Equal(expectedAllowedFallbackModels[i], deserialized.AllowedFallbackModels[i]);
        }
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
        var model = new BetaModelInfo
        {
            ID = "claude-opus-5",
            AllowedFallbackModels = ["string"],
            Capabilities = new()
            {
                Batch = new(true),
                Citations = new(true),
                CodeExecution = new(true),
                Compaction = new() { Summarize = new(true), Supported = true },
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
            Lifecycle = BetaModelInfoLifecycle.Active,
            Line = BetaModelLine.Haiku,
            MaxInputTokens = 0,
            MaxTokens = 0,
            RetiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaModelInfo
        {
            ID = "claude-opus-5",
            AllowedFallbackModels = ["string"],
            Capabilities = new()
            {
                Batch = new(true),
                Citations = new(true),
                CodeExecution = new(true),
                Compaction = new() { Summarize = new(true), Supported = true },
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
            Lifecycle = BetaModelInfoLifecycle.Active,
            Line = BetaModelLine.Haiku,
            MaxInputTokens = 0,
            MaxTokens = 0,
            RetiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaModelInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaModelInfoLifecycleTest : TestBase
{
    [Theory]
    [InlineData(BetaModelInfoLifecycle.Active)]
    [InlineData(BetaModelInfoLifecycle.Deprecated)]
    [InlineData(BetaModelInfoLifecycle.Retired)]
    public void Validation_Works(BetaModelInfoLifecycle rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaModelInfoLifecycle> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaModelInfoLifecycle>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaModelInfoLifecycle.Active)]
    [InlineData(BetaModelInfoLifecycle.Deprecated)]
    [InlineData(BetaModelInfoLifecycle.Retired)]
    public void SerializationRoundtrip_Works(BetaModelInfoLifecycle rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaModelInfoLifecycle> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaModelInfoLifecycle>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaModelInfoLifecycle>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaModelInfoLifecycle>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
