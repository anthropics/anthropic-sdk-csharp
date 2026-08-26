using System;
using Anthropic.Models.Beta.Organization.Workspaces.Members;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces.Members;

public class MemberRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemberRetrieveParams
        {
            WorkspaceID = "workspace_id",
            UserID = "user_id",
        };

        string expectedWorkspaceID = "workspace_id";
        string expectedUserID = "user_id";

        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        MemberRetrieveParams parameters = new()
        {
            WorkspaceID = "workspace_id",
            UserID = "user_id",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/workspaces/workspace_id/members/user_id?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MemberRetrieveParams
        {
            WorkspaceID = "workspace_id",
            UserID = "user_id",
        };

        MemberRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
