using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.MemoryStores.Memories;

namespace Anthropic.Tests.Models.Beta.MemoryStores.Memories;

public class BetaManagedAgentsMemoryListItemTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsMemoryValidationWorks()
    {
        BetaManagedAgentsMemoryListItem value = new BetaManagedAgentsMemory()
        {
            ID = "id",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
            Path = "path",
            Type = BetaManagedAgentsMemoryType.Memory,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Content = "content",
        };
        value.Validate();
    }

    [Fact]
    public void PrefixValidationWorks()
    {
        BetaManagedAgentsMemoryListItem value = new BetaManagedAgentsMemoryPrefix()
        {
            Path = "path",
            Type = BetaManagedAgentsMemoryPrefixType.MemoryPrefix,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMemorySerializationRoundtripWorks()
    {
        BetaManagedAgentsMemoryListItem value = new BetaManagedAgentsMemory()
        {
            ID = "id",
            ContentSha256 = "content_sha256",
            ContentSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
            Path = "path",
            Type = BetaManagedAgentsMemoryType.Memory,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Content = "content",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryListItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PrefixSerializationRoundtripWorks()
    {
        BetaManagedAgentsMemoryListItem value = new BetaManagedAgentsMemoryPrefix()
        {
            Path = "path",
            Type = BetaManagedAgentsMemoryPrefixType.MemoryPrefix,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryListItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
