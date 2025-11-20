using System.Threading.Tasks;
using Anthropic.Tests;

namespace Anthropic.Tests.Services.Beta.Skills;

public class VersionServiceTest
{
    [Theory(Skip = "prism binary unsupported")]
    [AnthropicTestClients]
    public async Task Create_Works(IAnthropicClient client)
    {
        var version = await client.Beta.Skills.Versions.Create("skill_id");
        version.Validate();
    }

    [Theory]
    [AnthropicTestClients]
    public async Task Retrieve_Works(IAnthropicClient client)
    {
        var version = await client.Beta.Skills.Versions.Retrieve(
            "version",
            new() { SkillID = "skill_id" }
        );
        version.Validate();
    }

    [Theory]
    [AnthropicTestClients]
    public async Task List_Works(IAnthropicClient client)
    {
        var page = await client.Beta.Skills.Versions.List("skill_id");
        page.Validate();
    }

    [Theory]
    [AnthropicTestClients]
    public async Task Delete_Works(IAnthropicClient client)
    {
        var version = await client.Beta.Skills.Versions.Delete(
            "version",
            new() { SkillID = "skill_id" }
        );
        version.Validate();
    }
}
