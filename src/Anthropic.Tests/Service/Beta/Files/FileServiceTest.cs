using Beta = Anthropic.Models.Beta;
using Tasks = System.Threading.Tasks;
using Tests = Anthropic.Tests;

namespace Anthropic.Tests.Service.Beta.Files;

public class FileServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task List_Works()
    {
        var page = await this.client.Beta.Files.List(
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

    [Fact]
    public async Tasks::Task Delete_Works()
    {
        var deletedFile = await this.client.Beta.Files.Delete(
            new() { FileID = "file_id", Betas = [Beta::AnthropicBeta.MessageBatches2024_09_24] }
        );
        deletedFile.Validate();
    }

    [Fact]
    public async Tasks::Task Download_Works()
    {
        var response = await this.client.Beta.Files.Download(
            new() { FileID = "file_id", Betas = [Beta::AnthropicBeta.MessageBatches2024_09_24] }
        );
        _ = response;
    }

    [Fact]
    public async Tasks::Task RetrieveMetadata_Works()
    {
        var fileMetadata = await this.client.Beta.Files.RetrieveMetadata(
            new() { FileID = "file_id", Betas = [Beta::AnthropicBeta.MessageBatches2024_09_24] }
        );
        fileMetadata.Validate();
    }

    [Fact]
    public async Tasks::Task Upload_Works()
    {
        var fileMetadata = await this.client.Beta.Files.Upload(
            new() { File = "a value", Betas = [Beta::AnthropicBeta.MessageBatches2024_09_24] }
        );
        fileMetadata.Validate();
    }
}
