using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.Federation.Rules;

public class WorkspaceServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.Federation.Rules.Workspaces.List(
            "federation_rule_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Add_Works()
    {
        var betaFederationRuleWorkspace =
            await this.client.Beta.Organization.Federation.Rules.Workspaces.Add(
                "federation_rule_id",
                new() { WorkspaceID = "workspace_id" },
                TestContext.Current.CancellationToken
            );
        betaFederationRuleWorkspace.Validate();
    }

    [Fact]
    public async Task Remove_Works()
    {
        var workspace = await this.client.Beta.Organization.Federation.Rules.Workspaces.Remove(
            "workspace_id",
            new() { FederationRuleID = "federation_rule_id" },
            TestContext.Current.CancellationToken
        );
        workspace.Validate();
    }
}
