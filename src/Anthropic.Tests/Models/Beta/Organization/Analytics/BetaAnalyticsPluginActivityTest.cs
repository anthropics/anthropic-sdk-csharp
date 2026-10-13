using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsPluginActivityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsPluginActivity
        {
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            InstallCount = 0,
            InvocationCount = 0,
            PluginName = "plugin_name",
            ChatCoworkUnifiedMetrics = new(0),
            PluginID = "plugin_id",
            Product = "product",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            UserID = "user_id",
        };

        BetaAnalyticsPluginClaudeCodeMetrics expectedClaudeCodeMetrics = new(0);
        BetaAnalyticsPluginCoworkMetrics expectedCoworkMetrics = new(0);
        long expectedDistinctUserCount = 0;
        long expectedInstallCount = 0;
        long expectedInvocationCount = 0;
        string expectedPluginName = "plugin_name";
        BetaAnalyticsPluginActivityChatCoworkUnifiedMetrics expectedChatCoworkUnifiedMetrics = new(
            0
        );
        string expectedPluginID = "plugin_id";
        string expectedProduct = "product";
        string expectedRbacGroupID = "rbac_group_id";
        string expectedRbacGroupName = "rbac_group_name";
        string expectedUserID = "user_id";

        Assert.Equal(expectedClaudeCodeMetrics, model.ClaudeCodeMetrics);
        Assert.Equal(expectedCoworkMetrics, model.CoworkMetrics);
        Assert.Equal(expectedDistinctUserCount, model.DistinctUserCount);
        Assert.Equal(expectedInstallCount, model.InstallCount);
        Assert.Equal(expectedInvocationCount, model.InvocationCount);
        Assert.Equal(expectedPluginName, model.PluginName);
        Assert.Equal(expectedChatCoworkUnifiedMetrics, model.ChatCoworkUnifiedMetrics);
        Assert.Equal(expectedPluginID, model.PluginID);
        Assert.Equal(expectedProduct, model.Product);
        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.Equal(expectedRbacGroupName, model.RbacGroupName);
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsPluginActivity
        {
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            InstallCount = 0,
            InvocationCount = 0,
            PluginName = "plugin_name",
            ChatCoworkUnifiedMetrics = new(0),
            PluginID = "plugin_id",
            Product = "product",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            UserID = "user_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsPluginActivity>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsPluginActivity
        {
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            InstallCount = 0,
            InvocationCount = 0,
            PluginName = "plugin_name",
            ChatCoworkUnifiedMetrics = new(0),
            PluginID = "plugin_id",
            Product = "product",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            UserID = "user_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsPluginActivity>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaAnalyticsPluginClaudeCodeMetrics expectedClaudeCodeMetrics = new(0);
        BetaAnalyticsPluginCoworkMetrics expectedCoworkMetrics = new(0);
        long expectedDistinctUserCount = 0;
        long expectedInstallCount = 0;
        long expectedInvocationCount = 0;
        string expectedPluginName = "plugin_name";
        BetaAnalyticsPluginActivityChatCoworkUnifiedMetrics expectedChatCoworkUnifiedMetrics = new(
            0
        );
        string expectedPluginID = "plugin_id";
        string expectedProduct = "product";
        string expectedRbacGroupID = "rbac_group_id";
        string expectedRbacGroupName = "rbac_group_name";
        string expectedUserID = "user_id";

        Assert.Equal(expectedClaudeCodeMetrics, deserialized.ClaudeCodeMetrics);
        Assert.Equal(expectedCoworkMetrics, deserialized.CoworkMetrics);
        Assert.Equal(expectedDistinctUserCount, deserialized.DistinctUserCount);
        Assert.Equal(expectedInstallCount, deserialized.InstallCount);
        Assert.Equal(expectedInvocationCount, deserialized.InvocationCount);
        Assert.Equal(expectedPluginName, deserialized.PluginName);
        Assert.Equal(expectedChatCoworkUnifiedMetrics, deserialized.ChatCoworkUnifiedMetrics);
        Assert.Equal(expectedPluginID, deserialized.PluginID);
        Assert.Equal(expectedProduct, deserialized.Product);
        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.Equal(expectedRbacGroupName, deserialized.RbacGroupName);
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsPluginActivity
        {
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            InstallCount = 0,
            InvocationCount = 0,
            PluginName = "plugin_name",
            ChatCoworkUnifiedMetrics = new(0),
            PluginID = "plugin_id",
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
        var model = new BetaAnalyticsPluginActivity
        {
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            InstallCount = 0,
            InvocationCount = 0,
            PluginName = "plugin_name",
        };

        Assert.Null(model.ChatCoworkUnifiedMetrics);
        Assert.False(model.RawData.ContainsKey("chat_cowork_unified_metrics"));
        Assert.Null(model.PluginID);
        Assert.False(model.RawData.ContainsKey("plugin_id"));
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
        var model = new BetaAnalyticsPluginActivity
        {
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            InstallCount = 0,
            InvocationCount = 0,
            PluginName = "plugin_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaAnalyticsPluginActivity
        {
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            InstallCount = 0,
            InvocationCount = 0,
            PluginName = "plugin_name",

            ChatCoworkUnifiedMetrics = null,
            PluginID = null,
            Product = null,
            RbacGroupID = null,
            RbacGroupName = null,
            UserID = null,
        };

        Assert.Null(model.ChatCoworkUnifiedMetrics);
        Assert.True(model.RawData.ContainsKey("chat_cowork_unified_metrics"));
        Assert.Null(model.PluginID);
        Assert.True(model.RawData.ContainsKey("plugin_id"));
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
        var model = new BetaAnalyticsPluginActivity
        {
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            InstallCount = 0,
            InvocationCount = 0,
            PluginName = "plugin_name",

            ChatCoworkUnifiedMetrics = null,
            PluginID = null,
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
        var model = new BetaAnalyticsPluginActivity
        {
            ClaudeCodeMetrics = new(0),
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            InstallCount = 0,
            InvocationCount = 0,
            PluginName = "plugin_name",
            ChatCoworkUnifiedMetrics = new(0),
            PluginID = "plugin_id",
            Product = "product",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            UserID = "user_id",
        };

        BetaAnalyticsPluginActivity copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaAnalyticsPluginActivityChatCoworkUnifiedMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsPluginActivityChatCoworkUnifiedMetrics
        {
            DistinctSessionPluginUsedCount = 0,
        };

        long expectedDistinctSessionPluginUsedCount = 0;

        Assert.Equal(expectedDistinctSessionPluginUsedCount, model.DistinctSessionPluginUsedCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsPluginActivityChatCoworkUnifiedMetrics
        {
            DistinctSessionPluginUsedCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsPluginActivityChatCoworkUnifiedMetrics>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsPluginActivityChatCoworkUnifiedMetrics
        {
            DistinctSessionPluginUsedCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsPluginActivityChatCoworkUnifiedMetrics>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedDistinctSessionPluginUsedCount = 0;

        Assert.Equal(
            expectedDistinctSessionPluginUsedCount,
            deserialized.DistinctSessionPluginUsedCount
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsPluginActivityChatCoworkUnifiedMetrics
        {
            DistinctSessionPluginUsedCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsPluginActivityChatCoworkUnifiedMetrics
        {
            DistinctSessionPluginUsedCount = 0,
        };

        BetaAnalyticsPluginActivityChatCoworkUnifiedMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
