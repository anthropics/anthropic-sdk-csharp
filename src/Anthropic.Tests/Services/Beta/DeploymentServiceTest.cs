using System.Threading.Tasks;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Services.Beta;

public class DeploymentServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaManagedAgentsDeployment = await this.client.Beta.Deployments.Create(
            new()
            {
                Agent = "string",
                EnvironmentID = "x",
                InitialEvents =
                [
                    new BetaManagedAgentsUserMessageEventParams()
                    {
                        Content =
                        [
                            new BetaManagedAgentsTextBlock()
                            {
                                Text = "Where is my order #1234?",
                                Type = BetaManagedAgentsTextBlockType.Text,
                            },
                        ],
                        Type = BetaManagedAgentsUserMessageEventParamsType.UserMessage,
                    },
                ],
                Name = "x",
            },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsDeployment.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task Retrieve_Works()
    {
        var betaManagedAgentsDeployment = await this.client.Beta.Deployments.Retrieve(
            "depl_011CZkZcDH3vPqd7xnEfwTai",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsDeployment.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaManagedAgentsDeployment = await this.client.Beta.Deployments.Update(
            "depl_011CZkZcDH3vPqd7xnEfwTai",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsDeployment.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Deployments.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var betaManagedAgentsDeployment = await this.client.Beta.Deployments.Archive(
            "depl_011CZkZcDH3vPqd7xnEfwTai",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsDeployment.Validate();
    }

    [Fact]
    public async Task Pause_Works()
    {
        var betaManagedAgentsDeployment = await this.client.Beta.Deployments.Pause(
            "depl_011CZkZcDH3vPqd7xnEfwTai",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsDeployment.Validate();
    }

    [Fact]
    public async Task Run_Works()
    {
        var betaManagedAgentsDeploymentRun = await this.client.Beta.Deployments.Run(
            "depl_011CZkZcDH3vPqd7xnEfwTai",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsDeploymentRun.Validate();
    }

    [Fact]
    public async Task Unpause_Works()
    {
        var betaManagedAgentsDeployment = await this.client.Beta.Deployments.Unpause(
            "depl_011CZkZcDH3vPqd7xnEfwTai",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsDeployment.Validate();
    }
}
