using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization;

public class RbacRoleServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaRbacRole = await this.client.Beta.Organization.RbacRoles.Retrieve(
            "rbac_role_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaRbacRole.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.RbacRoles.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
