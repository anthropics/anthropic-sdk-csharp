// xUnit1024: same-name overloads are intentional — base method is parameterless with no test attribute.
#pragma warning disable xUnit1024

using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta;

/// <summary>
/// Runs the <see cref="SkillServiceTest"/> suite against each client implementation supported by this service.
/// Each wrapper method sets <c>client</c> to the injected implementation then delegates to the base method.
///
/// When codegen adds a new method to <see cref="SkillServiceTest"/>, add a corresponding wrapper here
/// and remove the [Fact] attribute from the base method. The <see cref="GeneratedTestConformanceTest"/>
/// will fail loudly if any [Fact] is left on a <see cref="TestBase"/> subclass.
/// </summary>
public class SkillServiceMultiClientTest : SkillServiceTest
{
    [Theory(Skip = "prism binary unsupported")]
    [AnthropicTestClients]
    public async Task Create_Works(IAnthropicClient c)
    {
        client = c;
        await base.Create_Works();
    }

    [Theory]
    [AnthropicTestClients]
    public async Task Retrieve_Works(IAnthropicClient c)
    {
        client = c;
        await base.Retrieve_Works();
    }

    [Theory]
    [AnthropicTestClients]
    public async Task List_Works(IAnthropicClient c)
    {
        client = c;
        await base.List_Works();
    }

    [Theory]
    [AnthropicTestClients]
    public async Task Delete_Works(IAnthropicClient c)
    {
        client = c;
        await base.Delete_Works();
    }
}
