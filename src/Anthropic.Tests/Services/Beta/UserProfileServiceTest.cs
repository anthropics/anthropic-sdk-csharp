using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta;

public class UserProfileServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaUserProfile = await this.client.Beta.UserProfiles.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        betaUserProfile.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaUserProfile = await this.client.Beta.UserProfiles.Retrieve(
            "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            new(),
            TestContext.Current.CancellationToken
        );
        betaUserProfile.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaUserProfile = await this.client.Beta.UserProfiles.Update(
            "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            new(),
            TestContext.Current.CancellationToken
        );
        betaUserProfile.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.UserProfiles.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task CreateEnrollmentUrl_Works()
    {
        var betaUserProfileEnrollmentUrl = await this.client.Beta.UserProfiles.CreateEnrollmentUrl(
            "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            new(),
            TestContext.Current.CancellationToken
        );
        betaUserProfileEnrollmentUrl.Validate();
    }
}
