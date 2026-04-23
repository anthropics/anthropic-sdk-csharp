using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Models;

namespace Anthropic.Tests.Models.Models;

public class ModelCapabilitiesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ModelCapabilities
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

        CapabilitySupport expectedBatch = new(true);
        CapabilitySupport expectedCitations = new(true);
        CapabilitySupport expectedCodeExecution = new(true);
        ContextManagementCapability expectedContextManagement = new()
        {
            ClearThinking20251015 = new(true),
            ClearToolUses20250919 = new(true),
            Compact20260112 = new(true),
            Supported = true,
        };
        EffortCapability expectedEffort = new()
        {
            High = new(true),
            Low = new(true),
            Max = new(true),
            Medium = new(true),
            Supported = true,
        };
        CapabilitySupport expectedImageInput = new(true);
        CapabilitySupport expectedPdfInput = new(true);
        CapabilitySupport expectedStructuredOutputs = new(true);
        ThinkingCapability expectedThinking = new()
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
        var model = new ModelCapabilities
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
        var deserialized = JsonSerializer.Deserialize<ModelCapabilities>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ModelCapabilities
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
        var deserialized = JsonSerializer.Deserialize<ModelCapabilities>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CapabilitySupport expectedBatch = new(true);
        CapabilitySupport expectedCitations = new(true);
        CapabilitySupport expectedCodeExecution = new(true);
        ContextManagementCapability expectedContextManagement = new()
        {
            ClearThinking20251015 = new(true),
            ClearToolUses20250919 = new(true),
            Compact20260112 = new(true),
            Supported = true,
        };
        EffortCapability expectedEffort = new()
        {
            High = new(true),
            Low = new(true),
            Max = new(true),
            Medium = new(true),
            Supported = true,
        };
        CapabilitySupport expectedImageInput = new(true);
        CapabilitySupport expectedPdfInput = new(true);
        CapabilitySupport expectedStructuredOutputs = new(true);
        ThinkingCapability expectedThinking = new()
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
        var model = new ModelCapabilities
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
        var model = new ModelCapabilities
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

        ModelCapabilities copied = new(model);

        Assert.Equal(model, copied);
    }
}
