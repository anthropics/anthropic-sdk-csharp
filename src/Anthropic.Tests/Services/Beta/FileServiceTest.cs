using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta;

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

    [Fact(Skip = "Prism doesn't support application/binary responses")]
    public async Task Download_Works()
    {
        await this.client.Beta.Files.Download(new() { FileID = "file_id" });
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
