using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Compliance.Review;

public class ItemServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaComplianceReviewItem = await this
            .client.WithQuery("beta=true")
            .Beta.Compliance.Review.Items.Retrieve(
                "item_id",
                new(),
                TestContext.Current.CancellationToken
            );
        betaComplianceReviewItem.Validate();
    }
}
