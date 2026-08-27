using System.Text;
using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta;

public class SkillServiceTest : TestBase
{
    public async Task Create_Works()
    {
        var betaSkill = await this.client.Beta.Skills.Create(
            new() { Files = [Encoding.UTF8.GetBytes("Example data")] },
            TestContext.Current.CancellationToken
        );
        betaSkill.Validate();
    }

    public async Task Retrieve_Works()
    {
        var betaSkill = await this.client.Beta.Skills.Retrieve(
            "skill_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaSkill.Validate();
    }

    public async Task List_Works()
    {
        var page = await this.client.Beta.Skills.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    public async Task Delete_Works()
    {
        var betaDeletedSkill = await this.client.Beta.Skills.Delete(
            "skill_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaDeletedSkill.Validate();
    }
}
