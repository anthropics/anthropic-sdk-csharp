using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.MemoryStores;

namespace Anthropic.Tests.Models.Beta.MemoryStores;

public class MemoryStoreUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemoryStoreUpdateParams
        {
            MemoryStoreID = "memory_store_id",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Name = "x",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedMemoryStoreID = "memory_store_id";
        string expectedDescription = "description";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "x";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedMemoryStoreID, parameters.MemoryStoreID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MemoryStoreUpdateParams
        {
            MemoryStoreID = "memory_store_id",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Name = "x",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MemoryStoreUpdateParams
        {
            MemoryStoreID = "memory_store_id",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Name = "x",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MemoryStoreUpdateParams
        {
            MemoryStoreID = "memory_store_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MemoryStoreUpdateParams
        {
            MemoryStoreID = "memory_store_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            Description = null,
            Metadata = null,
            Name = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        MemoryStoreUpdateParams parameters = new() { MemoryStoreID = "memory_store_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/memory_stores/memory_store_id?beta=true"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MemoryStoreUpdateParams parameters = new()
        {
            MemoryStoreID = "memory_store_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["managed-agents-2026-04-01", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MemoryStoreUpdateParams
        {
            MemoryStoreID = "memory_store_id",
            Description = "description",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Name = "x",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        MemoryStoreUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
