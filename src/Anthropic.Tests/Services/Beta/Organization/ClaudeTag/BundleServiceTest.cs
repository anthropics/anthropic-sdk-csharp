using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.ClaudeTag;

public class BundleServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaClaudeTagBundle = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeTag.Bundles.Retrieve(
                "capp_011CZkZjLP1cWxj5EtMmdgbq",
                new(),
                TestContext.Current.CancellationToken
            );
        betaClaudeTagBundle.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeTag.Bundles.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }
}
