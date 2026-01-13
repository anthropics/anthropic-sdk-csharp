using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaClearToolUses20250919EditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClearToolUses20250919Edit
        {
            ClearAtLeast = new(0),
            ClearToolInputs = true,
            ExcludeTools = ["string"],
            Keep = new(0),
            Trigger = new BetaInputTokensTrigger(1),
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("clear_tool_uses_20250919");
        BetaInputTokensClearAtLeast expectedClearAtLeast = new(0);
        ClearToolInputs expectedClearToolInputs = true;
        List<string> expectedExcludeTools = ["string"];
        BetaToolUsesKeep expectedKeep = new(0);
        Trigger expectedTrigger = new BetaInputTokensTrigger(1);

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedClearAtLeast, model.ClearAtLeast);
        Assert.Equal(expectedClearToolInputs, model.ClearToolInputs);
        Assert.NotNull(model.ExcludeTools);
        Assert.Equal(expectedExcludeTools.Count, model.ExcludeTools.Count);
        for (int i = 0; i < expectedExcludeTools.Count; i++)
        {
            Assert.Equal(expectedExcludeTools[i], model.ExcludeTools[i]);
        }
        Assert.Equal(expectedKeep, model.Keep);
        Assert.Equal(expectedTrigger, model.Trigger);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClearToolUses20250919Edit
        {
            ClearAtLeast = new(0),
            ClearToolInputs = true,
            ExcludeTools = ["string"],
            Keep = new(0),
            Trigger = new BetaInputTokensTrigger(1),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaClearToolUses20250919Edit>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClearToolUses20250919Edit
        {
            ClearAtLeast = new(0),
            ClearToolInputs = true,
            ExcludeTools = ["string"],
            Keep = new(0),
            Trigger = new BetaInputTokensTrigger(1),
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaClearToolUses20250919Edit>(element);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("clear_tool_uses_20250919");
        BetaInputTokensClearAtLeast expectedClearAtLeast = new(0);
        ClearToolInputs expectedClearToolInputs = true;
        List<string> expectedExcludeTools = ["string"];
        BetaToolUsesKeep expectedKeep = new(0);
        Trigger expectedTrigger = new BetaInputTokensTrigger(1);

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedClearAtLeast, deserialized.ClearAtLeast);
        Assert.Equal(expectedClearToolInputs, deserialized.ClearToolInputs);
        Assert.NotNull(deserialized.ExcludeTools);
        Assert.Equal(expectedExcludeTools.Count, deserialized.ExcludeTools.Count);
        for (int i = 0; i < expectedExcludeTools.Count; i++)
        {
            Assert.Equal(expectedExcludeTools[i], deserialized.ExcludeTools[i]);
        }
        Assert.Equal(expectedKeep, deserialized.Keep);
        Assert.Equal(expectedTrigger, deserialized.Trigger);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClearToolUses20250919Edit
        {
            ClearAtLeast = new(0),
            ClearToolInputs = true,
            ExcludeTools = ["string"],
            Keep = new(0),
            Trigger = new BetaInputTokensTrigger(1),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaClearToolUses20250919Edit
        {
            ClearAtLeast = new(0),
            ClearToolInputs = true,
            ExcludeTools = ["string"],
        };

        Assert.Null(model.Keep);
        Assert.False(model.RawData.ContainsKey("keep"));
        Assert.Null(model.Trigger);
        Assert.False(model.RawData.ContainsKey("trigger"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaClearToolUses20250919Edit
        {
            ClearAtLeast = new(0),
            ClearToolInputs = true,
            ExcludeTools = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaClearToolUses20250919Edit
        {
            ClearAtLeast = new(0),
            ClearToolInputs = true,
            ExcludeTools = ["string"],

            // Null should be interpreted as omitted for these properties
            Keep = null,
            Trigger = null,
        };

        Assert.Null(model.Keep);
        Assert.False(model.RawData.ContainsKey("keep"));
        Assert.Null(model.Trigger);
        Assert.False(model.RawData.ContainsKey("trigger"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaClearToolUses20250919Edit
        {
            ClearAtLeast = new(0),
            ClearToolInputs = true,
            ExcludeTools = ["string"],

            // Null should be interpreted as omitted for these properties
            Keep = null,
            Trigger = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaClearToolUses20250919Edit
        {
            Keep = new(0),
            Trigger = new BetaInputTokensTrigger(1),
        };

        Assert.Null(model.ClearAtLeast);
        Assert.False(model.RawData.ContainsKey("clear_at_least"));
        Assert.Null(model.ClearToolInputs);
        Assert.False(model.RawData.ContainsKey("clear_tool_inputs"));
        Assert.Null(model.ExcludeTools);
        Assert.False(model.RawData.ContainsKey("exclude_tools"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaClearToolUses20250919Edit
        {
            Keep = new(0),
            Trigger = new BetaInputTokensTrigger(1),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaClearToolUses20250919Edit
        {
            Keep = new(0),
            Trigger = new BetaInputTokensTrigger(1),

            ClearAtLeast = null,
            ClearToolInputs = null,
            ExcludeTools = null,
        };

        Assert.Null(model.ClearAtLeast);
        Assert.True(model.RawData.ContainsKey("clear_at_least"));
        Assert.Null(model.ClearToolInputs);
        Assert.True(model.RawData.ContainsKey("clear_tool_inputs"));
        Assert.Null(model.ExcludeTools);
        Assert.True(model.RawData.ContainsKey("exclude_tools"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaClearToolUses20250919Edit
        {
            Keep = new(0),
            Trigger = new BetaInputTokensTrigger(1),

            ClearAtLeast = null,
            ClearToolInputs = null,
            ExcludeTools = null,
        };

        model.Validate();
    }
}

public class ClearToolInputsTest : TestBase
{
    [Fact]
    public void BoolValidationWorks()
    {
        ClearToolInputs value = true;
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        ClearToolInputs value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ClearToolInputs value = true;
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ClearToolInputs>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        ClearToolInputs value = new(["string"]);
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ClearToolInputs>(element);

        Assert.Equal(value, deserialized);
    }
}

public class TriggerTest : TestBase
{
    [Fact]
    public void BetaInputTokensValidationWorks()
    {
        Trigger value = new BetaInputTokensTrigger(1);
        value.Validate();
    }

    [Fact]
    public void BetaToolUsesValidationWorks()
    {
        Trigger value = new BetaToolUsesTrigger(1);
        value.Validate();
    }

    [Fact]
    public void BetaInputTokensSerializationRoundtripWorks()
    {
        Trigger value = new BetaInputTokensTrigger(1);
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Trigger>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolUsesSerializationRoundtripWorks()
    {
        Trigger value = new BetaToolUsesTrigger(1);
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Trigger>(element);

        Assert.Equal(value, deserialized);
    }
}
