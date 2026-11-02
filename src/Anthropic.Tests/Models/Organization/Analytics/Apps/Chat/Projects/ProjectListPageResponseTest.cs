using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Analytics;
using Anthropic.Models.Organization.Analytics.Apps.Chat.Projects;

namespace Anthropic.Tests.Models.Organization.Analytics.Apps.Chat.Projects;

public class ProjectListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProjectListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedBy = new() { ID = "id", EmailAddress = "email_address" },
                    DistinctConversationCount = 0,
                    DistinctUserCount = 0,
                    MessageCount = 0,
                    ProjectID = "project_id",
                    ProjectName = "project_name",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        List<AnalyticsProjectActivity> expectedData =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { ID = "id", EmailAddress = "email_address" },
                DistinctConversationCount = 0,
                DistinctUserCount = 0,
                MessageCount = 0,
                ProjectID = "project_id",
                ProjectName = "project_name",
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
        var model = new ProjectListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedBy = new() { ID = "id", EmailAddress = "email_address" },
                    DistinctConversationCount = 0,
                    DistinctUserCount = 0,
                    MessageCount = 0,
                    ProjectID = "project_id",
                    ProjectName = "project_name",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProjectListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProjectListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedBy = new() { ID = "id", EmailAddress = "email_address" },
                    DistinctConversationCount = 0,
                    DistinctUserCount = 0,
                    MessageCount = 0,
                    ProjectID = "project_id",
                    ProjectName = "project_name",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProjectListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AnalyticsProjectActivity> expectedData =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedBy = new() { ID = "id", EmailAddress = "email_address" },
                DistinctConversationCount = 0,
                DistinctUserCount = 0,
                MessageCount = 0,
                ProjectID = "project_id",
                ProjectName = "project_name",
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
        var model = new ProjectListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedBy = new() { ID = "id", EmailAddress = "email_address" },
                    DistinctConversationCount = 0,
                    DistinctUserCount = 0,
                    MessageCount = 0,
                    ProjectID = "project_id",
                    ProjectName = "project_name",
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
        var model = new ProjectListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedBy = new() { ID = "id", EmailAddress = "email_address" },
                    DistinctConversationCount = 0,
                    DistinctUserCount = 0,
                    MessageCount = 0,
                    ProjectID = "project_id",
                    ProjectName = "project_name",
                    RbacGroupID = "rbac_group_id",
                    RbacGroupName = "rbac_group_name",
                    UserID = "user_id",
                },
            ],
            NextPage = "next_page",
        };

        ProjectListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
