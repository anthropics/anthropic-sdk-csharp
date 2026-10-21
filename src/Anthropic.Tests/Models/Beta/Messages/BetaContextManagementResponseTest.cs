using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContextManagementResponse>(
            json,
            ModelBase.SerializerOptions
        );

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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaContextManagementResponse>(
            element,
            ModelBase.SerializerOptions
        );
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

    [Fact]
    public void CopyConstructor_Works()
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

        BetaContextManagementResponse copied = new(model);

        Assert.Equal(model, copied);
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AppliedEdit>(
            element,
            ModelBase.SerializerOptions
        );

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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AppliedEdit>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaClearToolUses20250919EditResponseTypeWorks()
    {
        AppliedEdit value = new BetaClearToolUses20250919EditResponse()
        {
            ClearedInputTokens = 0,
            ClearedToolUses = 0,
        };
        Assert.Equal(AppliedEditType.ClearToolUses20250919, value.Type.Value());
    }

    [Fact]
    public void BetaClearThinking20251015EditResponseTypeWorks()
    {
        AppliedEdit value = new BetaClearThinking20251015EditResponse()
        {
            ClearedInputTokens = 0,
            ClearedThinkingTurns = 0,
        };
        Assert.Equal(AppliedEditType.ClearThinking20251015, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        AppliedEdit value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "cleared_input_tokens": 0,
                  "type": "clear_tool_uses_20250919"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        long expectedClearedInputTokens = 0;
        ApiEnum<string, AppliedEditType> expectedType = AppliedEditType.ClearToolUses20250919;

        Assert.Equal(expectedClearedInputTokens, value.ClearedInputTokens);
        Assert.Equal(expectedType, value.Type);

        AppliedEdit emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.ClearedInputTokens);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        AppliedEdit mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "cleared_input_tokens": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.ClearedInputTokens);
    }
}

public class AppliedEditTypeTest : TestBase
{
    [Theory]
    [InlineData(AppliedEditType.ClearToolUses20250919)]
    [InlineData(AppliedEditType.ClearThinking20251015)]
    public void Validation_Works(AppliedEditType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AppliedEditType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AppliedEditType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AppliedEditType.ClearToolUses20250919)]
    [InlineData(AppliedEditType.ClearThinking20251015)]
    public void SerializationRoundtrip_Works(AppliedEditType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AppliedEditType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AppliedEditType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AppliedEditType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AppliedEditType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
