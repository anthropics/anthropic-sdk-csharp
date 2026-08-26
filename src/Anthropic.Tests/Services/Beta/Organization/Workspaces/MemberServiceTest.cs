using System.Threading.Tasks;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Services.Beta.Organization.Workspaces;

public class MemberServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaWorkspaceMember = await this.client.Beta.Organization.Workspaces.Members.Retrieve(
            "user_id",
            new() { WorkspaceID = "workspace_id" },
            TestContext.Current.CancellationToken
        );
        betaWorkspaceMember.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaWorkspaceMember = await this.client.Beta.Organization.Workspaces.Members.Update(
            "user_id",
            new()
            {
                WorkspaceID = "workspace_id",
                WorkspaceRole = BetaWorkspaceRole.WorkspaceAdmin,
            },
            TestContext.Current.CancellationToken
        );
        betaWorkspaceMember.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.Workspaces.Members.List(
            "workspace_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Add_Works()
    {
        var betaWorkspaceMember = await this.client.Beta.Organization.Workspaces.Members.Add(
            "workspace_id",
            new()
            {
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                WorkspaceRole = BetaNoBillingWorkspaceRole.WorkspaceAdmin,
            },
            TestContext.Current.CancellationToken
        );
        betaWorkspaceMember.Validate();
    }

    [Fact]
    public async Task Remove_Works()
    {
        var member = await this.client.Beta.Organization.Workspaces.Members.Remove(
            "user_id",
            new() { WorkspaceID = "workspace_id" },
            TestContext.Current.CancellationToken
        );
        member.Validate();
    }
}
