using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsCostBucketedResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsCostBucketedResult
        {
            Amount = "amount",
            ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
            ClaudeTagUserID = "U0123ABCDEF",
            ContextWindow = BetaAnalyticsContextWindow.From0To200k,
            CostType = BetaAnalyticsCostType.CodeExecution,
            Currency = "USD",
            InferenceGeo = InferenceGeo.Global,
            ListAmount = "list_amount",
            Model = "claude-opus-5",
            Product = "chat",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            Requests = 0,
            SlackChannelID = "C0123ABCDEF",
            Speed = Speed.Fast,
            TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
        };

        string expectedAmount = "amount";
        ApiEnum<string, BetaAnalyticsClaudeTagCategory> expectedClaudeTagCategory =
            BetaAnalyticsClaudeTagCategory.Dm;
        string expectedClaudeTagUserID = "U0123ABCDEF";
        ApiEnum<string, BetaAnalyticsContextWindow> expectedContextWindow =
            BetaAnalyticsContextWindow.From0To200k;
        ApiEnum<string, BetaAnalyticsCostType> expectedCostType =
            BetaAnalyticsCostType.CodeExecution;
        string expectedCurrency = "USD";
        ApiEnum<string, InferenceGeo> expectedInferenceGeo = InferenceGeo.Global;
        string expectedListAmount = "list_amount";
        string expectedModel = "claude-opus-5";
        string expectedProduct = "chat";
        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        long expectedRequests = 0;
        string expectedSlackChannelID = "C0123ABCDEF";
        ApiEnum<string, Speed> expectedSpeed = Speed.Fast;
        ApiEnum<string, BetaAnalyticsTokenType> expectedTokenType =
            BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedClaudeTagCategory, model.ClaudeTagCategory);
        Assert.Equal(expectedClaudeTagUserID, model.ClaudeTagUserID);
        Assert.Equal(expectedContextWindow, model.ContextWindow);
        Assert.Equal(expectedCostType, model.CostType);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedInferenceGeo, model.InferenceGeo);
        Assert.Equal(expectedListAmount, model.ListAmount);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedProduct, model.Product);
        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.Equal(expectedRequests, model.Requests);
        Assert.Equal(expectedSlackChannelID, model.SlackChannelID);
        Assert.Equal(expectedSpeed, model.Speed);
        Assert.Equal(expectedTokenType, model.TokenType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsCostBucketedResult
        {
            Amount = "amount",
            ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
            ClaudeTagUserID = "U0123ABCDEF",
            ContextWindow = BetaAnalyticsContextWindow.From0To200k,
            CostType = BetaAnalyticsCostType.CodeExecution,
            Currency = "USD",
            InferenceGeo = InferenceGeo.Global,
            ListAmount = "list_amount",
            Model = "claude-opus-5",
            Product = "chat",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            Requests = 0,
            SlackChannelID = "C0123ABCDEF",
            Speed = Speed.Fast,
            TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsCostBucketedResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsCostBucketedResult
        {
            Amount = "amount",
            ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
            ClaudeTagUserID = "U0123ABCDEF",
            ContextWindow = BetaAnalyticsContextWindow.From0To200k,
            CostType = BetaAnalyticsCostType.CodeExecution,
            Currency = "USD",
            InferenceGeo = InferenceGeo.Global,
            ListAmount = "list_amount",
            Model = "claude-opus-5",
            Product = "chat",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            Requests = 0,
            SlackChannelID = "C0123ABCDEF",
            Speed = Speed.Fast,
            TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsCostBucketedResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAmount = "amount";
        ApiEnum<string, BetaAnalyticsClaudeTagCategory> expectedClaudeTagCategory =
            BetaAnalyticsClaudeTagCategory.Dm;
        string expectedClaudeTagUserID = "U0123ABCDEF";
        ApiEnum<string, BetaAnalyticsContextWindow> expectedContextWindow =
            BetaAnalyticsContextWindow.From0To200k;
        ApiEnum<string, BetaAnalyticsCostType> expectedCostType =
            BetaAnalyticsCostType.CodeExecution;
        string expectedCurrency = "USD";
        ApiEnum<string, InferenceGeo> expectedInferenceGeo = InferenceGeo.Global;
        string expectedListAmount = "list_amount";
        string expectedModel = "claude-opus-5";
        string expectedProduct = "chat";
        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        long expectedRequests = 0;
        string expectedSlackChannelID = "C0123ABCDEF";
        ApiEnum<string, Speed> expectedSpeed = Speed.Fast;
        ApiEnum<string, BetaAnalyticsTokenType> expectedTokenType =
            BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedClaudeTagCategory, deserialized.ClaudeTagCategory);
        Assert.Equal(expectedClaudeTagUserID, deserialized.ClaudeTagUserID);
        Assert.Equal(expectedContextWindow, deserialized.ContextWindow);
        Assert.Equal(expectedCostType, deserialized.CostType);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedInferenceGeo, deserialized.InferenceGeo);
        Assert.Equal(expectedListAmount, deserialized.ListAmount);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedProduct, deserialized.Product);
        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.Equal(expectedRequests, deserialized.Requests);
        Assert.Equal(expectedSlackChannelID, deserialized.SlackChannelID);
        Assert.Equal(expectedSpeed, deserialized.Speed);
        Assert.Equal(expectedTokenType, deserialized.TokenType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsCostBucketedResult
        {
            Amount = "amount",
            ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
            ClaudeTagUserID = "U0123ABCDEF",
            ContextWindow = BetaAnalyticsContextWindow.From0To200k,
            CostType = BetaAnalyticsCostType.CodeExecution,
            Currency = "USD",
            InferenceGeo = InferenceGeo.Global,
            ListAmount = "list_amount",
            Model = "claude-opus-5",
            Product = "chat",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            Requests = 0,
            SlackChannelID = "C0123ABCDEF",
            Speed = Speed.Fast,
            TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsCostBucketedResult
        {
            Amount = "amount",
            ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
            ClaudeTagUserID = "U0123ABCDEF",
            ContextWindow = BetaAnalyticsContextWindow.From0To200k,
            CostType = BetaAnalyticsCostType.CodeExecution,
            Currency = "USD",
            InferenceGeo = InferenceGeo.Global,
            ListAmount = "list_amount",
            Model = "claude-opus-5",
            Product = "chat",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            Requests = 0,
            SlackChannelID = "C0123ABCDEF",
            Speed = Speed.Fast,
            TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
        };

        BetaAnalyticsCostBucketedResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InferenceGeoTest : TestBase
{
    [Theory]
    [InlineData(InferenceGeo.Global)]
    [InlineData(InferenceGeo.Us)]
    public void Validation_Works(InferenceGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InferenceGeo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InferenceGeo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InferenceGeo.Global)]
    [InlineData(InferenceGeo.Us)]
    public void SerializationRoundtrip_Works(InferenceGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InferenceGeo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InferenceGeo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InferenceGeo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InferenceGeo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SpeedTest : TestBase
{
    [Theory]
    [InlineData(Speed.Fast)]
    [InlineData(Speed.Standard)]
    public void Validation_Works(Speed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Speed> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Speed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Speed.Fast)]
    [InlineData(Speed.Standard)]
    public void SerializationRoundtrip_Works(Speed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Speed> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Speed>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Speed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Speed>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
