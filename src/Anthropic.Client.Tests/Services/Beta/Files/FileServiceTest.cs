using System.Threading.Tasks;

namespace Anthropic.Client.Tests.Services.Beta.Files;

public class FileServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Files.List();
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var deletedFile = await this.client.Beta.Files.Delete(new() { FileID = "file_id" });
        deletedFile.Validate();
    }

    [Fact]
    public async Task RetrieveMetadata_Works()
    {
        var fileMetadata = await this.client.Beta.Files.RetrieveMetadata(
            new() { FileID = "file_id" }
        );
        fileMetadata.Validate();
    }
}
