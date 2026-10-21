using System.Threading.Tasks;
using Anthropic.Models.Organization.Workspaces;

namespace Anthropic.Tests.Services.Organization.ServiceAccounts;

public class WorkspaceServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Organization.ServiceAccounts.Workspaces.List(
            "service_account_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Add_Works()
    {
        var serviceAccountWorkspaceMember =
            await this.client.Organization.ServiceAccounts.Workspaces.Add(
                "service_account_id",
                new()
                {
                    WorkspaceID = "workspace_id",
                    WorkspaceRole = NoBillingWorkspaceRole.WorkspaceAdmin,
                },
                TestContext.Current.CancellationToken
            );
        serviceAccountWorkspaceMember.Validate();
    }

    [Fact]
    public async Task Remove_Works()
    {
        var workspace = await this.client.Organization.ServiceAccounts.Workspaces.Remove(
            "workspace_id",
            new() { ServiceAccountID = "service_account_id" },
            TestContext.Current.CancellationToken
        );
        workspace.Validate();
    }
}
