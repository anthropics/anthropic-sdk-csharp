using System.Threading.Tasks;
using Anthropic.Models.Organization.Users;

namespace Anthropic.Tests.Services.Organization;

public class UserServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var organizationUser = await this.client.Organization.Users.Retrieve(
            "user_id",
            new(),
            TestContext.Current.CancellationToken
        );
        organizationUser.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var organizationUser = await this.client.Organization.Users.Update(
            "user_id",
            new() { Role = Role.User },
            TestContext.Current.CancellationToken
        );
        organizationUser.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Organization.Users.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Remove_Works()
    {
        var user = await this.client.Organization.Users.Remove(
            "user_id",
            new(),
            TestContext.Current.CancellationToken
        );
        user.Validate();
    }
}
