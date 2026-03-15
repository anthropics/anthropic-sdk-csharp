using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Skills;

public class VersionServiceTest : TestBase
{
    public async Task Create_Works()
    {
        var version = await this.client.Beta.Skills.Versions.Create(
            "skill_id",
            new(),
            TestContext.Current.CancellationToken
        );
        version.Validate();
    }

    public async Task Retrieve_Works()
    {
        var version = await this.client.Beta.Skills.Versions.Retrieve(
            "version",
            new() { SkillID = "skill_id" },
            TestContext.Current.CancellationToken
        );
        version.Validate();
    }

    public async Task List_Works()
    {
        var page = await this.client.Beta.Skills.Versions.List(
            "skill_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    public async Task Delete_Works()
    {
        var version = await this.client.Beta.Skills.Versions.Delete(
            "version",
            new() { SkillID = "skill_id" },
            TestContext.Current.CancellationToken
        );
        version.Validate();
    }
}
