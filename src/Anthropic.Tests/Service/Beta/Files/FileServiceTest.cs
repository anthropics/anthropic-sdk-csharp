using System.Threading.Tasks;
using Anthropic.Models.Beta;

namespace Anthropic.Tests.Service.Beta.Files;

public class FileServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Beta.Files.List(
            new()
            {
                AfterID = "after_id",
                BeforeID = "before_id",
                Limit = 1,
                Betas = [AnthropicBeta.MessageBatches2024_09_24],
            }
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var deletedFile = await this.client.Beta.Files.Delete(
            new() { FileID = "file_id", Betas = [AnthropicBeta.MessageBatches2024_09_24] }
        );
        deletedFile.Validate();
    }

    [Fact]
    public async Task Download_Works()
    {
        var response = await this.client.Beta.Files.Download(
            new() { FileID = "file_id", Betas = [AnthropicBeta.MessageBatches2024_09_24] }
        );
        _ = response;
    }

    [Fact]
    public async Task RetrieveMetadata_Works()
    {
        var fileMetadata = await this.client.Beta.Files.RetrieveMetadata(
            new() { FileID = "file_id", Betas = [AnthropicBeta.MessageBatches2024_09_24] }
        );
        fileMetadata.Validate();
    }

    [Fact]
    public async Task Upload_Works()
    {
        var fileMetadata = await this.client.Beta.Files.Upload(
            new() { File = "a value", Betas = [AnthropicBeta.MessageBatches2024_09_24] }
        );
        fileMetadata.Validate();
    }
}
