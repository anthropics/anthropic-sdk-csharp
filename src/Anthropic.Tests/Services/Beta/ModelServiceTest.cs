using System.Threading.Tasks;
using Anthropic.Tests;

namespace Anthropic.Tests.Services.Beta;

public class ModelServiceTest
{
    [Theory]
    [AnthropicTestClients(TestSupportTypes.Anthropic)]
    public async Task Retrieve_Works(IAnthropicClient client)
    {
        var betaModelInfo = await client.Beta.Models.Retrieve(
            "model_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaModelInfo.Validate();
    }

    [Theory]
    [AnthropicTestClients]
    public async Task List_Works(IAnthropicClient client)
    {
        var page = await client.Beta.Models.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }
}
