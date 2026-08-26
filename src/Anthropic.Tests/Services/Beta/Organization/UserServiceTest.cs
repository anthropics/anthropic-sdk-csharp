using System.Threading.Tasks;
using Anthropic.Models.Beta.Organization.Users;

namespace Anthropic.Tests.Services.Beta.Organization;

public class UserServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaOrganizationUser = await this.client.Beta.Organization.Users.Retrieve(
            "user_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaOrganizationUser.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaOrganizationUser = await this.client.Beta.Organization.Users.Update(
            "user_id",
            new() { Role = Role.User },
            TestContext.Current.CancellationToken
        );
        betaOrganizationUser.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.Users.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Remove_Works()
    {
        var user = await this.client.Beta.Organization.Users.Remove(
            "user_id",
            new(),
            TestContext.Current.CancellationToken
        );
        user.Validate();
    }
}
