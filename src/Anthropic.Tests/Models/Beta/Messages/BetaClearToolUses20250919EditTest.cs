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

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"clear_tool_uses_20250919\""
        );
        BetaInputTokensClearAtLeast expectedClearAtLeast = new(0);
        ClearToolInputs expectedClearToolInputs = true;
        List<string> expectedExcludeTools = ["string"];
        BetaToolUsesKeep expectedKeep = new(0);
        Trigger expectedTrigger = new BetaInputTokensTrigger(1);

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedClearAtLeast, model.ClearAtLeast);
        Assert.Equal(expectedClearToolInputs, model.ClearToolInputs);
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaClearToolUses20250919Edit>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"clear_tool_uses_20250919\""
        );
        BetaInputTokensClearAtLeast expectedClearAtLeast = new(0);
        ClearToolInputs expectedClearToolInputs = true;
        List<string> expectedExcludeTools = ["string"];
        BetaToolUsesKeep expectedKeep = new(0);
        Trigger expectedTrigger = new BetaInputTokensTrigger(1);

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedClearAtLeast, deserialized.ClearAtLeast);
        Assert.Equal(expectedClearToolInputs, deserialized.ClearToolInputs);
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
    public void boolValidation_Works()
    {
        ClearToolInputs value = new(true);
        value.Validate();
    }

    [Fact]
    public void stringsValidation_Works()
    {
        ClearToolInputs value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void boolSerializationRoundtrip_Works()
    {
        ClearToolInputs value = new(true);
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ClearToolInputs>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void stringsSerializationRoundtrip_Works()
    {
        ClearToolInputs value = new(["string"]);
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ClearToolInputs>(json);

        Assert.Equal(value, deserialized);
    }
}

public class TriggerTest : TestBase
{
    [Fact]
    public void beta_input_tokensValidation_Works()
    {
        Trigger value = new(new(1));
        value.Validate();
    }

    [Fact]
    public void beta_tool_usesValidation_Works()
    {
        Trigger value = new(new(1));
        value.Validate();
    }

    [Fact]
    public void beta_input_tokensSerializationRoundtrip_Works()
    {
        Trigger value = new(new(1));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Trigger>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_tool_usesSerializationRoundtrip_Works()
    {
        Trigger value = new(new(1));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Trigger>(json);

        Assert.Equal(value, deserialized);
    }
}
