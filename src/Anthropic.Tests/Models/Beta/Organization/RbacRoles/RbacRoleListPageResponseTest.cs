using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.RbacRoles;

namespace Anthropic.Tests.Models.Beta.Organization.RbacRoles;

public class RbacRoleListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RbacRoleListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Name = "Project Editor",
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            HasMore = true,
            NextPage = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",
        };

        List<BetaRbacRole> expectedData =
        [
            new()
            {
                ID = "rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s",
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                Name = "Project Editor",
                UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            },
        ];
        bool expectedHasMore = true;
        string expectedNextPage = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0";

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
        var model = new RbacRoleListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Name = "Project Editor",
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            HasMore = true,
            NextPage = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacRoleListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RbacRoleListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Name = "Project Editor",
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            HasMore = true,
            NextPage = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacRoleListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaRbacRole> expectedData =
        [
            new()
            {
                ID = "rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s",
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                Name = "Project Editor",
                UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            },
        ];
        bool expectedHasMore = true;
        string expectedNextPage = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0";

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
        var model = new RbacRoleListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Name = "Project Editor",
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            HasMore = true,
            NextPage = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RbacRoleListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "rbac_role_016J8xVtKpDq3Wy9ZmN2hR4s",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Name = "Project Editor",
                    UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                },
            ],
            HasMore = true,
            NextPage = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",
        };

        RbacRoleListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
