using System;
using Anthropic.Models.Beta.Organization.RbacRoles.Permissions;

namespace Anthropic.Tests.Models.Beta.Organization.RbacRoles.Permissions;

public class PermissionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PermissionListParams
        {
            RbacRoleID = "rbac_role_id",
            Limit = 1,
            Page = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",
        };

        string expectedRbacRoleID = "rbac_role_id";
        long expectedLimit = 1;
        string expectedPage = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0";

        Assert.Equal(expectedRbacRoleID, parameters.RbacRoleID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PermissionListParams
        {
            RbacRoleID = "rbac_role_id",
            Page = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PermissionListParams
        {
            RbacRoleID = "rbac_role_id",
            Page = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new PermissionListParams
        {
            RbacRoleID = "rbac_role_id",
            Limit = 1,
            Page = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",
        } with
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PermissionListParams { RbacRoleID = "rbac_role_id", Limit = 1 };

        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PermissionListParams
        {
            RbacRoleID = "rbac_role_id",
            Limit = 1,

            Page = null,
        };

        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void Url_Works()
    {
        PermissionListParams parameters = new()
        {
            RbacRoleID = "rbac_role_id",
            Limit = 1,
            Page = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/rbac_roles/rbac_role_id/permissions?beta=true&limit=1&page=eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PermissionListParams
        {
            RbacRoleID = "rbac_role_id",
            Limit = 1,
            Page = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",
        };

        PermissionListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
