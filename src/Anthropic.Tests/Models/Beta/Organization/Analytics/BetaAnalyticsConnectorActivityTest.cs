using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsConnectorActivityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsConnectorActivity
        {
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            ConnectorDisplayName = "connector_display_name",
            ConnectorName = "connector_name",
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            IndividualAuthDistinctUserCount = 0,
            ManagedAuthDistinctUserCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ReadCallCount = 0,
            UnclassifiedCallCount = 0,
            WriteCallCount = 0,
            ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
            Product = "product",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            UserID = "user_id",
        };

        BetaAnalyticsConnectorChatMetrics expectedChatMetrics = new(0);
        BetaAnalyticsConnectorClaudeCodeMetrics expectedClaudeCodeMetrics = new(0);
        string expectedConnectorDisplayName = "connector_display_name";
        string expectedConnectorName = "connector_name";
        BetaAnalyticsConnectorCoworkMetrics expectedCoworkMetrics = new(0);
        long expectedDistinctUserCount = 0;
        long expectedIndividualAuthDistinctUserCount = 0;
        long expectedManagedAuthDistinctUserCount = 0;
        BetaAnalyticsConnectorOfficeMetrics expectedOfficeMetrics = new()
        {
            Excel = new(0),
            Outlook = new(0),
            Powerpoint = new(0),
            Word = new(0),
        };
        long expectedReadCallCount = 0;
        long expectedUnclassifiedCallCount = 0;
        long expectedWriteCallCount = 0;
        BetaAnalyticsConnectorChatCoworkUnifiedMetrics expectedChatCoworkUnifiedMetrics = new()
        {
            Chat = new(0),
            Sessions = new(0),
        };
        string expectedProduct = "product";
        string expectedRbacGroupID = "rbac_group_id";
        string expectedRbacGroupName = "rbac_group_name";
        string expectedUserID = "user_id";

        Assert.Equal(expectedChatMetrics, model.ChatMetrics);
        Assert.Equal(expectedClaudeCodeMetrics, model.ClaudeCodeMetrics);
        Assert.Equal(expectedConnectorDisplayName, model.ConnectorDisplayName);
        Assert.Equal(expectedConnectorName, model.ConnectorName);
        Assert.Equal(expectedCoworkMetrics, model.CoworkMetrics);
        Assert.Equal(expectedDistinctUserCount, model.DistinctUserCount);
        Assert.Equal(
            expectedIndividualAuthDistinctUserCount,
            model.IndividualAuthDistinctUserCount
        );
        Assert.Equal(expectedManagedAuthDistinctUserCount, model.ManagedAuthDistinctUserCount);
        Assert.Equal(expectedOfficeMetrics, model.OfficeMetrics);
        Assert.Equal(expectedReadCallCount, model.ReadCallCount);
        Assert.Equal(expectedUnclassifiedCallCount, model.UnclassifiedCallCount);
        Assert.Equal(expectedWriteCallCount, model.WriteCallCount);
        Assert.Equal(expectedChatCoworkUnifiedMetrics, model.ChatCoworkUnifiedMetrics);
        Assert.Equal(expectedProduct, model.Product);
        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.Equal(expectedRbacGroupName, model.RbacGroupName);
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsConnectorActivity
        {
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            ConnectorDisplayName = "connector_display_name",
            ConnectorName = "connector_name",
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            IndividualAuthDistinctUserCount = 0,
            ManagedAuthDistinctUserCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ReadCallCount = 0,
            UnclassifiedCallCount = 0,
            WriteCallCount = 0,
            ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
            Product = "product",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            UserID = "user_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsConnectorActivity>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsConnectorActivity
        {
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            ConnectorDisplayName = "connector_display_name",
            ConnectorName = "connector_name",
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            IndividualAuthDistinctUserCount = 0,
            ManagedAuthDistinctUserCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ReadCallCount = 0,
            UnclassifiedCallCount = 0,
            WriteCallCount = 0,
            ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
            Product = "product",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            UserID = "user_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsConnectorActivity>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaAnalyticsConnectorChatMetrics expectedChatMetrics = new(0);
        BetaAnalyticsConnectorClaudeCodeMetrics expectedClaudeCodeMetrics = new(0);
        string expectedConnectorDisplayName = "connector_display_name";
        string expectedConnectorName = "connector_name";
        BetaAnalyticsConnectorCoworkMetrics expectedCoworkMetrics = new(0);
        long expectedDistinctUserCount = 0;
        long expectedIndividualAuthDistinctUserCount = 0;
        long expectedManagedAuthDistinctUserCount = 0;
        BetaAnalyticsConnectorOfficeMetrics expectedOfficeMetrics = new()
        {
            Excel = new(0),
            Outlook = new(0),
            Powerpoint = new(0),
            Word = new(0),
        };
        long expectedReadCallCount = 0;
        long expectedUnclassifiedCallCount = 0;
        long expectedWriteCallCount = 0;
        BetaAnalyticsConnectorChatCoworkUnifiedMetrics expectedChatCoworkUnifiedMetrics = new()
        {
            Chat = new(0),
            Sessions = new(0),
        };
        string expectedProduct = "product";
        string expectedRbacGroupID = "rbac_group_id";
        string expectedRbacGroupName = "rbac_group_name";
        string expectedUserID = "user_id";

        Assert.Equal(expectedChatMetrics, deserialized.ChatMetrics);
        Assert.Equal(expectedClaudeCodeMetrics, deserialized.ClaudeCodeMetrics);
        Assert.Equal(expectedConnectorDisplayName, deserialized.ConnectorDisplayName);
        Assert.Equal(expectedConnectorName, deserialized.ConnectorName);
        Assert.Equal(expectedCoworkMetrics, deserialized.CoworkMetrics);
        Assert.Equal(expectedDistinctUserCount, deserialized.DistinctUserCount);
        Assert.Equal(
            expectedIndividualAuthDistinctUserCount,
            deserialized.IndividualAuthDistinctUserCount
        );
        Assert.Equal(
            expectedManagedAuthDistinctUserCount,
            deserialized.ManagedAuthDistinctUserCount
        );
        Assert.Equal(expectedOfficeMetrics, deserialized.OfficeMetrics);
        Assert.Equal(expectedReadCallCount, deserialized.ReadCallCount);
        Assert.Equal(expectedUnclassifiedCallCount, deserialized.UnclassifiedCallCount);
        Assert.Equal(expectedWriteCallCount, deserialized.WriteCallCount);
        Assert.Equal(expectedChatCoworkUnifiedMetrics, deserialized.ChatCoworkUnifiedMetrics);
        Assert.Equal(expectedProduct, deserialized.Product);
        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.Equal(expectedRbacGroupName, deserialized.RbacGroupName);
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsConnectorActivity
        {
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            ConnectorDisplayName = "connector_display_name",
            ConnectorName = "connector_name",
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            IndividualAuthDistinctUserCount = 0,
            ManagedAuthDistinctUserCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ReadCallCount = 0,
            UnclassifiedCallCount = 0,
            WriteCallCount = 0,
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
        var model = new BetaAnalyticsConnectorActivity
        {
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            ConnectorDisplayName = "connector_display_name",
            ConnectorName = "connector_name",
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            IndividualAuthDistinctUserCount = 0,
            ManagedAuthDistinctUserCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ReadCallCount = 0,
            UnclassifiedCallCount = 0,
            WriteCallCount = 0,
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
        var model = new BetaAnalyticsConnectorActivity
        {
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            ConnectorDisplayName = "connector_display_name",
            ConnectorName = "connector_name",
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            IndividualAuthDistinctUserCount = 0,
            ManagedAuthDistinctUserCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ReadCallCount = 0,
            UnclassifiedCallCount = 0,
            WriteCallCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaAnalyticsConnectorActivity
        {
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            ConnectorDisplayName = "connector_display_name",
            ConnectorName = "connector_name",
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            IndividualAuthDistinctUserCount = 0,
            ManagedAuthDistinctUserCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ReadCallCount = 0,
            UnclassifiedCallCount = 0,
            WriteCallCount = 0,

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
        var model = new BetaAnalyticsConnectorActivity
        {
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            ConnectorDisplayName = "connector_display_name",
            ConnectorName = "connector_name",
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            IndividualAuthDistinctUserCount = 0,
            ManagedAuthDistinctUserCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ReadCallCount = 0,
            UnclassifiedCallCount = 0,
            WriteCallCount = 0,

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
        var model = new BetaAnalyticsConnectorActivity
        {
            ChatMetrics = new(0),
            ClaudeCodeMetrics = new(0),
            ConnectorDisplayName = "connector_display_name",
            ConnectorName = "connector_name",
            CoworkMetrics = new(0),
            DistinctUserCount = 0,
            IndividualAuthDistinctUserCount = 0,
            ManagedAuthDistinctUserCount = 0,
            OfficeMetrics = new()
            {
                Excel = new(0),
                Outlook = new(0),
                Powerpoint = new(0),
                Word = new(0),
            },
            ReadCallCount = 0,
            UnclassifiedCallCount = 0,
            WriteCallCount = 0,
            ChatCoworkUnifiedMetrics = new() { Chat = new(0), Sessions = new(0) },
            Product = "product",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            UserID = "user_id",
        };

        BetaAnalyticsConnectorActivity copied = new(model);

        Assert.Equal(model, copied);
    }
}
