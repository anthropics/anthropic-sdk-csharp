using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.UserProfiles;

public class ActionUrlServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaUserProfileActionUrl = await this
            .client.WithQuery("beta=true")
            .Beta.UserProfiles.ActionUrls.Create(
                "uprof_011CZkZCu8hGbp5mYRQgUmz9",
                new() { Action = new() },
                TestContext.Current.CancellationToken
            );
        betaUserProfileActionUrl.Validate();
    }
}
