using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaContextManagementResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaContextManagementResponse
        {
            AppliedEdits =
            [
                new BetaClearToolUses20250919EditResponse()
                {
                    ClearedInputTokens = 0,
                    ClearedToolUses = 0,
                },
            ],
        };

        List<AppliedEdit> expectedAppliedEdits =
        [
            new BetaClearToolUses20250919EditResponse()
            {
                ClearedInputTokens = 0,
                ClearedToolUses = 0,
            },
        ];

        Assert.Equal(expectedAppliedEdits.Count, model.AppliedEdits.Count);
        for (int i = 0; i < expectedAppliedEdits.Count; i++)
        {
            Assert.Equal(expectedAppliedEdits[i], model.AppliedEdits[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaContextManagementResponse
        {
            AppliedEdits =
            [
                new BetaClearToolUses20250919EditResponse()
                {
                    ClearedInputTokens = 0,
                    ClearedToolUses = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaContextManagementResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaContextManagementResponse
        {
            AppliedEdits =
            [
                new BetaClearToolUses20250919EditResponse()
                {
                    ClearedInputTokens = 0,
                    ClearedToolUses = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaContextManagementResponse>(element);
        Assert.NotNull(deserialized);

        List<AppliedEdit> expectedAppliedEdits =
        [
            new BetaClearToolUses20250919EditResponse()
            {
                ClearedInputTokens = 0,
                ClearedToolUses = 0,
            },
        ];

        Assert.Equal(expectedAppliedEdits.Count, deserialized.AppliedEdits.Count);
        for (int i = 0; i < expectedAppliedEdits.Count; i++)
        {
            Assert.Equal(expectedAppliedEdits[i], deserialized.AppliedEdits[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaContextManagementResponse
        {
            AppliedEdits =
            [
                new BetaClearToolUses20250919EditResponse()
                {
                    ClearedInputTokens = 0,
                    ClearedToolUses = 0,
                },
            ],
        };

        model.Validate();
    }
}

public class AppliedEditTest : TestBase
{
    [Fact]
    public void BetaClearToolUses20250919EditResponseValidationWorks()
    {
        AppliedEdit value = new BetaClearToolUses20250919EditResponse()
        {
            ClearedInputTokens = 0,
            ClearedToolUses = 0,
        };
        value.Validate();
    }

    [Fact]
    public void BetaClearThinking20251015EditResponseValidationWorks()
    {
        AppliedEdit value = new BetaClearThinking20251015EditResponse()
        {
            ClearedInputTokens = 0,
            ClearedThinkingTurns = 0,
        };
        value.Validate();
    }

    [Fact]
    public void BetaClearToolUses20250919EditResponseSerializationRoundtripWorks()
    {
        AppliedEdit value = new BetaClearToolUses20250919EditResponse()
        {
            ClearedInputTokens = 0,
            ClearedToolUses = 0,
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<AppliedEdit>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaClearThinking20251015EditResponseSerializationRoundtripWorks()
    {
        AppliedEdit value = new BetaClearThinking20251015EditResponse()
        {
            ClearedInputTokens = 0,
            ClearedThinkingTurns = 0,
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<AppliedEdit>(element);

        Assert.Equal(value, deserialized);
    }
}
