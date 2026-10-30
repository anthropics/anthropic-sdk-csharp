using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.RbacGroups.Members;

namespace Anthropic.Tests.Models.Organization.RbacGroups.Members;

public class DeletedRbacGroupMemberTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeletedRbacGroupMember
        {
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };

        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_group_member_deleted");
        string expectedUserID = "user_01WxYzAbCdEfGhJkMnPqRsTu";

        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeletedRbacGroupMember
        {
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeletedRbacGroupMember>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeletedRbacGroupMember
        {
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeletedRbacGroupMember>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_group_member_deleted");
        string expectedUserID = "user_01WxYzAbCdEfGhJkMnPqRsTu";

        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeletedRbacGroupMember
        {
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeletedRbacGroupMember
        {
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };

        DeletedRbacGroupMember copied = new(model);

        Assert.Equal(model, copied);
    }
}
