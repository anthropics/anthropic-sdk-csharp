using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ServiceAccounts;
using Anthropic.Models.Beta.Organization.ServiceAccounts.Workspaces;
using Workspaces = Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.ServiceAccounts.Workspaces;

public class WorkspaceListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkspaceListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedByActorID = "created_by_actor_id",
                    Implicit = true,
                    ServiceAccountID = "service_account_id",
                    WorkspaceID = "workspace_id",
                    WorkspaceRole = Workspaces::BetaWorkspaceRole.WorkspaceAdmin,
                },
            ],
            NextPage = "next_page",
        };

        List<BetaServiceAccountWorkspaceMember> expectedData =
        [
            new()
            {
                CreatedByActorID = "created_by_actor_id",
                Implicit = true,
                ServiceAccountID = "service_account_id",
                WorkspaceID = "workspace_id",
                WorkspaceRole = Workspaces::BetaWorkspaceRole.WorkspaceAdmin,
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
        var model = new WorkspaceListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedByActorID = "created_by_actor_id",
                    Implicit = true,
                    ServiceAccountID = "service_account_id",
                    WorkspaceID = "workspace_id",
                    WorkspaceRole = Workspaces::BetaWorkspaceRole.WorkspaceAdmin,
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspaceListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkspaceListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedByActorID = "created_by_actor_id",
                    Implicit = true,
                    ServiceAccountID = "service_account_id",
                    WorkspaceID = "workspace_id",
                    WorkspaceRole = Workspaces::BetaWorkspaceRole.WorkspaceAdmin,
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspaceListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaServiceAccountWorkspaceMember> expectedData =
        [
            new()
            {
                CreatedByActorID = "created_by_actor_id",
                Implicit = true,
                ServiceAccountID = "service_account_id",
                WorkspaceID = "workspace_id",
                WorkspaceRole = Workspaces::BetaWorkspaceRole.WorkspaceAdmin,
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
        var model = new WorkspaceListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedByActorID = "created_by_actor_id",
                    Implicit = true,
                    ServiceAccountID = "service_account_id",
                    WorkspaceID = "workspace_id",
                    WorkspaceRole = Workspaces::BetaWorkspaceRole.WorkspaceAdmin,
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkspaceListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedByActorID = "created_by_actor_id",
                    Implicit = true,
                    ServiceAccountID = "service_account_id",
                    WorkspaceID = "workspace_id",
                    WorkspaceRole = Workspaces::BetaWorkspaceRole.WorkspaceAdmin,
                },
            ],
            NextPage = "next_page",
        };

        WorkspaceListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
