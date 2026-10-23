using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;
using Anthropic.Models.Beta.Organization.Analytics.Usage;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Usage;

public class BetaAnalyticsUsageItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsUsageItem
        {
            EndingAt = DateTimeOffset.Parse("2026-10-01T00:00:00Z"),
            Group = new()
            {
                Actor = new BetaAnalyticsReportUserActor()
                {
                    Deleted = false,
                    EmailAddress = "user@emaildomain.com",
                    Name = "Jane Doe",
                    UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                },
                ActorType = BetaAnalyticsActorType.UserActor,
                AgentID = "agent_01VHd3EAGJ6PLkP9LM7DDu3f",
                ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                ClaudeTagUserID = "U0123ABCDEF",
                ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                DeploymentID = "depl_01JFC6ihzZHtAuyHsaENdJhY",
                EnvironmentID = "env_017oTjuGedHtjhJauVC5xGJD",
                InferenceGeo = BetaAnalyticsUsageCostInferenceGeo.Global,
                Model = "claude-opus-5-5",
                Product = "chat",
                RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                ServiceTier = BetaAnalyticsServiceTier.Standard,
                SessionID = "sesn_0187kPDyNCwibNNvfaPEApCJ",
                SlackChannelID = "C0123ABCDEF",
                Speed = BetaAnalyticsSpeed.Fast,
                UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
                WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            },
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
            Usage = new()
            {
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 3200000,
                OutputTokens = 891000,
                Requests = 128,
                ServerToolUse = new(10),
                TotalTokens = 5375500,
                UncachedInputTokens = 1284500,
            },
        };

        DateTimeOffset expectedEndingAt = DateTimeOffset.Parse("2026-10-01T00:00:00Z");
        BetaAnalyticsUsageGroup expectedGroup = new()
        {
            Actor = new BetaAnalyticsReportUserActor()
            {
                Deleted = false,
                EmailAddress = "user@emaildomain.com",
                Name = "Jane Doe",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            ActorType = BetaAnalyticsActorType.UserActor,
            AgentID = "agent_01VHd3EAGJ6PLkP9LM7DDu3f",
            ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
            ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
            ClaudeTagUserID = "U0123ABCDEF",
            ContextWindow = BetaAnalyticsContextWindow.From0To200k,
            DeploymentID = "depl_01JFC6ihzZHtAuyHsaENdJhY",
            EnvironmentID = "env_017oTjuGedHtjhJauVC5xGJD",
            InferenceGeo = BetaAnalyticsUsageCostInferenceGeo.Global,
            Model = "claude-opus-5-5",
            Product = "chat",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            ServiceTier = BetaAnalyticsServiceTier.Standard,
            SessionID = "sesn_0187kPDyNCwibNNvfaPEApCJ",
            SlackChannelID = "C0123ABCDEF",
            Speed = BetaAnalyticsSpeed.Fast,
            UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
        };
        DateTimeOffset expectedStartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z");
        BetaAnalyticsUsageMetrics expectedUsage = new()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 3200000,
            OutputTokens = 891000,
            Requests = 128,
            ServerToolUse = new(10),
            TotalTokens = 5375500,
            UncachedInputTokens = 1284500,
        };

        Assert.Equal(expectedEndingAt, model.EndingAt);
        Assert.Equal(expectedGroup, model.Group);
        Assert.Equal(expectedStartingAt, model.StartingAt);
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsUsageItem
        {
            EndingAt = DateTimeOffset.Parse("2026-10-01T00:00:00Z"),
            Group = new()
            {
                Actor = new BetaAnalyticsReportUserActor()
                {
                    Deleted = false,
                    EmailAddress = "user@emaildomain.com",
                    Name = "Jane Doe",
                    UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                },
                ActorType = BetaAnalyticsActorType.UserActor,
                AgentID = "agent_01VHd3EAGJ6PLkP9LM7DDu3f",
                ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                ClaudeTagUserID = "U0123ABCDEF",
                ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                DeploymentID = "depl_01JFC6ihzZHtAuyHsaENdJhY",
                EnvironmentID = "env_017oTjuGedHtjhJauVC5xGJD",
                InferenceGeo = BetaAnalyticsUsageCostInferenceGeo.Global,
                Model = "claude-opus-5-5",
                Product = "chat",
                RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                ServiceTier = BetaAnalyticsServiceTier.Standard,
                SessionID = "sesn_0187kPDyNCwibNNvfaPEApCJ",
                SlackChannelID = "C0123ABCDEF",
                Speed = BetaAnalyticsSpeed.Fast,
                UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
                WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            },
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
            Usage = new()
            {
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 3200000,
                OutputTokens = 891000,
                Requests = 128,
                ServerToolUse = new(10),
                TotalTokens = 5375500,
                UncachedInputTokens = 1284500,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsUsageItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsUsageItem
        {
            EndingAt = DateTimeOffset.Parse("2026-10-01T00:00:00Z"),
            Group = new()
            {
                Actor = new BetaAnalyticsReportUserActor()
                {
                    Deleted = false,
                    EmailAddress = "user@emaildomain.com",
                    Name = "Jane Doe",
                    UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                },
                ActorType = BetaAnalyticsActorType.UserActor,
                AgentID = "agent_01VHd3EAGJ6PLkP9LM7DDu3f",
                ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                ClaudeTagUserID = "U0123ABCDEF",
                ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                DeploymentID = "depl_01JFC6ihzZHtAuyHsaENdJhY",
                EnvironmentID = "env_017oTjuGedHtjhJauVC5xGJD",
                InferenceGeo = BetaAnalyticsUsageCostInferenceGeo.Global,
                Model = "claude-opus-5-5",
                Product = "chat",
                RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                ServiceTier = BetaAnalyticsServiceTier.Standard,
                SessionID = "sesn_0187kPDyNCwibNNvfaPEApCJ",
                SlackChannelID = "C0123ABCDEF",
                Speed = BetaAnalyticsSpeed.Fast,
                UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
                WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            },
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
            Usage = new()
            {
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 3200000,
                OutputTokens = 891000,
                Requests = 128,
                ServerToolUse = new(10),
                TotalTokens = 5375500,
                UncachedInputTokens = 1284500,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsUsageItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedEndingAt = DateTimeOffset.Parse("2026-10-01T00:00:00Z");
        BetaAnalyticsUsageGroup expectedGroup = new()
        {
            Actor = new BetaAnalyticsReportUserActor()
            {
                Deleted = false,
                EmailAddress = "user@emaildomain.com",
                Name = "Jane Doe",
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            },
            ActorType = BetaAnalyticsActorType.UserActor,
            AgentID = "agent_01VHd3EAGJ6PLkP9LM7DDu3f",
            ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
            ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
            ClaudeTagUserID = "U0123ABCDEF",
            ContextWindow = BetaAnalyticsContextWindow.From0To200k,
            DeploymentID = "depl_01JFC6ihzZHtAuyHsaENdJhY",
            EnvironmentID = "env_017oTjuGedHtjhJauVC5xGJD",
            InferenceGeo = BetaAnalyticsUsageCostInferenceGeo.Global,
            Model = "claude-opus-5-5",
            Product = "chat",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            ServiceTier = BetaAnalyticsServiceTier.Standard,
            SessionID = "sesn_0187kPDyNCwibNNvfaPEApCJ",
            SlackChannelID = "C0123ABCDEF",
            Speed = BetaAnalyticsSpeed.Fast,
            UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
        };
        DateTimeOffset expectedStartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z");
        BetaAnalyticsUsageMetrics expectedUsage = new()
        {
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 3200000,
            OutputTokens = 891000,
            Requests = 128,
            ServerToolUse = new(10),
            TotalTokens = 5375500,
            UncachedInputTokens = 1284500,
        };

        Assert.Equal(expectedEndingAt, deserialized.EndingAt);
        Assert.Equal(expectedGroup, deserialized.Group);
        Assert.Equal(expectedStartingAt, deserialized.StartingAt);
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsUsageItem
        {
            EndingAt = DateTimeOffset.Parse("2026-10-01T00:00:00Z"),
            Group = new()
            {
                Actor = new BetaAnalyticsReportUserActor()
                {
                    Deleted = false,
                    EmailAddress = "user@emaildomain.com",
                    Name = "Jane Doe",
                    UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                },
                ActorType = BetaAnalyticsActorType.UserActor,
                AgentID = "agent_01VHd3EAGJ6PLkP9LM7DDu3f",
                ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                ClaudeTagUserID = "U0123ABCDEF",
                ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                DeploymentID = "depl_01JFC6ihzZHtAuyHsaENdJhY",
                EnvironmentID = "env_017oTjuGedHtjhJauVC5xGJD",
                InferenceGeo = BetaAnalyticsUsageCostInferenceGeo.Global,
                Model = "claude-opus-5-5",
                Product = "chat",
                RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                ServiceTier = BetaAnalyticsServiceTier.Standard,
                SessionID = "sesn_0187kPDyNCwibNNvfaPEApCJ",
                SlackChannelID = "C0123ABCDEF",
                Speed = BetaAnalyticsSpeed.Fast,
                UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
                WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            },
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
            Usage = new()
            {
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 3200000,
                OutputTokens = 891000,
                Requests = 128,
                ServerToolUse = new(10),
                TotalTokens = 5375500,
                UncachedInputTokens = 1284500,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsUsageItem
        {
            EndingAt = DateTimeOffset.Parse("2026-10-01T00:00:00Z"),
            Group = new()
            {
                Actor = new BetaAnalyticsReportUserActor()
                {
                    Deleted = false,
                    EmailAddress = "user@emaildomain.com",
                    Name = "Jane Doe",
                    UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                },
                ActorType = BetaAnalyticsActorType.UserActor,
                AgentID = "agent_01VHd3EAGJ6PLkP9LM7DDu3f",
                ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                ClaudeTagUserID = "U0123ABCDEF",
                ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                DeploymentID = "depl_01JFC6ihzZHtAuyHsaENdJhY",
                EnvironmentID = "env_017oTjuGedHtjhJauVC5xGJD",
                InferenceGeo = BetaAnalyticsUsageCostInferenceGeo.Global,
                Model = "claude-opus-5-5",
                Product = "chat",
                RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                ServiceTier = BetaAnalyticsServiceTier.Standard,
                SessionID = "sesn_0187kPDyNCwibNNvfaPEApCJ",
                SlackChannelID = "C0123ABCDEF",
                Speed = BetaAnalyticsSpeed.Fast,
                UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
                WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            },
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
            Usage = new()
            {
                CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
                CacheReadInputTokens = 3200000,
                OutputTokens = 891000,
                Requests = 128,
                ServerToolUse = new(10),
                TotalTokens = 5375500,
                UncachedInputTokens = 1284500,
            },
        };

        BetaAnalyticsUsageItem copied = new(model);

        Assert.Equal(model, copied);
    }
}
