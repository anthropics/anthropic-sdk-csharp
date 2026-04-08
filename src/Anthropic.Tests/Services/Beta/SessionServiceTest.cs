using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta;

public class SessionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaManagedAgentsSession = await this.client.Beta.Sessions.Create(
            new()
            {
                Agent = "agent_011CZkYpogX7uDKUyvBTophP",
                EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsSession.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaManagedAgentsSession = await this.client.Beta.Sessions.Retrieve(
            "sesn_011CZkZAtmR3yMPDzynEDxu7",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsSession.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaManagedAgentsSession = await this.client.Beta.Sessions.Update(
            "sesn_011CZkZAtmR3yMPDzynEDxu7",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsSession.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Sessions.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var betaManagedAgentsDeletedSession = await this.client.Beta.Sessions.Delete(
            "sesn_011CZkZAtmR3yMPDzynEDxu7",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsDeletedSession.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var betaManagedAgentsSession = await this.client.Beta.Sessions.Archive(
            "sesn_011CZkZAtmR3yMPDzynEDxu7",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsSession.Validate();
    }
}
