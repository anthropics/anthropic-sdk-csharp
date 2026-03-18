using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Models;

namespace Anthropic.Tests.Models.Models;

public class ContextManagementCapabilityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContextManagementCapability
        {
            ClearThinking20251015 = new(true),
            ClearToolUses20250919 = new(true),
            Compact20260112 = new(true),
            Supported = true,
        };

        CapabilitySupport expectedClearThinking20251015 = new(true);
        CapabilitySupport expectedClearToolUses20250919 = new(true);
        CapabilitySupport expectedCompact20260112 = new(true);
        bool expectedSupported = true;

        Assert.Equal(expectedClearThinking20251015, model.ClearThinking20251015);
        Assert.Equal(expectedClearToolUses20250919, model.ClearToolUses20250919);
        Assert.Equal(expectedCompact20260112, model.Compact20260112);
        Assert.Equal(expectedSupported, model.Supported);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContextManagementCapability
        {
            ClearThinking20251015 = new(true),
            ClearToolUses20250919 = new(true),
            Compact20260112 = new(true),
            Supported = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContextManagementCapability>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContextManagementCapability
        {
            ClearThinking20251015 = new(true),
            ClearToolUses20250919 = new(true),
            Compact20260112 = new(true),
            Supported = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContextManagementCapability>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CapabilitySupport expectedClearThinking20251015 = new(true);
        CapabilitySupport expectedClearToolUses20250919 = new(true);
        CapabilitySupport expectedCompact20260112 = new(true);
        bool expectedSupported = true;

        Assert.Equal(expectedClearThinking20251015, deserialized.ClearThinking20251015);
        Assert.Equal(expectedClearToolUses20250919, deserialized.ClearToolUses20250919);
        Assert.Equal(expectedCompact20260112, deserialized.Compact20260112);
        Assert.Equal(expectedSupported, deserialized.Supported);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContextManagementCapability
        {
            ClearThinking20251015 = new(true),
            ClearToolUses20250919 = new(true),
            Compact20260112 = new(true),
            Supported = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContextManagementCapability
        {
            ClearThinking20251015 = new(true),
            ClearToolUses20250919 = new(true),
            Compact20260112 = new(true),
            Supported = true,
        };

        ContextManagementCapability copied = new(model);

        Assert.Equal(model, copied);
    }
}
