using System.Threading.Tasks;
using Anthropic.Tests;

namespace Anthropic.Tests.Services.Beta.Skills;

public class VersionServiceTest : TestBase
{
    [Fact(Skip = "prism binary unsupported")]
    public async Task Create_Works()
    {
        var version = await this.client.Beta.Skills.Versions.Create("skill_id");
        version.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var version = await this.client.Beta.Skills.Versions.Retrieve(
            "version",
            new() { SkillID = "skill_id" }
        );
        version.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Skills.Versions.List("skill_id");
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var version = await this.client.Beta.Skills.Versions.Delete(
            "version",
            new() { SkillID = "skill_id" }
        );
        version.Validate();
    }
}
