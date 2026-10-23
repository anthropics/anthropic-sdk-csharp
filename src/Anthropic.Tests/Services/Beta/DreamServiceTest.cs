using System.Threading.Tasks;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Services.Beta;

public class DreamServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaDream = await this
            .client.WithQuery("beta=true")
            .Beta.Dreams.Create(
                new() { Inputs = [new BetaDreamMemoryStoreInput("x")], Model = "string" },
                TestContext.Current.CancellationToken
            );
        betaDream.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaDream = await this
            .client.WithQuery("beta=true")
            .Beta.Dreams.Retrieve("dream_id", new(), TestContext.Current.CancellationToken);
        betaDream.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Dreams.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var betaDream = await this
            .client.WithQuery("beta=true")
            .Beta.Dreams.Archive("dream_id", new(), TestContext.Current.CancellationToken);
        betaDream.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var betaDream = await this
            .client.WithQuery("beta=true")
            .Beta.Dreams.Cancel("dream_id", new(), TestContext.Current.CancellationToken);
        betaDream.Validate();
    }
}
