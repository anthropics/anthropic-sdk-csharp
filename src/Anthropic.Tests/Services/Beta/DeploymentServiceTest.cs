using System.Threading.Tasks;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Services.Beta;

public class DeploymentServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaManagedAgentsDeployment = await this
            .client.WithQuery("beta=true")
            .Beta.Deployments.Create(
                new()
                {
                    Agent = "string",
                    EnvironmentID = "x",
                    InitialEvents =
                    [
                        new BetaManagedAgentsUserMessageEventParams(
                            [new BetaManagedAgentsTextBlock("Where is my order #1234?")]
                        ),
                    ],
                    Name = "x",
                },
                TestContext.Current.CancellationToken
            );
        betaManagedAgentsDeployment.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaManagedAgentsDeployment = await this
            .client.WithQuery("beta=true")
            .Beta.Deployments.Retrieve(
                "depl_011CZkZcDH3vPqd7xnEfwTai",
                new(),
                TestContext.Current.CancellationToken
            );
        betaManagedAgentsDeployment.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaManagedAgentsDeployment = await this
            .client.WithQuery("beta=true")
            .Beta.Deployments.Update(
                "depl_011CZkZcDH3vPqd7xnEfwTai",
                new(),
                TestContext.Current.CancellationToken
            );
        betaManagedAgentsDeployment.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Deployments.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var betaManagedAgentsDeployment = await this
            .client.WithQuery("beta=true")
            .Beta.Deployments.Archive(
                "depl_011CZkZcDH3vPqd7xnEfwTai",
                new(),
                TestContext.Current.CancellationToken
            );
        betaManagedAgentsDeployment.Validate();
    }

    [Fact]
    public async Task Pause_Works()
    {
        var betaManagedAgentsDeployment = await this
            .client.WithQuery("beta=true")
            .Beta.Deployments.Pause(
                "depl_011CZkZcDH3vPqd7xnEfwTai",
                new(),
                TestContext.Current.CancellationToken
            );
        betaManagedAgentsDeployment.Validate();
    }

    [Fact]
    public async Task Run_Works()
    {
        var betaManagedAgentsDeploymentRun = await this
            .client.WithQuery("beta=true")
            .Beta.Deployments.Run(
                "depl_011CZkZcDH3vPqd7xnEfwTai",
                new(),
                TestContext.Current.CancellationToken
            );
        betaManagedAgentsDeploymentRun.Validate();
    }

    [Fact]
    public async Task Unpause_Works()
    {
        var betaManagedAgentsDeployment = await this
            .client.WithQuery("beta=true")
            .Beta.Deployments.Unpause(
                "depl_011CZkZcDH3vPqd7xnEfwTai",
                new(),
                TestContext.Current.CancellationToken
            );
        betaManagedAgentsDeployment.Validate();
    }
}
