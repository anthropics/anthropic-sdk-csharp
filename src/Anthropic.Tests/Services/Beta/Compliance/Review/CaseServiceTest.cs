using System.Threading.Tasks;
using Anthropic.Models.Beta.Compliance.Review.Cases;

namespace Anthropic.Tests.Services.Beta.Compliance.Review;

public class CaseServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaComplianceReviewCase = await this
            .client.WithQuery("beta=true")
            .Beta.Compliance.Review.Cases.Retrieve(
                "case_id",
                new(),
                TestContext.Current.CancellationToken
            );
        betaComplianceReviewCase.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Compliance.Review.Cases.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Respond_Works()
    {
        var betaComplianceReviewCase = await this
            .client.WithQuery("beta=true")
            .Beta.Compliance.Review.Cases.Respond(
                "case_id",
                new() { Determination = BetaComplianceReviewDetermination.NoViolation },
                TestContext.Current.CancellationToken
            );
        betaComplianceReviewCase.Validate();
    }
}
