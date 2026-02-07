using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InferenceGeo = "inference_geo",
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
                    OutputTokens = 0,
                },
            ],
            OutputTokens = 503,
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
            ServiceTier = BetaUsageServiceTier.Standard,
            Speed = BetaUsageSpeed.Standard,
        };

        BetaCacheCreation expectedCacheCreation = new()
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };
        long expectedCacheCreationInputTokens = 2051;
        long expectedCacheReadInputTokens = 2051;
        string expectedInferenceGeo = "inference_geo";
        long expectedInputTokens = 2095;
        List<UnnamedSchemaWithArrayParent0> expectedIterations =
        [
            new BetaMessageIterationUsage()
            {
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 0,
                CacheReadInputTokens = 0,
                InputTokens = 0,
                OutputTokens = 0,
            },
        ];
        long expectedOutputTokens = 503;
        BetaServerToolUsage expectedServerToolUse = new()
        {
            WebFetchRequests = 2,
            WebSearchRequests = 0,
        };
        ApiEnum<string, BetaUsageServiceTier> expectedServiceTier = BetaUsageServiceTier.Standard;
        ApiEnum<string, BetaUsageSpeed> expectedSpeed = BetaUsageSpeed.Standard;

        Assert.Equal(expectedCacheCreation, model.CacheCreation);
        Assert.Equal(expectedCacheCreationInputTokens, model.CacheCreationInputTokens);
        Assert.Equal(expectedCacheReadInputTokens, model.CacheReadInputTokens);
        Assert.Equal(expectedInferenceGeo, model.InferenceGeo);
        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.NotNull(model.Iterations);
        Assert.Equal(expectedIterations.Count, model.Iterations.Count);
        for (int i = 0; i < expectedIterations.Count; i++)
        {
            Assert.Equal(expectedIterations[i], model.Iterations[i]);
        }
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.Equal(expectedServerToolUse, model.ServerToolUse);
        Assert.Equal(expectedServiceTier, model.ServiceTier);
        Assert.Equal(expectedSpeed, model.Speed);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InferenceGeo = "inference_geo",
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
                    OutputTokens = 0,
                },
            ],
            OutputTokens = 503,
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
            ServiceTier = BetaUsageServiceTier.Standard,
            Speed = BetaUsageSpeed.Standard,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaUsage>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InferenceGeo = "inference_geo",
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
                    OutputTokens = 0,
                },
            ],
            OutputTokens = 503,
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
            ServiceTier = BetaUsageServiceTier.Standard,
            Speed = BetaUsageSpeed.Standard,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaCacheCreation expectedCacheCreation = new()
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };
        long expectedCacheCreationInputTokens = 2051;
        long expectedCacheReadInputTokens = 2051;
        string expectedInferenceGeo = "inference_geo";
        long expectedInputTokens = 2095;
        List<UnnamedSchemaWithArrayParent0> expectedIterations =
        [
            new BetaMessageIterationUsage()
            {
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheCreationInputTokens = 0,
                CacheReadInputTokens = 0,
                InputTokens = 0,
                OutputTokens = 0,
            },
        ];
        long expectedOutputTokens = 503;
        BetaServerToolUsage expectedServerToolUse = new()
        {
            WebFetchRequests = 2,
            WebSearchRequests = 0,
        };
        ApiEnum<string, BetaUsageServiceTier> expectedServiceTier = BetaUsageServiceTier.Standard;
        ApiEnum<string, BetaUsageSpeed> expectedSpeed = BetaUsageSpeed.Standard;

        Assert.Equal(expectedCacheCreation, deserialized.CacheCreation);
        Assert.Equal(expectedCacheCreationInputTokens, deserialized.CacheCreationInputTokens);
        Assert.Equal(expectedCacheReadInputTokens, deserialized.CacheReadInputTokens);
        Assert.Equal(expectedInferenceGeo, deserialized.InferenceGeo);
        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
        Assert.NotNull(deserialized.Iterations);
        Assert.Equal(expectedIterations.Count, deserialized.Iterations.Count);
        for (int i = 0; i < expectedIterations.Count; i++)
        {
            Assert.Equal(expectedIterations[i], deserialized.Iterations[i]);
        }
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
        Assert.Equal(expectedServerToolUse, deserialized.ServerToolUse);
        Assert.Equal(expectedServiceTier, deserialized.ServiceTier);
        Assert.Equal(expectedSpeed, deserialized.Speed);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InferenceGeo = "inference_geo",
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
                    OutputTokens = 0,
                },
            ],
            OutputTokens = 503,
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
            ServiceTier = BetaUsageServiceTier.Standard,
            Speed = BetaUsageSpeed.Standard,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaUsage
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
            InferenceGeo = "inference_geo",
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
                    OutputTokens = 0,
                },
            ],
            OutputTokens = 503,
            ServerToolUse = new() { WebFetchRequests = 2, WebSearchRequests = 0 },
            ServiceTier = BetaUsageServiceTier.Standard,
            Speed = BetaUsageSpeed.Standard,
        };

        BetaUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaUsageServiceTierTest : TestBase
{
    [Theory]
    [InlineData(BetaUsageServiceTier.Standard)]
    [InlineData(BetaUsageServiceTier.Priority)]
    [InlineData(BetaUsageServiceTier.Batch)]
    public void Validation_Works(BetaUsageServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaUsageServiceTier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaUsageServiceTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaUsageServiceTier.Standard)]
    [InlineData(BetaUsageServiceTier.Priority)]
    [InlineData(BetaUsageServiceTier.Batch)]
    public void SerializationRoundtrip_Works(BetaUsageServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaUsageServiceTier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaUsageServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaUsageServiceTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaUsageServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaUsageSpeedTest : TestBase
{
    [Theory]
    [InlineData(BetaUsageSpeed.Standard)]
    [InlineData(BetaUsageSpeed.Fast)]
    public void Validation_Works(BetaUsageSpeed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaUsageSpeed> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaUsageSpeed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaUsageSpeed.Standard)]
    [InlineData(BetaUsageSpeed.Fast)]
    public void SerializationRoundtrip_Works(BetaUsageSpeed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaUsageSpeed> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaUsageSpeed>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaUsageSpeed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaUsageSpeed>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
