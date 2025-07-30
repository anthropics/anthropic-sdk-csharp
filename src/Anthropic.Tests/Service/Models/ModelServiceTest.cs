using System.Threading.Tasks;
using Anthropic.Models.Beta;

namespace Anthropic.Tests.Service.Models;

public class ModelServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var modelInfo = await this.client.Models.Retrieve(
            new() { ModelID = "model_id", Betas = [AnthropicBeta.MessageBatches2024_09_24] }
        );
        modelInfo.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Models.List(
            new()
            {
                AfterID = "after_id",
                BeforeID = "before_id",
                Limit = 1,
                Betas = [AnthropicBeta.MessageBatches2024_09_24],
            }
        );
        page.Validate();
    }
}
