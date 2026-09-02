using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.MemoryStores.Memories;

namespace Anthropic.Tests.Models.Beta.MemoryStores.Memories;

public class MemoryDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemoryDeleteParams
        {
            MemoryStoreID = "memory_store_id",
            MemoryID = "memory_id",
            ExpectedContentSha256 = "expected_content_sha256",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        string expectedMemoryStoreID = "memory_store_id";
        string expectedMemoryID = "memory_id";
        string expectedExpectedContentSha256 = "expected_content_sha256";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];
        string expectedWorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy";

        Assert.Equal(expectedMemoryStoreID, parameters.MemoryStoreID);
        Assert.Equal(expectedMemoryID, parameters.MemoryID);
        Assert.Equal(expectedExpectedContentSha256, parameters.ExpectedContentSha256);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MemoryDeleteParams
        {
            MemoryStoreID = "memory_store_id",
            MemoryID = "memory_id",
        };

        Assert.Null(parameters.ExpectedContentSha256);
        Assert.False(parameters.RawQueryData.ContainsKey("expected_content_sha256"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MemoryDeleteParams
        {
            MemoryStoreID = "memory_store_id",
            MemoryID = "memory_id",

            // Null should be interpreted as omitted for these properties
            ExpectedContentSha256 = null,
            Betas = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.ExpectedContentSha256);
        Assert.False(parameters.RawQueryData.ContainsKey("expected_content_sha256"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void Url_Works()
    {
        MemoryDeleteParams parameters = new()
        {
            MemoryStoreID = "memory_store_id",
            MemoryID = "memory_id",
            ExpectedContentSha256 = "expected_content_sha256",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/memory_stores/memory_store_id/memories/memory_id?beta=true&expected_content_sha256=expected_content_sha256"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MemoryDeleteParams parameters = new()
        {
            MemoryStoreID = "memory_store_id",
            MemoryID = "memory_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["agent-memory-2026-07-22", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
        Assert.Equal(
            ["wrkspc_011CZkZaBF1tNoB5wlCeusgy"],
            requestMessage.Headers.GetValues("anthropic-workspace-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MemoryDeleteParams
        {
            MemoryStoreID = "memory_store_id",
            MemoryID = "memory_id",
            ExpectedContentSha256 = "expected_content_sha256",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        MemoryDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
