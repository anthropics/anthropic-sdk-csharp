using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ServiceAccounts.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.ServiceAccounts.Workspaces;

public class WorkspaceRemoveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkspaceRemoveResponse
        {
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
        };

        string expectedServiceAccountID = "service_account_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "service_account_workspace_member_deleted"
        );
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedServiceAccountID, model.ServiceAccountID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkspaceRemoveResponse
        {
            ServiceAccountID = "service_account_id",
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
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspaceRemoveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedServiceAccountID = "service_account_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "service_account_workspace_member_deleted"
        );
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedServiceAccountID, deserialized.ServiceAccountID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkspaceRemoveResponse
        {
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkspaceRemoveResponse
        {
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
        };

        WorkspaceRemoveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
