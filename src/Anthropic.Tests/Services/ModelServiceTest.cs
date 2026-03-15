using System.Threading.Tasks;

namespace Anthropic.Tests.Services;

public class ModelServiceTest : TestBase
{
    public async Task Retrieve_Works()
    {
        var modelInfo = await this.client.Models.Retrieve(
            "model_id",
            new(),
            TestContext.Current.CancellationToken
        );
        modelInfo.Validate();
    }

    public async Task List_Works()
    {
        var page = await this.client.Models.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }
}
