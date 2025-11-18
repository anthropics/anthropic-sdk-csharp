using System.Threading.Tasks;
using Anthropic.Tests;

namespace Anthropic.Tests.Services.Beta.Skills;

public class VersionServiceTest
{
    [Theory(Skip = "prism binary unsupported")]
    [AnthropicTestClients]
    public async Task Create_Works(IAnthropicClient client)
    {
        var version = await client.Beta.Skills.Versions.Create(new() { SkillID = "skill_id" });
        version.Validate();
    }

    
    [Theory]
    [AnthropicTestClients]
    public async Task Retrieve_Works(IAnthropicClient client)
    {
        var version = await client.Beta.Skills.Versions.Retrieve(
            new() { SkillID = "skill_id", Version = "version" }
        );
        version.Validate();
    }

    
    [Theory]
    [AnthropicTestClients]
    public async Task List_Works(IAnthropicClient client)
    {
        var page = await client.Beta.Skills.Versions.List(new() { SkillID = "skill_id" });
        page.Validate();
    }

    
    [Theory]
    [AnthropicTestClients]
    public async Task Delete_Works(IAnthropicClient client)
    {
        var version = await client.Beta.Skills.Versions.Delete(
            new() { SkillID = "skill_id", Version = "version" }
        );
        version.Validate();
    }
}
