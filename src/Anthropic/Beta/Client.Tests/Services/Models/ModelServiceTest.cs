using System.Threading.Tasks;

namespace Anthropic.Beta.Client.Tests.Services.Models;

public class ModelServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var modelInfo = await this.client.Models.Retrieve(new() { ModelID = "model_id" });
        modelInfo.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Models.List();
        page.Validate();
    }
}
