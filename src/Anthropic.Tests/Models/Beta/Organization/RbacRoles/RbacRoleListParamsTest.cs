using System;
using Anthropic.Models.Beta.Organization.RbacRoles;

namespace Anthropic.Tests.Models.Beta.Organization.RbacRoles;

public class RbacRoleListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RbacRoleListParams
        {
            Limit = 1,
            Page = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",
        };

        long expectedLimit = 1;
        string expectedPage = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0";

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RbacRoleListParams { Page = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RbacRoleListParams
        {
            Page = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RbacRoleListParams { Limit = 1 };

        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RbacRoleListParams
        {
            Limit = 1,

            Page = null,
        };

        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void Url_Works()
    {
        RbacRoleListParams parameters = new()
        {
            Limit = 1,
            Page = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/rbac_roles?beta=true&limit=1&page=eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RbacRoleListParams
        {
            Limit = 1,
            Page = "eyJjdXJzb3IiOiAicmJhY19yb2xlXzAxIn0",
        };

        RbacRoleListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
