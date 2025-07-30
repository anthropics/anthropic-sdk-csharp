using Beta = Anthropic.Models.Beta;
using Tasks = System.Threading.Tasks;
using Tests = Anthropic.Tests;

namespace Anthropic.Tests.Service.Beta.Models;

public class ModelServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Retrieve_Works()
    {
        var betaModelInfo = await this.client.Beta.Models.Retrieve(
            new() { ModelID = "model_id", Betas = [Beta::AnthropicBeta.MessageBatches2024_09_24] }
        );
        betaModelInfo.Validate();
    }

    [Fact]
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Beta.Models.List(
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
