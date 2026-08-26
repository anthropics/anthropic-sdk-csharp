using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization;

public class ApiKeyServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaApiKey = await this.client.Beta.Organization.ApiKeys.Retrieve(
            "api_key_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaApiKey.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaApiKey = await this.client.Beta.Organization.ApiKeys.Update(
            "api_key_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaApiKey.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.ApiKeys.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
