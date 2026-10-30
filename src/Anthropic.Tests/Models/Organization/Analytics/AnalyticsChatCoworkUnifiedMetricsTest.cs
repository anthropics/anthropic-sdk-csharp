using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Analytics;

namespace Anthropic.Tests.Models.Organization.Analytics;

public class AnalyticsChatCoworkUnifiedMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AnalyticsChatCoworkUnifiedMetrics
        {
            Chat = new()
            {
                ConnectorsUsedCount = 0,
                DistinctArtifactsCreatedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctConversationCount = 0,
                DistinctFilesUploadedCount = 0,
                DistinctProjectsCreatedCount = 0,
                DistinctProjectsUsedCount = 0,
                DistinctSharedArtifactsViewedCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SharedConversationsViewedCount = 0,
                ThinkingMessageCount = 0,
            },
            Sessions = new()
            {
                ActionCount = 0,
                ArtifactsCreatedCount = 0,
                ConnectorsUsedCount = 0,
                DispatchTurnCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MessageCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                SkillsUsedCount = 0,
                WriteToolCount = 0,
            },
        };

        AnalyticsChatCoworkUnifiedChatMetrics expectedChat = new()
        {
            ConnectorsUsedCount = 0,
            DistinctArtifactsCreatedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctConversationCount = 0,
            DistinctFilesUploadedCount = 0,
            DistinctProjectsCreatedCount = 0,
            DistinctProjectsUsedCount = 0,
            DistinctSharedArtifactsViewedCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SharedConversationsViewedCount = 0,
            ThinkingMessageCount = 0,
        };
        AnalyticsChatCoworkUnifiedSessionsMetrics expectedSessions = new()
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MessageCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            SkillsUsedCount = 0,
            WriteToolCount = 0,
        };

        Assert.Equal(expectedChat, model.Chat);
        Assert.Equal(expectedSessions, model.Sessions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AnalyticsChatCoworkUnifiedMetrics
        {
            Chat = new()
            {
                ConnectorsUsedCount = 0,
                DistinctArtifactsCreatedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctConversationCount = 0,
                DistinctFilesUploadedCount = 0,
                DistinctProjectsCreatedCount = 0,
                DistinctProjectsUsedCount = 0,
                DistinctSharedArtifactsViewedCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SharedConversationsViewedCount = 0,
                ThinkingMessageCount = 0,
            },
            Sessions = new()
            {
                ActionCount = 0,
                ArtifactsCreatedCount = 0,
                ConnectorsUsedCount = 0,
                DispatchTurnCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MessageCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                SkillsUsedCount = 0,
                WriteToolCount = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsChatCoworkUnifiedMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AnalyticsChatCoworkUnifiedMetrics
        {
            Chat = new()
            {
                ConnectorsUsedCount = 0,
                DistinctArtifactsCreatedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctConversationCount = 0,
                DistinctFilesUploadedCount = 0,
                DistinctProjectsCreatedCount = 0,
                DistinctProjectsUsedCount = 0,
                DistinctSharedArtifactsViewedCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SharedConversationsViewedCount = 0,
                ThinkingMessageCount = 0,
            },
            Sessions = new()
            {
                ActionCount = 0,
                ArtifactsCreatedCount = 0,
                ConnectorsUsedCount = 0,
                DispatchTurnCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MessageCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                SkillsUsedCount = 0,
                WriteToolCount = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnalyticsChatCoworkUnifiedMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AnalyticsChatCoworkUnifiedChatMetrics expectedChat = new()
        {
            ConnectorsUsedCount = 0,
            DistinctArtifactsCreatedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctConversationCount = 0,
            DistinctFilesUploadedCount = 0,
            DistinctProjectsCreatedCount = 0,
            DistinctProjectsUsedCount = 0,
            DistinctSharedArtifactsViewedCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SharedConversationsViewedCount = 0,
            ThinkingMessageCount = 0,
        };
        AnalyticsChatCoworkUnifiedSessionsMetrics expectedSessions = new()
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MessageCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            SkillsUsedCount = 0,
            WriteToolCount = 0,
        };

        Assert.Equal(expectedChat, deserialized.Chat);
        Assert.Equal(expectedSessions, deserialized.Sessions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AnalyticsChatCoworkUnifiedMetrics
        {
            Chat = new()
            {
                ConnectorsUsedCount = 0,
                DistinctArtifactsCreatedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctConversationCount = 0,
                DistinctFilesUploadedCount = 0,
                DistinctProjectsCreatedCount = 0,
                DistinctProjectsUsedCount = 0,
                DistinctSharedArtifactsViewedCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SharedConversationsViewedCount = 0,
                ThinkingMessageCount = 0,
            },
            Sessions = new()
            {
                ActionCount = 0,
                ArtifactsCreatedCount = 0,
                ConnectorsUsedCount = 0,
                DispatchTurnCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MessageCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                SkillsUsedCount = 0,
                WriteToolCount = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AnalyticsChatCoworkUnifiedMetrics
        {
            Chat = new()
            {
                ConnectorsUsedCount = 0,
                DistinctArtifactsCreatedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctConversationCount = 0,
                DistinctFilesUploadedCount = 0,
                DistinctProjectsCreatedCount = 0,
                DistinctProjectsUsedCount = 0,
                DistinctSharedArtifactsViewedCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SharedConversationsViewedCount = 0,
                ThinkingMessageCount = 0,
            },
            Sessions = new()
            {
                ActionCount = 0,
                ArtifactsCreatedCount = 0,
                ConnectorsUsedCount = 0,
                DispatchTurnCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MessageCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                SkillsUsedCount = 0,
                WriteToolCount = 0,
            },
        };

        AnalyticsChatCoworkUnifiedMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
