using System.Threading.Tasks;
using Anthropic.Models.Beta.Sessions.Resources;

namespace Anthropic.Tests.Services.Beta.Sessions;

public class ResourceServiceTest : TestBase
{
    [Fact(Skip = "prism can't find endpoint with beta only tag")]
    public async Task Retrieve_Works()
    {
        var resource = await this.client.Beta.Sessions.Resources.Retrieve(
            "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            new() { SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7" },
            TestContext.Current.CancellationToken
        );
        resource.Validate();
    }

    [Fact(Skip = "prism can't find endpoint with beta only tag")]
    public async Task Update_Works()
    {
        var resource = await this.client.Beta.Sessions.Resources.Update(
            "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
            new()
            {
                SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7",
                AuthorizationToken = "ghp_exampletoken",
            },
            TestContext.Current.CancellationToken
        );
        resource.Validate();
    }

    [Fact(Skip = "prism can't find endpoint with beta only tag")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Sessions.Resources.List(
            "sesn_011CZkZAtmR3yMPDzynEDxu7",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "prism can't find endpoint with beta only tag")]
    public async Task Delete_Works()
    {
        var betaManagedAgentsDeleteSessionResource =
            await this.client.Beta.Sessions.Resources.Delete(
                "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
                new() { SessionID = "sesn_011CZkZAtmR3yMPDzynEDxu7" },
                TestContext.Current.CancellationToken
            );
        betaManagedAgentsDeleteSessionResource.Validate();
    }

    [Fact(Skip = "prism can't find endpoint with beta only tag")]
    public async Task Add_Works()
    {
        var betaManagedAgentsFileResource = await this.client.Beta.Sessions.Resources.Add(
            "sesn_011CZkZAtmR3yMPDzynEDxu7",
            new() { FileID = "file_011CNha8iCJcU1wXNR6q4V8w", Type = Type.File },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsFileResource.Validate();
    }
}
