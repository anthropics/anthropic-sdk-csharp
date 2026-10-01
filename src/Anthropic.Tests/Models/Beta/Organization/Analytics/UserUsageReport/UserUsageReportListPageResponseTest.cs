using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;
using Anthropic.Models.Beta.Organization.Analytics.UserUsageReport;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.UserUsageReport;

public class UserUsageReportListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserUsageReportListPageResponse
        {
            Data =
            [
                new()
                {
                    Actor = new()
                    {
                        Deleted = true,
                        EmailAddress = "jane@example.com",
                        Name = "Jane Smith",
                        UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
                    },
                    CacheCreation = new()
                    {
                        Ephemeral1hInputTokens = 0,
                        Ephemeral5mInputTokens = 0,
                    },
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
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
            OrganizationID = "org_013FP9SaFPBg7Kw7fetjn6cF",
        };

        List<BetaAnalyticsUsageUsersItem> expectedData =
        [
            new()
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
            },
        ];
        DateTimeOffset expectedDataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedHasMore = true;
        string expectedNextPage = "next_page";
        string expectedOrganizationID = "org_013FP9SaFPBg7Kw7fetjn6cF";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedDataRefreshedAt, model.DataRefreshedAt);
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedNextPage, model.NextPage);
        Assert.Equal(expectedOrganizationID, model.OrganizationID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserUsageReportListPageResponse
        {
            Data =
            [
                new()
                {
                    Actor = new()
                    {
                        Deleted = true,
                        EmailAddress = "jane@example.com",
                        Name = "Jane Smith",
                        UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
                    },
                    CacheCreation = new()
                    {
                        Ephemeral1hInputTokens = 0,
                        Ephemeral5mInputTokens = 0,
                    },
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
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
            OrganizationID = "org_013FP9SaFPBg7Kw7fetjn6cF",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserUsageReportListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserUsageReportListPageResponse
        {
            Data =
            [
                new()
                {
                    Actor = new()
                    {
                        Deleted = true,
                        EmailAddress = "jane@example.com",
                        Name = "Jane Smith",
                        UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
                    },
                    CacheCreation = new()
                    {
                        Ephemeral1hInputTokens = 0,
                        Ephemeral5mInputTokens = 0,
                    },
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
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
            OrganizationID = "org_013FP9SaFPBg7Kw7fetjn6cF",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserUsageReportListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaAnalyticsUsageUsersItem> expectedData =
        [
            new()
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
            },
        ];
        DateTimeOffset expectedDataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedHasMore = true;
        string expectedNextPage = "next_page";
        string expectedOrganizationID = "org_013FP9SaFPBg7Kw7fetjn6cF";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedDataRefreshedAt, deserialized.DataRefreshedAt);
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedNextPage, deserialized.NextPage);
        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserUsageReportListPageResponse
        {
            Data =
            [
                new()
                {
                    Actor = new()
                    {
                        Deleted = true,
                        EmailAddress = "jane@example.com",
                        Name = "Jane Smith",
                        UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
                    },
                    CacheCreation = new()
                    {
                        Ephemeral1hInputTokens = 0,
                        Ephemeral5mInputTokens = 0,
                    },
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
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
            OrganizationID = "org_013FP9SaFPBg7Kw7fetjn6cF",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserUsageReportListPageResponse
        {
            Data =
            [
                new()
                {
                    Actor = new()
                    {
                        Deleted = true,
                        EmailAddress = "jane@example.com",
                        Name = "Jane Smith",
                        UserID = "user_01AbCdEfGhIjKlMnOpQrSt",
                    },
                    CacheCreation = new()
                    {
                        Ephemeral1hInputTokens = 0,
                        Ephemeral5mInputTokens = 0,
                    },
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
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
            OrganizationID = "org_013FP9SaFPBg7Kw7fetjn6cF",
        };

        UserUsageReportListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
