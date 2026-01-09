using System.Threading.Tasks;
using Anthropic.Tests;

namespace Anthropic.Tests.Services;

public class ModelServiceTest
{
    [Theory]
    [AnthropicTestClients(TestSupportTypes.Anthropic)]
    public async Task Retrieve_Works(IAnthropicClient client)
    {
        var modelInfo = await client.Models.Retrieve(
            "model_id",
            new(),
            TestContext.Current.CancellationToken
        );
        modelInfo.Validate();
    }

    [Theory]
    [AnthropicTestClients]
    public async Task List_Works(IAnthropicClient client)
    {
        var page = await client.Models.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }
}
