using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;
using Anthropic.Models.Beta.Organization.Analytics.Connectors;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Connectors;

public class ConnectorListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConnectorListPageResponse
        {
            Data =
            [
                new()
                {
                    ChatMetrics = new(0),
                    ClaudeCodeMetrics = new(0),
                    ConnectorName = "connector_name",
                    CoworkMetrics = new(0),
                    DistinctUserCount = 0,
                    OfficeMetrics = new()
                    {
                        Excel = new(0),
                        Outlook = new(0),
                        Powerpoint = new(0),
                        Word = new(0),
                    },
                    ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
                    ConnectorDisplayName = "connector_display_name",
                    IndividualAuthDistinctUserCount = 0,
                    ManagedAuthDistinctUserCount = 0,
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    ReadCallCount = 0,
                    UnclassifiedCallCount = 0,
                    UserID = "user_id",
                    WriteCallCount = 0,
                },
            ],
            NextPage = "next_page",
        };

        List<BetaAnalyticsConnectorActivity> expectedData =
        [
            new()
            {
                ChatMetrics = new(0),
                ClaudeCodeMetrics = new(0),
                ConnectorName = "connector_name",
                CoworkMetrics = new(0),
                DistinctUserCount = 0,
                OfficeMetrics = new()
                {
                    Excel = new(0),
                    Outlook = new(0),
                    Powerpoint = new(0),
                    Word = new(0),
                },
                ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
                ConnectorDisplayName = "connector_display_name",
                IndividualAuthDistinctUserCount = 0,
                ManagedAuthDistinctUserCount = 0,
                Product = "product",
                RbacGroupID = "rbac_group_id",
                RbacGroupName = "rbac_group_name",
                ReadCallCount = 0,
                UnclassifiedCallCount = 0,
                UserID = "user_id",
                WriteCallCount = 0,
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
        var model = new ConnectorListPageResponse
        {
            Data =
            [
                new()
                {
                    ChatMetrics = new(0),
                    ClaudeCodeMetrics = new(0),
                    ConnectorName = "connector_name",
                    CoworkMetrics = new(0),
                    DistinctUserCount = 0,
                    OfficeMetrics = new()
                    {
                        Excel = new(0),
                        Outlook = new(0),
                        Powerpoint = new(0),
                        Word = new(0),
                    },
                    ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
                    ConnectorDisplayName = "connector_display_name",
                    IndividualAuthDistinctUserCount = 0,
                    ManagedAuthDistinctUserCount = 0,
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    ReadCallCount = 0,
                    UnclassifiedCallCount = 0,
                    UserID = "user_id",
                    WriteCallCount = 0,
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConnectorListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConnectorListPageResponse
        {
            Data =
            [
                new()
                {
                    ChatMetrics = new(0),
                    ClaudeCodeMetrics = new(0),
                    ConnectorName = "connector_name",
                    CoworkMetrics = new(0),
                    DistinctUserCount = 0,
                    OfficeMetrics = new()
                    {
                        Excel = new(0),
                        Outlook = new(0),
                        Powerpoint = new(0),
                        Word = new(0),
                    },
                    ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
                    ConnectorDisplayName = "connector_display_name",
                    IndividualAuthDistinctUserCount = 0,
                    ManagedAuthDistinctUserCount = 0,
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    ReadCallCount = 0,
                    UnclassifiedCallCount = 0,
                    UserID = "user_id",
                    WriteCallCount = 0,
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConnectorListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaAnalyticsConnectorActivity> expectedData =
        [
            new()
            {
                ChatMetrics = new(0),
                ClaudeCodeMetrics = new(0),
                ConnectorName = "connector_name",
                CoworkMetrics = new(0),
                DistinctUserCount = 0,
                OfficeMetrics = new()
                {
                    Excel = new(0),
                    Outlook = new(0),
                    Powerpoint = new(0),
                    Word = new(0),
                },
                ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
                ConnectorDisplayName = "connector_display_name",
                IndividualAuthDistinctUserCount = 0,
                ManagedAuthDistinctUserCount = 0,
                Product = "product",
                RbacGroupID = "rbac_group_id",
                RbacGroupName = "rbac_group_name",
                ReadCallCount = 0,
                UnclassifiedCallCount = 0,
                UserID = "user_id",
                WriteCallCount = 0,
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
        var model = new ConnectorListPageResponse
        {
            Data =
            [
                new()
                {
                    ChatMetrics = new(0),
                    ClaudeCodeMetrics = new(0),
                    ConnectorName = "connector_name",
                    CoworkMetrics = new(0),
                    DistinctUserCount = 0,
                    OfficeMetrics = new()
                    {
                        Excel = new(0),
                        Outlook = new(0),
                        Powerpoint = new(0),
                        Word = new(0),
                    },
                    ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
                    ConnectorDisplayName = "connector_display_name",
                    IndividualAuthDistinctUserCount = 0,
                    ManagedAuthDistinctUserCount = 0,
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    ReadCallCount = 0,
                    UnclassifiedCallCount = 0,
                    UserID = "user_id",
                    WriteCallCount = 0,
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConnectorListPageResponse
        {
            Data =
            [
                new()
                {
                    ChatMetrics = new(0),
                    ClaudeCodeMetrics = new(0),
                    ConnectorName = "connector_name",
                    CoworkMetrics = new(0),
                    DistinctUserCount = 0,
                    OfficeMetrics = new()
                    {
                        Excel = new(0),
                        Outlook = new(0),
                        Powerpoint = new(0),
                        Word = new(0),
                    },
                    ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
                    ConnectorDisplayName = "connector_display_name",
                    IndividualAuthDistinctUserCount = 0,
                    ManagedAuthDistinctUserCount = 0,
                    Product = "product",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    ReadCallCount = 0,
                    UnclassifiedCallCount = 0,
                    UserID = "user_id",
                    WriteCallCount = 0,
                },
            ],
            NextPage = "next_page",
        };

        ConnectorListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
