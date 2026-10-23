using System.Threading.Tasks;
using Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

namespace Anthropic.Tests.Services.Beta.Organization.ClaudeTag.Bundles;

public class TargetServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaClaudeTagBundleTarget = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeTag.Bundles.Targets.Create(
                "capp_011CZkZjLP1cWxj5EtMmdgbq",
                new() { Target = new BetaClaudeTagSlackChannelBundleTargetCreate("xxxxxxxx") },
                TestContext.Current.CancellationToken
            );
        betaClaudeTagBundleTarget.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaClaudeTagBundleTarget = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeTag.Bundles.Targets.Retrieve(
                "btgt_01SvpyRQK3nN6eH9uhRA7n1qHq8TzW5mKc2YbX7vNd4RfJ",
                new() { BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq" },
                TestContext.Current.CancellationToken
            );
        betaClaudeTagBundleTarget.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeTag.Bundles.Targets.List(
                "capp_011CZkZjLP1cWxj5EtMmdgbq",
                new(),
                TestContext.Current.CancellationToken
            );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var betaClaudeTagDeletedBundleTarget = await this
            .client.WithQuery("beta=true")
            .Beta.Organization.ClaudeTag.Bundles.Targets.Delete(
                "btgt_01SvpyRQK3nN6eH9uhRA7n1qHq8TzW5mKc2YbX7vNd4RfJ",
                new() { BundleID = "capp_011CZkZjLP1cWxj5EtMmdgbq" },
                TestContext.Current.CancellationToken
            );
        betaClaudeTagDeletedBundleTarget.Validate();
    }
}
