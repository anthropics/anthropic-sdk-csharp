using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.RbacGroups.Members;

namespace Anthropic.Tests.Models.Organization.RbacGroups.Members;

public class RbacGroupMemberTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RbacGroupMember
        {
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Email = "user@emaildomain.com",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedEmail = "user@emaildomain.com";
        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_group_member");
        string expectedUserID = "user_01WxYzAbCdEfGhJkMnPqRsTu";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedRbacGroupID, model.RbacGroupID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RbacGroupMember
        {
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Email = "user@emaildomain.com",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacGroupMember>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RbacGroupMember
        {
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Email = "user@emaildomain.com",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacGroupMember>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedEmail = "user@emaildomain.com";
        string expectedRbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_group_member");
        string expectedUserID = "user_01WxYzAbCdEfGhJkMnPqRsTu";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedRbacGroupID, deserialized.RbacGroupID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RbacGroupMember
        {
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Email = "user@emaildomain.com",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RbacGroupMember
        {
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Email = "user@emaildomain.com",
            RbacGroupID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
        };

        RbacGroupMember copied = new(model);

        Assert.Equal(model, copied);
    }
}
