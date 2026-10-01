using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsUsageReportTimeBucketTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsUsageReportTimeBucket
        {
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Results =
            [
                new()
                {
                    CacheCreation = new()
                    {
                        Ephemeral1hInputTokens = 0,
                        Ephemeral5mInputTokens = 0,
                    },
                    CacheReadInputTokens = 0,
                    ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                    ClaudeTagUserID = "U0123ABCDEF",
                    ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                    InferenceGeo = BetaAnalyticsUsageBucketedResultInferenceGeo.Global,
                    Model = "claude-opus-5",
                    OutputTokens = 0,
                    Product = "chat",
                    RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                    Requests = 0,
                    ServerToolUse = new(10),
                    SlackChannelID = "C0123ABCDEF",
                    Speed = BetaAnalyticsUsageBucketedResultSpeed.Fast,
                    UncachedInputTokens = 0,
                },
            ],
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedEndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<BetaAnalyticsUsageBucketedResult> expectedResults =
        [
            new()
            {
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                ClaudeTagUserID = "U0123ABCDEF",
                ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                InferenceGeo = BetaAnalyticsUsageBucketedResultInferenceGeo.Global,
                Model = "claude-opus-5",
                OutputTokens = 0,
                Product = "chat",
                RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                Requests = 0,
                ServerToolUse = new(10),
                SlackChannelID = "C0123ABCDEF",
                Speed = BetaAnalyticsUsageBucketedResultSpeed.Fast,
                UncachedInputTokens = 0,
            },
        ];
        DateTimeOffset expectedStartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEndingAt, model.EndingAt);
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
        Assert.Equal(expectedStartingAt, model.StartingAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsUsageReportTimeBucket
        {
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Results =
            [
                new()
                {
                    CacheCreation = new()
                    {
                        Ephemeral1hInputTokens = 0,
                        Ephemeral5mInputTokens = 0,
                    },
                    CacheReadInputTokens = 0,
                    ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                    ClaudeTagUserID = "U0123ABCDEF",
                    ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                    InferenceGeo = BetaAnalyticsUsageBucketedResultInferenceGeo.Global,
                    Model = "claude-opus-5",
                    OutputTokens = 0,
                    Product = "chat",
                    RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                    Requests = 0,
                    ServerToolUse = new(10),
                    SlackChannelID = "C0123ABCDEF",
                    Speed = BetaAnalyticsUsageBucketedResultSpeed.Fast,
                    UncachedInputTokens = 0,
                },
            ],
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsUsageReportTimeBucket>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsUsageReportTimeBucket
        {
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Results =
            [
                new()
                {
                    CacheCreation = new()
                    {
                        Ephemeral1hInputTokens = 0,
                        Ephemeral5mInputTokens = 0,
                    },
                    CacheReadInputTokens = 0,
                    ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                    ClaudeTagUserID = "U0123ABCDEF",
                    ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                    InferenceGeo = BetaAnalyticsUsageBucketedResultInferenceGeo.Global,
                    Model = "claude-opus-5",
                    OutputTokens = 0,
                    Product = "chat",
                    RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                    Requests = 0,
                    ServerToolUse = new(10),
                    SlackChannelID = "C0123ABCDEF",
                    Speed = BetaAnalyticsUsageBucketedResultSpeed.Fast,
                    UncachedInputTokens = 0,
                },
            ],
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsUsageReportTimeBucket>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedEndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<BetaAnalyticsUsageBucketedResult> expectedResults =
        [
            new()
            {
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 0,
                ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                ClaudeTagUserID = "U0123ABCDEF",
                ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                InferenceGeo = BetaAnalyticsUsageBucketedResultInferenceGeo.Global,
                Model = "claude-opus-5",
                OutputTokens = 0,
                Product = "chat",
                RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                Requests = 0,
                ServerToolUse = new(10),
                SlackChannelID = "C0123ABCDEF",
                Speed = BetaAnalyticsUsageBucketedResultSpeed.Fast,
                UncachedInputTokens = 0,
            },
        ];
        DateTimeOffset expectedStartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEndingAt, deserialized.EndingAt);
        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
        Assert.Equal(expectedStartingAt, deserialized.StartingAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsUsageReportTimeBucket
        {
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Results =
            [
                new()
                {
                    CacheCreation = new()
                    {
                        Ephemeral1hInputTokens = 0,
                        Ephemeral5mInputTokens = 0,
                    },
                    CacheReadInputTokens = 0,
                    ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                    ClaudeTagUserID = "U0123ABCDEF",
                    ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                    InferenceGeo = BetaAnalyticsUsageBucketedResultInferenceGeo.Global,
                    Model = "claude-opus-5",
                    OutputTokens = 0,
                    Product = "chat",
                    RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                    Requests = 0,
                    ServerToolUse = new(10),
                    SlackChannelID = "C0123ABCDEF",
                    Speed = BetaAnalyticsUsageBucketedResultSpeed.Fast,
                    UncachedInputTokens = 0,
                },
            ],
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsUsageReportTimeBucket
        {
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Results =
            [
                new()
                {
                    CacheCreation = new()
                    {
                        Ephemeral1hInputTokens = 0,
                        Ephemeral5mInputTokens = 0,
                    },
                    CacheReadInputTokens = 0,
                    ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                    ClaudeTagUserID = "U0123ABCDEF",
                    ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                    InferenceGeo = BetaAnalyticsUsageBucketedResultInferenceGeo.Global,
                    Model = "claude-opus-5",
                    OutputTokens = 0,
                    Product = "chat",
                    RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                    Requests = 0,
                    ServerToolUse = new(10),
                    SlackChannelID = "C0123ABCDEF",
                    Speed = BetaAnalyticsUsageBucketedResultSpeed.Fast,
                    UncachedInputTokens = 0,
                },
            ],
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaAnalyticsUsageReportTimeBucket copied = new(model);

        Assert.Equal(model, copied);
    }
}
