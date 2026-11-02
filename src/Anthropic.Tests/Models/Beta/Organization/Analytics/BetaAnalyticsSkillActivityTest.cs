using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsSkillActivityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsSkillActivity
        {
            AttributedListPrice = "attributed_list_price",
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            Currency = "currency",
            DistinctUserCount = 0,
            EnableCount = 0,
            EstimatedOverageSpend = "estimated_overage_spend",
            InvocationCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ShareStatus = ShareStatus.Organization,
            SkillDisplayName = "skill_display_name",
            SkillName = "skill_name",
            ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
            Product = "product",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            UserID = "user_id",
        };

        string expectedAttributedListPrice = "attributed_list_price";
        BetaAnalyticsSkillChatMetrics expectedChatMetrics = new(0);
        BetaAnalyticsSkillClaudeCodeMetrics expectedClaudeCodeMetrics = new(0);
        BetaAnalyticsSkillCoworkMetrics expectedCoworkMetrics = new(0);
        string expectedCurrency = "currency";
        long expectedDistinctUserCount = 0;
        long expectedEnableCount = 0;
        string expectedEstimatedOverageSpend = "estimated_overage_spend";
        long expectedInvocationCount = 0;
        BetaAnalyticsSkillOfficeMetrics expectedOfficeMetrics = new()
        {
            Excel = new(0),
            Outlook = new(0),
            Powerpoint = new(0),
            Word = new(0),
        };
        ApiEnum<string, ShareStatus> expectedShareStatus = ShareStatus.Organization;
        string expectedSkillDisplayName = "skill_display_name";
        string expectedSkillName = "skill_name";
        BetaAnalyticsSkillChatCoworkUnifiedMetrics expectedChatCoworkUnifiedMetrics = new()
        {
            Chat = new(0),
            Sessions = new(0),
        };
        string expectedProduct = "product";
        string expectedRbacGroupID = "rbac_group_id";
        string expectedRbacGroupName = "rbac_group_name";
        string expectedUserID = "user_id";

        Assert.Equal(expectedAttributedListPrice, model.AttributedListPrice);
        Assert.Equal(expectedChatMetrics, model.ChatMetrics);
        Assert.Equal(expectedClaudeCodeMetrics, model.ClaudeCodeMetrics);
        Assert.Equal(expectedCoworkMetrics, model.CoworkMetrics);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDistinctUserCount, model.DistinctUserCount);
        Assert.Equal(expectedEnableCount, model.EnableCount);
        Assert.Equal(expectedEstimatedOverageSpend, model.EstimatedOverageSpend);
        Assert.Equal(expectedInvocationCount, model.InvocationCount);
        Assert.Equal(expectedOfficeMetrics, model.OfficeMetrics);
        Assert.Equal(expectedShareStatus, model.ShareStatus);
        Assert.Equal(expectedSkillDisplayName, model.SkillDisplayName);
        Assert.Equal(expectedSkillName, model.SkillName);
        Assert.Equal(expectedChatCoworkUnifiedMetrics, model.ChatCoworkUnifiedMetrics);
        Assert.Equal(expectedProduct, model.Product);
        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.Equal(expectedRbacGroupName, model.RbacGroupName);
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsSkillActivity
        {
            AttributedListPrice = "attributed_list_price",
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            Currency = "currency",
            DistinctUserCount = 0,
            EnableCount = 0,
            EstimatedOverageSpend = "estimated_overage_spend",
            InvocationCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ShareStatus = ShareStatus.Organization,
            SkillDisplayName = "skill_display_name",
            SkillName = "skill_name",
            ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
            Product = "product",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            UserID = "user_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsSkillActivity>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsSkillActivity
        {
            AttributedListPrice = "attributed_list_price",
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            Currency = "currency",
            DistinctUserCount = 0,
            EnableCount = 0,
            EstimatedOverageSpend = "estimated_overage_spend",
            InvocationCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ShareStatus = ShareStatus.Organization,
            SkillDisplayName = "skill_display_name",
            SkillName = "skill_name",
            ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
            Product = "product",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            UserID = "user_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsSkillActivity>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAttributedListPrice = "attributed_list_price";
        BetaAnalyticsSkillChatMetrics expectedChatMetrics = new(0);
        BetaAnalyticsSkillClaudeCodeMetrics expectedClaudeCodeMetrics = new(0);
        BetaAnalyticsSkillCoworkMetrics expectedCoworkMetrics = new(0);
        string expectedCurrency = "currency";
        long expectedDistinctUserCount = 0;
        long expectedEnableCount = 0;
        string expectedEstimatedOverageSpend = "estimated_overage_spend";
        long expectedInvocationCount = 0;
        BetaAnalyticsSkillOfficeMetrics expectedOfficeMetrics = new()
        {
            Excel = new(0),
            Outlook = new(0),
            Powerpoint = new(0),
            Word = new(0),
        };
        ApiEnum<string, ShareStatus> expectedShareStatus = ShareStatus.Organization;
        string expectedSkillDisplayName = "skill_display_name";
        string expectedSkillName = "skill_name";
        BetaAnalyticsSkillChatCoworkUnifiedMetrics expectedChatCoworkUnifiedMetrics = new()
        {
            Chat = new(0),
            Sessions = new(0),
        };
        string expectedProduct = "product";
        string expectedRbacGroupID = "rbac_group_id";
        string expectedRbacGroupName = "rbac_group_name";
        string expectedUserID = "user_id";

        Assert.Equal(expectedAttributedListPrice, deserialized.AttributedListPrice);
        Assert.Equal(expectedChatMetrics, deserialized.ChatMetrics);
        Assert.Equal(expectedClaudeCodeMetrics, deserialized.ClaudeCodeMetrics);
        Assert.Equal(expectedCoworkMetrics, deserialized.CoworkMetrics);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDistinctUserCount, deserialized.DistinctUserCount);
        Assert.Equal(expectedEnableCount, deserialized.EnableCount);
        Assert.Equal(expectedEstimatedOverageSpend, deserialized.EstimatedOverageSpend);
        Assert.Equal(expectedInvocationCount, deserialized.InvocationCount);
        Assert.Equal(expectedOfficeMetrics, deserialized.OfficeMetrics);
        Assert.Equal(expectedShareStatus, deserialized.ShareStatus);
        Assert.Equal(expectedSkillDisplayName, deserialized.SkillDisplayName);
        Assert.Equal(expectedSkillName, deserialized.SkillName);
        Assert.Equal(expectedChatCoworkUnifiedMetrics, deserialized.ChatCoworkUnifiedMetrics);
        Assert.Equal(expectedProduct, deserialized.Product);
        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.Equal(expectedRbacGroupName, deserialized.RbacGroupName);
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsSkillActivity
        {
            AttributedListPrice = "attributed_list_price",
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            Currency = "currency",
            DistinctUserCount = 0,
            EnableCount = 0,
            EstimatedOverageSpend = "estimated_overage_spend",
            InvocationCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ShareStatus = ShareStatus.Organization,
            SkillDisplayName = "skill_display_name",
            SkillName = "skill_name",
            ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
            Product = "product",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            UserID = "user_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaAnalyticsSkillActivity
        {
            AttributedListPrice = "attributed_list_price",
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            Currency = "currency",
            DistinctUserCount = 0,
            EnableCount = 0,
            EstimatedOverageSpend = "estimated_overage_spend",
            InvocationCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ShareStatus = ShareStatus.Organization,
            SkillDisplayName = "skill_display_name",
            SkillName = "skill_name",
        };

        Assert.Null(model.ChatCoworkUnifiedMetrics);
        Assert.False(model.RawData.ContainsKey("chat_cowork_unified_metrics"));
        Assert.Null(model.Product);
        Assert.False(model.RawData.ContainsKey("product"));
        Assert.Null(model.RbacGroupID);
        Assert.False(model.RawData.ContainsKey("rbac_group_id"));
        Assert.Null(model.RbacGroupName);
        Assert.False(model.RawData.ContainsKey("rbac_group_name"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaAnalyticsSkillActivity
        {
            AttributedListPrice = "attributed_list_price",
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            Currency = "currency",
            DistinctUserCount = 0,
            EnableCount = 0,
            EstimatedOverageSpend = "estimated_overage_spend",
            InvocationCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ShareStatus = ShareStatus.Organization,
            SkillDisplayName = "skill_display_name",
            SkillName = "skill_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaAnalyticsSkillActivity
        {
            AttributedListPrice = "attributed_list_price",
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            Currency = "currency",
            DistinctUserCount = 0,
            EnableCount = 0,
            EstimatedOverageSpend = "estimated_overage_spend",
            InvocationCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ShareStatus = ShareStatus.Organization,
            SkillDisplayName = "skill_display_name",
            SkillName = "skill_name",

            ChatCoworkUnifiedMetrics = null,
            Product = null,
            RbacGroupID = null,
            RbacGroupName = null,
            UserID = null,
        };

        Assert.Null(model.ChatCoworkUnifiedMetrics);
        Assert.True(model.RawData.ContainsKey("chat_cowork_unified_metrics"));
        Assert.Null(model.Product);
        Assert.True(model.RawData.ContainsKey("product"));
        Assert.Null(model.RbacGroupID);
        Assert.True(model.RawData.ContainsKey("rbac_group_id"));
        Assert.Null(model.RbacGroupName);
        Assert.True(model.RawData.ContainsKey("rbac_group_name"));
        Assert.Null(model.UserID);
        Assert.True(model.RawData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaAnalyticsSkillActivity
        {
            AttributedListPrice = "attributed_list_price",
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            Currency = "currency",
            DistinctUserCount = 0,
            EnableCount = 0,
            EstimatedOverageSpend = "estimated_overage_spend",
            InvocationCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ShareStatus = ShareStatus.Organization,
            SkillDisplayName = "skill_display_name",
            SkillName = "skill_name",

            ChatCoworkUnifiedMetrics = null,
            Product = null,
            RbacGroupID = null,
            RbacGroupName = null,
            UserID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsSkillActivity
        {
            AttributedListPrice = "attributed_list_price",
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            Currency = "currency",
            DistinctUserCount = 0,
            EnableCount = 0,
            EstimatedOverageSpend = "estimated_overage_spend",
            InvocationCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ShareStatus = ShareStatus.Organization,
            SkillDisplayName = "skill_display_name",
            SkillName = "skill_name",
            ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
            Product = "product",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            UserID = "user_id",
        };

        BetaAnalyticsSkillActivity copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ShareStatusTest : TestBase
{
    [Theory]
    [InlineData(ShareStatus.Organization)]
    [InlineData(ShareStatus.Private)]
    [InlineData(ShareStatus.Public)]
    public void Validation_Works(ShareStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ShareStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ShareStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ShareStatus.Organization)]
    [InlineData(ShareStatus.Private)]
    [InlineData(ShareStatus.Public)]
    public void SerializationRoundtrip_Works(ShareStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ShareStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ShareStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ShareStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ShareStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
