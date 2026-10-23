using System;
using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.Analytics;

public class CostServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.Analytics.Cost.List(
                new() { StartingAt = DateTimeOffset.Parse("2026-09-01T00:00:00Z") },
                TestContext.Current.CancellationToken
            );
        page.Validate();
    }
}
