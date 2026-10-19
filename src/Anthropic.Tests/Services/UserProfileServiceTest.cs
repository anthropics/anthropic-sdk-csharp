using System.Threading.Tasks;

namespace Anthropic.Tests.Services;

public class UserProfileServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var userProfile = await this.client.UserProfiles.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        userProfile.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var userProfile = await this.client.UserProfiles.Retrieve(
            "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            new(),
            TestContext.Current.CancellationToken
        );
        userProfile.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var userProfile = await this.client.UserProfiles.Update(
            "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            new(),
            TestContext.Current.CancellationToken
        );
        userProfile.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.UserProfiles.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var deletedUserProfile = await this.client.UserProfiles.Delete(
            "uprof_011CZkZCu8hGbp5mYRQgUmz9",
            new(),
            TestContext.Current.CancellationToken
        );
        deletedUserProfile.Validate();
    }
}
