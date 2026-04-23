using System.Threading.Tasks;

namespace Anthropic.Tests.Services.Beta.MemoryStores;

public class MemoryVersionServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var betaManagedAgentsMemoryVersion =
            await this.client.Beta.MemoryStores.MemoryVersions.Retrieve(
                "memory_version_id",
                new() { MemoryStoreID = "memory_store_id" },
                TestContext.Current.CancellationToken
            );
        betaManagedAgentsMemoryVersion.Validate();
    }

    [Fact(Skip = "buildURL drops path-level query params (SDK-4349)")]
    public async Task List_Works()
    {
        var page = await this.client.Beta.MemoryStores.MemoryVersions.List(
            "memory_store_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Redact_Works()
    {
        var betaManagedAgentsMemoryVersion =
            await this.client.Beta.MemoryStores.MemoryVersions.Redact(
                "memory_version_id",
                new() { MemoryStoreID = "memory_store_id" },
                TestContext.Current.CancellationToken
            );
        betaManagedAgentsMemoryVersion.Validate();
    }
}
