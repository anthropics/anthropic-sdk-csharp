using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.CostReport;
using Analytics = Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.CostReport;

public class CostReportListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CostReportListPageResponse
        {
            Data =
            [
                new()
                {
                    EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Results =
                    [
                        new()
                        {
                            Amount = "amount",
                            ClaudeTagCategory = Analytics::BetaAnalyticsClaudeTagCategory.Dm,
                            ClaudeTagUserID = "U0123ABCDEF",
                            ContextWindow = Analytics::BetaAnalyticsContextWindow.From0To200k,
                            CostType = Analytics::BetaAnalyticsCostType.CodeExecution,
                            Currency = "USD",
                            InferenceGeo = Analytics::InferenceGeo.Global,
                            ListAmount = "list_amount",
                            Model = "claude-opus-5",
                            Product = "chat",
                            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                            Requests = 0,
                            SlackChannelID = "C0123ABCDEF",
                            Speed = Analytics::Speed.Fast,
                            TokenType =
                                Analytics::BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                        },
                    ],
                    StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
            OrganizationID = "org_013FP9SaFPBg7Kw7fetjn6cF",
        };

        List<Analytics::BetaAnalyticsCostReportTimeBucket> expectedData =
        [
            new()
            {
                EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Results =
                [
                    new()
                    {
                        Amount = "amount",
                        ClaudeTagCategory = Analytics::BetaAnalyticsClaudeTagCategory.Dm,
                        ClaudeTagUserID = "U0123ABCDEF",
                        ContextWindow = Analytics::BetaAnalyticsContextWindow.From0To200k,
                        CostType = Analytics::BetaAnalyticsCostType.CodeExecution,
                        Currency = "USD",
                        InferenceGeo = Analytics::InferenceGeo.Global,
                        ListAmount = "list_amount",
                        Model = "claude-opus-5",
                        Product = "chat",
                        RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                        Requests = 0,
                        SlackChannelID = "C0123ABCDEF",
                        Speed = Analytics::Speed.Fast,
                        TokenType =
                            Analytics::BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                    },
                ],
                StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new CostReportListPageResponse
        {
            Data =
            [
                new()
                {
                    EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Results =
                    [
                        new()
                        {
                            Amount = "amount",
                            ClaudeTagCategory = Analytics::BetaAnalyticsClaudeTagCategory.Dm,
                            ClaudeTagUserID = "U0123ABCDEF",
                            ContextWindow = Analytics::BetaAnalyticsContextWindow.From0To200k,
                            CostType = Analytics::BetaAnalyticsCostType.CodeExecution,
                            Currency = "USD",
                            InferenceGeo = Analytics::InferenceGeo.Global,
                            ListAmount = "list_amount",
                            Model = "claude-opus-5",
                            Product = "chat",
                            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                            Requests = 0,
                            SlackChannelID = "C0123ABCDEF",
                            Speed = Analytics::Speed.Fast,
                            TokenType =
                                Analytics::BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                        },
                    ],
                    StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
            OrganizationID = "org_013FP9SaFPBg7Kw7fetjn6cF",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CostReportListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CostReportListPageResponse
        {
            Data =
            [
                new()
                {
                    EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Results =
                    [
                        new()
                        {
                            Amount = "amount",
                            ClaudeTagCategory = Analytics::BetaAnalyticsClaudeTagCategory.Dm,
                            ClaudeTagUserID = "U0123ABCDEF",
                            ContextWindow = Analytics::BetaAnalyticsContextWindow.From0To200k,
                            CostType = Analytics::BetaAnalyticsCostType.CodeExecution,
                            Currency = "USD",
                            InferenceGeo = Analytics::InferenceGeo.Global,
                            ListAmount = "list_amount",
                            Model = "claude-opus-5",
                            Product = "chat",
                            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                            Requests = 0,
                            SlackChannelID = "C0123ABCDEF",
                            Speed = Analytics::Speed.Fast,
                            TokenType =
                                Analytics::BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                        },
                    ],
                    StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
            OrganizationID = "org_013FP9SaFPBg7Kw7fetjn6cF",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CostReportListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Analytics::BetaAnalyticsCostReportTimeBucket> expectedData =
        [
            new()
            {
                EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Results =
                [
                    new()
                    {
                        Amount = "amount",
                        ClaudeTagCategory = Analytics::BetaAnalyticsClaudeTagCategory.Dm,
                        ClaudeTagUserID = "U0123ABCDEF",
                        ContextWindow = Analytics::BetaAnalyticsContextWindow.From0To200k,
                        CostType = Analytics::BetaAnalyticsCostType.CodeExecution,
                        Currency = "USD",
                        InferenceGeo = Analytics::InferenceGeo.Global,
                        ListAmount = "list_amount",
                        Model = "claude-opus-5",
                        Product = "chat",
                        RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                        Requests = 0,
                        SlackChannelID = "C0123ABCDEF",
                        Speed = Analytics::Speed.Fast,
                        TokenType =
                            Analytics::BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                    },
                ],
                StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new CostReportListPageResponse
        {
            Data =
            [
                new()
                {
                    EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Results =
                    [
                        new()
                        {
                            Amount = "amount",
                            ClaudeTagCategory = Analytics::BetaAnalyticsClaudeTagCategory.Dm,
                            ClaudeTagUserID = "U0123ABCDEF",
                            ContextWindow = Analytics::BetaAnalyticsContextWindow.From0To200k,
                            CostType = Analytics::BetaAnalyticsCostType.CodeExecution,
                            Currency = "USD",
                            InferenceGeo = Analytics::InferenceGeo.Global,
                            ListAmount = "list_amount",
                            Model = "claude-opus-5",
                            Product = "chat",
                            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                            Requests = 0,
                            SlackChannelID = "C0123ABCDEF",
                            Speed = Analytics::Speed.Fast,
                            TokenType =
                                Analytics::BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                        },
                    ],
                    StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new CostReportListPageResponse
        {
            Data =
            [
                new()
                {
                    EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Results =
                    [
                        new()
                        {
                            Amount = "amount",
                            ClaudeTagCategory = Analytics::BetaAnalyticsClaudeTagCategory.Dm,
                            ClaudeTagUserID = "U0123ABCDEF",
                            ContextWindow = Analytics::BetaAnalyticsContextWindow.From0To200k,
                            CostType = Analytics::BetaAnalyticsCostType.CodeExecution,
                            Currency = "USD",
                            InferenceGeo = Analytics::InferenceGeo.Global,
                            ListAmount = "list_amount",
                            Model = "claude-opus-5",
                            Product = "chat",
                            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                            Requests = 0,
                            SlackChannelID = "C0123ABCDEF",
                            Speed = Analytics::Speed.Fast,
                            TokenType =
                                Analytics::BetaAnalyticsTokenType.CacheCreationEphemeral1hInputTokens,
                        },
                    ],
                    StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            DataRefreshedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HasMore = true,
            NextPage = "next_page",
            OrganizationID = "org_013FP9SaFPBg7Kw7fetjn6cF",
        };

        CostReportListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
