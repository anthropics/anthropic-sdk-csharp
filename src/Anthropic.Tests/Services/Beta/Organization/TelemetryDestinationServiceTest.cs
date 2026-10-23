using System.Threading.Tasks;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Services.Beta.Organization;

public class TelemetryDestinationServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaTelemetryDestination = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.TelemetryDestinations.Create(
                new()
                {
                    EndpointUrl = "x",
                    Workspaces = new BetaTelemetryDestinationWorkspacesAllParams(),
                },
                TestContext.Current.CancellationToken
            );
        betaTelemetryDestination.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaTelemetryDestination = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.TelemetryDestinations.Retrieve(
                "destination_id",
                new(),
                TestContext.Current.CancellationToken
            );
        betaTelemetryDestination.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaTelemetryDestination = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.TelemetryDestinations.Update(
                "destination_id",
                new(),
                TestContext.Current.CancellationToken
            );
        betaTelemetryDestination.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.TelemetryDestinations.List(
                new(),
                TestContext.Current.CancellationToken
            );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var betaDeletedTelemetryDestination = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.TelemetryDestinations.Delete(
                "destination_id",
                new(),
                TestContext.Current.CancellationToken
            );
        betaDeletedTelemetryDestination.Validate();
    }

    [Fact]
    public async Task Test_Works()
    {
        var betaTelemetryDestinationTestResponse = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.TelemetryDestinations.Test(
                "destination_id",
                new(),
                TestContext.Current.CancellationToken
            );
        betaTelemetryDestinationTestResponse.Validate();
    }
}
