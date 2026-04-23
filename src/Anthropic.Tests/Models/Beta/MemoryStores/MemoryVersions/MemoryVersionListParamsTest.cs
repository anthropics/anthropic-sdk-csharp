using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.MemoryStores.Memories;
using Anthropic.Models.Beta.MemoryStores.MemoryVersions;

namespace Anthropic.Tests.Models.Beta.MemoryStores.MemoryVersions;

public class MemoryVersionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MemoryVersionListParams
        {
            MemoryStoreID = "memory_store_id",
            ApiKeyID = "api_key_id",
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 0,
            MemoryID = "memory_id",
            Operation = BetaManagedAgentsMemoryVersionOperation.Created,
            Page = "page",
            SessionID = "session_id",
            View = BetaManagedAgentsMemoryView.Basic,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedMemoryStoreID = "memory_store_id";
        string expectedApiKeyID = "api_key_id";
        DateTimeOffset expectedCreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        int expectedLimit = 0;
        string expectedMemoryID = "memory_id";
        ApiEnum<string, BetaManagedAgentsMemoryVersionOperation> expectedOperation =
            BetaManagedAgentsMemoryVersionOperation.Created;
        string expectedPage = "page";
        string expectedSessionID = "session_id";
        ApiEnum<string, BetaManagedAgentsMemoryView> expectedView =
            BetaManagedAgentsMemoryView.Basic;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedMemoryStoreID, parameters.MemoryStoreID);
        Assert.Equal(expectedApiKeyID, parameters.ApiKeyID);
        Assert.Equal(expectedCreatedAtGte, parameters.CreatedAtGte);
        Assert.Equal(expectedCreatedAtLte, parameters.CreatedAtLte);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMemoryID, parameters.MemoryID);
        Assert.Equal(expectedOperation, parameters.Operation);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedSessionID, parameters.SessionID);
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
        var parameters = new MemoryVersionListParams { MemoryStoreID = "memory_store_id" };

        Assert.Null(parameters.ApiKeyID);
        Assert.False(parameters.RawQueryData.ContainsKey("api_key_id"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gte]"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lte]"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.MemoryID);
        Assert.False(parameters.RawQueryData.ContainsKey("memory_id"));
        Assert.Null(parameters.Operation);
        Assert.False(parameters.RawQueryData.ContainsKey("operation"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.SessionID);
        Assert.False(parameters.RawQueryData.ContainsKey("session_id"));
        Assert.Null(parameters.View);
        Assert.False(parameters.RawQueryData.ContainsKey("view"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MemoryVersionListParams
        {
            MemoryStoreID = "memory_store_id",

            // Null should be interpreted as omitted for these properties
            ApiKeyID = null,
            CreatedAtGte = null,
            CreatedAtLte = null,
            Limit = null,
            MemoryID = null,
            Operation = null,
            Page = null,
            SessionID = null,
            View = null,
            Betas = null,
        };

        Assert.Null(parameters.ApiKeyID);
        Assert.False(parameters.RawQueryData.ContainsKey("api_key_id"));
        Assert.Null(parameters.CreatedAtGte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gte]"));
        Assert.Null(parameters.CreatedAtLte);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lte]"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.MemoryID);
        Assert.False(parameters.RawQueryData.ContainsKey("memory_id"));
        Assert.Null(parameters.Operation);
        Assert.False(parameters.RawQueryData.ContainsKey("operation"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.SessionID);
        Assert.False(parameters.RawQueryData.ContainsKey("session_id"));
        Assert.Null(parameters.View);
        Assert.False(parameters.RawQueryData.ContainsKey("view"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        MemoryVersionListParams parameters = new()
        {
            MemoryStoreID = "memory_store_id",
            ApiKeyID = "api_key_id",
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            Limit = 0,
            MemoryID = "memory_id",
            Operation = BetaManagedAgentsMemoryVersionOperation.Created,
            Page = "page",
            SessionID = "session_id",
            View = BetaManagedAgentsMemoryView.Basic,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/memory_stores/memory_store_id/memory_versions?beta=true&api_key_id=api_key_id&created_at%5bgte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at%5blte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&limit=0&memory_id=memory_id&operation=created&page=page&session_id=session_id&view=basic"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MemoryVersionListParams parameters = new()
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
        var parameters = new MemoryVersionListParams
        {
            MemoryStoreID = "memory_store_id",
            ApiKeyID = "api_key_id",
            CreatedAtGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 0,
            MemoryID = "memory_id",
            Operation = BetaManagedAgentsMemoryVersionOperation.Created,
            Page = "page",
            SessionID = "session_id",
            View = BetaManagedAgentsMemoryView.Basic,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        MemoryVersionListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
