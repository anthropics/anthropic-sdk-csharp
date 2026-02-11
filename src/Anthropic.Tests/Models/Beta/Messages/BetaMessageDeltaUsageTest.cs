using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

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
        };

        long expectedCacheCreationInputTokens = 2051;
        long expectedCacheReadInputTokens = 2051;
        long expectedInputTokens = 2095;
        List<BetaIterationsUsageItems> expectedIterations =
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

        Assert.Equal(expectedCacheCreationInputTokens, model.CacheCreationInputTokens);
        Assert.Equal(expectedCacheReadInputTokens, model.CacheReadInputTokens);
        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.NotNull(model.Iterations);
        Assert.Equal(expectedIterations.Count, model.Iterations.Count);
        for (int i = 0; i < expectedIterations.Count; i++)
        {
            Assert.Equal(expectedIterations[i], model.Iterations[i]);
        }
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.Equal(expectedServerToolUse, model.ServerToolUse);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMessageDeltaUsage
        {
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageDeltaUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCacheCreationInputTokens = 2051;
        long expectedCacheReadInputTokens = 2051;
        long expectedInputTokens = 2095;
        List<BetaIterationsUsageItems> expectedIterations =
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

        Assert.Equal(expectedCacheCreationInputTokens, deserialized.CacheCreationInputTokens);
        Assert.Equal(expectedCacheReadInputTokens, deserialized.CacheReadInputTokens);
        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
        Assert.NotNull(deserialized.Iterations);
        Assert.Equal(expectedIterations.Count, deserialized.Iterations.Count);
        for (int i = 0; i < expectedIterations.Count; i++)
        {
            Assert.Equal(expectedIterations[i], deserialized.Iterations[i]);
        }
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
        Assert.Equal(expectedServerToolUse, deserialized.ServerToolUse);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMessageDeltaUsage
        {
            CacheCreationInputTokens = 2051,
            CacheReadInputTokens = 2051,
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
        };

        BetaMessageDeltaUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}
