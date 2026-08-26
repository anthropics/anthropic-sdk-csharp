using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization;

public class WorkspaceServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaWorkspace = await this.client.Beta.Organization.Workspaces.Create(
            new() { Name = "x" },
            TestContext.Current.CancellationToken
        );
        betaWorkspace.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaWorkspace = await this.client.Beta.Organization.Workspaces.Retrieve(
            "workspace_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaWorkspace.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaWorkspace = await this.client.Beta.Organization.Workspaces.Update(
            "workspace_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaWorkspace.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.Workspaces.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var betaWorkspace = await this.client.Beta.Organization.Workspaces.Archive(
            "workspace_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaWorkspace.Validate();
    }
}
