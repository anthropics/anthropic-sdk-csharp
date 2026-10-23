using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.Analytics.Apps.Chat;

public class ProjectServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.Analytics.Apps.Chat.Projects.List(
                new(),
                TestContext.Current.CancellationToken
            );
        page.Validate();
    }
}
