using System;
using Anthropic.Models.Organization.Workspaces.ServiceAccounts;

namespace Anthropic.Tests.Models.Organization.Workspaces.ServiceAccounts;

public class ServiceAccountRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ServiceAccountRetrieveParams
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",
        };

        string expectedWorkspaceID = "workspace_id";
        string expectedServiceAccountID = "service_account_id";

        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
        Assert.Equal(expectedServiceAccountID, parameters.ServiceAccountID);
    }

    [Fact]
    public void Url_Works()
    {
        ServiceAccountRetrieveParams parameters = new()
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",
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
        var parameters = new ServiceAccountRetrieveParams
        {
            WorkspaceID = "workspace_id",
            ServiceAccountID = "service_account_id",
        };

        ServiceAccountRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
