using System.Text;
using System.Threading.Tasks;

namespace Anthropic.Tests.Services;

public class SkillServiceTest : TestBase
{
    public async Task Create_Works()
    {
        var skill = await this.client.Skills.Create(
            new() { Files = [Encoding.UTF8.GetBytes("Example data")] },
            TestContext.Current.CancellationToken
        );
        skill.Validate();
    }

    public async Task Retrieve_Works()
    {
        var skill = await this.client.Skills.Retrieve(
            "skill_id",
            new(),
            TestContext.Current.CancellationToken
        );
        skill.Validate();
    }

    public async Task List_Works()
    {
        var page = await this.client.Skills.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    public async Task Delete_Works()
    {
        var deletedSkill = await this.client.Skills.Delete(
            "skill_id",
            new(),
            TestContext.Current.CancellationToken
        );
        deletedSkill.Validate();
    }
}
