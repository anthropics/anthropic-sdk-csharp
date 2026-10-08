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
        };

        BetaAnalyticsConnectorChatMetrics expectedChatMetrics = new(0);
        BetaAnalyticsConnectorClaudeCodeMetrics expectedClaudeCodeMetrics = new(0);
        string expectedConnectorName = "connector_name";
        BetaAnalyticsConnectorCoworkMetrics expectedCoworkMetrics = new(0);
        long expectedDistinctUserCount = 0;
        BetaAnalyticsConnectorOfficeMetrics expectedOfficeMetrics = new()
        {
            Excel = new(0),
            Outlook = new(0),
            Powerpoint = new(0),
            Word = new(0),
        };
        ChatCoworkUnifiedMetrics expectedChatCoworkUnifiedMetrics = new()
        {
            Chat = new(0),
            Sessions = new(0),
        };
        string expectedConnectorDisplayName = "connector_display_name";
        long expectedIndividualAuthDistinctUserCount = 0;
        long expectedManagedAuthDistinctUserCount = 0;
        string expectedProduct = "product";
        string expectedRbacGroupID = "rbac_group_id";
        string expectedRbacGroupName = "rbac_group_name";
        long expectedReadCallCount = 0;
        long expectedUnclassifiedCallCount = 0;
        string expectedUserID = "user_id";
        long expectedWriteCallCount = 0;

        Assert.Equal(expectedChatMetrics, model.ChatMetrics);
        Assert.Equal(expectedClaudeCodeMetrics, model.ClaudeCodeMetrics);
        Assert.Equal(expectedConnectorName, model.ConnectorName);
        Assert.Equal(expectedCoworkMetrics, model.CoworkMetrics);
        Assert.Equal(expectedDistinctUserCount, model.DistinctUserCount);
        Assert.Equal(expectedOfficeMetrics, model.OfficeMetrics);
        Assert.Equal(expectedChatCoworkUnifiedMetrics, model.ChatCoworkUnifiedMetrics);
        Assert.Equal(expectedConnectorDisplayName, model.ConnectorDisplayName);
        Assert.Equal(
            expectedIndividualAuthDistinctUserCount,
            model.IndividualAuthDistinctUserCount
        );
        Assert.Equal(expectedManagedAuthDistinctUserCount, model.ManagedAuthDistinctUserCount);
        Assert.Equal(expectedProduct, model.Product);
        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.Equal(expectedRbacGroupName, model.RbacGroupName);
        Assert.Equal(expectedReadCallCount, model.ReadCallCount);
        Assert.Equal(expectedUnclassifiedCallCount, model.UnclassifiedCallCount);
        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedWriteCallCount, model.WriteCallCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsConnectorActivity
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsConnectorActivity>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaAnalyticsConnectorChatMetrics expectedChatMetrics = new(0);
        BetaAnalyticsConnectorClaudeCodeMetrics expectedClaudeCodeMetrics = new(0);
        string expectedConnectorName = "connector_name";
        BetaAnalyticsConnectorCoworkMetrics expectedCoworkMetrics = new(0);
        long expectedDistinctUserCount = 0;
        BetaAnalyticsConnectorOfficeMetrics expectedOfficeMetrics = new()
        {
            Excel = new(0),
            Outlook = new(0),
            Powerpoint = new(0),
            Word = new(0),
        };
        ChatCoworkUnifiedMetrics expectedChatCoworkUnifiedMetrics = new()
        {
            Chat = new(0),
            Sessions = new(0),
        };
        string expectedConnectorDisplayName = "connector_display_name";
        long expectedIndividualAuthDistinctUserCount = 0;
        long expectedManagedAuthDistinctUserCount = 0;
        string expectedProduct = "product";
        string expectedRbacGroupID = "rbac_group_id";
        string expectedRbacGroupName = "rbac_group_name";
        long expectedReadCallCount = 0;
        long expectedUnclassifiedCallCount = 0;
        string expectedUserID = "user_id";
        long expectedWriteCallCount = 0;

        Assert.Equal(expectedChatMetrics, deserialized.ChatMetrics);
        Assert.Equal(expectedClaudeCodeMetrics, deserialized.ClaudeCodeMetrics);
        Assert.Equal(expectedConnectorName, deserialized.ConnectorName);
        Assert.Equal(expectedCoworkMetrics, deserialized.CoworkMetrics);
        Assert.Equal(expectedDistinctUserCount, deserialized.DistinctUserCount);
        Assert.Equal(expectedOfficeMetrics, deserialized.OfficeMetrics);
        Assert.Equal(expectedChatCoworkUnifiedMetrics, deserialized.ChatCoworkUnifiedMetrics);
        Assert.Equal(expectedConnectorDisplayName, deserialized.ConnectorDisplayName);
        Assert.Equal(
            expectedIndividualAuthDistinctUserCount,
            deserialized.IndividualAuthDistinctUserCount
        );
        Assert.Equal(
            expectedManagedAuthDistinctUserCount,
            deserialized.ManagedAuthDistinctUserCount
        );
        Assert.Equal(expectedProduct, deserialized.Product);
        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.Equal(expectedRbacGroupName, deserialized.RbacGroupName);
        Assert.Equal(expectedReadCallCount, deserialized.ReadCallCount);
        Assert.Equal(expectedUnclassifiedCallCount, deserialized.UnclassifiedCallCount);
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedWriteCallCount, deserialized.WriteCallCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsConnectorActivity
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
        };

        Assert.Null(model.ChatCoworkUnifiedMetrics);
        Assert.False(model.RawData.ContainsKey("chat_cowork_unified_metrics"));
        Assert.Null(model.ConnectorDisplayName);
        Assert.False(model.RawData.ContainsKey("connector_display_name"));
        Assert.Null(model.IndividualAuthDistinctUserCount);
        Assert.False(model.RawData.ContainsKey("individual_auth_distinct_user_count"));
        Assert.Null(model.ManagedAuthDistinctUserCount);
        Assert.False(model.RawData.ContainsKey("managed_auth_distinct_user_count"));
        Assert.Null(model.Product);
        Assert.False(model.RawData.ContainsKey("product"));
        Assert.Null(model.RbacGroupID);
        Assert.False(model.RawData.ContainsKey("rbac_group_id"));
        Assert.Null(model.RbacGroupName);
        Assert.False(model.RawData.ContainsKey("rbac_group_name"));
        Assert.Null(model.ReadCallCount);
        Assert.False(model.RawData.ContainsKey("read_call_count"));
        Assert.Null(model.UnclassifiedCallCount);
        Assert.False(model.RawData.ContainsKey("unclassified_call_count"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("user_id"));
        Assert.Null(model.WriteCallCount);
        Assert.False(model.RawData.ContainsKey("write_call_count"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaAnalyticsConnectorActivity
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

            ChatCoworkUnifiedMetrics = null,
            ConnectorDisplayName = null,
            IndividualAuthDistinctUserCount = null,
            ManagedAuthDistinctUserCount = null,
            Product = null,
            RbacGroupID = null,
            RbacGroupName = null,
            ReadCallCount = null,
            UnclassifiedCallCount = null,
            UserID = null,
            WriteCallCount = null,
        };

        Assert.Null(model.ChatCoworkUnifiedMetrics);
        Assert.True(model.RawData.ContainsKey("chat_cowork_unified_metrics"));
        Assert.Null(model.ConnectorDisplayName);
        Assert.True(model.RawData.ContainsKey("connector_display_name"));
        Assert.Null(model.IndividualAuthDistinctUserCount);
        Assert.True(model.RawData.ContainsKey("individual_auth_distinct_user_count"));
        Assert.Null(model.ManagedAuthDistinctUserCount);
        Assert.True(model.RawData.ContainsKey("managed_auth_distinct_user_count"));
        Assert.Null(model.Product);
        Assert.True(model.RawData.ContainsKey("product"));
        Assert.Null(model.RbacGroupID);
        Assert.True(model.RawData.ContainsKey("rbac_group_id"));
        Assert.Null(model.RbacGroupName);
        Assert.True(model.RawData.ContainsKey("rbac_group_name"));
        Assert.Null(model.ReadCallCount);
        Assert.True(model.RawData.ContainsKey("read_call_count"));
        Assert.Null(model.UnclassifiedCallCount);
        Assert.True(model.RawData.ContainsKey("unclassified_call_count"));
        Assert.Null(model.UserID);
        Assert.True(model.RawData.ContainsKey("user_id"));
        Assert.Null(model.WriteCallCount);
        Assert.True(model.RawData.ContainsKey("write_call_count"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaAnalyticsConnectorActivity
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

            ChatCoworkUnifiedMetrics = null,
            ConnectorDisplayName = null,
            IndividualAuthDistinctUserCount = null,
            ManagedAuthDistinctUserCount = null,
            Product = null,
            RbacGroupID = null,
            RbacGroupName = null,
            ReadCallCount = null,
            UnclassifiedCallCount = null,
            UserID = null,
            WriteCallCount = null,
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
        };

        BetaAnalyticsConnectorActivity copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChatCoworkUnifiedMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCoworkUnifiedMetrics { Chat = new(0), Sessions = new(0) };

        Chat expectedChat = new(0);
        ChatCoworkUnifiedMetricsSessions expectedSessions = new(0);

        Assert.Equal(expectedChat, model.Chat);
        Assert.Equal(expectedSessions, model.Sessions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCoworkUnifiedMetrics { Chat = new(0), Sessions = new(0) };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCoworkUnifiedMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCoworkUnifiedMetrics { Chat = new(0), Sessions = new(0) };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCoworkUnifiedMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Chat expectedChat = new(0);
        ChatCoworkUnifiedMetricsSessions expectedSessions = new(0);

        Assert.Equal(expectedChat, deserialized.Chat);
        Assert.Equal(expectedSessions, deserialized.Sessions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCoworkUnifiedMetrics { Chat = new(0), Sessions = new(0) };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCoworkUnifiedMetrics { Chat = new(0), Sessions = new(0) };

        ChatCoworkUnifiedMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChatTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Chat { DistinctConversationConnectorUsedCount = 0 };

        long expectedDistinctConversationConnectorUsedCount = 0;

        Assert.Equal(
            expectedDistinctConversationConnectorUsedCount,
            model.DistinctConversationConnectorUsedCount
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Chat { DistinctConversationConnectorUsedCount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Chat>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Chat { DistinctConversationConnectorUsedCount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Chat>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedDistinctConversationConnectorUsedCount = 0;

        Assert.Equal(
            expectedDistinctConversationConnectorUsedCount,
            deserialized.DistinctConversationConnectorUsedCount
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Chat { DistinctConversationConnectorUsedCount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Chat { DistinctConversationConnectorUsedCount = 0 };

        Chat copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChatCoworkUnifiedMetricsSessionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChatCoworkUnifiedMetricsSessions { DistinctSessionConnectorUsedCount = 0 };

        long expectedDistinctSessionConnectorUsedCount = 0;

        Assert.Equal(
            expectedDistinctSessionConnectorUsedCount,
            model.DistinctSessionConnectorUsedCount
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChatCoworkUnifiedMetricsSessions { DistinctSessionConnectorUsedCount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCoworkUnifiedMetricsSessions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChatCoworkUnifiedMetricsSessions { DistinctSessionConnectorUsedCount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChatCoworkUnifiedMetricsSessions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDistinctSessionConnectorUsedCount = 0;

        Assert.Equal(
            expectedDistinctSessionConnectorUsedCount,
            deserialized.DistinctSessionConnectorUsedCount
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChatCoworkUnifiedMetricsSessions { DistinctSessionConnectorUsedCount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChatCoworkUnifiedMetricsSessions { DistinctSessionConnectorUsedCount = 0 };

        ChatCoworkUnifiedMetricsSessions copied = new(model);

        Assert.Equal(model, copied);
    }
}
