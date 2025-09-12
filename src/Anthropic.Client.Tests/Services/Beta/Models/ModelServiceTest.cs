using System.Threading.Tasks;

namespace Anthropic.Client.Tests.Services.Beta.Models;

public class ModelServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaModelInfo = await this.client.Beta.Models.Retrieve(new() { ModelID = "model_id" });
        betaModelInfo.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Models.List();
        page.Validate();
    }
}
