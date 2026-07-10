using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class DreamListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DreamListParams
        {
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IncludeArchived = true,
            Limit = 0,
            Page = "page",
            Statuses = [BetaDreamStatus.Pending],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        DateTimeOffset expectedCreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIncludeArchived = true;
        int expectedLimit = 0;
        string expectedPage = "page";
        List<ApiEnum<string, BetaDreamStatus>> expectedStatuses = [BetaDreamStatus.Pending];
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedCreatedAtGt, parameters.CreatedAtGt);
        Assert.Equal(expectedCreatedAtLt, parameters.CreatedAtLt);
        Assert.Equal(expectedIncludeArchived, parameters.IncludeArchived);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.NotNull(parameters.Statuses);
        Assert.Equal(expectedStatuses.Count, parameters.Statuses.Count);
        for (int i = 0; i < expectedStatuses.Count; i++)
        {
            Assert.Equal(expectedStatuses[i], parameters.Statuses[i]);
        }
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
        var parameters = new DreamListParams { };

        Assert.Null(parameters.CreatedAtGt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gt]"));
        Assert.Null(parameters.CreatedAtLt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lt]"));
        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("include_archived"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Statuses);
        Assert.False(parameters.RawQueryData.ContainsKey("statuses"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DreamListParams
        {
            // Null should be interpreted as omitted for these properties
            CreatedAtGt = null,
            CreatedAtLt = null,
            IncludeArchived = null,
            Limit = null,
            Page = null,
            Statuses = null,
            Betas = null,
        };

        Assert.Null(parameters.CreatedAtGt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[gt]"));
        Assert.Null(parameters.CreatedAtLt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at[lt]"));
        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("include_archived"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Statuses);
        Assert.False(parameters.RawQueryData.ContainsKey("statuses"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        DreamListParams parameters = new()
        {
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            IncludeArchived = true,
            Limit = 0,
            Page = "page",
            Statuses = [BetaDreamStatus.Pending],
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/dreams?beta=true&created_at%5bgt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at%5blt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&include_archived=true&limit=0&page=page&statuses%5b%5d=pending"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        DreamListParams parameters = new() { Betas = [AnthropicBeta.MessageBatches2024_09_24] };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["dreaming-2026-04-21", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DreamListParams
        {
            CreatedAtGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IncludeArchived = true,
            Limit = 0,
            Page = "page",
            Statuses = [BetaDreamStatus.Pending],
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        DreamListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
