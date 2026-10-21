using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.SpendLimits;

public class IncreaseRequestServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaSpendLimitIncreaseRequest =
            await this.client.Beta.Organization.SpendLimits.IncreaseRequests.Retrieve(
                "spend_limit_increase_request_id",
                new(),
                TestContext.Current.CancellationToken
            );
        betaSpendLimitIncreaseRequest.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.SpendLimits.IncreaseRequests.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Approve_Works()
    {
        var response = await this.client.Beta.Organization.SpendLimits.IncreaseRequests.Approve(
            "spend_limit_increase_request_id",
            new() { Amount = "50000" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Deny_Works()
    {
        var betaSpendLimitIncreaseRequest =
            await this.client.Beta.Organization.SpendLimits.IncreaseRequests.Deny(
                "spend_limit_increase_request_id",
                new(),
                TestContext.Current.CancellationToken
            );
        betaSpendLimitIncreaseRequest.Validate();
    }
}
