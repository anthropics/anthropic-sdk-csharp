using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Organization;

public class WorkspaceServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var workspace = await this.client.Organization.Workspaces.Create(
            new() { Name = "x" },
            TestContext.Current.CancellationToken
        );
        workspace.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var workspace = await this.client.Organization.Workspaces.Retrieve(
            "workspace_id",
            new(),
            TestContext.Current.CancellationToken
        );
        workspace.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var workspace = await this.client.Organization.Workspaces.Update(
            "workspace_id",
            new(),
            TestContext.Current.CancellationToken
        );
        workspace.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Organization.Workspaces.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var workspace = await this.client.Organization.Workspaces.Archive(
            "workspace_id",
            new(),
            TestContext.Current.CancellationToken
        );
        workspace.Validate();
    }
}
