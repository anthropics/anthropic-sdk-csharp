using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Environments;

public class WorkServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaSelfHostedWork = await this.client.Beta.Environments.Work.Retrieve(
            "work_id",
            new() { EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW" },
            TestContext.Current.CancellationToken
        );
        betaSelfHostedWork.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaSelfHostedWork = await this.client.Beta.Environments.Work.Update(
            "work_id",
            new()
            {
                EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            },
            TestContext.Current.CancellationToken
        );
        betaSelfHostedWork.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Environments.Work.List(
            "env_011CZkZ9X2dpNyB7HsEFoRfW",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Ack_Works()
    {
        var betaSelfHostedWork = await this.client.Beta.Environments.Work.Ack(
            "work_id",
            new() { EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW" },
            TestContext.Current.CancellationToken
        );
        betaSelfHostedWork.Validate();
    }

    [Fact]
    public async Task Heartbeat_Works()
    {
        var betaSelfHostedWorkHeartbeatResponse =
            await this.client.Beta.Environments.Work.Heartbeat(
                "work_id",
                new() { EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW" },
                TestContext.Current.CancellationToken
            );
        betaSelfHostedWorkHeartbeatResponse.Validate();
    }

    [Fact]
    public async Task Poll_Works()
    {
        var betaSelfHostedWork = await this.client.Beta.Environments.Work.Poll(
            "env_011CZkZ9X2dpNyB7HsEFoRfW",
            new(),
            TestContext.Current.CancellationToken
        );
        betaSelfHostedWork?.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task Stats_Works()
    {
        var betaSelfHostedWorkQueueStats = await this.client.Beta.Environments.Work.Stats(
            "env_011CZkZ9X2dpNyB7HsEFoRfW",
            new(),
            TestContext.Current.CancellationToken
        );
        betaSelfHostedWorkQueueStats.Validate();
    }

    [Fact]
    public async Task Stop_Works()
    {
        var betaSelfHostedWork = await this.client.Beta.Environments.Work.Stop(
            "work_id",
            new() { EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW" },
            TestContext.Current.CancellationToken
        );
        betaSelfHostedWork.Validate();
    }
}
