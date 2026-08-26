using System;
using Anthropic.Models.Beta.Organization.Invites;

namespace Anthropic.Tests.Models.Beta.Organization.Invites;

public class InviteDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InviteDeleteParams { InviteID = "invite_id" };

        string expectedInviteID = "invite_id";

        Assert.Equal(expectedInviteID, parameters.InviteID);
    }

    [Fact]
    public void Url_Works()
    {
        InviteDeleteParams parameters = new() { InviteID = "invite_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/invites/invite_id?beta=true"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InviteDeleteParams { InviteID = "invite_id" };

        InviteDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
