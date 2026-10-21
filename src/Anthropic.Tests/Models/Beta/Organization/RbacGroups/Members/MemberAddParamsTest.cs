using System;
using Anthropic.Models.Beta.Organization.RbacGroups.Members;

namespace Anthropic.Tests.Models.Beta.Organization.RbacGroups.Members;

public class MemberAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemberAddParams
        {
            RbacGroupID = "rbac_group_id",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };

        string expectedRbacGroupID = "rbac_group_id";
        string expectedUserID = "user_01WCz1FkmYMm4gnmykNKUu3Q";

        Assert.Equal(expectedRbacGroupID, parameters.RbacGroupID);
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        MemberAddParams parameters = new()
        {
            RbacGroupID = "rbac_group_id",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/rbac_groups/rbac_group_id/members?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MemberAddParams
        {
            RbacGroupID = "rbac_group_id",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };

        MemberAddParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
