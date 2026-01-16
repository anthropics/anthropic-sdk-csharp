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
            AfterID = "after_id",
            BeforeID = "before_id",
            Limit = 1,
            Betas = ["string"],
        };

        string expectedAfterID = "after_id";
        string expectedBeforeID = "before_id";
        long expectedLimit = 1;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas = ["string"];

        Assert.Equal(expectedAfterID, parameters.AfterID);
        Assert.Equal(expectedBeforeID, parameters.BeforeID);
        Assert.Equal(expectedLimit, parameters.Limit);
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
        var parameters = new FileListParams { };

        Assert.Null(parameters.AfterID);
        Assert.False(parameters.RawQueryData.ContainsKey("after_id"));
        Assert.Null(parameters.BeforeID);
        Assert.False(parameters.RawQueryData.ContainsKey("before_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FileListParams
        {
            // Null should be interpreted as omitted for these properties
            AfterID = null,
            BeforeID = null,
            Limit = null,
            Betas = null,
        };

        Assert.Null(parameters.AfterID);
        Assert.False(parameters.RawQueryData.ContainsKey("after_id"));
        Assert.Null(parameters.BeforeID);
        Assert.False(parameters.RawQueryData.ContainsKey("before_id"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        FileListParams parameters = new()
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Limit = 1,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            new Uri(
                "https://api.anthropic.com/v1/files?after_id=after_id&before_id=before_id&limit=1"
            ),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        FileListParams parameters = new() { Betas = ["string"] };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["files-api-2025-04-14", "string"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Limit = 1,
            Betas = ["string"],
        };

        FileListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
