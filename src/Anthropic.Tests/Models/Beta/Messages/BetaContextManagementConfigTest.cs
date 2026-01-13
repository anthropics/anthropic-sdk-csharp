using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaContextManagementConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaContextManagementConfig
        {
            Edits =
            [
                new BetaClearToolUses20250919Edit()
                {
                    ClearAtLeast = new(0),
                    ClearToolInputs = true,
                    ExcludeTools = ["string"],
                    Keep = new(0),
                    Trigger = new BetaInputTokensTrigger(1),
                },
            ],
        };

        List<Edit> expectedEdits =
        [
            new BetaClearToolUses20250919Edit()
            {
                ClearAtLeast = new(0),
                ClearToolInputs = true,
                ExcludeTools = ["string"],
                Keep = new(0),
                Trigger = new BetaInputTokensTrigger(1),
            },
        ];

        Assert.NotNull(model.Edits);
        Assert.Equal(expectedEdits.Count, model.Edits.Count);
        for (int i = 0; i < expectedEdits.Count; i++)
        {
            Assert.Equal(expectedEdits[i], model.Edits[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaContextManagementConfig
        {
            Edits =
            [
                new BetaClearToolUses20250919Edit()
                {
                    ClearAtLeast = new(0),
                    ClearToolInputs = true,
                    ExcludeTools = ["string"],
                    Keep = new(0),
                    Trigger = new BetaInputTokensTrigger(1),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContextManagementConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaContextManagementConfig
        {
            Edits =
            [
                new BetaClearToolUses20250919Edit()
                {
                    ClearAtLeast = new(0),
                    ClearToolInputs = true,
                    ExcludeTools = ["string"],
                    Keep = new(0),
                    Trigger = new BetaInputTokensTrigger(1),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContextManagementConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Edit> expectedEdits =
        [
            new BetaClearToolUses20250919Edit()
            {
                ClearAtLeast = new(0),
                ClearToolInputs = true,
                ExcludeTools = ["string"],
                Keep = new(0),
                Trigger = new BetaInputTokensTrigger(1),
            },
        ];

        Assert.NotNull(deserialized.Edits);
        Assert.Equal(expectedEdits.Count, deserialized.Edits.Count);
        for (int i = 0; i < expectedEdits.Count; i++)
        {
            Assert.Equal(expectedEdits[i], deserialized.Edits[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaContextManagementConfig
        {
            Edits =
            [
                new BetaClearToolUses20250919Edit()
                {
                    ClearAtLeast = new(0),
                    ClearToolInputs = true,
                    ExcludeTools = ["string"],
                    Keep = new(0),
                    Trigger = new BetaInputTokensTrigger(1),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaContextManagementConfig { };

        Assert.Null(model.Edits);
        Assert.False(model.RawData.ContainsKey("edits"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaContextManagementConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaContextManagementConfig
        {
            // Null should be interpreted as omitted for these properties
            Edits = null,
        };

        Assert.Null(model.Edits);
        Assert.False(model.RawData.ContainsKey("edits"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaContextManagementConfig
        {
            // Null should be interpreted as omitted for these properties
            Edits = null,
        };

        model.Validate();
    }
}

public class EditTest : TestBase
{
    [Fact]
    public void BetaClearToolUses20250919ValidationWorks()
    {
        Edit value = new BetaClearToolUses20250919Edit()
        {
            ClearAtLeast = new(0),
            ClearToolInputs = true,
            ExcludeTools = ["string"],
            Keep = new(0),
            Trigger = new BetaInputTokensTrigger(1),
        };
        value.Validate();
    }

    [Fact]
    public void BetaClearThinking20251015ValidationWorks()
    {
        Edit value = new BetaClearThinking20251015Edit() { Keep = new BetaThinkingTurns(1) };
        value.Validate();
    }

    [Fact]
    public void BetaClearToolUses20250919SerializationRoundtripWorks()
    {
        Edit value = new BetaClearToolUses20250919Edit()
        {
            ClearAtLeast = new(0),
            ClearToolInputs = true,
            ExcludeTools = ["string"],
            Keep = new(0),
            Trigger = new BetaInputTokensTrigger(1),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Edit>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaClearThinking20251015SerializationRoundtripWorks()
    {
        Edit value = new BetaClearThinking20251015Edit() { Keep = new BetaThinkingTurns(1) };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Edit>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
