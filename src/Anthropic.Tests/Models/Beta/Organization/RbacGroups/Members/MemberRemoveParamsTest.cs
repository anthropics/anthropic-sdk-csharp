using System;
using Anthropic.Models.Beta.Organization.RbacGroups.Members;

namespace Anthropic.Tests.Models.Beta.Organization.RbacGroups.Members;

public class MemberRemoveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemberRemoveParams
        {
            RbacGroupID = "rbac_group_id",
            UserID = "user_id",
        };

        string expectedRbacGroupID = "rbac_group_id";
        string expectedUserID = "user_id";

        Assert.Equal(expectedRbacGroupID, parameters.RbacGroupID);
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        MemberRemoveParams parameters = new() { RbacGroupID = "rbac_group_id", UserID = "user_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/rbac_groups/rbac_group_id/members/user_id?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MemberRemoveParams
        {
            RbacGroupID = "rbac_group_id",
            UserID = "user_id",
        };

        MemberRemoveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
