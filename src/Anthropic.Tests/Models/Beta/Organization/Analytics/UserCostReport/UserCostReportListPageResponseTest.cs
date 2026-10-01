using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;
using Anthropic.Models.Beta.Organization.Analytics.UserCostReport;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.UserCostReport;

public class UserCostReportListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserCostReportListPageResponse
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
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
            OrganizationID = "org_013FP9SaFPBg7Kw7fetjn6cF",
        };

        List<BetaAnalyticsCostUsersItem> expectedData =
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
        var model = new UserCostReportListPageResponse
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
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
            OrganizationID = "org_013FP9SaFPBg7Kw7fetjn6cF",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserCostReportListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserCostReportListPageResponse
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
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
            OrganizationID = "org_013FP9SaFPBg7Kw7fetjn6cF",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserCostReportListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaAnalyticsCostUsersItem> expectedData =
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
        var model = new UserCostReportListPageResponse
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
        var model = new UserCostReportListPageResponse
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
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
            OrganizationID = "org_013FP9SaFPBg7Kw7fetjn6cF",
        };

        UserCostReportListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
