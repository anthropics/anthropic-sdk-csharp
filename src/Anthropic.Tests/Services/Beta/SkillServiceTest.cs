using System.Threading.Tasks;
using Anthropic.Tests;

namespace Anthropic.Tests.Services.Beta;

public class SkillServiceTest
{
    [Theory(Skip = "prism binary unsupported")]
    [AnthropicTestClients]
    public async Task Create_Works(IAnthropicClient client)
    {
        var skill = await client.Beta.Skills.Create();
        skill.Validate();
    }

    [Theory]
    [AnthropicTestClients]
    public async Task Retrieve_Works(IAnthropicClient client)
    {
        var skill = await client.Beta.Skills.Retrieve(new() { SkillID = "skill_id" });
        skill.Validate();
    }


    [Theory]
    [AnthropicTestClients]
    public async Task List_Works(IAnthropicClient client)
    {
        var page = await client.Beta.Skills.List();
        page.Validate();
    }


    [Theory]
    [AnthropicTestClients]
    public async Task Delete_Works(IAnthropicClient client)
    {
        var skill = await client.Beta.Skills.Delete(new() { SkillID = "skill_id" });
        skill.Validate();
    }
}
