using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;
using Anthropic.Models.Beta.Organization.Analytics.Users;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Users;

public class UserListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        List<BetaAnalyticsUserActivity> expectedData =
        [
            new()
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
        var model = new UserListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaAnalyticsUserActivity> expectedData =
        [
            new()
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
        var model = new UserListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        UserListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
