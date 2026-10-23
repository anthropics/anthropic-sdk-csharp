using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.TelemetryDestinations;

public class WorkspaceServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.TelemetryDestinations.Workspaces.List(
                "destination_id",
                new(),
                TestContext.Current.CancellationToken
            );
        page.Validate();
    }

    [Fact]
    public async Task Add_Works()
    {
        var betaTelemetryDestinationWorkspace = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.TelemetryDestinations.Workspaces.Add(
                "workspace_id",
                new() { DestinationID = "destination_id" },
                TestContext.Current.CancellationToken
            );
        betaTelemetryDestinationWorkspace.Validate();
    }

    [Fact]
    public async Task Remove_Works()
    {
        var betaDeletedTelemetryDestinationWorkspace = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.TelemetryDestinations.Workspaces.Remove(
                "workspace_id",
                new() { DestinationID = "destination_id" },
                TestContext.Current.CancellationToken
            );
        betaDeletedTelemetryDestinationWorkspace.Validate();
    }
}
