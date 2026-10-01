using System;
using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.Analytics;

public class CostReportServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.Analytics.CostReport.List(
            new() { StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
