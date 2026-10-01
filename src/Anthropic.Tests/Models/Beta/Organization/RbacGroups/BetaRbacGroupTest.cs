using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.RbacGroups;

namespace Anthropic.Tests.Models.Beta.Organization.RbacGroups;

public class BetaRbacGroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRbacGroup
        {
            ID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Engineering",
            RoleIds = ["rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s"],
            SourceType = SourceType.Direct,
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        string expectedID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedName = "Engineering";
        List<string> expectedRoleIds = ["rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s"];
        ApiEnum<string, SourceType> expectedSourceType = SourceType.Direct;
        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_group");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.RoleIds);
        Assert.Equal(expectedRoleIds.Count, model.RoleIds.Count);
        for (int i = 0; i < expectedRoleIds.Count; i++)
        {
            Assert.Equal(expectedRoleIds[i], model.RoleIds[i]);
        }
        Assert.Equal(expectedSourceType, model.SourceType);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRbacGroup
        {
            ID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Engineering",
            RoleIds = ["rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s"],
            SourceType = SourceType.Direct,
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacGroup>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRbacGroup
        {
            ID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Engineering",
            RoleIds = ["rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s"],
            SourceType = SourceType.Direct,
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacGroup>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedName = "Engineering";
        List<string> expectedRoleIds = ["rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s"];
        ApiEnum<string, SourceType> expectedSourceType = SourceType.Direct;
        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_group");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.RoleIds);
        Assert.Equal(expectedRoleIds.Count, deserialized.RoleIds.Count);
        for (int i = 0; i < expectedRoleIds.Count; i++)
        {
            Assert.Equal(expectedRoleIds[i], deserialized.RoleIds[i]);
        }
        Assert.Equal(expectedSourceType, deserialized.SourceType);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaRbacGroup
        {
            ID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Engineering",
            RoleIds = ["rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s"],
            SourceType = SourceType.Direct,
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaRbacGroup
        {
            ID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Engineering",
            RoleIds = ["rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s"],
            SourceType = SourceType.Direct,
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
        };

        BetaRbacGroup copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SourceTypeTest : TestBase
{
    [Theory]
    [InlineData(SourceType.Direct)]
    [InlineData(SourceType.Scim)]
    public void Validation_Works(SourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SourceType.Direct)]
    [InlineData(SourceType.Scim)]
    public void SerializationRoundtrip_Works(SourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
