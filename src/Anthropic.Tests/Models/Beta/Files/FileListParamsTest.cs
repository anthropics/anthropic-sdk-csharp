using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Files;

namespace Anthropic.Tests.Models.Beta.Files;

public class FileListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileListParams
        {
            Ids = ["string"],
            Limit = 1,
            Page = "page",
            ScopeID = "scope_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        List<string> expectedIds = ["string"];
        long expectedLimit = 1;
        string expectedPage = "page";
        string expectedScopeID = "scope_id";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.NotNull(parameters.Ids);
        Assert.Equal(expectedIds.Count, parameters.Ids.Count);
        for (int i = 0; i < expectedIds.Count; i++)
        {
            Assert.Equal(expectedIds[i], parameters.Ids[i]);
        }
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedScopeID, parameters.ScopeID);
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
        var parameters = new FileListParams { Ids = ["string"], Page = "page" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.ScopeID);
        Assert.False(parameters.RawQueryData.ContainsKey("scope_id"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FileListParams
        {
            Ids = ["string"],
            Page = "page",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            ScopeID = null,
            Betas = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.ScopeID);
        Assert.False(parameters.RawQueryData.ContainsKey("scope_id"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileListParams
        {
            Limit = 1,
            ScopeID = "scope_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Ids);
        Assert.False(parameters.RawQueryData.ContainsKey("ids"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new FileListParams
        {
            Limit = 1,
            ScopeID = "scope_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            Ids = null,
            Page = null,
        };

        Assert.Null(parameters.Ids);
        Assert.True(parameters.RawQueryData.ContainsKey("ids"));
        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void Url_Works()
    {
        FileListParams parameters = new()
        {
            Ids = ["string"],
            Limit = 1,
            Page = "page",
            ScopeID = "scope_id",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/files?beta=true&ids%5b%5d=string&limit=1&page=page&scope_id=scope_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        FileListParams parameters = new() { Betas = [AnthropicBeta.MessageBatches2024_09_24] };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileListParams
        {
            Ids = ["string"],
            Limit = 1,
            Page = "page",
            ScopeID = "scope_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        FileListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
