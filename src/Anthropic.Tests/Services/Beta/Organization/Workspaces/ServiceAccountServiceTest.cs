using System.Threading.Tasks;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Services.Beta.Organization.Workspaces;

public class ServiceAccountServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaServiceAccountWorkspaceMember =
            await this.client.Beta.Organization.Workspaces.ServiceAccounts.Retrieve(
                "service_account_id",
                new() { WorkspaceID = "workspace_id" },
                TestContext.Current.CancellationToken
            );
        betaServiceAccountWorkspaceMember.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaServiceAccountWorkspaceMember =
            await this.client.Beta.Organization.Workspaces.ServiceAccounts.Update(
                "service_account_id",
                new()
                {
                    WorkspaceID = "workspace_id",
                    WorkspaceRole = BetaNoBillingWorkspaceRole.WorkspaceAdmin,
                },
                TestContext.Current.CancellationToken
            );
        betaServiceAccountWorkspaceMember.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.Workspaces.ServiceAccounts.List(
            "workspace_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Add_Works()
    {
        var betaServiceAccountWorkspaceMember =
            await this.client.Beta.Organization.Workspaces.ServiceAccounts.Add(
                "workspace_id",
                new()
                {
                    ServiceAccountID = "service_account_id",
                    WorkspaceRole = BetaNoBillingWorkspaceRole.WorkspaceAdmin,
                },
                TestContext.Current.CancellationToken
            );
        betaServiceAccountWorkspaceMember.Validate();
    }

    [Fact]
    public async Task Remove_Works()
    {
        var serviceAccount = await this.client.Beta.Organization.Workspaces.ServiceAccounts.Remove(
            "service_account_id",
            new() { WorkspaceID = "workspace_id" },
            TestContext.Current.CancellationToken
        );
        serviceAccount.Validate();
    }
}
