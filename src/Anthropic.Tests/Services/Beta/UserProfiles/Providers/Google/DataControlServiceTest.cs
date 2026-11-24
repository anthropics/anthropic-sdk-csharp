using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.UserProfiles.Providers.Google;

public class DataControlServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaGoogleManagedDataControls = await this
            .client.WithQuery("beta=true")
            .Beta.UserProfiles.Providers.Google.DataControls.Retrieve(
                "uprof_011CZkZCu8hGbp5mYRQgUmz9",
                new(),
                TestContext.Current.CancellationToken
            );
        betaGoogleManagedDataControls.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaGoogleManagedDataControls = await this
            .client.WithQuery("beta=true")
            .Beta.UserProfiles.Providers.Google.DataControls.Update(
                "uprof_011CZkZCu8hGbp5mYRQgUmz9",
                new(),
                TestContext.Current.CancellationToken
            );
        betaGoogleManagedDataControls.Validate();
    }
}
