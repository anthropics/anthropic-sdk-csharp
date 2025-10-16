using System.Threading.Tasks;

namespace Anthropic.Client.Tests.Services.Beta.Skills.Versions;

public class VersionServiceTest : TestBase
{
    [Fact(Skip = "prism binary unsupported")]
    public async Task Create_Works()
    {
        var version = await this.client.Beta.Skills.Versions.Create(new() { SkillID = "skill_id" });
        version.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var version = await this.client.Beta.Skills.Versions.Retrieve(
            new() { SkillID = "skill_id", Version = "version" }
        );
        version.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Skills.Versions.List(new() { SkillID = "skill_id" });
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var version = await this.client.Beta.Skills.Versions.Delete(
            new() { SkillID = "skill_id", Version = "version" }
        );
        version.Validate();
    }
}
