using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta;

public class SkillServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var skill = await this.client.Beta.Skills.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        skill.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var skill = await this.client.Beta.Skills.Retrieve(
            "skill_id",
            new(),
            TestContext.Current.CancellationToken
        );
        skill.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Skills.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var skill = await this.client.Beta.Skills.Delete(
            "skill_id",
            new(),
            TestContext.Current.CancellationToken
        );
        skill.Validate();
    }
}
