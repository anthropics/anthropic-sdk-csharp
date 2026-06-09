using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta;

public class DeploymentRunServiceTest : TestBase
{
    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task Retrieve_Works()
    {
        var betaManagedAgentsDeploymentRun = await this.client.Beta.DeploymentRuns.Retrieve(
            "deployment_run_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsDeploymentRun.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.DeploymentRuns.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
