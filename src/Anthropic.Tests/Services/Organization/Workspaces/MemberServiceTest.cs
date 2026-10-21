using System.Threading.Tasks;
using Anthropic.Models.Organization.Workspaces;

namespace Anthropic.Tests.Services.Organization.Workspaces;

public class MemberServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var workspaceMember = await this.client.Organization.Workspaces.Members.Retrieve(
            "user_id",
            new() { WorkspaceID = "workspace_id" },
            TestContext.Current.CancellationToken
        );
        workspaceMember.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var workspaceMember = await this.client.Organization.Workspaces.Members.Update(
            "user_id",
            new() { WorkspaceID = "workspace_id", WorkspaceRole = WorkspaceRole.WorkspaceAdmin },
            TestContext.Current.CancellationToken
        );
        workspaceMember.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Organization.Workspaces.Members.List(
            "workspace_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Add_Works()
    {
        var workspaceMember = await this.client.Organization.Workspaces.Members.Add(
            "workspace_id",
            new()
            {
                UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                WorkspaceRole = NoBillingWorkspaceRole.WorkspaceAdmin,
            },
            TestContext.Current.CancellationToken
        );
        workspaceMember.Validate();
    }

    [Fact]
    public async Task Remove_Works()
    {
        var member = await this.client.Organization.Workspaces.Members.Remove(
            "user_id",
            new() { WorkspaceID = "workspace_id" },
            TestContext.Current.CancellationToken
        );
        member.Validate();
    }
}
