using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;
using Anthropic.Models.Beta.Organization.Analytics.Cost;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Cost;

public class BetaAnalyticsCostItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsCostItem
        {
            Cost = new()
            {
                Amount = "41280.000000",
                Currency = "USD",
                ListAmount = "51600.000000",
                Requests = 128,
            },
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
                CostType = BetaAnalyticsGroupedCostType.Tokens,
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
                TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
                WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            },
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
        };

        BetaAnalyticsCostMetrics expectedCost = new()
        {
            Amount = "41280.000000",
            Currency = "USD",
            ListAmount = "51600.000000",
            Requests = 128,
        };
        DateTimeOffset expectedEndingAt = DateTimeOffset.Parse("2026-10-01T00:00:00Z");
        BetaAnalyticsCostGroup expectedGroup = new()
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
            CostType = BetaAnalyticsGroupedCostType.Tokens,
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
            TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
            UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
        };
        DateTimeOffset expectedStartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z");

        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedEndingAt, model.EndingAt);
        Assert.Equal(expectedGroup, model.Group);
        Assert.Equal(expectedStartingAt, model.StartingAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsCostItem
        {
            Cost = new()
            {
                Amount = "41280.000000",
                Currency = "USD",
                ListAmount = "51600.000000",
                Requests = 128,
            },
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
                CostType = BetaAnalyticsGroupedCostType.Tokens,
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
                TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
                WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            },
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsCostItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsCostItem
        {
            Cost = new()
            {
                Amount = "41280.000000",
                Currency = "USD",
                ListAmount = "51600.000000",
                Requests = 128,
            },
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
                CostType = BetaAnalyticsGroupedCostType.Tokens,
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
                TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
                WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            },
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsCostItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaAnalyticsCostMetrics expectedCost = new()
        {
            Amount = "41280.000000",
            Currency = "USD",
            ListAmount = "51600.000000",
            Requests = 128,
        };
        DateTimeOffset expectedEndingAt = DateTimeOffset.Parse("2026-10-01T00:00:00Z");
        BetaAnalyticsCostGroup expectedGroup = new()
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
            CostType = BetaAnalyticsGroupedCostType.Tokens,
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
            TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
            UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
        };
        DateTimeOffset expectedStartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z");

        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedEndingAt, deserialized.EndingAt);
        Assert.Equal(expectedGroup, deserialized.Group);
        Assert.Equal(expectedStartingAt, deserialized.StartingAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsCostItem
        {
            Cost = new()
            {
                Amount = "41280.000000",
                Currency = "USD",
                ListAmount = "51600.000000",
                Requests = 128,
            },
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
                CostType = BetaAnalyticsGroupedCostType.Tokens,
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
                TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
                WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            },
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsCostItem
        {
            Cost = new()
            {
                Amount = "41280.000000",
                Currency = "USD",
                ListAmount = "51600.000000",
                Requests = 128,
            },
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
                CostType = BetaAnalyticsGroupedCostType.Tokens,
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
                TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
                WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            },
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
        };

        BetaAnalyticsCostItem copied = new(model);

        Assert.Equal(model, copied);
    }
}
