using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta;

public class OrganizationServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaOrganization = await this.client.Beta.Organization.Retrieve(
            new(),
            TestContext.Current.CancellationToken
        );
        betaOrganization.Validate();
    }
}
