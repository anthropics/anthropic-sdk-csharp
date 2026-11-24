using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Compliance.Review;

public class NoticeServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Compliance.Review.Notices.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }
}
