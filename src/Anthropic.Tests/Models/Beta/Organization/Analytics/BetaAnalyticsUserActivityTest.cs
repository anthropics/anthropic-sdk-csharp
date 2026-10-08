using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsUserActivityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsUserActivity
        {
            ChatMetrics = new()
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
            ClaudeCodeMetrics = new()
            {
                CoreMetrics = new()
                {
                    ArtifactsCreatedCount = 0,
                    CommitCount = 0,
                    DistinctSessionCount = 0,
                    LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
                    PullRequestCount = 0,
                },
                ToolActions = new()
                {
                    EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                },
            },
            CoworkMetrics = new()
            {
                ActionCount = 0,
                ArtifactsCreatedCount = 0,
                ConnectorsUsedCount = 0,
                DispatchTurnCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                WriteToolCount = 0,
            },
            DesignMetrics = new()
            {
                DistinctProjectsCreatedCount = 0,
                DistinctProjectsUsedCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
            },
            OfficeMetrics = new()
            {
                Excel = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Outlook = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Powerpoint = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Word = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
            },
            ScienceMetrics = new()
            {
                DelegationCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
                RemoteComputeJobCount = 0,
                SkillsUsedCount = 0,
            },
            WebSearchCount = 0,
            ChatCoworkUnifiedMetrics = new()
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
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                    DistinctPluginsUsedCount = 0,
                    EditToolCount = 0,
                    FileEditCount = 0,
                    MultiEditToolCount = 0,
                    NotebookEditToolCount = 0,
                    PluginsUsedCount = 0,
                    SessionsWithFileEditsCount = 0,
                    WriteToolCount = 0,
                },
            },
            DistinctUserCount = 0,
            LastActivityDate = "2019-12-27",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            User = new() { ID = "id", EmailAddress = "email_address" },
        };

        BetaAnalyticsChatMetrics expectedChatMetrics = new()
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
        BetaAnalyticsClaudeCodeMetrics expectedClaudeCodeMetrics = new()
        {
            CoreMetrics = new()
            {
                ArtifactsCreatedCount = 0,
                CommitCount = 0,
                DistinctSessionCount = 0,
                LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
                PullRequestCount = 0,
            },
            ToolActions = new()
            {
                EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            },
        };
        BetaAnalyticsCoworkMetrics expectedCoworkMetrics = new()
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            WriteToolCount = 0,
        };
        BetaAnalyticsDesignMetrics expectedDesignMetrics = new()
        {
            DistinctProjectsCreatedCount = 0,
            DistinctProjectsUsedCount = 0,
            DistinctSessionCount = 0,
            MessageCount = 0,
        };
        BetaAnalyticsOfficeMetrics expectedOfficeMetrics = new()
        {
            Excel = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Outlook = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Powerpoint = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Word = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
        };
        BetaAnalyticsScienceMetrics expectedScienceMetrics = new()
        {
            DelegationCount = 0,
            DistinctSessionCount = 0,
            MessageCount = 0,
            RemoteComputeJobCount = 0,
            SkillsUsedCount = 0,
        };
        long expectedWebSearchCount = 0;
        BetaAnalyticsUserActivityChatCoworkUnifiedMetrics expectedChatCoworkUnifiedMetrics = new()
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
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                WriteToolCount = 0,
            },
        };
        long expectedDistinctUserCount = 0;
        string expectedLastActivityDate = "2019-12-27";
        string expectedRbacGroupID = "rbac_group_id";
        string expectedRbacGroupName = "rbac_group_name";
        BetaAnalyticsUser expectedUser = new() { ID = "id", EmailAddress = "email_address" };

        Assert.Equal(expectedChatMetrics, model.ChatMetrics);
        Assert.Equal(expectedClaudeCodeMetrics, model.ClaudeCodeMetrics);
        Assert.Equal(expectedCoworkMetrics, model.CoworkMetrics);
        Assert.Equal(expectedDesignMetrics, model.DesignMetrics);
        Assert.Equal(expectedOfficeMetrics, model.OfficeMetrics);
        Assert.Equal(expectedScienceMetrics, model.ScienceMetrics);
        Assert.Equal(expectedWebSearchCount, model.WebSearchCount);
        Assert.Equal(expectedChatCoworkUnifiedMetrics, model.ChatCoworkUnifiedMetrics);
        Assert.Equal(expectedDistinctUserCount, model.DistinctUserCount);
        Assert.Equal(expectedLastActivityDate, model.LastActivityDate);
        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.Equal(expectedRbacGroupName, model.RbacGroupName);
        Assert.Equal(expectedUser, model.User);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsUserActivity
        {
            ChatMetrics = new()
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
            ClaudeCodeMetrics = new()
            {
                CoreMetrics = new()
                {
                    ArtifactsCreatedCount = 0,
                    CommitCount = 0,
                    DistinctSessionCount = 0,
                    LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
                    PullRequestCount = 0,
                },
                ToolActions = new()
                {
                    EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                },
            },
            CoworkMetrics = new()
            {
                ActionCount = 0,
                ArtifactsCreatedCount = 0,
                ConnectorsUsedCount = 0,
                DispatchTurnCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                WriteToolCount = 0,
            },
            DesignMetrics = new()
            {
                DistinctProjectsCreatedCount = 0,
                DistinctProjectsUsedCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
            },
            OfficeMetrics = new()
            {
                Excel = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Outlook = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Powerpoint = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Word = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
            },
            ScienceMetrics = new()
            {
                DelegationCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
                RemoteComputeJobCount = 0,
                SkillsUsedCount = 0,
            },
            WebSearchCount = 0,
            ChatCoworkUnifiedMetrics = new()
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
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                    DistinctPluginsUsedCount = 0,
                    EditToolCount = 0,
                    FileEditCount = 0,
                    MultiEditToolCount = 0,
                    NotebookEditToolCount = 0,
                    PluginsUsedCount = 0,
                    SessionsWithFileEditsCount = 0,
                    WriteToolCount = 0,
                },
            },
            DistinctUserCount = 0,
            LastActivityDate = "2019-12-27",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            User = new() { ID = "id", EmailAddress = "email_address" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsUserActivity>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsUserActivity
        {
            ChatMetrics = new()
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
            ClaudeCodeMetrics = new()
            {
                CoreMetrics = new()
                {
                    ArtifactsCreatedCount = 0,
                    CommitCount = 0,
                    DistinctSessionCount = 0,
                    LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
                    PullRequestCount = 0,
                },
                ToolActions = new()
                {
                    EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                },
            },
            CoworkMetrics = new()
            {
                ActionCount = 0,
                ArtifactsCreatedCount = 0,
                ConnectorsUsedCount = 0,
                DispatchTurnCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                WriteToolCount = 0,
            },
            DesignMetrics = new()
            {
                DistinctProjectsCreatedCount = 0,
                DistinctProjectsUsedCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
            },
            OfficeMetrics = new()
            {
                Excel = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Outlook = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Powerpoint = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Word = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
            },
            ScienceMetrics = new()
            {
                DelegationCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
                RemoteComputeJobCount = 0,
                SkillsUsedCount = 0,
            },
            WebSearchCount = 0,
            ChatCoworkUnifiedMetrics = new()
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
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                    DistinctPluginsUsedCount = 0,
                    EditToolCount = 0,
                    FileEditCount = 0,
                    MultiEditToolCount = 0,
                    NotebookEditToolCount = 0,
                    PluginsUsedCount = 0,
                    SessionsWithFileEditsCount = 0,
                    WriteToolCount = 0,
                },
            },
            DistinctUserCount = 0,
            LastActivityDate = "2019-12-27",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            User = new() { ID = "id", EmailAddress = "email_address" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsUserActivity>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaAnalyticsChatMetrics expectedChatMetrics = new()
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
        BetaAnalyticsClaudeCodeMetrics expectedClaudeCodeMetrics = new()
        {
            CoreMetrics = new()
            {
                ArtifactsCreatedCount = 0,
                CommitCount = 0,
                DistinctSessionCount = 0,
                LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
                PullRequestCount = 0,
            },
            ToolActions = new()
            {
                EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
            },
        };
        BetaAnalyticsCoworkMetrics expectedCoworkMetrics = new()
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            WriteToolCount = 0,
        };
        BetaAnalyticsDesignMetrics expectedDesignMetrics = new()
        {
            DistinctProjectsCreatedCount = 0,
            DistinctProjectsUsedCount = 0,
            DistinctSessionCount = 0,
            MessageCount = 0,
        };
        BetaAnalyticsOfficeMetrics expectedOfficeMetrics = new()
        {
            Excel = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Outlook = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Powerpoint = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
            Word = new()
            {
                ConnectorsUsedCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
            },
        };
        BetaAnalyticsScienceMetrics expectedScienceMetrics = new()
        {
            DelegationCount = 0,
            DistinctSessionCount = 0,
            MessageCount = 0,
            RemoteComputeJobCount = 0,
            SkillsUsedCount = 0,
        };
        long expectedWebSearchCount = 0;
        BetaAnalyticsUserActivityChatCoworkUnifiedMetrics expectedChatCoworkUnifiedMetrics = new()
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
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                WriteToolCount = 0,
            },
        };
        long expectedDistinctUserCount = 0;
        string expectedLastActivityDate = "2019-12-27";
        string expectedRbacGroupID = "rbac_group_id";
        string expectedRbacGroupName = "rbac_group_name";
        BetaAnalyticsUser expectedUser = new() { ID = "id", EmailAddress = "email_address" };

        Assert.Equal(expectedChatMetrics, deserialized.ChatMetrics);
        Assert.Equal(expectedClaudeCodeMetrics, deserialized.ClaudeCodeMetrics);
        Assert.Equal(expectedCoworkMetrics, deserialized.CoworkMetrics);
        Assert.Equal(expectedDesignMetrics, deserialized.DesignMetrics);
        Assert.Equal(expectedOfficeMetrics, deserialized.OfficeMetrics);
        Assert.Equal(expectedScienceMetrics, deserialized.ScienceMetrics);
        Assert.Equal(expectedWebSearchCount, deserialized.WebSearchCount);
        Assert.Equal(expectedChatCoworkUnifiedMetrics, deserialized.ChatCoworkUnifiedMetrics);
        Assert.Equal(expectedDistinctUserCount, deserialized.DistinctUserCount);
        Assert.Equal(expectedLastActivityDate, deserialized.LastActivityDate);
        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.Equal(expectedRbacGroupName, deserialized.RbacGroupName);
        Assert.Equal(expectedUser, deserialized.User);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsUserActivity
        {
            ChatMetrics = new()
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
            ClaudeCodeMetrics = new()
            {
                CoreMetrics = new()
                {
                    ArtifactsCreatedCount = 0,
                    CommitCount = 0,
                    DistinctSessionCount = 0,
                    LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
                    PullRequestCount = 0,
                },
                ToolActions = new()
                {
                    EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                },
            },
            CoworkMetrics = new()
            {
                ActionCount = 0,
                ArtifactsCreatedCount = 0,
                ConnectorsUsedCount = 0,
                DispatchTurnCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                WriteToolCount = 0,
            },
            DesignMetrics = new()
            {
                DistinctProjectsCreatedCount = 0,
                DistinctProjectsUsedCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
            },
            OfficeMetrics = new()
            {
                Excel = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Outlook = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Powerpoint = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Word = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
            },
            ScienceMetrics = new()
            {
                DelegationCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
                RemoteComputeJobCount = 0,
                SkillsUsedCount = 0,
            },
            WebSearchCount = 0,
            ChatCoworkUnifiedMetrics = new()
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
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                    DistinctPluginsUsedCount = 0,
                    EditToolCount = 0,
                    FileEditCount = 0,
                    MultiEditToolCount = 0,
                    NotebookEditToolCount = 0,
                    PluginsUsedCount = 0,
                    SessionsWithFileEditsCount = 0,
                    WriteToolCount = 0,
                },
            },
            DistinctUserCount = 0,
            LastActivityDate = "2019-12-27",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            User = new() { ID = "id", EmailAddress = "email_address" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaAnalyticsUserActivity
        {
            ChatMetrics = new()
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
            ClaudeCodeMetrics = new()
            {
                CoreMetrics = new()
                {
                    ArtifactsCreatedCount = 0,
                    CommitCount = 0,
                    DistinctSessionCount = 0,
                    LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
                    PullRequestCount = 0,
                },
                ToolActions = new()
                {
                    EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                },
            },
            CoworkMetrics = new()
            {
                ActionCount = 0,
                ArtifactsCreatedCount = 0,
                ConnectorsUsedCount = 0,
                DispatchTurnCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                WriteToolCount = 0,
            },
            DesignMetrics = new()
            {
                DistinctProjectsCreatedCount = 0,
                DistinctProjectsUsedCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
            },
            OfficeMetrics = new()
            {
                Excel = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Outlook = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Powerpoint = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Word = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
            },
            ScienceMetrics = new()
            {
                DelegationCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
                RemoteComputeJobCount = 0,
                SkillsUsedCount = 0,
            },
            WebSearchCount = 0,
        };

        Assert.Null(model.ChatCoworkUnifiedMetrics);
        Assert.False(model.RawData.ContainsKey("chat_cowork_unified_metrics"));
        Assert.Null(model.DistinctUserCount);
        Assert.False(model.RawData.ContainsKey("distinct_user_count"));
        Assert.Null(model.LastActivityDate);
        Assert.False(model.RawData.ContainsKey("last_activity_date"));
        Assert.Null(model.RbacGroupID);
        Assert.False(model.RawData.ContainsKey("rbac_group_id"));
        Assert.Null(model.RbacGroupName);
        Assert.False(model.RawData.ContainsKey("rbac_group_name"));
        Assert.Null(model.User);
        Assert.False(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaAnalyticsUserActivity
        {
            ChatMetrics = new()
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
            ClaudeCodeMetrics = new()
            {
                CoreMetrics = new()
                {
                    ArtifactsCreatedCount = 0,
                    CommitCount = 0,
                    DistinctSessionCount = 0,
                    LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
                    PullRequestCount = 0,
                },
                ToolActions = new()
                {
                    EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                },
            },
            CoworkMetrics = new()
            {
                ActionCount = 0,
                ArtifactsCreatedCount = 0,
                ConnectorsUsedCount = 0,
                DispatchTurnCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                WriteToolCount = 0,
            },
            DesignMetrics = new()
            {
                DistinctProjectsCreatedCount = 0,
                DistinctProjectsUsedCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
            },
            OfficeMetrics = new()
            {
                Excel = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Outlook = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Powerpoint = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Word = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
            },
            ScienceMetrics = new()
            {
                DelegationCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
                RemoteComputeJobCount = 0,
                SkillsUsedCount = 0,
            },
            WebSearchCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaAnalyticsUserActivity
        {
            ChatMetrics = new()
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
            ClaudeCodeMetrics = new()
            {
                CoreMetrics = new()
                {
                    ArtifactsCreatedCount = 0,
                    CommitCount = 0,
                    DistinctSessionCount = 0,
                    LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
                    PullRequestCount = 0,
                },
                ToolActions = new()
                {
                    EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                },
            },
            CoworkMetrics = new()
            {
                ActionCount = 0,
                ArtifactsCreatedCount = 0,
                ConnectorsUsedCount = 0,
                DispatchTurnCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                WriteToolCount = 0,
            },
            DesignMetrics = new()
            {
                DistinctProjectsCreatedCount = 0,
                DistinctProjectsUsedCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
            },
            OfficeMetrics = new()
            {
                Excel = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Outlook = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Powerpoint = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Word = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
            },
            ScienceMetrics = new()
            {
                DelegationCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
                RemoteComputeJobCount = 0,
                SkillsUsedCount = 0,
            },
            WebSearchCount = 0,

            ChatCoworkUnifiedMetrics = null,
            DistinctUserCount = null,
            LastActivityDate = null,
            RbacGroupID = null,
            RbacGroupName = null,
            User = null,
        };

        Assert.Null(model.ChatCoworkUnifiedMetrics);
        Assert.True(model.RawData.ContainsKey("chat_cowork_unified_metrics"));
        Assert.Null(model.DistinctUserCount);
        Assert.True(model.RawData.ContainsKey("distinct_user_count"));
        Assert.Null(model.LastActivityDate);
        Assert.True(model.RawData.ContainsKey("last_activity_date"));
        Assert.Null(model.RbacGroupID);
        Assert.True(model.RawData.ContainsKey("rbac_group_id"));
        Assert.Null(model.RbacGroupName);
        Assert.True(model.RawData.ContainsKey("rbac_group_name"));
        Assert.Null(model.User);
        Assert.True(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaAnalyticsUserActivity
        {
            ChatMetrics = new()
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
            ClaudeCodeMetrics = new()
            {
                CoreMetrics = new()
                {
                    ArtifactsCreatedCount = 0,
                    CommitCount = 0,
                    DistinctSessionCount = 0,
                    LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
                    PullRequestCount = 0,
                },
                ToolActions = new()
                {
                    EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                },
            },
            CoworkMetrics = new()
            {
                ActionCount = 0,
                ArtifactsCreatedCount = 0,
                ConnectorsUsedCount = 0,
                DispatchTurnCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                WriteToolCount = 0,
            },
            DesignMetrics = new()
            {
                DistinctProjectsCreatedCount = 0,
                DistinctProjectsUsedCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
            },
            OfficeMetrics = new()
            {
                Excel = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Outlook = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Powerpoint = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Word = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
            },
            ScienceMetrics = new()
            {
                DelegationCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
                RemoteComputeJobCount = 0,
                SkillsUsedCount = 0,
            },
            WebSearchCount = 0,

            ChatCoworkUnifiedMetrics = null,
            DistinctUserCount = null,
            LastActivityDate = null,
            RbacGroupID = null,
            RbacGroupName = null,
            User = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsUserActivity
        {
            ChatMetrics = new()
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
            ClaudeCodeMetrics = new()
            {
                CoreMetrics = new()
                {
                    ArtifactsCreatedCount = 0,
                    CommitCount = 0,
                    DistinctSessionCount = 0,
                    LinesOfCode = new() { AddedCount = 0, RemovedCount = 0 },
                    PullRequestCount = 0,
                },
                ToolActions = new()
                {
                    EditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    MultiEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    NotebookEditTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                    WriteTool = new() { AcceptedCount = 0, RejectedCount = 0 },
                },
            },
            CoworkMetrics = new()
            {
                ActionCount = 0,
                ArtifactsCreatedCount = 0,
                ConnectorsUsedCount = 0,
                DispatchTurnCount = 0,
                DistinctConnectorsUsedCount = 0,
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                WriteToolCount = 0,
            },
            DesignMetrics = new()
            {
                DistinctProjectsCreatedCount = 0,
                DistinctProjectsUsedCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
            },
            OfficeMetrics = new()
            {
                Excel = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Outlook = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Powerpoint = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
                Word = new()
                {
                    ConnectorsUsedCount = 0,
                    DistinctConnectorsUsedCount = 0,
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                },
            },
            ScienceMetrics = new()
            {
                DelegationCount = 0,
                DistinctSessionCount = 0,
                MessageCount = 0,
                RemoteComputeJobCount = 0,
                SkillsUsedCount = 0,
            },
            WebSearchCount = 0,
            ChatCoworkUnifiedMetrics = new()
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
                    DistinctSessionCount = 0,
                    DistinctSkillsUsedCount = 0,
                    MessageCount = 0,
                    SkillsUsedCount = 0,
                    DistinctPluginsUsedCount = 0,
                    EditToolCount = 0,
                    FileEditCount = 0,
                    MultiEditToolCount = 0,
                    NotebookEditToolCount = 0,
                    PluginsUsedCount = 0,
                    SessionsWithFileEditsCount = 0,
                    WriteToolCount = 0,
                },
            },
            DistinctUserCount = 0,
            LastActivityDate = "2019-12-27",
            RbacGroupID = "rbac_group_id",
            RbacGroupName = "rbac_group_name",
            User = new() { ID = "id", EmailAddress = "email_address" },
        };

        BetaAnalyticsUserActivity copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaAnalyticsUserActivityChatCoworkUnifiedMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetrics
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
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                WriteToolCount = 0,
            },
        };

        BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat expectedChat = new()
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
        BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions expectedSessions = new()
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            WriteToolCount = 0,
        };

        Assert.Equal(expectedChat, model.Chat);
        Assert.Equal(expectedSessions, model.Sessions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetrics
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
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                WriteToolCount = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsUserActivityChatCoworkUnifiedMetrics>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetrics
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
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                WriteToolCount = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsUserActivityChatCoworkUnifiedMetrics>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat expectedChat = new()
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
        BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions expectedSessions = new()
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            WriteToolCount = 0,
        };

        Assert.Equal(expectedChat, deserialized.Chat);
        Assert.Equal(expectedSessions, deserialized.Sessions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetrics
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
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                WriteToolCount = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetrics
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
                DistinctSessionCount = 0,
                DistinctSkillsUsedCount = 0,
                MessageCount = 0,
                SkillsUsedCount = 0,
                DistinctPluginsUsedCount = 0,
                EditToolCount = 0,
                FileEditCount = 0,
                MultiEditToolCount = 0,
                NotebookEditToolCount = 0,
                PluginsUsedCount = 0,
                SessionsWithFileEditsCount = 0,
                WriteToolCount = 0,
            },
        };

        BetaAnalyticsUserActivityChatCoworkUnifiedMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChatTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat
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

        long expectedConnectorsUsedCount = 0;
        long expectedDistinctArtifactsCreatedCount = 0;
        long expectedDistinctConnectorsUsedCount = 0;
        long expectedDistinctConversationCount = 0;
        long expectedDistinctFilesUploadedCount = 0;
        long expectedDistinctProjectsCreatedCount = 0;
        long expectedDistinctProjectsUsedCount = 0;
        long expectedDistinctSharedArtifactsViewedCount = 0;
        long expectedDistinctSkillsUsedCount = 0;
        long expectedMessageCount = 0;
        long expectedSharedConversationsViewedCount = 0;
        long expectedThinkingMessageCount = 0;

        Assert.Equal(expectedConnectorsUsedCount, model.ConnectorsUsedCount);
        Assert.Equal(expectedDistinctArtifactsCreatedCount, model.DistinctArtifactsCreatedCount);
        Assert.Equal(expectedDistinctConnectorsUsedCount, model.DistinctConnectorsUsedCount);
        Assert.Equal(expectedDistinctConversationCount, model.DistinctConversationCount);
        Assert.Equal(expectedDistinctFilesUploadedCount, model.DistinctFilesUploadedCount);
        Assert.Equal(expectedDistinctProjectsCreatedCount, model.DistinctProjectsCreatedCount);
        Assert.Equal(expectedDistinctProjectsUsedCount, model.DistinctProjectsUsedCount);
        Assert.Equal(
            expectedDistinctSharedArtifactsViewedCount,
            model.DistinctSharedArtifactsViewedCount
        );
        Assert.Equal(expectedDistinctSkillsUsedCount, model.DistinctSkillsUsedCount);
        Assert.Equal(expectedMessageCount, model.MessageCount);
        Assert.Equal(expectedSharedConversationsViewedCount, model.SharedConversationsViewedCount);
        Assert.Equal(expectedThinkingMessageCount, model.ThinkingMessageCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedConnectorsUsedCount = 0;
        long expectedDistinctArtifactsCreatedCount = 0;
        long expectedDistinctConnectorsUsedCount = 0;
        long expectedDistinctConversationCount = 0;
        long expectedDistinctFilesUploadedCount = 0;
        long expectedDistinctProjectsCreatedCount = 0;
        long expectedDistinctProjectsUsedCount = 0;
        long expectedDistinctSharedArtifactsViewedCount = 0;
        long expectedDistinctSkillsUsedCount = 0;
        long expectedMessageCount = 0;
        long expectedSharedConversationsViewedCount = 0;
        long expectedThinkingMessageCount = 0;

        Assert.Equal(expectedConnectorsUsedCount, deserialized.ConnectorsUsedCount);
        Assert.Equal(
            expectedDistinctArtifactsCreatedCount,
            deserialized.DistinctArtifactsCreatedCount
        );
        Assert.Equal(expectedDistinctConnectorsUsedCount, deserialized.DistinctConnectorsUsedCount);
        Assert.Equal(expectedDistinctConversationCount, deserialized.DistinctConversationCount);
        Assert.Equal(expectedDistinctFilesUploadedCount, deserialized.DistinctFilesUploadedCount);
        Assert.Equal(
            expectedDistinctProjectsCreatedCount,
            deserialized.DistinctProjectsCreatedCount
        );
        Assert.Equal(expectedDistinctProjectsUsedCount, deserialized.DistinctProjectsUsedCount);
        Assert.Equal(
            expectedDistinctSharedArtifactsViewedCount,
            deserialized.DistinctSharedArtifactsViewedCount
        );
        Assert.Equal(expectedDistinctSkillsUsedCount, deserialized.DistinctSkillsUsedCount);
        Assert.Equal(expectedMessageCount, deserialized.MessageCount);
        Assert.Equal(
            expectedSharedConversationsViewedCount,
            deserialized.SharedConversationsViewedCount
        );
        Assert.Equal(expectedThinkingMessageCount, deserialized.ThinkingMessageCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat
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

        BetaAnalyticsUserActivityChatCoworkUnifiedMetricsChat copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            WriteToolCount = 0,
        };

        long expectedActionCount = 0;
        long expectedArtifactsCreatedCount = 0;
        long expectedConnectorsUsedCount = 0;
        long expectedDispatchTurnCount = 0;
        long expectedDistinctConnectorsUsedCount = 0;
        long expectedDistinctSessionCount = 0;
        long expectedDistinctSkillsUsedCount = 0;
        long expectedMessageCount = 0;
        long expectedSkillsUsedCount = 0;
        long expectedDistinctPluginsUsedCount = 0;
        long expectedEditToolCount = 0;
        long expectedFileEditCount = 0;
        long expectedMultiEditToolCount = 0;
        long expectedNotebookEditToolCount = 0;
        long expectedPluginsUsedCount = 0;
        long expectedSessionsWithFileEditsCount = 0;
        long expectedWriteToolCount = 0;

        Assert.Equal(expectedActionCount, model.ActionCount);
        Assert.Equal(expectedArtifactsCreatedCount, model.ArtifactsCreatedCount);
        Assert.Equal(expectedConnectorsUsedCount, model.ConnectorsUsedCount);
        Assert.Equal(expectedDispatchTurnCount, model.DispatchTurnCount);
        Assert.Equal(expectedDistinctConnectorsUsedCount, model.DistinctConnectorsUsedCount);
        Assert.Equal(expectedDistinctSessionCount, model.DistinctSessionCount);
        Assert.Equal(expectedDistinctSkillsUsedCount, model.DistinctSkillsUsedCount);
        Assert.Equal(expectedMessageCount, model.MessageCount);
        Assert.Equal(expectedSkillsUsedCount, model.SkillsUsedCount);
        Assert.Equal(expectedDistinctPluginsUsedCount, model.DistinctPluginsUsedCount);
        Assert.Equal(expectedEditToolCount, model.EditToolCount);
        Assert.Equal(expectedFileEditCount, model.FileEditCount);
        Assert.Equal(expectedMultiEditToolCount, model.MultiEditToolCount);
        Assert.Equal(expectedNotebookEditToolCount, model.NotebookEditToolCount);
        Assert.Equal(expectedPluginsUsedCount, model.PluginsUsedCount);
        Assert.Equal(expectedSessionsWithFileEditsCount, model.SessionsWithFileEditsCount);
        Assert.Equal(expectedWriteToolCount, model.WriteToolCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            WriteToolCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            WriteToolCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedActionCount = 0;
        long expectedArtifactsCreatedCount = 0;
        long expectedConnectorsUsedCount = 0;
        long expectedDispatchTurnCount = 0;
        long expectedDistinctConnectorsUsedCount = 0;
        long expectedDistinctSessionCount = 0;
        long expectedDistinctSkillsUsedCount = 0;
        long expectedMessageCount = 0;
        long expectedSkillsUsedCount = 0;
        long expectedDistinctPluginsUsedCount = 0;
        long expectedEditToolCount = 0;
        long expectedFileEditCount = 0;
        long expectedMultiEditToolCount = 0;
        long expectedNotebookEditToolCount = 0;
        long expectedPluginsUsedCount = 0;
        long expectedSessionsWithFileEditsCount = 0;
        long expectedWriteToolCount = 0;

        Assert.Equal(expectedActionCount, deserialized.ActionCount);
        Assert.Equal(expectedArtifactsCreatedCount, deserialized.ArtifactsCreatedCount);
        Assert.Equal(expectedConnectorsUsedCount, deserialized.ConnectorsUsedCount);
        Assert.Equal(expectedDispatchTurnCount, deserialized.DispatchTurnCount);
        Assert.Equal(expectedDistinctConnectorsUsedCount, deserialized.DistinctConnectorsUsedCount);
        Assert.Equal(expectedDistinctSessionCount, deserialized.DistinctSessionCount);
        Assert.Equal(expectedDistinctSkillsUsedCount, deserialized.DistinctSkillsUsedCount);
        Assert.Equal(expectedMessageCount, deserialized.MessageCount);
        Assert.Equal(expectedSkillsUsedCount, deserialized.SkillsUsedCount);
        Assert.Equal(expectedDistinctPluginsUsedCount, deserialized.DistinctPluginsUsedCount);
        Assert.Equal(expectedEditToolCount, deserialized.EditToolCount);
        Assert.Equal(expectedFileEditCount, deserialized.FileEditCount);
        Assert.Equal(expectedMultiEditToolCount, deserialized.MultiEditToolCount);
        Assert.Equal(expectedNotebookEditToolCount, deserialized.NotebookEditToolCount);
        Assert.Equal(expectedPluginsUsedCount, deserialized.PluginsUsedCount);
        Assert.Equal(expectedSessionsWithFileEditsCount, deserialized.SessionsWithFileEditsCount);
        Assert.Equal(expectedWriteToolCount, deserialized.WriteToolCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            WriteToolCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
        };

        Assert.Null(model.DistinctPluginsUsedCount);
        Assert.False(model.RawData.ContainsKey("distinct_plugins_used_count"));
        Assert.Null(model.EditToolCount);
        Assert.False(model.RawData.ContainsKey("edit_tool_count"));
        Assert.Null(model.FileEditCount);
        Assert.False(model.RawData.ContainsKey("file_edit_count"));
        Assert.Null(model.MultiEditToolCount);
        Assert.False(model.RawData.ContainsKey("multi_edit_tool_count"));
        Assert.Null(model.NotebookEditToolCount);
        Assert.False(model.RawData.ContainsKey("notebook_edit_tool_count"));
        Assert.Null(model.PluginsUsedCount);
        Assert.False(model.RawData.ContainsKey("plugins_used_count"));
        Assert.Null(model.SessionsWithFileEditsCount);
        Assert.False(model.RawData.ContainsKey("sessions_with_file_edits_count"));
        Assert.Null(model.WriteToolCount);
        Assert.False(model.RawData.ContainsKey("write_tool_count"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,

            DistinctPluginsUsedCount = null,
            EditToolCount = null,
            FileEditCount = null,
            MultiEditToolCount = null,
            NotebookEditToolCount = null,
            PluginsUsedCount = null,
            SessionsWithFileEditsCount = null,
            WriteToolCount = null,
        };

        Assert.Null(model.DistinctPluginsUsedCount);
        Assert.True(model.RawData.ContainsKey("distinct_plugins_used_count"));
        Assert.Null(model.EditToolCount);
        Assert.True(model.RawData.ContainsKey("edit_tool_count"));
        Assert.Null(model.FileEditCount);
        Assert.True(model.RawData.ContainsKey("file_edit_count"));
        Assert.Null(model.MultiEditToolCount);
        Assert.True(model.RawData.ContainsKey("multi_edit_tool_count"));
        Assert.Null(model.NotebookEditToolCount);
        Assert.True(model.RawData.ContainsKey("notebook_edit_tool_count"));
        Assert.Null(model.PluginsUsedCount);
        Assert.True(model.RawData.ContainsKey("plugins_used_count"));
        Assert.Null(model.SessionsWithFileEditsCount);
        Assert.True(model.RawData.ContainsKey("sessions_with_file_edits_count"));
        Assert.Null(model.WriteToolCount);
        Assert.True(model.RawData.ContainsKey("write_tool_count"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,

            DistinctPluginsUsedCount = null,
            EditToolCount = null,
            FileEditCount = null,
            MultiEditToolCount = null,
            NotebookEditToolCount = null,
            PluginsUsedCount = null,
            SessionsWithFileEditsCount = null,
            WriteToolCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            WriteToolCount = 0,
        };

        BetaAnalyticsUserActivityChatCoworkUnifiedMetricsSessions copied = new(model);

        Assert.Equal(model, copied);
    }
}
