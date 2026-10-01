using System;
using Anthropic.Core;
using Anthropic.Models.Organization.Workspaces;
using Anthropic.Models.Organization.Workspaces.Members;

namespace Anthropic.Tests.Models.Organization.Workspaces.Members;

public class MemberUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemberUpdateParams
        {
            WorkspaceID = "workspace_id",
            UserID = "user_id",
            WorkspaceRole = WorkspaceRole.WorkspaceAdmin,
        };

        string expectedWorkspaceID = "workspace_id";
        string expectedUserID = "user_id";
        ApiEnum<string, WorkspaceRole> expectedWorkspaceRole = WorkspaceRole.WorkspaceAdmin;

        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedWorkspaceRole, parameters.WorkspaceRole);
    }

    [Fact]
    public void Url_Works()
    {
        MemberUpdateParams parameters = new()
        {
            WorkspaceID = "workspace_id",
            UserID = "user_id",
            WorkspaceRole = WorkspaceRole.WorkspaceAdmin,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/workspaces/workspace_id/members/user_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MemberUpdateParams
        {
            WorkspaceID = "workspace_id",
            UserID = "user_id",
            WorkspaceRole = WorkspaceRole.WorkspaceAdmin,
        };

        MemberUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
