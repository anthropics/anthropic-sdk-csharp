using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Federation.Rules.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Federation.Rules.Workspaces;

public class WorkspaceRemoveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkspaceRemoveResponse
        {
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
        };

        string expectedFederationRuleID = "federation_rule_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "federation_rule_workspace_deleted"
        );
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedFederationRuleID, model.FederationRuleID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkspaceRemoveResponse
        {
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspaceRemoveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkspaceRemoveResponse
        {
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspaceRemoveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFederationRuleID = "federation_rule_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "federation_rule_workspace_deleted"
        );
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedFederationRuleID, deserialized.FederationRuleID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkspaceRemoveResponse
        {
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkspaceRemoveResponse
        {
            FederationRuleID = "federation_rule_id",
            WorkspaceID = "workspace_id",
        };

        WorkspaceRemoveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
