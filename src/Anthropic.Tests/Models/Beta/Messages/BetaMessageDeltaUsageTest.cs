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
            FallbackCredit = new(new Status(new BetaFallbackCreditRedeemed())),
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
                    Model = Model.ClaudeFable5_1,
                    OutputTokens = 0,
                },
            ],
            OutputTokens = 503,
            OutputTokensDetails = new(0),
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
        };

        long expectedCacheCreationInputTokens = 2051;
        long expectedCacheReadInputTokens = 2051;
        BetaFallbackCreditUsage expectedFallbackCredit = new(
            new Status(new BetaFallbackCreditRedeemed())
        );
        long expectedInputTokens = 2095;
        List<Iteration> expectedIterations =
        [
            new BetaMessageIterationUsage()
            {
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 0,
                CacheReadInputTokens = 0,
                InputTokens = 0,
                Model = Model.ClaudeFable5_1,
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
            FallbackCredit = new(new Status(new BetaFallbackCreditRedeemed())),
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
                    Model = Model.ClaudeFable5_1,
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
            FallbackCredit = new(new Status(new BetaFallbackCreditRedeemed())),
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
                    Model = Model.ClaudeFable5_1,
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
        BetaFallbackCreditUsage expectedFallbackCredit = new(
            new Status(new BetaFallbackCreditRedeemed())
        );
        long expectedInputTokens = 2095;
        List<Iteration> expectedIterations =
        [
            new BetaMessageIterationUsage()
            {
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 0,
                CacheReadInputTokens = 0,
                InputTokens = 0,
                Model = Model.ClaudeFable5_1,
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
            FallbackCredit = new(new Status(new BetaFallbackCreditRedeemed())),
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
                    Model = Model.ClaudeFable5_1,
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
            FallbackCredit = new(new Status(new BetaFallbackCreditRedeemed())),
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
                    Model = Model.ClaudeFable5_1,
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
            Model = Model.ClaudeFable5_1,
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
            Model = Model.ClaudeFable5_1,
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
            Model = Model.ClaudeFable5_1,
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
            Model = Model.ClaudeFable5_1,
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
            Model = Model.ClaudeFable5_1,
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
            Model = Model.ClaudeFable5_1,
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
                  "model": "claude-fable-5-1",
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
        ApiEnum<string, Model> expectedModel = Model.ClaudeFable5_1;
        long expectedOutputTokens = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("message");

        Assert.Equal(expectedCacheCreation, value.CacheCreation);
        Assert.Equal(expectedCacheCreationInputTokens, value.CacheCreationInputTokens);
        Assert.Equal(expectedCacheReadInputTokens, value.CacheReadInputTokens);
        Assert.Equal(expectedInputTokens, value.InputTokens);
        Assert.Equal(expectedModel, value.Model);
        Assert.Equal(expectedOutputTokens, value.OutputTokens);
        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

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
