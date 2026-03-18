using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Models;

namespace Anthropic.Tests.Models.Beta.Models;

public class BetaContextManagementCapabilityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaContextManagementCapability
        {
            ClearThinking20251015 = new(true),
            ClearToolUses20250919 = new(true),
            Compact20260112 = new(true),
            Supported = true,
        };

        BetaCapabilitySupport expectedClearThinking20251015 = new(true);
        BetaCapabilitySupport expectedClearToolUses20250919 = new(true);
        BetaCapabilitySupport expectedCompact20260112 = new(true);
        bool expectedSupported = true;

        Assert.Equal(expectedClearThinking20251015, model.ClearThinking20251015);
        Assert.Equal(expectedClearToolUses20250919, model.ClearToolUses20250919);
        Assert.Equal(expectedCompact20260112, model.Compact20260112);
        Assert.Equal(expectedSupported, model.Supported);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaContextManagementCapability
        {
            ClearThinking20251015 = new(true),
            ClearToolUses20250919 = new(true),
            Compact20260112 = new(true),
            Supported = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContextManagementCapability>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaContextManagementCapability
        {
            ClearThinking20251015 = new(true),
            ClearToolUses20250919 = new(true),
            Compact20260112 = new(true),
            Supported = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContextManagementCapability>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaCapabilitySupport expectedClearThinking20251015 = new(true);
        BetaCapabilitySupport expectedClearToolUses20250919 = new(true);
        BetaCapabilitySupport expectedCompact20260112 = new(true);
        bool expectedSupported = true;

        Assert.Equal(expectedClearThinking20251015, deserialized.ClearThinking20251015);
        Assert.Equal(expectedClearToolUses20250919, deserialized.ClearToolUses20250919);
        Assert.Equal(expectedCompact20260112, deserialized.Compact20260112);
        Assert.Equal(expectedSupported, deserialized.Supported);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaContextManagementCapability
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
        var model = new BetaContextManagementCapability
        {
            ClearThinking20251015 = new(true),
            ClearToolUses20250919 = new(true),
            Compact20260112 = new(true),
            Supported = true,
        };

        BetaContextManagementCapability copied = new(model);

        Assert.Equal(model, copied);
    }
}
