using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsUsageUsersItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsUsageUsersItem
        {
            Actor = new()
            {
                Deleted = true,
                EmailAddress = "jane@example.com",
                Name = "Jane Smith",
                UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
            },
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 3200000,
            ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
            ClaudeTagUserID = "U0123ABCDEF",
            ContextWindow = BetaAnalyticsContextWindow.From0To200k,
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InferenceGeo = BetaAnalyticsUsageUsersItemInferenceGeo.Global,
            Model = "claude-opus-5",
            OutputTokens = 891000,
            Product = "chat",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            Requests = 128,
            ServerToolUse = new(10),
            SlackChannelID = "C0123ABCDEF",
            Speed = BetaAnalyticsUsageUsersItemSpeed.Fast,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TotalTokens = 5377000,
            UncachedInputTokens = 1284500,
        };

        BetaAnalyticsUserActor expectedActor = new()
        {
            Deleted = true,
            EmailAddress = "jane@example.com",
            Name = "Jane Smith",
            UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
        };
        BetaCacheCreation expectedCacheCreation = new()
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };
        long expectedCacheReadInputTokens = 3200000;
        ApiEnum<string, BetaAnalyticsClaudeTagCategory> expectedClaudeTagCategory =
            BetaAnalyticsClaudeTagCategory.Dm;
        string expectedClaudeTagUserID = "U0123ABCDEF";
        ApiEnum<string, BetaAnalyticsContextWindow> expectedContextWindow =
            BetaAnalyticsContextWindow.From0To200k;
        DateTimeOffset expectedEndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaAnalyticsUsageUsersItemInferenceGeo> expectedInferenceGeo =
            BetaAnalyticsUsageUsersItemInferenceGeo.Global;
        string expectedModel = "claude-opus-5";
        long expectedOutputTokens = 891000;
        string expectedProduct = "chat";
        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        long expectedRequests = 128;
        BetaAnalyticsServerToolUse expectedServerToolUse = new(10);
        string expectedSlackChannelID = "C0123ABCDEF";
        ApiEnum<string, BetaAnalyticsUsageUsersItemSpeed> expectedSpeed =
            BetaAnalyticsUsageUsersItemSpeed.Fast;
        DateTimeOffset expectedStartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedTotalTokens = 5377000;
        long expectedUncachedInputTokens = 1284500;

        Assert.Equal(expectedActor, model.Actor);
        Assert.Equal(expectedCacheCreation, model.CacheCreation);
        Assert.Equal(expectedCacheReadInputTokens, model.CacheReadInputTokens);
        Assert.Equal(expectedClaudeTagCategory, model.ClaudeTagCategory);
        Assert.Equal(expectedClaudeTagUserID, model.ClaudeTagUserID);
        Assert.Equal(expectedContextWindow, model.ContextWindow);
        Assert.Equal(expectedEndingAt, model.EndingAt);
        Assert.Equal(expectedInferenceGeo, model.InferenceGeo);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.Equal(expectedProduct, model.Product);
        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.Equal(expectedRequests, model.Requests);
        Assert.Equal(expectedServerToolUse, model.ServerToolUse);
        Assert.Equal(expectedSlackChannelID, model.SlackChannelID);
        Assert.Equal(expectedSpeed, model.Speed);
        Assert.Equal(expectedStartingAt, model.StartingAt);
        Assert.Equal(expectedTotalTokens, model.TotalTokens);
        Assert.Equal(expectedUncachedInputTokens, model.UncachedInputTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsUsageUsersItem
        {
            Actor = new()
            {
                Deleted = true,
                EmailAddress = "jane@example.com",
                Name = "Jane Smith",
                UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
            },
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 3200000,
            ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
            ClaudeTagUserID = "U0123ABCDEF",
            ContextWindow = BetaAnalyticsContextWindow.From0To200k,
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InferenceGeo = BetaAnalyticsUsageUsersItemInferenceGeo.Global,
            Model = "claude-opus-5",
            OutputTokens = 891000,
            Product = "chat",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            Requests = 128,
            ServerToolUse = new(10),
            SlackChannelID = "C0123ABCDEF",
            Speed = BetaAnalyticsUsageUsersItemSpeed.Fast,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TotalTokens = 5377000,
            UncachedInputTokens = 1284500,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsUsageUsersItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsUsageUsersItem
        {
            Actor = new()
            {
                Deleted = true,
                EmailAddress = "jane@example.com",
                Name = "Jane Smith",
                UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
            },
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 3200000,
            ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
            ClaudeTagUserID = "U0123ABCDEF",
            ContextWindow = BetaAnalyticsContextWindow.From0To200k,
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InferenceGeo = BetaAnalyticsUsageUsersItemInferenceGeo.Global,
            Model = "claude-opus-5",
            OutputTokens = 891000,
            Product = "chat",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            Requests = 128,
            ServerToolUse = new(10),
            SlackChannelID = "C0123ABCDEF",
            Speed = BetaAnalyticsUsageUsersItemSpeed.Fast,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TotalTokens = 5377000,
            UncachedInputTokens = 1284500,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsUsageUsersItem>(
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
        BetaCacheCreation expectedCacheCreation = new()
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };
        long expectedCacheReadInputTokens = 3200000;
        ApiEnum<string, BetaAnalyticsClaudeTagCategory> expectedClaudeTagCategory =
            BetaAnalyticsClaudeTagCategory.Dm;
        string expectedClaudeTagUserID = "U0123ABCDEF";
        ApiEnum<string, BetaAnalyticsContextWindow> expectedContextWindow =
            BetaAnalyticsContextWindow.From0To200k;
        DateTimeOffset expectedEndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaAnalyticsUsageUsersItemInferenceGeo> expectedInferenceGeo =
            BetaAnalyticsUsageUsersItemInferenceGeo.Global;
        string expectedModel = "claude-opus-5";
        long expectedOutputTokens = 891000;
        string expectedProduct = "chat";
        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        long expectedRequests = 128;
        BetaAnalyticsServerToolUse expectedServerToolUse = new(10);
        string expectedSlackChannelID = "C0123ABCDEF";
        ApiEnum<string, BetaAnalyticsUsageUsersItemSpeed> expectedSpeed =
            BetaAnalyticsUsageUsersItemSpeed.Fast;
        DateTimeOffset expectedStartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedTotalTokens = 5377000;
        long expectedUncachedInputTokens = 1284500;

        Assert.Equal(expectedActor, deserialized.Actor);
        Assert.Equal(expectedCacheCreation, deserialized.CacheCreation);
        Assert.Equal(expectedCacheReadInputTokens, deserialized.CacheReadInputTokens);
        Assert.Equal(expectedClaudeTagCategory, deserialized.ClaudeTagCategory);
        Assert.Equal(expectedClaudeTagUserID, deserialized.ClaudeTagUserID);
        Assert.Equal(expectedContextWindow, deserialized.ContextWindow);
        Assert.Equal(expectedEndingAt, deserialized.EndingAt);
        Assert.Equal(expectedInferenceGeo, deserialized.InferenceGeo);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
        Assert.Equal(expectedProduct, deserialized.Product);
        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.Equal(expectedRequests, deserialized.Requests);
        Assert.Equal(expectedServerToolUse, deserialized.ServerToolUse);
        Assert.Equal(expectedSlackChannelID, deserialized.SlackChannelID);
        Assert.Equal(expectedSpeed, deserialized.Speed);
        Assert.Equal(expectedStartingAt, deserialized.StartingAt);
        Assert.Equal(expectedTotalTokens, deserialized.TotalTokens);
        Assert.Equal(expectedUncachedInputTokens, deserialized.UncachedInputTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsUsageUsersItem
        {
            Actor = new()
            {
                Deleted = true,
                EmailAddress = "jane@example.com",
                Name = "Jane Smith",
                UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
            },
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 3200000,
            ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
            ClaudeTagUserID = "U0123ABCDEF",
            ContextWindow = BetaAnalyticsContextWindow.From0To200k,
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InferenceGeo = BetaAnalyticsUsageUsersItemInferenceGeo.Global,
            Model = "claude-opus-5",
            OutputTokens = 891000,
            Product = "chat",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            Requests = 128,
            ServerToolUse = new(10),
            SlackChannelID = "C0123ABCDEF",
            Speed = BetaAnalyticsUsageUsersItemSpeed.Fast,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TotalTokens = 5377000,
            UncachedInputTokens = 1284500,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsUsageUsersItem
        {
            Actor = new()
            {
                Deleted = true,
                EmailAddress = "jane@example.com",
                Name = "Jane Smith",
                UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
            },
            CacheCreation = new() { Ephemeral1hInputTokens = 0, Ephemeral5mInputTokens = 0 },
            CacheReadInputTokens = 3200000,
            ClaudeTagCategory = BetaAnalyticsClaudeTagCategory.Dm,
            ClaudeTagUserID = "U0123ABCDEF",
            ContextWindow = BetaAnalyticsContextWindow.From0To200k,
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InferenceGeo = BetaAnalyticsUsageUsersItemInferenceGeo.Global,
            Model = "claude-opus-5",
            OutputTokens = 891000,
            Product = "chat",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            Requests = 128,
            ServerToolUse = new(10),
            SlackChannelID = "C0123ABCDEF",
            Speed = BetaAnalyticsUsageUsersItemSpeed.Fast,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TotalTokens = 5377000,
            UncachedInputTokens = 1284500,
        };

        BetaAnalyticsUsageUsersItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaAnalyticsUsageUsersItemInferenceGeoTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsUsageUsersItemInferenceGeo.Global)]
    [InlineData(BetaAnalyticsUsageUsersItemInferenceGeo.Us)]
    public void Validation_Works(BetaAnalyticsUsageUsersItemInferenceGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsUsageUsersItemInferenceGeo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsUsageUsersItemInferenceGeo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsUsageUsersItemInferenceGeo.Global)]
    [InlineData(BetaAnalyticsUsageUsersItemInferenceGeo.Us)]
    public void SerializationRoundtrip_Works(BetaAnalyticsUsageUsersItemInferenceGeo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsUsageUsersItemInferenceGeo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsUsageUsersItemInferenceGeo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsUsageUsersItemInferenceGeo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsUsageUsersItemInferenceGeo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaAnalyticsUsageUsersItemSpeedTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsUsageUsersItemSpeed.Fast)]
    [InlineData(BetaAnalyticsUsageUsersItemSpeed.Standard)]
    public void Validation_Works(BetaAnalyticsUsageUsersItemSpeed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsUsageUsersItemSpeed> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsUsageUsersItemSpeed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsUsageUsersItemSpeed.Fast)]
    [InlineData(BetaAnalyticsUsageUsersItemSpeed.Standard)]
    public void SerializationRoundtrip_Works(BetaAnalyticsUsageUsersItemSpeed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsUsageUsersItemSpeed> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsUsageUsersItemSpeed>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaAnalyticsUsageUsersItemSpeed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsUsageUsersItemSpeed>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
