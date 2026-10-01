using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;
using Anthropic.Models.Beta.Organization.Analytics.Plugins;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Plugins;

public class PluginListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PluginListPageResponse
        {
            Data =
            [
                new()
                {
                    ClaudeCodeMetrics = new(0),
                    CoworkMetrics = new(0),
                    DistinctUserCount = 0,
                    InstallCount = 0,
                    InvocationCount = 0,
                    PluginName = "plugin_name",
                    PluginID = "plugin_id",
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        List<BetaAnalyticsPluginActivity> expectedData =
        [
            new()
            {
                ClaudeCodeMetrics = new(0),
                CoworkMetrics = new(0),
                DistinctUserCount = 0,
                InstallCount = 0,
                InvocationCount = 0,
                PluginName = "plugin_name",
                PluginID = "plugin_id",
                Product = "product",
                RbacGroupID = "rbac_group_id",
                RbacGroupName = "rbac_group_name",
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
        var model = new PluginListPageResponse
        {
            Data =
            [
                new()
                {
                    ClaudeCodeMetrics = new(0),
                    CoworkMetrics = new(0),
                    DistinctUserCount = 0,
                    InstallCount = 0,
                    InvocationCount = 0,
                    PluginName = "plugin_name",
                    PluginID = "plugin_id",
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PluginListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PluginListPageResponse
        {
            Data =
            [
                new()
                {
                    ClaudeCodeMetrics = new(0),
                    CoworkMetrics = new(0),
                    DistinctUserCount = 0,
                    InstallCount = 0,
                    InvocationCount = 0,
                    PluginName = "plugin_name",
                    PluginID = "plugin_id",
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PluginListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaAnalyticsPluginActivity> expectedData =
        [
            new()
            {
                ClaudeCodeMetrics = new(0),
                CoworkMetrics = new(0),
                DistinctUserCount = 0,
                InstallCount = 0,
                InvocationCount = 0,
                PluginName = "plugin_name",
                PluginID = "plugin_id",
                Product = "product",
                RbacGroupID = "rbac_group_id",
                RbacGroupName = "rbac_group_name",
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
        var model = new PluginListPageResponse
        {
            Data =
            [
                new()
                {
                    ClaudeCodeMetrics = new(0),
                    CoworkMetrics = new(0),
                    DistinctUserCount = 0,
                    InstallCount = 0,
                    InvocationCount = 0,
                    PluginName = "plugin_name",
                    PluginID = "plugin_id",
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
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
        var model = new PluginListPageResponse
        {
            Data =
            [
                new()
                {
                    ClaudeCodeMetrics = new(0),
                    CoworkMetrics = new(0),
                    DistinctUserCount = 0,
                    InstallCount = 0,
                    InvocationCount = 0,
                    PluginName = "plugin_name",
                    PluginID = "plugin_id",
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        PluginListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
