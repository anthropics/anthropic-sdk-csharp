using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;
using Anthropic.Models.Beta.Organization.Analytics.Cost;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Cost;

public class CostListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CostListPageResponse
        {
            Data =
            [
                new()
                {
                    Cost = new()
                    {
                        Amount = "41280.000000",
                        Currency = "USD",
                        ListAmount = "51600.000000",
                        Requests = 128,
                    },
                    EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Group = new()
                    {
                        Actor = new BetaAnalyticsReportUserActor()
                        {
                            Deleted = true,
                            EmailAddress = "user@emaildomain.com",
                            Name = "Jane Doe",
                            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                        },
                        ActorType = BetaAnalyticsActorType.ApiActor,
                        AgentID = "agent_01VHd3EAGJ6PLkP9LM7DDu3f",
                        ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                        ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                        ClaudeTagUserID = "U0123ABCDEF",
                        ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                        CostType = BetaAnalyticsGroupedCostType.CodeExecution,
                        DeploymentID = "depl_01JFC6ihzZHtAuyHsaENdJhY",
                        EnvironmentID = "env_017oTjuGedHtjhJauVC5xGJD",
                        InferenceGeo = BetaAnalyticsUsageCostInferenceGeo.Global,
                        Model = "claude-opus-5-5",
                        Product = "chat",
                        RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                        ServiceTier = BetaAnalyticsServiceTier.Batch,
                        SessionID = "sesn_0187kPDyNCwibNNvfaPEApCJ",
                        SlackChannelID = "C0123ABCDEF",
                        Speed = BetaAnalyticsSpeed.Fast,
                        TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                        UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
                        WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
                    },
                    StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
        };

        List<BetaAnalyticsCostItem> expectedData =
        [
            new()
            {
                Cost = new()
                {
                    Amount = "41280.000000",
                    Currency = "USD",
                    ListAmount = "51600.000000",
                    Requests = 128,
                },
                EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Group = new()
                {
                    Actor = new BetaAnalyticsReportUserActor()
                    {
                        Deleted = true,
                        EmailAddress = "user@emaildomain.com",
                        Name = "Jane Doe",
                        UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                    },
                    ActorType = BetaAnalyticsActorType.ApiActor,
                    AgentID = "agent_01VHd3EAGJ6PLkP9LM7DDu3f",
                    ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                    ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                    ClaudeTagUserID = "U0123ABCDEF",
                    ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                    CostType = BetaAnalyticsGroupedCostType.CodeExecution,
                    DeploymentID = "depl_01JFC6ihzZHtAuyHsaENdJhY",
                    EnvironmentID = "env_017oTjuGedHtjhJauVC5xGJD",
                    InferenceGeo = BetaAnalyticsUsageCostInferenceGeo.Global,
                    Model = "claude-opus-5-5",
                    Product = "chat",
                    RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                    ServiceTier = BetaAnalyticsServiceTier.Batch,
                    SessionID = "sesn_0187kPDyNCwibNNvfaPEApCJ",
                    SlackChannelID = "C0123ABCDEF",
                    Speed = BetaAnalyticsSpeed.Fast,
                    TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                    UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
                    WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
                },
                StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        DateTimeOffset expectedDataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedHasMore = true;
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedDataRefreshedAt, model.DataRefreshedAt);
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CostListPageResponse
        {
            Data =
            [
                new()
                {
                    Cost = new()
                    {
                        Amount = "41280.000000",
                        Currency = "USD",
                        ListAmount = "51600.000000",
                        Requests = 128,
                    },
                    EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Group = new()
                    {
                        Actor = new BetaAnalyticsReportUserActor()
                        {
                            Deleted = true,
                            EmailAddress = "user@emaildomain.com",
                            Name = "Jane Doe",
                            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                        },
                        ActorType = BetaAnalyticsActorType.ApiActor,
                        AgentID = "agent_01VHd3EAGJ6PLkP9LM7DDu3f",
                        ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                        ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                        ClaudeTagUserID = "U0123ABCDEF",
                        ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                        CostType = BetaAnalyticsGroupedCostType.CodeExecution,
                        DeploymentID = "depl_01JFC6ihzZHtAuyHsaENdJhY",
                        EnvironmentID = "env_017oTjuGedHtjhJauVC5xGJD",
                        InferenceGeo = BetaAnalyticsUsageCostInferenceGeo.Global,
                        Model = "claude-opus-5-5",
                        Product = "chat",
                        RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                        ServiceTier = BetaAnalyticsServiceTier.Batch,
                        SessionID = "sesn_0187kPDyNCwibNNvfaPEApCJ",
                        SlackChannelID = "C0123ABCDEF",
                        Speed = BetaAnalyticsSpeed.Fast,
                        TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                        UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
                        WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
                    },
                    StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CostListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CostListPageResponse
        {
            Data =
            [
                new()
                {
                    Cost = new()
                    {
                        Amount = "41280.000000",
                        Currency = "USD",
                        ListAmount = "51600.000000",
                        Requests = 128,
                    },
                    EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Group = new()
                    {
                        Actor = new BetaAnalyticsReportUserActor()
                        {
                            Deleted = true,
                            EmailAddress = "user@emaildomain.com",
                            Name = "Jane Doe",
                            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                        },
                        ActorType = BetaAnalyticsActorType.ApiActor,
                        AgentID = "agent_01VHd3EAGJ6PLkP9LM7DDu3f",
                        ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                        ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                        ClaudeTagUserID = "U0123ABCDEF",
                        ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                        CostType = BetaAnalyticsGroupedCostType.CodeExecution,
                        DeploymentID = "depl_01JFC6ihzZHtAuyHsaENdJhY",
                        EnvironmentID = "env_017oTjuGedHtjhJauVC5xGJD",
                        InferenceGeo = BetaAnalyticsUsageCostInferenceGeo.Global,
                        Model = "claude-opus-5-5",
                        Product = "chat",
                        RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                        ServiceTier = BetaAnalyticsServiceTier.Batch,
                        SessionID = "sesn_0187kPDyNCwibNNvfaPEApCJ",
                        SlackChannelID = "C0123ABCDEF",
                        Speed = BetaAnalyticsSpeed.Fast,
                        TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                        UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
                        WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
                    },
                    StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CostListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaAnalyticsCostItem> expectedData =
        [
            new()
            {
                Cost = new()
                {
                    Amount = "41280.000000",
                    Currency = "USD",
                    ListAmount = "51600.000000",
                    Requests = 128,
                },
                EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Group = new()
                {
                    Actor = new BetaAnalyticsReportUserActor()
                    {
                        Deleted = true,
                        EmailAddress = "user@emaildomain.com",
                        Name = "Jane Doe",
                        UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                    },
                    ActorType = BetaAnalyticsActorType.ApiActor,
                    AgentID = "agent_01VHd3EAGJ6PLkP9LM7DDu3f",
                    ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                    ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                    ClaudeTagUserID = "U0123ABCDEF",
                    ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                    CostType = BetaAnalyticsGroupedCostType.CodeExecution,
                    DeploymentID = "depl_01JFC6ihzZHtAuyHsaENdJhY",
                    EnvironmentID = "env_017oTjuGedHtjhJauVC5xGJD",
                    InferenceGeo = BetaAnalyticsUsageCostInferenceGeo.Global,
                    Model = "claude-opus-5-5",
                    Product = "chat",
                    RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                    ServiceTier = BetaAnalyticsServiceTier.Batch,
                    SessionID = "sesn_0187kPDyNCwibNNvfaPEApCJ",
                    SlackChannelID = "C0123ABCDEF",
                    Speed = BetaAnalyticsSpeed.Fast,
                    TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                    UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
                    WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
                },
                StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        DateTimeOffset expectedDataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedHasMore = true;
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedDataRefreshedAt, deserialized.DataRefreshedAt);
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CostListPageResponse
        {
            Data =
            [
                new()
                {
                    Cost = new()
                    {
                        Amount = "41280.000000",
                        Currency = "USD",
                        ListAmount = "51600.000000",
                        Requests = 128,
                    },
                    EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Group = new()
                    {
                        Actor = new BetaAnalyticsReportUserActor()
                        {
                            Deleted = true,
                            EmailAddress = "user@emaildomain.com",
                            Name = "Jane Doe",
                            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                        },
                        ActorType = BetaAnalyticsActorType.ApiActor,
                        AgentID = "agent_01VHd3EAGJ6PLkP9LM7DDu3f",
                        ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                        ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                        ClaudeTagUserID = "U0123ABCDEF",
                        ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                        CostType = BetaAnalyticsGroupedCostType.CodeExecution,
                        DeploymentID = "depl_01JFC6ihzZHtAuyHsaENdJhY",
                        EnvironmentID = "env_017oTjuGedHtjhJauVC5xGJD",
                        InferenceGeo = BetaAnalyticsUsageCostInferenceGeo.Global,
                        Model = "claude-opus-5-5",
                        Product = "chat",
                        RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                        ServiceTier = BetaAnalyticsServiceTier.Batch,
                        SessionID = "sesn_0187kPDyNCwibNNvfaPEApCJ",
                        SlackChannelID = "C0123ABCDEF",
                        Speed = BetaAnalyticsSpeed.Fast,
                        TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                        UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
                        WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
                    },
                    StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CostListPageResponse
        {
            Data =
            [
                new()
                {
                    Cost = new()
                    {
                        Amount = "41280.000000",
                        Currency = "USD",
                        ListAmount = "51600.000000",
                        Requests = 128,
                    },
                    EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Group = new()
                    {
                        Actor = new BetaAnalyticsReportUserActor()
                        {
                            Deleted = true,
                            EmailAddress = "user@emaildomain.com",
                            Name = "Jane Doe",
                            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                        },
                        ActorType = BetaAnalyticsActorType.ApiActor,
                        AgentID = "agent_01VHd3EAGJ6PLkP9LM7DDu3f",
                        ApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                        ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
                        ClaudeTagUserID = "U0123ABCDEF",
                        ContextWindow = BetaAnalyticsContextWindow.From0To200k,
                        CostType = BetaAnalyticsGroupedCostType.CodeExecution,
                        DeploymentID = "depl_01JFC6ihzZHtAuyHsaENdJhY",
                        EnvironmentID = "env_017oTjuGedHtjhJauVC5xGJD",
                        InferenceGeo = BetaAnalyticsUsageCostInferenceGeo.Global,
                        Model = "claude-opus-5-5",
                        Product = "chat",
                        RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                        ServiceTier = BetaAnalyticsServiceTier.Batch,
                        SessionID = "sesn_0187kPDyNCwibNNvfaPEApCJ",
                        SlackChannelID = "C0123ABCDEF",
                        Speed = BetaAnalyticsSpeed.Fast,
                        TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                        UserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi",
                        WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
                    },
                    StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
        };

        CostListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
