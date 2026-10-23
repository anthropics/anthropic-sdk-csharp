using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;
using Anthropic.Models.Beta.Organization.Analytics.Cost;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Cost;

public class BetaAnalyticsCostGroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsCostGroup
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

        BetaAnalyticsActor expectedActor = new BetaAnalyticsReportUserActor()
        {
            Deleted = false,
            EmailAddress = "user@emaildomain.com",
            Name = "Jane Doe",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        ApiEnum<string, BetaAnalyticsActorType> expectedActorType =
            BetaAnalyticsActorType.UserActor;
        string expectedAgentID = "agent_01VHd3EAGJ6PLkP9LM7DDu3f";
        string expectedApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT";
        ApiEnum<string, BetaAnalyticsClaudeTagCategory> expectedClaudeTagCategory =
            BetaAnalyticsClaudeTagCategory.Dm;
        string expectedClaudeTagUserID = "U0123ABCDEF";
        ApiEnum<string, BetaAnalyticsContextWindow> expectedContextWindow =
            BetaAnalyticsContextWindow.From0To200k;
        ApiEnum<string, BetaAnalyticsGroupedCostType> expectedCostType =
            BetaAnalyticsGroupedCostType.Tokens;
        string expectedDeploymentID = "depl_01JFC6ihzZHtAuyHsaENdJhY";
        string expectedEnvironmentID = "env_017oTjuGedHtjhJauVC5xGJD";
        ApiEnum<string, BetaAnalyticsUsageCostInferenceGeo> expectedInferenceGeo =
            BetaAnalyticsUsageCostInferenceGeo.Global;
        string expectedModel = "claude-opus-5-5";
        string expectedProduct = "chat";
        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        ApiEnum<string, BetaAnalyticsServiceTier> expectedServiceTier =
            BetaAnalyticsServiceTier.Standard;
        string expectedSessionID = "sesn_0187kPDyNCwibNNvfaPEApCJ";
        string expectedSlackChannelID = "C0123ABCDEF";
        ApiEnum<string, BetaAnalyticsSpeed> expectedSpeed = BetaAnalyticsSpeed.Fast;
        ApiEnum<string, BetaAnalyticsTokenType> expectedTokenType =
            BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens;
        string expectedUserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi";
        string expectedWorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ";

        Assert.Equal(expectedActor, model.Actor);
        Assert.Equal(expectedActorType, model.ActorType);
        Assert.Equal(expectedAgentID, model.AgentID);
        Assert.Equal(expectedApiKeyID, model.ApiKeyID);
        Assert.Equal(expectedClaudeTagCategory, model.ClaudeTagCategory);
        Assert.Equal(expectedClaudeTagUserID, model.ClaudeTagUserID);
        Assert.Equal(expectedContextWindow, model.ContextWindow);
        Assert.Equal(expectedCostType, model.CostType);
        Assert.Equal(expectedDeploymentID, model.DeploymentID);
        Assert.Equal(expectedEnvironmentID, model.EnvironmentID);
        Assert.Equal(expectedInferenceGeo, model.InferenceGeo);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedProduct, model.Product);
        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.Equal(expectedServiceTier, model.ServiceTier);
        Assert.Equal(expectedSessionID, model.SessionID);
        Assert.Equal(expectedSlackChannelID, model.SlackChannelID);
        Assert.Equal(expectedSpeed, model.Speed);
        Assert.Equal(expectedTokenType, model.TokenType);
        Assert.Equal(expectedUserProfileID, model.UserProfileID);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsCostGroup
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsCostGroup>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsCostGroup
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsCostGroup>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaAnalyticsActor expectedActor = new BetaAnalyticsReportUserActor()
        {
            Deleted = false,
            EmailAddress = "user@emaildomain.com",
            Name = "Jane Doe",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };
        ApiEnum<string, BetaAnalyticsActorType> expectedActorType =
            BetaAnalyticsActorType.UserActor;
        string expectedAgentID = "agent_01VHd3EAGJ6PLkP9LM7DDu3f";
        string expectedApiKeyID = "apikey_01Rj2N8SVvo6BePZj99NhmiT";
        ApiEnum<string, BetaAnalyticsClaudeTagCategory> expectedClaudeTagCategory =
            BetaAnalyticsClaudeTagCategory.Dm;
        string expectedClaudeTagUserID = "U0123ABCDEF";
        ApiEnum<string, BetaAnalyticsContextWindow> expectedContextWindow =
            BetaAnalyticsContextWindow.From0To200k;
        ApiEnum<string, BetaAnalyticsGroupedCostType> expectedCostType =
            BetaAnalyticsGroupedCostType.Tokens;
        string expectedDeploymentID = "depl_01JFC6ihzZHtAuyHsaENdJhY";
        string expectedEnvironmentID = "env_017oTjuGedHtjhJauVC5xGJD";
        ApiEnum<string, BetaAnalyticsUsageCostInferenceGeo> expectedInferenceGeo =
            BetaAnalyticsUsageCostInferenceGeo.Global;
        string expectedModel = "claude-opus-5-5";
        string expectedProduct = "chat";
        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        ApiEnum<string, BetaAnalyticsServiceTier> expectedServiceTier =
            BetaAnalyticsServiceTier.Standard;
        string expectedSessionID = "sesn_0187kPDyNCwibNNvfaPEApCJ";
        string expectedSlackChannelID = "C0123ABCDEF";
        ApiEnum<string, BetaAnalyticsSpeed> expectedSpeed = BetaAnalyticsSpeed.Fast;
        ApiEnum<string, BetaAnalyticsTokenType> expectedTokenType =
            BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens;
        string expectedUserProfileID = "uprof_01M33NeYUQK2WV9PpYcsPHLi";
        string expectedWorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ";

        Assert.Equal(expectedActor, deserialized.Actor);
        Assert.Equal(expectedActorType, deserialized.ActorType);
        Assert.Equal(expectedAgentID, deserialized.AgentID);
        Assert.Equal(expectedApiKeyID, deserialized.ApiKeyID);
        Assert.Equal(expectedClaudeTagCategory, deserialized.ClaudeTagCategory);
        Assert.Equal(expectedClaudeTagUserID, deserialized.ClaudeTagUserID);
        Assert.Equal(expectedContextWindow, deserialized.ContextWindow);
        Assert.Equal(expectedCostType, deserialized.CostType);
        Assert.Equal(expectedDeploymentID, deserialized.DeploymentID);
        Assert.Equal(expectedEnvironmentID, deserialized.EnvironmentID);
        Assert.Equal(expectedInferenceGeo, deserialized.InferenceGeo);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedProduct, deserialized.Product);
        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.Equal(expectedServiceTier, deserialized.ServiceTier);
        Assert.Equal(expectedSessionID, deserialized.SessionID);
        Assert.Equal(expectedSlackChannelID, deserialized.SlackChannelID);
        Assert.Equal(expectedSpeed, deserialized.Speed);
        Assert.Equal(expectedTokenType, deserialized.TokenType);
        Assert.Equal(expectedUserProfileID, deserialized.UserProfileID);
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsCostGroup
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsCostGroup
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

        BetaAnalyticsCostGroup copied = new(model);

        Assert.Equal(model, copied);
    }
}
