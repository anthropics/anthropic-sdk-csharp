using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Organization;

public class RbacRoleServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var rbacRole = await this.client.Organization.RbacRoles.Retrieve(
            "rbac_role_id",
            new(),
            TestContext.Current.CancellationToken
        );
        rbacRole.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Organization.RbacRoles.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
