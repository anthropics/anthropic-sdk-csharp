using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Sessions;

public class ThreadServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaManagedAgentsSessionThread = await this.client.Beta.Sessions.Threads.Retrieve(
            "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            new() { SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7" },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsSessionThread.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Sessions.Threads.List(
            "sesn_011CZkZAtmR3yMPDzynEDxu7",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var betaManagedAgentsSessionThread = await this.client.Beta.Sessions.Threads.Archive(
            "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            new() { SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7" },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsSessionThread.Validate();
    }
}
