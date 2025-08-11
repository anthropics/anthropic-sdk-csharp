using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.Files;

public class FileServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Files.List(new());
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
        var response = await this.client.Beta.Files.Download(new() { FileID = "file_id" });
        _ = response;
    }

    [Fact]
    public async Task RetrieveMetadata_Works()
    {
        var fileMetadata = await this.client.Beta.Files.RetrieveMetadata(
            new() { FileID = "file_id" }
        );
        fileMetadata.Validate();
    }

    [Fact]
    public async Task Upload_Works()
    {
        var fileMetadata = await this.client.Beta.Files.Upload(new() { File = "a value" });
        fileMetadata.Validate();
    }
}
