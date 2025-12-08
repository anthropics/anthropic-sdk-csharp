using System.Collections.Generic;
using System.Text.Json;
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaContextManagementConfig>(json);

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaContextManagementConfig>(json);
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
