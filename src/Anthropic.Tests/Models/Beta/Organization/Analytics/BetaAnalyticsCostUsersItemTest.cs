using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsCostUsersItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsCostUsersItem
        {
            Actor = new()
            {
                Deleted = true,
                EmailAddress = "jane@example.com",
                Name = "Jane Smith",
                UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
            },
            Amount = "41280.000000",
            ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
            ClaudeTagUserID = "U0123ABCDEF",
            ContextWindow = BetaAnalyticsContextWindow.From0To200k,
            CostType = BetaAnalyticsCostType.CodeExecution,
            Currency = "USD",
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InferenceGeo = BetaAnalyticsCostUsersItemInferenceGeo.Global,
            ListAmount = "51600.000000",
            Model = "claude-opus-5",
            Product = "chat",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            Requests = 128,
            SlackChannelID = "C0123ABCDEF",
            Speed = BetaAnalyticsCostUsersItemSpeed.Fast,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
        };

        BetaAnalyticsUserActor expectedActor = new()
        {
            Deleted = true,
            EmailAddress = "jane@example.com",
            Name = "Jane Smith",
            UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
        };
        string expectedAmount = "41280.000000";
        ApiEnum<string, BetaAnalyticsClaudeTagCategory> expectedClaudeTagCategory =
            BetaAnalyticsClaudeTagCategory.Dm;
        string expectedClaudeTagUserID = "U0123ABCDEF";
        ApiEnum<string, BetaAnalyticsContextWindow> expectedContextWindow =
            BetaAnalyticsContextWindow.From0To200k;
        ApiEnum<string, BetaAnalyticsCostType> expectedCostType =
            BetaAnalyticsCostType.CodeExecution;
        string expectedCurrency = "USD";
        DateTimeOffset expectedEndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaAnalyticsCostUsersItemInferenceGeo> expectedInferenceGeo =
            BetaAnalyticsCostUsersItemInferenceGeo.Global;
        string expectedListAmount = "51600.000000";
        string expectedModel = "claude-opus-5";
        string expectedProduct = "chat";
        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        long expectedRequests = 128;
        string expectedSlackChannelID = "C0123ABCDEF";
        ApiEnum<string, BetaAnalyticsCostUsersItemSpeed> expectedSpeed =
            BetaAnalyticsCostUsersItemSpeed.Fast;
        DateTimeOffset expectedStartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaAnalyticsTokenType> expectedTokenType =
            BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens;

        Assert.Equal(expectedActor, model.Actor);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedClaudeTagCategory, model.ClaudeTagCategory);
        Assert.Equal(expectedClaudeTagUserID, model.ClaudeTagUserID);
        Assert.Equal(expectedContextWindow, model.ContextWindow);
        Assert.Equal(expectedCostType, model.CostType);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedEndingAt, model.EndingAt);
        Assert.Equal(expectedInferenceGeo, model.InferenceGeo);
        Assert.Equal(expectedListAmount, model.ListAmount);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedProduct, model.Product);
        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.Equal(expectedRequests, model.Requests);
        Assert.Equal(expectedSlackChannelID, model.SlackChannelID);
        Assert.Equal(expectedSpeed, model.Speed);
        Assert.Equal(expectedStartingAt, model.StartingAt);
        Assert.Equal(expectedTokenType, model.TokenType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsCostUsersItem
        {
            Actor = new()
            {
                Deleted = true,
                EmailAddress = "jane@example.com",
                Name = "Jane Smith",
                UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
            },
            Amount = "41280.000000",
            ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
            ClaudeTagUserID = "U0123ABCDEF",
            ContextWindow = BetaAnalyticsContextWindow.From0To200k,
            CostType = BetaAnalyticsCostType.CodeExecution,
            Currency = "USD",
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InferenceGeo = BetaAnalyticsCostUsersItemInferenceGeo.Global,
            ListAmount = "51600.000000",
            Model = "claude-opus-5",
            Product = "chat",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            Requests = 128,
            SlackChannelID = "C0123ABCDEF",
            Speed = BetaAnalyticsCostUsersItemSpeed.Fast,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsCostUsersItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsCostUsersItem
        {
            Actor = new()
            {
                Deleted = true,
                EmailAddress = "jane@example.com",
                Name = "Jane Smith",
                UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
            },
            Amount = "41280.000000",
            ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
            ClaudeTagUserID = "U0123ABCDEF",
            ContextWindow = BetaAnalyticsContextWindow.From0To200k,
            CostType = BetaAnalyticsCostType.CodeExecution,
            Currency = "USD",
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InferenceGeo = BetaAnalyticsCostUsersItemInferenceGeo.Global,
            ListAmount = "51600.000000",
            Model = "claude-opus-5",
            Product = "chat",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            Requests = 128,
            SlackChannelID = "C0123ABCDEF",
            Speed = BetaAnalyticsCostUsersItemSpeed.Fast,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsCostUsersItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaAnalyticsUserActor expectedActor = new()
        {
            Deleted = true,
            EmailAddress = "jane@example.com",
            Name = "Jane Smith",
            UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
        };
        string expectedAmount = "41280.000000";
        ApiEnum<string, BetaAnalyticsClaudeTagCategory> expectedClaudeTagCategory =
            BetaAnalyticsClaudeTagCategory.Dm;
        string expectedClaudeTagUserID = "U0123ABCDEF";
        ApiEnum<string, BetaAnalyticsContextWindow> expectedContextWindow =
            BetaAnalyticsContextWindow.From0To200k;
        ApiEnum<string, BetaAnalyticsCostType> expectedCostType =
            BetaAnalyticsCostType.CodeExecution;
        string expectedCurrency = "USD";
        DateTimeOffset expectedEndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaAnalyticsCostUsersItemInferenceGeo> expectedInferenceGeo =
            BetaAnalyticsCostUsersItemInferenceGeo.Global;
        string expectedListAmount = "51600.000000";
        string expectedModel = "claude-opus-5";
        string expectedProduct = "chat";
        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        long expectedRequests = 128;
        string expectedSlackChannelID = "C0123ABCDEF";
        ApiEnum<string, BetaAnalyticsCostUsersItemSpeed> expectedSpeed =
            BetaAnalyticsCostUsersItemSpeed.Fast;
        DateTimeOffset expectedStartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaAnalyticsTokenType> expectedTokenType =
            BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens;

        Assert.Equal(expectedActor, deserialized.Actor);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedClaudeTagCategory, deserialized.ClaudeTagCategory);
        Assert.Equal(expectedClaudeTagUserID, deserialized.ClaudeTagUserID);
        Assert.Equal(expectedContextWindow, deserialized.ContextWindow);
        Assert.Equal(expectedCostType, deserialized.CostType);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedEndingAt, deserialized.EndingAt);
        Assert.Equal(expectedInferenceGeo, deserialized.InferenceGeo);
        Assert.Equal(expectedListAmount, deserialized.ListAmount);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedProduct, deserialized.Product);
        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.Equal(expectedRequests, deserialized.Requests);
        Assert.Equal(expectedSlackChannelID, deserialized.SlackChannelID);
        Assert.Equal(expectedSpeed, deserialized.Speed);
        Assert.Equal(expectedStartingAt, deserialized.StartingAt);
        Assert.Equal(expectedTokenType, deserialized.TokenType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsCostUsersItem
        {
            Actor = new()
            {
                Deleted = true,
                EmailAddress = "jane@example.com",
                Name = "Jane Smith",
                UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
            },
            Amount = "41280.000000",
            ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
            ClaudeTagUserID = "U0123ABCDEF",
            ContextWindow = BetaAnalyticsContextWindow.From0To200k,
            CostType = BetaAnalyticsCostType.CodeExecution,
            Currency = "USD",
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InferenceGeo = BetaAnalyticsCostUsersItemInferenceGeo.Global,
            ListAmount = "51600.000000",
            Model = "claude-opus-5",
            Product = "chat",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            Requests = 128,
            SlackChannelID = "C0123ABCDEF",
            Speed = BetaAnalyticsCostUsersItemSpeed.Fast,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsCostUsersItem
        {
            Actor = new()
            {
                Deleted = true,
                EmailAddress = "jane@example.com",
                Name = "Jane Smith",
                UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
            },
            Amount = "41280.000000",
            ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
            ClaudeTagUserID = "U0123ABCDEF",
            ContextWindow = BetaAnalyticsContextWindow.From0To200k,
            CostType = BetaAnalyticsCostType.CodeExecution,
            Currency = "USD",
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InferenceGeo = BetaAnalyticsCostUsersItemInferenceGeo.Global,
            ListAmount = "51600.000000",
            Model = "claude-opus-5",
            Product = "chat",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            Requests = 128,
            SlackChannelID = "C0123ABCDEF",
            Speed = BetaAnalyticsCostUsersItemSpeed.Fast,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TokenType = BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
        };

        BetaAnalyticsCostUsersItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaAnalyticsCostUsersItemInferenceGeoTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsCostUsersItemInferenceGeo.Global)]
    [InlineData(BetaAnalyticsCostUsersItemInferenceGeo.Us)]
    public void Validation_Works(BetaAnalyticsCostUsersItemInferenceGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsCostUsersItemInferenceGeo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsCostUsersItemInferenceGeo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsCostUsersItemInferenceGeo.Global)]
    [InlineData(BetaAnalyticsCostUsersItemInferenceGeo.Us)]
    public void SerializationRoundtrip_Works(BetaAnalyticsCostUsersItemInferenceGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsCostUsersItemInferenceGeo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsCostUsersItemInferenceGeo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsCostUsersItemInferenceGeo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsCostUsersItemInferenceGeo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaAnalyticsCostUsersItemSpeedTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsCostUsersItemSpeed.Fast)]
    [InlineData(BetaAnalyticsCostUsersItemSpeed.Standard)]
    public void Validation_Works(BetaAnalyticsCostUsersItemSpeed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsCostUsersItemSpeed> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsCostUsersItemSpeed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsCostUsersItemSpeed.Fast)]
    [InlineData(BetaAnalyticsCostUsersItemSpeed.Standard)]
    public void SerializationRoundtrip_Works(BetaAnalyticsCostUsersItemSpeed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsCostUsersItemSpeed> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsCostUsersItemSpeed>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsCostUsersItemSpeed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsCostUsersItemSpeed>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
