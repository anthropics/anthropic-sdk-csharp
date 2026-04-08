using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Vaults;

namespace Anthropic.Tests.Models.Beta.Vaults;

public class VaultUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VaultUpdateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            DisplayName = "Example vault",
            Metadata = new Dictionary<string, string?>() { { "environment", "production" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedVaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv";
        string expectedDisplayName = "Example vault";
        Dictionary<string, string?> expectedMetadata = new() { { "environment", "production" } };
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedVaultID, parameters.VaultID);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.NotNull(parameters.Metadata);
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
        var parameters = new VaultUpdateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            DisplayName = "Example vault",
            Metadata = new Dictionary<string, string?>() { { "environment", "production" } },
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new VaultUpdateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            DisplayName = "Example vault",
            Metadata = new Dictionary<string, string?>() { { "environment", "production" } },

            // Null should be interpreted as omitted for these properties
            Betas = null,
        };

        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new VaultUpdateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new VaultUpdateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            DisplayName = null,
            Metadata = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.True(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        VaultUpdateParams parameters = new() { VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            new Uri("https://api.anthropic.com/v1/vaults/vlt_011CZkZDLs7fYzm1hXNPeRjv?beta=true"),
            url
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        VaultUpdateParams parameters = new()
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
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
        var parameters = new VaultUpdateParams
        {
            VaultID = "vlt_011CZkZDLs7fYzm1hXNPeRjv",
            DisplayName = "Example vault",
            Metadata = new Dictionary<string, string?>() { { "environment", "production" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        VaultUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
