using System;
using Anthropic.Core;
using Anthropic.Models.Organization.ServiceAccounts.Workspaces;
using Anthropic.Models.Organization.Workspaces;

namespace Anthropic.Tests.Models.Organization.ServiceAccounts.Workspaces;

public class WorkspaceAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkspaceAddParams
        {
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
            WorkspaceRole = NoBillingWorkspaceRole.WorkspaceAdmin,
        };

        string expectedServiceAccountID = "service_account_id";
        string expectedWorkspaceID = "workspace_id";
        ApiEnum<string, NoBillingWorkspaceRole> expectedWorkspaceRole =
            NoBillingWorkspaceRole.WorkspaceAdmin;

        Assert.Equal(expectedServiceAccountID, parameters.ServiceAccountID);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
        Assert.Equal(expectedWorkspaceRole, parameters.WorkspaceRole);
    }

    [Fact]
    public void Url_Works()
    {
        WorkspaceAddParams parameters = new()
        {
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
            WorkspaceRole = NoBillingWorkspaceRole.WorkspaceAdmin,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/service_accounts/service_account_id/workspaces"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkspaceAddParams
        {
            ServiceAccountID = "service_account_id",
            WorkspaceID = "workspace_id",
            WorkspaceRole = NoBillingWorkspaceRole.WorkspaceAdmin,
        };

        WorkspaceAddParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
