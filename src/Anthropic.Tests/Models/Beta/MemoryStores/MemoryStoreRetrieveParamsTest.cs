using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.MemoryStores;

namespace Anthropic.Tests.Models.Beta.MemoryStores;

public class MemoryStoreRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemoryStoreRetrieveParams
        {
            MemoryStoreID = "memory_store_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedMemoryStoreID = "memory_store_id";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedMemoryStoreID, parameters.MemoryStoreID);
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
        var parameters = new MemoryStoreRetrieveParams { MemoryStoreID = "memory_store_id" };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MemoryStoreRetrieveParams
        {
            MemoryStoreID = "memory_store_id",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        MemoryStoreRetrieveParams parameters = new() { MemoryStoreID = "memory_store_id" };

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
        MemoryStoreRetrieveParams parameters = new()
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
        var parameters = new MemoryStoreRetrieveParams
        {
            MemoryStoreID = "memory_store_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        MemoryStoreRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
