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
        };

        BetaAnalyticsSkillChatMetrics expectedChatMetrics = new(0);
        BetaAnalyticsSkillClaudeCodeMetrics expectedClaudeCodeMetrics = new(0);
        BetaAnalyticsSkillCoworkMetrics expectedCoworkMetrics = new(0);
        long expectedDistinctUserCount = 0;
        BetaAnalyticsSkillOfficeMetrics expectedOfficeMetrics = new()
        {
            Excel = new(0),
            Outlook = new(0),
            Powerpoint = new(0),
            Word = new(0),
        };
        string expectedSkillName = "skill_name";
        string expectedAttributedListPrice = "attributed_list_price";
        BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics expectedChatCoworkUnifiedMetrics = new()
        {
            Chat = new(0),
            Sessions = new(0),
        };
        string expectedCurrency = "currency";
        long expectedEnableCount = 0;
        string expectedEstimatedOverageSpend = "estimated_overage_spend";
        long expectedInvocationCount = 0;
        string expectedProduct = "product";
        string expectedRbacGroupID = "rbac_group_id";
        string expectedRbacGroupName = "rbac_group_name";
        ApiEnum<string, ShareStatus> expectedShareStatus = ShareStatus.Organization;
        string expectedSkillDisplayName = "skill_display_name";
        string expectedUserID = "user_id";

        Assert.Equal(expectedChatMetrics, model.ChatMetrics);
        Assert.Equal(expectedClaudeCodeMetrics, model.ClaudeCodeMetrics);
        Assert.Equal(expectedCoworkMetrics, model.CoworkMetrics);
        Assert.Equal(expectedDistinctUserCount, model.DistinctUserCount);
        Assert.Equal(expectedOfficeMetrics, model.OfficeMetrics);
        Assert.Equal(expectedSkillName, model.SkillName);
        Assert.Equal(expectedAttributedListPrice, model.AttributedListPrice);
        Assert.Equal(expectedChatCoworkUnifiedMetrics, model.ChatCoworkUnifiedMetrics);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedEnableCount, model.EnableCount);
        Assert.Equal(expectedEstimatedOverageSpend, model.EstimatedOverageSpend);
        Assert.Equal(expectedInvocationCount, model.InvocationCount);
        Assert.Equal(expectedProduct, model.Product);
        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.Equal(expectedRbacGroupName, model.RbacGroupName);
        Assert.Equal(expectedShareStatus, model.ShareStatus);
        Assert.Equal(expectedSkillDisplayName, model.SkillDisplayName);
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsSkillActivity
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsSkillActivity>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaAnalyticsSkillChatMetrics expectedChatMetrics = new(0);
        BetaAnalyticsSkillClaudeCodeMetrics expectedClaudeCodeMetrics = new(0);
        BetaAnalyticsSkillCoworkMetrics expectedCoworkMetrics = new(0);
        long expectedDistinctUserCount = 0;
        BetaAnalyticsSkillOfficeMetrics expectedOfficeMetrics = new()
        {
            Excel = new(0),
            Outlook = new(0),
            Powerpoint = new(0),
            Word = new(0),
        };
        string expectedSkillName = "skill_name";
        string expectedAttributedListPrice = "attributed_list_price";
        BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics expectedChatCoworkUnifiedMetrics = new()
        {
            Chat = new(0),
            Sessions = new(0),
        };
        string expectedCurrency = "currency";
        long expectedEnableCount = 0;
        string expectedEstimatedOverageSpend = "estimated_overage_spend";
        long expectedInvocationCount = 0;
        string expectedProduct = "product";
        string expectedRbacGroupID = "rbac_group_id";
        string expectedRbacGroupName = "rbac_group_name";
        ApiEnum<string, ShareStatus> expectedShareStatus = ShareStatus.Organization;
        string expectedSkillDisplayName = "skill_display_name";
        string expectedUserID = "user_id";

        Assert.Equal(expectedChatMetrics, deserialized.ChatMetrics);
        Assert.Equal(expectedClaudeCodeMetrics, deserialized.ClaudeCodeMetrics);
        Assert.Equal(expectedCoworkMetrics, deserialized.CoworkMetrics);
        Assert.Equal(expectedDistinctUserCount, deserialized.DistinctUserCount);
        Assert.Equal(expectedOfficeMetrics, deserialized.OfficeMetrics);
        Assert.Equal(expectedSkillName, deserialized.SkillName);
        Assert.Equal(expectedAttributedListPrice, deserialized.AttributedListPrice);
        Assert.Equal(expectedChatCoworkUnifiedMetrics, deserialized.ChatCoworkUnifiedMetrics);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedEnableCount, deserialized.EnableCount);
        Assert.Equal(expectedEstimatedOverageSpend, deserialized.EstimatedOverageSpend);
        Assert.Equal(expectedInvocationCount, deserialized.InvocationCount);
        Assert.Equal(expectedProduct, deserialized.Product);
        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.Equal(expectedRbacGroupName, deserialized.RbacGroupName);
        Assert.Equal(expectedShareStatus, deserialized.ShareStatus);
        Assert.Equal(expectedSkillDisplayName, deserialized.SkillDisplayName);
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsSkillActivity
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaAnalyticsSkillActivity
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
        };

        Assert.Null(model.AttributedListPrice);
        Assert.False(model.RawData.ContainsKey("attributed_list_price"));
        Assert.Null(model.ChatCoworkUnifiedMetrics);
        Assert.False(model.RawData.ContainsKey("chat_cowork_unified_metrics"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.EnableCount);
        Assert.False(model.RawData.ContainsKey("enable_count"));
        Assert.Null(model.EstimatedOverageSpend);
        Assert.False(model.RawData.ContainsKey("estimated_overage_spend"));
        Assert.Null(model.InvocationCount);
        Assert.False(model.RawData.ContainsKey("invocation_count"));
        Assert.Null(model.Product);
        Assert.False(model.RawData.ContainsKey("product"));
        Assert.Null(model.RbacGroupID);
        Assert.False(model.RawData.ContainsKey("rbac_group_id"));
        Assert.Null(model.RbacGroupName);
        Assert.False(model.RawData.ContainsKey("rbac_group_name"));
        Assert.Null(model.ShareStatus);
        Assert.False(model.RawData.ContainsKey("share_status"));
        Assert.Null(model.SkillDisplayName);
        Assert.False(model.RawData.ContainsKey("skill_display_name"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaAnalyticsSkillActivity
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaAnalyticsSkillActivity
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

            AttributedListPrice = null,
            ChatCoworkUnifiedMetrics = null,
            Currency = null,
            EnableCount = null,
            EstimatedOverageSpend = null,
            InvocationCount = null,
            Product = null,
            RbacGroupID = null,
            RbacGroupName = null,
            ShareStatus = null,
            SkillDisplayName = null,
            UserID = null,
        };

        Assert.Null(model.AttributedListPrice);
        Assert.True(model.RawData.ContainsKey("attributed_list_price"));
        Assert.Null(model.ChatCoworkUnifiedMetrics);
        Assert.True(model.RawData.ContainsKey("chat_cowork_unified_metrics"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.EnableCount);
        Assert.True(model.RawData.ContainsKey("enable_count"));
        Assert.Null(model.EstimatedOverageSpend);
        Assert.True(model.RawData.ContainsKey("estimated_overage_spend"));
        Assert.Null(model.InvocationCount);
        Assert.True(model.RawData.ContainsKey("invocation_count"));
        Assert.Null(model.Product);
        Assert.True(model.RawData.ContainsKey("product"));
        Assert.Null(model.RbacGroupID);
        Assert.True(model.RawData.ContainsKey("rbac_group_id"));
        Assert.Null(model.RbacGroupName);
        Assert.True(model.RawData.ContainsKey("rbac_group_name"));
        Assert.Null(model.ShareStatus);
        Assert.True(model.RawData.ContainsKey("share_status"));
        Assert.Null(model.SkillDisplayName);
        Assert.True(model.RawData.ContainsKey("skill_display_name"));
        Assert.Null(model.UserID);
        Assert.True(model.RawData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaAnalyticsSkillActivity
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

            AttributedListPrice = null,
            ChatCoworkUnifiedMetrics = null,
            Currency = null,
            EnableCount = null,
            EstimatedOverageSpend = null,
            InvocationCount = null,
            Product = null,
            RbacGroupID = null,
            RbacGroupName = null,
            ShareStatus = null,
            SkillDisplayName = null,
            UserID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsSkillActivity
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
        };

        BetaAnalyticsSkillActivity copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaAnalyticsSkillActivityChatCoworkUnifiedMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        BetaAnalyticsSkillChatCoworkUnifiedChatMetrics expectedChat = new(0);
        BetaAnalyticsSkillChatCoworkUnifiedSessionsMetrics expectedSessions = new(0);

        Assert.Equal(expectedChat, model.Chat);
        Assert.Equal(expectedSessions, model.Sessions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        BetaAnalyticsSkillChatCoworkUnifiedChatMetrics expectedChat = new(0);
        BetaAnalyticsSkillChatCoworkUnifiedSessionsMetrics expectedSessions = new(0);

        Assert.Equal(expectedChat, deserialized.Chat);
        Assert.Equal(expectedSessions, deserialized.Sessions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics
        {
            Chat = new(0),
            Sessions = new(0),
        };

        BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics copied = new(model);

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
