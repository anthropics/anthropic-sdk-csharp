using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Workspaces;

namespace Anthropic.Tests.Models.Organization.Workspaces;

public class WorkspaceMemberTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkspaceMember
        {
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            WorkspaceRole = WorkspaceRole.WorkspaceAdmin,
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("workspace_member");
        string expectedUserID = "user_01WCz1FkmYMm4gnmykNKUu3Q";
        string expectedWorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ";
        ApiEnum<string, WorkspaceRole> expectedWorkspaceRole = WorkspaceRole.WorkspaceAdmin;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
        Assert.Equal(expectedWorkspaceRole, model.WorkspaceRole);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkspaceMember
        {
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            WorkspaceRole = WorkspaceRole.WorkspaceAdmin,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspaceMember>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkspaceMember
        {
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            WorkspaceRole = WorkspaceRole.WorkspaceAdmin,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspaceMember>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("workspace_member");
        string expectedUserID = "user_01WCz1FkmYMm4gnmykNKUu3Q";
        string expectedWorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ";
        ApiEnum<string, WorkspaceRole> expectedWorkspaceRole = WorkspaceRole.WorkspaceAdmin;

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
        Assert.Equal(expectedWorkspaceRole, deserialized.WorkspaceRole);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkspaceMember
        {
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            WorkspaceRole = WorkspaceRole.WorkspaceAdmin,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkspaceMember
        {
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
            WorkspaceRole = WorkspaceRole.WorkspaceAdmin,
        };

        WorkspaceMember copied = new(model);

        Assert.Equal(model, copied);
    }
}
