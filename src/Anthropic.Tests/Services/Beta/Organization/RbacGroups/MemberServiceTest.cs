using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization.RbacGroups;

public class MemberServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.RbacGroups.Members.List(
            "rbac_group_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Add_Works()
    {
        var betaRbacGroupMember = await this.client.Beta.Organization.RbacGroups.Members.Add(
            "rbac_group_id",
            new() { UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q" },
            TestContext.Current.CancellationToken
        );
        betaRbacGroupMember.Validate();
    }

    [Fact]
    public async Task Remove_Works()
    {
        var member = await this.client.Beta.Organization.RbacGroups.Members.Remove(
            "user_id",
            new() { RbacGroupID = "rbac_group_id" },
            TestContext.Current.CancellationToken
        );
        member.Validate();
    }
}
