using System;
using Anthropic.Models.Beta.Organization.RbacGroups.Members;

namespace Anthropic.Tests.Models.Beta.Organization.RbacGroups.Members;

public class MemberListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemberListParams
        {
            RbacGroupID = "rbac_group_id",
            Limit = 1,
            Page = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9",
        };

        string expectedRbacGroupID = "rbac_group_id";
        long expectedLimit = 1;
        string expectedPage = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9";

        Assert.Equal(expectedRbacGroupID, parameters.RbacGroupID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MemberListParams
        {
            RbacGroupID = "rbac_group_id",
            Page = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MemberListParams
        {
            RbacGroupID = "rbac_group_id",
            Page = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MemberListParams { RbacGroupID = "rbac_group_id", Limit = 1 };

        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MemberListParams
        {
            RbacGroupID = "rbac_group_id",
            Limit = 1,

            Page = null,
        };

        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void Url_Works()
    {
        MemberListParams parameters = new()
        {
            RbacGroupID = "rbac_group_id",
            Limit = 1,
            Page = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/rbac_groups/rbac_group_id/members?beta=true&limit=1&page=eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MemberListParams
        {
            RbacGroupID = "rbac_group_id",
            Limit = 1,
            Page = "eyJjdXJzb3IiOiAicmJhY19ncm91cF8wMSJ9",
        };

        MemberListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
