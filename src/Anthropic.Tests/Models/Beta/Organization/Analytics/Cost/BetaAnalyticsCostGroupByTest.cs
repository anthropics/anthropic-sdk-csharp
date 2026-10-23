using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics.Cost;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Cost;

public class BetaAnalyticsCostGroupByTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsCostGroupBy.Actor)]
    [InlineData(BetaAnalyticsCostGroupBy.ActorType)]
    [InlineData(BetaAnalyticsCostGroupBy.AgentID)]
    [InlineData(BetaAnalyticsCostGroupBy.ApiKeyID)]
    [InlineData(BetaAnalyticsCostGroupBy.ClaudeTagCategory)]
    [InlineData(BetaAnalyticsCostGroupBy.ClaudeTagUserID)]
    [InlineData(BetaAnalyticsCostGroupBy.ContextWindow)]
    [InlineData(BetaAnalyticsCostGroupBy.CostType)]
    [InlineData(BetaAnalyticsCostGroupBy.DeploymentID)]
    [InlineData(BetaAnalyticsCostGroupBy.EnvironmentID)]
    [InlineData(BetaAnalyticsCostGroupBy.InferenceGeo)]
    [InlineData(BetaAnalyticsCostGroupBy.Model)]
    [InlineData(BetaAnalyticsCostGroupBy.Product)]
    [InlineData(BetaAnalyticsCostGroupBy.RbacGroupID)]
    [InlineData(BetaAnalyticsCostGroupBy.ServiceTier)]
    [InlineData(BetaAnalyticsCostGroupBy.SessionID)]
    [InlineData(BetaAnalyticsCostGroupBy.SlackChannelID)]
    [InlineData(BetaAnalyticsCostGroupBy.Speed)]
    [InlineData(BetaAnalyticsCostGroupBy.TokenType)]
    [InlineData(BetaAnalyticsCostGroupBy.UserProfileID)]
    [InlineData(BetaAnalyticsCostGroupBy.WorkspaceID)]
    public void Validation_Works(BetaAnalyticsCostGroupBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsCostGroupBy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsCostGroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsCostGroupBy.Actor)]
    [InlineData(BetaAnalyticsCostGroupBy.ActorType)]
    [InlineData(BetaAnalyticsCostGroupBy.AgentID)]
    [InlineData(BetaAnalyticsCostGroupBy.ApiKeyID)]
    [InlineData(BetaAnalyticsCostGroupBy.ClaudeTagCategory)]
    [InlineData(BetaAnalyticsCostGroupBy.ClaudeTagUserID)]
    [InlineData(BetaAnalyticsCostGroupBy.ContextWindow)]
    [InlineData(BetaAnalyticsCostGroupBy.CostType)]
    [InlineData(BetaAnalyticsCostGroupBy.DeploymentID)]
    [InlineData(BetaAnalyticsCostGroupBy.EnvironmentID)]
    [InlineData(BetaAnalyticsCostGroupBy.InferenceGeo)]
    [InlineData(BetaAnalyticsCostGroupBy.Model)]
    [InlineData(BetaAnalyticsCostGroupBy.Product)]
    [InlineData(BetaAnalyticsCostGroupBy.RbacGroupID)]
    [InlineData(BetaAnalyticsCostGroupBy.ServiceTier)]
    [InlineData(BetaAnalyticsCostGroupBy.SessionID)]
    [InlineData(BetaAnalyticsCostGroupBy.SlackChannelID)]
    [InlineData(BetaAnalyticsCostGroupBy.Speed)]
    [InlineData(BetaAnalyticsCostGroupBy.TokenType)]
    [InlineData(BetaAnalyticsCostGroupBy.UserProfileID)]
    [InlineData(BetaAnalyticsCostGroupBy.WorkspaceID)]
    public void SerializationRoundtrip_Works(BetaAnalyticsCostGroupBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsCostGroupBy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsCostGroupBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsCostGroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsCostGroupBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
