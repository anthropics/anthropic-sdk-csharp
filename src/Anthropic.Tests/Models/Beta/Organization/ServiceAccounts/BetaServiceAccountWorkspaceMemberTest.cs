using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ServiceAccounts;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.ServiceAccounts;

public class BetaServiceAccountWorkspaceMemberTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaServiceAccountWorkspaceMember
        {
            CreatedByActorID = "created_by_actor_id",
            Implicit = true,
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
            WorkspaceRole = BetaWorkspaceRole.WorkspaceAdmin,
        };

        string expectedCreatedByActorID = "created_by_actor_id";
        bool expectedImplicit = true;
        string expectedServiceAccountID = "service_account_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "service_account_workspace_member"
        );
        string expectedWorkspaceID = "workspace_id";
        ApiEnum<string, BetaWorkspaceRole> expectedWorkspaceRole = BetaWorkspaceRole.WorkspaceAdmin;

        Assert.Equal(expectedCreatedByActorID, model.CreatedByActorID);
        Assert.Equal(expectedImplicit, model.Implicit);
        Assert.Equal(expectedServiceAccountID, model.ServiceAccountID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
        Assert.Equal(expectedWorkspaceRole, model.WorkspaceRole);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaServiceAccountWorkspaceMember
        {
            CreatedByActorID = "created_by_actor_id",
            Implicit = true,
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
            WorkspaceRole = BetaWorkspaceRole.WorkspaceAdmin,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaServiceAccountWorkspaceMember>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaServiceAccountWorkspaceMember
        {
            CreatedByActorID = "created_by_actor_id",
            Implicit = true,
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
            WorkspaceRole = BetaWorkspaceRole.WorkspaceAdmin,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaServiceAccountWorkspaceMember>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCreatedByActorID = "created_by_actor_id";
        bool expectedImplicit = true;
        string expectedServiceAccountID = "service_account_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "service_account_workspace_member"
        );
        string expectedWorkspaceID = "workspace_id";
        ApiEnum<string, BetaWorkspaceRole> expectedWorkspaceRole = BetaWorkspaceRole.WorkspaceAdmin;

        Assert.Equal(expectedCreatedByActorID, deserialized.CreatedByActorID);
        Assert.Equal(expectedImplicit, deserialized.Implicit);
        Assert.Equal(expectedServiceAccountID, deserialized.ServiceAccountID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
        Assert.Equal(expectedWorkspaceRole, deserialized.WorkspaceRole);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaServiceAccountWorkspaceMember
        {
            CreatedByActorID = "created_by_actor_id",
            Implicit = true,
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
            WorkspaceRole = BetaWorkspaceRole.WorkspaceAdmin,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaServiceAccountWorkspaceMember
        {
            CreatedByActorID = "created_by_actor_id",
            Implicit = true,
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
            WorkspaceRole = BetaWorkspaceRole.WorkspaceAdmin,
        };

        BetaServiceAccountWorkspaceMember copied = new(model);

        Assert.Equal(model, copied);
    }
}
