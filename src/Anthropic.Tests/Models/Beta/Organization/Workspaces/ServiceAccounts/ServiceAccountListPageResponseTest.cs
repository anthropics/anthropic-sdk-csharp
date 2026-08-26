using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Workspaces;
using Anthropic.Models.Beta.Organization.Workspaces.ServiceAccounts;
using ServiceAccounts = Anthropic.Models.Beta.Organization.ServiceAccounts;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces.ServiceAccounts;

public class ServiceAccountListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ServiceAccountListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedByActorID = "created_by_actor_id",
                    Implicit = true,
                    ServiceAccountID = "service_account_id",
                    WorkspaceID = "workspace_id",
                    WorkspaceRole = BetaWorkspaceRole.WorkspaceAdmin,
                },
            ],
            NextPage = "next_page",
        };

        List<ServiceAccounts::BetaServiceAccountWorkspaceMember> expectedData =
        [
            new()
            {
                CreatedByActorID = "created_by_actor_id",
                Implicit = true,
                ServiceAccountID = "service_account_id",
                WorkspaceID = "workspace_id",
                WorkspaceRole = BetaWorkspaceRole.WorkspaceAdmin,
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
        var model = new ServiceAccountListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedByActorID = "created_by_actor_id",
                    Implicit = true,
                    ServiceAccountID = "service_account_id",
                    WorkspaceID = "workspace_id",
                    WorkspaceRole = BetaWorkspaceRole.WorkspaceAdmin,
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServiceAccountListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ServiceAccountListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedByActorID = "created_by_actor_id",
                    Implicit = true,
                    ServiceAccountID = "service_account_id",
                    WorkspaceID = "workspace_id",
                    WorkspaceRole = BetaWorkspaceRole.WorkspaceAdmin,
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServiceAccountListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ServiceAccounts::BetaServiceAccountWorkspaceMember> expectedData =
        [
            new()
            {
                CreatedByActorID = "created_by_actor_id",
                Implicit = true,
                ServiceAccountID = "service_account_id",
                WorkspaceID = "workspace_id",
                WorkspaceRole = BetaWorkspaceRole.WorkspaceAdmin,
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
        var model = new ServiceAccountListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedByActorID = "created_by_actor_id",
                    Implicit = true,
                    ServiceAccountID = "service_account_id",
                    WorkspaceID = "workspace_id",
                    WorkspaceRole = BetaWorkspaceRole.WorkspaceAdmin,
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ServiceAccountListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedByActorID = "created_by_actor_id",
                    Implicit = true,
                    ServiceAccountID = "service_account_id",
                    WorkspaceID = "workspace_id",
                    WorkspaceRole = BetaWorkspaceRole.WorkspaceAdmin,
                },
            ],
            NextPage = "next_page",
        };

        ServiceAccountListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
