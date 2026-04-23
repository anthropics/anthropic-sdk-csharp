using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta;

public class MemoryStoreServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var betaManagedAgentsMemoryStore = await this.client.Beta.MemoryStores.Create(
            new() { Name = "x" },
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsMemoryStore.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var betaManagedAgentsMemoryStore = await this.client.Beta.MemoryStores.Retrieve(
            "memory_store_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsMemoryStore.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var betaManagedAgentsMemoryStore = await this.client.Beta.MemoryStores.Update(
            "memory_store_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsMemoryStore.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.MemoryStores.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var betaManagedAgentsDeletedMemoryStore = await this.client.Beta.MemoryStores.Delete(
            "memory_store_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsDeletedMemoryStore.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var betaManagedAgentsMemoryStore = await this.client.Beta.MemoryStores.Archive(
            "memory_store_id",
            new(),
            TestContext.Current.CancellationToken
        );
        betaManagedAgentsMemoryStore.Validate();
    }
}
