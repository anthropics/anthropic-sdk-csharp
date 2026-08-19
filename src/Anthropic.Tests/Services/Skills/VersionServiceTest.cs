using System.Text;
using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Skills;

public class VersionServiceTest : TestBase
{
    public async Task Create_Works()
    {
        var skillVersion = await this.client.Skills.Versions.Create(
            "skill_id",
            new() { Files = [Encoding.UTF8.GetBytes("Example data")] },
            TestContext.Current.CancellationToken
        );
        skillVersion.Validate();
    }

    public async Task Retrieve_Works()
    {
        var skillVersion = await this.client.Skills.Versions.Retrieve(
            "version",
            new() { SkillID = "skill_id" },
            TestContext.Current.CancellationToken
        );
        skillVersion.Validate();
    }

    public async Task List_Works()
    {
        var page = await this.client.Skills.Versions.List(
            "skill_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    public async Task Delete_Works()
    {
        var deletedSkillVersion = await this.client.Skills.Versions.Delete(
            "version",
            new() { SkillID = "skill_id" },
            TestContext.Current.CancellationToken
        );
        deletedSkillVersion.Validate();
    }
}
