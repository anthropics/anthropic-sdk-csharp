using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization.Analytics;
using Anthropic.Models.Beta.Organization.Analytics.Usage;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Usage;

public class UsageListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UsageListParams
        {
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
            ActorIds = ["user_01WCz1FkmYMm4gnmykNKUu3Q"],
            ActorTypes = [BetaAnalyticsActorType.ServiceAccountActor],
            AgentIds = ["agent_01VHd3EAGJ6PLkP9LM7DDu3f"],
            ApiKeyIds = ["apikey_01Rj2N8SVvo6BePZj99NhmiT"],
            ClaudeTagCategories = [BetaAnalyticsClaudeTagCategory.Engaged],
            ClaudeTagUserIds = ["U0123ABCDEF"],
            ContextWindows = [BetaAnalyticsContextWindow.From0To200k],
            DeploymentIds = ["depl_01JFC6ihzZHtAuyHsaENdJhY"],
            EndingAt = DateTimeOffset.Parse("2026-10-01T00:00:00Z"),
            EnvironmentIds = ["env_017oTjuGedHtjhJauVC5xGJD"],
            ExcludeDeletedUsers = true,
            GroupBy = [BetaAnalyticsUsageGroupBy.Actor],
            InferenceGeos = [BetaAnalyticsInferenceGeoFilter.Global],
            Limit = 1,
            Models = ["string"],
            Order = BetaAnalyticsUsageCostSortOrder.Asc,
            OrderBy = BetaAnalyticsUsageOrderBy.OutputTokens,
            Page = "page",
            Products = [BetaAnalyticsUsageCostProductFilter.Chat],
            RbacGroupIds = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"],
            ServiceTiers = [BetaAnalyticsServiceTier.Batch],
            SessionIds = ["sesn_0187kPDyNCwibNNvfaPEApCJ"],
            SlackChannelIds = ["C0123ABCDEF"],
            Speeds = [BetaAnalyticsSpeed.Fast],
            TimeBucketWidth = BetaAnalyticsTimeBucketWidth.Day,
            UserProfileIds = ["uprof_01M33NeYUQK2WV9PpYcsPHLi"],
            WorkspaceIds = ["wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        DateTimeOffset expectedStartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z");
        List<string> expectedActorIds = ["user_01WCz1FkmYMm4gnmykNKUu3Q"];
        List<ApiEnum<string, BetaAnalyticsActorType>> expectedActorTypes =
        [
            BetaAnalyticsActorType.ServiceAccountActor,
        ];
        List<string> expectedAgentIds = ["agent_01VHd3EAGJ6PLkP9LM7DDu3f"];
        List<string> expectedApiKeyIds = ["apikey_01Rj2N8SVvo6BePZj99NhmiT"];
        List<ApiEnum<string, BetaAnalyticsClaudeTagCategory>> expectedClaudeTagCategories =
        [
            BetaAnalyticsClaudeTagCategory.Engaged,
        ];
        List<string> expectedClaudeTagUserIds = ["U0123ABCDEF"];
        List<ApiEnum<string, BetaAnalyticsContextWindow>> expectedContextWindows =
        [
            BetaAnalyticsContextWindow.From0To200k,
        ];
        List<string> expectedDeploymentIds = ["depl_01JFC6ihzZHtAuyHsaENdJhY"];
        DateTimeOffset expectedEndingAt = DateTimeOffset.Parse("2026-10-01T00:00:00Z");
        List<string> expectedEnvironmentIds = ["env_017oTjuGedHtjhJauVC5xGJD"];
        bool expectedExcludeDeletedUsers = true;
        List<ApiEnum<string, BetaAnalyticsUsageGroupBy>> expectedGroupBy =
        [
            BetaAnalyticsUsageGroupBy.Actor,
        ];
        List<ApiEnum<string, BetaAnalyticsInferenceGeoFilter>> expectedInferenceGeos =
        [
            BetaAnalyticsInferenceGeoFilter.Global,
        ];
        long expectedLimit = 1;
        List<string> expectedModels = ["string"];
        ApiEnum<string, BetaAnalyticsUsageCostSortOrder> expectedOrder =
            BetaAnalyticsUsageCostSortOrder.Asc;
        ApiEnum<string, BetaAnalyticsUsageOrderBy> expectedOrderBy =
            BetaAnalyticsUsageOrderBy.OutputTokens;
        string expectedPage = "page";
        List<ApiEnum<string, BetaAnalyticsUsageCostProductFilter>> expectedProducts =
        [
            BetaAnalyticsUsageCostProductFilter.Chat,
        ];
        List<string> expectedRbacGroupIds = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"];
        List<ApiEnum<string, BetaAnalyticsServiceTier>> expectedServiceTiers =
        [
            BetaAnalyticsServiceTier.Batch,
        ];
        List<string> expectedSessionIds = ["sesn_0187kPDyNCwibNNvfaPEApCJ"];
        List<string> expectedSlackChannelIds = ["C0123ABCDEF"];
        List<ApiEnum<string, BetaAnalyticsSpeed>> expectedSpeeds = [BetaAnalyticsSpeed.Fast];
        ApiEnum<string, BetaAnalyticsTimeBucketWidth> expectedTimeBucketWidth =
            BetaAnalyticsTimeBucketWidth.Day;
        List<string> expectedUserProfileIds = ["uprof_01M33NeYUQK2WV9PpYcsPHLi"];
        List<string> expectedWorkspaceIds = ["wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedStartingAt, parameters.StartingAt);
        Assert.NotNull(parameters.ActorIds);
        Assert.Equal(expectedActorIds.Count, parameters.ActorIds.Count);
        for (int i = 0; i < expectedActorIds.Count; i++)
        {
            Assert.Equal(expectedActorIds[i], parameters.ActorIds[i]);
        }
        Assert.NotNull(parameters.ActorTypes);
        Assert.Equal(expectedActorTypes.Count, parameters.ActorTypes.Count);
        for (int i = 0; i < expectedActorTypes.Count; i++)
        {
            Assert.Equal(expectedActorTypes[i], parameters.ActorTypes[i]);
        }
        Assert.NotNull(parameters.AgentIds);
        Assert.Equal(expectedAgentIds.Count, parameters.AgentIds.Count);
        for (int i = 0; i < expectedAgentIds.Count; i++)
        {
            Assert.Equal(expectedAgentIds[i], parameters.AgentIds[i]);
        }
        Assert.NotNull(parameters.ApiKeyIds);
        Assert.Equal(expectedApiKeyIds.Count, parameters.ApiKeyIds.Count);
        for (int i = 0; i < expectedApiKeyIds.Count; i++)
        {
            Assert.Equal(expectedApiKeyIds[i], parameters.ApiKeyIds[i]);
        }
        Assert.NotNull(parameters.ClaudeTagCategories);
        Assert.Equal(expectedClaudeTagCategories.Count, parameters.ClaudeTagCategories.Count);
        for (int i = 0; i < expectedClaudeTagCategories.Count; i++)
        {
            Assert.Equal(expectedClaudeTagCategories[i], parameters.ClaudeTagCategories[i]);
        }
        Assert.NotNull(parameters.ClaudeTagUserIds);
        Assert.Equal(expectedClaudeTagUserIds.Count, parameters.ClaudeTagUserIds.Count);
        for (int i = 0; i < expectedClaudeTagUserIds.Count; i++)
        {
            Assert.Equal(expectedClaudeTagUserIds[i], parameters.ClaudeTagUserIds[i]);
        }
        Assert.NotNull(parameters.ContextWindows);
        Assert.Equal(expectedContextWindows.Count, parameters.ContextWindows.Count);
        for (int i = 0; i < expectedContextWindows.Count; i++)
        {
            Assert.Equal(expectedContextWindows[i], parameters.ContextWindows[i]);
        }
        Assert.NotNull(parameters.DeploymentIds);
        Assert.Equal(expectedDeploymentIds.Count, parameters.DeploymentIds.Count);
        for (int i = 0; i < expectedDeploymentIds.Count; i++)
        {
            Assert.Equal(expectedDeploymentIds[i], parameters.DeploymentIds[i]);
        }
        Assert.Equal(expectedEndingAt, parameters.EndingAt);
        Assert.NotNull(parameters.EnvironmentIds);
        Assert.Equal(expectedEnvironmentIds.Count, parameters.EnvironmentIds.Count);
        for (int i = 0; i < expectedEnvironmentIds.Count; i++)
        {
            Assert.Equal(expectedEnvironmentIds[i], parameters.EnvironmentIds[i]);
        }
        Assert.Equal(expectedExcludeDeletedUsers, parameters.ExcludeDeletedUsers);
        Assert.NotNull(parameters.GroupBy);
        Assert.Equal(expectedGroupBy.Count, parameters.GroupBy.Count);
        for (int i = 0; i < expectedGroupBy.Count; i++)
        {
            Assert.Equal(expectedGroupBy[i], parameters.GroupBy[i]);
        }
        Assert.NotNull(parameters.InferenceGeos);
        Assert.Equal(expectedInferenceGeos.Count, parameters.InferenceGeos.Count);
        for (int i = 0; i < expectedInferenceGeos.Count; i++)
        {
            Assert.Equal(expectedInferenceGeos[i], parameters.InferenceGeos[i]);
        }
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.NotNull(parameters.Models);
        Assert.Equal(expectedModels.Count, parameters.Models.Count);
        for (int i = 0; i < expectedModels.Count; i++)
        {
            Assert.Equal(expectedModels[i], parameters.Models[i]);
        }
        Assert.Equal(expectedOrder, parameters.Order);
        Assert.Equal(expectedOrderBy, parameters.OrderBy);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.NotNull(parameters.Products);
        Assert.Equal(expectedProducts.Count, parameters.Products.Count);
        for (int i = 0; i < expectedProducts.Count; i++)
        {
            Assert.Equal(expectedProducts[i], parameters.Products[i]);
        }
        Assert.NotNull(parameters.RbacGroupIds);
        Assert.Equal(expectedRbacGroupIds.Count, parameters.RbacGroupIds.Count);
        for (int i = 0; i < expectedRbacGroupIds.Count; i++)
        {
            Assert.Equal(expectedRbacGroupIds[i], parameters.RbacGroupIds[i]);
        }
        Assert.NotNull(parameters.ServiceTiers);
        Assert.Equal(expectedServiceTiers.Count, parameters.ServiceTiers.Count);
        for (int i = 0; i < expectedServiceTiers.Count; i++)
        {
            Assert.Equal(expectedServiceTiers[i], parameters.ServiceTiers[i]);
        }
        Assert.NotNull(parameters.SessionIds);
        Assert.Equal(expectedSessionIds.Count, parameters.SessionIds.Count);
        for (int i = 0; i < expectedSessionIds.Count; i++)
        {
            Assert.Equal(expectedSessionIds[i], parameters.SessionIds[i]);
        }
        Assert.NotNull(parameters.SlackChannelIds);
        Assert.Equal(expectedSlackChannelIds.Count, parameters.SlackChannelIds.Count);
        for (int i = 0; i < expectedSlackChannelIds.Count; i++)
        {
            Assert.Equal(expectedSlackChannelIds[i], parameters.SlackChannelIds[i]);
        }
        Assert.NotNull(parameters.Speeds);
        Assert.Equal(expectedSpeeds.Count, parameters.Speeds.Count);
        for (int i = 0; i < expectedSpeeds.Count; i++)
        {
            Assert.Equal(expectedSpeeds[i], parameters.Speeds[i]);
        }
        Assert.Equal(expectedTimeBucketWidth, parameters.TimeBucketWidth);
        Assert.NotNull(parameters.UserProfileIds);
        Assert.Equal(expectedUserProfileIds.Count, parameters.UserProfileIds.Count);
        for (int i = 0; i < expectedUserProfileIds.Count; i++)
        {
            Assert.Equal(expectedUserProfileIds[i], parameters.UserProfileIds[i]);
        }
        Assert.NotNull(parameters.WorkspaceIds);
        Assert.Equal(expectedWorkspaceIds.Count, parameters.WorkspaceIds.Count);
        for (int i = 0; i < expectedWorkspaceIds.Count; i++)
        {
            Assert.Equal(expectedWorkspaceIds[i], parameters.WorkspaceIds[i]);
        }
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UsageListParams
        {
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
            ActorIds = ["user_01WCz1FkmYMm4gnmykNKUu3Q"],
            ActorTypes = [BetaAnalyticsActorType.ServiceAccountActor],
            AgentIds = ["agent_01VHd3EAGJ6PLkP9LM7DDu3f"],
            ApiKeyIds = ["apikey_01Rj2N8SVvo6BePZj99NhmiT"],
            ClaudeTagCategories = [BetaAnalyticsClaudeTagCategory.Engaged],
            ClaudeTagUserIds = ["U0123ABCDEF"],
            ContextWindows = [BetaAnalyticsContextWindow.From0To200k],
            DeploymentIds = ["depl_01JFC6ihzZHtAuyHsaENdJhY"],
            EndingAt = DateTimeOffset.Parse("2026-10-01T00:00:00Z"),
            EnvironmentIds = ["env_017oTjuGedHtjhJauVC5xGJD"],
            GroupBy = [BetaAnalyticsUsageGroupBy.Actor],
            InferenceGeos = [BetaAnalyticsInferenceGeoFilter.Global],
            Models = ["string"],
            Page = "page",
            Products = [BetaAnalyticsUsageCostProductFilter.Chat],
            RbacGroupIds = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"],
            ServiceTiers = [BetaAnalyticsServiceTier.Batch],
            SessionIds = ["sesn_0187kPDyNCwibNNvfaPEApCJ"],
            SlackChannelIds = ["C0123ABCDEF"],
            Speeds = [BetaAnalyticsSpeed.Fast],
            TimeBucketWidth = BetaAnalyticsTimeBucketWidth.Day,
            UserProfileIds = ["uprof_01M33NeYUQK2WV9PpYcsPHLi"],
            WorkspaceIds = ["wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"],
        };

        Assert.Null(parameters.ExcludeDeletedUsers);
        Assert.False(parameters.RawQueryData.ContainsKey("exclude_deleted_users"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawQueryData.ContainsKey("order"));
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("order_by"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UsageListParams
        {
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
            ActorIds = ["user_01WCz1FkmYMm4gnmykNKUu3Q"],
            ActorTypes = [BetaAnalyticsActorType.ServiceAccountActor],
            AgentIds = ["agent_01VHd3EAGJ6PLkP9LM7DDu3f"],
            ApiKeyIds = ["apikey_01Rj2N8SVvo6BePZj99NhmiT"],
            ClaudeTagCategories = [BetaAnalyticsClaudeTagCategory.Engaged],
            ClaudeTagUserIds = ["U0123ABCDEF"],
            ContextWindows = [BetaAnalyticsContextWindow.From0To200k],
            DeploymentIds = ["depl_01JFC6ihzZHtAuyHsaENdJhY"],
            EndingAt = DateTimeOffset.Parse("2026-10-01T00:00:00Z"),
            EnvironmentIds = ["env_017oTjuGedHtjhJauVC5xGJD"],
            GroupBy = [BetaAnalyticsUsageGroupBy.Actor],
            InferenceGeos = [BetaAnalyticsInferenceGeoFilter.Global],
            Models = ["string"],
            Page = "page",
            Products = [BetaAnalyticsUsageCostProductFilter.Chat],
            RbacGroupIds = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"],
            ServiceTiers = [BetaAnalyticsServiceTier.Batch],
            SessionIds = ["sesn_0187kPDyNCwibNNvfaPEApCJ"],
            SlackChannelIds = ["C0123ABCDEF"],
            Speeds = [BetaAnalyticsSpeed.Fast],
            TimeBucketWidth = BetaAnalyticsTimeBucketWidth.Day,
            UserProfileIds = ["uprof_01M33NeYUQK2WV9PpYcsPHLi"],
            WorkspaceIds = ["wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"],

            // Null should be interpreted as omitted for these properties
            ExcludeDeletedUsers = null,
            Limit = null,
            Order = null,
            OrderBy = null,
            Betas = null,
        };

        Assert.Null(parameters.ExcludeDeletedUsers);
        Assert.False(parameters.RawQueryData.ContainsKey("exclude_deleted_users"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawQueryData.ContainsKey("order"));
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("order_by"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new UsageListParams
        {
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
            ActorIds = ["user_01WCz1FkmYMm4gnmykNKUu3Q"],
            ActorTypes = [BetaAnalyticsActorType.ServiceAccountActor],
            AgentIds = ["agent_01VHd3EAGJ6PLkP9LM7DDu3f"],
            ApiKeyIds = ["apikey_01Rj2N8SVvo6BePZj99NhmiT"],
            ClaudeTagCategories = [BetaAnalyticsClaudeTagCategory.Engaged],
            ClaudeTagUserIds = ["U0123ABCDEF"],
            ContextWindows = [BetaAnalyticsContextWindow.From0To200k],
            DeploymentIds = ["depl_01JFC6ihzZHtAuyHsaENdJhY"],
            EndingAt = DateTimeOffset.Parse("2026-10-01T00:00:00Z"),
            EnvironmentIds = ["env_017oTjuGedHtjhJauVC5xGJD"],
            ExcludeDeletedUsers = true,
            GroupBy = [BetaAnalyticsUsageGroupBy.Actor],
            InferenceGeos = [BetaAnalyticsInferenceGeoFilter.Global],
            Limit = 1,
            Models = ["string"],
            Order = BetaAnalyticsUsageCostSortOrder.Asc,
            OrderBy = BetaAnalyticsUsageOrderBy.OutputTokens,
            Page = "page",
            Products = [BetaAnalyticsUsageCostProductFilter.Chat],
            RbacGroupIds = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"],
            ServiceTiers = [BetaAnalyticsServiceTier.Batch],
            SessionIds = ["sesn_0187kPDyNCwibNNvfaPEApCJ"],
            SlackChannelIds = ["C0123ABCDEF"],
            Speeds = [BetaAnalyticsSpeed.Fast],
            TimeBucketWidth = BetaAnalyticsTimeBucketWidth.Day,
            UserProfileIds = ["uprof_01M33NeYUQK2WV9PpYcsPHLi"],
            WorkspaceIds = ["wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        } with
        {
            // Null should be interpreted as omitted for these properties
            ExcludeDeletedUsers = null,
            Limit = null,
            Order = null,
            OrderBy = null,
            Betas = null,
        };

        Assert.Null(parameters.ExcludeDeletedUsers);
        Assert.False(parameters.RawQueryData.ContainsKey("exclude_deleted_users"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawQueryData.ContainsKey("order"));
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("order_by"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UsageListParams
        {
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
            ExcludeDeletedUsers = true,
            Limit = 1,
            Order = BetaAnalyticsUsageCostSortOrder.Asc,
            OrderBy = BetaAnalyticsUsageOrderBy.OutputTokens,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.ActorIds);
        Assert.False(parameters.RawQueryData.ContainsKey("actor_ids"));
        Assert.Null(parameters.ActorTypes);
        Assert.False(parameters.RawQueryData.ContainsKey("actor_types"));
        Assert.Null(parameters.AgentIds);
        Assert.False(parameters.RawQueryData.ContainsKey("agent_ids"));
        Assert.Null(parameters.ApiKeyIds);
        Assert.False(parameters.RawQueryData.ContainsKey("api_key_ids"));
        Assert.Null(parameters.ClaudeTagCategories);
        Assert.False(parameters.RawQueryData.ContainsKey("claude_tag_categories"));
        Assert.Null(parameters.ClaudeTagUserIds);
        Assert.False(parameters.RawQueryData.ContainsKey("claude_tag_user_ids"));
        Assert.Null(parameters.ContextWindows);
        Assert.False(parameters.RawQueryData.ContainsKey("context_windows"));
        Assert.Null(parameters.DeploymentIds);
        Assert.False(parameters.RawQueryData.ContainsKey("deployment_ids"));
        Assert.Null(parameters.EndingAt);
        Assert.False(parameters.RawQueryData.ContainsKey("ending_at"));
        Assert.Null(parameters.EnvironmentIds);
        Assert.False(parameters.RawQueryData.ContainsKey("environment_ids"));
        Assert.Null(parameters.GroupBy);
        Assert.False(parameters.RawQueryData.ContainsKey("group_by"));
        Assert.Null(parameters.InferenceGeos);
        Assert.False(parameters.RawQueryData.ContainsKey("inference_geos"));
        Assert.Null(parameters.Models);
        Assert.False(parameters.RawQueryData.ContainsKey("models"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Products);
        Assert.False(parameters.RawQueryData.ContainsKey("products"));
        Assert.Null(parameters.RbacGroupIds);
        Assert.False(parameters.RawQueryData.ContainsKey("rbac_group_ids"));
        Assert.Null(parameters.ServiceTiers);
        Assert.False(parameters.RawQueryData.ContainsKey("service_tiers"));
        Assert.Null(parameters.SessionIds);
        Assert.False(parameters.RawQueryData.ContainsKey("session_ids"));
        Assert.Null(parameters.SlackChannelIds);
        Assert.False(parameters.RawQueryData.ContainsKey("slack_channel_ids"));
        Assert.Null(parameters.Speeds);
        Assert.False(parameters.RawQueryData.ContainsKey("speeds"));
        Assert.Null(parameters.TimeBucketWidth);
        Assert.False(parameters.RawQueryData.ContainsKey("time_bucket_width"));
        Assert.Null(parameters.UserProfileIds);
        Assert.False(parameters.RawQueryData.ContainsKey("user_profile_ids"));
        Assert.Null(parameters.WorkspaceIds);
        Assert.False(parameters.RawQueryData.ContainsKey("workspace_ids"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new UsageListParams
        {
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
            ExcludeDeletedUsers = true,
            Limit = 1,
            Order = BetaAnalyticsUsageCostSortOrder.Asc,
            OrderBy = BetaAnalyticsUsageOrderBy.OutputTokens,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            ActorIds = null,
            ActorTypes = null,
            AgentIds = null,
            ApiKeyIds = null,
            ClaudeTagCategories = null,
            ClaudeTagUserIds = null,
            ContextWindows = null,
            DeploymentIds = null,
            EndingAt = null,
            EnvironmentIds = null,
            GroupBy = null,
            InferenceGeos = null,
            Models = null,
            Page = null,
            Products = null,
            RbacGroupIds = null,
            ServiceTiers = null,
            SessionIds = null,
            SlackChannelIds = null,
            Speeds = null,
            TimeBucketWidth = null,
            UserProfileIds = null,
            WorkspaceIds = null,
        };

        Assert.Null(parameters.ActorIds);
        Assert.True(parameters.RawQueryData.ContainsKey("actor_ids"));
        Assert.Null(parameters.ActorTypes);
        Assert.True(parameters.RawQueryData.ContainsKey("actor_types"));
        Assert.Null(parameters.AgentIds);
        Assert.True(parameters.RawQueryData.ContainsKey("agent_ids"));
        Assert.Null(parameters.ApiKeyIds);
        Assert.True(parameters.RawQueryData.ContainsKey("api_key_ids"));
        Assert.Null(parameters.ClaudeTagCategories);
        Assert.True(parameters.RawQueryData.ContainsKey("claude_tag_categories"));
        Assert.Null(parameters.ClaudeTagUserIds);
        Assert.True(parameters.RawQueryData.ContainsKey("claude_tag_user_ids"));
        Assert.Null(parameters.ContextWindows);
        Assert.True(parameters.RawQueryData.ContainsKey("context_windows"));
        Assert.Null(parameters.DeploymentIds);
        Assert.True(parameters.RawQueryData.ContainsKey("deployment_ids"));
        Assert.Null(parameters.EndingAt);
        Assert.True(parameters.RawQueryData.ContainsKey("ending_at"));
        Assert.Null(parameters.EnvironmentIds);
        Assert.True(parameters.RawQueryData.ContainsKey("environment_ids"));
        Assert.Null(parameters.GroupBy);
        Assert.True(parameters.RawQueryData.ContainsKey("group_by"));
        Assert.Null(parameters.InferenceGeos);
        Assert.True(parameters.RawQueryData.ContainsKey("inference_geos"));
        Assert.Null(parameters.Models);
        Assert.True(parameters.RawQueryData.ContainsKey("models"));
        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Products);
        Assert.True(parameters.RawQueryData.ContainsKey("products"));
        Assert.Null(parameters.RbacGroupIds);
        Assert.True(parameters.RawQueryData.ContainsKey("rbac_group_ids"));
        Assert.Null(parameters.ServiceTiers);
        Assert.True(parameters.RawQueryData.ContainsKey("service_tiers"));
        Assert.Null(parameters.SessionIds);
        Assert.True(parameters.RawQueryData.ContainsKey("session_ids"));
        Assert.Null(parameters.SlackChannelIds);
        Assert.True(parameters.RawQueryData.ContainsKey("slack_channel_ids"));
        Assert.Null(parameters.Speeds);
        Assert.True(parameters.RawQueryData.ContainsKey("speeds"));
        Assert.Null(parameters.TimeBucketWidth);
        Assert.True(parameters.RawQueryData.ContainsKey("time_bucket_width"));
        Assert.Null(parameters.UserProfileIds);
        Assert.True(parameters.RawQueryData.ContainsKey("user_profile_ids"));
        Assert.Null(parameters.WorkspaceIds);
        Assert.True(parameters.RawQueryData.ContainsKey("workspace_ids"));
    }

    [Fact]
    public void Url_Works()
    {
        UsageListParams parameters = new()
        {
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00+00:00"),
            ActorIds = ["user_01WCz1FkmYMm4gnmykNKUu3Q"],
            ActorTypes = [BetaAnalyticsActorType.ServiceAccountActor],
            AgentIds = ["agent_01VHd3EAGJ6PLkP9LM7DDu3f"],
            ApiKeyIds = ["apikey_01Rj2N8SVvo6BePZj99NhmiT"],
            ClaudeTagCategories = [BetaAnalyticsClaudeTagCategory.Engaged],
            ClaudeTagUserIds = ["U0123ABCDEF"],
            ContextWindows = [BetaAnalyticsContextWindow.From0To200k],
            DeploymentIds = ["depl_01JFC6ihzZHtAuyHsaENdJhY"],
            EndingAt = DateTimeOffset.Parse("2026-10-01T00:00:00+00:00"),
            EnvironmentIds = ["env_017oTjuGedHtjhJauVC5xGJD"],
            ExcludeDeletedUsers = true,
            GroupBy = [BetaAnalyticsUsageGroupBy.Actor],
            InferenceGeos = [BetaAnalyticsInferenceGeoFilter.Global],
            Limit = 1,
            Models = ["string"],
            Order = BetaAnalyticsUsageCostSortOrder.Asc,
            OrderBy = BetaAnalyticsUsageOrderBy.OutputTokens,
            Page = "page",
            Products = [BetaAnalyticsUsageCostProductFilter.Chat],
            RbacGroupIds = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"],
            ServiceTiers = [BetaAnalyticsServiceTier.Batch],
            SessionIds = ["sesn_0187kPDyNCwibNNvfaPEApCJ"],
            SlackChannelIds = ["C0123ABCDEF"],
            Speeds = [BetaAnalyticsSpeed.Fast],
            TimeBucketWidth = BetaAnalyticsTimeBucketWidth.Day,
            UserProfileIds = ["uprof_01M33NeYUQK2WV9PpYcsPHLi"],
            WorkspaceIds = ["wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"],
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/analytics/usage?starting_at=2026-09-01T00%3a00%3a00%2b00%3a00&actor_ids%5b%5d=user_01WCz1FkmYMm4gnmykNKUu3Q&actor_types%5b%5d=service_account_actor&agent_ids%5b%5d=agent_01VHd3EAGJ6PLkP9LM7DDu3f&api_key_ids%5b%5d=apikey_01Rj2N8SVvo6BePZj99NhmiT&claude_tag_categories%5b%5d=engaged&claude_tag_user_ids%5b%5d=U0123ABCDEF&context_windows%5b%5d=0-200k&deployment_ids%5b%5d=depl_01JFC6ihzZHtAuyHsaENdJhY&ending_at=2026-10-01T00%3a00%3a00%2b00%3a00&environment_ids%5b%5d=env_017oTjuGedHtjhJauVC5xGJD&exclude_deleted_users=true&group_by%5b%5d=actor&inference_geos%5b%5d=global&limit=1&models%5b%5d=string&order=asc&order_by=output_tokens&page=page&products%5b%5d=chat&rbac_group_ids%5b%5d=rbac_group_012rppKaSVsmTo6NqRDXQXNF&service_tiers%5b%5d=batch&session_ids%5b%5d=sesn_0187kPDyNCwibNNvfaPEApCJ&slack_channel_ids%5b%5d=C0123ABCDEF&speeds%5b%5d=fast&time_bucket_width=1d&user_profile_ids%5b%5d=uprof_01M33NeYUQK2WV9PpYcsPHLi&workspace_ids%5b%5d=wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        UsageListParams parameters = new()
        {
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24,analytics-usage-cost-2026-08-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UsageListParams
        {
            StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z"),
            ActorIds = ["user_01WCz1FkmYMm4gnmykNKUu3Q"],
            ActorTypes = [BetaAnalyticsActorType.ServiceAccountActor],
            AgentIds = ["agent_01VHd3EAGJ6PLkP9LM7DDu3f"],
            ApiKeyIds = ["apikey_01Rj2N8SVvo6BePZj99NhmiT"],
            ClaudeTagCategories = [BetaAnalyticsClaudeTagCategory.Engaged],
            ClaudeTagUserIds = ["U0123ABCDEF"],
            ContextWindows = [BetaAnalyticsContextWindow.From0To200k],
            DeploymentIds = ["depl_01JFC6ihzZHtAuyHsaENdJhY"],
            EndingAt = DateTimeOffset.Parse("2026-10-01T00:00:00Z"),
            EnvironmentIds = ["env_017oTjuGedHtjhJauVC5xGJD"],
            ExcludeDeletedUsers = true,
            GroupBy = [BetaAnalyticsUsageGroupBy.Actor],
            InferenceGeos = [BetaAnalyticsInferenceGeoFilter.Global],
            Limit = 1,
            Models = ["string"],
            Order = BetaAnalyticsUsageCostSortOrder.Asc,
            OrderBy = BetaAnalyticsUsageOrderBy.OutputTokens,
            Page = "page",
            Products = [BetaAnalyticsUsageCostProductFilter.Chat],
            RbacGroupIds = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"],
            ServiceTiers = [BetaAnalyticsServiceTier.Batch],
            SessionIds = ["sesn_0187kPDyNCwibNNvfaPEApCJ"],
            SlackChannelIds = ["C0123ABCDEF"],
            Speeds = [BetaAnalyticsSpeed.Fast],
            TimeBucketWidth = BetaAnalyticsTimeBucketWidth.Day,
            UserProfileIds = ["uprof_01M33NeYUQK2WV9PpYcsPHLi"],
            WorkspaceIds = ["wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        UsageListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
