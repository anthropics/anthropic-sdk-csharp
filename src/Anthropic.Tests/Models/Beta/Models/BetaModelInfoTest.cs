using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Models;

namespace Anthropic.Tests.Models.Beta.Models;

public class BetaModelInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaModelInfo
        {
            ID = "claude-opus-4-6",
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
                },
                ImageInput = new(true),
                PdfInput = new(true),
                StructuredOutputs = new(true),
                Thinking = new()
                {
                    Supported = true,
                    Types = new() { Adaptive = new(true), Enabled = new(true) },
                },
            },
            CreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z"),
            DisplayName = "Claude Opus 4.6",
            MaxInputTokens = 0,
            MaxTokens = 0,
        };

        string expectedID = "claude-opus-4-6";
        BetaModelCapabilities expectedCapabilities = new()
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
            },
            ImageInput = new(true),
            PdfInput = new(true),
            StructuredOutputs = new(true),
            Thinking = new()
            {
                Supported = true,
                Types = new() { Adaptive = new(true), Enabled = new(true) },
            },
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z");
        string expectedDisplayName = "Claude Opus 4.6";
        long expectedMaxInputTokens = 0;
        long expectedMaxTokens = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("model");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCapabilities, model.Capabilities);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedMaxInputTokens, model.MaxInputTokens);
        Assert.Equal(expectedMaxTokens, model.MaxTokens);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaModelInfo
        {
            ID = "claude-opus-4-6",
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
                },
                ImageInput = new(true),
                PdfInput = new(true),
                StructuredOutputs = new(true),
                Thinking = new()
                {
                    Supported = true,
                    Types = new() { Adaptive = new(true), Enabled = new(true) },
                },
            },
            CreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z"),
            DisplayName = "Claude Opus 4.6",
            MaxInputTokens = 0,
            MaxTokens = 0,
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
            ID = "claude-opus-4-6",
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
                },
                ImageInput = new(true),
                PdfInput = new(true),
                StructuredOutputs = new(true),
                Thinking = new()
                {
                    Supported = true,
                    Types = new() { Adaptive = new(true), Enabled = new(true) },
                },
            },
            CreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z"),
            DisplayName = "Claude Opus 4.6",
            MaxInputTokens = 0,
            MaxTokens = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaModelInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "claude-opus-4-6";
        BetaModelCapabilities expectedCapabilities = new()
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
            },
            ImageInput = new(true),
            PdfInput = new(true),
            StructuredOutputs = new(true),
            Thinking = new()
            {
                Supported = true,
                Types = new() { Adaptive = new(true), Enabled = new(true) },
            },
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z");
        string expectedDisplayName = "Claude Opus 4.6";
        long expectedMaxInputTokens = 0;
        long expectedMaxTokens = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("model");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCapabilities, deserialized.Capabilities);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedMaxInputTokens, deserialized.MaxInputTokens);
        Assert.Equal(expectedMaxTokens, deserialized.MaxTokens);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaModelInfo
        {
            ID = "claude-opus-4-6",
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
                },
                ImageInput = new(true),
                PdfInput = new(true),
                StructuredOutputs = new(true),
                Thinking = new()
                {
                    Supported = true,
                    Types = new() { Adaptive = new(true), Enabled = new(true) },
                },
            },
            CreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z"),
            DisplayName = "Claude Opus 4.6",
            MaxInputTokens = 0,
            MaxTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaModelInfo
        {
            ID = "claude-opus-4-6",
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
                },
                ImageInput = new(true),
                PdfInput = new(true),
                StructuredOutputs = new(true),
                Thinking = new()
                {
                    Supported = true,
                    Types = new() { Adaptive = new(true), Enabled = new(true) },
                },
            },
            CreatedAt = DateTimeOffset.Parse("2026-02-04T00:00:00Z"),
            DisplayName = "Claude Opus 4.6",
            MaxInputTokens = 0,
            MaxTokens = 0,
        };

        BetaModelInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}
