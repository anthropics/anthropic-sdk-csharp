using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Federation.Rules;

namespace Anthropic.Tests.Models.Beta.Organization.Federation.Rules;

public class BetaFederationRuleWorkspaceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaFederationRuleWorkspace
        {
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedByActorID = "created_by_actor_id",
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
            WorkspaceName = "workspace_name",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedCreatedByActorID = "created_by_actor_id";
        string expectedFederationRuleID = "federation_rule_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("federation_rule_workspace");
        string expectedWorkspaceID = "workspace_id";
        string expectedWorkspaceName = "workspace_name";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedByActorID, model.CreatedByActorID);
        Assert.Equal(expectedFederationRuleID, model.FederationRuleID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
        Assert.Equal(expectedWorkspaceName, model.WorkspaceName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaFederationRuleWorkspace
        {
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedByActorID = "created_by_actor_id",
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
            WorkspaceName = "workspace_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFederationRuleWorkspace>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaFederationRuleWorkspace
        {
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedByActorID = "created_by_actor_id",
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
            WorkspaceName = "workspace_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFederationRuleWorkspace>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedCreatedByActorID = "created_by_actor_id";
        string expectedFederationRuleID = "federation_rule_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("federation_rule_workspace");
        string expectedWorkspaceID = "workspace_id";
        string expectedWorkspaceName = "workspace_name";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedByActorID, deserialized.CreatedByActorID);
        Assert.Equal(expectedFederationRuleID, deserialized.FederationRuleID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
        Assert.Equal(expectedWorkspaceName, deserialized.WorkspaceName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaFederationRuleWorkspace
        {
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedByActorID = "created_by_actor_id",
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
            WorkspaceName = "workspace_name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaFederationRuleWorkspace
        {
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedByActorID = "created_by_actor_id",
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
            WorkspaceName = "workspace_name",
        };

        BetaFederationRuleWorkspace copied = new(model);

        Assert.Equal(model, copied);
    }
}
