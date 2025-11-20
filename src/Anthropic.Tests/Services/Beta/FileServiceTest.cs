using System.Threading.Tasks;
using Anthropic.Tests;

namespace Anthropic.Tests.Services.Beta;

public class FileServiceTest
{
    [Theory]
    [AnthropicTestClients]
    public async Task List_Works(IAnthropicClient client)
    {
        var page = await client.Beta.Files.List();
        page.Validate();
    }

    [Theory]
    [AnthropicTestClients]
    public async Task Delete_Works(IAnthropicClient client)
    {
        var deletedFile = await client.Beta.Files.Delete("file_id");
        deletedFile.Validate();
    }

    [Theory(Skip = "Prism doesn't support application/binary responses")]
    [AnthropicTestClients]
    public async Task Download_Works(IAnthropicClient client)
    {
        await client.Beta.Files.Download("file_id");
    }

    [Theory]
    [AnthropicTestClients]
    public async Task RetrieveMetadata_Works(IAnthropicClient client)
    {
        var fileMetadata = await client.Beta.Files.RetrieveMetadata("file_id");
        fileMetadata.Validate();
    }
}
