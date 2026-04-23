using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.MemoryStores.Memories;
using Anthropic.Models.Beta.MemoryStores.MemoryVersions;

namespace Anthropic.Tests.Models.Beta.MemoryStores.MemoryVersions;

public class MemoryVersionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemoryVersionRetrieveParams
        {
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
            View = BetaManagedAgentsMemoryView.Basic,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedMemoryStoreID = "memory_store_id";
        string expectedMemoryVersionID = "memory_version_id";
        ApiEnum<string, BetaManagedAgentsMemoryView> expectedView =
            BetaManagedAgentsMemoryView.Basic;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedMemoryStoreID, parameters.MemoryStoreID);
        Assert.Equal(expectedMemoryVersionID, parameters.MemoryVersionID);
        Assert.Equal(expectedView, parameters.View);
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
        var parameters = new MemoryVersionRetrieveParams
        {
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
        };

        Assert.Null(parameters.View);
        Assert.False(parameters.RawQueryData.ContainsKey("view"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MemoryVersionRetrieveParams
        {
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",

            // Null should be interpreted as omitted for these properties
            View = null,
            Betas = null,
        };

        Assert.Null(parameters.View);
        Assert.False(parameters.RawQueryData.ContainsKey("view"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        MemoryVersionRetrieveParams parameters = new()
        {
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
            View = BetaManagedAgentsMemoryView.Basic,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/memory_stores/memory_store_id/memory_versions/memory_version_id?beta=true&view=basic"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MemoryVersionRetrieveParams parameters = new()
        {
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
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
        var parameters = new MemoryVersionRetrieveParams
        {
            MemoryStoreID = "memory_store_id",
            MemoryVersionID = "memory_version_id",
            View = BetaManagedAgentsMemoryView.Basic,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        MemoryVersionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
