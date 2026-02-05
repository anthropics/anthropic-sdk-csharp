using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCompact20260112EditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCompact20260112Edit
        {
            Instructions = "instructions",
            PauseAfterCompaction = true,
            Trigger = new(1),
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("compact_20260112");
        string expectedInstructions = "instructions";
        bool expectedPauseAfterCompaction = true;
        BetaInputTokensTrigger expectedTrigger = new(1);

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedInstructions, model.Instructions);
        Assert.Equal(expectedPauseAfterCompaction, model.PauseAfterCompaction);
        Assert.Equal(expectedTrigger, model.Trigger);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCompact20260112Edit
        {
            Instructions = "instructions",
            PauseAfterCompaction = true,
            Trigger = new(1),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCompact20260112Edit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCompact20260112Edit
        {
            Instructions = "instructions",
            PauseAfterCompaction = true,
            Trigger = new(1),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCompact20260112Edit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("compact_20260112");
        string expectedInstructions = "instructions";
        bool expectedPauseAfterCompaction = true;
        BetaInputTokensTrigger expectedTrigger = new(1);

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedInstructions, deserialized.Instructions);
        Assert.Equal(expectedPauseAfterCompaction, deserialized.PauseAfterCompaction);
        Assert.Equal(expectedTrigger, deserialized.Trigger);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCompact20260112Edit
        {
            Instructions = "instructions",
            PauseAfterCompaction = true,
            Trigger = new(1),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaCompact20260112Edit { Instructions = "instructions", Trigger = new(1) };

        Assert.Null(model.PauseAfterCompaction);
        Assert.False(model.RawData.ContainsKey("pause_after_compaction"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaCompact20260112Edit { Instructions = "instructions", Trigger = new(1) };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaCompact20260112Edit
        {
            Instructions = "instructions",
            Trigger = new(1),

            // Null should be interpreted as omitted for these properties
            PauseAfterCompaction = null,
        };

        Assert.Null(model.PauseAfterCompaction);
        Assert.False(model.RawData.ContainsKey("pause_after_compaction"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaCompact20260112Edit
        {
            Instructions = "instructions",
            Trigger = new(1),

            // Null should be interpreted as omitted for these properties
            PauseAfterCompaction = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaCompact20260112Edit { PauseAfterCompaction = true };

        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.Trigger);
        Assert.False(model.RawData.ContainsKey("trigger"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaCompact20260112Edit { PauseAfterCompaction = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaCompact20260112Edit
        {
            PauseAfterCompaction = true,

            Instructions = null,
            Trigger = null,
        };

        Assert.Null(model.Instructions);
        Assert.True(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.Trigger);
        Assert.True(model.RawData.ContainsKey("trigger"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaCompact20260112Edit
        {
            PauseAfterCompaction = true,

            Instructions = null,
            Trigger = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaCompact20260112Edit
        {
            Instructions = "instructions",
            PauseAfterCompaction = true,
            Trigger = new(1),
        };

        BetaCompact20260112Edit copied = new(model);

        Assert.Equal(model, copied);
    }
}
