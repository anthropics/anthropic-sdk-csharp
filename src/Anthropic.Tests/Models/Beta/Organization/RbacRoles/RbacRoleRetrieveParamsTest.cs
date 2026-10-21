using System;
using Anthropic.Models.Beta.Organization.RbacRoles;

namespace Anthropic.Tests.Models.Beta.Organization.RbacRoles;

public class RbacRoleRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RbacRoleRetrieveParams { RbacRoleID = "rbac_role_id" };

        string expectedRbacRoleID = "rbac_role_id";

        Assert.Equal(expectedRbacRoleID, parameters.RbacRoleID);
    }

    [Fact]
    public void Url_Works()
    {
        RbacRoleRetrieveParams parameters = new() { RbacRoleID = "rbac_role_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/rbac_roles/rbac_role_id?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RbacRoleRetrieveParams { RbacRoleID = "rbac_role_id" };

        RbacRoleRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
