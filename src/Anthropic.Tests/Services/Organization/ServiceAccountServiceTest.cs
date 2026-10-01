using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Organization;

public class ServiceAccountServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var serviceAccount = await this.client.Organization.ServiceAccounts.Create(
            new() { Name = "ci-deploy-bot" },
            TestContext.Current.CancellationToken
        );
        serviceAccount.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var serviceAccount = await this.client.Organization.ServiceAccounts.Retrieve(
            "service_account_id",
            new(),
            TestContext.Current.CancellationToken
        );
        serviceAccount.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var serviceAccount = await this.client.Organization.ServiceAccounts.Update(
            "service_account_id",
            new(),
            TestContext.Current.CancellationToken
        );
        serviceAccount.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Organization.ServiceAccounts.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var serviceAccount = await this.client.Organization.ServiceAccounts.Archive(
            "service_account_id",
            new(),
            TestContext.Current.CancellationToken
        );
        serviceAccount.Validate();
    }
}
