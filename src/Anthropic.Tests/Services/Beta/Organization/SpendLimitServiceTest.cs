using System.Threading.Tasks;
using Anthropic.Models.Beta.Organization.SpendLimits;

namespace Anthropic.Tests.Services.Beta.Organization;

public class SpendLimitServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaSpendLimit = await this.client.Beta.Organization.SpendLimits.Retrieve(
            "spend_limit_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaSpendLimit.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.SpendLimits.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var spendLimit = await this.client.Beta.Organization.SpendLimits.Delete(
            "spend_limit_id",
            new(),
            TestContext.Current.CancellationToken
        );
        spendLimit.Validate();
    }

    [Fact]
    public async Task Set_Works()
    {
        var betaSpendLimit = await this.client.Beta.Organization.SpendLimits.Set(
            new()
            {
                Amount = "50000",
                Scope = new BetaSpendLimitUserScope("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            },
            TestContext.Current.CancellationToken
        );
        betaSpendLimit.Validate();
    }
}
