using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Workspaces.Members;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces.Members;

public class MemberRemoveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MemberRemoveResponse
        {
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("workspace_member_deleted");
        string expectedUserID = "user_01WCz1FkmYMm4gnmykNKUu3Q";
        string expectedWorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MemberRemoveResponse
        {
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MemberRemoveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MemberRemoveResponse
        {
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MemberRemoveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("workspace_member_deleted");
        string expectedUserID = "user_01WCz1FkmYMm4gnmykNKUu3Q";
        string expectedWorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MemberRemoveResponse
        {
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MemberRemoveResponse
        {
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            WorkspaceID = "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ",
        };

        MemberRemoveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
