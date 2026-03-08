// xUnit1024: same-name overloads are intentional — base method is parameterless with no test attribute.
#pragma warning disable xUnit1024

using System.Text;
using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta;

/// <summary>
/// Runs the <see cref="FileServiceTest"/> suite against each client implementation supported by this service.
/// Each wrapper method sets <c>client</c> to the injected implementation then delegates to the base method.
///
/// When codegen adds a new method to <see cref="FileServiceTest"/>, add a corresponding wrapper here
/// and remove the [Fact] attribute from the base method. The <see cref="GeneratedTestConformanceTest"/>
/// will fail loudly if any [Fact] is left on a <see cref="TestBase"/> subclass.
/// </summary>
public class FileServiceMultiClientTest : FileServiceTest
{
    [Theory]
    [AnthropicTestClients(TestSupportTypes.All & ~TestSupportTypes.Bedrock)]
    public async Task List_Works(IAnthropicClient c)
    {
        client = c;
        await base.List_Works();
    }

    [Theory]
    [AnthropicTestClients(TestSupportTypes.All & ~TestSupportTypes.Bedrock)]
    public async Task Delete_Works(IAnthropicClient c)
    {
        client = c;
        await base.Delete_Works();
    }

    [Theory(Skip = "Mock server doesn't support application/binary responses")]
    [AnthropicTestClients]
    public async Task Download_Works(IAnthropicClient c)
    {
        client = c;
        await base.Download_Works();
    }

    [Theory]
    [AnthropicTestClients(TestSupportTypes.All & ~TestSupportTypes.Bedrock)]
    public async Task RetrieveMetadata_Works(IAnthropicClient c)
    {
        client = c;
        await base.RetrieveMetadata_Works();
    }

    [Theory]
    [AnthropicTestClients(TestSupportTypes.All & ~TestSupportTypes.Bedrock)]
    public async Task Upload_Works(IAnthropicClient c)
    {
        client = c;
        await base.Upload_Works();
    }
}
