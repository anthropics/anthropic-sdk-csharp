using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Organization.Analytics;

public class SkillServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Organization.Analytics.Skills.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
