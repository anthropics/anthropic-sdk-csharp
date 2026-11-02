using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Organization.RbacGroups;

public class MemberServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Organization.RbacGroups.Members.List(
            "rbac_group_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Add_Works()
    {
        var rbacGroupMember = await this.client.Organization.RbacGroups.Members.Add(
            "rbac_group_id",
            new() { UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu" },
            TestContext.Current.CancellationToken
        );
        rbacGroupMember.Validate();
    }

    [Fact]
    public async Task Remove_Works()
    {
        var deletedRbacGroupMember = await this.client.Organization.RbacGroups.Members.Remove(
            "user_id",
            new() { RbacGroupID = "rbac_group_id" },
            TestContext.Current.CancellationToken
        );
        deletedRbacGroupMember.Validate();
    }
}
