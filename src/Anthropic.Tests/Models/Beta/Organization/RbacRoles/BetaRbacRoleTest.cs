using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.RbacRoles;

namespace Anthropic.Tests.Models.Beta.Organization.RbacRoles;

public class BetaRbacRoleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRbacRole
        {
            ID = "rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "Project Editor",
            Name = "Project Editor",
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        string expectedID = "rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedDisplayName = "Project Editor";
        string expectedName = "Project Editor";
        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_role");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRbacRole
        {
            ID = "rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "Project Editor",
            Name = "Project Editor",
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacRole>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRbacRole
        {
            ID = "rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "Project Editor",
            Name = "Project Editor",
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacRole>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedDisplayName = "Project Editor";
        string expectedName = "Project Editor";
        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_role");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaRbacRole
        {
            ID = "rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "Project Editor",
            Name = "Project Editor",
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaRbacRole
        {
            ID = "rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            DisplayName = "Project Editor",
            Name = "Project Editor",
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        BetaRbacRole copied = new(model);

        Assert.Equal(model, copied);
    }
}
