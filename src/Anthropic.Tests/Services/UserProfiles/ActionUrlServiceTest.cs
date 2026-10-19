using System.Threading.Tasks;

namespace Anthropic.Tests.Services.UserProfiles;

public class ActionUrlServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var userProfileActionUrl = await this.client.UserProfiles.ActionUrls.Create(
            "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            new() { Action = new() },
            TestContext.Current.CancellationToken
        );
        userProfileActionUrl.Validate();
    }
}
