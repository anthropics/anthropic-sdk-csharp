using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.SpendLimits;

public class EffectiveServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.SpendLimits.Effective.List(
                new(),
                TestContext.Current.CancellationToken
            );
        page.Validate();
    }
}
