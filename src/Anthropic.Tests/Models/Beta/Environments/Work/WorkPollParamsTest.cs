using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Environments.Work;

namespace Anthropic.Tests.Models.Beta.Environments.Work;

public class WorkPollParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkPollParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            BlockMs = 1,
            ReclaimOlderThanMs = 1,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            AnthropicWorkerID = "Anthropic-Worker-ID",
        };

        string expectedEnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW";
        long expectedBlockMs = 1;
        long expectedReclaimOlderThanMs = 1;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];
        string expectedAnthropicWorkerID = "Anthropic-Worker-ID";

        Assert.Equal(expectedEnvironmentID, parameters.EnvironmentID);
        Assert.Equal(expectedBlockMs, parameters.BlockMs);
        Assert.Equal(expectedReclaimOlderThanMs, parameters.ReclaimOlderThanMs);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
        Assert.Equal(expectedAnthropicWorkerID, parameters.AnthropicWorkerID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkPollParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            BlockMs = 1,
            ReclaimOlderThanMs = 1,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.AnthropicWorkerID);
        Assert.False(parameters.RawHeaderData.ContainsKey("Anthropic-Worker-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkPollParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            BlockMs = 1,
            ReclaimOlderThanMs = 1,

            // Null should be interpreted as omitted for these properties
            Betas = null,
            AnthropicWorkerID = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
        Assert.Null(parameters.AnthropicWorkerID);
        Assert.False(parameters.RawHeaderData.ContainsKey("Anthropic-Worker-ID"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkPollParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            AnthropicWorkerID = "Anthropic-Worker-ID",
        };

        Assert.Null(parameters.BlockMs);
        Assert.False(parameters.RawQueryData.ContainsKey("block_ms"));
        Assert.Null(parameters.ReclaimOlderThanMs);
        Assert.False(parameters.RawQueryData.ContainsKey("reclaim_older_than_ms"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WorkPollParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            AnthropicWorkerID = "Anthropic-Worker-ID",

            BlockMs = null,
            ReclaimOlderThanMs = null,
        };

        Assert.Null(parameters.BlockMs);
        Assert.True(parameters.RawQueryData.ContainsKey("block_ms"));
        Assert.Null(parameters.ReclaimOlderThanMs);
        Assert.True(parameters.RawQueryData.ContainsKey("reclaim_older_than_ms"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkPollParams parameters = new()
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            BlockMs = 1,
            ReclaimOlderThanMs = 1,
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/environments/env_011CZkZ9X2dpNyB7HsEFoRfW/work/poll?beta=true&block_ms=1&reclaim_older_than_ms=1"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WorkPollParams parameters = new()
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            AnthropicWorkerID = "Anthropic-Worker-ID",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["managed-agents-2026-04-01", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
        Assert.Equal(
            ["Anthropic-Worker-ID"],
            requestMessage.Headers.GetValues("Anthropic-Worker-ID")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkPollParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            BlockMs = 1,
            ReclaimOlderThanMs = 1,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
            AnthropicWorkerID = "Anthropic-Worker-ID",
        };

        WorkPollParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
