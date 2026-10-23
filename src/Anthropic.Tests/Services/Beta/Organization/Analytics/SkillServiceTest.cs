using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.Analytics;

public class SkillServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.Analytics.Skills.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }
}
