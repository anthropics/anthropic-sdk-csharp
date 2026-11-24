using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.Providers.Google.Projects;

public class DataControlServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaGoogleManagedProjectDataControls = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.Providers.Google.Projects.DataControls.Retrieve(
                "123456789012",
                new(),
                TestContext.Current.CancellationToken
            );
        betaGoogleManagedProjectDataControls.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaGoogleManagedProjectDataControls = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.Providers.Google.Projects.DataControls.Update(
                "123456789012",
                new(),
                TestContext.Current.CancellationToken
            );
        betaGoogleManagedProjectDataControls.Validate();
    }
}
