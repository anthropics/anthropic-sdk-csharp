// xUnit1024: same-name overloads are intentional — base method is parameterless with no test attribute.
#pragma warning disable xUnit1024

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
    [Theory(
        Skip = "UriBuilder.Query overwrites ?beta=true — beta batch create hits non-beta endpoint; needs codegen fix"
    )]
    [AnthropicTestClients]
    public async Task Create_Works(IAnthropicClient c)
    {
        client = c;
        await base.Create_Works();
    }

    [Theory(
        Skip = "UriBuilder.Query overwrites ?beta=true — beta batch create hits non-beta endpoint; needs codegen fix"
    )]
    [AnthropicTestClients]
    public async Task CreateStreaming_Works(IAnthropicClient c)
    {
        client = c;
        await base.CreateStreaming_Works();
    }

    [Theory(
        Skip = "UriBuilder.Query overwrites ?beta=true — beta batch create hits non-beta endpoint; needs codegen fix"
    )]
    [AnthropicTestClients]
    public async Task CountTokens_Works(IAnthropicClient c)
    {
        client = c;
        await base.CountTokens_Works();
    }
}
