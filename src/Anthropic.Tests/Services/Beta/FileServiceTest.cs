using System.Text;
using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta;

public class FileServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Files.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var deletedFile = await this.client.Beta.Files.Delete(
            "file_id",
            new(),
            TestContext.Current.CancellationToken
        );
        deletedFile.Validate();
    }

    [Fact(Skip = "Mock server doesn't support application/binary responses")]
    public async Task Download_Works()
    {
        await this.client.Beta.Files.Download(
            "file_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task RetrieveMetadata_Works()
    {
        var fileMetadata = await this.client.Beta.Files.RetrieveMetadata(
            "file_id",
            new(),
            TestContext.Current.CancellationToken
        );
        fileMetadata.Validate();
    }

    [Fact]
    public async Task Upload_Works()
    {
        var fileMetadata = await this.client.Beta.Files.Upload(
            new() { File = Encoding.UTF8.GetBytes("text") },
            TestContext.Current.CancellationToken
        );
        fileMetadata.Validate();
    }
}
