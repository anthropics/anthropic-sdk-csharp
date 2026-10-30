using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Organization.Analytics;

public class UserServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Organization.Analytics.Users.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
