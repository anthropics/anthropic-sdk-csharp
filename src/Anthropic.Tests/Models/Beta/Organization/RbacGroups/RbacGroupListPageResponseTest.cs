using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.RbacGroups;

namespace Anthropic.Tests.Models.Beta.Organization.RbacGroups;

public class RbacGroupListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RbacGroupListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Name = "Engineering",
                    RoleIds = ["rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s"],
                    SourceType = SourceType.Direct,
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            HasMore = false,
            NextPage = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9",
        };

        List<BetaRbacGroup> expectedData =
        [
            new()
            {
                ID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                Name = "Engineering",
                RoleIds = ["rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s"],
                SourceType = SourceType.Direct,
                UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            },
        ];
        bool expectedHasMore = false;
        string expectedNextPage = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RbacGroupListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Name = "Engineering",
                    RoleIds = ["rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s"],
                    SourceType = SourceType.Direct,
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            HasMore = false,
            NextPage = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacGroupListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RbacGroupListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Name = "Engineering",
                    RoleIds = ["rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s"],
                    SourceType = SourceType.Direct,
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            HasMore = false,
            NextPage = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacGroupListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaRbacGroup> expectedData =
        [
            new()
            {
                ID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                Name = "Engineering",
                RoleIds = ["rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s"],
                SourceType = SourceType.Direct,
                UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            },
        ];
        bool expectedHasMore = false;
        string expectedNextPage = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RbacGroupListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Name = "Engineering",
                    RoleIds = ["rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s"],
                    SourceType = SourceType.Direct,
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            HasMore = false,
            NextPage = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RbacGroupListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "rbac_group_012rppKaSVsmTo6NqRDXQXNF",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Name = "Engineering",
                    RoleIds = ["rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s"],
                    SourceType = SourceType.Direct,
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            HasMore = false,
            NextPage = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9",
        };

        RbacGroupListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
