using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Environments.Work;

namespace Anthropic.Tests.Models.Beta.Environments.Work;

public class WorkUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkUpdateParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            WorkID = "work_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedEnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW";
        string expectedWorkID = "work_id";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedEnvironmentID, parameters.EnvironmentID);
        Assert.Equal(expectedWorkID, parameters.WorkID);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
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
        var parameters = new WorkUpdateParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            WorkID = "work_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkUpdateParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            WorkID = "work_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkUpdateParams parameters = new()
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            WorkID = "work_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/environments/env_011CZkZ9X2dpNyB7HsEFoRfW/work/work_id?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WorkUpdateParams parameters = new()
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            WorkID = "work_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
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
        var parameters = new WorkUpdateParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            WorkID = "work_id",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        WorkUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
