using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Models;

namespace Anthropic.Tests.Models.Beta.Models;

public class BetaModelCapabilitiesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaModelCapabilities
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

        BetaCapabilitySupport expectedBatch = new(true);
        BetaCapabilitySupport expectedCitations = new(true);
        BetaCapabilitySupport expectedCodeExecution = new(true);
        BetaContextManagementCapability expectedContextManagement = new()
        {
            ClearThinking20251015 = new(true),
            ClearToolUses20250919 = new(true),
            Compact20260112 = new(true),
            Supported = true,
        };
        BetaEffortCapability expectedEffort = new()
        {
            High = new(true),
            Low = new(true),
            Max = new(true),
            Medium = new(true),
            Supported = true,
        };
        BetaCapabilitySupport expectedImageInput = new(true);
        BetaCapabilitySupport expectedPdfInput = new(true);
        BetaCapabilitySupport expectedStructuredOutputs = new(true);
        BetaThinkingCapability expectedThinking = new()
        {
            Supported = true,
            Types = new() { Adaptive = new(true), Enabled = new(true) },
        };

        Assert.Equal(expectedBatch, model.Batch);
        Assert.Equal(expectedCitations, model.Citations);
        Assert.Equal(expectedCodeExecution, model.CodeExecution);
        Assert.Equal(expectedContextManagement, model.ContextManagement);
        Assert.Equal(expectedEffort, model.Effort);
        Assert.Equal(expectedImageInput, model.ImageInput);
        Assert.Equal(expectedPdfInput, model.PdfInput);
        Assert.Equal(expectedStructuredOutputs, model.StructuredOutputs);
        Assert.Equal(expectedThinking, model.Thinking);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaModelCapabilities
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaModelCapabilities>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaModelCapabilities
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaModelCapabilities>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaCapabilitySupport expectedBatch = new(true);
        BetaCapabilitySupport expectedCitations = new(true);
        BetaCapabilitySupport expectedCodeExecution = new(true);
        BetaContextManagementCapability expectedContextManagement = new()
        {
            ClearThinking20251015 = new(true),
            ClearToolUses20250919 = new(true),
            Compact20260112 = new(true),
            Supported = true,
        };
        BetaEffortCapability expectedEffort = new()
        {
            High = new(true),
            Low = new(true),
            Max = new(true),
            Medium = new(true),
            Supported = true,
        };
        BetaCapabilitySupport expectedImageInput = new(true);
        BetaCapabilitySupport expectedPdfInput = new(true);
        BetaCapabilitySupport expectedStructuredOutputs = new(true);
        BetaThinkingCapability expectedThinking = new()
        {
            Supported = true,
            Types = new() { Adaptive = new(true), Enabled = new(true) },
        };

        Assert.Equal(expectedBatch, deserialized.Batch);
        Assert.Equal(expectedCitations, deserialized.Citations);
        Assert.Equal(expectedCodeExecution, deserialized.CodeExecution);
        Assert.Equal(expectedContextManagement, deserialized.ContextManagement);
        Assert.Equal(expectedEffort, deserialized.Effort);
        Assert.Equal(expectedImageInput, deserialized.ImageInput);
        Assert.Equal(expectedPdfInput, deserialized.PdfInput);
        Assert.Equal(expectedStructuredOutputs, deserialized.StructuredOutputs);
        Assert.Equal(expectedThinking, deserialized.Thinking);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaModelCapabilities
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaModelCapabilities
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

        BetaModelCapabilities copied = new(model);

        Assert.Equal(model, copied);
    }
}
