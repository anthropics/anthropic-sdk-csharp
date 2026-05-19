using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Environments.Work;

namespace Anthropic.Tests.Models.Beta.Environments.Work;

public class WorkListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkListParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Limit = 1,
            Page = "page",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedEnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW";
        long expectedLimit = 1;
        string expectedPage = "page";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedEnvironmentID, parameters.EnvironmentID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
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
        var parameters = new WorkListParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Page = "page",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkListParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Page = "page",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Betas = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkListParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Limit = 1,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WorkListParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Limit = 1,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            Page = null,
        };

        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkListParams parameters = new()
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Limit = 1,
            Page = "page",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/environments/env_011CZkZ9X2dpNyB7HsEFoRfW/work?beta=true&limit=1&page=page"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WorkListParams parameters = new()
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
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
        var parameters = new WorkListParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Limit = 1,
            Page = "page",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        WorkListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
