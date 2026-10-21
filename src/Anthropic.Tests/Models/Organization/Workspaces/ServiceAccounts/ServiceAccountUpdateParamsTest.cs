using System;
using Anthropic.Core;
using Anthropic.Models.Organization.Workspaces;
using Anthropic.Models.Organization.Workspaces.ServiceAccounts;

namespace Anthropic.Tests.Models.Organization.Workspaces.ServiceAccounts;

public class ServiceAccountUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ServiceAccountUpdateParams
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",
            WorkspaceRole = NoBillingWorkspaceRole.WorkspaceAdmin,
        };

        string expectedWorkspaceID = "workspace_id";
        string expectedServiceAccountID = "service_account_id";
        ApiEnum<string, NoBillingWorkspaceRole> expectedWorkspaceRole =
            NoBillingWorkspaceRole.WorkspaceAdmin;

        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
        Assert.Equal(expectedServiceAccountID, parameters.ServiceAccountID);
        Assert.Equal(expectedWorkspaceRole, parameters.WorkspaceRole);
    }

    [Fact]
    public void Url_Works()
    {
        ServiceAccountUpdateParams parameters = new()
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",
            WorkspaceRole = NoBillingWorkspaceRole.WorkspaceAdmin,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/workspaces/workspace_id/service_accounts/service_account_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ServiceAccountUpdateParams
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",
            WorkspaceRole = NoBillingWorkspaceRole.WorkspaceAdmin,
        };

        ServiceAccountUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
