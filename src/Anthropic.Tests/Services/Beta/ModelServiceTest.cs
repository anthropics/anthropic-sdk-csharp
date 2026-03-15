using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta;

public class ModelServiceTest : TestBase
{
    public async Task Retrieve_Works()
    {
        var betaModelInfo = await this.client.Beta.Models.Retrieve(
            "model_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaModelInfo.Validate();
    }

    public async Task List_Works()
    {
        var page = await this.client.Beta.Models.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }
}
