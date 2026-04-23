using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.MemoryStores.Memories;

namespace Anthropic.Tests.Models.Beta.MemoryStores.Memories;

public class MemoryUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemoryUpdateParams
        {
            MemoryStoreID = "memory_store_id",
            MemoryID = "memory_id",
            View = BetaManagedAgentsMemoryView.Basic,
            Content = "content",
            Path = "xx",
            Precondition = new()
            {
                Type = BetaManagedAgentsPreconditionType.ContentSha256,
                ContentSha256 = "content_sha256",
            },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedMemoryStoreID = "memory_store_id";
        string expectedMemoryID = "memory_id";
        ApiEnum<string, BetaManagedAgentsMemoryView> expectedView =
            BetaManagedAgentsMemoryView.Basic;
        string expectedContent = "content";
        string expectedPath = "xx";
        BetaManagedAgentsPrecondition expectedPrecondition = new()
        {
            Type = BetaManagedAgentsPreconditionType.ContentSha256,
            ContentSha256 = "content_sha256",
        };
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedMemoryStoreID, parameters.MemoryStoreID);
        Assert.Equal(expectedMemoryID, parameters.MemoryID);
        Assert.Equal(expectedView, parameters.View);
        Assert.Equal(expectedContent, parameters.Content);
        Assert.Equal(expectedPath, parameters.Path);
        Assert.Equal(expectedPrecondition, parameters.Precondition);
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
        var parameters = new MemoryUpdateParams
        {
            MemoryStoreID = "memory_store_id",
            MemoryID = "memory_id",
            Content = "content",
            Path = "xx",
        };

        Assert.Null(parameters.View);
        Assert.False(parameters.RawQueryData.ContainsKey("view"));
        Assert.Null(parameters.Precondition);
        Assert.False(parameters.RawBodyData.ContainsKey("precondition"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MemoryUpdateParams
        {
            MemoryStoreID = "memory_store_id",
            MemoryID = "memory_id",
            Content = "content",
            Path = "xx",

            // Null should be interpreted as omitted for these properties
            View = null,
            Precondition = null,
            Betas = null,
        };

        Assert.Null(parameters.View);
        Assert.False(parameters.RawQueryData.ContainsKey("view"));
        Assert.Null(parameters.Precondition);
        Assert.False(parameters.RawBodyData.ContainsKey("precondition"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MemoryUpdateParams
        {
            MemoryStoreID = "memory_store_id",
            MemoryID = "memory_id",
            View = BetaManagedAgentsMemoryView.Basic,
            Precondition = new()
            {
                Type = BetaManagedAgentsPreconditionType.ContentSha256,
                ContentSha256 = "content_sha256",
            },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Content);
        Assert.False(parameters.RawBodyData.ContainsKey("content"));
        Assert.Null(parameters.Path);
        Assert.False(parameters.RawBodyData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MemoryUpdateParams
        {
            MemoryStoreID = "memory_store_id",
            MemoryID = "memory_id",
            View = BetaManagedAgentsMemoryView.Basic,
            Precondition = new()
            {
                Type = BetaManagedAgentsPreconditionType.ContentSha256,
                ContentSha256 = "content_sha256",
            },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            Content = null,
            Path = null,
        };

        Assert.Null(parameters.Content);
        Assert.True(parameters.RawBodyData.ContainsKey("content"));
        Assert.Null(parameters.Path);
        Assert.True(parameters.RawBodyData.ContainsKey("path"));
    }

    [Fact]
    public void Url_Works()
    {
        MemoryUpdateParams parameters = new()
        {
            MemoryStoreID = "memory_store_id",
            MemoryID = "memory_id",
            View = BetaManagedAgentsMemoryView.Basic,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/memory_stores/memory_store_id/memories/memory_id?beta=true&view=basic"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MemoryUpdateParams parameters = new()
        {
            MemoryStoreID = "memory_store_id",
            MemoryID = "memory_id",
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
        var parameters = new MemoryUpdateParams
        {
            MemoryStoreID = "memory_store_id",
            MemoryID = "memory_id",
            View = BetaManagedAgentsMemoryView.Basic,
            Content = "content",
            Path = "xx",
            Precondition = new()
            {
                Type = BetaManagedAgentsPreconditionType.ContentSha256,
                ContentSha256 = "content_sha256",
            },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        MemoryUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
