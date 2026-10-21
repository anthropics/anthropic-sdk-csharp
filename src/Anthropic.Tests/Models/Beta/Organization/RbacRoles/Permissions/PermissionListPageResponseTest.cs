using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.RbacRoles.Permissions;

namespace Anthropic.Tests.Models.Beta.Organization.RbacRoles.Permissions;

public class PermissionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PermissionListPageResponse
        {
            Data =
            [
                new()
                {
                    Action = "use",
                    Resource = new BetaRbacOrganizationPermissionResource(
                        "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
                    ),
                },
            ],
            HasMore = true,
            NextPage = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",
        };

        List<BetaRbacRolePermission> expectedData =
        [
            new()
            {
                Action = "use",
                Resource = new BetaRbacOrganizationPermissionResource(
                    "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
                ),
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
        var model = new PermissionListPageResponse
        {
            Data =
            [
                new()
                {
                    Action = "use",
                    Resource = new BetaRbacOrganizationPermissionResource(
                        "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
                    ),
                },
            ],
            HasMore = true,
            NextPage = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PermissionListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PermissionListPageResponse
        {
            Data =
            [
                new()
                {
                    Action = "use",
                    Resource = new BetaRbacOrganizationPermissionResource(
                        "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
                    ),
                },
            ],
            HasMore = true,
            NextPage = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PermissionListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaRbacRolePermission> expectedData =
        [
            new()
            {
                Action = "use",
                Resource = new BetaRbacOrganizationPermissionResource(
                    "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
                ),
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
        var model = new PermissionListPageResponse
        {
            Data =
            [
                new()
                {
                    Action = "use",
                    Resource = new BetaRbacOrganizationPermissionResource(
                        "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
                    ),
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
        var model = new PermissionListPageResponse
        {
            Data =
            [
                new()
                {
                    Action = "use",
                    Resource = new BetaRbacOrganizationPermissionResource(
                        "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
                    ),
                },
            ],
            HasMore = true,
            NextPage = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",
        };

        PermissionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
