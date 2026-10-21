using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClearToolUses20250919Edit>(
            json,
            ModelBase.SerializerOptions
        );

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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClearToolUses20250919Edit>(
            element,
            ModelBase.SerializerOptions
        );
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
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaClearToolUses20250919Edit
        {
            ClearAtLeast = new(0),
            ClearToolInputs = true,
            ExcludeTools = ["string"],
            Keep = new(0),
            Trigger = new BetaInputTokensTrigger(1),
        } with
        {
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

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClearToolUses20250919Edit
        {
            ClearAtLeast = new(0),
            ClearToolInputs = true,
            ExcludeTools = ["string"],
            Keep = new(0),
            Trigger = new BetaInputTokensTrigger(1),
        };

        BetaClearToolUses20250919Edit copied = new(model);

        Assert.Equal(model, copied);
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClearToolInputs>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        ClearToolInputs value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClearToolInputs>(
            element,
            ModelBase.SerializerOptions
        );

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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Trigger>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolUsesSerializationRoundtripWorks()
    {
        Trigger value = new BetaToolUsesTrigger(1);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Trigger>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaInputTokensTypeWorks()
    {
        Trigger value = new BetaInputTokensTrigger(1);
        Assert.Equal(TriggerType.InputTokens, value.Type.Value());
    }

    [Fact]
    public void BetaToolUsesTypeWorks()
    {
        Trigger value = new BetaToolUsesTrigger(1);
        Assert.Equal(TriggerType.ToolUses, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Trigger value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "input_tokens",
                  "value": 1
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, TriggerType> expectedType = TriggerType.InputTokens;
        long expectedValueValue = 1;

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedValueValue, value.ValueValue);

        Trigger emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.ValueValue);

        Trigger mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "value": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.ValueValue);
    }
}

public class TriggerTypeTest : TestBase
{
    [Theory]
    [InlineData(TriggerType.InputTokens)]
    [InlineData(TriggerType.ToolUses)]
    public void Validation_Works(TriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TriggerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TriggerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TriggerType.InputTokens)]
    [InlineData(TriggerType.ToolUses)]
    public void SerializationRoundtrip_Works(TriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TriggerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TriggerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TriggerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TriggerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
