using System.Threading.Tasks;
using Anthropic.Tests;

namespace Anthropic.Tests.Services;

public class ModelServiceTest
{    
    [Theory]
    [AnthropicTestClients(TestSupportTypes.Anthropic)]
    public async Task Retrieve_Works(IAnthropicClient client)
    {
        var modelInfo = await client.Models.Retrieve(new() { ModelID = "model_id" });
        modelInfo.Validate();
    }

    
    [Theory]
    [AnthropicTestClients]
    public async Task List_Works(IAnthropicClient client)
    {
        var page = await client.Models.List();
        page.Validate();
    }
}
