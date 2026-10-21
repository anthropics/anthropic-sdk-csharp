using System;
using Anthropic.Models.Beta.Organization.RbacGroups;

namespace Anthropic.Tests.Models.Beta.Organization.RbacGroups;

public class RbacGroupListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RbacGroupListParams
        {
            Limit = 1,
            Page = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9",
        };

        long expectedLimit = 1;
        string expectedPage = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9";

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RbacGroupListParams { Page = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RbacGroupListParams
        {
            Page = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new RbacGroupListParams
        {
            Limit = 1,
            Page = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9",
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
        var parameters = new RbacGroupListParams { Limit = 1 };

        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RbacGroupListParams
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
        RbacGroupListParams parameters = new()
        {
            Limit = 1,
            Page = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/rbac_groups?beta=true&limit=1&page=eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RbacGroupListParams
        {
            Limit = 1,
            Page = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9",
        };

        RbacGroupListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
