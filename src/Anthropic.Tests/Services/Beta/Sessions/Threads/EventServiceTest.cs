using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Sessions.Threads;

public class EventServiceTest : TestBase
{
    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Sessions.Threads.Events.List(
            "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            new() { SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task StreamStreaming_Works()
    {
        var stream = this.client.Beta.Sessions.Threads.Events.StreamStreaming(
            "sthr_011CZkZVWa6oIjw0rgXZpnBt",
            new() { SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7" },
            TestContext.Current.CancellationToken
        );

        await foreach (var betaManagedAgentsStreamSessionThreadEvents in stream)
        {
            betaManagedAgentsStreamSessionThreadEvents.Validate();
        }
    }
}
