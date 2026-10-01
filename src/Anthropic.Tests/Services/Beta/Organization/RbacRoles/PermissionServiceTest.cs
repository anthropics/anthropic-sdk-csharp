using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.RbacRoles;

public class PermissionServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.RbacRoles.Permissions.List(
            "rbac_role_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
