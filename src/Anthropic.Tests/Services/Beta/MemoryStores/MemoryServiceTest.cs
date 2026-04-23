using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.MemoryStores;

public class MemoryServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaManagedAgentsMemory = await this.client.Beta.MemoryStores.Memories.Create(
            "memory_store_id",
            new() { Content = "content", Path = "xx" },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsMemory.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaManagedAgentsMemory = await this.client.Beta.MemoryStores.Memories.Retrieve(
            "memory_id",
            new() { MemoryStoreID = "memory_store_id" },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsMemory.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaManagedAgentsMemory = await this.client.Beta.MemoryStores.Memories.Update(
            "memory_id",
            new() { MemoryStoreID = "memory_store_id" },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsMemory.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.MemoryStores.Memories.List(
            "memory_store_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var betaManagedAgentsDeletedMemory = await this.client.Beta.MemoryStores.Memories.Delete(
            "memory_id",
            new() { MemoryStoreID = "memory_store_id" },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsDeletedMemory.Validate();
    }
}
