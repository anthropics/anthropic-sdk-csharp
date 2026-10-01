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

            DistinctUserCount = null,
            LastActivityDate = null,
            RbacGroupID = null,
            RbacGroupName = null,
            User = null,
        };

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
