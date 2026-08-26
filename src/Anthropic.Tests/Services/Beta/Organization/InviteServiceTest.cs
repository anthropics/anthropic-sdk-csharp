using System.Threading.Tasks;
using Anthropic.Models.Beta.Organization.Invites;

namespace Anthropic.Tests.Services.Beta.Organization;

public class InviteServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaOrganizationInvite = await this.client.Beta.Organization.Invites.Create(
            new() { Email = "user@emaildomain.com", Role = Role.User },
            TestContext.Current.CancellationToken
        );
        betaOrganizationInvite.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaOrganizationInvite = await this.client.Beta.Organization.Invites.Retrieve(
            "invite_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaOrganizationInvite.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Organization.Invites.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var invite = await this.client.Beta.Organization.Invites.Delete(
            "invite_id",
            new(),
            TestContext.Current.CancellationToken
        );
        invite.Validate();
    }
}
