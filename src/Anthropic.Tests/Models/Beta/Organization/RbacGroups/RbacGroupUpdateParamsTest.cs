using System;
using Anthropic.Models.Beta.Organization.RbacGroups;

namespace Anthropic.Tests.Models.Beta.Organization.RbacGroups;

public class RbacGroupUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RbacGroupUpdateParams
        {
            RbacGroupID = "rbac_group_id",
            Name = "Engineering",
        };

        string expectedRbacGroupID = "rbac_group_id";
        string expectedName = "Engineering";

        Assert.Equal(expectedRbacGroupID, parameters.RbacGroupID);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RbacGroupUpdateParams { RbacGroupID = "rbac_group_id" };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RbacGroupUpdateParams
        {
            RbacGroupID = "rbac_group_id",

            Name = null,
        };

        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        RbacGroupUpdateParams parameters = new() { RbacGroupID = "rbac_group_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/rbac_groups/rbac_group_id?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RbacGroupUpdateParams
        {
            RbacGroupID = "rbac_group_id",
            Name = "Engineering",
        };

        RbacGroupUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
