using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Environments.Work;

namespace Anthropic.Tests.Models.Beta.Environments.Work;

public class WorkHeartbeatParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkHeartbeatParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            WorkID = "work_id",
            DesiredTtlSeconds = 0,
            ExpectedLastHeartbeat = "expected_last_heartbeat",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedEnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW";
        string expectedWorkID = "work_id";
        long expectedDesiredTtlSeconds = 0;
        string expectedExpectedLastHeartbeat = "expected_last_heartbeat";
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedEnvironmentID, parameters.EnvironmentID);
        Assert.Equal(expectedWorkID, parameters.WorkID);
        Assert.Equal(expectedDesiredTtlSeconds, parameters.DesiredTtlSeconds);
        Assert.Equal(expectedExpectedLastHeartbeat, parameters.ExpectedLastHeartbeat);
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
        var parameters = new WorkHeartbeatParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            WorkID = "work_id",
            DesiredTtlSeconds = 0,
            ExpectedLastHeartbeat = "expected_last_heartbeat",
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkHeartbeatParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            WorkID = "work_id",
            DesiredTtlSeconds = 0,
            ExpectedLastHeartbeat = "expected_last_heartbeat",

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkHeartbeatParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            WorkID = "work_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.DesiredTtlSeconds);
        Assert.False(parameters.RawQueryData.ContainsKey("desired_ttl_seconds"));
        Assert.Null(parameters.ExpectedLastHeartbeat);
        Assert.False(parameters.RawQueryData.ContainsKey("expected_last_heartbeat"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WorkHeartbeatParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            WorkID = "work_id",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            DesiredTtlSeconds = null,
            ExpectedLastHeartbeat = null,
        };

        Assert.Null(parameters.DesiredTtlSeconds);
        Assert.True(parameters.RawQueryData.ContainsKey("desired_ttl_seconds"));
        Assert.Null(parameters.ExpectedLastHeartbeat);
        Assert.True(parameters.RawQueryData.ContainsKey("expected_last_heartbeat"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkHeartbeatParams parameters = new()
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            WorkID = "work_id",
            DesiredTtlSeconds = 0,
            ExpectedLastHeartbeat = "expected_last_heartbeat",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/environments/env_011CZkZ9X2dpNyB7HsEFoRfW/work/work_id/heartbeat?beta=true&desired_ttl_seconds=0&expected_last_heartbeat=expected_last_heartbeat"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WorkHeartbeatParams parameters = new()
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            WorkID = "work_id",
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
        var parameters = new WorkHeartbeatParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            WorkID = "work_id",
            DesiredTtlSeconds = 0,
            ExpectedLastHeartbeat = "expected_last_heartbeat",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        WorkHeartbeatParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
