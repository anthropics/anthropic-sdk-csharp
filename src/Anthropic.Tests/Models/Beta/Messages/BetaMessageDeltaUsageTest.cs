using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMessageDeltaUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMessageDeltaUsage
        {
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            FallbackCredit = new(new BetaFallbackCreditRedeemed()),
            InputTokens = 2095,
            Iterations =
            [
                new BetaMessageIterationUsage()
                {
                    CacheCreation = new()
                    {
                        Ephemeral1hInputTokens = 0,
                        Ephemeral5mInputTokens = 0,
                    },
                    CacheCreationInputTokens = 0,
                    CacheReadInputTokens = 0,
                    InputTokens = 0,
                    Model = Model.ClaudeHaiku5_5,
                    OutputTokens = 0,
                },
            ],
            OutputTokens = 503,
            OutputTokensDetails = new(0),
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
        };

        long expectedCacheCreationInputTokens = 2051;
        long expectedCacheReadInputTokens = 2051;
        BetaFallbackCreditUsage expectedFallbackCredit = new(new BetaFallbackCreditRedeemed());
        long expectedInputTokens = 2095;
        List<Iteration> expectedIterations =
        [
            new BetaMessageIterationUsage()
            {
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 0,
                CacheReadInputTokens = 0,
                InputTokens = 0,
                Model = Model.ClaudeHaiku5_5,
                OutputTokens = 0,
            },
        ];
        long expectedOutputTokens = 503;
        BetaOutputTokensDetails expectedOutputTokensDetails = new(0);
        BetaServerToolUsage expectedServerToolUse = new()
        {
            WebFetchRequests = 2,
            WebSearchRequests = 0,
        };

        Assert.Equal(expectedCacheCreationInputTokens, model.CacheCreationInputTokens);
        Assert.Equal(expectedCacheReadInputTokens, model.CacheReadInputTokens);
        Assert.Equal(expectedFallbackCredit, model.FallbackCredit);
        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.NotNull(model.Iterations);
        Assert.Equal(expectedIterations.Count, model.Iterations.Count);
        for (int i = 0; i < expectedIterations.Count; i++)
        {
            Assert.Equal(expectedIterations[i], model.Iterations[i]);
        }
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.Equal(expectedOutputTokensDetails, model.OutputTokensDetails);
        Assert.Equal(expectedServerToolUse, model.ServerToolUse);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMessageDeltaUsage
        {
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            FallbackCredit = new(new BetaFallbackCreditRedeemed()),
            InputTokens = 2095,
            Iterations =
            [
                new BetaMessageIterationUsage()
                {
                    CacheCreation = new()
                    {
                        Ephemeral1hInputTokens = 0,
                        Ephemeral5mInputTokens = 0,
                    },
                    CacheCreationInputTokens = 0,
                    CacheReadInputTokens = 0,
                    InputTokens = 0,
                    Model = Model.ClaudeHaiku5_5,
                    OutputTokens = 0,
                },
            ],
            OutputTokens = 503,
            OutputTokensDetails = new(0),
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageDeltaUsage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMessageDeltaUsage
        {
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            FallbackCredit = new(new BetaFallbackCreditRedeemed()),
            InputTokens = 2095,
            Iterations =
            [
                new BetaMessageIterationUsage()
                {
                    CacheCreation = new()
                    {
                        Ephemeral1hInputTokens = 0,
                        Ephemeral5mInputTokens = 0,
                    },
                    CacheCreationInputTokens = 0,
                    CacheReadInputTokens = 0,
                    InputTokens = 0,
                    Model = Model.ClaudeHaiku5_5,
                    OutputTokens = 0,
                },
            ],
            OutputTokens = 503,
            OutputTokensDetails = new(0),
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageDeltaUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCacheCreationInputTokens = 2051;
        long expectedCacheReadInputTokens = 2051;
        BetaFallbackCreditUsage expectedFallbackCredit = new(new BetaFallbackCreditRedeemed());
        long expectedInputTokens = 2095;
        List<Iteration> expectedIterations =
        [
            new BetaMessageIterationUsage()
            {
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 0,
                CacheReadInputTokens = 0,
                InputTokens = 0,
                Model = Model.ClaudeHaiku5_5,
                OutputTokens = 0,
            },
        ];
        long expectedOutputTokens = 503;
        BetaOutputTokensDetails expectedOutputTokensDetails = new(0);
        BetaServerToolUsage expectedServerToolUse = new()
        {
            WebFetchRequests = 2,
            WebSearchRequests = 0,
        };

        Assert.Equal(expectedCacheCreationInputTokens, deserialized.CacheCreationInputTokens);
        Assert.Equal(expectedCacheReadInputTokens, deserialized.CacheReadInputTokens);
        Assert.Equal(expectedFallbackCredit, deserialized.FallbackCredit);
        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
        Assert.NotNull(deserialized.Iterations);
        Assert.Equal(expectedIterations.Count, deserialized.Iterations.Count);
        for (int i = 0; i < expectedIterations.Count; i++)
        {
            Assert.Equal(expectedIterations[i], deserialized.Iterations[i]);
        }
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
        Assert.Equal(expectedOutputTokensDetails, deserialized.OutputTokensDetails);
        Assert.Equal(expectedServerToolUse, deserialized.ServerToolUse);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMessageDeltaUsage
        {
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            FallbackCredit = new(new BetaFallbackCreditRedeemed()),
            InputTokens = 2095,
            Iterations =
            [
                new BetaMessageIterationUsage()
                {
                    CacheCreation = new()
                    {
                        Ephemeral1hInputTokens = 0,
                        Ephemeral5mInputTokens = 0,
                    },
                    CacheCreationInputTokens = 0,
                    CacheReadInputTokens = 0,
                    InputTokens = 0,
                    Model = Model.ClaudeHaiku5_5,
                    OutputTokens = 0,
                },
            ],
            OutputTokens = 503,
            OutputTokensDetails = new(0),
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaMessageDeltaUsage
        {
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            FallbackCredit = new(new BetaFallbackCreditRedeemed()),
            InputTokens = 2095,
            Iterations =
            [
                new BetaMessageIterationUsage()
                {
                    CacheCreation = new()
                    {
                        Ephemeral1hInputTokens = 0,
                        Ephemeral5mInputTokens = 0,
                    },
                    CacheCreationInputTokens = 0,
                    CacheReadInputTokens = 0,
                    InputTokens = 0,
                    Model = Model.ClaudeHaiku5_5,
                    OutputTokens = 0,
                },
            ],
            OutputTokens = 503,
            OutputTokensDetails = new(0),
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
        };

        BetaMessageDeltaUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IterationTest : TestBase
{
    [Fact]
    public void BetaMessageIterationUsageValidationWorks()
    {
        Iteration value = new BetaMessageIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            Model = Model.ClaudeHaiku5_5,
            OutputTokens = 0,
        };
        value.Validate();
    }

    [Fact]
    public void BetaCompactionIterationUsageValidationWorks()
    {
        Iteration value = new BetaCompactionIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };
        value.Validate();
    }

    [Fact]
    public void BetaAdvisorMessageIterationUsageValidationWorks()
    {
        Iteration value = new BetaAdvisorMessageIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            Model = Model.ClaudeHaiku5_5,
            OutputTokens = 0,
        };
        value.Validate();
    }

    [Fact]
    public void BetaFallbackMessageIterationUsageValidationWorks()
    {
        Iteration value = new BetaFallbackMessageIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            Model = Model.ClaudeHaiku5_5,
            OutputTokens = 0,
        };
        value.Validate();
    }

    [Fact]
    public void BetaMessageIterationUsageSerializationRoundtripWorks()
    {
        Iteration value = new BetaMessageIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            Model = Model.ClaudeHaiku5_5,
            OutputTokens = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Iteration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaCompactionIterationUsageSerializationRoundtripWorks()
    {
        Iteration value = new BetaCompactionIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Iteration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaAdvisorMessageIterationUsageSerializationRoundtripWorks()
    {
        Iteration value = new BetaAdvisorMessageIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            Model = Model.ClaudeHaiku5_5,
            OutputTokens = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Iteration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaFallbackMessageIterationUsageSerializationRoundtripWorks()
    {
        Iteration value = new BetaFallbackMessageIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            Model = Model.ClaudeHaiku5_5,
            OutputTokens = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Iteration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaMessageIterationUsageTypeWorks()
    {
        Iteration value = new BetaMessageIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            Model = Model.ClaudeHaiku5_5,
            OutputTokens = 0,
        };
        Assert.Equal(IterationType.Message, value.Type.Value());
    }

    [Fact]
    public void BetaCompactionIterationUsageTypeWorks()
    {
        Iteration value = new BetaCompactionIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            OutputTokens = 0,
        };
        Assert.Equal(IterationType.Compaction, value.Type.Value());
    }

    [Fact]
    public void BetaAdvisorMessageIterationUsageTypeWorks()
    {
        Iteration value = new BetaAdvisorMessageIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            Model = Model.ClaudeHaiku5_5,
            OutputTokens = 0,
        };
        Assert.Equal(IterationType.AdvisorMessage, value.Type.Value());
    }

    [Fact]
    public void BetaFallbackMessageIterationUsageTypeWorks()
    {
        Iteration value = new BetaFallbackMessageIterationUsage()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 0,
            CacheReadInputTokens = 0,
            InputTokens = 0,
            Model = Model.ClaudeHaiku5_5,
            OutputTokens = 0,
        };
        Assert.Equal(IterationType.FallbackMessage, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Iteration value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "cache_creation": {
                    "ephemeral_1h_input_tokens": 0,
                    "ephemeral_5m_input_tokens": 0
                  },
                  "cache_creation_input_tokens": 0,
                  "cache_read_input_tokens": 0,
                  "input_tokens": 0,
                  "model": "claude-haiku-5-5",
                  "output_tokens": 0,
                  "type": "message"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        BetaCacheCreation expectedCacheCreation = new()
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };
        long expectedCacheCreationInputTokens = 0;
        long expectedCacheReadInputTokens = 0;
        long expectedInputTokens = 0;
        ApiEnum<string, Model> expectedModel = Model.ClaudeHaiku5_5;
        long expectedOutputTokens = 0;
        ApiEnum<string, IterationType> expectedType = IterationType.Message;

        Assert.Equal(expectedCacheCreation, value.CacheCreation);
        Assert.Equal(expectedCacheCreationInputTokens, value.CacheCreationInputTokens);
        Assert.Equal(expectedCacheReadInputTokens, value.CacheReadInputTokens);
        Assert.Equal(expectedInputTokens, value.InputTokens);
        Assert.Equal(expectedModel, value.Model);
        Assert.Equal(expectedOutputTokens, value.OutputTokens);
        Assert.Equal(expectedType, value.Type);

        Iteration emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Null(emptyValue.CacheCreation);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.CacheCreationInputTokens);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.CacheReadInputTokens);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.InputTokens);
        Assert.Null(emptyValue.Model);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.OutputTokens);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        Iteration mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "cache_creation": [
                    "invalid"
                  ],
                  "cache_creation_input_tokens": [
                    "invalid"
                  ],
                  "cache_read_input_tokens": [
                    "invalid"
                  ],
                  "input_tokens": [
                    "invalid"
                  ],
                  "output_tokens": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.CacheCreation);
        Assert.Throws<AnthropicInvalidDataException>(() =>
            mismatchedValue.CacheCreationInputTokens
        );
        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.CacheReadInputTokens);
        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.InputTokens);
        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.OutputTokens);
    }
}

public class IterationTypeTest : TestBase
{
    [Theory]
    [InlineData(IterationType.Message)]
    [InlineData(IterationType.Compaction)]
    [InlineData(IterationType.AdvisorMessage)]
    [InlineData(IterationType.FallbackMessage)]
    public void Validation_Works(IterationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IterationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IterationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IterationType.Message)]
    [InlineData(IterationType.Compaction)]
    [InlineData(IterationType.AdvisorMessage)]
    [InlineData(IterationType.FallbackMessage)]
    public void SerializationRoundtrip_Works(IterationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IterationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IterationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IterationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IterationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
