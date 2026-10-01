using System;
using Anthropic.Models.Beta.Organization.RbacGroups;

namespace Anthropic.Tests.Models.Beta.Organization.RbacGroups;

public class RbacGroupDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RbacGroupDeleteParams { RbacGroupID = "rbac_group_id" };

        string expectedRbacGroupID = "rbac_group_id";

        Assert.Equal(expectedRbacGroupID, parameters.RbacGroupID);
    }

    [Fact]
    public void Url_Works()
    {
        RbacGroupDeleteParams parameters = new() { RbacGroupID = "rbac_group_id" };

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
        var parameters = new RbacGroupDeleteParams { RbacGroupID = "rbac_group_id" };

        RbacGroupDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
