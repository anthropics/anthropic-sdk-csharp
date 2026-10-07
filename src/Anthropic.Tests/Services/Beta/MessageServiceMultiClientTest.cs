using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta;

/// <summary>
/// Runs the <see cref="MessageServiceTest"/> suite against each client implementation supported by this service.
/// Each wrapper method sets <c>client</c> to the injected implementation then delegates to the base method.
///
/// When codegen adds a new method to <see cref="MessageServiceTest"/>, add a corresponding wrapper here
/// and remove the [Fact] attribute from the base method. The <see cref="GeneratedTestConformanceTest"/>
/// will fail loudly if any [Fact] is left on a <see cref="TestBase"/> subclass.
/// </summary>
public class MessageServiceMultiClientTest : MessageServiceTest
{
    [Theory]
    [AnthropicTestClients]
    public async Task Create_WorksForClient(IAnthropicClient c)
    {
        client = c;
        await base.Create_Works();
    }

    [Theory]
    [AnthropicTestClients]
    public async Task CreateStreaming_WorksForClient(IAnthropicClient c)
    {
        client = c;
        await base.CreateStreaming_Works();
    }

    [Theory]
    [AnthropicTestClients]
    public async Task CountTokens_WorksForClient(IAnthropicClient c)
    {
        client = c;
        await base.CountTokens_Works();
    }
}
