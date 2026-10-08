using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;
using Anthropic.Models.Beta.Organization.Analytics.Skills;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Skills;

public class SkillListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SkillListPageResponse
        {
            Data =
            [
                new()
                {
                    ChatMetrics = new(0),
                    ClaudeCodeMetrics = new(0),
                    CoworkMetrics = new(0),
                    DistinctUserCount = 0,
                    OfficeMetrics = new()
                    {
                        Excel = new(0),
                        Outlook = new(0),
                        Powerpoint = new(0),
                        Word = new(0),
                    },
                    SkillName = "skill_name",
                    AttributedListPrice = "attributed_list_price",
                    ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
                    Currency = "currency",
                    EnableCount = 0,
                    EstimatedOverageSpend = "estimated_overage_spend",
                    InvocationCount = 0,
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    ShareStatus = ShareStatus.Organization,
                    SkillDisplayName = "skill_display_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        List<BetaAnalyticsSkillActivity> expectedData =
        [
            new()
            {
                ChatMetrics = new(0),
                ClaudeCodeMetrics = new(0),
                CoworkMetrics = new(0),
                DistinctUserCount = 0,
                OfficeMetrics = new()
                {
                    Excel = new(0),
                    Outlook = new(0),
                    Powerpoint = new(0),
                    Word = new(0),
                },
                SkillName = "skill_name",
                AttributedListPrice = "attributed_list_price",
                ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
                Currency = "currency",
                EnableCount = 0,
                EstimatedOverageSpend = "estimated_overage_spend",
                InvocationCount = 0,
                Product = "product",
                RbacGroupID = "rbac_group_id",
                RbacGroupName = "rbac_group_name",
                ShareStatus = ShareStatus.Organization,
                SkillDisplayName = "skill_display_name",
                UserID = "user_id",
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SkillListPageResponse
        {
            Data =
            [
                new()
                {
                    ChatMetrics = new(0),
                    ClaudeCodeMetrics = new(0),
                    CoworkMetrics = new(0),
                    DistinctUserCount = 0,
                    OfficeMetrics = new()
                    {
                        Excel = new(0),
                        Outlook = new(0),
                        Powerpoint = new(0),
                        Word = new(0),
                    },
                    SkillName = "skill_name",
                    AttributedListPrice = "attributed_list_price",
                    ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
                    Currency = "currency",
                    EnableCount = 0,
                    EstimatedOverageSpend = "estimated_overage_spend",
                    InvocationCount = 0,
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    ShareStatus = ShareStatus.Organization,
                    SkillDisplayName = "skill_display_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SkillListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SkillListPageResponse
        {
            Data =
            [
                new()
                {
                    ChatMetrics = new(0),
                    ClaudeCodeMetrics = new(0),
                    CoworkMetrics = new(0),
                    DistinctUserCount = 0,
                    OfficeMetrics = new()
                    {
                        Excel = new(0),
                        Outlook = new(0),
                        Powerpoint = new(0),
                        Word = new(0),
                    },
                    SkillName = "skill_name",
                    AttributedListPrice = "attributed_list_price",
                    ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
                    Currency = "currency",
                    EnableCount = 0,
                    EstimatedOverageSpend = "estimated_overage_spend",
                    InvocationCount = 0,
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    ShareStatus = ShareStatus.Organization,
                    SkillDisplayName = "skill_display_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SkillListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaAnalyticsSkillActivity> expectedData =
        [
            new()
            {
                ChatMetrics = new(0),
                ClaudeCodeMetrics = new(0),
                CoworkMetrics = new(0),
                DistinctUserCount = 0,
                OfficeMetrics = new()
                {
                    Excel = new(0),
                    Outlook = new(0),
                    Powerpoint = new(0),
                    Word = new(0),
                },
                SkillName = "skill_name",
                AttributedListPrice = "attributed_list_price",
                ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
                Currency = "currency",
                EnableCount = 0,
                EstimatedOverageSpend = "estimated_overage_spend",
                InvocationCount = 0,
                Product = "product",
                RbacGroupID = "rbac_group_id",
                RbacGroupName = "rbac_group_name",
                ShareStatus = ShareStatus.Organization,
                SkillDisplayName = "skill_display_name",
                UserID = "user_id",
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SkillListPageResponse
        {
            Data =
            [
                new()
                {
                    ChatMetrics = new(0),
                    ClaudeCodeMetrics = new(0),
                    CoworkMetrics = new(0),
                    DistinctUserCount = 0,
                    OfficeMetrics = new()
                    {
                        Excel = new(0),
                        Outlook = new(0),
                        Powerpoint = new(0),
                        Word = new(0),
                    },
                    SkillName = "skill_name",
                    AttributedListPrice = "attributed_list_price",
                    ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
                    Currency = "currency",
                    EnableCount = 0,
                    EstimatedOverageSpend = "estimated_overage_spend",
                    InvocationCount = 0,
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    ShareStatus = ShareStatus.Organization,
                    SkillDisplayName = "skill_display_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SkillListPageResponse
        {
            Data =
            [
                new()
                {
                    ChatMetrics = new(0),
                    ClaudeCodeMetrics = new(0),
                    CoworkMetrics = new(0),
                    DistinctUserCount = 0,
                    OfficeMetrics = new()
                    {
                        Excel = new(0),
                        Outlook = new(0),
                        Powerpoint = new(0),
                        Word = new(0),
                    },
                    SkillName = "skill_name",
                    AttributedListPrice = "attributed_list_price",
                    ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
                    Currency = "currency",
                    EnableCount = 0,
                    EstimatedOverageSpend = "estimated_overage_spend",
                    InvocationCount = 0,
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    ShareStatus = ShareStatus.Organization,
                    SkillDisplayName = "skill_display_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        SkillListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
