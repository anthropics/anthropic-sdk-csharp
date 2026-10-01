using System.Threading.Tasks;

namespace Anthropic.Tests.Services;

public class OrganizationServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var organizationInfo = await this.client.Organization.Retrieve(
            new(),
            TestContext.Current.CancellationToken
        );
        organizationInfo.Validate();
    }
}
