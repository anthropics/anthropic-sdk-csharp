using System;
using Anthropic.Core;
using Anthropic.Models.Organization.Workspaces;
using Anthropic.Models.Organization.Workspaces.Members;

namespace Anthropic.Tests.Models.Organization.Workspaces.Members;

public class MemberAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemberAddParams
        {
            WorkspaceID = "workspace_id",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            WorkspaceRole = NoBillingWorkspaceRole.WorkspaceAdmin,
        };

        string expectedWorkspaceID = "workspace_id";
        string expectedUserID = "user_01WCz1FkmYMm4gnmykNKUu3Q";
        ApiEnum<string, NoBillingWorkspaceRole> expectedWorkspaceRole =
            NoBillingWorkspaceRole.WorkspaceAdmin;

        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedWorkspaceRole, parameters.WorkspaceRole);
    }

    [Fact]
    public void Url_Works()
    {
        MemberAddParams parameters = new()
        {
            WorkspaceID = "workspace_id",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            WorkspaceRole = NoBillingWorkspaceRole.WorkspaceAdmin,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/workspaces/workspace_id/members"
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
            WorkspaceID = "workspace_id",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            WorkspaceRole = NoBillingWorkspaceRole.WorkspaceAdmin,
        };

        MemberAddParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
