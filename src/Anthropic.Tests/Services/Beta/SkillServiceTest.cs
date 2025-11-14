using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta;

public class SkillServiceTest : TestBase
{
    [Fact(Skip = "prism binary unsupported")]
    public async Task Create_Works()
    {
        var skill = await this.client.Beta.Skills.Create();
        skill.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var skill = await this.client.Beta.Skills.Retrieve(new() { SkillID = "skill_id" });
        skill.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Skills.List();
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var skill = await this.client.Beta.Skills.Delete(new() { SkillID = "skill_id" });
        skill.Validate();
    }
}
