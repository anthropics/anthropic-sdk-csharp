using Beta = Anthropic.Models.Beta;
using Tasks = System.Threading.Tasks;
using Tests = Anthropic.Tests;

namespace Anthropic.Tests.Service.Models;

public class ModelServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Retrieve_Works()
    {
        var modelInfo = await this.client.Models.Retrieve(
            new() { ModelID = "model_id", Betas = [Beta::AnthropicBeta.MessageBatches2024_09_24] }
        );
        modelInfo.Validate();
    }

    [Fact]
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Models.List(
            new()
            {
                AfterID = "after_id",
                BeforeID = "before_id",
                Limit = 1,
                Betas = [Beta::AnthropicBeta.MessageBatches2024_09_24],
            }
        );
        page.Validate();
    }
}
