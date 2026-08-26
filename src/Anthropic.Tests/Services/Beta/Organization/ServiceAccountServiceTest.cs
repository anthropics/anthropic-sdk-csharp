using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization;

public class ServiceAccountServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaServiceAccount = await this.client.Beta.Organization.ServiceAccounts.Create(
            new() { Name = "ci-deploy-bot" },
            TestContext.Current.CancellationToken
        );
        betaServiceAccount.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaServiceAccount = await this.client.Beta.Organization.ServiceAccounts.Retrieve(
            "service_account_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaServiceAccount.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaServiceAccount = await this.client.Beta.Organization.ServiceAccounts.Update(
            "service_account_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaServiceAccount.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.ServiceAccounts.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var betaServiceAccount = await this.client.Beta.Organization.ServiceAccounts.Archive(
            "service_account_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaServiceAccount.Validate();
    }
}
