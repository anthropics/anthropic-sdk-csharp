using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta;

public class EnvironmentServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaEnvironment = await this.client.Beta.Environments.Create(
            new() { Name = "python-data-analysis" },
            TestContext.Current.CancellationToken
        );
        betaEnvironment.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaEnvironment = await this.client.Beta.Environments.Retrieve(
            "env_011CZkZ9X2dpNyB7HsEFoRfW",
            new(),
            TestContext.Current.CancellationToken
        );
        betaEnvironment.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaEnvironment = await this.client.Beta.Environments.Update(
            "env_011CZkZ9X2dpNyB7HsEFoRfW",
            new(),
            TestContext.Current.CancellationToken
        );
        betaEnvironment.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Environments.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var betaEnvironmentDeleteResponse = await this.client.Beta.Environments.Delete(
            "env_011CZkZ9X2dpNyB7HsEFoRfW",
            new(),
            TestContext.Current.CancellationToken
        );
        betaEnvironmentDeleteResponse.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var betaEnvironment = await this.client.Beta.Environments.Archive(
            "env_011CZkZ9X2dpNyB7HsEFoRfW",
            new(),
            TestContext.Current.CancellationToken
        );
        betaEnvironment.Validate();
    }
}
