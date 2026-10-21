using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Organization;

public class RbacGroupServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaRbacGroup = await this.client.Beta.Organization.RbacGroups.Create(
            new() { Name = "Engineering" },
            TestContext.Current.CancellationToken
        );
        betaRbacGroup.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaRbacGroup = await this.client.Beta.Organization.RbacGroups.Retrieve(
            "rbac_group_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaRbacGroup.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaRbacGroup = await this.client.Beta.Organization.RbacGroups.Update(
            "rbac_group_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaRbacGroup.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.RbacGroups.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var rbacGroup = await this.client.Beta.Organization.RbacGroups.Delete(
            "rbac_group_id",
            new(),
            TestContext.Current.CancellationToken
        );
        rbacGroup.Validate();
    }
}
