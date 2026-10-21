using System;
using Anthropic.Models.Organization.ServiceAccounts.Workspaces;

namespace Anthropic.Tests.Models.Organization.ServiceAccounts.Workspaces;

public class WorkspaceRemoveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkspaceRemoveParams
        {
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
        };

        string expectedServiceAccountID = "service_account_id";
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedServiceAccountID, parameters.ServiceAccountID);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
    }

    [Fact]
    public void Url_Works()
    {
        WorkspaceRemoveParams parameters = new()
        {
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/service_accounts/service_account_id/workspaces/workspace_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkspaceRemoveParams
        {
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
        };

        WorkspaceRemoveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
